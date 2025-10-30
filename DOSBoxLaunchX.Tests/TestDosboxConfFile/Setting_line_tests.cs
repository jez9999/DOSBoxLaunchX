using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxConfFile;

[TestFixture]
public class Setting_line_tests {
	[Test]
	public void Setting_line_with_spaces_and_value_parses_correctly() {
		// Arrange
		string text = "core = dynamic";

		// Act
		var file = DosboxConfFile.FromText(text);
		var setting = file.Lines.OfType<SettingLine>().First();

		// Assert
		setting.Should().BeOfType<SettingLine>();
		setting.Should().BeEquivalentTo(new {
			Section = (string?)null,
			Key = "core",
			Value = "dynamic",
			RawText = "core = dynamic"
		});
	}

	[Test]
	public void Empty_value_is_valid() {
		// Arrange
		string text = "cycles=";

		// Act
		var file = DosboxConfFile.FromText(text);
		var setting = file.Lines.OfType<SettingLine>().First();

		// Assert
		setting.Should().BeOfType<SettingLine>();
		setting.Should().BeEquivalentTo(new {
			Section = (string?)null,
			Key = "cycles",
			Value = "",
			RawText = "cycles="
		});
	}

	[Test]
	public void Value_with_hash_is_literal() {
		// Arrange
		string text = "title = hello world # literal";

		// Act
		var file = DosboxConfFile.FromText(text);
		var setting = file.Lines.OfType<SettingLine>().First();

		// Assert
		setting.Should().BeOfType<SettingLine>();
		setting.Should().BeEquivalentTo(new {
			Section = (string?)null,
			Key = "title",
			Value = "hello world # literal",
			RawText = "title = hello world # literal"
		});
	}

	[Test]
	public void Keys_before_any_section_go_to_null_section() {
		// Arrange
		string text =
			"""
			foo=bar
			[autoexec]
			first
			second
			""";
		var file = DosboxConfFile.FromText(text);

		// Act
		var result = file.GetSetting(null, "foo").First();

		// Assert
		result.Should().BeOfType<SettingLine>();
		result.Should().BeEquivalentTo(new { Value = "bar" });
	}
}
