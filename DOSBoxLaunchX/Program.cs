using DOSBoxLaunchX.Factories;
using DOSBoxLaunchX.Helpers;
using DOSBoxLaunchX.Models;
using DOSBoxLaunchX.Logic.Services;
using DOSBoxLaunchX.Logic.Extensions;

namespace DOSBoxLaunchX;

internal static class Program {
	private const string _programName = "DOSBoxLaunchX";
	private const string _errorLogfile = "_errorlog_.txt";

	// TODO: If Linux support is ever needed, refactor this app's Form logic into an MVVM pattern for Uno.

	// ====================================================
	// TODO: Always normalize all config files line endings to Unix newlines (LF)
	// ====================================================

	[STAThread]
	private static void Main(string[] args) {
		try {
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			var appHost = createHost(Directory.GetCurrentDirectory(), Application.ExecutablePath, args);

			Application.ThreadException += (sender, ea) => handleExceptionAndExit(ea.Exception);
			AppDomain.CurrentDomain.UnhandledException += (sender, ea) => {
				handleExceptionAndExit(ea.ExceptionObject as Exception);
			};
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

			MainForm? mainForm = null;
			LauncherForm? launcherForm = null;
			try {
				if (args.Length > 0) {
					Application.Run(launcherForm =
						appHost
							.Services
							.GetRequiredService<FormFactory>()
							.CreateLauncherForm()
					);
				}
				else {
					Application.Run(mainForm =
						appHost
							.Services
							.GetRequiredService<FormFactory>()
							.CreateMainForm()
					);
				}
			}
			finally {
				appHost.Dispose();
				launcherForm?.Dispose();
				mainForm?.Dispose();
			}
		}
		catch (Exception ex) {
			handleExceptionAndExit(ex);
		}
	}

	private static void handleExceptionAndExit(Exception? ex) {
		if (ex == null) {
			return;
		}

		try {
			File.WriteAllText(_errorLogfile, $"- FATAL ERROR in {_programName}:{ex.GetFormattedExceptionMessages()}");
			MessageBoxHelper.ShowErrorMessageOk($"FATAL ERROR in {_programName} (please see '{_errorLogfile}' for detailed info): {ex.Message}", "Fatal error");
		}
		catch {
			// Last resort: silent fail to avoid recursion
		}
		finally {
			// Force termination
			Environment.Exit(1);
		}
	}

	private static IHost createHost(string cwd, string appExePath, string[] args) {
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
#if DEBUG
					IsDebugBuild = true,
#else
					IsDebugBuild = false,
#endif
					EnvironmentName = hostContext.HostingEnvironment.EnvironmentName,
					CurrentWorkingDirectory = cwd,
					ProgramName = _programName,
					AppExePath = appExePath,
					Args = args,
				});
				services.AddTransient<FormFactory>();
				services.AddTransient(x => Random.Shared);
				IJsonSerializerProvider jsonProvider = new JsonSerializerProvider();
				services.AddSingleton(svc => jsonProvider);

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
