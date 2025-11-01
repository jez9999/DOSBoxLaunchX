using Newtonsoft.Json;

namespace DOSBoxLaunchX.Logic.Services;

public interface IJsonSerializerProvider {
	/// <summary>
	/// Returns a preferred config for JSON serialization, optionally based on an existing base config and
	/// optionally with additional configuration to be applied after the preferred config defaults.
	/// </summary>
	/// <param name="additionalConfig">If specified, the additional configuration.</param>
	/// <param name="baseConfiguration">If specified, the base config.</param>
	/// <returns>The config for JSON serialization.</returns>
	JsonSerializerSettings ConfigJsonSerializer(
		Action<JsonSerializerSettings>? additionalConfig = null,
		JsonSerializerSettings? baseConfiguration = null
	);
}
