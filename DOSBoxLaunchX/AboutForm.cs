namespace DOSBoxLaunchX;

public partial class AboutForm : Form {
	#region Constructors

	public AboutForm() {
		InitializeComponent();
	}

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private void AboutForm_Load(object sender, EventArgs ea) {
		txtVersion.Text = $"[{ThisAssembly.GitCommitId}]";
		txtDate.Text = $"[{ThisAssembly.GitCommitDate:yyyy-MM-dd HH:mm}]";
	}
#pragma warning restore IDE1006 // Naming Styles

	private void btnOk_Click(object sender, EventArgs ea) {
		Close();
	}
}
