namespace DOSBoxLaunchX.Helpers;

internal static class LocalAppDataHelper {
	internal static string EnsureLocalAppDataDir(string appName) {
		try {
			string appFolder = Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
				appName
			);

			Directory.CreateDirectory(appFolder); // This will do nothing if it already exists

			return appFolder;
		}
		catch (Exception ex) {
			throw new Exception($"Failed to ensure local app data directory: {ex.Message}", ex);
		}
	}

	internal static bool IsGlobalShortcut(string localAppDataDir, string? shortcutFilePath) {
		return (shortcutFilePath ?? "") == GetGlobalShortcut(localAppDataDir);
	}

	internal static string GetGlobalShortcut(string localAppDataDir) {
		return Path.Combine(localAppDataDir, "global.dlx");
	}
}
