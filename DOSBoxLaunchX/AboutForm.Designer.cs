namespace DOSBoxLaunchX {
	partial class AboutForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			lblHeading = new Label();
			lblSubHeading = new Label();
			pbLogo = new PictureBox();
			txtVersion = new TextBox();
			lblVersionHeading = new Label();
			lblDateHeading = new Label();
			txtDate = new TextBox();
			btnOk = new Button();
			lnkDosboxXHomepage = new LinkLabel();
			lblDosboxXHeading = new Label();
			lnkDosboxXGithub = new LinkLabel();
			lnkDosboxXDevBuilds = new LinkLabel();
			((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
			SuspendLayout();
			// 
			// lblHeading
			// 
			lblHeading.AutoSize = true;
			lblHeading.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblHeading.Location = new Point(66, 2);
			lblHeading.Name = "lblHeading";
			lblHeading.Size = new Size(294, 47);
			lblHeading.TabIndex = 0;
			lblHeading.Text = "DOSBoxLaunchX";
			// 
			// lblSubHeading
			// 
			lblSubHeading.AutoSize = true;
			lblSubHeading.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
			lblSubHeading.Location = new Point(265, 46);
			lblSubHeading.Name = "lblSubHeading";
			lblSubHeading.Size = new Size(86, 21);
			lblSubHeading.TabIndex = 1;
			lblSubHeading.Text = "by jez9999";
			// 
			// pbLogo
			// 
			pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
			pbLogo.Location = new Point(12, 15);
			pbLogo.Name = "pbLogo";
			pbLogo.Size = new Size(48, 48);
			pbLogo.TabIndex = 2;
			pbLogo.TabStop = false;
			// 
			// txtVersion
			// 
			txtVersion.BackColor = Color.WhiteSmoke;
			txtVersion.Location = new Point(12, 111);
			txtVersion.Name = "txtVersion";
			txtVersion.ReadOnly = true;
			txtVersion.Size = new Size(338, 23);
			txtVersion.TabIndex = 11;
			txtVersion.TabStop = false;
			// 
			// lblVersionHeading
			// 
			lblVersionHeading.AutoSize = true;
			lblVersionHeading.Location = new Point(12, 93);
			lblVersionHeading.Name = "lblVersionHeading";
			lblVersionHeading.Size = new Size(119, 15);
			lblVersionHeading.TabIndex = 12;
			lblVersionHeading.Text = "Version / Git commit:";
			// 
			// lblDateHeading
			// 
			lblDateHeading.AutoSize = true;
			lblDateHeading.Location = new Point(13, 148);
			lblDateHeading.Name = "lblDateHeading";
			lblDateHeading.Size = new Size(34, 15);
			lblDateHeading.TabIndex = 14;
			lblDateHeading.Text = "Date:";
			// 
			// txtDate
			// 
			txtDate.BackColor = Color.WhiteSmoke;
			txtDate.Location = new Point(13, 166);
			txtDate.Name = "txtDate";
			txtDate.ReadOnly = true;
			txtDate.Size = new Size(338, 23);
			txtDate.TabIndex = 13;
			txtDate.TabStop = false;
			// 
			// btnOk
			// 
			btnOk.Location = new Point(134, 201);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(95, 23);
			btnOk.TabIndex = 15;
			btnOk.Text = "OK";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += btnOk_Click;
			// 
			// lnkDosboxXHomepage
			// 
			lnkDosboxXHomepage.AutoSize = true;
			lnkDosboxXHomepage.LinkColor = Color.Blue;
			lnkDosboxXHomepage.Location = new Point(125, 238);
			lnkDosboxXHomepage.Name = "lnkDosboxXHomepage";
			lnkDosboxXHomepage.Size = new Size(66, 15);
			lnkDosboxXHomepage.TabIndex = 20;
			lnkDosboxXHomepage.TabStop = true;
			lnkDosboxXHomepage.Text = "Homepage";
			lnkDosboxXHomepage.VisitedLinkColor = Color.Blue;
			lnkDosboxXHomepage.LinkClicked += lnkDosboxXHomepage_LinkClicked;
			// 
			// lblDosboxXHeading
			// 
			lblDosboxXHeading.AutoSize = true;
			lblDosboxXHeading.Location = new Point(48, 239);
			lblDosboxXHeading.Name = "lblDosboxXHeading";
			lblDosboxXHeading.Size = new Size(71, 15);
			lblDosboxXHeading.TabIndex = 17;
			lblDosboxXHeading.Text = "DOSBox-X...";
			// 
			// lnkDosboxXGithub
			// 
			lnkDosboxXGithub.AutoSize = true;
			lnkDosboxXGithub.LinkColor = Color.Blue;
			lnkDosboxXGithub.Location = new Point(198, 238);
			lnkDosboxXGithub.Name = "lnkDosboxXGithub";
			lnkDosboxXGithub.Size = new Size(43, 15);
			lnkDosboxXGithub.TabIndex = 21;
			lnkDosboxXGithub.TabStop = true;
			lnkDosboxXGithub.Text = "Github";
			lnkDosboxXGithub.VisitedLinkColor = Color.Blue;
			lnkDosboxXGithub.LinkClicked += lnkDosboxXGithub_LinkClicked;
			// 
			// lnkDosboxXDevBuilds
			// 
			lnkDosboxXDevBuilds.AutoSize = true;
			lnkDosboxXDevBuilds.LinkColor = Color.Blue;
			lnkDosboxXDevBuilds.Location = new Point(248, 238);
			lnkDosboxXDevBuilds.Name = "lnkDosboxXDevBuilds";
			lnkDosboxXDevBuilds.Size = new Size(62, 15);
			lnkDosboxXDevBuilds.TabIndex = 22;
			lnkDosboxXDevBuilds.TabStop = true;
			lnkDosboxXDevBuilds.Text = "Dev builds";
			lnkDosboxXDevBuilds.VisitedLinkColor = Color.Blue;
			lnkDosboxXDevBuilds.LinkClicked += lnkDosboxXDevBuilds_LinkClicked;
			// 
			// AboutForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(362, 270);
			Controls.Add(lnkDosboxXDevBuilds);
			Controls.Add(lnkDosboxXGithub);
			Controls.Add(lblDosboxXHeading);
			Controls.Add(lnkDosboxXHomepage);
			Controls.Add(btnOk);
			Controls.Add(lblDateHeading);
			Controls.Add(txtDate);
			Controls.Add(lblVersionHeading);
			Controls.Add(txtVersion);
			Controls.Add(pbLogo);
			Controls.Add(lblSubHeading);
			Controls.Add(lblHeading);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AboutForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "DOSBoxLaunchX - About";
			Load += AboutForm_Load;
			((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblHeading;
		private Label lblSubHeading;
		private PictureBox pbLogo;
		private TextBox txtVersion;
		private Label lblVersionHeading;
		private Label lblDateHeading;
		private TextBox txtDate;
		private Button btnOk;
		private LinkLabel lnkDosboxXHomepage;
		private Label lblDosboxXHeading;
		private LinkLabel lnkDosboxXGithub;
		private LinkLabel lnkDosboxXDevBuilds;
	}
}