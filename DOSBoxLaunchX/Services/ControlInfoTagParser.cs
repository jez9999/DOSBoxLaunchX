using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX.Services;

public class ControlInfoTagParser {
	/// <summary>
	/// Parses a Tag string for a control.
	/// See the ControlInfo class for documentation on the format of the Tag string.
	/// </summary>
	/// <param name="tagStr">The Tag string to parse.</param>
	/// <param name="ctrl">The control from which the Tag string was read.</param>
	/// <returns>A control info structure representing the parsed Tag string data.</returns>
	public ControlInfo? ParseTag(string tagStr, Control ctrl) {
		if (string.IsNullOrWhiteSpace(tagStr)) {
			MessageBoxHelper.ShowErrorMessageOk(
					$"Control '{ctrl.Name}' is missing a Tag and should have one.",
					"Missing Tag"
				);
			return null;
		}

		var info = new ControlInfo {
			Tag = tagStr
		};

		// Parse key=value pairs separated by '|'
		string[] parts = tagStr.Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

		foreach (string part in parts) {
			int eqIndex = part.IndexOf('=');
			if (eqIndex <= 0) {
				MessageBoxHelper.ShowErrorMessageOk(
					$"Malformed Tag for control '{ctrl.Name}': '{part}'",
					"Tag Parse Error"
				);
				return null;
			}

			string key = part[..eqIndex].Trim();
			string value = part[(eqIndex + 1)..].Trim();

			switch (key.ToLowerInvariant()) {
				case "ignore":
					if (!bool.TryParse(value, out bool ignore)) {
						MessageBoxHelper.ShowErrorMessageOk(
							$"Invalid boolean value for 'ignore' in control '{ctrl.Name}': '{value}'",
							"Tag Parse Error"
						);
						return null;
					}
					info.Ignore = ignore;

					if (info.Ignore && parts.Length > 1) {
						MessageBoxHelper.ShowErrorMessageOk(
							$"Control '{ctrl.Name}' has 'ignore=true' but other keys are present in the Tag.",
							"Tag Parse Error"
						);
						return null;
					}

					if (info.Ignore) {
						return info; // Short-circuit if ignored
					}
					break;

				case "setting":
					info.Setting = value;
					break;

				case "cb":
					var cbCtrl = ctrl.FindForm()?.Controls.Find(value, true)
						.OfType<CheckBox>()
						.FirstOrDefault();
					if (cbCtrl == null) {
						MessageBoxHelper.ShowErrorMessageOk(
							$"Checkbox control '{value}' not found for '{ctrl.Name}'.",
							"Tag Warning"
						);
						return null;
					}
					info.CheckboxControl = cbCtrl;
					break;

				case "assoc":
					string[] assocNames = value.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
					foreach (string name in assocNames) {
						var found = ctrl.FindForm()?.Controls.Find(name, true) ?? [];
						if (found.Length > 0) {
							info.AssociatedControls.Add(found[0]);
						}
						else {
							MessageBoxHelper.ShowErrorMessageOk(
								$"Associated control '{name}' not found for '{ctrl.Name}'.",
								"Tag Warning"
							);
						}
					}
					break;

				case "nl":
					if (!bool.TryParse(value, out bool allowNl)) {
						MessageBoxHelper.ShowErrorMessageOk(
							$"Invalid boolean value for 'nl' in control '{ctrl.Name}': '{value}'",
							"Tag Parse Error"
						);
						return null;
					}
					info.AllowNewlines = allowNl;
					break;

				default:
					MessageBoxHelper.ShowErrorMessageOk(
						$"Unknown key '{key}' in Tag for control '{ctrl.Name}'",
						"Tag Parse Error"
					);
					return null;
			}
		}

		return info;
	}
}
