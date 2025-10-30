using System.Linq;
using NUnit.Framework;
using AwesomeAssertions;
using DOSBoxLaunchX.Logic.DosboxParsing;

namespace DOSBoxLaunchX.Tests.TestDosboxConfFile;

[TestFixture]
public class Ordering_and_overrides_tests {
	[Test]
	public void Later_section_overrides_same_key_in_earlier_section() {
		// Arrange
		string text =
			"""
			[cpu]
			cycles=auto
			[cpu]
			cycles=max
			""";

		// Act
		var file = DosboxConfFile.FromText(text);
		var value = file.GetSetting("cpu", "cycles").Last().Value;

		// Assert
		value.Should().Be("max");
	}

	[Test]
	public void Duplicate_keys_in_same_section_last_one_wins() {
		// Arrange
		string text =
			"""
			[cpu]
			cycles=1000
			cycles=2000
			cycles=auto
			""";

		// Act
		var file = DosboxConfFile.FromText(text);
		var value = file.GetSetting("cpu", "cycles").Last().Value;

		// Assert
		value.Should().Be("auto");
	}

	[Test]
	public void Adding_new_setting_keeps_original_order() {
		// Arrange
		string text =
			"""
			[cpu]
			cycles=auto
			core=dynamic
			""";

		// Act
		var file = DosboxConfFile.FromText(text);
		file.SetSetting("cpu", "frameskip", "2");
		var serialized = file.ToText().Split('\n');

		// Assert
		serialized.Should().BeEquivalentTo([
			"[cpu]",
			"cycles=auto",
			"core=dynamic",
			"frameskip=2"
		], options => options.WithStrictOrdering());
	}

	[Test]
	public void Merging_sections_retains_non_overridden_settings() {
		// Arrange
		string text =
			"""
			[cpu]
			cycles=auto
			frameskip=1
			[cpu]
			cycles=max
			""";

		// Act
		var file = DosboxConfFile.FromText(text);
		var allCpu = file.GetSetting("cpu", "frameskip").ToList();
		var allCycles = file.GetSetting("cpu", "cycles").ToList();

		// Assert
		allCpu.Should().HaveCount(1);
		allCpu[0].Should().BeEquivalentTo(new { Value = "1" });

		allCycles.Should().HaveCount(2);
		allCycles.Last().Should().BeEquivalentTo(new { Value = "max" });
	}
}
