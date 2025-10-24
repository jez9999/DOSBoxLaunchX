using DOSBoxLaunchX.Extensions;
using DOSBoxLaunchX.Factories;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX;

internal static class Program {
	private const string _programName = "DOSBoxLaunchX";
	private const string _errorLogfile = "_errorlog_.txt";

	// TODO: Our file extension will be .dlx
	// TODO: If Linux support is needed, refactor this app's Form logic into an MVVM pattern for Uno.

	// ====================================================
	//Always convert config files line endings to newlines

	//local / global (radioboxes) | Associate app with .dlx files, Remove app's association with .dlx files
	// ^ Save / Load / New | ?
	//textbox for entering location of local shortcut whose settings we're editing


	//tabgroup settings



	//output info textbox
	// ====================================================

	[STAThread]
	private static void Main() {
		try {
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			var appHost = createHost(Directory.GetCurrentDirectory());
			MainForm? mainForm = null;
			try {
				Application.Run(mainForm =
					appHost
						.Services
						.GetRequiredService<FormFactory>()
						.CreateMainForm()
				);
			}
			finally {
				appHost.Dispose();
				mainForm?.Dispose();
			}
		}
		catch (Exception ex) {
			MessageBoxHelper.ShowErrorMessageOk($"FATAL ERROR running {_programName} (please see '{_errorLogfile}' for detailed info): {ex.Message}", "Fatal error");
			File.WriteAllText(_errorLogfile, $"- FATAL ERROR running {_programName}:{ex.GetFormattedExceptionMessages()}");
		}
	}

	private static IHost createHost(string cwd) {
		// NOTE: The key to getting appsettings.json to work along with appsettings.Development.json being
		// picked up and overriding settings in appsettings.json during development is to be using the
		// "Microsoft.NET.Sdk.Worker" project SDK instead of the "Microsoft.NET.Sdk" one at the top of the
		// startup project's .csproj file.  Although "Microsoft.NET.Sdk" is the default project SDK for
		// many project types, luckily it looks like you can just change that to "Microsoft.NET.Sdk.Worker"
		// and it doesn't cause problems, either for a bootstrap project or a Windows Forms project.  Note,
		// however, that "Microsoft.NET.Sdk.Worker" does need to have a static 'Main' method suitable for
		// an entry point, so it won't work for something like a class library.
		var builder = Host
			.CreateDefaultBuilder()

			.ConfigureServices((hostContext, services) => {
				// Setup DI / IoC container
				services.AddSingleton(new AppOptionsWithData {
					EnvironmentName = hostContext.HostingEnvironment.EnvironmentName,
					CurrentWorkingDirectory = cwd,
				});
				services.AddTransient<FormFactory>();
				services.AddTransient(x => Random.Shared);

				// NOTE: whenever you find yourself tempted to consume IServiceProvider via DI, consider whether
				// it might be a better idea to create a factory class for the service you're going to be
				// requesting from the service provider.  It's not always appropriate but it often is, whether
				// you have an explicit 'FooFactory' class or just register/consume via DI a lambda that functions
				// as a lightweight factory for what you need, eg.:
				//   services.AddTransient<IFoo, Foo>();
				//   services.AddTransient<Func<IFoo>>(sp => () => sp.GetRequiredService<IFoo>());
				// ... then to consume:
				//   public SomeClassConstructor(Func<IFoo> fooFact) { _fooFact = fooFact; }
				// ... then to get instance:
				//   var foo = _fooFact();
			});

		return builder.Build();
	}
}
