using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxMapperFile;

[TestFixture]
public class Ordering_and_overrides_tests {
	[Test]
	public void Later_section_overrides_same_key_in_earlier_section() {
		// Arrange
		string text =
			"""
            [SDL1]
            hand_reset "key 114 host"
            [SDL1]
            hand_reset "key 115 host"
            """;

		// Act
		var file = DosboxMapperFile.FromText(text);
		var value = file.GetMapping("sdl1", "hand_reset").Last().Value;

		// Assert
		value.Should().Be("key 115 host");
	}

	[Test]
	public void Duplicate_keys_in_same_section_last_one_wins() {
		// Arrange
		string text =
			"""
            [SDL1]
            hand_reset "key 114 host"
            hand_reset "key 115 host"
            hand_reset "key 116 host"
            """;

		// Act
		var file = DosboxMapperFile.FromText(text);
		var value = file.GetMapping("sdl1", "hand_reset").Last().Value;

		// Assert
		value.Should().Be("key 116 host");
	}

	[Test]
	public void Adding_new_mapping_keeps_original_order() {
		// Arrange
		string text =
			"""
	        [SDL1]
	        hand_reset "key 114 host"
	        hand_quickrun "key 113 host"
	        """;

		// Act
		var file = DosboxMapperFile.FromText(text);
		file.SetMapping("sdl1", "hand_shutdown", "key 290 mod1");
		var serialized = file.ToText().Split('\n');

		// Assert
		serialized.Should().BeEquivalentTo([
			"[SDL1]",
			"hand_reset \"key 114 host\"",
			"hand_quickrun \"key 113 host\"",
			"hand_shutdown \"key 290 mod1\""
		], options => options.WithStrictOrdering());
	}

	[Test]
	public void Merging_sections_retains_non_overridden_mappings() {
		// Arrange
		string text =
			"""
	        [SDL1]
	        hand_reset "key 114 host"
	        hand_quickrun "key 113 host"
	        [SDL1]
	        hand_reset "key 115 host"
	        """;

		// Act
		var file = DosboxMapperFile.FromText(text);
		var allQuickrun = file.GetMapping("sdl1", "hand_quickrun").ToList();
		var allReset = file.GetMapping("sdl1", "hand_reset").ToList();

		// Assert
		allQuickrun.Should().HaveCount(1);
		allQuickrun[0].Should().BeEquivalentTo(new { Value = "key 113 host" });

		allReset.Should().HaveCount(2);
		allReset.Last().Should().BeEquivalentTo(new { Value = "key 115 host" });
	}
}
