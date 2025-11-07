using System.Text;
using System.Text.RegularExpressions;
using DOSBoxLaunchX.Models;
using DOSBoxLaunchX.Logic.Models;

namespace DOSBoxLaunchX.Helpers;

internal static class UiHelper {
	internal static void SetTextFromValue(TextBox ctrl, string? val) {
		ctrl.Text = val ?? "";
	}

	internal static void SetCheckboxFromValue(CheckBox ctrl, bool val) {
		ctrl.Checked = val;
	}

	internal static void SetComboFromValue(ComboBox ctrl, bool? val) {
		SetComboFromValue(ctrl, val == null ? null : val == true ? "Yes" : "No");
	}

	internal static void SetComboFromValue(ComboBox ctrl, string? val) {
		if (val == null || !ctrl.Items.Contains(val)) {
			ctrl.SelectedIndex = 0;
			return;
		}
		ctrl.SelectedItem = val;
	}

	internal static void SetLimitFreeSpaceFromValue(ComboBox ctrl, int? val, int defaultVal) {
		val ??= defaultVal;

		foreach (string item in ctrl.Items) {
			if (Regex.IsMatch(item, $"{val}MiB")) {
				ctrl.SelectedItem = item;
				return;
			}
		}

		MessageBoxHelper.ShowErrorMessageOk($"Couldn't find valid 'limit free space' value '{val}' in ComboBox!", "Error setting ComboBox");
	}

	internal static string GetTextValue(TextBox ctrl) {
		return ctrl.Text;
	}

	internal static T GetComboValue<T>(ComboBox ctrl) {
		if (typeof(T) == typeof(string)) {
			return (T)(object)(ctrl.Text ?? "");
		}
		else if (typeof(T) == typeof(bool)) {
			return (T)(object)(ctrl.Text == "Yes");
		}
		else {
			throw new NotSupportedException($"Unsupported type: {typeof(T).Name}");
		}
	}

	internal static int? GetLimitFreeSpaceValue(ComboBox combo) {
		var match = Regex.Match(combo.Text, @"(?<Amount>[0-9]+)MiB");
		if (!match.Groups["Amount"].Success) {
			MessageBoxHelper.ShowErrorMessageOk("Couldn't get valid 'limit free space' value from ComboBox!", "Error parsing ComboBox");
			return null;
		}
		return int.Parse(match.Groups["Amount"].Value);
	}

	internal static void CheckRequiredFiles(GeneralSettings sett, AppOptionsWithData data, bool checkingOnStartup = false) {
		StringBuilder sb = new();

		if (string.IsNullOrWhiteSpace(sett.BaseDosboxDir)) {
			sb.AppendLine("The base DOSBox directory is not set. It must be set in order for the launcher to work.");
			if (checkingOnStartup) {
				sb.AppendLine();
				sb.AppendLine(@"Please go to ""Tools | Options"" and set the base DOSBox directory.");
			}
			MessageBoxHelper.ShowInfoMessage(
				$"{sb}".Trim(),
				"Base DOSBox Directory not set"
			);
			return;
		}

		if (!Directory.Exists(sett.BaseDosboxDir)) {
			sb.AppendLine($"Warning: the {(checkingOnStartup ? "configured" : "specified")} DOSBox base directory was not found.");
			sb.AppendLine();
			sb.AppendLine(sett.BaseDosboxDir);
			MessageBoxHelper.ShowInfoMessage(
				$"{sb}".Trim(),
				"Directory not found"
			);
			return;
		}

		bool notFound = false;
		sb.AppendLine($"Warning: the following required files were not found in the {(checkingOnStartup ? "configured" : "specified")} DOSBox base directory:");
		sb.AppendLine();

		if (!File.Exists(Path.Combine(sett.BaseDosboxDir, data.DosboxExeBaseFilename))) {
			notFound = true;
			sb.AppendLine($"- {data.DosboxExeBaseFilename}");
		}
		if (!File.Exists(Path.Combine(sett.BaseDosboxDir, data.DosboxConfBaseFilename))) {
			notFound = true;
			sb.AppendLine($"- {data.DosboxConfBaseFilename}");
		}

		if (notFound) {
			MessageBoxHelper.ShowInfoMessage(
				$"{sb}".Trim(),
				"Required files not found"
			);
		}
	}
}
