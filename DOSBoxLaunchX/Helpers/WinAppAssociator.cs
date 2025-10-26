using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace DOSBoxLaunchX.Helpers;

public static partial class WinAppAssociator {
	#region DLL Imports

	[LibraryImport("shell32.dll")]
	private static partial void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

	#endregion

	private const string _classesPath = @"Software\Classes";

	/// <summary>
	/// Registers an app as the default handler for a given file type.  When the a file of the type is opened,
	/// the app will be invoked with the path to the file as the first argument to the app.
	/// NOTE: after calling this, TriggerExplorerIconsRefresh should generally be called immediately afterwards
	/// to make Explorer refresh its icons, or Explorer icon for the file type won't be updated.
	/// </summary>
	/// <param name="extension">The file extension to register as the default handler for.</param>
	/// <param name="progId">The Programmatic Identifier to use for app association.</param>
	/// <param name="description">The description of to use for the file type.</param>
	/// <param name="appExePath">The (unquoted) path of the application executable to invoke for the file type.</param>
	/// <param name="iconPath">The optional (unquoted) path to use for the associated file type's icon; if null, will use the application executable's icon by default.</param>
	public static void RegisterApp(string extension, string progId, string description, string appExePath, string? iconPath = null) {
		if (string.IsNullOrWhiteSpace(extension)) { throw new ArgumentException("File extension cannot be null or empty/whitespace.", nameof(extension)); }
		if (string.IsNullOrWhiteSpace(progId)) { throw new ArgumentException("ProgID cannot be null or empty/whitespace.", nameof(progId)); }
		if (string.IsNullOrWhiteSpace(appExePath)) { throw new ArgumentException("Application EXE path cannot be null or empty/whitespace.", nameof(appExePath)); }

		extension = $"{(extension.StartsWith('.') ? "" : ".")}{extension.ToLower()}";
		iconPath ??= $"\"{appExePath}\",0";

		// Register extension -> ProgID
		using (var extKey = Registry.CurrentUser.CreateSubKey($@"{_classesPath}\{extension}")) {
			extKey.SetValue("", progId);
		}

		// Register ProgID details (display name, icon, open command)
		using (var progIdKey = Registry.CurrentUser.CreateSubKey($@"{_classesPath}\{progId}")) {
			progIdKey.SetValue("", description); // Explorer "Type" string
			progIdKey.CreateSubKey("DefaultIcon").SetValue("", iconPath); // App's exe icon
			progIdKey.CreateSubKey(@"shell\open\command")
				.SetValue("", $"\"{appExePath}\" \"%1\""); // 'Open' command
		}
	}

	/// <summary>
	/// Unregisters an app as the default handler for a given file type.
	/// NOTE: after calling this, TriggerExplorerIconsRefresh should generally be called immediately afterwards
	/// to make Explorer refresh its icons, or Explorer icon for the file type won't be updated.
	/// </summary>
	/// <param name="extension">The file extension to unregister as the default handler for.</param>
	/// <param name="progId">The Programmatic Identifier used for app association.</param>
	public static void UnregisterApp(string extension, string progId) {
		if (string.IsNullOrWhiteSpace(extension)) { throw new ArgumentException("File extension cannot be null or empty/whitespace.", nameof(extension)); }
		if (string.IsNullOrWhiteSpace(progId)) { throw new ArgumentException("ProgID cannot be null or empty/whitespace.", nameof(progId)); }

		extension = $"{(extension.StartsWith('.') ? "" : ".")}{extension.ToLower()}";

		Registry.CurrentUser.DeleteSubKeyTree($@"{_classesPath}\{extension}", false);
		Registry.CurrentUser.DeleteSubKeyTree($@"{_classesPath}\{progId}", false);
	}

	/// <summary>
	/// Triggers Windows Explorer to refresh its icons cache.
	/// </summary>
	public static void TriggerExplorerIconsRefresh() {
		const uint SHCNE_ASSOCCHANGED = 0x08000000;
		const uint SHCNF_IDLIST = 0x0000;
		SHChangeNotify(SHCNE_ASSOCCHANGED, SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
	}

	/// <summary>
	/// Checks whether the app is currently registered as the default handler for a given file extension.
	/// </summary>
	/// <param name="extension">The file extension to check.</param>
	/// <param name="progId">The ProgID expected for the association.</param>
	/// <returns>If the app is currently registered as the default handler, true; otherwise false.</returns>
	public static bool IsAppRegistered(string extension, string progId) {
		if (string.IsNullOrWhiteSpace(extension)) { throw new ArgumentException("File extension cannot be null or empty/whitespace.", nameof(extension)); }
		if (string.IsNullOrWhiteSpace(progId)) { throw new ArgumentException("ProgID cannot be null or empty/whitespace.", nameof(progId)); }

		extension = $"{(extension.StartsWith('.') ? "" : ".")}{extension.ToLower()}";

		using (var extKey = Registry.CurrentUser.OpenSubKey($@"{_classesPath}\{extension}")) {
			if (extKey == null) {
				return false; // Extension key does not exist
			}

			var currentProgId = extKey.GetValue("") as string;
			return string.Equals(currentProgId, progId, StringComparison.OrdinalIgnoreCase);
		}
	}
}
