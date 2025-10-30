namespace DOSBoxLaunchX.Logic.DosboxParsing;

/// <summary>
/// Base class for all lines in a DOSBox configuration file.
/// </summary>
public abstract class ConfigLine {
	public string RawText { get; }

	protected ConfigLine(string rawText) {
		RawText = rawText;
	}
}

/// <summary>
/// Base class for lines that are ignored by DOSBox (comments, malformed).
/// </summary>
public abstract class IgnoredLine : ConfigLine {
	protected IgnoredLine(string rawText) : base(rawText) { }
}

/// <summary>
/// A malformed line such as one containing an invalid section header (eg., "[sectionname").
/// </summary>
public class MalformedLine : IgnoredLine {
	public MalformedLine(string rawText) : base(rawText) { }
}

/// <summary>
/// A comment line, often with a leading '#'.
/// </summary>
public class CommentLine : IgnoredLine {
	public string Comment { get; }

	public CommentLine(string rawText, string comment) : base(rawText) {
		Comment = comment;
	}
}

/// <summary>
/// A section header line, eg., "[cpu]".
/// </summary>
public class SectionHeaderLine : ConfigLine {
	public string SectionName { get; }

	public SectionHeaderLine(string rawText, string sectionName) : base(rawText) {
		SectionName = sectionName;
	}
}

/// <summary>
/// A setting line (key=value) in a non-autoexec section.
/// </summary>
public class SettingLine : ConfigLine {
	public string? Section { get; } // null if before first section
	public string Key { get; }
	public string Value { get; }

	public SettingLine(string rawText, string key, string value, string? section = null) : base(rawText) {
		Key = key;
		Value = value;
		Section = section;
	}
}

/// <summary>
/// A line in the [autoexec] section.
/// </summary>
public class AutoexecLine : ConfigLine {
	public string Command { get; }

	public AutoexecLine(string rawText, string command) : base(rawText) {
		Command = command;
	}
}
