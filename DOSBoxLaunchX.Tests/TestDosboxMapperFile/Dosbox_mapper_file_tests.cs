using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxMapperFile;

[TestFixture]
public class Dosbox_mapper_file_tests {
	[Test]
	public void Parse_empty_file_contains_single_blank_line() {
		// Arrange
		var fileEmpty = DosboxMapperFile.FromEmpty();
		var fileText = DosboxMapperFile.FromText(string.Empty);

		// Act
		var linesEmpty = fileEmpty.Lines;
		var linesText = fileText.Lines;

		// Assert
		linesEmpty.Should().HaveCount(1);
		linesEmpty[0].Should().BeOfType<MapperBlankLine>().Which.RawText.Should().Be(string.Empty);

		linesText.Should().HaveCount(1);
		linesText[0].Should().BeOfType<MapperBlankLine>().Which.RawText.Should().Be(string.Empty);
	}

	[Test]
	public void Parse_file_with_section_and_mapping_fromtext_parses_correctly() {
		// Arrange
		string text =
			"""
            [SDL1]
            hand_reset "key 114 host"
            """;

		// Act
		var file = DosboxMapperFile.FromText(text);
		var mapping = file.GetMapping("sdl1", "hand_reset").ToList();

		// Assert
		mapping.Should().HaveCount(1);
		mapping[0].Should().BeEquivalentTo(new { Value = "key 114 host" });
	}

	[Test]
	public void Parse_file_with_section_and_mapping_fromlines_parses_correctly() {
		// Arrange
		List<string> text = [
			"[SDL1]",
			"hand_reset \"key 114 host\"",
		];

		// Act
		var file = DosboxMapperFile.FromLines(text);
		var mapping = file.GetMapping("sdl1", "hand_reset").ToList();

		// Assert
		mapping.Should().HaveCount(1);
		mapping[0].Should().BeEquivalentTo(new { Value = "key 114 host" });
	}

	[Test]
	public void Get_mapping_returns_all_duplicates() {
		// Arrange
		string text =
			"""
	        [SDL1]
	        hand_reset "key 114 host"
	        hand_reset "key 115 host"
	        """;
		var file = DosboxMapperFile.FromText(text);

		// Act
		var mappings = file.GetMapping("sdl1", "hand_reset").ToList();

		// Assert
		mappings.Should().HaveCount(2);
		mappings.Should().BeEquivalentTo([
			new { Value = "key 114 host" },
			new { Value = "key 115 host" }
		], options => options.WithStrictOrdering());
	}

	[Test]
	public void Set_mapping_replaces_all_existing_instances() {
		// Arrange
		string text =
			"""
	        [SDL1]
	        hand_reset "key 114 host"
	        hand_reset "key 115 host"
	        """;
		var file = DosboxMapperFile.FromText(text);

		// Act
		file.SetMapping("sdl1", "hand_reset", "key 116 host");
		var updated = file.GetMapping("sdl1", "hand_reset").ToList();

		// Assert
		updated.Should().HaveCount(2);
		updated.All(s => s.Value == "key 116 host").Should().BeTrue();
	}

	[Test]
	public void Set_mapping_adds_section_if_doesnt_exist_at_end() {
		// Arrange
		var file = DosboxMapperFile.FromEmpty();

		// Act
		file.SetMapping("sdl2", "hand_mapper", "key 117 host");
		var lines = file.Lines;
		var header = lines[lines.Count - 2];
		var lastMapping = lines[lines.Count - 1];

		// Assert
		header.Should().BeOfType<MapperSectionHeaderLine>().Which.SectionName.Should().Be("sdl2");
		lastMapping.Should().BeOfType<MapperMappingLine>().Which.Should().BeEquivalentTo(new {
			Key = "hand_mapper",
			Value = "key 117 host"
		});
	}

	[Test]
	public void Parse_modify_serialize_preserves_other_lines() {
		// Arrange
		string text =
			"""
	        [SDL1]
	        hand_reset "key 114 host"
	        hand_quickrun "key 113 host"
	        """;
		var file = DosboxMapperFile.FromText(text);

		// Act
		file.SetMapping("sdl1", "hand_reset", "key 115 host");
		string serialized = file.ToText();
		var lines = serialized.Split('\n');

		// Assert
		lines.Should().BeEquivalentTo([
			"[SDL1]",
			"hand_reset \"key 115 host\"",
			"hand_quickrun \"key 113 host\""
		], options => options.WithStrictOrdering());
	}

	[Test]
	public void Blank_lines_are_interpreted_correctly() {
		// Arrange
		string text = "\n   \n";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var lines = file.Lines.ToList();

		// Assert
		lines.Should().HaveCount(3);
		lines.All(l => l is MapperBlankLine).Should().BeTrue();
		lines.Should().BeEquivalentTo([
			new { RawText = "" },
			new { RawText = "   " },
			new { RawText = "" }
		], options => options.WithStrictOrdering());
	}

	[Test]
	public void Malformed_section_header_without_closing_bracket_is_malformed_line() {
		// Arrange
		string text = "[abc";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var line = file.Lines[0];

		// Assert
		line.Should().BeOfType<MapperMalformedLine>().Which.RawText.Should().Be("[abc");
	}
}
