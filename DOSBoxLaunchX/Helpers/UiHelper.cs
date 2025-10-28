namespace DOSBoxLaunchX.Helpers;

internal static class UiHelper {
	internal static void SetTextFromValue(TextBox ctrl, string? val) {
		ctrl.Text = val ?? "";
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

	internal static void SetCheckboxFromValue(CheckBox ctrl, bool val) {
		ctrl.Checked = val;
	}

	internal static string GetTextValue(TextBox ctrl) {
		return ctrl.Text;
	}

	internal static T GetComboValue<T>(ComboBox ctrl) {
		if (typeof(T) == typeof(string)) {
			return (T)(object)(ctrl.SelectedItem as string ?? "");
		}
		else if (typeof(T) == typeof(bool)) {
			return (T)(object)(ctrl.SelectedItem as string == "Yes");
		}
		else {
			throw new NotSupportedException($"Unsupported type: {typeof(T).Name}");
		}
	}
}
