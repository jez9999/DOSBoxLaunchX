using System.Reflection;
using DOSBoxLaunchX.Logic.Helpers;
using DOSBoxLaunchX.Logic.Models;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX.Helpers;

internal static class SettingsUiBinder {
	/// <summary>
	/// Updates all GroupedSetting properties of a LaunchSettings instance from the corresponding UI controls.
	/// If a value control has an associated checkbox and it's unchecked, the property is set to null.
	/// </summary>
	public static void SetGroupedSettingsFromUi(LaunchSettings sett, Dictionary<Control, ControlInfo> controlInfo) {
		var map = new Dictionary<string, (PropertyInfo, object)>();
		LaunchSettingsMetaHelper.AddGroupedPropertiesToMap(map, sett);

		var controlsBySetting = controlInfo
			.Where(kvp => kvp.Value.Setting != null)
			.ToDictionary(kvp => kvp.Value.Setting!, kvp => kvp.Key);

		foreach (var kvp in map) {
			var settingKey = kvp.Key;
			var (prop, instance) = kvp.Value;

			if (!controlsBySetting.TryGetValue(settingKey, out var ctrl)) {
				MessageBoxHelper.ShowErrorMessageOk(
					$"No UI control found for grouped setting '{settingKey}'.",
					"Setting Missing"
				);
				continue;
			}

			var info = controlInfo[ctrl];
			var value = info.CheckboxControl != null && !info.CheckboxControl.Checked
				? null
				: ctrl.Text;

			prop.SetValue(instance, value);
		}
	}

	/// <summary>
	/// Updates the UI controls to reflect the current values of all GroupedSetting properties in LaunchSettings.
	/// For value controls with an associated checkbox, sets the Text and updates the checkbox state.
	/// </summary>
	public static void SetUiFromGroupedSettings(LaunchSettings sett, Dictionary<Control, ControlInfo> controlInfo) {
		var map = new Dictionary<string, (PropertyInfo, object)>();
		LaunchSettingsMetaHelper.AddGroupedPropertiesToMap(map, sett);

		var controlsBySetting = controlInfo
			.Where(kvp => kvp.Value.Setting != null)
			.ToDictionary(kvp => kvp.Value.Setting!, kvp => kvp.Key);

		foreach (var kvp in map) {
			var settingKey = kvp.Key;
			var (prop, instance) = kvp.Value;

			if (!controlsBySetting.TryGetValue(settingKey, out var ctrl)) {
				MessageBoxHelper.ShowErrorMessageOk(
					$"No UI control found for grouped setting '{settingKey}'.",
					"Setting Missing"
				);
				continue;
			}

			var info = controlInfo[ctrl];
			var value = prop.GetValue(instance) as string;

			ctrl.Text = value ?? "";
			if (info.CheckboxControl != null) {
				// If the property is null, checkbox is unchecked; otherwise checked
				info.CheckboxControl.Checked = value != null;
			}
		}
	}

	/// <summary>
	/// Validates that every value control with a Setting defined corresponds to an actual GroupedSetting
	/// property in LaunchSettings.  Displays modal errors if any controls are invalid.
	/// </summary>
	public static void ValidateUiControlsForGroupedSettings(LaunchSettings sett, Dictionary<Control, ControlInfo> controlInfo) {
		// Build a map of all GroupedSetting keys in LaunchSettings
		var groupedSettingsMap = new Dictionary<string, (PropertyInfo, object)>();
		LaunchSettingsMetaHelper.AddGroupedPropertiesToMap(groupedSettingsMap, sett);

		// Iterate all controls with a Setting defined
		foreach (var kvp in controlInfo) {
			var info = kvp.Value;
			if (string.IsNullOrEmpty(info.Setting)) { continue; }

			if (!groupedSettingsMap.ContainsKey(info.Setting)) {
				MessageBoxHelper.ShowErrorMessageOk(
					$"UI control '{kvp.Key.Name}' has Setting='{info.Setting}', but no corresponding grouped setting exists in LaunchSettings.",
					"UI Validation Error"
				);
			}
		}
	}
}
