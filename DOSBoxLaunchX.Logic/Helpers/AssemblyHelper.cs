using System.Reflection;

namespace DOSBoxLaunchX.Logic.Helpers;

/// <summary>
/// Used to specify the type of version string that should be generated.
/// </summary>
public enum VersionStringType {
	/// <summary>
	/// A full Assembly version string, including major, minor, build, and revision.
	/// </summary>
	FullString,
	MajorMinorBuild,
	MajorMinor,
	Major,
}

public class AssemblyHelper {
	/// <summary>
	/// Returns a string indicating the version of the Assembly supplied.
	/// </summary>
	/// <param name="getVersionFor">The Assembly to get the version string for.</param>
	/// <param name="versionStrType">The format of the version string to return.</param>
	/// <returns>The version string for the Assembly supplied.</returns>
	public static string GetVersionString(Assembly getVersionFor, VersionStringType versionStrType) {
		Version? ver = getVersionFor.GetName().Version;
		if (ver == null) {
			return "? Version unknown ?";
		}

		return versionStrType switch {
			VersionStringType.FullString => ver.Major.ToString() + "." + ver.Minor.ToString() + "." + ver.Build.ToString() + "." + ver.Revision.ToString(),
			VersionStringType.MajorMinorBuild => ver.Major.ToString() + "." + ver.Minor.ToString() + "." + ver.Build.ToString(),
			VersionStringType.MajorMinor => ver.Major.ToString() + "." + ver.Minor.ToString(),
			VersionStringType.Major => ver.Major.ToString(),
			_ => ("(no version type recognized!)"),
		};
	}
}
