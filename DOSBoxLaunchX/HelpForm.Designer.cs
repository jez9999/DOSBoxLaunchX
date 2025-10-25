namespace DOSBoxLaunchX {
	partial class HelpForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
			txtHelp = new TextBox();
			btnOk = new Button();
			SuspendLayout();
			// 
			// txtHelp
			// 
			txtHelp.BackColor = SystemColors.Window;
			txtHelp.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			txtHelp.Location = new Point(12, 12);
			txtHelp.Multiline = true;
			txtHelp.Name = "txtHelp";
			txtHelp.ReadOnly = true;
			txtHelp.Size = new Size(776, 408);
			txtHelp.TabIndex = 0;
			txtHelp.TabStop = false;
			// 
			// btnOk
			// 
			btnOk.Location = new Point(354, 429);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(95, 23);
			btnOk.TabIndex = 1;
			btnOk.Text = "OK";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += btnOk_Click;
			// 
			// HelpForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 461);
			Controls.Add(btnOk);
			Controls.Add(txtHelp);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "HelpForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "DOSBoxLaunchX - Help";
			Load += HelpForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtHelp;
		private Button btnOk;
	}
}