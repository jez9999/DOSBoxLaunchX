namespace DOSBoxLaunchX.Helpers;

internal static class LocalAppDataHelper {
	internal static string EnsureLocalAppDataDir(string appName) {
		string appFolder = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
			appName
		);

		Directory.CreateDirectory(appFolder); // This will do nothing if it already exists

		return appFolder;
	}
}
