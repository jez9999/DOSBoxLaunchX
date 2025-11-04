using System.Linq;
using DOSBoxLaunchX.Logic.DosboxParsing;
using DOSBoxLaunchX.Logic.Models;

namespace DOSBoxLaunchX.Logic.Helpers;

public static class DosboxConfigMergeHelper {
	public static void MergeMappings(DosboxMapperFile map, LaunchSettings sett, Action<string> fnWarn) {
		var mappings = map.GetAllMappings().ToDictionary(m => (m.Section, m.Key));

		foreach (var entry in sett.KeyboardMappings) {
			if (mappings.ContainsKey((entry.Section, entry.Key))) {
				// Override base mapping
				map.SetMapping(entry.Section, entry.Key, entry.Mapping);
			}
			else {
				// Mapping not in base file - warn
				fnWarn.Invoke($"WARNING: section/key '{entry.Section}/{entry.Key}' for keyboard mapping does not exist in base mapper file.");
			}
		}
	}

	public static void MergeSettings(DosboxConfFile config, LaunchSettings sett, Action<string> fnWarn) {
		var settFlat = sett.Settings;

		// Merge settings
		foreach (var (sectionKey, val) in settFlat) {
			var parts = sectionKey.Split('.', 2);

			var section = parts[0];
			var key = parts.Length > 1 ? parts[1] : "";
			var value = val?.ToString() ?? "";
			if (section == "autoexec") { continue; }

			if (!config.SetSetting(section, key, value)) {
				fnWarn.Invoke($"WARNING: section/key '{section ?? "[null]"}/{key}' for setting does not exist in base config file.");
			}
		}
	}

	public static void MergeAutoexecMain(DosboxConfFile config, LaunchSettings sett) {
		var settFlatCustom = sett.GetCustomSettings();
		var mainAutoexec = GetAutoexecLinesFromCustomSettings(settFlatCustom);
		config.AddAutoexecCommands(mainAutoexec);
	}

	public static void MergeAutoexecPrePost(DosboxConfFile config, LaunchSettings sett, bool mergingGlobals = false) {
		// Merge generated and user-custom autoexec
		(var preAutoexec, var postAutoexec) = GeneratePrePostAutoexec(
			sett.BaseDir,
			sett.LimitBaseDirFreeSpace,
			sett.Executable,
			mergingGlobals
		);
		config.AddAutoexecCommands(preAutoexec, insertAtEnd: false);
		config.AddAutoexecCommands(postAutoexec);
	}

	public static (List<string> PreAutoexec, List<string> PostAutoexec) GeneratePrePostAutoexec(string? baseDir, int? limitBaseDirFreeSpace, string? executable, bool? generateForGlobals = null) {
		generateForGlobals ??= false;
		List<string> preAutoexec = [];
		List<string> postAutoexec = [];

		if (generateForGlobals.Value) {
			preAutoexec.Add("@REM [Autoexec Script Start]");
			postAutoexec.Add("@REM [Autoexec Script End]");
		}
		else {
			if (baseDir != null) {
				string mountDir = baseDir;
				if (string.IsNullOrWhiteSpace(baseDir)) {
					mountDir = "???";
				}
				preAutoexec.AddRange([
					$"MOUNT C {mountDir}{(limitBaseDirFreeSpace == null ? "" : $" -freesize {limitBaseDirFreeSpace}")}",
					string.IsNullOrWhiteSpace(baseDir) ? "" : "C:",
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
