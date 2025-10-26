namespace DOSBoxLaunchX.Logic.Helpers;

public static class NewlinesHelper {
	public enum NewlineStyle {
		Unix,     // LF (\n)
		Windows,  // CRLF (\r\n)
		OldMac    // CR (\r)
	}

	/// <summary>
	/// Normalizes all newlines in the input text to the given newline style.
	/// </summary>
	/// <param name="input">The input text to normalize.</param>
	/// <param name="style">The style to normalize all newlines in the text to.</param>
	/// <returns>The text with normalized newlines.</returns>
	public static string NormalizeNewlines(string input, NewlineStyle style) {
		if (input == null) { return string.Empty; }

		// Normalize all newlines to \n first
		var normalized = input
			.Replace("\r\n", "\n")
			.Replace("\r", "\n");

		return style switch {
			NewlineStyle.Unix => normalized,
			NewlineStyle.Windows => normalized.Replace("\n", "\r\n"),
			NewlineStyle.OldMac => normalized.Replace("\n", "\r"),
			_ => throw new ArgumentOutOfRangeException(nameof(style), style, "Unrecognized newline style.")
		};
	}
}
