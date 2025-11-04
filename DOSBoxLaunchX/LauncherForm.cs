using System.Diagnostics;
using DOSBoxLaunchX.Logic.Services;
using DOSBoxLaunchX.Logic.DosboxParsing;
using DOSBoxLaunchX.Logic.Helpers;
using DOSBoxLaunchX.Logic.Models;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX;

public partial class LauncherForm : Form {
	#region Private vars

	private readonly AppOptionsWithData _data;
	private readonly GeneralSettings _settings;
	private readonly GeneralSettingsFileService _genSettingsFileService;
	private readonly LaunchSettingsFileService _launchSettingsFileService;

	private string _localAppDataDir = null!;
	private int _widthDiffOutput = 0;
	private int _heightDiffOutput = 0;
	private int _widthDiffShortcut = 0;

	#endregion

	#region Constructors

	public LauncherForm(AppOptionsWithData data, GeneralSettings settings, GeneralSettingsFileService genSettingsFileService, LaunchSettingsFileService launchSettingsFileService) {
		_data = data;
		_settings = settings;
		_genSettingsFileService = genSettingsFileService;
		_launchSettingsFileService = launchSettingsFileService;

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
		var baseDir = _settings.BaseDosboxDir;

		if ((_data.Args.Length < 2 && _data.Args[0] == "-shortcut") || _data.Args.Length < 1) {
			throw new Exception("No DLX shortcut specified!");
		}
		var dlxPath = txtLaunchShortcut.Text = _data.Args[0] == "-shortcut" ? _data.Args[1] : _data.Args[0];

		addTxtboxMsg("Loading DLX shortcut...");
		if (!File.Exists(dlxPath)) {
			addTxtboxMsg($"ERROR: Shortcut file not found: {dlxPath}");
			return false;
		}
		var shortcutSettings = _launchSettingsFileService.LoadFromFile(dlxPath);
		if (!string.IsNullOrWhiteSpace(shortcutSettings.Name)) {
			var heading = $"| {shortcutSettings.Name} |";
			addTxtboxMsg("/" + new string('=', heading.Length - 2) + "\\");
			addTxtboxMsg(heading);
			addTxtboxMsg("\\" + new string('=', heading.Length - 2) + "/");
		}

		addTxtboxMsg("Loading globals...");
		var globalsPath = LocalAppDataHelper.GetGlobalShortcut(_localAppDataDir);
		if (!File.Exists(globalsPath)) {
			addTxtboxMsg($"ERROR: Globals file not found: {globalsPath}");
			return false;
		}
		var globalSettings = _launchSettingsFileService.LoadFromFile(globalsPath);

		addTxtboxMsg("Loading base DOSBox config...");
		string baseConfigPath = Path.Combine(baseDir, _data.DosboxConfBaseFilename);
		if (!File.Exists(baseConfigPath)) {
			addTxtboxMsg($"ERROR: Base DOSBox config not found: {baseConfigPath}");
			return false;
		}
		DosboxConfFile config = DosboxConfFile.FromText(await File.ReadAllTextAsync(baseConfigPath));

		if (globalSettings.KeyboardMappings.Count > 0 || shortcutSettings.KeyboardMappings.Count > 0) {
			addTxtboxMsg("Loading keyboard mappings...");
			var baseMapperPath = Path.Combine(_settings.BaseDosboxDir, _data.DosboxMapperBaseFilename);
			DosboxMapperFile mapFile = null!;
			try {
				mapFile = DosboxMapperFile.FromText(File.ReadAllText(
					baseMapperPath
				));
			}
			catch (Exception) {
				addTxtboxMsg($"ERROR: Keyboard mappings are configured, but couldn't read base mapper file: {baseMapperPath}");
				return false;
			}

			if (
				globalSettings.GetCustomSetting<string>("sdl.mapperfile") != null ||
				shortcutSettings.GetCustomSetting<string>("sdl.mapperfile") != null
			) {
				addTxtboxMsg($"ERROR: Keyboard mappings are configured, but setting sdl.mapperfile is also set in config.  Can't have both at the same time.");
				return false;
			}

			// Setup mappings
			DosboxConfigMergeHelper.MergeMappings(mapFile, globalSettings, addTxtboxMsg);
			DosboxConfigMergeHelper.MergeMappings(mapFile, shortcutSettings, addTxtboxMsg);

			// Write and point to temp mapperfile in config
			string tempMapPath = Path.Combine(
				_localAppDataDir,
				_data.DosboxMapperTemplateFilename.Replace("[shortcutName]", Path.GetFileNameWithoutExtension(dlxPath))
			);
			await File.WriteAllTextAsync(
				tempMapPath,
				mapFile.ToText()
			);
			config.SetSetting("sdl", "mapperfile", tempMapPath);
		}

		addTxtboxMsg("Merging shortcut & global settings into DOSBox config...");
		DosboxConfigMergeHelper.MergeAutoexecMain(config, globalSettings);
		DosboxConfigMergeHelper.MergeAutoexecMain(config, shortcutSettings);
		DosboxConfigMergeHelper.MergeAutoexecPrePost(config, shortcutSettings);
		DosboxConfigMergeHelper.MergeAutoexecPrePost(config, globalSettings, true);
		DosboxConfigMergeHelper.MergeSettings(config, globalSettings, addTxtboxMsg);
		DosboxConfigMergeHelper.MergeSettings(config, shortcutSettings, addTxtboxMsg);

		addTxtboxMsg("Writing temp. DOSBox config...");
		string tempConfigPath = Path.Combine(
			_settings.WriteConfToBaseDir ? _settings.BaseDosboxDir : _localAppDataDir,
			_data.DosboxConfTemplateFilename.Replace("[shortcutName]", Path.GetFileNameWithoutExtension(dlxPath))
		);
		await File.WriteAllTextAsync(
			tempConfigPath,
			config.ToText()
		);
		addTxtboxMsg($"Temporary config written to: {tempConfigPath}");

		addTxtboxMsg("Launching DOSBox...");
		await launchDosboxX(Path.Combine(baseDir, _data.DosboxExeBaseFilename), tempConfigPath, baseDir);

		return true;
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
			LocalAppDataHelper.LoadSettingsIfAvailable(_localAppDataDir, _genSettingsFileService, _settings);

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
			cbCloseOnDosboxExit.Checked = _settings.CloseOnDosboxExit;

			if (string.IsNullOrWhiteSpace(_settings.BaseDosboxDir)) {
				MessageBoxHelper.ShowErrorMessageOk(
					"""
					The base DOSBox directory is not set.  It must be set in order for the launcher to work.

					Please go to "Tools | Options" and set the base DOSBox directory in the main DOSBoxLaunchX UI.  Unable to continue with launch of DOSBox.
					""",
					"Base DOSBox Directory not set"
				);
				Environment.Exit(1);
			}

			var success = await parseConfigAndLaunch();

			txtOutput.Enabled = true;

			if (success && cbCloseOnDosboxExit.Checked) { Close(); }
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk($"FATAL ERROR: {ex.Message}", "Error");
			Environment.Exit(1);
		}
	}
#pragma warning restore IDE1006 // Naming Styles
}
