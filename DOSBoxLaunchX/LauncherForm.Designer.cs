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
			lblLaunchShortcut = new Label();
			txtOutput = new RichTextBox();
			txtLaunchShortcut = new TextBox();
			SuspendLayout();
			// 
			// lblLaunchShortcut
			// 
			lblLaunchShortcut.AutoSize = true;
			lblLaunchShortcut.Location = new Point(12, 12);
			lblLaunchShortcut.Name = "lblLaunchShortcut";
			lblLaunchShortcut.Size = new Size(74, 15);
			lblLaunchShortcut.TabIndex = 1;
			lblLaunchShortcut.Text = "Shortcut file:";
			// 
			// txtOutput
			// 
			txtOutput.Enabled = false;
			txtOutput.Font = new Font("Courier New", 9.75F);
			txtOutput.Location = new Point(12, 40);
			txtOutput.Name = "txtOutput";
			txtOutput.ReadOnly = true;
			txtOutput.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
			txtOutput.Size = new Size(1235, 402);
			txtOutput.TabIndex = 2;
			txtOutput.Text = "";
			txtOutput.WordWrap = false;
			// 
			// txtLaunchShortcut
			// 
			txtLaunchShortcut.BackColor = Color.WhiteSmoke;
			txtLaunchShortcut.Location = new Point(92, 9);
			txtLaunchShortcut.Name = "txtLaunchShortcut";
			txtLaunchShortcut.ReadOnly = true;
			txtLaunchShortcut.Size = new Size(1155, 23);
			txtLaunchShortcut.TabIndex = 11;
			// 
			// LauncherForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1259, 454);
			Controls.Add(txtLaunchShortcut);
			Controls.Add(txtOutput);
			Controls.Add(lblLaunchShortcut);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "LauncherForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "DOSBoxLaunchX";
			Load += LauncherForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label lblLaunchShortcut;
		private RichTextBox txtOutput;
		private TextBox txtLaunchShortcut;
	}
}