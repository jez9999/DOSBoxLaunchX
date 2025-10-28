using Newtonsoft.Json;

namespace DOSBoxLaunchX.Logic.Services;

public class InterfaceToConcreteConverter<TInterface, TConcrete> : JsonConverter<TInterface> where TConcrete : TInterface, new() {
	public override void WriteJson(JsonWriter writer, TInterface? value, JsonSerializer serializer) {
		serializer.Serialize(writer, value);
	}

	public override TInterface ReadJson(JsonReader reader, Type objectType, TInterface? existingValue, bool hasExistingValue, JsonSerializer serializer) {
		return serializer.Deserialize<TConcrete>(reader)!;
	}
}
