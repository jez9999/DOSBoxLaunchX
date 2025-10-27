using Newtonsoft.Json;
using DOSBoxLaunchX.Logic.Models;

namespace DOSBoxLaunchX.Logic.Services;

public class LaunchSettingsFileService(IJsonSerializerProvider jsonProvider) {
	#region Private vars

	private readonly IJsonSerializerProvider _jsonProvider = jsonProvider;

	#endregion

	/// <summary>
	/// Saves the given launch settings to a JSON file.
	/// </summary>
	/// <param name="settings">The launch settings to save.</param>
	/// <param name="path">The file path to save to.</param>
	public void SaveToFile(LaunchSettings settings, string path) {
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
