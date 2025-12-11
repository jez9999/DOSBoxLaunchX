namespace DOSBoxLaunchX.Logic.Helpers;

public static class ShortcutSentinelHelper {
	public const string ShortcutDirSentinel = "<shortcutDir>";

	public static string? ParseDirForShortcutSentinel(string? baseDir, string? shortcutFilePath, bool assumeBaseDirValIsSentinel = false) {
		if (baseDir == null) { return null; }

		if (assumeBaseDirValIsSentinel) { baseDir = ShortcutDirSentinel; }
		if (baseDir != ShortcutDirSentinel) { return baseDir; }

		if (shortcutFilePath == null) {
			return "";
		}
		else {
			try {
				return Path.GetDirectoryName(shortcutFilePath) ?? "";
			}
			catch (Exception) {
				return "";
			}
		}
	}
}
