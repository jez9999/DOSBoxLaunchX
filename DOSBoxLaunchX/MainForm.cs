using DOSBoxLaunchX.Factories;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;
using DOSBoxLaunchX.Services;
using DOSBoxLaunchX.Logic.Models;

namespace DOSBoxLaunchX;

public partial class MainForm : Form {
	#region Private vars

	private readonly AppOptionsWithData _data;
	private readonly FormFactory _formFact;
	private readonly FormsValidatorHelper _formsValidator;
	private readonly ControlInfoTagParser _ctrlTagParser;
	private readonly Dictionary<Control, ControlInfo> _controlInfo = [];

	private LaunchSettings _currentShortcut = null!;
	private LaunchSettings _currentGlobals = new();
	private string? _currentShortcutFilePath = null;
	private bool _shortcutDirty = false;
	private bool _globalsDirty = false;

	#endregion

	#region Constructors

	public MainForm(AppOptionsWithData data, FormFactory formFact, FormsValidatorHelper formsValidator, ControlInfoTagParser ctrlTagParser) {
		_data = data;
		_formFact = formFact;
		_formsValidator = formsValidator;
		_ctrlTagParser = ctrlTagParser;

		InitializeComponent();
	}

	#endregion

	#region Non-event helper methods

	private void initNewShortcut() {
		// Reset UI first...
		resetControlDefaults(tabsContainer);
		selectFirstControl();

		// ... then underlying model.
		_currentShortcut = new LaunchSettings();
		_currentShortcutFilePath = null;
		_shortcutDirty = false;
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
			tb.Enter += (sender, ea) => info.PreviousValue = tb.Text;

			tb.Validating += (sender, ea) => {
				if (!info.AllowNewlines && (tb.Text.Contains('\r') || tb.Text.Contains('\n'))) {
					MessageBoxHelper.ShowErrorMessageOk("Control text contains invalid newline characters.", "Control text invalid");
					ea.Cancel = true;
				}
			};

			tb.Validated += (sender, ea) => {
				if (tb.Text != info.PreviousValue) {
					controlValueChanged(sender, ea);
				}
			};
		}
		else if (ctl is ComboBox combo) {
			combo.Enter += (sender, ea) => info.PreviousValue = $"{combo.SelectedIndex}";

			combo.Validated += (sender, ea) => {
				if ($"{combo.SelectedIndex}" != info.PreviousValue) {
					controlValueChanged(sender, ea);
				}
			};
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

	private void updateUiDirtyState() {
		addTxtboxMsg("updating UI dirty state");
		// TODO: implement
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
		// TODO: if data's still dirty, modal popup allowing save/don't save/cancel
	}
#pragma warning restore IDE1006 // Naming Styles

	private void updateIsRegisteredLabel() {
		if (WinAppAssociator.IsAppRegistered(_data.ShortcutFiletypeExtension, _data.ShortcutFiletypeProgId)) {
			lblIsRegistered.Text = "Registered: YES";
		}
		else {
			lblIsRegistered.Text = "Registered: NO";
		}
	}

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
		updateShortcutFilePath();
	}

	private void radGlobal_CheckedChanged(object sender, EventArgs ea) {
		updateShortcutFilePath();
	}

	private void updateShortcutFilePath() {
		if (radGlobal.Checked) {
			txtShortcutFilePath.Enabled = false;
			txtShortcutFilePath.BackColor = SystemColors.Window;
		}
		else {
			txtShortcutFilePath.Enabled = true;
			txtShortcutFilePath.BackColor = Color.WhiteSmoke;
		}
	}

	private void newToolStripMenuItem_Click(object sender, EventArgs ea) {
		initNewShortcut();
	}

	private void openToolStripMenuItem_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'Open Shortcut'", "");
	}

	private void saveToolStripMenuItem_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'Save Shortcut'", "");
	}

	private void saveAsToolStripMenuItem_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'Save Shortcut As'", "");
	}

	private void saveGlobalsToolStripMenuItem_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'Save Globals'", "");
	}

	private void exitToolStripMenuItem_Click(object sender, EventArgs ea) {
		Application.Exit();
	}

	private void optionsToolStripMenuItem_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'Options'", "");
	}

	private void infoToolStripMenuItem_Click(object sender, EventArgs ea) {
		using var helpForm = _formFact.CreateHelpForm();
		helpForm.ShowDialog();
	}

	private void aboutToolStripMenuItem_Click(object sender, EventArgs ea) {
		//MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'About'", "");
		MessageBoxHelper.ShowErrorMessageOk("msgText", "titleText");
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
