namespace DOSBoxLaunchX.Logic.DosboxParsing;

/// <summary>
/// Base class for all lines in a DOSBox mapper file.
/// </summary>
public abstract class MapperLine {
	public string RawText { get; }

	protected MapperLine(string rawText) {
		RawText = rawText;
	}
}

/// <summary>
/// Base class for lines that are ignored by DOSBox (comments, malformed).
/// </summary>
public abstract class MapperIgnoredLine : MapperLine {
	protected MapperIgnoredLine(string rawText) : base(rawText) { }
}

/// <summary>
/// A blank line containing nothing or only whitespace.
/// </summary>
public class MapperBlankLine : MapperIgnoredLine {
	public MapperBlankLine(string rawText) : base(rawText) { }
}

/// <summary>
/// A malformed line such as one containing an invalid section header (eg., "[sectionname").
/// </summary>
public class MapperMalformedLine : MapperIgnoredLine {
	public MapperMalformedLine(string rawText) : base(rawText) { }
}

/// <summary>
/// A section header line, eg., "[SDL1]".
/// </summary>
public class MapperSectionHeaderLine : MapperLine {
	public string SectionName { get; }

	public MapperSectionHeaderLine(string rawText, string sectionName) : base(rawText) {
		SectionName = sectionName;
	}
}

/// <summary>
/// A mapping line (key "value") in the mapping section.
/// </summary>
public class MapperMappingLine : MapperLine {
	public string? Section { get; } // null if before first section
	public string Key { get; }
	public string Value { get; }

	public MapperMappingLine(string rawText, string key, string value, string? section = null) : base(rawText) {
		Key = key;
		Value = value;
		Section = section;
	}
}
