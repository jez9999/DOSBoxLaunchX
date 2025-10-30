using System.Reflection;
using System.ComponentModel;
using DOSBoxLaunchX.Factories;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;
using DOSBoxLaunchX.Services;
using DOSBoxLaunchX.Logic.Models;
using DOSBoxLaunchX.Logic.Services;
using DOSBoxLaunchX.Logic.Helpers;

namespace DOSBoxLaunchX;

public partial class MainForm : Form {
	#region Private vars

	private readonly AppOptionsWithData _data;
	private readonly FormFactory _formFact;
	private readonly FormsValidatorHelper _formsValidator;
	private readonly ControlInfoTagParser _ctrlTagParser;
	private readonly LaunchSettingsFileService _settingsFileService;
	private readonly Dictionary<Control, ControlInfo> _controlInfo = [];
	private readonly HashSet<string> _reservedSectionKeys;

	private readonly Font _radFontRegular;
	private readonly Font _radFontBold;
	private string? _currentShortcutFilePath = null;
	private bool _shortcutDirty = false;
	private bool _globalsDirty = false;

	#endregion

	#region Constructors

	public MainForm(AppOptionsWithData data, FormFactory formFact, FormsValidatorHelper formsValidator, ControlInfoTagParser ctrlTagParser, LaunchSettingsFileService settingsFileService) {
		_data = data;
		_formFact = formFact;
		_formsValidator = formsValidator;
		_ctrlTagParser = ctrlTagParser;
		_settingsFileService = settingsFileService;

		InitializeComponent();

		_radFontRegular = new Font(radShortcut.Font, FontStyle.Regular);
		_radFontBold = new Font(radShortcut.Font, FontStyle.Bold);
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

	private void initNewShortcut() {
		// Reset UI first...
		resetControlDefaults();
		radShortcut.Checked = true;
		selectFirstControl();

		// ... then underlying model.
		_currentShortcutFilePath = null;
		_shortcutDirty = false;
		updateUiShortcutFilePath();
		updateUiDirtyState();
	}

	private void resetControlDefaults() {
		generateUiFromShortcutLaunchSettings(new LaunchSettings {
			BaseDir = "",
			LimitBaseDirToOneGiB = true,
			Executable = "",
		});
	}

	private void selectFirstControl() {
		tabsContainer.SelectedTab = tabGeneral;
		txtName.Focus();
	}

	private void initAndProcessControls(Control parent) {
		foreach (Control ctl in parent.Controls) {
			// Recurse first so children are processed
			if (ctl.HasChildren) {
				initAndProcessControls(ctl);
			}

			// Only process relevant control types
			if (!(ctl is CheckBox || ctl is TextBox || ctl is ComboBox)) {
				continue;
			}

			string? tagStr = ctl.Tag as string;

			if (string.IsNullOrWhiteSpace(tagStr)) {
				MessageBoxHelper.ShowErrorMessageOk(
					$"Control '{ctl.Name}' is missing a Tag and should have one.",
					"Missing Tag"
				);
				continue;
			}

			var info = _ctrlTagParser.ParseTag(tagStr, ctl);
			if (info == null || info.Ignore) { continue; }

			// Store in dictionary
			_controlInfo[ctl] = info;

			// Attach appropriate handlers
			attachControlHandlers(ctl, info);

			if (ctl is CheckBox cb && info.AssociatedControls.Count > 0) {
				// Enable/disable associated controls if any
				updateAssociatedControlsState(cb, info);
			}
		}
	}

	private void attachControlHandlers(Control ctl) {
		attachControlHandlers(ctl, new ControlInfo { Tag = "" });
	}

	private void attachControlHandlers(Control ctl, ControlInfo info) {
		if (ctl is CheckBox cb) {
			cb.CheckedChanged += (sender, ea) => {
				// Enable/disable associated controls if any
				updateAssociatedControlsState(cb, info);

				// Always mark as dirty when checkbox changes
				controlValueChanged(sender, ea);
			};
		}
		else if (ctl is TextBox tb) {
			// Mark dirty on change
			tb.TextChanged += controlValueChanged;

			tb.Validating += (sender, ea) => {
				if (!info.AllowNewlines && (tb.Text.Contains('\r') || tb.Text.Contains('\n'))) {
					MessageBoxHelper.ShowErrorMessageOk("Control text contains invalid newline characters.", "Control text invalid");
					ea.Cancel = true;
				}
			};

			tb.Validated += (sender, ea) => {
				if (info.AllowNewlines) {
					var newlineStyle = Environment.NewLine switch {
						"\n" => NewlinesHelper.NewlineStyle.Unix,
						"\r\n" => NewlinesHelper.NewlineStyle.Windows,
						"\r" => NewlinesHelper.NewlineStyle.OldMac,
						_ => throw new InvalidOperationException($"Unrecognized environment newline format: {BitConverter.ToString(System.Text.Encoding.ASCII.GetBytes(Environment.NewLine))}")
					};
					var normalized = NewlinesHelper.NormalizeNewlines(tb.Text, newlineStyle);
					if (tb.Text != normalized) {
						tb.Text = normalized;
					}
				}
			};
		}
		else if (ctl is ComboBox combo) {
			// Mark dirty on change
			combo.SelectedIndexChanged += controlValueChanged;
		}
	}

	private void updateAssociatedControlsState(CheckBox cb, ControlInfo info) {
		foreach (var ctrl in info.AssociatedControls) {
			switch (ctrl) {
				case Label lbl:
					lbl.ForeColor = cb.Checked ? SystemColors.ControlText : ControlPaint.LightLight(SystemColors.ControlText);
					break;

				default:
					ctrl.Enabled = cb.Checked;
					break;
			}
		}
	}

	private void controlValueChanged(object? sender, EventArgs ea) {
		if (!_shortcutDirty) {
			_shortcutDirty = true;
			updateUiDirtyState();
		}
	}

	private void attachPrePostAutoexecHandlers() {
		cbBaseDirSet.CheckedChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
		txtBaseDir.TextChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
		cbExecutableSet.CheckedChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
		txtExecutable.TextChanged += (sender, ea) => {
			refreshPrePostAutoexec();
		};
	}

	private void updateUiShortcutFilePath() {
		if (radGlobal.Checked) {
			txtShortcutFilePath.Text = "";
			txtShortcutFilePath.Enabled = false;
			txtShortcutFilePath.BackColor = SystemColors.Window;
		}
		else {
			txtShortcutFilePath.Text = _currentShortcutFilePath ?? "[New shortcut]";
			txtShortcutFilePath.Enabled = true;
			txtShortcutFilePath.BackColor = Color.WhiteSmoke;
		}
	}

	private void updateUiDirtyState() {
		if (_shortcutDirty) {
			if (radShortcut.Text[^1] != '*') {
				radShortcut.Font = _radFontBold;
				radShortcut.Text += "*";

				//radGlobal.Font = _radFontBold; // TODO: use when implementing global settings
				//radGlobal.Text += "*";
			}
		}
		else {
			if (radShortcut.Text[^1] == '*') {
				radShortcut.Font = _radFontRegular;
				radShortcut.Text = radShortcut.Text[..^1];

				//radGlobal.Font = _radFontRegular; // TODO: use when implementing global settings
				//radGlobal.Text = radGlobal.Text[..^1];
			}
		}

		// Enable/disable menu items based on dirty state
		mnuSave.Enabled = _shortcutDirty;
		//mnuSaveGlobals.Enabled = _globalsDirty;
	}

	private bool promptSaveIfDirty(bool checkShortcutDirty = true, bool checkGlobalsDirty = false) {
		// If this method returns true, action can continue; otherwise, it should abort.
		bool shortcutDirty = checkShortcutDirty && _shortcutDirty;
		bool globalsDirty = checkGlobalsDirty && _globalsDirty;

		if (!shortcutDirty && !globalsDirty) {
			return true;
		}

		string msg;
		if (shortcutDirty && globalsDirty) {
			msg = "You have unsaved changes to both the current shortcut and the global settings. Do you want to save them?";
		}
		else if (shortcutDirty) {
			msg = "You have unsaved changes to the current shortcut. Do you want to save them?";
		}
		else {
			msg = "You have unsaved changes to the global settings. Do you want to save them?";
		}

		var result = MessageBoxHelper.ShowQuestionMessage(
			msg,
			"Save changes?",
			MessageBoxButtons.YesNoCancel,
			MessageBoxDefaultButton.Button1
		);

		switch (result) {
			case DialogResult.Yes:
				// TODO: implement (Save Globals menu option code)
				//if (globalsDirty && !saveGlobals()) { return false; }
				if (shortcutDirty && !doSave()) { return false; }
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
		openFileDialog.Filter = "DOS Executables (*.exe;*.com;*.bat)|*.exe;*.com;*.bat";
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
			var sett = _settingsFileService.LoadFromFile(path);
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
		_currentShortcutFilePath = path;
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
				saveFileDialog.FileName =
					!string.IsNullOrEmpty(_currentShortcutFilePath)
					? Path.GetFileName(_currentShortcutFilePath)
					: string.Empty;
			}
			catch {
				saveFileDialog.FileName = string.Empty;
			}

			if (saveFileDialog.ShowDialog() != DialogResult.OK) { return false; }

			path = saveFileDialog.FileName;
		}

		try {
			_settingsFileService.SaveToFile(generateShortcutLaunchSettingsFromUi(), path);
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

	private LaunchSettings generateShortcutLaunchSettingsFromUi() {
		// General and main settings
		var sett = new LaunchSettings {
			Name = UiHelper.GetTextValue(txtName),
			Description = UiHelper.GetTextValue(txtDescription),
		};

		if (cbBaseDirSet.Checked) { sett.BaseDir = UiHelper.GetTextValue(txtBaseDir); }
		if (cbLimitBaseDirToOneGiBSet.Checked) { sett.LimitBaseDirToOneGiB = UiHelper.GetComboValue<bool>(comboLimitBaseDirToOneGiB); }
		if (cbExecutableSet.Checked) { sett.Executable = UiHelper.GetTextValue(txtExecutable); }

		if (cbCyclesSet.Checked) { sett.CPU.Cycles = UiHelper.GetTextValue(txtCycles); }

		// Autoexec script
		saveAutoexec(sett, txtAutoexec);

		// Other custom settings
		saveCustomSettings(sett, flowPnlCustom);

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

		static void saveCustomSettings(LaunchSettings sett, FlowLayoutPanel ctrl) {
			foreach (var row in ctrl.Controls.OfType<FlowLayoutPanel>()) {
				var txtSection = row.Controls.OfType<TextBox>().FirstOrDefault(c => c.Name == "txtSection");
				var txtKey = row.Controls.OfType<TextBox>().FirstOrDefault(c => c.Name == "txtKey");
				var txtValue = row.Controls.OfType<TextBox>().FirstOrDefault(c => c.Name == "txtValue");

				if (txtSection == null || txtKey == null || txtValue == null) { continue; }

				string section = txtSection.Text.Trim();
				string key = txtKey.Text.Trim();
				string value = txtValue.Text.Trim();

				if (string.IsNullOrEmpty(section)) { continue; } // Skip entries with no section (mandatory)
				if (section.Equals("autoexec", StringComparison.OrdinalIgnoreCase)) { continue; }
				// ^ reserved name

				string fullKey = string.IsNullOrEmpty(key)
					? section
					: $"{section}.{key}";

				sett.SetCustomSetting(fullKey, value);
			}
		}
	}

	private void generateUiFromShortcutLaunchSettings(LaunchSettings sett) {
		var settFlatCustom = sett.GetCustomSettings();

		// General and main settings
		UiHelper.SetTextFromValue(txtName, sett.Name);
		UiHelper.SetTextFromValue(txtDescription, sett.Description);

		UiHelper.SetCheckboxFromValue(cbBaseDirSet, sett.BaseDir != null);
		UiHelper.SetTextFromValue(txtBaseDir, sett.BaseDir);

		UiHelper.SetCheckboxFromValue(cbLimitBaseDirToOneGiBSet, sett.LimitBaseDirToOneGiB != null);
		UiHelper.SetComboFromValue(comboLimitBaseDirToOneGiB, sett.LimitBaseDirToOneGiB);

		UiHelper.SetCheckboxFromValue(cbExecutableSet, sett.Executable != null);
		UiHelper.SetTextFromValue(txtExecutable, sett.Executable);

		UiHelper.SetCheckboxFromValue(cbCyclesSet, sett.CPU.Cycles != null);
		UiHelper.SetTextFromValue(txtCycles, sett.CPU.Cycles);

		// Autoexec script
		loadAutoexec(settFlatCustom, txtAutoexec);

		// Other custom settings
		loadCustomSettings(settFlatCustom, flowPnlCustom, addCustomSettingRow);

		static void loadAutoexec(IReadOnlyDictionary<string, object> settFlat, TextBox ctrl) {
			var autoexecLines = settFlat
				.Where(kvp => kvp.Key.StartsWith("autoexec."))
				.OrderBy(kvp => int.TryParse(kvp.Key["autoexec.".Length..], out var n) ? n : int.MaxValue)
				.Select(kvp => kvp.Value.ToString())
				.ToList();

			ctrl.Text = string.Join(Environment.NewLine, autoexecLines);
		}

		static void loadCustomSettings(IReadOnlyDictionary<string, object> settFlat, FlowLayoutPanel ctrl, Action<string, string, string> addCustomSettingRow) {
			ctrl.Controls.Clear();

			foreach (var (sectionKey, val) in settFlat) {
				var parts = sectionKey.Split('.', 2);

				var section = parts[0];
				var key = parts.Length > 1 ? parts[1] : "";
				var value = val?.ToString() ?? "";
				addCustomSettingRow(section, key, value);
			}
		}
	}

	private void updateIsRegisteredLabel() {
		if (WinAppAssociator.IsAppRegistered(_data.ShortcutFiletypeExtension, _data.ShortcutFiletypeProgId)) {
			lblIsRegistered.Text = "Registered: YES";
		}
		else {
			lblIsRegistered.Text = "Registered: NO";
		}
	}

	private void refreshPrePostAutoexec() {
		txtPreAutoexec.Text = """
			@REM [No BaseDir set]                                    eg. MOUNT C C:\games\pizza -freesize 1024
			@REM TODO: now C: command here potentially, mount above  eg. C:
			""";

		txtPostAutoexec.Text = """
			@REM [No Executable set]                                 eg. PIZZA.BAT
			@REM TODO: these texts should be pulled from utility code that generates them at launch time too
			""";

		// TODO: remember that global autoexec should be merged with local autoexec with global autoexec
		// coming BEFORE shortcut autoexec; not like other settings where shortcut overrides global.
	}

	private void addCustomSettingRow(string section, string key, string value) {
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
		}
		// TODO: ^ handle section/key dupes where multiple custom settings have the same one

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
			flowPnlCustom.Controls.Remove(rowPanel);
			rowPanel.Dispose();
			_shortcutDirty = true;
			updateUiDirtyState();
		};
		rowPanel.Controls.Add(btnDelete);

		// Add the row to the FlowLayoutPanel and scroll
		flowPnlCustom.Controls.Add(rowPanel);
		flowPnlCustom.ScrollControlIntoView(rowPanel);

		// Attach handlers for controls
		attachControlHandlers(txtSection);
		attachControlHandlers(txtKey);
		attachControlHandlers(txtValue);
	}

	private void addTxtboxMsg(string msg) {
		txtOutput.SelectionColor = Color.Black;
		txtOutput.SelectedText += msg + Environment.NewLine;
		txtOutput.ScrollToCaret();
		txtOutput.Update();
	}

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private void MainForm_Load(object sender, EventArgs ea) {
		try {
			_data.LocalAppDataDir = LocalAppDataHelper.EnsureLocalAppDataDir(_data.ProgramName);
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk($"FATAL ERROR: Failed to ensure local app data directory: {ex.Message}", "Error");
			Environment.Exit(1);
		}

		if (_data.IsDebugBuild) {
			Text += " (DEBUG BUILD)";
		}

		updateIsRegisteredLabel();

		initAndProcessControls(tabsContainer);
		attachPrePostAutoexecHandlers();
		refreshPrePostAutoexec();
		initNewShortcut();
		BeginInvoke(selectFirstControl);
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

		// Prompt for dirty shortcut/globals
		if (!promptSaveIfDirty(true, true)) {
			ea.Cancel = true;
			return;
		}
	}
#pragma warning restore IDE1006 // Naming Styles

	private void btnAssoc_Click(object sender, EventArgs ea) {
		WinAppAssociator.RegisterApp(_data.ShortcutFiletypeExtension, _data.ShortcutFiletypeProgId, $"{_data.ShortcutFiletypeDescription}{(_data.IsDebugBuild ? " - DEBUG BUILD" : "")}", _data.AppExePath);
		WinAppAssociator.TriggerExplorerIconsRefresh();

		updateIsRegisteredLabel();

		MessageBoxHelper.ShowInfoMessage(
			"DOSBoxLaunchX has been registered as a handler for .DLX files.",
			"Associated app with .DLX files"
		);
	}

	private void btnRemoveAssoc_Click(object sender, EventArgs ea) {
		WinAppAssociator.UnregisterApp(_data.ShortcutFiletypeExtension, _data.ShortcutFiletypeProgId);
		WinAppAssociator.TriggerExplorerIconsRefresh();

		updateIsRegisteredLabel();

		MessageBoxHelper.ShowInfoMessage(
			"DOSBoxLaunchX has been unregistered as a handler for .DLX files.",
			"Removed app's association with .DLX files"
		);
	}

	private void radShortcut_CheckedChanged(object sender, EventArgs ea) {
		updateUiShortcutFilePath();
	}

	private void radGlobal_CheckedChanged(object sender, EventArgs ea) {
		updateUiShortcutFilePath();
	}

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

	private void mnuSaveGlobals_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'Save Globals'", "");
	}

	private void mnuExit_Click(object sender, EventArgs ea) {
		Application.Exit();
	}

	private void mnuOptions_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'Options'", "");
	}

	private void mnuInfo_Click(object sender, EventArgs ea) {
		using var helpForm = _formFact.CreateHelpForm();
		helpForm.ShowDialog();
	}

	private void mnuAbout_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'About'", "");
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
		addCustomSettingRow("", "", "");

		if (!_shortcutDirty) {
			_shortcutDirty = true;
			updateUiDirtyState();
		}
	}
}
