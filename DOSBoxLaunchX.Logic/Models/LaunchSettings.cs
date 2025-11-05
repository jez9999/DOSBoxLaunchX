using System.Reflection;
using Newtonsoft.Json;
using DOSBoxLaunchX.Logic.Services;
using DOSBoxLaunchX.Logic.Helpers;

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
	/// When used for storing global settings, this field is ignored.
	/// </summary>
	public string? BaseDir { get; set; }

	/// <summary>
	/// If BaseDir is set, determines whether it's mounted with "-freesize [XXX]" (limit free hard disk space
	/// to max. [XXX] MiB).
	/// When used for storing global settings, this field is ignored.
	/// </summary>
	public int? LimitBaseDirFreeSpace { get; set; }

	/// <summary>
	/// Optional executable to launch at the end of autoexec.
	/// When used for storing global settings, this field is ignored.
	/// </summary>
	public string? Executable { get; set; }

	#endregion

	#region Grouped settings (not serialized)

	[JsonIgnore]
	public CPUSettings CPU { get; set; } = new();

	[JsonIgnore]
	public VideoSettings Video { get; set; } = new();

	[JsonIgnore]
	public AudioSettings Audio { get; set; } = new();

	[JsonIgnore]
	public PeripheralsSettings Peripherals { get; set; } = new();

	#endregion

	#region Keyboard mappings

	/// <summary>
	/// Optional keyboard mapping overrides.
	/// These entries represent replacement mappings to be merged into the base mapper file at launch.
	/// </summary>
	public List<KeyboardMapping> KeyboardMappings { get; set; } = [];

	#endregion

	#region Custom settings

	[JsonIgnore]
	private readonly Dictionary<string, object> _customSettings = [];

	public T? GetCustomSetting<T>(string key) {
		if (_customSettings.TryGetValue(key, out var val)) {
			return getValueOrThrow<T>(val, key);
		}
		return default;
	}

	public void SetCustomSetting<T>(string key, T value) where T : notnull {
		if (value is null) {
			throw new ArgumentNullException(nameof(value), $"Cannot set custom setting '{key}' to null.");
		}
		_customSettings[key] = value;
	}

	public void DeleteCustomSetting(string key) {
		_customSettings.Remove(key);
	}

	public IReadOnlyDictionary<string, object> GetCustomSettings() {
		return _customSettings.AsReadOnly();
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

	#region Flat settings dictionary for serialization

	/// <summary>
	/// Flat dictionary of all settings, generated dynamically from the strongly-typed properties and
	/// custom settings.
	///
	/// IMPORTANT: This property is intended for serialization/deserialization.  Do not modify it
	/// directly in your code, and don't *frequently* access the getter as generating the Settings
	/// dictionary each time is a heavyweight operation.
	///
	/// To set values, use the strongly-typed properties or use the get/set CustomSetting methods.
	/// </summary>
	[JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
	[JsonConverter(typeof(InterfaceToConcreteConverter<IReadOnlyDictionary<string, object>, Dictionary<string, object>>))]
	public IReadOnlyDictionary<string, object> Settings {
		get => toFlatSettings();
		private set => fromFlatSettings(value); // Private setter only for deserialization
	}

	private IReadOnlyDictionary<string, object> toFlatSettings() {
		var dict = new Dictionary<string, object>();

		LaunchSettingsMetaHelper.AddGroupedSettingsToDict(dict, this);

		foreach (var kvp in _customSettings) {
			dict[kvp.Key] = kvp.Value;
		}

		return dict.AsReadOnly();
	}

	private void fromFlatSettings(IReadOnlyDictionary<string, object> flat) {
		var groupedMap = new Dictionary<string, (PropertyInfo prop, object instance)>();
		LaunchSettingsMetaHelper.AddGroupedPropertiesToMap(groupedMap, this);

		foreach (var kvp in flat) {
			if (groupedMap.TryGetValue(kvp.Key, out var tuple)) {
				var (prop, instance) = tuple;

				if (!prop.PropertyType.IsAssignableFrom(kvp.Value.GetType())) {
					throw new InvalidDataException(
						$"Expected a value of type {prop.PropertyType.Name} for '{kvp.Key}', but got {kvp.Value.GetType().Name}."
					);
				}

				prop.SetValue(instance, kvp.Value);
			}
			else {
				_customSettings[kvp.Key] = kvp.Value;
			}
		}
	}

	#endregion

	#region Classes

	public class CPUSettings {
		[GroupedSetting("cpu", "core")]
		public string? Core { get; set; }

		[GroupedSetting("cpu", "cycles")]
		public string? Cycles { get; set; }

		[GroupedSetting("cpu", "cycleup")]
		public string? CycleUp { get; set; }

		[GroupedSetting("cpu", "cycledown")]
		public string? CycleDown { get; set; }

		[GroupedSetting("dosbox", "machine")]
		public string? Machine { get; set; }

		[GroupedSetting("dosbox", "memsize")]
		public string? MemSize { get; set; }
	}

	public class VideoSettings {
		[GroupedSetting("render", "frameskip")]
		public string? Frameskip { get; set; }

		[GroupedSetting("sdl", "output")]
		public string? Output { get; set; }

		[GroupedSetting("render", "scaler")]
		public string? Scaler { get; set; }

		[GroupedSetting("render", "doublescan")]
		public string? Doublescan { get; set; }

		[GroupedSetting("video", "forcerate")]
		public string? RefreshRate { get; set; }
	}

	public class AudioSettings {
		[GroupedSetting("mixer", "nosound")]
		public string? Silenced { get; set; }

		[GroupedSetting("mixer", "rate")]
		public string? SampleRate { get; set; }

		[GroupedSetting("midi", "mpu401")]
		public string? Mpu401Type { get; set; }

		[GroupedSetting("midi", "mididevice")]
		public string? MidiDevice { get; set; }

		[GroupedSetting("midi", "mt32.romdir")]
		public string? Mt32RomDir { get; set; }

		[GroupedSetting("midi", "mt32.model")]
		public string? Mt32Model { get; set; }

		[GroupedSetting("sblaster", "sbtype")]
		public string? SbType { get; set; }

		[GroupedSetting("sblaster", "sbbase")]
		public string? SbBase { get; set; }

		[GroupedSetting("sblaster", "irq")]
		public string? IRQ { get; set; }

		[GroupedSetting("sblaster", "dma")]
		public string? DMA { get; set; }

		[GroupedSetting("sblaster", "hdma")]
		public string? HighDMA { get; set; }

		[GroupedSetting("speaker", "pcspeaker")]
		public string? PcSpeaker { get; set; }

		[GroupedSetting("speaker", "tandy")]
		public string? TandySound { get; set; }
	}

	public class PeripheralsSettings {
		[GroupedSetting("sdl", "mouse_emulation")]
		public string? MouseEmulation { get; set; }

		[GroupedSetting("sdl", "middle_unlock")]
		public string? MouseMiddleUnlock { get; set; }

		[GroupedSetting("sdl", "sensitivity")]
		public string? MouseSensitivity { get; set; }

		[GroupedSetting("dos", "keyboardlayout")]
		public string? KbLayout { get; set; }
	}

	#endregion
}
