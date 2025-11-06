using System.ComponentModel;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX;

public partial class LoggingSettingForm : Form {
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string? LoggingType { get; private set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string? Verbosity { get; private set; }

	#region Private vars

	private readonly Func<(string LoggingType, string Verbosity), string?> _loggingTypeVerbosityValidator;

	#endregion

	#region Constructors

	public LoggingSettingForm(LoggingSettingFormDynamicParams dynamicParams) {
		_loggingTypeVerbosityValidator = dynamicParams.LoggingTypeVerbosityValidator;

		InitializeComponent();
	}

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private void LoggingSettingForm_Load(object sender, EventArgs ea) {
		comboLoggingType.Validated += (sender, ea) => { comboLoggingType.Text = comboLoggingType.Text.Trim().ToLower(); };
		comboVerbosity.Validated += (sender, ea) => { comboVerbosity.Text = comboVerbosity.Text.Trim().ToLower(); };
	}
#pragma warning restore IDE1006 // Naming Styles

	private void btnAdd_Click(object sender, EventArgs ea) {
		var result = _loggingTypeVerbosityValidator((comboLoggingType.Text, comboVerbosity.Text));
		if (result != null) {
			MessageBoxHelper.ShowErrorMessageOk(
				result,
				"Invalid Setting Data"
			);
			return;
		}

		LoggingType = comboLoggingType.Text;
		Verbosity = comboVerbosity.Text;
		Close();
	}
}
