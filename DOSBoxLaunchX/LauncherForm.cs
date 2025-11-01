using System.Diagnostics;
using DOSBoxLaunchX.Logic.Services;
using DOSBoxLaunchX.Logic.DosboxParsing;
using DOSBoxLaunchX.Logic.Helpers;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX;

public partial class LauncherForm : Form {
	#region Private vars

	private readonly AppOptionsWithData _data;
	private readonly LaunchSettingsFileService _settingsFileService;

	private string _localAppDataDir = null!;
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

	#region Non-event helper methods

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

	private async Task<bool> parseConfigAndLaunch() {
		// TODO: temp assume the base dir of DOSBox-X...
		var baseDir = @"C:\games\_DOSBox-X_";

		if ((_data.Args.Length < 2 && _data.Args[0] == "-shortcut") || _data.Args.Length < 1) {
			throw new Exception("No DLX shortcut specified!");
		}
		var dlxPath = txtLaunchShortcut.Text = _data.Args[0] == "-shortcut" ? _data.Args[1] : _data.Args[0];

		// Read config settings file
		// TODO: impl. later
		// Read globals DLX file
		// TODO: impl. later

		addTxtboxMsg("Loading DLX shortcut...");
		if (!File.Exists(dlxPath)) {
			addTxtboxMsg($"ERROR: Shortcut file not found: {dlxPath}");
			return false;
		}
		var shortcutSettings = _settingsFileService.LoadFromFile(dlxPath);

		addTxtboxMsg("Loading base DOSBox config...");
		string baseConfigPath = Path.Combine(baseDir, _data.DosboxConfBaseFilename);
		if (!File.Exists(baseConfigPath)) {
			addTxtboxMsg($"ERROR: Base DOSBox config not found: {baseConfigPath}");
			return false;
		}
		DosboxConfFile config = DosboxConfFile.FromText(await File.ReadAllTextAsync(baseConfigPath));

		// Merge shortcut DLX into globals DLX
		// TODO: impl. later

		addTxtboxMsg("Merging shortcut settings into DOSBox config...");
		DosboxConfigMergeHelper.Merge(config, shortcutSettings);

		addTxtboxMsg("Writing temp. DOSBox config...");
		string tempConfigPath = Path.Combine(
			_localAppDataDir,
			_data.DosboxConfTemplateFilename.Replace("[shortcutName]", Path.GetFileNameWithoutExtension(dlxPath))
		);
		await File.WriteAllTextAsync(
			tempConfigPath,
			config.ToText()
		);
		addTxtboxMsg($"Temporary config written to: {tempConfigPath}");

		addTxtboxMsg("Launching DOSBox...");
		await launchDosboxX(Path.Combine(baseDir, "dosbox-x.exe"), tempConfigPath, baseDir);

		return true;

		// TODO: the local app data dir will typically contain:
		// - dosbox-x._Tyrian_.conf             // per-launch merged DOSBox-X configs for each shortcut; written each time a .dlx is opened
		// - dosbox-x.[shortcutFilename2].conf
		// - dosbox-x.[shortcutFilename3].conf
		// - global.dlx                         // global shortcut providing default overrides; other shortcuts merge into it, with the non-global shortcut taking precedence for any conflicting settings
		// - settings.json                      // app settings/preferences
	}

	private async Task launchDosboxX(string exePath, string configFilePath, string workingDir) {
		var cmdArgs = $@"-conf ""{configFilePath}""";
		addTxtboxMsg($@"{exePath} {cmdArgs}");

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
	}

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private async void LauncherForm_Load(object sender, EventArgs ea) {
		try {
			_localAppDataDir = LocalAppDataHelper.EnsureLocalAppDataDir(_data.ProgramName);

			// Windows 10+ pushes the window a bit away from the left of the screen (by design) when you
			// set the location to 0,0.  As we can't get it flush with the screen edge, let's just purposely
			// put it a little bit in from the edge.
			Location = new(5, 10);

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

			var success = await parseConfigAndLaunch();

			txtOutput.Enabled = true;

			if (success && cbCloseOnDosboxExit.Checked) { Close(); }
			// TODO: cbCloseOnDosboxExit default checked state should be a config setting
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk($"FATAL ERROR: {ex.Message}", "Error");
			Environment.Exit(1);
		}
	}
#pragma warning restore IDE1006 // Naming Styles
}
