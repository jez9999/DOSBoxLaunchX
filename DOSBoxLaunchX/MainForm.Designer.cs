namespace DOSBoxLaunchX
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			txtOutput = new TextBox();
			SuspendLayout();
			// 
			// txtOutput
			// 
			txtOutput.BackColor = SystemColors.Window;
			txtOutput.Font = new Font("Lucida Console", 9.75F);
			txtOutput.Location = new Point(12, 692);
			txtOutput.Multiline = true;
			txtOutput.Name = "txtOutput";
			txtOutput.ReadOnly = true;
			txtOutput.ScrollBars = ScrollBars.Vertical;
			txtOutput.Size = new Size(1235, 163);
			txtOutput.TabIndex = 0;
			txtOutput.TabStop = false;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1259, 867);
			Controls.Add(txtOutput);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MainForm";
			Text = "DOSBoxLaunchX";
			Load += MainForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtOutput;
	}
}
