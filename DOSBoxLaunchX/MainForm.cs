using System.Text;
using DOSBoxLaunchX.Factories;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX;

public partial class MainForm : Form {
	#region Private vars

	private readonly AppOptionsWithData _data;
	private readonly FormFactory _formFact;

	#endregion

	#region Constructors

	public MainForm(AppOptionsWithData data, FormFactory formFact) {
		_data = data;
		_formFact = formFact;

		InitializeComponent();
	}

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private void MainForm_Load(object sender, EventArgs ea) {
		if (_data.IsDebugBuild) {
			Text += " - DEBUG BUILD";
		}

		StringBuilder sb = new();
		foreach (var arg in _data.Args) {
			sb.AppendLine($"- {arg}");
		}
		txtOutput.Text = $"{sb}";

		_data.LocalAppDataDir = LocalAppDataHelper.EnsureLocalAppDataDir(_data.ProgramName);

		// TODO: probable docs for 'executable name': When a shortcut is being used to run a DOS game/app rather than just start a DOS shell with a particular configuration, the name of the executable to run can be entered here to run it; if an autoexec section also exists, this will be added to the end of it.
	}
#pragma warning restore IDE1006 // Naming Styles

	private void btnAssoc_Click(object sender, EventArgs ea) {
		AppAssociator.RegisterApp(_data.ShortcutFiletypeExtension, _data.ShortcutFiletypeProgId, $"{_data.ShortcutFiletypeDescription}{(_data.IsDebugBuild ? " - DEBUG BUILD" : "")}", _data.AppExePath);
		AppAssociator.TriggerExplorerIconsRefresh();

		MessageBoxHelper.ShowInfoMessage(
			"DOSBoxLaunchX has been registered as a handler for .DLX files.",
			"Associated app with .DLX files"
		);
	}

	private void btnRemoveAssoc_Click(object sender, EventArgs ea) {
		AppAssociator.UnregisterApp(_data.ShortcutFiletypeExtension, _data.ShortcutFiletypeProgId);
		AppAssociator.TriggerExplorerIconsRefresh();

		MessageBoxHelper.ShowInfoMessage(
			"DOSBoxLaunchX has been unregistered as a handler for .DLX files.",
			"Removed app's association with .DLX files"
		);
	}

	private void btnSave_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'Save shortcut config settings'", "");
	}

	private void btnLoad_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'Load shortcut config settings'", "");
	}

	private void btnNew_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. 'New shortcut config settings'", "");
	}

	private void btnHelp_Click(object sender, EventArgs ea) {
		using var helpForm = _formFact.CreateHelpForm();
		helpForm.ShowDialog();
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
}
