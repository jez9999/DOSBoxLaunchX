using DOSBoxLaunchX.Logic.Models;
using DOSBoxLaunchX.Logic.Services;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX;

public partial class OptionsForm : Form {
	#region Private vars

	private readonly AppOptionsWithData _data;
	private readonly GeneralSettings _settings;
	private readonly GeneralSettingsFileService _genSettingsFileService;
	private readonly Dictionary<Control, object?> _originalValues = [];

	private string _localAppDataDir = null!;

	#endregion

	#region Constructors

	public OptionsForm(AppOptionsWithData data, GeneralSettings settings, GeneralSettingsFileService genSettingsFileService) {
		_data = data;
		_settings = settings;
		_genSettingsFileService = genSettingsFileService;

		InitializeComponent();
	}

	#endregion

	#region Non-event helper methods

	private void applyChanges(bool doCheck = true) {
		_settings.BaseDosboxDir = txtBaseDosboxDir.Text;
		_settings.CloseOnDosboxExit = cbCloseOnDosboxExit.Checked;
		_settings.WriteConfToBaseDir = cbWriteConfToBaseDir.Checked;
		_settings.LaunchImmediately = cbLaunchImmediately.Checked;

		LocalAppDataHelper.SaveSettings(_localAppDataDir, _genSettingsFileService, _settings);

		if (doCheck) { UiHelper.CheckRequiredFiles(_settings, _data); }
	}

	private void checkForChanges() {
		bool changed = _originalValues.Any(kv => !Equals(getCtrlValue(kv.Key), kv.Value));
		btnApply.Enabled = btnApply.Enabled || changed;
	}

	private object? getCtrlValue(Control ctrl) => ctrl switch {
		TextBox tb => tb.Text,
		CheckBox cb => cb.Checked,
		ComboBox cbo => cbo.SelectedItem,
		_ => null
	};

	private void updateAssociationStatus() {
		if (WinAppAssociator.IsAppRegistered(_data.ShortcutFiletypeExtension, _data.ShortcutFiletypeProgId)) {
			lblAssociateStatus.Text = "DOSBoxLaunchX is currently registered to handle .DLX files.";
		}
		else {
			lblAssociateStatus.Text = "DOSBoxLaunchX is NOT currently registered to handle .DLX files.";
		}
	}

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private void OptionsForm_Load(object sender, EventArgs ea) {
		try {
			_localAppDataDir = LocalAppDataHelper.EnsureLocalAppDataDir(_data.ProgramName);

			txtBaseDosboxDir.Text = _settings.BaseDosboxDir;
			cbCloseOnDosboxExit.Checked = _settings.CloseOnDosboxExit;
			cbWriteConfToBaseDir.Checked = _settings.WriteConfToBaseDir;
			cbLaunchImmediately.Checked = _settings.LaunchImmediately;

			_originalValues[txtBaseDosboxDir] = getCtrlValue(txtBaseDosboxDir);
			_originalValues[cbCloseOnDosboxExit] = getCtrlValue(cbCloseOnDosboxExit);
			_originalValues[cbWriteConfToBaseDir] = getCtrlValue(cbWriteConfToBaseDir);
			_originalValues[cbLaunchImmediately] = getCtrlValue(cbLaunchImmediately);

			updateAssociationStatus();
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk($"FATAL ERROR: {ex.Message}", "Error");
			Environment.Exit(1);
		}
	}
#pragma warning restore IDE1006 // Naming Styles

	private void btnBaseDosboxDirBrowse_Click(object sender, EventArgs ea) {
		if (folderBrowserDialog.ShowDialog() != DialogResult.OK) { return; }
		txtBaseDosboxDir.Text = folderBrowserDialog.SelectedPath;
		checkForChanges();
	}

	private void btnOk_Click(object sender, EventArgs ea) {
		if (btnApply.Enabled) { applyChanges(false); }
		UiHelper.CheckRequiredFiles(_settings, _data);
		Close();
	}

	private void btnCancel_Click(object sender, EventArgs ea) {
		Close();
	}

	private void btnApply_Click(object sender, EventArgs ea) {
		applyChanges();

		foreach (var kv in _originalValues.Keys.ToList()) {
			_originalValues[kv] = getCtrlValue(kv);
		}

		btnApply.Enabled = false;
	}

	private void txtBaseDosboxDir_Validated(object sender, EventArgs ea) {
		checkForChanges();
	}

	private void cbCloseOnDosboxExit_CheckedChanged(object sender, EventArgs ea) {
		checkForChanges();
	}

	private void cbWriteConfToBaseDir_CheckedChanged(object sender, EventArgs ea) {
		checkForChanges();
	}

	private void cbLaunchImmediately_CheckedChanged(object sender, EventArgs ea) {
		checkForChanges();
	}

	private void lblWriteConfToBaseDirHelp_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			"""
			If this is selected, temporary config files used to customize DOSBox with the launched shortcut's settings will be written to the base DOSBox directory.

			Otherwise, they will be written to this app's local app data directory.
			""",
			"Write Temp. Config Files to Base DOSBox Dir setting"
		);
	}

	private void btnSetAssociation_Click(object sender, EventArgs ea) {
		WinAppAssociator.RegisterApp(_data.ShortcutFiletypeExtension, _data.ShortcutFiletypeProgId, $"{_data.ShortcutFiletypeDescription}{(_data.IsDebugBuild ? " - DEBUG BUILD" : "")}", _data.AppExePath);
		WinAppAssociator.TriggerExplorerIconsRefresh();

		updateAssociationStatus();

		MessageBoxHelper.ShowInfoMessage(
			"DOSBoxLaunchX has been registered as a handler for .DLX files.",
			"Associated app with .DLX files"
		);
	}

	private void btnRemoveAssociation_Click(object sender, EventArgs ea) {
		WinAppAssociator.UnregisterApp(_data.ShortcutFiletypeExtension, _data.ShortcutFiletypeProgId);
		WinAppAssociator.TriggerExplorerIconsRefresh();

		updateAssociationStatus();

		MessageBoxHelper.ShowInfoMessage(
			"DOSBoxLaunchX has been unregistered as a handler for .DLX files.",
			"Removed app's association with .DLX files"
		);
	}

	private void lblBaseDosboxDir_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage(
			$"""
			The base DOSBox directory must contain the main executable {_data.DosboxExeBaseFilename} and config file {_data.DosboxConfBaseFilename} for the launcher to work correctly.

			In addition, if custom keyboard mappings are being used, this directory must also contain a {_data.DosboxMapperBaseFilename} file. If this file doesn't already exist in the base DOSBox-X dir you can generate it by running DOSBox-X, going into the mapper editor, and saving.
			""",
			"Base DOSBox Directory setting"
		);
	}
}
