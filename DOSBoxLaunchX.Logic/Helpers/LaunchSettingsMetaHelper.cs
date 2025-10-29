using System.Reflection;
using DOSBoxLaunchX.Logic.Models;

namespace DOSBoxLaunchX.Logic.Helpers;

public static class LaunchSettingsMetaHelper {
	public static void AddGroupedSettingsToDict(Dictionary<string, object> dict, object obj) {
		foreach (var prop in obj.GetType().GetProperties()) {
			if (!prop.CanRead || prop.GetIndexParameters().Length > 0 || prop.Name == nameof(LaunchSettings.Settings)) {
				continue; // Skip write-only or indexed properties
			}

			var attr = prop.GetCustomAttribute<GroupedSettingAttribute>();
			var val = prop.GetValue(obj);

			if (attr != null) {
				if (val != null) {
					dict[$"{attr.Section}.{attr.Key}"] = val;
				}
			}
			else {
				if (val != null && !prop.PropertyType.IsPrimitive && prop.PropertyType != typeof(string)) {
					AddGroupedSettingsToDict(dict, val);
				}
			}
		}
	}

	public static void AddGroupedPropertiesToMap(Dictionary<string, (PropertyInfo, object)> map, object obj) {
		foreach (var prop in obj.GetType().GetProperties()) {
			if (!prop.CanRead || prop.GetIndexParameters().Length > 0 || prop.Name == nameof(LaunchSettings.Settings)) {
				continue; // Skip write-only or indexed properties
			}

			var attr = prop.GetCustomAttribute<GroupedSettingAttribute>();
			var val = prop.GetValue(obj);

			if (attr != null) {
				map[$"{attr.Section}.{attr.Key}"] = (prop, obj);
			}
			else if (val != null && !prop.PropertyType.IsPrimitive && prop.PropertyType != typeof(string)) {
				AddGroupedPropertiesToMap(map, val);
			}
		}
	}
}
