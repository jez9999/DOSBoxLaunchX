using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;
using DOSBoxLaunchX.Logic.Models;
using DOSBoxLaunchX.Logic.Services;
using DOSBoxLaunchX.Logic.Helpers;
using DOSBoxLaunchX.Logic.DosboxParsing;
using DOSBoxLaunchX.Factories;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;
using DOSBoxLaunchX.Services;

namespace DOSBoxLaunchX;

public partial class MainForm : Form {
	#region Private vars

	private readonly AppOptionsWithData _data;
	private readonly GeneralSettings _settings;
	private readonly FormFactory _formFact;
	private readonly FormsValidatorHelper _formsValidator;
	private readonly ControlInfoTagParser _ctrlTagParser;
	private readonly GeneralSettingsFileService _genSettingsFileService;
	private readonly LaunchSettingsFileService _launchSettingsFileService;
	private readonly Dictionary<Control, ControlInfo> _controlInfo = [];
	private readonly HashSet<string> _reservedSectionKeys;
	private readonly string? _providedShortcutPath;

	private readonly Font _lblFontNa;
	private string _localAppDataDir = null!;
	private string? _currentShortcutFilePath = null;
	private bool _shortcutDirty = false;

	#endregion

	#region Constructors

	public MainForm(AppOptionsWithData data, GeneralSettings settings, FormFactory formFact, FormsValidatorHelper formsValidator, ControlInfoTagParser ctrlTagParser, GeneralSettingsFileService genSettingsFileService, LaunchSettingsFileService launchSettingsFileService, MainFormDynamicParams dynamicParams) {
		_data = data;
		_settings = settings;
		_formFact = formFact;
		_formsValidator = formsValidator;
		_ctrlTagParser = ctrlTagParser;
		_genSettingsFileService = genSettingsFileService;
		_launchSettingsFileService = launchSettingsFileService;
		_providedShortcutPath = dynamicParams.ShortcutFilePath;

		InitializeComponent();

		_lblFontNa = new Font("Courier New", 120, FontStyle.Bold);
		_reservedSectionKeys = getReservedSectionKeys(new LaunchSettings());
	}

	#endregion

	#region Non-event helper methods

	private HashSet<string> getReservedSectionKeys(LaunchSettings sett) {
		var map = new Dictionary<string, (PropertyInfo, object)>();
		LaunchSettingsMetaHelper.AddGroupedPropertiesToMap(map, sett);
		return [.. map.Keys];
	}

	private string? sectionKeyReserved(string section, string key) {
		string sectionKey = string.IsNullOrEmpty(key) ? section : $"{section}.{key}";
		return _reservedSectionKeys.Contains(sectionKey) ? sectionKey : null;
	}

	private int getDefaultFreeSpaceLimit() => 1024;

	private void resetControlDefaults() {
		// Reset UI with defaults; default settings for new shortcuts are hardcoded here
		generateUiFromShortcutLaunchSettings(new LaunchSettings {
			BaseDir = "",
			LimitBaseDirFreeSpace = getDefaultFreeSpaceLimit(),
			Executable = "",
			ExitAfterTerminate = true,
		});
	}

	private void selectFirstControl() {
		tabsContainer.SelectedTab = tabGeneral;
		txtName.Focus();
	}

	private void discoverValueControls(Control parent) {
		foreach (Control ctrl in parent.Controls) {
			// Recurse first to process children
			if (ctrl.HasChildren) {
				discoverValueControls(ctrl);
			}

			// Only process value controls
			if (!(ctrl is TextBox || ctrl is ComboBox)) {
				continue;
			}

			string? tagStr = ctrl.Tag as string;
			if (string.IsNullOrWhiteSpace(tagStr)) {
				MessageBoxHelper.ShowErrorMessageOk(
					$"Control '{ctrl.Name}' is missing a Tag and should have one.",
					"Missing Tag"
				);
				continue;
			}

			var info = _ctrlTagParser.ParseTag(tagStr, ctrl);
			if (info == null || info.Ignore) { continue; }

			// Store in dictionary keyed by the value control
			_controlInfo[ctrl] = info;
		}
	}

	private void initAndProcessControls(Control parent) {
		// Recursively discover value controls and parse tags
		discoverValueControls(parent);

		// Now attach event handlers and initialize associated controls
		foreach (var kvp in _controlInfo) {
			var ctrl = kvp.Key;
			var info = kvp.Value;

			// Attach handlers for the value control and associated
			attachControlHandlers(ctrl, info);

			// Initialize enabled/disabled state
			updateAssociatedControlsState(ctrl, info);
		}
	}

	private void attachControlHandlers(Control ctrl) {
		attachControlHandlers(ctrl, new ControlInfo());
	}

	private void attachControlHandlers(Control ctrl, ControlInfo info) {
		// Attach handlers for the value control itself
		ctrl.TextChanged += controlValueChangedEvent;

		ctrl.Validating += (sender, ea) => {
			if (!validateTextCtrlContent(ctrl.Text, info)) { ea.Cancel = true; }
		};

		ctrl.Validated += (sender, ea) => {
			if (info.AllowNewlines) {
				var newlineStyle = Environment.NewLine switch {
					"\n" => NewlinesHelper.NewlineStyle.Unix,
					"\r\n" => NewlinesHelper.NewlineStyle.Windows,
					"\r" => NewlinesHelper.NewlineStyle.OldMac,
					_ => throw new InvalidOperationException($"Unrecognized environment newline format: {BitConverter.ToString(Encoding.ASCII.GetBytes(Environment.NewLine))}")
				};
				var normalized = NewlinesHelper.NormalizeNewlines(ctrl.Text, newlineStyle);
				if (ctrl.Text != normalized) {
					ctrl.Text = normalized;
				}
			}
		};

		// Attach the checkbox CheckedChanged once, if there is a checkbox
		if (info.CheckboxControl != null) {
			info.CheckboxControl.CheckedChanged += (sender, ea) => {
				// Enable/disable associated controls if any
				updateAssociatedControlsState(ctrl, info);

				// Always mark as dirty when checkbox changes
				controlValueChangedEvent(sender, ea);
			};
		}
	}

	private void updateAssociatedControlsState(Control ctrl, ControlInfo info) {
		bool enabled = info.CheckboxControl?.Checked ?? true;

		// Update the value control itself
		ctrl.Enabled = enabled;

		// Update associated controls (labels, etc.)
		foreach (var assoc in info.AssociatedControls) {
			switch (assoc) {
				case Label lbl:
					lbl.ForeColor = enabled ? SystemColors.ControlText : ControlPaint.LightLight(SystemColors.ControlText);
					break;

				default:
					assoc.Enabled = enabled;
					break;
			}
		}
	}

	private void controlValueChangedEvent(object? sender, EventArgs ea) {
		controlValueChanged();
	}

	private void controlValueChanged() {
		if (!_shortcutDirty) {
			_shortcutDirty = true;
			updateUiDirtyState();
		}
	}

	private bool validateTextCtrlContent(string text, ControlInfo info) {
		if (!info.AllowNewlines && (text.Contains('\r') || text.Contains('\n'))) {
			MessageBoxHelper.ShowErrorMessageOk("Control text contains invalid newline characters.", "Control text invalid");
			return false;
		}
		return true;
	}

	private void attachPrePostAutoexecHandlers() {
		cbBaseDirSet.CheckedChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
		txtBaseDir.TextChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
		cbLimitBaseDirFreeSpaceSet.CheckedChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
		comboLimitBaseDirFreeSpace.SelectedIndexChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
		cbExecutableSet.CheckedChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
		txtExecutable.TextChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
		cbExitAfterTerminateSet.CheckedChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
		comboExitAfterTerminate.SelectedIndexChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
	}

	private void updateUiShortcutFilePath() {
		if (LocalAppDataHelper.IsGlobalShortcut(_localAppDataDir, _currentShortcutFilePath)) {
			txtShortcutFilePath.Text = "[Editing globals]";
			btnTestLaunch.Enabled = false;
		}
		else {
			txtShortcutFilePath.Text = _currentShortcutFilePath ?? "[New shortcut]";
			btnTestLaunch.Enabled = _currentShortcutFilePath != null;
		}
	}

	private void updateUiDirtyState() {
		if (_shortcutDirty) {
			if (Text[0] != '*') {
				Text = $"*{Text}";
			}
		}
		else {
			if (Text[0] == '*') {
				Text = Text[1..];
			}
		}

		// Enable/disable menu items based on dirty state
		mnuSave.Enabled = _shortcutDirty;
	}

	private bool promptSaveIfDirty() {
		// If this method returns true, action can continue; otherwise, it should abort.
		if (!_shortcutDirty) {
			return true;
		}

		var promptMsg =
			LocalAppDataHelper.IsGlobalShortcut(_localAppDataDir, _currentShortcutFilePath)
			? "You have unsaved changes to the global settings. Do you want to save them?"
			: "You have unsaved changes to the current shortcut. Do you want to save them?";
		var result = MessageBoxHelper.ShowQuestionMessage(
			promptMsg,
			"Save changes?",
			MessageBoxButtons.YesNoCancel,
			MessageBoxDefaultButton.Button1
		);

		switch (result) {
			case DialogResult.Yes:
				if (_shortcutDirty && !doSave()) { return false; }
				return true;

			case DialogResult.No:
				return true;

			case DialogResult.Cancel:
			default:
				return false;
		}
	}

	private bool doBrowseExecutable() {
		// We purposely don't set the .InitialDirectory property.  When left unset,
		// the dialog helpfully remembers the last directory the user was in, which
		// is desired behaviour.
		openFileDialog.Title = "Browse To Executable";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "DOS Executables (*.exe;*.com;*.bat)|*.exe;*.com;*.bat|All files (*.*)|*.*";
		openFileDialog.FilterIndex = 1;

		if (openFileDialog.ShowDialog() != DialogResult.OK) { return false; }

		// Browsed successfully
		var path = openFileDialog.FileName;
		cbExecutableSet.Checked = true;
		txtExecutable.Text = Path.GetFileName(path) ?? "";
		cbBaseDirSet.Checked = true;
		txtBaseDir.Text = Path.GetDirectoryName(path) ?? "";

		return true;
	}

	private bool doBrowseDosboxBaseDir() {
		if (folderBrowserDialog.ShowDialog() != DialogResult.OK) { return false; }
		txtUseDosboxBaseDir.Text = folderBrowserDialog.SelectedPath;

		return true;
	}

	private bool doBrowseLogOutputFile() {
		// We purposely don't set the .InitialDirectory property.  When left unset,
		// the dialog helpfully remembers the last directory the user was in, which
		// is desired behaviour.
		openFileDialog.Title = "Browse To Log Output File";
		openFileDialog.FileName = "";
		openFileDialog.Filter = "Logfiles (*.log;*.txt)|*.log;*.txt|All files (*.*)|*.*";
		openFileDialog.FilterIndex = 1;

		if (openFileDialog.ShowDialog() != DialogResult.OK) { return false; }

		// Browsed successfully
		cbLogOutputFileSet.Checked = true;
		txtLogOutputFile.Text = openFileDialog.FileName;

		return true;
	}

	private bool doBrowseMt32Romdir() {
		if (folderBrowserDialog.ShowDialog() != DialogResult.OK) { return false; }
		txtMt32RomDir.Text = folderBrowserDialog.SelectedPath;

		return true;
	}

	private bool doBrowsePrintDocDir() {
		if (folderBrowserDialog.ShowDialog() != DialogResult.OK) { return false; }
		txtPrintDocDir.Text = folderBrowserDialog.SelectedPath;

		return true;
	}

	private void initNewShortcut() {
		// Reset UI first...
		_currentShortcutFilePath = null;
		resetControlDefaults();
		selectFirstControl();

		// ... then underlying model.
		_shortcutDirty = false;
		updateUiShortcutFilePath();
		updateUiDirtyState();
	}

	private bool doOpen() {
		return doOpen(null);
	}

	private bool doOpen(string? path = null) {
		if (!ValidateChildren()) { return false; }
		if (!promptSaveIfDirty()) { return false; }

		// If no path is supplied, show the Open dialog
		if (string.IsNullOrWhiteSpace(path)) {
			// We purposely don't set the .InitialDirectory property.  When left unset,
			// the dialog helpfully remembers the last directory the user was in, which
			// is desired behaviour.
			openFileDialog.Title = "Open Shortcut";
			openFileDialog.FileName = "";
			openFileDialog.Filter = "DOSBoxLaunchX Shortcut (*.dlx)|*.dlx";
			openFileDialog.FilterIndex = 1;

			if (openFileDialog.ShowDialog() != DialogResult.OK) { return false; }

			path = openFileDialog.FileName;
		}

		try {
			var sett = _launchSettingsFileService.LoadFromFile(path);
			_currentShortcutFilePath = path;
			generateUiFromShortcutLaunchSettings(sett);
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk(
				$"""
				Failed to open launch shortcut:
				{ex.Message}
				""",
				"Error opening launch shortcut"
			);
			return false;
		}

		// Loaded successfully
		_shortcutDirty = false;
		updateUiShortcutFilePath();
		updateUiDirtyState();

		return true;
	}

	private bool doSave() {
		return doSaveAs(_currentShortcutFilePath);
	}

	private bool doSaveAs(string? path = null) {
		if (!ValidateChildren()) { return false; }

		// If no path is supplied, show the Save As dialog
		if (string.IsNullOrWhiteSpace(path)) {
			// We purposely don't set the .InitialDirectory property.  When left unset,
			// the dialog helpfully remembers the last directory the user was in, which
			// is desired behaviour.
			saveFileDialog.Title = "Save Shortcut As";
			saveFileDialog.Filter = "DOSBoxLaunchX Shortcut (*.dlx)|*.dlx";
			saveFileDialog.FilterIndex = 1;
			saveFileDialog.DefaultExt = "dlx";
			saveFileDialog.AddExtension = true;

			// Pre-fill filename if one exists
			try {
				if (!string.IsNullOrEmpty(_currentShortcutFilePath)) {
					saveFileDialog.FileName = Path.GetFileName(_currentShortcutFilePath);
				}
				else if (!string.IsNullOrWhiteSpace(txtName.Text)) {
					saveFileDialog.FileName = $"_{txtName.Text}_";
				}
				else {
					saveFileDialog.FileName = string.Empty;
				}
			}
			catch {
				saveFileDialog.FileName = string.Empty;
			}

			if (saveFileDialog.ShowDialog() != DialogResult.OK) { return false; }

			path = saveFileDialog.FileName;
		}

		try {
			_launchSettingsFileService.SaveToFile(generateShortcutLaunchSettingsFromUi(), path);
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk(
				$"""
				Failed to save launch shortcut:
				{ex.Message}
				""",
				"Error saving launch shortcut"
			);
			return false;
		}

		// Saved successfully
		_currentShortcutFilePath = path;
		_shortcutDirty = false;
		updateUiShortcutFilePath();
		updateUiDirtyState();

		return true;
	}

	private void doTestLaunch() {
		// Get path to this executable
		var module = Process.GetCurrentProcess().MainModule
			?? throw new InvalidOperationException("Couldn't find main process module for this executable.");
		string exePath = module.FileName;

		if (string.IsNullOrWhiteSpace(_currentShortcutFilePath)) {
			throw new InvalidOperationException("Current shortcut path is empty.");
		}

		var psi = new ProcessStartInfo {
			FileName = exePath,
			Arguments = $@"-launchnow ""{_currentShortcutFilePath}""",
			UseShellExecute = false
		};

		using var proc = Process.Start(psi)
			?? throw new InvalidOperationException("Failed to start launcher process!");
	}

	private Dictionary<(string Section, string? Key), List<string>> getCustomSettingsFromUi() {
		// Value is List<string> because a setting with a certain section/key can be duped
		var dict = new Dictionary<(string Section, string? Key), List<string>>();

		foreach (var row in flowPnlCustom.Controls.OfType<FlowLayoutPanel>()) {
			var txtSection = row.Controls.OfType<TextBox>().FirstOrDefault(c => c.Name == "txtSection");
			var txtKey = row.Controls.OfType<TextBox>().FirstOrDefault(c => c.Name == "txtKey");
			var txtValue = row.Controls.OfType<TextBox>().FirstOrDefault(c => c.Name == "txtValue");

			if (txtSection == null || txtKey == null || txtValue == null) { continue; }

			string section = txtSection.Text.ToLowerInvariant().Trim();
			string key = txtKey.Text.ToLowerInvariant().Trim();
			string value = txtValue.Text.ToLowerInvariant().Trim();

			if (string.IsNullOrEmpty(section)) { continue; } // Skip entries with no section (mandatory)

			string? keyOrNull = string.IsNullOrWhiteSpace(key) ? null : key;
			var dictKey = (Section: section, Key: keyOrNull);
			if (!dict.TryGetValue(dictKey, out var list)) {
				list = [];
				dict[dictKey] = list;
			}
			list.Add(value);
		}

		return dict;
	}

	private LaunchSettings generateShortcutLaunchSettingsFromUi() {
		// General settings
		var name = UiHelper.GetTextValue(txtName);
		var description = UiHelper.GetTextValue(txtDescription);
		var sett = new LaunchSettings {
			Name = name == "" ? null : name,
			Description = description == "" ? null : description,
		};

		if (cbBaseDirSet.Checked) { sett.BaseDir = UiHelper.GetTextValue(txtBaseDir); }
		if (cbLimitBaseDirFreeSpaceSet.Checked) { sett.LimitBaseDirFreeSpace = UiHelper.GetLimitFreeSpaceValue(comboLimitBaseDirFreeSpace); }
		if (cbExecutableSet.Checked) { sett.Executable = UiHelper.GetTextValue(txtExecutable); }
		if (cbExitAfterTerminateSet.Checked) { sett.ExitAfterTerminate = UiHelper.GetComboValue<bool>(comboExitAfterTerminate); }
		if (cbUseDosboxBaseDirSet.Checked) { sett.UseDosboxBaseDir = UiHelper.GetTextValue(txtUseDosboxBaseDir); }
		if (cbOpenLoggingConsoleSet.Checked) { sett.ConsoleOnLaunch = UiHelper.GetComboValue<bool>(comboOpenLoggingConsole); }
		if (cbDontApplyKbMappingsSet.Checked) { sett.DontApplyKbMappings = UiHelper.GetComboValue<bool>(comboDontApplyKbMappings); }

		// Grouped settings
		SettingsUiBinder.SetGroupedSettingsFromUi(sett, _controlInfo);

		// Autoexec script
		saveAutoexec(sett, txtAutoexec);

		// Other custom settings
		saveCustomSettings(sett);

		// Keyboard mappings
		sett.KeyboardMappings = collectCurrentUiMappings();

		return sett;

		static void saveAutoexec(LaunchSettings sett, TextBox ctrl) {
			// Split main textbox lines
			var lines = ctrl.Text.Split(Environment.NewLine).ToList();

			// Trim trailing blank lines, keep leading
			for (int i = lines.Count - 1; i >= 0; i--) {
				if (string.IsNullOrWhiteSpace(lines[i])) { lines.RemoveAt(i); }
				else { break; }
			}

			// Write back as autoexec.0, autoexec.1, ...
			for (int i = 0; i < lines.Count; i++) { sett.SetCustomSetting($"autoexec.{i}", lines[i]); }
		}

		void saveCustomSettings(LaunchSettings launchSett) {
			var uiSetts = getCustomSettingsFromUi();

			foreach (var uiSett in uiSetts) {
				(var section, var key) = uiSett.Key;
				var value = uiSett.Value.First();

				if (section.Equals("autoexec", StringComparison.OrdinalIgnoreCase)) { continue; }
				// ^ reserved name

				string fullKey = string.IsNullOrEmpty(key)
					? section
					: $"{section}.{key}";

				launchSett.SetCustomSetting(fullKey, value);
			}
		}
	}

	private bool generateUiFromShortcutLaunchSettings(LaunchSettings sett, bool justRefreshMappingsFromUi = false) {
		bool success = true;

		var editingGlobals = LocalAppDataHelper.IsGlobalShortcut(_localAppDataDir, _currentShortcutFilePath);
		var settFlatCustom = sett.GetCustomSettings();

		// Keyboard mappings
		DosboxMapperFile? mapFile = null;
		try {
			mapFile = DosboxMapperFile.FromText(File.ReadAllText(
				Path.Combine(_settings.BaseDosboxDir, _data.DosboxMapperBaseFilename)
			));
		}
		catch (Exception) {
			success = false;
		}
		var keyboardMappings = sett.KeyboardMappings;
		if (justRefreshMappingsFromUi) { keyboardMappings = collectCurrentUiMappings(); }
		DataGridHelper.LoadKeyboardMappingsToGrid(mapFile?.GetAllMappings(), keyboardMappings, dataGridMappings);

		if (mapFile == null) {
			disableMappingSettings();
		}
		else {
			enableMappingSettings();
		}
		if (justRefreshMappingsFromUi) { return success; }

		if (editingGlobals) { resetGlobalNaSettings(sett); }

		// General settings
		UiHelper.SetTextFromValue(txtName, sett.Name);
		UiHelper.SetTextFromValue(txtDescription, sett.Description);

		UiHelper.SetTextFromValue(txtBaseDir, sett.BaseDir);
		UiHelper.SetCheckboxFromValue(cbBaseDirSet, sett.BaseDir != null);

		UiHelper.SetLimitFreeSpaceFromValue(comboLimitBaseDirFreeSpace, sett.LimitBaseDirFreeSpace, getDefaultFreeSpaceLimit());
		UiHelper.SetCheckboxFromValue(cbLimitBaseDirFreeSpaceSet, sett.LimitBaseDirFreeSpace != null);

		UiHelper.SetTextFromValue(txtExecutable, sett.Executable);
		UiHelper.SetCheckboxFromValue(cbExecutableSet, sett.Executable != null);

		UiHelper.SetComboFromValue(comboExitAfterTerminate, sett.ExitAfterTerminate);
		UiHelper.SetCheckboxFromValue(cbExitAfterTerminateSet, sett.ExitAfterTerminate != null);

		UiHelper.SetTextFromValue(txtUseDosboxBaseDir, sett.UseDosboxBaseDir);
		UiHelper.SetCheckboxFromValue(cbUseDosboxBaseDirSet, sett.UseDosboxBaseDir != null);

		UiHelper.SetComboFromValue(comboOpenLoggingConsole, sett.ConsoleOnLaunch);
		UiHelper.SetCheckboxFromValue(cbOpenLoggingConsoleSet, sett.ConsoleOnLaunch != null);

		UiHelper.SetComboFromValue(comboDontApplyKbMappings, sett.DontApplyKbMappings);
		UiHelper.SetCheckboxFromValue(cbDontApplyKbMappingsSet, sett.DontApplyKbMappings != null);

		// Grouped settings
		SettingsUiBinder.SetUiFromGroupedSettings(sett, _controlInfo);

		// Autoexec script
		loadAutoexec(settFlatCustom, txtAutoexec);

		// Other custom settings
		loadCustomSettings(settFlatCustom, flowPnlCustom, addCustomSettingRow);

		// Overlaying N/A in front of general controls when editing globals
		showGeneralNotApplicable(editingGlobals);

		return success;

		static void loadAutoexec(IReadOnlyDictionary<string, object> settFlatCustom, TextBox ctrl) {
			ctrl.Text = string.Join(Environment.NewLine, DosboxConfigMergeHelper.GetAutoexecLinesFromCustomSettings(settFlatCustom));
		}

		static void loadCustomSettings(IReadOnlyDictionary<string, object> settFlat, FlowLayoutPanel ctrl, Action<FlowLayoutPanel, string, string, string> addCustomSettingRow) {
			ctrl.Controls.Clear();

			foreach (var (sectionKey, val) in settFlat) {
				var parts = sectionKey.Split('.', 2);

				var section = parts[0];
				var key = parts.Length > 1 ? parts[1] : "";
				var value = val?.ToString() ?? "";
				if (section == "autoexec") { continue; }

				addCustomSettingRow(ctrl, section, key, value);
			}
		}

		static void resetGlobalNaSettings(LaunchSettings sett) {
			sett.Name = sett.Description = sett.BaseDir = sett.Executable = sett.UseDosboxBaseDir = null;
			sett.LimitBaseDirFreeSpace = null;
			sett.ExitAfterTerminate = null;
		}

		void showGeneralNotApplicable(bool makeVisible) {
			// When showing N/A, general controls must be disabled; otherwise, enabled.
			lblGeneralSet.Enabled =
				lblNameDescriptionNote.Enabled =
				lblName.Enabled = txtName.Enabled =
				lblDescription.Enabled = txtDescription.Enabled =
				cbBaseDirSet.Enabled = cbLimitBaseDirFreeSpaceSet.Enabled = cbExecutableSet.Enabled =
				cbExitAfterTerminateSet.Enabled = cbUseDosboxBaseDirSet.Enabled =
				!makeVisible;
			pnlGeneralSettingsMain.BackColor = makeVisible ? SystemColors.ControlLight : SystemColors.Control;
			lblNotApplicable.Font = _lblFontNa;
			lblNotApplicable.Size = new(352, 166);
			lblNotApplicable.Location = new(129, 23);
			lblNotApplicable.Visible = makeVisible;
			lblNotApplicable.Refresh();
		}
	}

	private List<KeyboardMapping> collectCurrentUiMappings() {
		var mappings = new List<KeyboardMapping>();

		foreach (DataGridViewRow row in dataGridMappings.Rows) {
			if (row.IsNewRow) { continue; }

			var isSet = row.Cells["IsSet"].Value as bool? ?? false;
			if (!isSet) { continue; }

			var section = row.Cells["Section"].Value?.ToString() ?? "";
			var key = row.Cells["Key"].Value?.ToString() ?? "";
			var newMapping = row.Cells["NewMapping"].Value?.ToString() ?? "";

			mappings.Add(new KeyboardMapping {
				Section = section,
				Key = key,
				Mapping = newMapping.Trim()
			});
		}

		return mappings;
	}

	private void refreshPrePostAutoexec() {
		StringBuilder sb = new();

		string? baseDir = cbBaseDirSet.Checked ? UiHelper.GetTextValue(txtBaseDir) : null;
		int? limitBaseDirFreeSpace = cbLimitBaseDirFreeSpaceSet.Checked ? UiHelper.GetLimitFreeSpaceValue(comboLimitBaseDirFreeSpace) : null;
		string? executable = cbExecutableSet.Checked ? UiHelper.GetTextValue(txtExecutable) : null;
		bool? exitAfterTerminate = cbExitAfterTerminateSet.Checked ? UiHelper.GetComboValue<bool>(comboExitAfterTerminate) : null;

		(var preAutoexec, var postAutoexec) = DosboxConfigMergeHelper.GeneratePrePostAutoexec(
			baseDir,
			limitBaseDirFreeSpace,
			executable,
			exitAfterTerminate,
			LocalAppDataHelper.IsGlobalShortcut(_localAppDataDir, _currentShortcutFilePath)
		);

		sb.Clear();
		foreach (var line in preAutoexec) {
			sb.AppendLine(line);
		}
		txtPreAutoexec.Text = $"{sb}";

		sb.Clear();
		foreach (var line in postAutoexec) {
			sb.AppendLine(line);
		}
		txtPostAutoexec.Text = $"{sb}";
	}

	private void addCustomSettingRow(FlowLayoutPanel ctrl, string section, string key, string value) {
		// Create the container panel for this row
		var rowPanel = new FlowLayoutPanel {
			AutoSize = true,
			AutoSizeMode = AutoSizeMode.GrowAndShrink,
			Dock = DockStyle.Top,
			FlowDirection = FlowDirection.LeftToRight,
			WrapContents = false,
			Margin = new Padding(3, 0, 3, 0),
		};

		// Section textbox
		var txtSection = new TextBox {
			Name = "txtSection",
			Text = section,
			Width = 180,
			Margin = new Padding(3),
		};
		rowPanel.Controls.Add(txtSection);

		// Key textbox
		var txtKey = new TextBox {
			Name = "txtKey",
			Text = key,
			Width = 300,
			Margin = new Padding(3),
		};
		rowPanel.Controls.Add(txtKey);

		// Value textbox
		var txtValue = new TextBox {
			Name = "txtValue",
			Text = value,
			Width = 620,
			Margin = new Padding(3),
		};
		rowPanel.Controls.Add(txtValue);

		// Validations
		void validateSectionAndKey(string section, string key, CancelEventArgs ea) {
			section = section.Trim().ToLower();
			key = key.Trim().ToLower();
			string fullKey = string.IsNullOrEmpty(key) ? section : $"{section}.{key}";

			if (section.Contains('.')) {
				MessageBoxHelper.ShowErrorMessageOk(@"A section name may not contain a dot.", "Invalid Section Name");
				ea.Cancel = true;
				return;
			}

			if (section == "autoexec") {
				MessageBoxHelper.ShowErrorMessageOk(@"The section name ""autoexec"" is reserved and cannot be used for custom settings.", "Invalid Section Name");
				ea.Cancel = true;
				return;
			}

			var reserved = sectionKeyReserved(section, key);
			if (reserved != null) {
				MessageBoxHelper.ShowErrorMessageOk($@"The section/key ""{reserved}"" is already managed by the main settings and can't be overridden by a custom setting.", "Invalid Section/Key Name");
				ea.Cancel = true;
			}

			var uiSetts = getCustomSettingsFromUi();
			if (uiSetts.TryGetValue((section, string.IsNullOrWhiteSpace(key) ? null : key), out var values) && values.Count > 1) {
				MessageBoxHelper.ShowErrorMessageOk($@"The section/key ""{fullKey}"" already exists in custom settings.", "Duplicate Custom Setting");
				ea.Cancel = true;
			}
		}

		txtSection.Validating += (sender, ea) => validateSectionAndKey(txtSection.Text, txtKey.Text, ea);
		txtKey.Validating += (sender, ea) => validateSectionAndKey(txtSection.Text, txtKey.Text, ea);
		txtSection.Validated += (sender, ea) => { txtSection.Text = txtSection.Text.Trim().ToLower(); };
		txtKey.Validated += (sender, ea) => { txtKey.Text = txtKey.Text.Trim().ToLower(); };

		// Delete button
		var btnDelete = new Button {
			Text = "Delete",
			AutoSize = true,
			Margin = new Padding(2),
		};
		btnDelete.Click += (sender, ea) => {
			ctrl.Controls.Remove(rowPanel);
			rowPanel.Dispose();
			_shortcutDirty = true;
			updateUiDirtyState();
		};
		rowPanel.Controls.Add(btnDelete);

		// Add the row to the FlowLayoutPanel and scroll
		ctrl.Controls.Add(rowPanel);
		ctrl.ScrollControlIntoView(rowPanel);

		// Attach handlers for controls
		attachControlHandlers(txtSection);
		attachControlHandlers(txtKey);
		attachControlHandlers(txtValue);
	}

	private void enableMappingSettings(bool doDisable = false) {
		dataGridMappings.Enabled = !doDisable;
		grpMapperNotFound.Visible = doDisable;
	}

	private void disableMappingSettings() => enableMappingSettings(true);

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private void MainForm_Load(object sender, EventArgs ea) {
		try {
			Text += $" [{ThisAssembly.GitCommitId[..7]}]";
			if (_data.IsDebugBuild) {
				Text += " (DEBUG BUILD)";
			}

			_localAppDataDir = LocalAppDataHelper.EnsureLocalAppDataDir(_data.ProgramName);
			LocalAppDataHelper.LoadSettingsIfAvailable(_localAppDataDir, _genSettingsFileService, _settings);

			UiHelper.CheckRequiredFiles(_settings, _data, true);

			DataGridHelper.InitMappingsDataGrid(dataGridMappings, validateTextCtrlContent, controlValueChanged);
			initAndProcessControls(tabsContainer);
			SettingsUiBinder.ValidateUiControlsForGroupedSettings(new(), _controlInfo);
			attachPrePostAutoexecHandlers();
			refreshPrePostAutoexec();
			if (_providedShortcutPath != null) {
				doOpen(_providedShortcutPath);
			}
			else {
				initNewShortcut();
			}
			BeginInvoke(selectFirstControl);

			timerRefreshNa.Start();
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk($"FATAL ERROR: {ex.Message}", "Error");
			Environment.Exit(1);
		}
	}

	private void MainForm_DragEnter(object sender, DragEventArgs ea) {
		if (ea.Data?.GetDataPresent(DataFormats.FileDrop) == true) {
			string[] files = (string[])ea.Data.GetData(DataFormats.FileDrop)!;
			if (files.Length == 1 && Path.GetExtension(files[0]).Equals($".{_data.ShortcutFiletypeExtension.ToLower()}", StringComparison.OrdinalIgnoreCase)) {
				ea.Effect = DragDropEffects.Copy;
				return;
			}
		}
		ea.Effect = DragDropEffects.None;
	}

	private void MainForm_DragDrop(object sender, DragEventArgs ea) {
		if (ea.Data?.GetDataPresent(DataFormats.FileDrop) == true) {
			string[] files = (string[])ea.Data.GetData(DataFormats.FileDrop)!;
			if (files.Length == 1 && Path.GetExtension(files[0]).Equals(".dlx", StringComparison.OrdinalIgnoreCase)) {
				BringToFront();
				Activate();
				doOpen(files[0]);
			}
		}
	}

	private void MainForm_FormClosing(object sender, FormClosingEventArgs ea) {
		// Force all controls to validate first
		if (!ValidateChildren()) {
			ea.Cancel = true;
			return;
		}

		// Prompt for dirty shortcut
		if (!promptSaveIfDirty()) {
			ea.Cancel = true;
			return;
		}
	}
#pragma warning restore IDE1006 // Naming Styles

	private void mnuNew_Click(object sender, EventArgs ea) {
		if (!ValidateChildren()) { return; }
		if (!promptSaveIfDirty()) { return; }

		initNewShortcut();
	}

	private void mnuOpen_Click(object sender, EventArgs ea) {
		doOpen();
	}

	private void mnuSave_Click(object sender, EventArgs ea) {
		doSave();
	}

	private void mnuSaveAs_Click(object sender, EventArgs ea) {
		doSaveAs();
	}

	private void mnuEditGlobals_Click(object sender, EventArgs ea) {
		var globalsPath = LocalAppDataHelper.GetGlobalShortcut(_localAppDataDir);
		if (!File.Exists(globalsPath)) {
			_launchSettingsFileService.SaveToFile(new(), globalsPath);
		}
		doOpen(globalsPath);
	}

	private void mnuExit_Click(object sender, EventArgs ea) {
		Application.Exit();
	}

	private void mnuOptions_Click(object sender, EventArgs ea) {
		using var optionsForm = _formFact.CreateOptionsForm();
		optionsForm.ShowDialog();
	}

	private void mnuInfo_Click(object sender, EventArgs ea) {
		using var helpForm = _formFact.CreateHelpForm();
		helpForm.ShowDialog();
	}

	private void mnuAbout_Click(object sender, EventArgs ea) {
		using var aboutForm = _formFact.CreateAboutForm();
		aboutForm.ShowDialog();
	}

	private void lblExecutable_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			When a shortcut is being used to run a DOS game/app rather than just start a DOS shell with a particular configuration, the name of the executable to run can be entered here.

			If there are already existing commands in the autoexec section, this command will be added after them.
			""",
			"Executable setting"
		);
	}

	private void lblBaseDir_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			This is the directory that will be mounted as the C: drive before the executable is run.

			If there are already existing commands in the autoexec section, this mount command will be added before them (as well as a command to switch to the C: drive).
			""",
			"Base Directory setting"
		);
	}

	private void btnExecutableBrowse_Click(object sender, EventArgs ea) {
		doBrowseExecutable();
	}

	private void btnUseDosboxBaseDirBrowse_Click(object sender, EventArgs ea) {
		doBrowseDosboxBaseDir();
	}

	private void lblAutoexecScript_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			The autoexec script that will be run on start.

			If there are already existing commands in the autoexec section of the base DOSBox-X config file, this script will be added after them.
			""",
			"Autoexec Script setting"
		);
	}

	private void btnAddCustomSetting_Click(object sender, EventArgs ea) {
		addCustomSettingRow(flowPnlCustom, "", "", "");

		if (!_shortcutDirty) {
			_shortcutDirty = true;
			updateUiDirtyState();
		}
	}

	private void btnAddCustomLoggingSetting_Click(object sender, EventArgs ea) {
		var loggingSection = "log";

		using var logForm = _formFact.CreateLoggingSettingForm(new LoggingSettingFormDynamicParams {
			LoggingTypeVerbosityValidator = (formVals) => {
				formVals.LoggingType = formVals.LoggingType.Trim().ToLower();
				formVals.Verbosity = formVals.Verbosity.Trim().ToLower();
				string fullKey = string.IsNullOrEmpty(formVals.LoggingType) ? loggingSection : $"{loggingSection}.{formVals.LoggingType}";

				var reserved = sectionKeyReserved(loggingSection, formVals.LoggingType);
				if (reserved != null) {
					return $@"The section/key ""{reserved}"" is already managed by the main settings and can't be overridden by a custom setting.";
				}

				var uiSetts = getCustomSettingsFromUi();
				if (uiSetts.TryGetValue((loggingSection, string.IsNullOrWhiteSpace(formVals.LoggingType) ? null : formVals.LoggingType), out var values) && values.Count > 0) {
					return $@"The section/key ""{fullKey}"" already exists in custom settings.";
				}

				foreach (var formVal in (IEnumerable<string>)[formVals.LoggingType, formVals.Verbosity]) {
					if (formVal.Contains('\r') || formVal.Contains('\n')) {
						return $@"Control text contains invalid newline characters.";
					}
				}

				return null; // Indicates no error
			}
		});
		logForm.ShowDialog();
		if (logForm.LoggingType == null || logForm.Verbosity == null) { return; }

		addCustomSettingRow(flowPnlCustom, loggingSection, logForm.LoggingType, logForm.Verbosity);

		if (!_shortcutDirty) {
			_shortcutDirty = true;
			updateUiDirtyState();
		}
	}

	private void timerRefreshNa_Tick(object sender, EventArgs ea) {
		// This is needed because when we go to edit globals, the animation to disable the general controls
		// can mean that N/A gets drawn behind one of these controls, as it's drawn before the control's
		// disable "fade" animation completes.  Thus we need to keep refreshing it to force it in front.
		// Purely a visual thing, and those controls will still be properly disabled at the right time.
		lblNotApplicable.Refresh();
	}

	private void btnMapperRescan_Click(object sender, EventArgs ea) {
		if (!generateUiFromShortcutLaunchSettings(new(), true)) {
			MessageBoxHelper.ShowErrorMessageOk(
				$"Couldn't read mapper file {_data.DosboxMapperBaseFilename} in the base DOSBox directory.",
				"Couldn't read mapper"
			);
		}
	}

	private void lblScaler_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			Note that for most scalers to actually work, you need to set the 'doublescan' setting to false.
			""",
			"Scaler setting"
		);
	}

	private void btnMt32RomDirBrowse_Click(object sender, EventArgs ea) {
		doBrowseMt32Romdir();
	}

	private void lblMouseMiddleUnlock_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			When this is set to 'manual', middle-click unlock works only with 'autolock' at false.

			When this is set to 'auto', middle-click unlock works only with 'autolock' at true.

			When this is set to 'both', middle-click unlock works with either setting.
			""",
			"Middle Mouse Btn Unlock setting"
		);
	}

	private void lblCore_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			Note that in order to avoid instructions being skipped or breakpoints being missed whilst stepping through instructions in the debugger, the core most be set to 'normal'. If not using the debugger, though, this usually isn't needed and may cause slightly lower performance.
			""",
			"CPU Core setting"
		);
	}

	private void lblGusDir_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			This directory should *not* be a path to a directory on your machine's actual file system; it should be the path to the Gravis Ultrasound directory within the DOSBox session. For instance, you may want to mount your ULTRASND dir to the G drive in Autoexec:

			MOUNT G C:\path\to\ULTRASND

			You would then set this directory value to something like 'G:\USPPL161'.

			Also note that some games (though not all) required the 'ULTRAMID' TSR to be loaded before the game could use GUS for its music/sound, so before running the game you'd run maybe 'G:\USPPL161\ULTRAMID.EXE' to first load ULTRAMID (you'd also want to add this to your Autoexec section so it happened automatically on each launch).
			""",
			"Gravis Ultrasound Dir setting"
		);
	}

	private void lblMt32Model_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			NOTE: The MT-32 synthesizer could display short LCD messages on its screen. Sometimes games or apps would use this to display interesting information. If you want to be able to see these messages while running DOSBox you might want to enable the 'Open the DOSBox logging console on launch' option in the General tab. Any messages that would be displayed by the MT-32 will be displayed in the console.
			""",
			"MT-32 messages"
		);
	}

	private void btnTestLaunch_Click(object sender, EventArgs ea) {
		try {
			if (!doSave()) { return; }
			doTestLaunch();
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk(
				$"Unable to save & test launch: {ex.Message}",
				"Error with save & test launch"
			);
		}
	}

	private void btnPrintDocDirBrowse_Click(object sender, EventArgs ea) {
		doBrowsePrintDocDir();
	}

	private void btnLogOutputFileBrowse_Click(object sender, EventArgs ea) {
		doBrowseLogOutputFile();
	}

	private void lblLogOutputFile_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			Note that although you can specify a file to which DOSBox logging will be output, you can still just view the logs in the logging console too. It's not necessary to go through an actual file.
			""",
			"Logging Output to File setting"
		);
	}

	private void lblDosVersion_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			DOS version 7.0 is 'Windows 95 DOS'. DOS version 7.1 is 'Windows 98 DOS'; this version supports mounting FAT32 drives.
			""",
			"DOS Version setting"
		);
	}
}
