namespace DOSBoxLaunchX.Logic.Models;

[AttributeUsage(AttributeTargets.Property)]
public class GroupedSettingAttribute : Attribute {
	public string Section { get; }
	public string Key { get; }

	public GroupedSettingAttribute(string section, string key) {
		Section = section;
		Key = key;
	}
}
