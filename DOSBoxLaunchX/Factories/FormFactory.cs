using DOSBoxLaunchX.Logic.Services;
using DOSBoxLaunchX.Models;

namespace DOSBoxLaunchX.Factories;

public class FormFactory(IServiceProvider sp) {
	private readonly IServiceProvider _sp = sp;

	// To achieve DI when you need to have some params resolved by your service provider, but also some
	// dynamically passed in, you can either:
	//
	// 1) Create the instance with 'new', eg.:
	// public ImageSelectForm CreateImageSelectForm([...dynamic params...]) {
	//     return new ImageSelectForm(
	//         _sp.GetRequiredService<AppOptionsWithData>(),
	//         _sp.GetRequiredService<ValidatorService>(),
	//         [...dynamic params...]
	//     );
	// }
	//
	// or 2) Use ActivatorUtilities.CreateInstance<T>, eg.:
	// public ImageSelectForm CreateImageSelectForm([...dynamic params...]) {
	//     return ActivatorUtilities.CreateInstance<ImageSelectForm>(_sp, [...dynamic params...]);
	// }
	//
	// In each possibility, you can either pass in dynamic params individually, which causes issues when
	// using ActivatorUtilities.CreateInstance<T> (if there are multiple primitives like bools, ints, etc.
	// then which provided bools/ints/etc. map to which required bools/ints/etc.? Also how are null values
	// dealt with?), or you can wrap them all up in a class dedicated to holding the dynamic parameters
	// for the class you're instantiating, and just pass in an instance of that. This class should, of
	// course, not be registered with the DI container.
	//
	// My personal preference for how to do this is: ALWAYS wrap up all dynamic params into a class
	// dedicated to holding them (even if there's just 1 dynamic param, still use this pattern). That way,
	// you get the best of both worlds; you can use ActivatorUtilities.CreateInstance<T>, allowing non-
	// dynamic dependencies to be added without changing the factory method, and you can easily pass in a
	// set of dynamic params in a class which can be modified when you want to modify the dynamic params. So:
	//
	// public ImageSelectForm CreateImageSelectForm(ImageSelectFormDynamicParams dynamicParams) {
	//     return ActivatorUtilities.CreateInstance<ImageSelectForm>(_sp, dynamicParams);
	// }
	//
	// ... and elsewhere:
	// public class ImageSelectFormDynamicParams {
	//     public required Size CropSize { get; set; }
	//     public Action<string>? DebugLogWriter { get; set; } = null;
	// }
	//
	// Of course if you don't have any dynamic params at all, you can simply do:
	// public ImageSelectForm CreateImageSelectForm() {
	//     return ActivatorUtilities.CreateInstance<ImageSelectForm>(_sp);
	// }

	public MainForm CreateMainForm(MainFormDynamicParams dynamicParams) {
		return ActivatorUtilities.CreateInstance<MainForm>(_sp, dynamicParams);
	}

	public OptionsForm CreateOptionsForm() {
		return ActivatorUtilities.CreateInstance<OptionsForm>(_sp);
	}

	public HelpForm CreateHelpForm() {
		return ActivatorUtilities.CreateInstance<HelpForm>(_sp);
	}

	public AboutForm CreateAboutForm() {
		return ActivatorUtilities.CreateInstance<AboutForm>(_sp);
	}

	public PreLaunchForm CreatePreLaunchForm() {
		return ActivatorUtilities.CreateInstance<PreLaunchForm>(_sp);
	}

	public LauncherForm CreateLauncherForm(LauncherFormDynamicParams dynamicParams) {
		return ActivatorUtilities.CreateInstance<LauncherForm>(_sp, dynamicParams);
	}

	public LoggingSettingForm CreateLoggingSettingForm(LoggingSettingFormDynamicParams dynamicParams) {
		return ActivatorUtilities.CreateInstance<LoggingSettingForm>(_sp, dynamicParams);
	}
}
