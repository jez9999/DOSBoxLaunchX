using System.Diagnostics;

namespace DOSBoxLaunchX;

public partial class AboutForm : Form {
	#region Constructors

	public AboutForm() {
		InitializeComponent();
	}

	#endregion

	#region Non-event helper methods

	private void launchUrl(string url) {
		var psi = new ProcessStartInfo {
			FileName = url,
			UseShellExecute = true // Use shell execute so filename being a URL launches URL in default browser
		};

		using var proc = Process.Start(psi)
			?? throw new InvalidOperationException($"Failed to launch URL: {url}");
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

	private void lnkGooey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs ea) {
		launchUrl("https://www.gooeysoftware.com/");
	}

	private void lnkDosboxLaunchXGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs ea) {
		launchUrl("https://github.com/jez9999/DOSBoxLaunchX");
	}

	private void lnkDosboxXHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs ea) {
		launchUrl("https://dosbox-x.com/");
	}

	private void lnkDosboxXGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs ea) {
		launchUrl("https://github.com/joncampbell123/dosbox-x");
	}

	private void lnkDosboxXDevBuilds_LinkClicked(object sender, LinkLabelLinkClickedEventArgs ea) {
		launchUrl("https://github.com/joncampbell123/dosbox-x/actions/workflows/vsbuild64.yml");
	}
}
