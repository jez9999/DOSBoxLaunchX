using System.Linq;
using DOSBoxLaunchX.Logic.Helpers;

namespace DOSBoxLaunchX.Logic.DosboxParsing;

/// <summary>
/// Represents a DOSBox configuration file.
/// </summary>
public class DosboxConfFile {
	private readonly List<ConfigLine> _lines;
	private readonly Dictionary<(string? section, string key), List<SettingLine>> _settingIndex = [];

	#region Constructors

	/// <summary>
	/// Private constructor to enforce use of static factories.
	/// </summary>
	private DosboxConfFile() {
		_lines = [
			// An empty file is represented as a single empty comment line
			new CommentLine(string.Empty, string.Empty),
		];
	}

	#endregion

	#region Creators

	/// <summary>
	/// Creates an empty DOSBox config file.
	/// </summary>
	public static DosboxConfFile FromEmpty() {
		return new DosboxConfFile();
	}

	/// <summary>
	/// Parses a DOSBox config file from its text.
	/// </summary>
	public static DosboxConfFile FromText(string fileText)
		=> FromLines(NewlinesHelper.NormalizeNewlines(fileText, NewlinesHelper.NewlineStyle.Unix).Split('\n'));

	/// <summary>
	/// Parses a DOSBox config file from its lines.
	/// </summary>
	public static DosboxConfFile FromLines(IEnumerable<string> fileLines) {
		var file = new DosboxConfFile();
		file.loadFromLines(fileLines);
		return file;
	}

	#endregion

	/// <summary>
	/// All lines in the file, in original order.
	/// </summary>
	public IReadOnlyList<ConfigLine> Lines => _lines.AsReadOnly();

	public IEnumerable<SettingLine> GetSetting(string? section, string key) {
		// Returns multiple because one setting can have dupes in the file
		if (section != null) {
			section = section.ToLowerInvariant();
		}
		key = key.ToLowerInvariant();

		if (_settingIndex.TryGetValue((section, key), out var list)) {
			return list;
		}
		return [];
	}

	public void SetSetting(string section, string key, string value) {
		section = section.ToLowerInvariant().Trim();
		key = key.ToLowerInvariant().Trim();
		string newRaw = $"{key}={value}";

		if (_settingIndex.TryGetValue((section, key), out var existingList) && existingList.Count > 0) {
			// Replace all existing instances
			for (int i = 0; i < existingList.Count; i++) {
				var existing = existingList[i];
				int index = _lines.IndexOf(existing);

				var newLine = new SettingLine(newRaw, key, value, section);

				_lines[index] = newLine;
				existingList[i] = newLine; // Update cache reference
			}
		}
		else {
			int insertIndex = _lines.FindLastIndex(
				l => l is SettingLine s && s.Section == section
			);

			var newLine = new SettingLine(newRaw, key, value, section);

			if (insertIndex >= 0) {
				_lines.Insert(insertIndex + 1, newLine);
			}
			else {
				// No section exists, insert a new section header first
				var header = new SectionHeaderLine($"[{section}]", section);
				_lines.Add(header);
				_lines.Add(newLine);
			}

			// Add to index
			if (!_settingIndex.TryGetValue((section, key), out var list)) {
				list = [];
				_settingIndex[(section, key)] = list;
			}
			list.Add(newLine);
		}
	}

	public void AddAutoexecCommand(string command, bool insertAtEnd = true) {
		AddAutoexecCommands([command], insertAtEnd);
	}

	public void AddAutoexecCommands(IEnumerable<string> commands, bool insertAtEnd = true) {
		var autoexecHeader = _lines.OfType<SectionHeaderLine>()
			.FirstOrDefault(h => h.SectionName == "autoexec");

		if (autoexecHeader == null) {
			autoexecHeader = new SectionHeaderLine("[autoexec]", "autoexec");
			_lines.Add(autoexecHeader);
		}

		int headerIndex = _lines.IndexOf(autoexecHeader);

		int insertIndex;
		if (insertAtEnd) {
			// Find the end of the autoexec section
			int endIndex = _lines.Count;
			for (int i = headerIndex + 1; i < _lines.Count; i++) {
				if (_lines[i] is SectionHeaderLine) {
					endIndex = i;
					break;
				}
			}
			insertIndex = endIndex - 1;
		}
		else {
			insertIndex = headerIndex;
		}

		foreach (var cmd in commands) {
			var line = new AutoexecLine(cmd, cmd);
			_lines.Insert(insertIndex++ + 1, line);
		}
	}

	public string ToText() {
		return string.Join("\n", _lines.Select(l => l.RawText));
	}

	private void rebuildSettingIndex() {
		_settingIndex.Clear();
		foreach (var s in _lines.OfType<SettingLine>()) {
			var keyTuple = (s.Section, s.Key);
			if (!_settingIndex.TryGetValue(keyTuple, out var list)) {
				list = [];
				_settingIndex[keyTuple] = list;
			}
			list.Add(s);
		}
	}

	#region Parser

	private void loadFromLines(IEnumerable<string> fileLines) {
		_lines.Clear();
		string? currentSection = null;
		bool isInAutoexec = false;

		foreach (string line in fileLines) {
			string trimmed = line.Trim();

			// Blank or comment lines
			if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith('#')) {
				string comment = trimmed.StartsWith('#') ? trimmed[1..] : string.Empty;
				_lines.Add(new CommentLine(line, comment));
				continue;
			}

			// Section header
			if (trimmed.StartsWith('[')) {
				int endBracket = trimmed.IndexOf(']');
				if (endBracket > 0) {
					string sectionName = trimmed[1..endBracket].ToLowerInvariant();
					currentSection = sectionName;
					isInAutoexec = sectionName == "autoexec";
					_lines.Add(new SectionHeaderLine(line, sectionName));
				}
				else {
					_lines.Add(new MalformedLine(line));
				}
				continue;
			}

			// Inside [autoexec] section
			if (isInAutoexec) {
				_lines.Add(new AutoexecLine(line, trimmed));
				continue;
			}

			// Setting (key=value) line
			int eqIndex = trimmed.IndexOf('=');
			if (eqIndex >= 0) {
				string key = trimmed[..eqIndex].Trim().ToLowerInvariant();
				string value = trimmed[(eqIndex + 1)..].Trim();
				_lines.Add(new SettingLine(line, key, value, currentSection));
			}
			else {
				_lines.Add(new SettingLine(line, trimmed, string.Empty, currentSection));
			}
		}

		if (_lines.Count == 0) {
			_lines.Add(new CommentLine(string.Empty, string.Empty));
		}

		rebuildSettingIndex();
	}

	#endregion
}
