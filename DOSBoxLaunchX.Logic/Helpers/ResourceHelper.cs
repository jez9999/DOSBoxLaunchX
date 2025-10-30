using System.Reflection;

namespace DOSBoxLaunchX.Logic.Helpers;

public static class ResourceHelper {
	/// <summary>
	/// Gets an embedded resource back from the given assembly as a stream.
	/// </summary>
	/// <param name="getFrom">
	/// The assembly from which to get the embedded resource. Often, you'll want Assembly.GetExecutingAssembly(),
	/// although you may also want this.GetType().Assembly which will give the assembly containing the current class.
	/// </param>
	/// <param name="defaultNamespace">
	/// The default namespace for the assembly. This is determined at compile-time by Visual Studio, and is
	/// specified in the project properties dialog.
	/// </param>
	/// <param name="resourceName">
	/// The name of the resource to retreive, in "Path.To.Filename.ext" format.  NOTE that the folder
	/// separator character is a dot, not a slash.
	/// </param>
	/// <returns>A stream containing the specified resource if found, or null otherwise.</returns>
	public static Stream GetEmbeddedResource(Assembly getFrom, string defaultNamespace, string resourceName) {
		var streamName = defaultNamespace + "." + resourceName;
		var foundStream = getFrom.GetManifestResourceStream(streamName);
		return foundStream ?? throw new Exception($"Couldn't find manifest resource stream: {streamName}");
	}

	/// <summary>
	/// Gets an embedded resource back from the given assembly as a string. Assumes UTF8 encoding for the resource.
	/// </summary>
	/// <param name="getFrom">
	/// The assembly from which to get the embedded resource. Often, you'll want Assembly.GetExecutingAssembly(),
	/// although you may also want this.GetType().Assembly which will give the assembly containing the current class.
	/// </param>
	/// <param name="defaultNamespace">
	/// The default namespace for the assembly. This is determined at compile-time by Visual Studio, and is
	/// specified in the project properties dialog.
	/// </param>
	/// <param name="resourceName">
	/// The name of the resource to retreive, in "Path.To.Filename.ext" format.  NOTE that the folder
	/// separator character is a dot, not a slash.
	/// </param>
	/// <returns>A stream containing the specified resource if found, or null otherwise.</returns>
	public static string GetEmbeddedResourceAsString(Assembly getFrom, string defaultNamespace, string resourceName) {
		using var stream = GetEmbeddedResource(getFrom, defaultNamespace, resourceName);
		using var rdr = new StreamReader(stream, Encoding.UTF8);
		return rdr.ReadToEnd();
	}
}
