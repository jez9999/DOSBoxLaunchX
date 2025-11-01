namespace DOSBoxLaunchX.Logic.Models;

public class GeneralSettings {
	public string BaseDosboxDir { get; set; } = "";
	public bool CloseOnDosboxExit { get; set; } = true;
	public bool WriteConfToBaseDir { get; set; } = false;
}
