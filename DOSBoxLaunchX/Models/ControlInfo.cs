namespace DOSBoxLaunchX.Models;

public class ControlInfo {
	/// <summary>
	/// Original Tag string from the designer that was parsed.
	/// </summary>
	public required string Tag { get; set; }

	/// <summary>
	/// Whether this control should be ignored for processing by the event handlers, etc.
	/// </summary>
	public bool Ignore { get; set; } = false;

	/// <summary>
	/// For "Set" checkboxes: the controls (labels, textboxes, comboboxes, etc.) that are enabled/disabled
	/// when this checkbox is toggled.
	/// </summary>
	public readonly List<Control> AssociatedControls = [];

	/// <summary>
	/// Only relevant for textboxes: whether newlines are allowed.  Defaults to false.
	/// </summary>
	public bool AllowNewlines { get; set; } = false;
}
