using DOSBoxLaunchX.Factories;
using DOSBoxLaunchX.Helpers;

namespace DOSBoxLaunchX;

public partial class MainForm : Form {
	#region Private vars

	private readonly FormFactory _formFact;

	#endregion

	#region Constructors

	public MainForm(FormFactory formFact) {
		_formFact = formFact;

		InitializeComponent();
	}

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private void MainForm_Load(object sender, EventArgs ea) {
		txtOutput.Text = "Hello world!";
	}
#pragma warning restore IDE1006 // Naming Styles

	private void btnAssoc_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. associate button", "");
	}

	private void btnRemoveAssoc_Click(object sender, EventArgs ea) {
		MessageBoxHelper.ShowInfoMessage("TODO: Impl. remove associate button", "");
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
