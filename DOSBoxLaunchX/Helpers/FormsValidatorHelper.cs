namespace DOSBoxLaunchX.Helpers;

public class FormsValidatorHelper {
	/// <summary>
	/// Validates that the textbox entry text for the given sender contains a valid integer that can be parsed, and
	/// optionally that it's below a max value and that it's positive.  If the text is empty, it's assumed to be
	/// a valid value of zero.
	/// </summary>
	/// <param name="sender">The textbox whose entry text is to be checked.</param>
	/// <param name="maxValue">If non-null, specified the maximum valid integer value.</param>
	/// <param name="mustBePositive">Whether the integer entered must be positive.</param>
	/// <param name="placeholderTextWhenEmpty">
	/// If true, parses the placeholder text instead when the text entry is empty.  Otherwise, or if the placeholder
	/// text itself is empty, assumes that an empty text value is a valid value of zero.
	/// </param>
	/// <param name="messageBoxWhenInvalid">Whether to popup a message box when the value is invalid.</param>
	/// <returns>Whether the entry was a valid integer, and if so, the parsed value (will be zero if invalid).</returns>
	public (bool IsValid, int parsedValue) ValidateTextboxInt(TextBox sender, int? maxValue = null, bool mustBePositive = true, bool placeholderTextWhenEmpty = true, bool messageBoxWhenInvalid = true) {
		int parsed = 0;
		if (
			sender.Text.Length > 0 &&
			(
				!int.TryParse(sender.Text, out parsed) ||
				(maxValue.HasValue && parsed > maxValue.Value) ||
				(mustBePositive && parsed < 0)
			)
		) {
			if (messageBoxWhenInvalid) {
				MessageBoxHelper.ShowErrorMessageOk(
					$"Invalid value (must be {(mustBePositive ? "a positive" : "an")} integer{(maxValue.HasValue ? $" no larger than {maxValue.Value}" : "")}).",
					"Invalid value"
				);
			}
			return (false, 0);
		}
		if (sender.Text.Length == 0 && placeholderTextWhenEmpty && sender.PlaceholderText.Length > 0) {
			return (true, int.Parse(sender.PlaceholderText));
		}
		else {
			return (true, parsed);
		}
	}
}
