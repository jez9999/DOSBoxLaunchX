using Newtonsoft.Json;

namespace DOSBoxLaunchX.Logic.Models;

public class GeneralSettings {
	[JsonIgnore]
	public bool SettingsInitialized { get; set; } = false;

	public string BaseDosboxDir { get; set; } = "";
	public bool CloseOnDosboxExit { get; set; } = true;
	public bool WriteConfToBaseDir { get; set; } = false;
	public bool LaunchImmediately { get; set; } = false;
}
