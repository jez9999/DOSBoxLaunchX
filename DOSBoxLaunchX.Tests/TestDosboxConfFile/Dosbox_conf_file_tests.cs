using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;
using DOSBoxLaunchX.Tests.Helpers;

namespace DOSBoxLaunchX.Tests.TestDosboxConfFile;

[TestFixture]
public class Dosbox_conf_file_tests {
	[Test]
	public void Parse_empty_file_contains_single_empty_comment_line() {
		// Arrange
		var fileEmpty = DosboxConfFile.FromEmpty();
		var fileText = DosboxConfFile.FromText(string.Empty);

		// Act
		var linesEmpty = fileEmpty.Lines;
		var linesText = fileText.Lines;

		// Assert
		linesEmpty.Should().HaveCount(1);
		linesEmpty[0].Should().BeOfType<CommentLine>().Which.RawText.Should().Be(string.Empty);

		linesText.Should().HaveCount(1);
		linesText[0].Should().BeOfType<CommentLine>().Which.RawText.Should().Be(string.Empty);
	}

	[Test]
	public void Parse_file_with_section_and_settings_fromtext_parses_correctly() {
		// Arrange
		string text =
			"""
			[cpu]
			cycles=auto
			""";

		// Act
		var file = DosboxConfFile.FromText(text);
		var cpuSettings = file.GetSetting("cpu", "cycles").ToList();

		// Assert
		cpuSettings.Should().HaveCount(1);
		cpuSettings[0].Should().BeEquivalentTo(new { Value = "auto" });
	}

	[Test]
	public void Parse_file_with_section_and_settings_fromlines_parses_correctly() {
		// Arrange
		List<string> text = [
			"[cpu]",
			"cycles=auto",
		];
		var file = DosboxConfFile.FromLines(text);

		// Act
		var cpuSettings = file.GetSetting("cpu", "cycles").ToList();

		// Assert
		cpuSettings.Should().HaveCount(1);
		cpuSettings[0].Should().BeEquivalentTo(new { Value = "auto" });
	}

	[Test]
	public void Get_setting_returns_all_duplicates() {
		// Arrange
		string text =
			"""
			[cpu]
			cycles=auto
			cycles=fixed
			""";
		var file = DosboxConfFile.FromText(text);

		// Act
		var settings = file.GetSetting("cpu", "cycles").ToList();

		// Assert
		settings.Should().HaveCount(2);
		settings.Should().BeEquivalentTo([
			new { Value = "auto" },
			new { Value = "fixed" }
		], options => options.WithStrictOrdering());
	}

	[Test]
	public void Set_setting_replaces_all_existing_instances() {
		// Arrange
		string text =
			"""
			[cpu]
			cycles=auto
			cycles=fixed
			""";
		var file = DosboxConfFile.FromText(text);

		// Act
		file.SetSetting("cpu", "cycles", "max");
		var updated = file.GetSetting("cpu", "cycles").ToList();

		// Assert
		updated.Should().HaveCount(2);
		updated.All(s => s.Value == "max").Should().BeTrue();
	}

	[Test]
	public void Set_setting_adds_section_if_doesnt_exist_at_end() {
		// Arrange
		var file = DosboxConfFile.FromEmpty();

		// Act
		file.SetSetting("sblaster", "irq", "7");
		var lines = file.Lines;
		var header = lines[lines.Count - 2];
		var lastSetting = lines[lines.Count - 1];

		// Assert
		header.Should().BeOfType<SectionHeaderLine>().Which.SectionName.Should().Be("sblaster");
		lastSetting.Should().BeOfType<SettingLine>().Which.Should().BeEquivalentTo(new {
			Key = "irq",
			Value = "7"
		});
	}

	[Test]
	public void Set_setting_adds_section_if_doesnt_exist_at_end_with_existing_sections() {
		// Arrange
		string text =
			"""
			[cpu]
			cycles=auto
			[autoexec]
			mount c c:\games
			[misc]
			volume=75
			""";
		var file = DosboxConfFile.FromText(text);

		// Act
		file.SetSetting("sblaster", "irq", "7");
		var lines = file.Lines;

		// Assert
		var lastHeader = lines[^2];
		lastHeader.Should().BeOfType<SectionHeaderLine>().Which.SectionName.Should().Be("sblaster");

		var lastSetting = lines[^1];
		lastSetting.Should().BeOfType<SettingLine>().Which.Should().BeEquivalentTo(new {
			Key = "irq",
			Value = "7"
		});
	}

	[Test]
	public void Parse_modify_serialize_preserves_other_lines() {
		// Arrange
		string text =
			"""
			[cpu]
			cycles=auto
			[misc]
			volume=75
			""";
		var file = DosboxConfFile.FromText(text);

		// Act
		file.SetSetting("cpu", "cycles", "max");
		string serialized = file.ToText();
		var lines = serialized.Split('\n');

		// Assert
		lines.Should().BeEquivalentTo([
			"[cpu]",
			"cycles=max",
			"[misc]",
			"volume=75"
		], options => options.WithStrictOrdering());
	}

	[Test]
	public void Parse_roundtrip_preserves_whitespace_and_comments() {
		// Arrange
		string input = TestHelpers.GetAssetString("weird_whitespace_vol_75.conf");
		var file = DosboxConfFile.FromText(input);

		// Act
		string output = file.ToText();

		// Assert
		output.Should().Be(input);
	}

	[Test]
	public void Parse_roundtrip_one_change_preserves_whitespace_and_comments() {
		// Arrange
		string input = TestHelpers.GetAssetString("weird_whitespace_vol_75.conf");
		string expected = TestHelpers.GetAssetString("weird_whitespace_vol_100.conf");
		var file = DosboxConfFile.FromText(input);

		// Act
		file.SetSetting("misc", "volume", "100");
		string output = file.ToText();

		// Assert
		output.Should().Be(expected);
	}
}
