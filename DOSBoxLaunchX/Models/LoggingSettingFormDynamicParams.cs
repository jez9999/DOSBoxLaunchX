namespace DOSBoxLaunchX.Models;

public class LoggingSettingFormDynamicParams {
	public required Func<(string LoggingType, string Verbosity), string?> LoggingTypeVerbosityValidator { get; set; }
}
