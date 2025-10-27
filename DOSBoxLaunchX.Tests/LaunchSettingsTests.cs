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
}
