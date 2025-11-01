using System.Linq;
using DOSBoxLaunchX.Logic.Helpers;

namespace DOSBoxLaunchX.Logic.DosboxParsing;

/// <summary>
/// Represents a DOSBox mapper file.
/// </summary>
public class DosboxMapperFile {
	private readonly List<MapperLine> _lines;
	private readonly Dictionary<(string? section, string action), List<MapperMappingLine>> _mappingIndex = [];

	#region Constructors

	/// <summary>
	/// Private constructor to enforce use of static factories.
	/// </summary>
	private DosboxMapperFile() {
		_lines = [
			// An empty file is represented as a single blank line
			new MapperBlankLine(string.Empty),
		];
	}

	#endregion

	#region Creators

	/// <summary>
	/// Creates an empty DOSBox mapper file.
	/// </summary>
	public static DosboxMapperFile FromEmpty() {
		return new DosboxMapperFile();
	}

	/// <summary>
	/// Parses a DOSBox mapper file from its text.
	/// </summary>
	public static DosboxMapperFile FromText(string fileText)
		=> FromLines(NewlinesHelper.NormalizeNewlines(fileText, NewlinesHelper.NewlineStyle.Unix).Split('\n'));

	/// <summary>
	/// Parses a DOSBox mapper file from its lines.
	/// </summary>
	public static DosboxMapperFile FromLines(IEnumerable<string> fileLines) {
		var file = new DosboxMapperFile();
		file.loadFromLines(fileLines);
		return file;
	}

	#endregion

	/// <summary>
	/// All lines in the file, in original order.
	/// </summary>
	public IReadOnlyList<MapperLine> Lines => _lines.AsReadOnly();

	public IEnumerable<MapperMappingLine> GetMapping(string? section, string key) {
		// Returns multiple because one mapping can have dupes in the file
		if (section != null) {
			section = section.ToLowerInvariant();
		}
		key = key.ToLowerInvariant();

		if (_mappingIndex.TryGetValue((section, key), out var list)) {
			return list;
		}
		return [];
	}

	public void SetMapping(string section, string key, string value) {
		section = section.ToLowerInvariant().Trim();
		key = key.ToLowerInvariant().Trim();
		string newRaw = string.IsNullOrEmpty(value) ? key : $@"{key} ""{value}""";

		if (_mappingIndex.TryGetValue((section, key), out var existingList) && existingList.Count > 0) {
			// Replace all existing instances
			for (int i = 0; i < existingList.Count; i++) {
				var existing = existingList[i];
				int index = _lines.IndexOf(existing);

				var newLine = new MapperMappingLine(newRaw, key, value, section);

				_lines[index] = newLine;
				existingList[i] = newLine; // Update cache reference
			}
		}
		else {
			int insertIndex = _lines.FindLastIndex(
				l => l is MapperMappingLine s && s.Section == section
			);

			var newLine = new MapperMappingLine(newRaw, key, value, section);

			if (insertIndex >= 0) {
				_lines.Insert(insertIndex + 1, newLine);
			}
			else {
				// No section exists, insert a new section header first
				var header = new MapperSectionHeaderLine($"[{section}]", section);
				_lines.Add(header);
				_lines.Add(newLine);
			}

			// Add to index
			if (!_mappingIndex.TryGetValue((section, key), out var list)) {
				list = [];
				_mappingIndex[(section, key)] = list;
			}
			list.Add(newLine);
		}
	}

	public string ToText() {
		return string.Join("\n", _lines.Select(l => l.RawText));
	}

	private void rebuildMappingIndex() {
		_mappingIndex.Clear();
		foreach (var s in _lines.OfType<MapperMappingLine>()) {
			var keyTuple = (s.Section, s.Key);
			if (!_mappingIndex.TryGetValue(keyTuple, out var list)) {
				list = [];
				_mappingIndex[keyTuple] = list;
			}
			list.Add(s);
		}
	}

	#region Parser

	private void loadFromLines(IEnumerable<string> fileLines) {
		_lines.Clear();
		string? currentSection = null;

		foreach (string line in fileLines) {
			string trimmed = line.Trim();

			// Blank lines
			if (string.IsNullOrEmpty(trimmed)) {
				_lines.Add(new MapperBlankLine(line));
				continue;
			}

			// Section header
			if (trimmed.StartsWith('[')) {
				int endBracket = trimmed.IndexOf(']');
				if (endBracket > 0) {
					string sectionName = trimmed[1..endBracket].ToLowerInvariant();
					currentSection = sectionName;
					_lines.Add(new MapperSectionHeaderLine(line, sectionName));
				}
				else {
					_lines.Add(new MapperMalformedLine(line));
				}
				continue;
			}

			// Mapping (key "value") line
			int spaceIndex = trimmed.IndexOf(' ');
			if (spaceIndex >= 0) {
				string key = trimmed[..spaceIndex].Trim().ToLowerInvariant();
				string value = trimmed[(spaceIndex + 1)..].Trim();

				if (string.IsNullOrEmpty(value)) {
					_lines.Add(new MapperMappingLine(line, key, string.Empty, currentSection));
				}
				else if (value.StartsWith('"') && value.EndsWith('"')) {
					_lines.Add(new MapperMappingLine(line, key, value[1..^1], currentSection));
				}
				else {
					_lines.Add(new MapperMalformedLine(line));
				}
			}
			else {
				_lines.Add(new MapperMappingLine(line, trimmed, string.Empty, currentSection));
			}
		}

		if (_lines.Count == 0) {
			_lines.Add(new MapperBlankLine(string.Empty));
		}

		rebuildMappingIndex();
	}

	#endregion
}
