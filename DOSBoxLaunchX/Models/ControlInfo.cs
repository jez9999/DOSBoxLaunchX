namespace DOSBoxLaunchX.Models;

public class ControlInfo {
	/// <summary>
	/// Original Tag string from the designer that was parsed.
	/// </summary>
	public required string Tag { get; set; }

	/// <summary>
	/// For "Set" checkboxes: the controls (labels, textboxes, comboboxes, etc.) that are enabled/disabled
	/// when this checkbox is toggled.
	/// </summary>
	public readonly List<Control> AssociatedControls = [];

	/// <summary>
	/// Default value for this control when initializing a new shortcut.
	/// </summary>
	public string? DefaultValue { get; set; }

	/// <summary>
	/// Only relevant for textboxes: whether newlines are allowed.  Defaults to false.
	/// </summary>
	public bool AllowNewlines { get; set; } = false;

	/// <summary>
	/// Stores the previous value of the control to detect changes on Validated.
	/// </summary>
	public string? PreviousValue { get; set; }
}
