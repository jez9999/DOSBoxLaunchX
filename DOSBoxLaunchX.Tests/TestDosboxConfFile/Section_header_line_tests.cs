using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxConfFile;

[TestFixture]
public class Section_header_line_tests {
	[Test]
	public void Section_with_trailing_text_preserves_name_and_raw() {
		// Arrange
		string text = "[autoexec]extra";

		// Act
		var file = DosboxConfFile.FromText(text);
		var header = file.Lines.OfType<SectionHeaderLine>().First();

		// Assert
		header.Should().BeOfType<SectionHeaderLine>();
		header.Should().BeEquivalentTo(new { SectionName = "autoexec", RawText = "[autoexec]extra" });
	}

	[Test]
	public void Section_names_are_case_insensitive() {
		// Arrange
		string text =
			"""
			[CPU]
			cycles=auto
			cycles=fixed
			""";

		// Act
		var file = DosboxConfFile.FromText(text);

		// Assert
		file.GetSetting("cpu", "cycles").Count().Should().Be(2);
	}

	[Test]
	public void Section_name_with_spaces_is_valid() {
		// Arrange
		string text = "[midi device]";

		// Act
		var file = DosboxConfFile.FromText(text);
		var header = file.Lines.OfType<SectionHeaderLine>().First();

		// Assert
		header.Should().BeOfType<SectionHeaderLine>();
		header.Should().BeEquivalentTo(new { SectionName = "midi device", RawText = "[midi device]" });
	}

	[Test]
	public void Parse_section_header_with_spaces_is_valid() {
		// Arrange
		string text =
			"""
			[midi device]
			mpu401=intelligent
			""";

		// Act
		var file = DosboxConfFile.FromText(text);
		var header = file.Lines.OfType<SectionHeaderLine>().First();
		var setting = file.GetSetting("midi device", "mpu401").Single();

		// Assert
		header.Should().BeOfType<SectionHeaderLine>();
		header.Should().BeEquivalentTo(new { SectionName = "midi device", RawText = "[midi device]" });
		setting.Should().BeEquivalentTo(new { Value = "intelligent" });
	}
}
