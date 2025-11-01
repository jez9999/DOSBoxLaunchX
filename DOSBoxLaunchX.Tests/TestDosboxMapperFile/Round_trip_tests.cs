using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;
using DOSBoxLaunchX.Tests.Helpers;

namespace DOSBoxLaunchX.Tests.TestDosboxMapperFile;

[TestFixture]
public class Round_trip_tests {
	[Test]
	public void Parse_roundtrip_preserves_comments_blank_lines_and_whitespace() {
		// Arrange
		string input = TestHelpers.GetAssetString("mapper_weird_whitespace.map");

		// Act
		var file = DosboxMapperFile.FromText(input);
		string output = file.ToText();

		// Assert
		output.Should().Be(input);
	}

	[Test]
	public void Parse_roundtrip_with_one_mapping_change_preserves_formatting() {
		// Arrange
		string input = TestHelpers.GetAssetString("mapper_weird_whitespace.map");
		string expected = TestHelpers.GetAssetString("mapper_weird_whitespace_reboot_92.map");

		// Act
		var file = DosboxMapperFile.FromText(input);
		file.SetMapping("sdl1", "hand_reboot", "key 92 host");
		string output = file.ToText();

		// Assert
		output.Should().Be(expected);
	}

	[Test]
	public void Parse_roundtrip_preserves_trailing_newline_absence() {
		// Arrange
		string text = "[sdl1]\nhand_reset \"key 114 host\""; // No trailing newline

		// Act
		var file = DosboxMapperFile.FromText(text);
		string output = file.ToText();

		// Assert
		output.Should().Be(text);
	}

	[Test]
	public void Parse_roundtrip_normalizes_mixed_newlines_to_unix() {
		// Arrange
		string input = "[sdl1]\r\nhand_reset \"key 114 host\"\r\n";
		string expected = "[sdl1]\nhand_reset \"key 114 host\"\n";

		// Act
		var file = DosboxMapperFile.FromText(input);
		string output = file.ToText();

		// Assert
		output.Should().Be(expected);
	}

	[Test]
	public void Parse_roundtrip_utf8_characters_are_preserved() {
		// Arrange
		string text = "[sdl1]\nkey_custom \"héllo🌍\"";

		// Act
		var file = DosboxMapperFile.FromText(text);
		string output = file.ToText();

		// Assert
		output.Should().Be(text);
	}

	[Test]
	public void Large_mapper_file_mappings_modifications_perform_ok() {
		// Arrange
		string input = TestHelpers.GetAssetString("mapper_large.map");
		string expected = TestHelpers.GetAssetString("mapper_large_expected.map");

		// Act
		var file = DosboxMapperFile.FromText(input);
		file.SetMapping("sdl1", "hand_reset", "key 22 mod1");
		file.SetMapping("sdl1", "hand_mapper", "");
		file.SetMapping("sdl1", "hand_copyall", "key 123");
		file.SetMapping(" sdl1 ", " hand_copyall ", "key 234"); // Whitespace surrounding key/section needs trimming
		file.SetMapping("sdl1", "hand_incfskip", "key 109 host");
		file.SetMapping("sdl1", "jaxis_0_1-", "key 67 host");
		file.SetMapping("sdl1", "jaxis_0_1+", "key 68 host");
		file.SetMapping("SDL1", "some!action.", "some-value"); // Missing key; add to end
		file.SetMapping("SDL1", "other!action.", ""); // Missing key 2; add to end
		file.SetMapping("misc", "foo", "bar"); // Missing section; add to end
		string output = file.ToText();

		// Assert
		output.Should().Be(expected);
	}
}
