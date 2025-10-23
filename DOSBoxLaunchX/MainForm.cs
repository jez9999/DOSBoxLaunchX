namespace DOSBoxLaunchX {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs ea) {
			txtOutput.Text = "Hello world!";
		}
	}
}
