using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxConfFile;

[TestFixture]
public class Whitespace_and_formatting_tests {
	[Test]
	public void Leading_and_trailing_whitespace_is_trimmed_before_classification() {
		// Arrange
		string text = "   [cpu]   \n   cycles = auto   ";

		// Act
		var file = DosboxConfFile.FromText(text);
		var section = file.Lines.OfType<SectionHeaderLine>().First();
		var setting = file.Lines.OfType<SettingLine>().First();

		// Assert
		section.Should().BeOfType<SectionHeaderLine>();
		setting.Should().BeOfType<SettingLine>();
		section.Should().BeEquivalentTo(new { SectionName = "cpu" });
		setting.Should().BeEquivalentTo(new { Section = "cpu", Key = "cycles", Value = "auto" });
	}

	[Test]
	public void Multiple_spaces_around_equals_are_trimmed_but_raw_text_preserved() {
		// Arrange
		string text = "[cpu]\ncycles   =   max";

		// Act
		var file = DosboxConfFile.FromText(text);
		var setting = file.Lines.OfType<SettingLine>().First();
		string output = file.ToText();

		// Assert
		setting.Should().BeOfType<SettingLine>();
		setting.Should().BeEquivalentTo(new {
			Section = "cpu",
			Key = "cycles",
			Value = "max",
			RawText = "cycles   =   max"
		});
		output.Should().Be(text);
	}

	[Test]
	public void Tabs_around_equals_are_treated_like_spaces() {
		// Arrange
		string text = "[cpu]\ncycles\t=\tdynamic";

		// Act
		var file = DosboxConfFile.FromText(text);
		var setting = file.Lines.OfType<SettingLine>().First();

		// Assert
		setting.Should().BeOfType<SettingLine>();
		setting.Should().BeEquivalentTo(new { Section = "cpu", Key = "cycles", Value = "dynamic" });
	}

	[Test]
	public void Blank_lines_with_spaces_are_ignored() {
		// Arrange
		string text = "[cpu]\n   \ncycles=auto";

		// Act
		var file = DosboxConfFile.FromText(text);
		var lines = file.Lines.ToList();

		// Assert
		lines.Count(l => l is SectionHeaderLine).Should().Be(1);
		lines.Count(l => l is IgnoredLine).Should().Be(1);
		lines.Count(l => l is SettingLine).Should().Be(1);
		lines.OfType<IgnoredLine>().First().RawText.Should().Be("   ");
		lines.OfType<SettingLine>().First().Should().BeEquivalentTo(new { Value = "auto" });
	}

	[Test]
	public void Whitespace_in_autoexec_is_trimmed_but_preserved_in_output() {
		// Arrange
		string text = "[autoexec]\n  mount c c:\\games\\mygame  \n  mygame.exe  ";

		// Act
		var file = DosboxConfFile.FromText(text);
		var autoexecLines = file.Lines.OfType<AutoexecLine>().ToList();
		string output = file.ToText();

		// Assert
		autoexecLines.Should().HaveCount(2);
		autoexecLines[0].Should().BeOfType<AutoexecLine>();
		autoexecLines[1].Should().BeOfType<AutoexecLine>();
		autoexecLines.Should().BeEquivalentTo(new[] {
			new { RawText = "  mount c c:\\games\\mygame  ", Command = "mount c c:\\games\\mygame" },
			new { RawText = "  mygame.exe  ", Command = "mygame.exe" }
		}, options => options.WithStrictOrdering());
		output.Should().Be(text);
	}

	[Test]
	public void Autoexec_blank_lines_are_preserved_in_roundtrip() {
		// Arrange
		string text = "[autoexec]\n\nmount c c:\\games\n\nc:\n";

		// Act
		var file = DosboxConfFile.FromText(text);
		string output = file.ToText();

		// Assert
		output.Should().Be(text);
	}

	[Test]
	public void Trailing_whitespace_after_closing_bracket_is_ignored_but_preserved_in_raw_text() {
		// Arrange
		string text = "[cpu]   ";

		// Act
		var file = DosboxConfFile.FromText(text);
		var header = file.Lines.OfType<SectionHeaderLine>().First();

		// Assert
		header.Should().BeOfType<SectionHeaderLine>();
		header.Should().BeEquivalentTo(new { SectionName = "cpu", RawText = "[cpu]   " });
	}

	[Test]
	public void Whitespace_before_comment_is_trimmed_but_preserved_in_raw_text() {
		// Arrange
		string text = "   #comment with leading spaces";

		// Act
		var file = DosboxConfFile.FromText(text);
		var comment = file.Lines[0];

		// Assert
		comment.Should().BeOfType<CommentLine>();
		comment.Should().BeEquivalentTo(new {
			Comment = "comment with leading spaces",
			RawText = "   #comment with leading spaces"
		});
	}

	[Test]
	public void Setting_with_empty_value_is_parsed_as_empty_string() {
		// Arrange
		string text = "[sdl]\ntitle=";

		// Act
		var file = DosboxConfFile.FromText(text);
		var setting = file.Lines.OfType<SettingLine>().First();

		// Assert
		setting.Should().BeOfType<SettingLine>();
		setting.Value.Should().Be("");
	}

	[Test]
	public void Spaces_in_key_name_are_preserved_in_raw_text_but_trimmed_in_key() {
		// Arrange
		string text = "[cpu]\ncycles per second = 1000";

		// Act
		var file = DosboxConfFile.FromText(text);
		var setting = file.Lines.OfType<SettingLine>().First();

		// Assert
		setting.Should().BeOfType<SettingLine>();
		setting.Should().BeEquivalentTo(new {
			Key = "cycles per second",
			Value = "1000",
			RawText = "cycles per second = 1000"
		});
	}
}
