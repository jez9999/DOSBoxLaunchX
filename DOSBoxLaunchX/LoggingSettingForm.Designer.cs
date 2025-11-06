namespace DOSBoxLaunchX {
	partial class LoggingSettingForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoggingSettingForm));
			lblLoggingType = new Label();
			comboLoggingType = new ComboBox();
			comboVerbosity = new ComboBox();
			label1 = new Label();
			btnAdd = new Button();
			SuspendLayout();
			// 
			// lblLoggingType
			// 
			lblLoggingType.AutoSize = true;
			lblLoggingType.Location = new Point(12, 15);
			lblLoggingType.Name = "lblLoggingType";
			lblLoggingType.Size = new Size(80, 15);
			lblLoggingType.TabIndex = 0;
			lblLoggingType.Text = "Logging type:";
			// 
			// comboLoggingType
			// 
			comboLoggingType.FormattingEnabled = true;
			comboLoggingType.Items.AddRange(new object[] { "vga", "vgagfx", "vgamisc", "int10", "sblaster", "dma_control", "fpu", "cpu", "paging", "fcb", "files", "ioctl", "exec", "dosmisc", "pit", "keyboard", "pic", "mouse", "bios", "gui", "misc", "io", "pci", "sst" });
			comboLoggingType.Location = new Point(98, 12);
			comboLoggingType.Name = "comboLoggingType";
			comboLoggingType.Size = new Size(121, 23);
			comboLoggingType.TabIndex = 1;
			// 
			// comboVerbosity
			// 
			comboVerbosity.FormattingEnabled = true;
			comboVerbosity.Items.AddRange(new object[] { "debug", "normal", "warn", "error", "fatal", "never", "true", "false" });
			comboVerbosity.Location = new Point(305, 12);
			comboVerbosity.Name = "comboVerbosity";
			comboVerbosity.Size = new Size(121, 23);
			comboVerbosity.TabIndex = 2;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(241, 15);
			label1.Name = "label1";
			label1.Size = new Size(58, 15);
			label1.TabIndex = 2;
			label1.Text = "Verbosity:";
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(451, 12);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(75, 23);
			btnAdd.TabIndex = 3;
			btnAdd.Text = "Add";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// LoggingSettingForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(541, 47);
			Controls.Add(btnAdd);
			Controls.Add(comboVerbosity);
			Controls.Add(label1);
			Controls.Add(comboLoggingType);
			Controls.Add(lblLoggingType);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "LoggingSettingForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "DOSBoxLaunchX - Custom Logging Setting";
			Load += LoggingSettingForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblLoggingType;
		private ComboBox comboLoggingType;
		private ComboBox comboVerbosity;
		private Label label1;
		private Button btnAdd;
	}
}