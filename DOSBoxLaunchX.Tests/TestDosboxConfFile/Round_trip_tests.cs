using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;
using DOSBoxLaunchX.Tests.Helpers;

namespace DOSBoxLaunchX.Tests.TestDosboxConfFile;

[TestFixture]
public class Round_trip_tests {
	[Test]
	public void Parse_roundtrip_preserves_comments_blank_lines_and_whitespace() {
		// Arrange
		string input = TestHelpers.GetAssetString("weird_whitespace_vol_75.conf");

		// Act
		var file = DosboxConfFile.FromText(input);
		string output = file.ToText();

		// Assert
		output.Should().Be(input);
	}

	[Test]
	public void Parse_roundtrip_with_one_setting_change_preserves_formatting() {
		// Arrange
		string input = TestHelpers.GetAssetString("weird_whitespace_vol_75.conf");
		string expected = TestHelpers.GetAssetString("weird_whitespace_vol_100.conf");

		// Act
		var file = DosboxConfFile.FromText(input);
		file.SetSetting("misc", "volume", "100");
		string output = file.ToText();

		// Assert
		output.Should().Be(expected);
	}

	[Test]
	public void Parse_roundtrip_preserves_trailing_newline_absence() {
		// Arrange
		string text = "[cpu]\ncycles=auto"; // No trailing newline

		// Act
		var file = DosboxConfFile.FromText(text);
		string output = file.ToText();

		// Assert
		output.Should().Be(text);
	}

	[Test]
	public void Parse_roundtrip_normalizes_mixed_newlines_to_unix() {
		// Arrange
		string input = "[cpu]\r\ncycles=auto\r\n";
		string expected = "[cpu]\ncycles=auto\n";

		// Act
		var file = DosboxConfFile.FromText(input);
		string output = file.ToText();

		// Assert
		output.Should().Be(expected);
	}

	[Test]
	public void Parse_roundtrip_utf8_characters_are_preserved() {
		// Arrange
		string text = "[cpu]\ntitle=héllo🌍";

		// Act
		var file = DosboxConfFile.FromText(text);
		string output = file.ToText();

		// Assert
		output.Should().Be(text);
	}

	[Test]
	public void Parse_roundtrip_preserves_hash_comments_in_autoexec() {
		// Arrange
		string text = "[autoexec]\n# mount section\nmount c c:\\games";

		// Act
		var file = DosboxConfFile.FromText(text);
		string output = file.ToText();

		// Assert
		output.Should().Be(text);
	}

	[Test]
	public void Large_conf_file_settings_modifications_perform_ok() {
		// Arrange
		string input = TestHelpers.GetAssetString("dosbox-x.large.conf");
		string expected = TestHelpers.GetAssetString("dosbox-x.large.expected.conf");

		// Act
		var file = DosboxConfFile.FromText(input);
		file.SetSetting("sdl", "mapperfile", "mapper-dosbox-x.map");
		file.SetSetting("dosbox", "machine", "tandy");
		file.SetSetting("dosbox", "saveslot", "5");
		file.SetSetting("dosbox", "somesetting", "somevalue"); // Missing key; add to end
		file.SetSetting("misc", "volume", "57"); // Missing section; add to beginning
		file.SetSetting("gus", "gus master volume", "1.23");
		file.SetSetting("gus", "global register read alias", "false");
		file.SetSetting("gus", "gus", "true");
		file.SetSetting("render", "aspect_ratio", "1:2");
		file.SetSetting(" render ", " aspect_ratio ", "3:4"); // Whitespace surrounding key/section needs trimming
		file.SetSetting("render", "scaler", "scan2x");
		file.SetSetting("serial", "serial7", "nullmodem");
		file.SetSetting("ide, sexternary", "enable", "true");
		file.SetSetting("ide, sexternary", "pnp", "false");
		file.AddAutoexecCommands(["mount c c:\\games", "C:", ""], insertAtEnd: false);
		file.AddAutoexecCommands(["", "CD subDIR", "game.EXE"]);
		string output = file.ToText();

		// Assert
		output.Should().Be(expected);
	}
}
