using System.Linq;
using DOSBoxLaunchX.Logic.DosboxParsing;
using DOSBoxLaunchX.Logic.Models;

namespace DOSBoxLaunchX.Logic.Helpers;

public static class DosboxConfigMergeHelper {
	public static void Merge(DosboxConfFile config, LaunchSettings sett) {
		var settFlat = sett.Settings;
		var settFlatCustom = sett.GetCustomSettings();

		// Merge generated and user-custom autoexec
		(var preAutoexec, var postAutoexec) = GeneratePrePostAutoexec(
			sett.BaseDir,
			sett.LimitBaseDirToOneGiB,
			sett.Executable
		);
		var mainAutoexec = GetAutoexecLinesFromCustomSettings(settFlatCustom);
		config.AddAutoexecCommands(preAutoexec, insertAtEnd: false);
		config.AddAutoexecCommands(mainAutoexec);
		config.AddAutoexecCommands(postAutoexec);

		// Merge settings
		foreach (var (sectionKey, val) in settFlat) {
			var parts = sectionKey.Split('.', 2);

			var section = parts[0];
			var key = parts.Length > 1 ? parts[1] : "";
			var value = val?.ToString() ?? "";
			if (section == "autoexec") { continue; }

			config.SetSetting(section, key, value);
		}
	}

	public static (List<string> PreAutoexec, List<string> PostAutoexec) GeneratePrePostAutoexec(string? baseDir, bool? limitBaseDirToOneGiB, string? executable, bool? generateForGlobals = null) {
		generateForGlobals ??= false;
		List<string> preAutoexec = [];
		List<string> postAutoexec = [];

		if (generateForGlobals.Value) {
			preAutoexec.Add("@REM [Global Autoexec Script]");
			postAutoexec.Add("@REM [Global Autoexec Script]");
		}
		else {
			if (baseDir != null) {
				preAutoexec.AddRange([
					$"MOUNT C {baseDir}{(limitBaseDirToOneGiB ?? false ? " -freesize 1024" : "")}",
					"C:",
				]);
			}
			else {
				preAutoexec.Add("@REM [No BaseDir set]");
			}

			if (executable != null) {
				postAutoexec.Add(executable);
			}
			else {
				postAutoexec.Add("@REM [No Executable set]");
			}
		}

		return (preAutoexec, postAutoexec);
	}

	public static List<string> GetAutoexecLinesFromCustomSettings(IReadOnlyDictionary<string, object> customSettings) {
		return [.. customSettings
			.Where(kvp => kvp.Key.StartsWith("autoexec."))
			.OrderBy(kvp => int.TryParse(kvp.Key["autoexec.".Length..], out var n) ? n : int.MaxValue)
			.Select(kvp => kvp.Value.ToString())];
	}
}
