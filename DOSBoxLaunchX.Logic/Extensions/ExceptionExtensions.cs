using System.Linq;

namespace DOSBoxLaunchX.Logic.Extensions;

public static class ExceptionExtensions {
	#region Private methods

	private static int buildFormattedExceptionMessages(StringBuilder sb, Exception ex, int maxNesting, int nesting = 1) {
		int firstLineLength = 0;
		if (nesting == 1) {
			string firstLine = string.Format(":: Exception ({0}):", ex.GetType().ToString());
			firstLineLength = firstLine.Length;
			sb.AppendLine(":: ");
			sb.AppendLine(firstLine);
			sb.AppendLine(":: ");
		}

		var properties = ex.GetType().GetProperties();
		foreach (var property in properties.Where(prop => ex.InnerException == null || prop.Name != "InnerException")) {
			var propValue = property.GetValue(ex, null);
			sb.AppendLine(string.Format("* {0}: {1}", property.Name, (propValue ?? "[null]").ToString()));
		}

		if (nesting >= maxNesting) {
			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine($"MAX NESTING LEVEL ({maxNesting}) REACHED - no further inner exceptions will be explored!");
		}
		else if (ex.InnerException != null) {
			nesting++;
			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine(string.Concat(Enumerable.Repeat(":: ", nesting)));
			sb.AppendLine(string.Format("{0}InnerException ({1}):", string.Concat(Enumerable.Repeat(":: ", nesting)), ex.InnerException.GetType().ToString()));
			sb.AppendLine(string.Concat(Enumerable.Repeat(":: ", nesting)));
			buildFormattedExceptionMessages(sb, ex.InnerException, maxNesting, nesting);
		}

		return firstLineLength;
	}

	#endregion

	public static string GetFormattedExceptionMessages(this Exception ex, int maxNesting = 100) {
		if (ex == null) {
			return "Exception ([null])";
		}

		var sbBorderStart = new StringBuilder();
		var sbBorderEnd = new StringBuilder();
		var sbMain = new StringBuilder();

		// Ensure we start on a newline, for clarity
		sbBorderStart.AppendLine();

		int firstLineLength = buildFormattedExceptionMessages(sbMain, ex, maxNesting);
		sbBorderStart.AppendLine(new string('=', firstLineLength));
		sbBorderEnd.AppendLine(new string('=', firstLineLength));

		return sbBorderStart.ToString() + sbMain.ToString() + sbBorderEnd.ToString();
	}
}
