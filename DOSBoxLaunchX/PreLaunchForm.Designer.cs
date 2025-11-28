namespace DOSBoxLaunchX {
	partial class PreLaunchForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreLaunchForm));
			btnLaunchNow = new Button();
			lblShortcutTitle = new Label();
			btnEditShortcut = new Button();
			txtDescription = new TextBox();
			SuspendLayout();
			// 
			// btnLaunchNow
			// 
			btnLaunchNow.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			btnLaunchNow.Location = new Point(12, 72);
			btnLaunchNow.Name = "btnLaunchNow";
			btnLaunchNow.Size = new Size(304, 91);
			btnLaunchNow.TabIndex = 10;
			btnLaunchNow.Text = "&Launch now!";
			btnLaunchNow.UseVisualStyleBackColor = true;
			btnLaunchNow.Click += btnLaunchNow_Click;
			// 
			// lblShortcutTitle
			// 
			lblShortcutTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblShortcutTitle.Location = new Point(12, 3);
			lblShortcutTitle.Name = "lblShortcutTitle";
			lblShortcutTitle.Size = new Size(304, 60);
			lblShortcutTitle.TabIndex = 1;
			lblShortcutTitle.Text = "[Shortcut title]";
			lblShortcutTitle.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// btnEditShortcut
			// 
			btnEditShortcut.Location = new Point(12, 169);
			btnEditShortcut.Name = "btnEditShortcut";
			btnEditShortcut.Size = new Size(304, 23);
			btnEditShortcut.TabIndex = 20;
			btnEditShortcut.Text = "&Edit shortcut";
			btnEditShortcut.UseVisualStyleBackColor = true;
			btnEditShortcut.Click += btnEditShortcut_Click;
			// 
			// txtDescription
			// 
			txtDescription.BackColor = SystemColors.Info;
			txtDescription.Location = new Point(12, 72);
			txtDescription.Multiline = true;
			txtDescription.Name = "txtDescription";
			txtDescription.ReadOnly = true;
			txtDescription.ScrollBars = ScrollBars.Vertical;
			txtDescription.Size = new Size(100, 23);
			txtDescription.TabIndex = 30;
			txtDescription.Visible = false;
			// 
			// PreLaunchForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(328, 201);
			Controls.Add(txtDescription);
			Controls.Add(btnEditShortcut);
			Controls.Add(lblShortcutTitle);
			Controls.Add(btnLaunchNow);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "PreLaunchForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "DOSBoxLaunchX";
			Load += PreLaunchForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnLaunchNow;
		private Label lblShortcutTitle;
		private Button btnEditShortcut;
		private TextBox txtDescription;
	}
}