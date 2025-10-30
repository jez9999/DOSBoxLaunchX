using System.Reflection;
using DOSBoxLaunchX.Logic.Helpers;

namespace DOSBoxLaunchX.Tests.Helpers;

internal class TestHelpers {
	public static string GetAssetString(string filename) {
		return ResourceHelper.GetEmbeddedResourceAsString(
			Assembly.GetExecutingAssembly(),
			"DOSBoxLaunchX.Tests",
			$"Assets.{filename}"
		);
	}
}
