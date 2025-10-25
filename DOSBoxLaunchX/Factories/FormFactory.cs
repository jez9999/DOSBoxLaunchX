namespace DOSBoxLaunchX.Factories;

public class FormFactory(IServiceProvider sp) {
	private readonly IServiceProvider _sp = sp;

	// There are 3 basic ways of achieving DI when you need to have some params resolved by your service
	// provider, and some dynamically passed in:
	//
	// 1) Use ActivatorUtilities.CreateInstance<T>, eg.:
	// public ImageSelectForm CreateImageSelectForm(Size cropSize, Action<string> debugLogWriter) {
	//     return ActivatorUtilities.CreateInstance<ImageSelectForm>(_sp, cropSize, debugLogWriter);
	// }
	//
	// 2) Create with 'new', and pass all params separately, eg.:
	// public ImageSelectForm CreateImageSelectForm(Size cropSize, Action<string>? debugLogWriter = null) {
	//     return new ImageSelectForm(
	//         _sp.GetRequiredService<ValidatorHelper>(),
	//         cropSize,
	//         debugLogWriter
	//     );
	// }
	//
	// 3) Create with 'new' and pass SP-resolved params separately, but dynamic params all in one class, eg.:
	// public ImageSelectForm CreateImageSelectForm(ImageSelectFormDynamicParams dynamicParams) {
	//     return new ImageSelectForm(
	//         _sp.GetRequiredService<ValidatorHelper>(),
	//         dynamicParams
	//     );
	// }
	// ... and elsewhere:
	// public class ImageSelectFormDynamicParams {
	//     public required Size CropSize { get; set; }
	//     public Action<string>? DebugLogWriter { get; set; } = null;
	// }
	//
	// Is there a more "correct" way?  Not really.  Just different ways.  However, my preference is for
	// option 3), because of tidiness, explicitness, and easy extensibility (just add to the class holding
	// the dynamic params if you need to add more dynamic params).  It also allows dynamic params to be
	// easily nullable, whereas this is a problem when using ActivatorUtilities.CreateInstance<T>.  So,
	// just use option 3) when you need to inject some dynamic params in a DI-friendly way.

	public MainForm CreateMainForm() {
		// One little exception: when *every* param can be resolved via the service provider and there are
		// a lot of params, it may be more convenient/concise to use ActivatorUtilities.CreateInstance<T>.
		return ActivatorUtilities.CreateInstance<MainForm>(_sp);
	}

	public HelpForm CreateHelpForm() {
		return new HelpForm();
	}
}
