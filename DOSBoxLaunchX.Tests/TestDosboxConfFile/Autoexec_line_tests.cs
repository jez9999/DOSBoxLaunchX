using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxConfFile;

[TestFixture]
public class Autoexec_line_tests {
	[Test]
	public void Parse_file_with_autoexec_parses_commands() {
		// Arrange
		string text =
			"""
			[autoexec]
			mount c c:\games
			c:
			game.exe
			""";

		// Act
		var file = DosboxConfFile.FromText(text);
		var autoexecLines = file.Lines.OfType<AutoexecLine>().ToList();

		// Assert
		autoexecLines.Should().HaveCount(3);
		autoexecLines.Should().BeEquivalentTo([
			new { Command = "mount c c:\\games" },
			new { Command = "c:" },
			new { Command = "game.exe" }
		]);
	}

	[Test]
	public void Add_autoexec_command_to_empty_file_creates_section_and_command() {
		// Arrange
		var file = DosboxConfFile.FromEmpty();

		// Act
		file.AddAutoexecCommand("game.exe");
		var header = file.Lines.OfType<SectionHeaderLine>().FirstOrDefault();
		var command = file.Lines.OfType<AutoexecLine>().FirstOrDefault();

		// Assert
		header.Should().BeEquivalentTo(new { SectionName = "autoexec" });
		command.Should().BeEquivalentTo(new { Command = "game.exe" });
	}

	[Test]
	public void Add_autoexec_commands_insert_at_start_and_end() {
		// Arrange
		string text =
			"""
			[autoexec]
			first
			second
			""";
		var file = DosboxConfFile.FromText(text);

		// Act
		file.AddAutoexecCommands(["start1.1", "start1.2"], insertAtEnd: false);
		file.AddAutoexecCommands(["end1.1", "end1.2"]);
		var autoexecLines = file.Lines.OfType<AutoexecLine>().Select(l => l.Command).ToList();

		// Assert
		autoexecLines.Should().BeEquivalentTo([
			"start1.1",
			"start1.2",
			"first",
			"second",
			"end1.1",
			"end1.2"
		]);
	}

	[Test]
	public void Autoexec_commands_with_equals_are_not_treated_as_settings() {
		// Arrange
		string text =
			"""
			[autoexec]
			SET PATH=C:\DOS
			""";
		var file = DosboxConfFile.FromText(text);

		// Act
		var autoexecLines = file.Lines.OfType<AutoexecLine>().ToList();

		// Assert
		autoexecLines.Should().HaveCount(1);
		autoexecLines[0].Should().BeEquivalentTo(new { Command = @"SET PATH=C:\DOS" });
	}
}
