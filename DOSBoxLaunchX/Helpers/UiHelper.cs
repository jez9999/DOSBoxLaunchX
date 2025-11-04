using System.Text.RegularExpressions;

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
}
