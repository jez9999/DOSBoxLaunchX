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
	}

	#endregion

	#region Non-event helper methods

	private void initNewShortcut() {
		// Reset UI first...
		resetControlDefaults(tabsContainer);
		radShortcut.Checked = true;
		selectFirstControl();

		// ... then underlying model.
		_currentShortcutFilePath = null;
		_shortcutDirty = false;
		updateUiShortcutFilePath();
		updateUiDirtyState();
	}

	private void resetControlDefaults(Control parent) {
		foreach (Control ctl in parent.Controls) {
			// Recurse first so children are processed
			if (ctl.HasChildren) { resetControlDefaults(ctl); }

			// Only process relevant control types
			if (!(ctl is CheckBox || ctl is TextBox || ctl is ComboBox)) { continue; }

			// Set default values from ControlInfo
			if (!_controlInfo.TryGetValue(ctl, out ControlInfo? info)) { continue; }

			switch (ctl) {
				case CheckBox cb:
					bool? cbVal = null;
					if (string.IsNullOrEmpty(info.DefaultValue)) {
						cbVal = false;
					}
					else if (bool.TryParse(info.DefaultValue, out bool cbValOut)) {
						cbVal = cbValOut;
					}
					cb.Checked = cbVal ?? cb.Checked;
					break;

				case TextBox tb:
					tb.Text = info.DefaultValue ?? "";
					break;

				case ComboBox combo:
					int? comboVal = null;
					if (string.IsNullOrEmpty(info.DefaultValue)) {
						comboVal = 0;
					}
					else if (int.TryParse(info.DefaultValue, out int comboValOut)) {
						if (comboValOut >= 0 && comboValOut < combo.Items.Count) {
							comboVal = comboValOut;
						}
						else {
							comboVal = 0;
						}
					}
					combo.SelectedIndex = comboVal ?? combo.SelectedIndex;
					break;
			}
		}
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
			if (info == null) { continue; }

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

				//radGlobal.Font = _radFontBold;
				//radGlobal.Text += "*";
			}
		}
		else {
			if (radShortcut.Text[^1] == '*') {
				radShortcut.Font = _radFontRegular;
				radShortcut.Text = radShortcut.Text[..^1];

				//radGlobal.Font = _radFontRegular;
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
				// TODO: implement (Save Globals and Save Shortcut menu options)
				//if (globalsDirty && !saveGlobals()) { return false; }
				//if (shortcutDirty && !saveShortcut()) { return false; }
				return true;

			case DialogResult.No:
				return true;

			case DialogResult.Cancel:
			default:
				return false;
		}
	}

	private void doSave() {
		doSaveAs(_currentShortcutFilePath);
	}

	private void doSaveAs(string? path = null) {
		if (!ValidateChildren()) {
			return;
		}

		// If no path is supplied, show the Save As dialog
		if (string.IsNullOrWhiteSpace(path)) {
			saveFileDialog.Title = "Save Shortcut As";
			// We purposely don't set the .InitialDirectory property.  When left unset,
			// the dialog helpfully remembers the last directory the user was in, which
			// is desired behaviour.
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

			if (saveFileDialog.ShowDialog() != DialogResult.OK) { return; }

			path = saveFileDialog.FileName;
		}

		try {
			_settingsFileService.SaveToFile(generateShortcutLaunchSettings(), path);
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk(
				$"""
				Failed to save launch shortcut:
				{ex.Message}
				""",
				"Error saving launch shortcut"
			);
			return;
		}

		// Saved successfully
		_currentShortcutFilePath = path;
		_shortcutDirty = false;
		updateUiShortcutFilePath();
		updateUiDirtyState();
	}

	private LaunchSettings generateShortcutLaunchSettings() {
		var sett = new LaunchSettings {
			Name = txtName.Text,
			Description = txtDescription.Text,
		};

		if (cbBaseDirSet.Checked) { sett.BaseDir = txtBaseDir.Text; }
		if (cbLimitBaseDirToOneGiBSet.Checked) { sett.LimitBaseDirToOneGiB = (comboLimitBaseDirToOneGiB.SelectedItem as string ?? "") == "Yes"; }
		if (cbExecutableSet.Checked) { sett.Executable = txtExecutable.Text; }

		if (cbCyclesSet.Checked) {
			sett.CPU.Cycles = txtCycles.Text;
		}

		return sett;
	}

	private void updateIsRegisteredLabel() {
		if (WinAppAssociator.IsAppRegistered(_data.ShortcutFiletypeExtension, _data.ShortcutFiletypeProgId)) {
			lblIsRegistered.Text = "Registered: YES";
		}
		else {
			lblIsRegistered.Text = "Registered: NO";
		}
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
			Text += " - DEBUG BUILD";
		}

		updateIsRegisteredLabel();

		initAndProcessControls(tabsContainer);
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
				string filePath = files[0];
				MessageBoxHelper.ShowInfoMessage("TODO: impl. drag/drop open", "");
				//OpenShortcut(filePath); // exec. existing open logic
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
		if (!ValidateChildren()) {
			return;
		}
		if (!promptSaveIfDirty()) { return; }

		initNewShortcut();
	}

	private void mnuOpen_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'Open Shortcut'", "");
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
}
