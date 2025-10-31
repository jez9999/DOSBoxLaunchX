namespace DOSBoxLaunchX.Models;

public class AppOptionsWithData {
	// If this app needs options at some point, we can put them here...
	//public required AppOptions Options;

	public required bool IsDebugBuild;
	public required string EnvironmentName;
	public required string CurrentWorkingDirectory;
	public required string ProgramName;
	public required string AppExePath;
	public required string[] Args;

	public string ShortcutFiletypeExtension => "dlx";
	public string ShortcutFiletypeProgId => "DOSBoxLaunchX.Shortcut";
	public string ShortcutFiletypeDescription => "DOSBoxLaunchX Shortcut File";

	public string DosboxConfBaseFilename => "dosbox-x.conf";
	public string DosboxConfTemplateFilename => "dosbox-x.[shortcutName].conf";
}
