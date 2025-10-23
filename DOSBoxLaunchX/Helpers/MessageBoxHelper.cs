namespace DOSBoxLaunchX.Helpers;

internal class MessageBoxHelper {
	// NOTE: we purposely only have error/info/question dialogs, because by Windows 10 there are only 2 different
	// sounds that play on messagebox popup; error, and normal.  As a warning dialog plays a normal sound, it
	// doesn't sound enough like an issue to be paid attention to.  Therefore a warning dialog shouldn't be
	// used.  Ideally Windows would have a separate sound for warnings but, for some reason, it doesn't.
	// Also, bear in mind that the MessageBoxIcon enum says there are actually only the following unique popup types:
	// - None
	// - Error
	// - Question
	// - Warning
	// - Information
	// ... so we're only missing out the None (pretty useless) and Warning (not obviously non-info enough) types.

	/// <summary>
	/// Shows a popup information message box.
	/// </summary>
	/// <param name="msgText">The text for the message box.</param>
	/// <param name="titleText">The title text for the message box.</param>
	/// <param name="buttons">The buttons to be displayed in the message box.</param>
	/// <param name="btnDefault">The default selected button in the message box.</param>
	/// <returns>The result of the interaction with the message box.</returns>
	internal static DialogResult ShowInfoMessage(string msgText, string titleText, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxDefaultButton btnDefault = MessageBoxDefaultButton.Button1) {
		return MessageBox.Show(msgText, titleText, buttons, MessageBoxIcon.Information, btnDefault);
	}

	/// <summary>
	/// Shows a popup question message box.
	/// </summary>
	/// <param name="msgText">The text for the message box.</param>
	/// <param name="titleText">The title text for the message box.</param>
	/// <param name="buttons">The buttons to be displayed in the message box.</param>
	/// <param name="btnDefault">The default selected button in the message box.</param>
	/// <returns>The result of the interaction with the message box.</returns>
	internal static DialogResult ShowQuestionMessage(string msgText, string titleText, MessageBoxButtons buttons = MessageBoxButtons.OKCancel, MessageBoxDefaultButton btnDefault = MessageBoxDefaultButton.Button1) {
		return MessageBox.Show(msgText, titleText, buttons, MessageBoxIcon.Question, btnDefault);
	}

	/// <summary>
	/// Shows a popup error message box.
	/// </summary>
	/// <param name="msgText">The text for the message box.</param>
	/// <param name="titleText">The title text for the message box.</param>
	/// <param name="buttons">The buttons to be displayed in the message box.</param>
	/// <param name="btnDefault">The default selected button in the message box.</param>
	/// <param name="showCancelledPopupOnCancel">If true, displays an info message box saying 'cancelled' if the 'cancel' button was clicked.</param>
	/// <returns>The result of the interaction with the message box.</returns>
	internal static DialogResult ShowErrorMessage(string msgText, string titleText, MessageBoxButtons buttons = MessageBoxButtons.OKCancel, MessageBoxDefaultButton btnDefault = MessageBoxDefaultButton.Button2, bool showCancelledPopupOnCancel = true) {
		var result = MessageBox.Show(msgText, titleText, buttons, MessageBoxIcon.Error, btnDefault);
		if (result == DialogResult.Cancel && showCancelledPopupOnCancel) {
			ShowInfoMessage("Cancelled.", "Cancelled");
		}
		return result;
	}

	/// <summary>
	/// Shows a popup error message box with just an OK button.
	/// </summary>
	/// <param name="msgText">The text for the message box.</param>
	/// <param name="titleText">The title text for the message box.</param>
	/// <returns>The result of the interaction with the message box.</returns>
	internal static DialogResult ShowErrorMessageOk(string msgText, string titleText) {
		return ShowErrorMessage(msgText, titleText, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
	}
}
