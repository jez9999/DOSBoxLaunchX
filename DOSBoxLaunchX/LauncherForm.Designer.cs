namespace DOSBoxLaunchX {
	partial class LauncherForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
			lblLaunching = new Label();
			txtOutput = new RichTextBox();
			SuspendLayout();
			// 
			// lblLaunching
			// 
			lblLaunching.AutoSize = true;
			lblLaunching.Location = new Point(12, 9);
			lblLaunching.Name = "lblLaunching";
			lblLaunching.Size = new Size(92, 15);
			lblLaunching.TabIndex = 1;
			lblLaunching.Text = "Shortcut file: ???";
			// 
			// txtOutput
			// 
			txtOutput.Enabled = false;
			txtOutput.Font = new Font("Courier New", 9.75F);
			txtOutput.Location = new Point(12, 27);
			txtOutput.Name = "txtOutput";
			txtOutput.ReadOnly = true;
			txtOutput.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
			txtOutput.Size = new Size(1261, 415);
			txtOutput.TabIndex = 2;
			txtOutput.Text = "";
			txtOutput.WordWrap = false;
			// 
			// LauncherForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1285, 454);
			Controls.Add(txtOutput);
			Controls.Add(lblLaunching);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "LauncherForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "DOSBoxLaunchX";
			Load += LauncherForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label lblLaunching;
		private RichTextBox txtOutput;
	}
}