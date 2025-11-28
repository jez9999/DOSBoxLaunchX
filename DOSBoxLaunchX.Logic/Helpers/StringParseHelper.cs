namespace DOSBoxLaunchX.Logic.Helpers;

public class StringParseHelper {
	public static string TrimAfterSeparator(string desc, string separator) {
		var sb = new StringBuilder();
		using var reader = new StringReader(desc);

		string? line;
		bool firstLine = true;

		while ((line = reader.ReadLine()) is not null) {
			if (line.StartsWith(separator, StringComparison.Ordinal)) {
				break;
			}

			if (!firstLine) {
				sb.AppendLine();
			}

			sb.Append(line);
			firstLine = false;
		}

		return $"{sb}";
	}
}
