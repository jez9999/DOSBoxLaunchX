using Newtonsoft.Json;

namespace DOSBoxLaunchX.Logic.Models;

public class LaunchSettings {
	#region General

	/// <summary>
	/// Optional user-friendly name. If null or whitespace, fallback to shortcut filename.
	/// When used for storing global settings, this field is ignored.
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// Optional description/notes for this shortcut.
	/// When used for storing global settings, this field is ignored.
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// Optional base directory to mount as C: at the start of autoexec.
	/// </summary>
	public string? BaseDir { get; set; }

	/// <summary>
	/// If BaseDir is set, determines whether it's mounted with "-freesize 1024" (limit free hard disk space
	/// to max. 1GiB).
	/// TODO: maybe this should be a long and determine the freesize MB value?  "LimitBaseDirFreeSpace"
	/// </summary>
	public bool? LimitBaseDirToOneGiB { get; set; }

	/// <summary>
	/// Optional executable to launch at the end of autoexec.
	/// </summary>
	public string? Executable { get; set; }

	#endregion

	#region Grouped settings (not serialized)

	[JsonIgnore]
	public CPUSettings CPU { get; set; } = new();

	#endregion

	#region Flat settings dictionary for serialization

	[JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
	public Dictionary<string, object> Settings {
		get => toFlatSettings();
		set => fromFlatSettings(value);
	}

	private Dictionary<string, object> toFlatSettings() {
		var dict = new Dictionary<string, object>();

		if (CPU.Cycles != null) { dict["cpu.cycles"] = CPU.Cycles; }

		return dict;
	}

	private void fromFlatSettings(Dictionary<string, object> flat) {
		foreach (var kvp in flat) {
			switch (kvp.Key) {
				case "cpu.cycles":
					CPU.Cycles = getValueOrThrow<string>(kvp.Value, kvp.Key);
					break;
			}
		}
	}

	private static T getValueOrThrow<T>(object value, string keyName) {
		if (value is T typedValue) {
			return typedValue;
		}
		throw new InvalidDataException(
			$"Expected a value of type {typeof(T).Name} for '{keyName}', but got {value?.GetType().Name ?? "[null]"}."
		);
	}

	#endregion

	#region Classes

	public class CPUSettings {
		public string? Cycles { get; set; }
	}

	#endregion
}
