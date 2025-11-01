namespace DOSBoxLaunchX {
	partial class OptionsForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
			lblBaseDosboxDir = new Label();
			txtBaseDosboxDir = new TextBox();
			btnBaseDosboxDirBrowse = new Button();
			btnApply = new Button();
			btnCancel = new Button();
			btnOk = new Button();
			folderBrowserDialog = new FolderBrowserDialog();
			cbCloseOnDosboxExit = new CheckBox();
			cbWriteConfToBaseDir = new CheckBox();
			lblWriteConfToBaseDirHelp = new Label();
			SuspendLayout();
			// 
			// lblBaseDosboxDir
			// 
			lblBaseDosboxDir.AutoSize = true;
			lblBaseDosboxDir.Location = new Point(12, 9);
			lblBaseDosboxDir.Name = "lblBaseDosboxDir";
			lblBaseDosboxDir.Size = new Size(131, 15);
			lblBaseDosboxDir.TabIndex = 0;
			lblBaseDosboxDir.Text = "Base DOSBox Directory:";
			// 
			// txtBaseDosboxDir
			// 
			txtBaseDosboxDir.Location = new Point(12, 27);
			txtBaseDosboxDir.Name = "txtBaseDosboxDir";
			txtBaseDosboxDir.Size = new Size(504, 23);
			txtBaseDosboxDir.TabIndex = 10;
			txtBaseDosboxDir.Validated += txtBaseDosboxDir_Validated;
			// 
			// btnBaseDosboxDirBrowse
			// 
			btnBaseDosboxDirBrowse.Location = new Point(522, 27);
			btnBaseDosboxDirBrowse.Name = "btnBaseDosboxDirBrowse";
			btnBaseDosboxDirBrowse.Size = new Size(75, 23);
			btnBaseDosboxDirBrowse.TabIndex = 11;
			btnBaseDosboxDirBrowse.Text = "&Browse...";
			btnBaseDosboxDirBrowse.UseVisualStyleBackColor = true;
			btnBaseDosboxDirBrowse.Click += btnBaseDosboxDirBrowse_Click;
			// 
			// btnApply
			// 
			btnApply.Enabled = false;
			btnApply.Location = new Point(522, 358);
			btnApply.Name = "btnApply";
			btnApply.Size = new Size(75, 23);
			btnApply.TabIndex = 102;
			btnApply.Text = "Apply";
			btnApply.UseVisualStyleBackColor = true;
			btnApply.Click += btnApply_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(441, 358);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 101;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			btnCancel.Click += btnCancel_Click;
			// 
			// btnOk
			// 
			btnOk.Location = new Point(360, 358);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(75, 23);
			btnOk.TabIndex = 100;
			btnOk.Text = "OK";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += btnOk_Click;
			// 
			// folderBrowserDialog
			// 
			folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
			// 
			// cbCloseOnDosboxExit
			// 
			cbCloseOnDosboxExit.AutoSize = true;
			cbCloseOnDosboxExit.Location = new Point(12, 56);
			cbCloseOnDosboxExit.Name = "cbCloseOnDosboxExit";
			cbCloseOnDosboxExit.Size = new Size(264, 19);
			cbCloseOnDosboxExit.TabIndex = 20;
			cbCloseOnDosboxExit.Text = "Close launcher automatically on &DOSBox exit";
			cbCloseOnDosboxExit.UseVisualStyleBackColor = true;
			cbCloseOnDosboxExit.CheckedChanged += cbCloseOnDosboxExit_CheckedChanged;
			// 
			// cbWriteConfToBaseDir
			// 
			cbWriteConfToBaseDir.AutoSize = true;
			cbWriteConfToBaseDir.Location = new Point(12, 81);
			cbWriteConfToBaseDir.Name = "cbWriteConfToBaseDir";
			cbWriteConfToBaseDir.Size = new Size(286, 19);
			cbWriteConfToBaseDir.TabIndex = 30;
			cbWriteConfToBaseDir.Text = "&Write temp. config files to base DOSBox directory";
			cbWriteConfToBaseDir.UseVisualStyleBackColor = true;
			cbWriteConfToBaseDir.CheckedChanged += cbWriteConfToBaseDir_CheckedChanged;
			// 
			// lblWriteConfToBaseDirHelp
			// 
			lblWriteConfToBaseDirHelp.AutoSize = true;
			lblWriteConfToBaseDirHelp.Cursor = Cursors.Help;
			lblWriteConfToBaseDirHelp.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
			lblWriteConfToBaseDirHelp.Location = new Point(293, 81);
			lblWriteConfToBaseDirHelp.Name = "lblWriteConfToBaseDirHelp";
			lblWriteConfToBaseDirHelp.Size = new Size(12, 15);
			lblWriteConfToBaseDirHelp.TabIndex = 104;
			lblWriteConfToBaseDirHelp.Text = "?";
			lblWriteConfToBaseDirHelp.Click += lblWriteConfToBaseDirHelp_Click;
			// 
			// OptionsForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(609, 393);
			Controls.Add(lblWriteConfToBaseDirHelp);
			Controls.Add(cbWriteConfToBaseDir);
			Controls.Add(cbCloseOnDosboxExit);
			Controls.Add(btnOk);
			Controls.Add(btnCancel);
			Controls.Add(btnApply);
			Controls.Add(btnBaseDosboxDirBrowse);
			Controls.Add(txtBaseDosboxDir);
			Controls.Add(lblBaseDosboxDir);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "OptionsForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "DOSBoxLaunchX - Options";
			Load += OptionsForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblBaseDosboxDir;
		private TextBox txtBaseDosboxDir;
		private Button btnBaseDosboxDirBrowse;
		private Button btnApply;
		private Button btnCancel;
		private Button btnOk;
		private FolderBrowserDialog folderBrowserDialog;
		private CheckBox cbCloseOnDosboxExit;
		private CheckBox cbWriteConfToBaseDir;
		private Label lblWriteConfToBaseDirHelp;
	}
}