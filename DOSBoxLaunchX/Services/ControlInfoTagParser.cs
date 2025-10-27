using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX.Services;

public class ControlInfoTagParser {
	public ControlInfo? ParseTag(string tagStr, Control ctl) {
		if (string.IsNullOrWhiteSpace(tagStr)) {
			MessageBoxHelper.ShowErrorMessageOk(
				$"Control '{ctl.Name}' is missing a Tag and should have one.",
				"Missing Tag"
			);
			return null;
		}

		var info = new ControlInfo {
			Tag = tagStr
		};

		if (string.Equals(tagStr, "defaults", StringComparison.OrdinalIgnoreCase)) { return info; }

		// Parse key=value pairs separated by '|'
		string[] parts = tagStr.Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
		foreach (string part in parts) {
			int eqIndex = part.IndexOf('=');
			if (eqIndex <= 0) {
				MessageBoxHelper.ShowErrorMessageOk(
					$"Malformed Tag for control '{ctl.Name}': '{part}'",
					"Tag Parse Error"
				);
				return null;
			}

			string key = part[..eqIndex].Trim();
			string value = part[(eqIndex + 1)..].Trim();

			switch (key.ToLowerInvariant()) {
				case "assoc":
					if (ctl is not CheckBox) {
						MessageBoxHelper.ShowErrorMessageOk(
							$"Control '{ctl.Name}' specifies 'assoc' but is not a CheckBox.",
							"Tag Warning"
						);
						return null;
					}

					string[] assocNames = value.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
					foreach (string name in assocNames) {
						Control[] found = ctl.FindForm()?.Controls.Find(name, true) ?? [];
						if (found.Length > 0) { info.AssociatedControls.Add(found[0]); }
						else {
							MessageBoxHelper.ShowErrorMessageOk(
								$"Associated control '{name}' not found for '{ctl.Name}'.",
								"Tag Warning"
							);
						}
					}
					break;

				case "default":
					info.DefaultValue = value;
					break;

				case "allownewlines":
					if (bool.TryParse(value, out bool allow)) { info.AllowNewlines = allow; }
					else {
						MessageBoxHelper.ShowErrorMessageOk(
							$"Invalid boolean value for 'allowNewlines' in control '{ctl.Name}': '{value}'",
							"Tag Parse Error"
						);
					}
					break;

				default:
					MessageBoxHelper.ShowErrorMessageOk(
						$"Unknown key '{key}' in Tag for control '{ctl.Name}'",
						"Tag Parse Error"
					);
					break;
			}
		}

		return info;
	}
}
