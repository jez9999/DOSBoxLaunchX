using NUnit.Framework;
using AwesomeAssertions;
using Newtonsoft.Json;
using DOSBoxLaunchX.Logic.Models;
using DOSBoxLaunchX.Logic.Services;

namespace DOSBoxLaunchX.Tests;

[TestFixture]
public class LaunchSettingsTests {
	private JsonSerializerSettings _jsonSettings = null!;

	[SetUp]
	public void Setup() {
		IJsonSerializerProvider jsonProvider = new JsonSerializerProvider(); // Use interface explicitly
		_jsonSettings = jsonProvider.ConfigJsonSerializer();
	}

	[Test]
	public void Serialize_minimal_settings() {
		// Arrange
		var settings = new LaunchSettings();

		// Act
		string json = JsonConvert.SerializeObject(settings, _jsonSettings);

		// Assert
		json.Should().Be(@"{""Settings"":{}}");
	}

	[Test]
	public void Serialize_basedir_executable() {
		// Arrange
		var settings = new LaunchSettings {
			BaseDir = @"C:\Games",
			Executable = "game.exe"
		};

		// Act
		string json = JsonConvert.SerializeObject(settings, _jsonSettings);

		// Assert
		json.Should().Contain(@"""BaseDir"":""C:\\Games""");
		json.Should().Contain(@"""Executable"":""game.exe""");
	}

	[Test]
	public void Serialize_cpu_cycles() {
		// Arrange
		var settings = new LaunchSettings();
		settings.CPU.Cycles = "3123";

		// Act
		string json = JsonConvert.SerializeObject(settings, _jsonSettings);

		// Assert
		json.Should().Contain(@"""Settings"":{""cpu.cycles"":""3123""}");
	}

	[Test]
	public void Serialize_full_with_one_setting() {
		// Arrange
		var settings = new LaunchSettings {
			Name = "Shortcut Name",
			Description = "Some description",
			BaseDir = @"C:\Games",
			LimitBaseDirToOneGiB = true,
			Executable = "game.exe"
		};
		settings.CPU.Cycles = "3123";

		// Act
		string json = JsonConvert.SerializeObject(settings, _jsonSettings);

		// Assert
		json.Should().Contain(@"""Name"":""Shortcut Name""");
		json.Should().Contain(@"""Description"":""Some description""");
		json.Should().Contain(@"""BaseDir"":""C:\\Games""");
		json.Should().Contain(@"""LimitBaseDirToOneGiB"":true");
		json.Should().Contain(@"""Executable"":""game.exe""");
		json.Should().Contain(@"""Settings"":{""cpu.cycles"":""3123""}");
	}

	[Test]
	public void Deserialize_empty_json() {
		// Arrange
		var json = @"{}";

		// Act
		var settings = JsonConvert.DeserializeObject<LaunchSettings>(json, _jsonSettings);

		// Assert
		settings.Should().BeEquivalentTo(new LaunchSettings());
	}


	[Test]
	public void Deserialize_minimal_settings() {
		// Arrange
		var json = @"{""Settings"":{}}";

		// Act
		var settings = JsonConvert.DeserializeObject<LaunchSettings>(json, _jsonSettings);

		// Assert
		settings.Should().BeEquivalentTo(new LaunchSettings());
	}

	[Test]
	public void Deserialize_basedir_executable() {
		// Arrange
		var json = @"{""BaseDir"":""C:\\Games"",""Executable"":""game.exe""}";

		// Act
		var settings = JsonConvert.DeserializeObject<LaunchSettings>(json, _jsonSettings);

		// Assert
		settings.Should().BeEquivalentTo(new LaunchSettings {
			BaseDir = @"C:\Games",
			Executable = "game.exe"
		});
	}

	[Test]
	public void Deserialize_cpu_cycles() {
		// Arrange
		var json = @"{""Settings"":{""cpu.cycles"":""3123""}}";

		// Act
		var settings = JsonConvert.DeserializeObject<LaunchSettings>(json, _jsonSettings);

		// Assert
		settings.Should().BeEquivalentTo(new LaunchSettings {
			CPU = new LaunchSettings.CPUSettings { Cycles = "3123" }
		});
	}

	[Test]
	public void Deserialize_full_with_one_setting() {
		// Arrange
		var json = """
			{
				"Name":"Shortcut Name",
				"Description":"Some description",
				"BaseDir":"C:\\Games",
				"LimitBaseDirToOneGiB":true,
				"Executable":"game.exe",
				"Settings":{"cpu.cycles":"3123"}
			}
			""";

		// Act
		var settings = JsonConvert.DeserializeObject<LaunchSettings>(json, _jsonSettings);

		// Assert
		settings.Should().BeEquivalentTo(new LaunchSettings {
			Name = "Shortcut Name",
			Description = "Some description",
			BaseDir = @"C:\Games",
			LimitBaseDirToOneGiB = true,
			Executable = "game.exe",
			CPU = new LaunchSettings.CPUSettings { Cycles = "3123" }
		});
	}

	[Test]
	public void Deserialize_custom_setting_present_and_correct() {
		// Arrange
		var json = @"{""Settings"":{""my.setting"":42}}";

		// Act
		var settings = JsonConvert.DeserializeObject<LaunchSettings>(json, _jsonSettings)!;

		// Assert
		settings.GetCustomSetting<long>("my.setting").Should().Be(42);
	}

	[Test]
	public void Set_custom_setting_stores_correctly() {
		// Arrange
		var settings = new LaunchSettings();

		// Act
		settings.SetCustomSetting("difficulty", "hard");

		// Assert
		settings.GetCustomSetting<string>("difficulty").Should().Be("hard");
	}

	[Test]
	public void Delete_custom_setting_removes_correctly() {
		// Arrange
		var settings = new LaunchSettings();
		settings.SetCustomSetting("temp", "abc");

		// Act
		settings.DeleteCustomSetting("temp");

		// Assert
		settings.GetCustomSetting<string>("temp").Should().BeNull();
	}

	[Test]
	public void Custom_setting_serialized_correctly() {
		// Arrange
		var settings = new LaunchSettings();
		settings.SetCustomSetting("map.size", 128);

		// Act
		string json = JsonConvert.SerializeObject(settings, _jsonSettings);

		// Assert
		json.Should().Contain(@"""Settings"":{""map.size"":128}");
	}

	[Test]
	public void Roundtrip_strong_and_custom_settings_preserve_ok() {
		// Arrange
		var originalJson = @"{""Settings"":{""cpu.cycles"":""3123"",""speed"":""fast"",""volume"":75}}";

		// Act
		var settings = JsonConvert.DeserializeObject<LaunchSettings>(originalJson, _jsonSettings)!;
		string reserializedJson = JsonConvert.SerializeObject(settings, _jsonSettings);

		// Assert
		settings.CPU.Cycles.Should().Be("3123");
		settings.GetCustomSetting<string>("speed").Should().Be("fast");
		settings.GetCustomSetting<long>("volume").Should().Be(75);
		reserializedJson.Should().Be(originalJson);
	}

	[Test]
	public void Custom_and_strongly_typed_setting_conflict_resolves_ok() {
		// TODO: test is failing.  we need typed settings to override custom ones of the same name i reckon...

		// Arrange
		var json = @"{""Settings"":{""cpu.cycles"":""3123""}}";
		var settings = JsonConvert.DeserializeObject<LaunchSettings>(json, _jsonSettings)!;

		// Act
		settings.SetCustomSetting("cpu.cycles", "9999"); // This should *not* override CPU.Cycles
		string jsonOut = JsonConvert.SerializeObject(settings, _jsonSettings);

		// Assert
		settings.CPU.Cycles.Should().Be("3123");
		settings.GetCustomSetting<string>("cpu.cycles").Should().Be("9999");
		jsonOut.Should().Contain(@"""cpu.cycles"":""3123""");
		jsonOut.Should().NotContain(@"""cpu.cycles"":""9999""");
	}

	[Test]
	public void Deserialize_invalid_cpu_cycles_type_throws() {
		// Arrange
		var json = @"{""Settings"":{""cpu.cycles"":1234}}"; // Expecting string

		// Act & Assert
		json
			.Invoking(x => JsonConvert.DeserializeObject<LaunchSettings>(x, _jsonSettings))
			.Should().Throw<Exception>().WithMessage("Error setting value to 'Settings'*");
	}

	[Test]
	public void Set_custom_setting_with_null_throws() {
		// Arrange
		var settings = new LaunchSettings();

		// Act & Assert
		"nulltest"
			.Invoking(x => settings.SetCustomSetting<string>(x, null!))
			.Should().Throw<ArgumentNullException>();
	}

	[Test]
	public void Get_custom_setting_with_wrong_type_throws() {
		// Arrange
		var settings = new LaunchSettings();
		settings.SetCustomSetting("difficulty", "hard");

		// Act
		Action act = () => settings.GetCustomSetting<int>("difficulty");

		// Assert
		act
			.Should().Throw<InvalidDataException>()
			.WithMessage("*Expected a value of type Int32*");
	}
}
