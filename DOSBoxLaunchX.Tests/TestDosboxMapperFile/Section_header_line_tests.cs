using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxMapperFile;

[TestFixture]
public class Section_header_line_tests {
	[Test]
	public void Section_with_trailing_text_preserves_name_and_raw() {
		// Arrange
		string text = "[SDL1]extra";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var header = file.Lines.OfType<MapperSectionHeaderLine>().First();

		// Assert
		header.Should().BeOfType<MapperSectionHeaderLine>();
		header.Should().BeEquivalentTo(new { SectionName = "sdl1", RawText = "[SDL1]extra" });
	}

	[Test]
	public void Section_names_are_case_insensitive() {
		// Arrange
		string text =
			"""
	        [SDL1]
	        hand_reset "key 114 host"
	        hand_reset "key 115 host"
	        """;

		// Act
		var file = DosboxMapperFile.FromText(text);

		// Assert
		file.GetMapping("sdl1", "hand_reset").Count().Should().Be(2);
	}

	[Test]
	public void Section_name_with_spaces_is_valid() {
		// Arrange
		string text = "[sdl 123]";

		// Act
		var file = DosboxMapperFile.FromText(text);
		var header = file.Lines.OfType<MapperSectionHeaderLine>().First();

		// Assert
		header.Should().BeOfType<MapperSectionHeaderLine>();
		header.Should().BeEquivalentTo(new { SectionName = "sdl 123", RawText = "[sdl 123]" });
	}

	[Test]
	public void Parse_section_header_with_spaces_is_valid() {
		// Arrange
		string text =
			"""
	        [sdl 123]
	        hand_reset "key 114 host"
	        """;

		// Act
		var file = DosboxMapperFile.FromText(text);
		var header = file.Lines.OfType<MapperSectionHeaderLine>().First();
		var mapping = file.GetMapping("sdl 123", "hand_reset").Single();

		// Assert
		header.Should().BeOfType<MapperSectionHeaderLine>();
		header.Should().BeEquivalentTo(new { SectionName = "sdl 123", RawText = "[sdl 123]" });
		mapping.Should().BeEquivalentTo(new { Value = "key 114 host" });
	}
}
