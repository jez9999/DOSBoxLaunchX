using DOSBoxLaunchX.Factories;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;
using DOSBoxLaunchX.Logic.Services;
using DOSBoxLaunchX.Logic.Models;
using DOSBoxLaunchX.Logic.Helpers;

namespace DOSBoxLaunchX;

public partial class PreLaunchForm : Form {
	#region Private vars

	private readonly AppOptionsWithData _data;
	private readonly FormFactory _formFact;
	private readonly LaunchSettingsFileService _launchSettingsFileService;

	private string _providedDlxPath = null!;

	#endregion

	#region Constructors

	public PreLaunchForm(AppOptionsWithData data, FormFactory formFact, LaunchSettingsFileService launchSettingsFileService) {
		_data = data;
		_formFact = formFact;
		_launchSettingsFileService = launchSettingsFileService;

		InitializeComponent();
	}

	#endregion

	#region Non-event helper methods

	private void setupFormAndTitle(LaunchSettings sett) {
		lblShortcutTitle.Text = string.IsNullOrWhiteSpace(sett.Name) ? _providedDlxPath : sett.Name;

		// When showing description pre-launch, make the txtbox the size of the launch button and push
		// everything else down as well as expand the form by that amount
		if (sett.ShowDescriptionPreLaunch ?? false) {
			var width = btnLaunchNow.Width;
			var height = btnLaunchNow.Height;
			var shiftDownAmount = btnEditShortcut.Top - btnLaunchNow.Top;
			txtDescription.Text = StringParseHelper.TrimAfterSeparator(sett.Description ?? "", "-----");
			txtDescription.Width = width;
			txtDescription.Height = height;
			Height += shiftDownAmount;
			btnEditShortcut.Top += shiftDownAmount;
			btnLaunchNow.Top += shiftDownAmount;
			txtDescription.Visible = true;
		}
	}

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private void PreLaunchForm_Load(object sender, EventArgs ea) {
		try {
			Text += $" [{ThisAssembly.GitCommitId[..7]}]";
			if (_data.IsDebugBuild) {
				Text += " (DEBUG BUILD)";
			}

			_providedDlxPath = UiHelper.GetShortcutFromArgs(_data.Args)
				?? throw new Exception("No DLX shortcut specified!");

			if (!File.Exists(_providedDlxPath)) {
				lblShortcutTitle.Text = $"[Shortcut not found: {_providedDlxPath}]";
			}
			else {
				var sett = _launchSettingsFileService.LoadFromFile(_providedDlxPath);
				setupFormAndTitle(sett);
			}
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk($"FATAL ERROR: {ex.Message}", "Error");
			Environment.Exit(1);
		}
	}
#pragma warning restore IDE1006 // Naming Styles

#pragma warning disable CA2000 // Dispose objects before losing scope (mustn't dispose the replacement forms)
	private void btnLaunchNow_Click(object sender, EventArgs ea) {
		var launchForm = _formFact.CreateLauncherForm(new LauncherFormDynamicParams {
			ShortcutFilePath = _providedDlxPath,
		});

		launchForm.FormClosed += (sender, ea) => Application.Exit();

		Hide();
		launchForm.Show();
	}

	private void btnEditShortcut_Click(object sender, EventArgs ea) {
		var mainForm = _formFact.CreateMainForm(new MainFormDynamicParams {
			ShortcutFilePath = _providedDlxPath
		});

		mainForm.FormClosed += (sender, ea) => Application.Exit();

		Hide();
		mainForm.Show();
	}
#pragma warning restore CA2000 // Dispose objects before losing scope (mustn't dispose the replacement forms)
}
