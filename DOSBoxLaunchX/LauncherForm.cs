using System.Diagnostics;
using DOSBoxLaunchX.Logic.Services;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX;

public partial class LauncherForm : Form {
	#region Private vars

	private readonly AppOptionsWithData _data;
	private readonly LaunchSettingsFileService _settingsFileService;

	private int _widthDiffOutput = 0;
	private int _heightDiffOutput = 0;
	private int _widthDiffShortcut = 0;

	#endregion

	#region Constructors

	public LauncherForm(AppOptionsWithData data, LaunchSettingsFileService settingsFileService) {
		_data = data;
		_settingsFileService = settingsFileService;

		InitializeComponent();
	}

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private async void LauncherForm_Load(object sender, EventArgs ea) {
		try {
			if (_data.IsDebugBuild) {
				Text += " (DEBUG BUILD)";
			}
			Text += " - Launching DOSBox-X...";

			// Record sizes on form that we'll need later
			_widthDiffOutput = Width - txtOutput.Width;
			_heightDiffOutput = Height - txtOutput.Height;
			_widthDiffShortcut = Width - txtLaunchShortcut.Width;
			SizeChanged += new EventHandler(positionFormControls);

			txtOutput.BackColor = SystemColors.Window;

			_data.LocalAppDataDir = LocalAppDataHelper.EnsureLocalAppDataDir(_data.ProgramName);

			// Read global config settings
			// TODO: impl. read global config settings

			// For now we'll assume the base dir of DOSBox-X...
			var baseDir = @"C:\games\_DOSBox-X_";
			var configFile = "dosbox-x.custom.conf";
			var exePath = Path.Combine(baseDir, "dosbox-x.exe");
			var configPath = Path.Combine(_data.LocalAppDataDir, configFile);

			// Read given shortcut file from args
			// look at: _data.Args

			// Generate config from given shortcut merged with global config settings

			// TODO: the local app data dir will typically contain:
			// - dosbox-x._Tyrian_.conf             // per-launch merged DOSBox-X configs for each shortcut; written each time a .dlx is opened
			// - dosbox-x.[shortcutFilename2].conf
			// - dosbox-x.[shortcutFilename3].conf
			// - global.dlx                         // global shortcut providing default overrides; other shortcuts merge into it, with the non-global shortcut taking precedence for any conflicting settings
			// - settings.json                      // app settings/preferences

			addTxtboxMsg($"Generating config file: {configFile}");

			await launchDosboxX(exePath, configPath, baseDir);
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk($"FATAL ERROR: {ex.Message}", "Error");
			Environment.Exit(1);
		}
	}
#pragma warning restore IDE1006 // Naming Styles

	private void positionFormControls(object? sender, EventArgs ea) {
		txtOutput.Width = Width - _widthDiffOutput;
		txtOutput.Height = Height - _heightDiffOutput;
		txtLaunchShortcut.Width = Width - _widthDiffShortcut;
	}

	private void addTxtboxMsg(string msg) {
		txtOutput.SelectionColor = Color.Black;
		txtOutput.SelectedText += msg + Environment.NewLine;
		txtOutput.ScrollToCaret();
		txtOutput.Update();
	}

	private async Task launchDosboxX(string exePath, string configFilePath, string workingDir) {
		var cmdArgs = $@"-conf ""{configFilePath}""";
		addTxtboxMsg($@"Launching: {exePath} {cmdArgs}");

		var psi = new ProcessStartInfo {
			FileName = exePath,
			Arguments = cmdArgs,
			WorkingDirectory = workingDir,
			UseShellExecute = true // Run as normal GUI app
		};

		using var process = Process.Start(psi)
			?? throw new InvalidOperationException("Failed to start DOSBox-X process!");
		await process.WaitForExitAsync();

		addTxtboxMsg($"Exited.");
		txtOutput.Enabled = true;
	}
}
