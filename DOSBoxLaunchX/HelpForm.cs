namespace DOSBoxLaunchX;

public partial class HelpForm : Form {
	#region Constructors

	public HelpForm() {
		InitializeComponent();
	}

	#endregion

#pragma warning disable IDE1006 // Naming Styles
	private void HelpForm_Load(object sender, EventArgs ea) {
		txtHelp.Text =
			"""
			DOSBoxLaunchX is a launcher for DOSBox-X that allows you to setup shortcut files that store sets of configuration modifications to make to the default DOSBox-X config. These shortcut files can then be opened from Explorer and DOSBox-X will be run with these configuration changes.

			What this allows is for different DOS games/apps to easily be run with a different configuration; a common requirement since no one configuration tends to work well with all different DOS games/apps. These config changes will be merged into an existing global set of config changes, so you can have some global changes that are always made by default (eg. mounting a directory as the C drive, a certain number of CPU cycles, etc.) and then a shortcut whose changes will be merged into this and override them if necessary (eg. different number of CPU cycles for this shortcut, a custom mouse sensitivity for this game, running the game's executable as part of autoexec, etc.)

			Because DOSBoxLaunchX allows you to store both sets of global and shortcut-specific config changes, there should be no need to change the default dosbox-x.conf file after installation. Simply point DOSBoxLaunchX to the DOSBox-X base dir (which should contain both dosbox-x.conf and dosbox-x.exe) and start setting up global config, and saving config shortcut files with DOSBoxLaunchX. When one of these shortcut files is opened, DOSBoxLaunchX will generate a temporary dosbox-x.conf file based on 1) the original dosbox-x.conf file it finds in the base dir, 2) the global config settings, and 3) the shortcut's config settings, all merged together. DOSBox-X will then be launched with this generated configuration.

			All of the DOSBoxLaunchX settings, global config, and temporary dosbox-x.conf files are stored in its app settings dir so nothing will be written to the DOSBox-X base dir.
			""";
	}
#pragma warning restore IDE1006 // Naming Styles

	private void btnOk_Click(object sender, EventArgs ea) {
		Close();
	}
}
