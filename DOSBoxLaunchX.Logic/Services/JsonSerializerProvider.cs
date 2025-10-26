using Newtonsoft.Json;

namespace DOSBoxLaunchX.Logic.Services;

public class JsonSerializerProvider : IJsonSerializerProvider {
	public JsonSerializerSettings ConfigJsonSerializer(Action<JsonSerializerSettings>? additionalConfig = null, JsonSerializerSettings? baseConfiguration = null) {
		baseConfiguration ??= new JsonSerializerSettings();

		// Configure our preferred JSON formatting defaults
		baseConfiguration.Formatting = Formatting.None;
		baseConfiguration.TypeNameHandling = TypeNameHandling.Auto;
		baseConfiguration.NullValueHandling = NullValueHandling.Ignore;

		additionalConfig?.Invoke(baseConfiguration);

		return baseConfiguration;
	}
}
