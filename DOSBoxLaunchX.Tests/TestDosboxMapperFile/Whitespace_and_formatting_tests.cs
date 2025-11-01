using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxMapperFile;

[TestFixture]
public class Whitespace_and_formatting_tests {
	[Test]
	public void Leading_and_trailing_whitespace_is_trimmed_before_classification() {
		// Arrange
		string text = "   [SDL1]   \n   hand_core \"key 1\"   ";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var section = file.Lines.OfType<MapperSectionHeaderLine>().First();
		var mapping = file.Lines.OfType<MapperMappingLine>().First();

		// Assert
		section.Should().BeOfType<MapperSectionHeaderLine>();
		mapping.Should().BeOfType<MapperMappingLine>();
		section.Should().BeEquivalentTo(new { SectionName = "sdl1" });
		mapping.Should().BeEquivalentTo(new { Section = "sdl1", Key = "hand_core", Value = "key 1" });
	}

	[Test]
	public void Spaces_around_key_and_value_are_trimmed_but_raw_text_preserved() {
		// Arrange
		string text = "[SDL1]\nhand_core   \"key 1\"";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var mapping = file.Lines.OfType<MapperMappingLine>().First();
		string output = file.ToText();

		// Assert
		mapping.Should().BeOfType<MapperMappingLine>();
		mapping.Should().BeEquivalentTo(new {
			Section = "sdl1",
			Key = "hand_core",
			Value = "key 1",
			RawText = "hand_core   \"key 1\""
		});
		output.Should().Be(text);
	}

	[Test]
	public void Tab_for_separator_is_malformed() {
		// Arrange
		string text = "[SDL1]\nhand_reset\t\"key 1\"";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var mapping = file.Lines.OfType<MapperMalformedLine>().First();

		// Assert
		mapping.Should().BeOfType<MapperMalformedLine>();
		mapping.Should().BeEquivalentTo(new { RawText = "hand_reset\t\"key 1\"" });
	}

	[Test]
	public void Blank_lines_with_spaces_are_ignored() {
		// Arrange
		string text = "[SDL1]\n   \nhand_reset \"key 1\"";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var lines = file.Lines.ToList();

		// Assert
		lines.Count(l => l is MapperSectionHeaderLine).Should().Be(1);
		lines.Count(l => l is MapperIgnoredLine).Should().Be(1);
		lines.Count(l => l is MapperMappingLine).Should().Be(1);
		lines.OfType<MapperIgnoredLine>().First().RawText.Should().Be("   ");
		lines.OfType<MapperMappingLine>().First().Should().BeEquivalentTo(new { Value = "key 1" });
	}

	[Test]
	public void Trailing_whitespace_after_closing_bracket_is_preserved_in_raw_text() {
		// Arrange
		string text = "[SDL1]   ";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var header = file.Lines.OfType<MapperSectionHeaderLine>().First();

		// Assert
		header.Should().BeOfType<MapperSectionHeaderLine>();
		header.Should().BeEquivalentTo(new { SectionName = "sdl1", RawText = "[SDL1]   " });
	}

	[Test]
	public void Mapping_with_empty_value_is_parsed_as_empty_string() {
		// Arrange
		string text = "[SDL1]\nhand_mapper";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var mapping = file.Lines.OfType<MapperMappingLine>().First();

		// Assert
		mapping.Should().BeOfType<MapperMappingLine>();
		mapping.Value.Should().Be("");
	}

	[Test]
	public void Spaces_surrounding_key_name_are_preserved_in_raw_text_but_trimmed_in_key() {
		// Arrange
		string text = "[SDL1]\nhand_test    \"100\"";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var mapping = file.Lines.OfType<MapperMappingLine>().First();

		// Assert
		mapping.Should().BeOfType<MapperMappingLine>();
		mapping.Should().BeEquivalentTo(new {
			Key = "hand_test",
			Value = "100",
			RawText = "hand_test    \"100\""
		});
	}
}
