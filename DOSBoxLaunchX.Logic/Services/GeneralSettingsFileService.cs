using Newtonsoft.Json;
using DOSBoxLaunchX.Logic.Models;

namespace DOSBoxLaunchX.Logic.Services;

public class GeneralSettingsFileService(IJsonSerializerProvider jsonProvider) {
	#region Private vars

	private readonly IJsonSerializerProvider _jsonProvider = jsonProvider;

	#endregion

	/// <summary>
	/// Loads general settings from the given JSON file.
	/// </summary>
	/// <param name="path">The JSON file from which to load general settings.</param>
	/// <returns>The general settings.</returns>
	public GeneralSettings LoadFromFile(string path) {
		if (string.IsNullOrWhiteSpace(path)) {
			throw new ArgumentException("Load path must be set.", nameof(path));
		}
		if (!File.Exists(path)) {
			throw new FileNotFoundException("The specified settings file was not found.", path);
		}

		var serializer = JsonSerializer.Create(_jsonProvider.ConfigJsonSerializer());

		using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
		using var sr = new StreamReader(fs);
		using var reader = new JsonTextReader(sr);

		var settings = serializer.Deserialize<GeneralSettings>(reader)
			?? throw new InvalidDataException($"File '{path}' did not contain valid settings.");

		return settings;
	}

	/// <summary>
	/// Saves the given general settings to a JSON file.
	/// </summary>
	/// <param name="settings">The general settings to save.</param>
	/// <param name="path">The file path to save to.</param>
	public void SaveToFile(GeneralSettings settings, string path) {
		if (string.IsNullOrWhiteSpace(path)) {
			throw new ArgumentException("Save path must be set.", nameof(path));
		}

		var serializer = JsonSerializer.Create(_jsonProvider.ConfigJsonSerializer());

		using var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
		using var sw = new StreamWriter(fs);
		using var writer = new JsonTextWriter(sw);
		serializer.Serialize(writer, settings);
	}
}
