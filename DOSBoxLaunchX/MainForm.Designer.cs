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
			tabGeneral = new TabPage();
			tabCpu = new TabPage();
			tabVideo = new TabPage();
			tabAudio = new TabPage();
			tabPeripherals = new TabPage();
			tabCustom = new TabPage();
			tabKbMappings = new TabPage();
			label2 = new Label();
			btnNew = new Button();
			btnLoad = new Button();
			btnSave = new Button();
			lblIsRegistered = new Label();
			mainMenuStrip = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			newToolStripMenuItem = new ToolStripMenuItem();
			openToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator = new ToolStripSeparator();
			saveToolStripMenuItem = new ToolStripMenuItem();
			saveAsToolStripMenuItem = new ToolStripMenuItem();
			saveGlobalsToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			exitToolStripMenuItem = new ToolStripMenuItem();
			toolsToolStripMenuItem = new ToolStripMenuItem();
			optionsToolStripMenuItem = new ToolStripMenuItem();
			helpToolStripMenuItem = new ToolStripMenuItem();
			infoToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator5 = new ToolStripSeparator();
			aboutToolStripMenuItem = new ToolStripMenuItem();
			mainMenuStripContainer = new ToolStripContainer();
			pbBgMainMenuStrip = new PictureBox();
			tabsContainer.SuspendLayout();
			mainMenuStrip.SuspendLayout();
			mainMenuStripContainer.TopToolStripPanel.SuspendLayout();
			mainMenuStripContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbBgMainMenuStrip).BeginInit();
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
			radShortcut.Location = new Point(13, 45);
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
			radGlobal.Location = new Point(84, 45);
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
			label1.Location = new Point(12, 27);
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
			txtShortcutFilePath.Location = new Point(153, 33);
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
			tabsContainer.Location = new Point(12, 83);
			tabsContainer.Name = "tabsContainer";
			tabsContainer.SelectedIndex = 0;
			tabsContainer.Size = new Size(1235, 539);
			tabsContainer.TabIndex = 100;
			// 
			// tabGeneral
			// 
			tabGeneral.BackColor = SystemColors.Control;
			tabGeneral.Location = new Point(4, 24);
			tabGeneral.Name = "tabGeneral";
			tabGeneral.Size = new Size(1227, 511);
			tabGeneral.TabIndex = 6;
			tabGeneral.Text = "General";
			// 
			// tabCpu
			// 
			tabCpu.BackColor = SystemColors.Control;
			tabCpu.Location = new Point(4, 24);
			tabCpu.Name = "tabCpu";
			tabCpu.Padding = new Padding(3);
			tabCpu.Size = new Size(1227, 511);
			tabCpu.TabIndex = 0;
			tabCpu.Text = "CPU";
			// 
			// tabVideo
			// 
			tabVideo.BackColor = SystemColors.Control;
			tabVideo.Location = new Point(4, 24);
			tabVideo.Name = "tabVideo";
			tabVideo.Padding = new Padding(3);
			tabVideo.Size = new Size(1227, 511);
			tabVideo.TabIndex = 1;
			tabVideo.Text = "Video";
			// 
			// tabAudio
			// 
			tabAudio.BackColor = SystemColors.Control;
			tabAudio.Location = new Point(4, 24);
			tabAudio.Name = "tabAudio";
			tabAudio.Size = new Size(1227, 511);
			tabAudio.TabIndex = 2;
			tabAudio.Text = "Audio";
			// 
			// tabPeripherals
			// 
			tabPeripherals.BackColor = SystemColors.Control;
			tabPeripherals.Location = new Point(4, 24);
			tabPeripherals.Name = "tabPeripherals";
			tabPeripherals.Size = new Size(1227, 511);
			tabPeripherals.TabIndex = 3;
			tabPeripherals.Text = "Peripherals";
			// 
			// tabCustom
			// 
			tabCustom.BackColor = SystemColors.Control;
			tabCustom.Location = new Point(4, 24);
			tabCustom.Name = "tabCustom";
			tabCustom.Size = new Size(1227, 511);
			tabCustom.TabIndex = 4;
			tabCustom.Text = "Custom settings";
			// 
			// tabKbMappings
			// 
			tabKbMappings.BackColor = SystemColors.Control;
			tabKbMappings.Location = new Point(4, 24);
			tabKbMappings.Name = "tabKbMappings";
			tabKbMappings.Size = new Size(1227, 511);
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
			// btnNew
			// 
			btnNew.Location = new Point(1133, 33);
			btnNew.Name = "btnNew";
			btnNew.Size = new Size(75, 23);
			btnNew.TabIndex = 82;
			btnNew.Text = "New";
			btnNew.UseVisualStyleBackColor = true;
			btnNew.Click += btnNew_Click;
			// 
			// btnLoad
			// 
			btnLoad.Location = new Point(1044, 33);
			btnLoad.Name = "btnLoad";
			btnLoad.Size = new Size(83, 23);
			btnLoad.TabIndex = 81;
			btnLoad.Text = "Load";
			btnLoad.UseVisualStyleBackColor = true;
			btnLoad.Click += btnLoad_Click;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(963, 33);
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
			// mainMenuStrip
			// 
			mainMenuStrip.Dock = DockStyle.None;
			mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
			mainMenuStrip.Location = new Point(0, 0);
			mainMenuStrip.Name = "mainMenuStrip";
			mainMenuStrip.RenderMode = ToolStripRenderMode.Professional;
			mainMenuStrip.Size = new Size(174, 24);
			mainMenuStrip.TabIndex = 203;
			mainMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, saveGlobalsToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
			newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
			newToolStripMenuItem.Name = "newToolStripMenuItem";
			newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
			newToolStripMenuItem.Size = new Size(194, 22);
			newToolStripMenuItem.Text = "&New Shortcut";
			newToolStripMenuItem.Click += newToolStripMenuItem_Click;
			// 
			// openToolStripMenuItem
			// 
			openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
			openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
			openToolStripMenuItem.Name = "openToolStripMenuItem";
			openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
			openToolStripMenuItem.Size = new Size(194, 22);
			openToolStripMenuItem.Text = "&Open Shortcut";
			openToolStripMenuItem.Click += openToolStripMenuItem_Click;
			// 
			// toolStripSeparator
			// 
			toolStripSeparator.Name = "toolStripSeparator";
			toolStripSeparator.Size = new Size(191, 6);
			// 
			// saveToolStripMenuItem
			// 
			saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
			saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
			saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
			saveToolStripMenuItem.Size = new Size(194, 22);
			saveToolStripMenuItem.Text = "&Save Shortcut";
			saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
			// 
			// saveAsToolStripMenuItem
			// 
			saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			saveAsToolStripMenuItem.Size = new Size(194, 22);
			saveAsToolStripMenuItem.Text = "Save Shortcut &As";
			saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
			// 
			// saveGlobalsToolStripMenuItem
			// 
			saveGlobalsToolStripMenuItem.Image = (Image)resources.GetObject("saveGlobalsToolStripMenuItem.Image");
			saveGlobalsToolStripMenuItem.ImageTransparentColor = Color.Magenta;
			saveGlobalsToolStripMenuItem.Name = "saveGlobalsToolStripMenuItem";
			saveGlobalsToolStripMenuItem.Size = new Size(194, 22);
			saveGlobalsToolStripMenuItem.Text = "Save &Globals";
			saveGlobalsToolStripMenuItem.Click += saveGlobalsToolStripMenuItem_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(191, 6);
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.Size = new Size(194, 22);
			exitToolStripMenuItem.Text = "E&xit";
			exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
			// 
			// toolsToolStripMenuItem
			// 
			toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
			toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			toolsToolStripMenuItem.Size = new Size(46, 20);
			toolsToolStripMenuItem.Text = "&Tools";
			// 
			// optionsToolStripMenuItem
			// 
			optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			optionsToolStripMenuItem.Size = new Size(116, 22);
			optionsToolStripMenuItem.Text = "&Options";
			optionsToolStripMenuItem.Click += optionsToolStripMenuItem_Click;
			// 
			// helpToolStripMenuItem
			// 
			helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { infoToolStripMenuItem, toolStripSeparator5, aboutToolStripMenuItem });
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new Size(44, 20);
			helpToolStripMenuItem.Text = "&Help";
			// 
			// infoToolStripMenuItem
			// 
			infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			infoToolStripMenuItem.Size = new Size(180, 22);
			infoToolStripMenuItem.Text = "&Info";
			infoToolStripMenuItem.Click += infoToolStripMenuItem_Click;
			// 
			// toolStripSeparator5
			// 
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new Size(177, 6);
			// 
			// aboutToolStripMenuItem
			// 
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new Size(180, 22);
			aboutToolStripMenuItem.Text = "&About...";
			aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
			// 
			// mainMenuStripContainer
			// 
			mainMenuStripContainer.BottomToolStripPanelVisible = false;
			// 
			// mainMenuStripContainer.ContentPanel
			// 
			mainMenuStripContainer.ContentPanel.Size = new Size(174, 0);
			mainMenuStripContainer.LeftToolStripPanelVisible = false;
			mainMenuStripContainer.Location = new Point(0, 0);
			mainMenuStripContainer.Name = "mainMenuStripContainer";
			mainMenuStripContainer.RightToolStripPanelVisible = false;
			mainMenuStripContainer.Size = new Size(174, 24);
			mainMenuStripContainer.TabIndex = 204;
			mainMenuStripContainer.Text = "toolStripContainer1";
			// 
			// mainMenuStripContainer.TopToolStripPanel
			// 
			mainMenuStripContainer.TopToolStripPanel.Controls.Add(mainMenuStrip);
			// 
			// pbBgMainMenuStrip
			// 
			pbBgMainMenuStrip.BackColor = Color.FromArgb(252, 252, 252);
			pbBgMainMenuStrip.Location = new Point(0, 0);
			pbBgMainMenuStrip.Name = "pbBgMainMenuStrip";
			pbBgMainMenuStrip.Size = new Size(1259, 24);
			pbBgMainMenuStrip.TabIndex = 205;
			pbBgMainMenuStrip.TabStop = false;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1259, 867);
			Controls.Add(mainMenuStripContainer);
			Controls.Add(lblIsRegistered);
			Controls.Add(btnSave);
			Controls.Add(btnLoad);
			Controls.Add(btnNew);
			Controls.Add(label2);
			Controls.Add(tabsContainer);
			Controls.Add(txtShortcutFilePath);
			Controls.Add(btnRemoveAssoc);
			Controls.Add(btnAssoc);
			Controls.Add(label1);
			Controls.Add(radGlobal);
			Controls.Add(radShortcut);
			Controls.Add(txtOutput);
			Controls.Add(pbBgMainMenuStrip);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = mainMenuStrip;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "DOSBoxLaunchX";
			FormClosing += MainForm_FormClosing;
			Load += MainForm_Load;
			tabsContainer.ResumeLayout(false);
			mainMenuStrip.ResumeLayout(false);
			mainMenuStrip.PerformLayout();
			mainMenuStripContainer.TopToolStripPanel.ResumeLayout(false);
			mainMenuStripContainer.TopToolStripPanel.PerformLayout();
			mainMenuStripContainer.ResumeLayout(false);
			mainMenuStripContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pbBgMainMenuStrip).EndInit();
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
		private Button btnNew;
		private Button btnLoad;
		private Button btnSave;
		private Label lblIsRegistered;
		private TabPage tabGeneral;
		private MenuStrip mainMenuStrip;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem newToolStripMenuItem;
		private ToolStripMenuItem openToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator;
		private ToolStripMenuItem saveToolStripMenuItem;
		private ToolStripMenuItem saveAsToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem toolsToolStripMenuItem;
		private ToolStripMenuItem optionsToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem infoToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private ToolStripContainer mainMenuStripContainer;
		private PictureBox pbBgMainMenuStrip;
		private ToolStripMenuItem saveGlobalsToolStripMenuItem;
	}
}
