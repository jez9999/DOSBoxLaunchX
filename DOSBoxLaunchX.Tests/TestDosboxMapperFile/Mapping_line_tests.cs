using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxMapperFile;

[TestFixture]
public class Mapping_line_tests {
	[Test]
	public void Mapping_line_with_spaces_in_value_parses_correctly() {
		// Arrange
		string text =
			"""
            [SDL1]
            hand_copyall "key 123"
            hand_test "some other value"
            """;

		// Act
		var file = DosboxMapperFile.FromText(text);
		var lines = file.Lines.ToList();
		var firstLine = lines[0];
		var restLines = lines[1..];

		// Assert
		firstLine.Should().BeOfType<MapperSectionHeaderLine>().And.BeEquivalentTo(
			new { SectionName = "sdl1", RawText = "[SDL1]" }
		);
		restLines.Should().AllBeOfType<MapperMappingLine>().And.BeEquivalentTo([
			new { Section = "sdl1", Key = "hand_copyall", Value = "key 123" },
			new { Section = "sdl1", Key = "hand_test", Value = "some other value" },
		], options => options.WithStrictOrdering());
	}

	[Test]
	public void Empty_value_is_valid() {
		// Arrange
		string text = "hand_mapper";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var mapping = file.Lines.OfType<MapperMappingLine>().First();

		// Assert
		mapping.Should().BeOfType<MapperMappingLine>();
		mapping.Should().BeEquivalentTo(new {
			Section = (string?)null,
			Key = "hand_mapper",
			Value = "",
			RawText = "hand_mapper"
		});
	}

	[Test]
	public void Keys_before_any_section_go_to_null_section() {
		// Arrange
		string text =
			"""
	        hand_reset "key 1"
	        [SDL1]
	        hand_quickrun "key 2"
	        """;

		// Act
		var file = DosboxMapperFile.FromText(text);
		var result = file.GetMapping(null, "hand_reset").First();

		// Assert
		result.Should().BeOfType<MapperMappingLine>();
		result.Should().BeEquivalentTo(new { Value = "key 1" });
	}

	[Test]
	public void Lines_with_invalid_mapping_value_are_marked_malformed() {
		string text = "[SDL1]\ninvalid_mapping value_without_quotes";

		var file = DosboxMapperFile.FromText(text);
		var line = file.Lines[1];

		line.Should().BeOfType<MapperMalformedLine>().Which
			.RawText.Should().Be("invalid_mapping value_without_quotes");
	}

	[Test]
	public void Value_with_embedded_quotes_is_preserved() {
		string text = "[SDL1]\nkey \"foo\\\"bar\"";

		var file = DosboxMapperFile.FromText(text);
		var mapping = file.Lines.OfType<MapperMappingLine>().First();

		mapping.Value.Should().Be("foo\\\"bar");
	}

	[Test]
	public void Mapping_line_with_opening_quote_but_no_closing_quote_is_malformed() {
		// Arrange
		string text = "[SDL1]\nkey \"value_without_closing";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var line = file.Lines[1];

		// Assert
		line.Should().BeOfType<MapperMalformedLine>().Which
			.RawText.Should().Be("key \"value_without_closing");
	}

	[Test]
	public void Mapping_line_with_only_spaces_after_key_parses_as_empty_value() {
		// Arrange
		string text = "hand_mapper    ";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var mapping = file.Lines.OfType<MapperMappingLine>().First();

		// Assert
		mapping.Should().BeOfType<MapperMappingLine>();
		mapping.Should().BeEquivalentTo(new {
			Section = (string?)null,
			Key = "hand_mapper",
			Value = "",
			RawText = "hand_mapper    "
		});
	}

	[Test]
	public void Mapping_line_with_empty_quoted_value_parses_as_empty_value() {
		// Arrange
		string text = @"hand_mapper """"";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var mapping = file.Lines.OfType<MapperMappingLine>().First();

		// Assert
		mapping.Should().BeOfType<MapperMappingLine>();
		mapping.Should().BeEquivalentTo(new {
			Section = (string?)null,
			Key = "hand_mapper",
			Value = "",
			RawText = @"hand_mapper """""
		});
	}

	[Test]
	public void Setting_empty_mapping_value_outputs_key_only() {
		// Arrange
		var file = DosboxMapperFile.FromEmpty();

		// Act
		file.SetMapping("sdl1", "hand_mapper", "");
		var output = file.ToText();

		// Assert
		output.Should().Be("\n[sdl1]\nhand_mapper");
	}
}
