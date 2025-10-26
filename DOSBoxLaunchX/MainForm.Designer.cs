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
			radShortcut = new RadioButton();
			radGlobal = new RadioButton();
			label1 = new Label();
			btnAssoc = new Button();
			btnRemoveAssoc = new Button();
			txtShortcutFilePath = new TextBox();
			tabsContainer = new TabControl();
			tabCpu = new TabPage();
			tabVideo = new TabPage();
			tabAudio = new TabPage();
			tabPeripherals = new TabPage();
			tabCustom = new TabPage();
			tabKbMappings = new TabPage();
			label2 = new Label();
			btnHelp = new Button();
			btnNew = new Button();
			btnLoad = new Button();
			btnSave = new Button();
			lblIsRegistered = new Label();
			tabGeneral = new TabPage();
			tabsContainer.SuspendLayout();
			SuspendLayout();
			// 
			// txtOutput
			// 
			txtOutput.BackColor = SystemColors.Window;
			txtOutput.Font = new Font("Courier New", 9.75F);
			txtOutput.Location = new Point(12, 656);
			txtOutput.Multiline = true;
			txtOutput.Name = "txtOutput";
			txtOutput.ReadOnly = true;
			txtOutput.ScrollBars = ScrollBars.Vertical;
			txtOutput.Size = new Size(1235, 199);
			txtOutput.TabIndex = 0;
			txtOutput.TabStop = false;
			// 
			// radShortcut
			// 
			radShortcut.AutoSize = true;
			radShortcut.Location = new Point(10, 27);
			radShortcut.Name = "radShortcut";
			radShortcut.Size = new Size(70, 19);
			radShortcut.TabIndex = 1;
			radShortcut.TabStop = true;
			radShortcut.Text = "Shortcut";
			radShortcut.UseVisualStyleBackColor = true;
			radShortcut.CheckedChanged += radShortcut_CheckedChanged;
			// 
			// radGlobal
			// 
			radGlobal.AutoSize = true;
			radGlobal.Location = new Point(81, 27);
			radGlobal.Name = "radGlobal";
			radGlobal.Size = new Size(59, 19);
			radGlobal.TabIndex = 2;
			radGlobal.TabStop = true;
			radGlobal.Text = "Global";
			radGlobal.UseVisualStyleBackColor = true;
			radGlobal.CheckedChanged += radGlobal_CheckedChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(9, 9);
			label1.Name = "label1";
			label1.Size = new Size(128, 15);
			label1.TabIndex = 3;
			label1.Text = "Editing config settings:";
			// 
			// btnAssoc
			// 
			btnAssoc.Location = new Point(814, 628);
			btnAssoc.Name = "btnAssoc";
			btnAssoc.Size = new Size(183, 23);
			btnAssoc.TabIndex = 200;
			btnAssoc.Text = "Associate app with .DLX files";
			btnAssoc.UseVisualStyleBackColor = true;
			btnAssoc.Click += btnAssoc_Click;
			// 
			// btnRemoveAssoc
			// 
			btnRemoveAssoc.Location = new Point(1003, 628);
			btnRemoveAssoc.Name = "btnRemoveAssoc";
			btnRemoveAssoc.Size = new Size(245, 23);
			btnRemoveAssoc.TabIndex = 201;
			btnRemoveAssoc.Text = "Remove app's association with .DLX files";
			btnRemoveAssoc.UseVisualStyleBackColor = true;
			btnRemoveAssoc.Click += btnRemoveAssoc_Click;
			// 
			// txtShortcutFilePath
			// 
			txtShortcutFilePath.Location = new Point(150, 15);
			txtShortcutFilePath.Name = "txtShortcutFilePath";
			txtShortcutFilePath.ReadOnly = true;
			txtShortcutFilePath.Size = new Size(798, 23);
			txtShortcutFilePath.TabIndex = 10;
			// 
			// tabsContainer
			// 
			tabsContainer.Controls.Add(tabGeneral);
			tabsContainer.Controls.Add(tabCpu);
			tabsContainer.Controls.Add(tabVideo);
			tabsContainer.Controls.Add(tabAudio);
			tabsContainer.Controls.Add(tabPeripherals);
			tabsContainer.Controls.Add(tabCustom);
			tabsContainer.Controls.Add(tabKbMappings);
			tabsContainer.Location = new Point(12, 52);
			tabsContainer.Name = "tabsContainer";
			tabsContainer.SelectedIndex = 0;
			tabsContainer.Size = new Size(1235, 572);
			tabsContainer.TabIndex = 100;
			// 
			// tabCpu
			// 
			tabCpu.BackColor = SystemColors.Control;
			tabCpu.Location = new Point(4, 24);
			tabCpu.Name = "tabCpu";
			tabCpu.Padding = new Padding(3);
			tabCpu.Size = new Size(1227, 544);
			tabCpu.TabIndex = 0;
			tabCpu.Text = "CPU";
			// 
			// tabVideo
			// 
			tabVideo.BackColor = SystemColors.Control;
			tabVideo.Location = new Point(4, 24);
			tabVideo.Name = "tabVideo";
			tabVideo.Padding = new Padding(3);
			tabVideo.Size = new Size(1227, 544);
			tabVideo.TabIndex = 1;
			tabVideo.Text = "Video";
			// 
			// tabAudio
			// 
			tabAudio.BackColor = SystemColors.Control;
			tabAudio.Location = new Point(4, 24);
			tabAudio.Name = "tabAudio";
			tabAudio.Size = new Size(1227, 544);
			tabAudio.TabIndex = 2;
			tabAudio.Text = "Audio";
			// 
			// tabPeripherals
			// 
			tabPeripherals.BackColor = SystemColors.Control;
			tabPeripherals.Location = new Point(4, 24);
			tabPeripherals.Name = "tabPeripherals";
			tabPeripherals.Size = new Size(1227, 544);
			tabPeripherals.TabIndex = 3;
			tabPeripherals.Text = "Peripherals";
			// 
			// tabCustom
			// 
			tabCustom.BackColor = SystemColors.Control;
			tabCustom.Location = new Point(4, 24);
			tabCustom.Name = "tabCustom";
			tabCustom.Size = new Size(1227, 544);
			tabCustom.TabIndex = 4;
			tabCustom.Text = "Custom settings";
			// 
			// tabKbMappings
			// 
			tabKbMappings.BackColor = SystemColors.Control;
			tabKbMappings.Location = new Point(4, 24);
			tabKbMappings.Name = "tabKbMappings";
			tabKbMappings.Size = new Size(1227, 544);
			tabKbMappings.TabIndex = 5;
			tabKbMappings.Text = "Keyboard mappings";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label2.Location = new Point(12, 636);
			label2.Name = "label2";
			label2.Size = new Size(47, 15);
			label2.TabIndex = 8;
			label2.Text = "Output";
			// 
			// btnHelp
			// 
			btnHelp.Image = (Image)resources.GetObject("btnHelp.Image");
			btnHelp.Location = new Point(1214, 9);
			btnHelp.Name = "btnHelp";
			btnHelp.Size = new Size(35, 35);
			btnHelp.TabIndex = 90;
			btnHelp.UseVisualStyleBackColor = true;
			btnHelp.Click += btnHelp_Click;
			// 
			// btnNew
			// 
			btnNew.Location = new Point(1130, 15);
			btnNew.Name = "btnNew";
			btnNew.Size = new Size(75, 23);
			btnNew.TabIndex = 82;
			btnNew.Text = "New";
			btnNew.UseVisualStyleBackColor = true;
			btnNew.Click += btnNew_Click;
			// 
			// btnLoad
			// 
			btnLoad.Location = new Point(1041, 15);
			btnLoad.Name = "btnLoad";
			btnLoad.Size = new Size(83, 23);
			btnLoad.TabIndex = 81;
			btnLoad.Text = "Load";
			btnLoad.UseVisualStyleBackColor = true;
			btnLoad.Click += btnLoad_Click;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(960, 15);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 80;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// lblIsRegistered
			// 
			lblIsRegistered.AutoSize = true;
			lblIsRegistered.Location = new Point(629, 629);
			lblIsRegistered.Name = "lblIsRegistered";
			lblIsRegistered.Size = new Size(83, 15);
			lblIsRegistered.TabIndex = 202;
			lblIsRegistered.Text = "Registered: ???";
			// 
			// tabGeneral
			// 
			tabGeneral.BackColor = SystemColors.Control;
			tabGeneral.Location = new Point(4, 24);
			tabGeneral.Name = "tabGeneral";
			tabGeneral.Size = new Size(1227, 544);
			tabGeneral.TabIndex = 6;
			tabGeneral.Text = "General";
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1259, 867);
			Controls.Add(lblIsRegistered);
			Controls.Add(btnSave);
			Controls.Add(btnLoad);
			Controls.Add(btnNew);
			Controls.Add(btnHelp);
			Controls.Add(label2);
			Controls.Add(tabsContainer);
			Controls.Add(txtShortcutFilePath);
			Controls.Add(btnRemoveAssoc);
			Controls.Add(btnAssoc);
			Controls.Add(label1);
			Controls.Add(radGlobal);
			Controls.Add(radShortcut);
			Controls.Add(txtOutput);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "DOSBoxLaunchX";
			Load += MainForm_Load;
			tabsContainer.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtOutput;
		private RadioButton radShortcut;
		private RadioButton radGlobal;
		private Label label1;
		private Button btnAssoc;
		private Button btnRemoveAssoc;
		private TextBox txtShortcutFilePath;
		private TabControl tabsContainer;
		private TabPage tabCpu;
		private TabPage tabVideo;
		private TabPage tabAudio;
		private TabPage tabPeripherals;
		private TabPage tabCustom;
		private TabPage tabKbMappings;
		private Label label2;
		private Button btnHelp;
		private Button btnNew;
		private Button btnLoad;
		private Button btnSave;
		private Label lblIsRegistered;
		private TabPage tabGeneral;
	}
}
