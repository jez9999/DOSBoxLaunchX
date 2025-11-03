namespace DOSBoxLaunchX.Models;

/// <summary>
/// Contains metadata for a value control (TextBox/ComboBox) parsed from its Tag property.
/// The Tag string should contain key=value pairs corresponding to these properties:
///
/// ignore:  if true, this control is ignored by the parser.
/// setting: the grouped setting property this control binds to (eg., "cpu.cycles").
/// cb:      the checkbox control name that enables/disables this value control.
/// assoc:   comma-delimited list of additional controls (labels, etc.) to enable/disable with the checkbox.
/// nl:      whether newlines are allowed in the control's text.
/// </summary>
public class ControlInfo {
	/// <summary>
	/// Original Tag string from the designer that was parsed.
	/// </summary>
	public string Tag { get; set; } = "";

	/// <summary>
	/// Whether this control should be ignored for processing by event handlers, binding, etc.
	/// </summary>
	public bool Ignore { get; set; } = false;

	/// <summary>
	/// The grouped setting property this control binds to (eg., "cpu.cycles").
	/// Null for unbound controls.
	/// </summary>
	public string? Setting { get; set; } = null;

	/// <summary>
	/// The checkbox that toggles this value control.
	/// Null if the control is always enabled (no checkbox).
	/// </summary>
	public CheckBox? CheckboxControl { get; set; } = null;

	/// <summary>
	/// Additional controls (labels, etc.) enabled/disabled alongside the value control when the checkbox
	/// is toggled.
	/// </summary>
	public readonly List<Control> AssociatedControls = [];

	/// <summary>
	/// Whether newlines are allowed in the value control's text.
	/// </summary>
	public bool AllowNewlines { get; set; } = false;
}
