using DOSBoxLaunchX.Logic.Models;
using DOSBoxLaunchX.Logic.Services;

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

	internal static void LoadSettingsIfAvailable(string localAppDataDir, GeneralSettingsFileService genSettingsFileService, GeneralSettings settings) {
		var settingsPath = Path.Combine(localAppDataDir, "settings.json");
		if (!File.Exists(settingsPath)) { return; }

		var loadedSettings = genSettingsFileService.LoadFromFile(settingsPath);
		settings.BaseDosboxDir = loadedSettings.BaseDosboxDir;
		settings.CloseOnDosboxExit = loadedSettings.CloseOnDosboxExit;
		settings.WriteConfToBaseDir = loadedSettings.WriteConfToBaseDir;
	}

	internal static void SaveSettings(string localAppDataDir, GeneralSettingsFileService genSettingsFileService, GeneralSettings settings) {
		var settingsPath = Path.Combine(localAppDataDir, "settings.json");
		genSettingsFileService.SaveToFile(settings, settingsPath);
	}
}
