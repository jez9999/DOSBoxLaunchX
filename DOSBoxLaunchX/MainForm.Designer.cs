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
			radShortcut = new RadioButton();
			radGlobal = new RadioButton();
			label1 = new Label();
			btnAssoc = new Button();
			btnRemoveAssoc = new Button();
			txtShortcutFilePath = new TextBox();
			tabsContainer = new TabControl();
			tabGeneral = new TabPage();
			btnExecutableBrowse = new Button();
			lblNameDescriptionNote = new Label();
			comboLimitBaseDirToOneGiB = new ComboBox();
			cbLimitBaseDirToOneGiBSet = new CheckBox();
			lblLimitBaseDirToOneGiB = new Label();
			cbExecutableSet = new CheckBox();
			txtExecutable = new TextBox();
			lblExecutable = new Label();
			cbBaseDirSet = new CheckBox();
			label6 = new Label();
			txtBaseDir = new TextBox();
			lblBaseDir = new Label();
			txtDescription = new TextBox();
			lblDescription = new Label();
			txtName = new TextBox();
			lblName = new Label();
			tabCpu = new TabPage();
			cbCyclesSet = new CheckBox();
			label4 = new Label();
			txtCycles = new TextBox();
			lblCycles = new Label();
			tabVideo = new TabPage();
			tabAudio = new TabPage();
			tabPeripherals = new TabPage();
			tabAutoexec = new TabPage();
			txtAutoexec = new TextBox();
			lblAutoexecScript = new Label();
			lblAutoexecEllipsis = new Label();
			txtPostAutoexec = new TextBox();
			txtPreAutoexec = new TextBox();
			tabCustom = new TabPage();
			lblHeadingValue = new Label();
			lblHeadingKey = new Label();
			lblHeadingSection = new Label();
			flowPnlCustom = new FlowLayoutPanel();
			btnAddCustomSetting = new Button();
			tabKbMappings = new TabPage();
			label2 = new Label();
			lblIsRegistered = new Label();
			mainMenuStrip = new MenuStrip();
			mnuFile = new ToolStripMenuItem();
			mnuNew = new ToolStripMenuItem();
			mnuOpen = new ToolStripMenuItem();
			toolStripSeparator = new ToolStripSeparator();
			mnuSave = new ToolStripMenuItem();
			mnuSaveAs = new ToolStripMenuItem();
			mnuSaveGlobals = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			mnuExit = new ToolStripMenuItem();
			mnuTools = new ToolStripMenuItem();
			mnuOptions = new ToolStripMenuItem();
			mnuHelp = new ToolStripMenuItem();
			mnuInfo = new ToolStripMenuItem();
			toolStripSeparator5 = new ToolStripSeparator();
			mnuAbout = new ToolStripMenuItem();
			mainMenuStripContainer = new ToolStripContainer();
			pbBgMainMenuStrip = new PictureBox();
			txtOutput = new RichTextBox();
			openFileDialog = new OpenFileDialog();
			saveFileDialog = new SaveFileDialog();
			tabsContainer.SuspendLayout();
			tabGeneral.SuspendLayout();
			tabCpu.SuspendLayout();
			tabAutoexec.SuspendLayout();
			tabCustom.SuspendLayout();
			mainMenuStrip.SuspendLayout();
			mainMenuStripContainer.TopToolStripPanel.SuspendLayout();
			mainMenuStripContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbBgMainMenuStrip).BeginInit();
			SuspendLayout();
			// 
			// radShortcut
			// 
			radShortcut.AutoSize = true;
			radShortcut.Checked = true;
			radShortcut.Location = new Point(13, 50);
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
			radGlobal.Location = new Point(96, 50);
			radGlobal.Name = "radGlobal";
			radGlobal.Size = new Size(59, 19);
			radGlobal.TabIndex = 2;
			radGlobal.Text = "Global";
			radGlobal.UseVisualStyleBackColor = true;
			radGlobal.CheckedChanged += radGlobal_CheckedChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(18, 32);
			label1.Name = "label1";
			label1.Size = new Size(128, 15);
			label1.TabIndex = 3;
			label1.Text = "Editing config settings:";
			// 
			// btnAssoc
			// 
			btnAssoc.Location = new Point(814, 621);
			btnAssoc.Name = "btnAssoc";
			btnAssoc.Size = new Size(183, 23);
			btnAssoc.TabIndex = 200;
			btnAssoc.Text = "Associate app with .DLX files";
			btnAssoc.UseVisualStyleBackColor = true;
			btnAssoc.Click += btnAssoc_Click;
			// 
			// btnRemoveAssoc
			// 
			btnRemoveAssoc.Location = new Point(1003, 621);
			btnRemoveAssoc.Name = "btnRemoveAssoc";
			btnRemoveAssoc.Size = new Size(245, 23);
			btnRemoveAssoc.TabIndex = 201;
			btnRemoveAssoc.Text = "Remove app's association with .DLX files";
			btnRemoveAssoc.UseVisualStyleBackColor = true;
			btnRemoveAssoc.Click += btnRemoveAssoc_Click;
			// 
			// txtShortcutFilePath
			// 
			txtShortcutFilePath.Location = new Point(167, 38);
			txtShortcutFilePath.Name = "txtShortcutFilePath";
			txtShortcutFilePath.ReadOnly = true;
			txtShortcutFilePath.Size = new Size(1076, 23);
			txtShortcutFilePath.TabIndex = 10;
			// 
			// tabsContainer
			// 
			tabsContainer.Controls.Add(tabGeneral);
			tabsContainer.Controls.Add(tabCpu);
			tabsContainer.Controls.Add(tabVideo);
			tabsContainer.Controls.Add(tabAudio);
			tabsContainer.Controls.Add(tabPeripherals);
			tabsContainer.Controls.Add(tabAutoexec);
			tabsContainer.Controls.Add(tabCustom);
			tabsContainer.Controls.Add(tabKbMappings);
			tabsContainer.Location = new Point(12, 76);
			tabsContainer.Name = "tabsContainer";
			tabsContainer.SelectedIndex = 0;
			tabsContainer.Size = new Size(1235, 539);
			tabsContainer.TabIndex = 100;
			// 
			// tabGeneral
			// 
			tabGeneral.BackColor = SystemColors.Control;
			tabGeneral.Controls.Add(btnExecutableBrowse);
			tabGeneral.Controls.Add(lblNameDescriptionNote);
			tabGeneral.Controls.Add(comboLimitBaseDirToOneGiB);
			tabGeneral.Controls.Add(cbLimitBaseDirToOneGiBSet);
			tabGeneral.Controls.Add(lblLimitBaseDirToOneGiB);
			tabGeneral.Controls.Add(cbExecutableSet);
			tabGeneral.Controls.Add(txtExecutable);
			tabGeneral.Controls.Add(lblExecutable);
			tabGeneral.Controls.Add(cbBaseDirSet);
			tabGeneral.Controls.Add(label6);
			tabGeneral.Controls.Add(txtBaseDir);
			tabGeneral.Controls.Add(lblBaseDir);
			tabGeneral.Controls.Add(txtDescription);
			tabGeneral.Controls.Add(lblDescription);
			tabGeneral.Controls.Add(txtName);
			tabGeneral.Controls.Add(lblName);
			tabGeneral.Location = new Point(4, 24);
			tabGeneral.Name = "tabGeneral";
			tabGeneral.Size = new Size(1227, 511);
			tabGeneral.TabIndex = 6;
			tabGeneral.Text = "General";
			// 
			// btnExecutableBrowse
			// 
			btnExecutableBrowse.Location = new Point(522, 203);
			btnExecutableBrowse.Name = "btnExecutableBrowse";
			btnExecutableBrowse.Size = new Size(75, 23);
			btnExecutableBrowse.TabIndex = 52;
			btnExecutableBrowse.Text = "&Browse...";
			btnExecutableBrowse.UseVisualStyleBackColor = true;
			btnExecutableBrowse.Click += btnExecutableBrowse_Click;
			// 
			// lblNameDescriptionNote
			// 
			lblNameDescriptionNote.AutoSize = true;
			lblNameDescriptionNote.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
			lblNameDescriptionNote.Location = new Point(127, 7);
			lblNameDescriptionNote.Name = "lblNameDescriptionNote";
			lblNameDescriptionNote.Size = new Size(463, 15);
			lblNameDescriptionNote.TabIndex = 19;
			lblNameDescriptionNote.Text = "(Name/Description are purely descriptive and don't affect the DOSBox-X configuration)";
			// 
			// comboLimitBaseDirToOneGiB
			// 
			comboLimitBaseDirToOneGiB.DropDownStyle = ComboBoxStyle.DropDownList;
			comboLimitBaseDirToOneGiB.FormattingEnabled = true;
			comboLimitBaseDirToOneGiB.Items.AddRange(new object[] { "Yes", "No" });
			comboLimitBaseDirToOneGiB.Location = new Point(289, 174);
			comboLimitBaseDirToOneGiB.Name = "comboLimitBaseDirToOneGiB";
			comboLimitBaseDirToOneGiB.Size = new Size(64, 23);
			comboLimitBaseDirToOneGiB.TabIndex = 41;
			comboLimitBaseDirToOneGiB.Tag = "defaults";
			// 
			// cbLimitBaseDirToOneGiBSet
			// 
			cbLimitBaseDirToOneGiBSet.AutoSize = true;
			cbLimitBaseDirToOneGiBSet.Location = new Point(11, 178);
			cbLimitBaseDirToOneGiBSet.Name = "cbLimitBaseDirToOneGiBSet";
			cbLimitBaseDirToOneGiBSet.Size = new Size(15, 14);
			cbLimitBaseDirToOneGiBSet.TabIndex = 40;
			cbLimitBaseDirToOneGiBSet.Tag = "assoc=lblLimitBaseDirToOneGiB,comboLimitBaseDirToOneGiB";
			cbLimitBaseDirToOneGiBSet.UseVisualStyleBackColor = true;
			// 
			// lblLimitBaseDirToOneGiB
			// 
			lblLimitBaseDirToOneGiB.AutoSize = true;
			lblLimitBaseDirToOneGiB.Location = new Point(36, 177);
			lblLimitBaseDirToOneGiB.Name = "lblLimitBaseDirToOneGiB";
			lblLimitBaseDirToOneGiB.Size = new Size(247, 15);
			lblLimitBaseDirToOneGiB.TabIndex = 15;
			lblLimitBaseDirToOneGiB.Text = "^ Limit reported free hard disk space to 1 GiB:";
			// 
			// cbExecutableSet
			// 
			cbExecutableSet.AutoSize = true;
			cbExecutableSet.Location = new Point(11, 207);
			cbExecutableSet.Name = "cbExecutableSet";
			cbExecutableSet.Size = new Size(15, 14);
			cbExecutableSet.TabIndex = 50;
			cbExecutableSet.Tag = "assoc=lblExecutable,txtExecutable,btnExecutableBrowse";
			cbExecutableSet.UseVisualStyleBackColor = true;
			// 
			// txtExecutable
			// 
			txtExecutable.Location = new Point(127, 203);
			txtExecutable.Name = "txtExecutable";
			txtExecutable.Size = new Size(389, 23);
			txtExecutable.TabIndex = 51;
			txtExecutable.Tag = "defaults";
			// 
			// lblExecutable
			// 
			lblExecutable.AutoSize = true;
			lblExecutable.Cursor = Cursors.Help;
			lblExecutable.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
			lblExecutable.Location = new Point(36, 206);
			lblExecutable.Name = "lblExecutable";
			lblExecutable.Size = new Size(67, 15);
			lblExecutable.TabIndex = 11;
			lblExecutable.Text = "Executable:";
			lblExecutable.Click += lblExecutable_Click;
			// 
			// cbBaseDirSet
			// 
			cbBaseDirSet.AutoSize = true;
			cbBaseDirSet.Location = new Point(11, 149);
			cbBaseDirSet.Name = "cbBaseDirSet";
			cbBaseDirSet.Size = new Size(15, 14);
			cbBaseDirSet.TabIndex = 30;
			cbBaseDirSet.Tag = "assoc=lblBaseDir,txtBaseDir";
			cbBaseDirSet.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label6.Location = new Point(5, 7);
			label6.Name = "label6";
			label6.Size = new Size(26, 15);
			label6.TabIndex = 6;
			label6.Text = "Set";
			// 
			// txtBaseDir
			// 
			txtBaseDir.Location = new Point(127, 145);
			txtBaseDir.Name = "txtBaseDir";
			txtBaseDir.Size = new Size(470, 23);
			txtBaseDir.TabIndex = 31;
			txtBaseDir.Tag = "defaults";
			// 
			// lblBaseDir
			// 
			lblBaseDir.AutoSize = true;
			lblBaseDir.Cursor = Cursors.Help;
			lblBaseDir.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
			lblBaseDir.Location = new Point(36, 148);
			lblBaseDir.Name = "lblBaseDir";
			lblBaseDir.Size = new Size(85, 15);
			lblBaseDir.TabIndex = 4;
			lblBaseDir.Text = "Base Directory:";
			lblBaseDir.Click += lblBaseDir_Click;
			// 
			// txtDescription
			// 
			txtDescription.Location = new Point(127, 54);
			txtDescription.Multiline = true;
			txtDescription.Name = "txtDescription";
			txtDescription.ScrollBars = ScrollBars.Vertical;
			txtDescription.Size = new Size(470, 85);
			txtDescription.TabIndex = 21;
			txtDescription.Tag = "allowNewlines=true";
			// 
			// lblDescription
			// 
			lblDescription.AutoSize = true;
			lblDescription.Location = new Point(36, 57);
			lblDescription.Name = "lblDescription";
			lblDescription.Size = new Size(70, 15);
			lblDescription.TabIndex = 2;
			lblDescription.Text = "Description:";
			// 
			// txtName
			// 
			txtName.Location = new Point(127, 25);
			txtName.Name = "txtName";
			txtName.Size = new Size(470, 23);
			txtName.TabIndex = 11;
			txtName.Tag = "defaults";
			// 
			// lblName
			// 
			lblName.AutoSize = true;
			lblName.Location = new Point(36, 28);
			lblName.Name = "lblName";
			lblName.Size = new Size(42, 15);
			lblName.TabIndex = 0;
			lblName.Text = "Name:";
			// 
			// tabCpu
			// 
			tabCpu.BackColor = SystemColors.Control;
			tabCpu.Controls.Add(cbCyclesSet);
			tabCpu.Controls.Add(label4);
			tabCpu.Controls.Add(txtCycles);
			tabCpu.Controls.Add(lblCycles);
			tabCpu.Location = new Point(4, 24);
			tabCpu.Name = "tabCpu";
			tabCpu.Padding = new Padding(3);
			tabCpu.Size = new Size(1227, 511);
			tabCpu.TabIndex = 0;
			tabCpu.Text = "CPU";
			// 
			// cbCyclesSet
			// 
			cbCyclesSet.AutoSize = true;
			cbCyclesSet.Location = new Point(11, 29);
			cbCyclesSet.Name = "cbCyclesSet";
			cbCyclesSet.Size = new Size(15, 14);
			cbCyclesSet.TabIndex = 10;
			cbCyclesSet.Tag = "assoc=lblCycles,txtCycles";
			cbCyclesSet.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			label4.Location = new Point(5, 7);
			label4.Name = "label4";
			label4.Size = new Size(26, 15);
			label4.TabIndex = 35;
			label4.Text = "Set";
			// 
			// txtCycles
			// 
			txtCycles.Location = new Point(127, 25);
			txtCycles.Name = "txtCycles";
			txtCycles.Size = new Size(470, 23);
			txtCycles.TabIndex = 11;
			txtCycles.Tag = "defaults";
			// 
			// lblCycles
			// 
			lblCycles.AutoSize = true;
			lblCycles.Location = new Point(36, 28);
			lblCycles.Name = "lblCycles";
			lblCycles.Size = new Size(44, 15);
			lblCycles.TabIndex = 34;
			lblCycles.Text = "Cycles:";
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
			// tabAutoexec
			// 
			tabAutoexec.BackColor = SystemColors.Control;
			tabAutoexec.Controls.Add(txtAutoexec);
			tabAutoexec.Controls.Add(lblAutoexecScript);
			tabAutoexec.Controls.Add(lblAutoexecEllipsis);
			tabAutoexec.Controls.Add(txtPostAutoexec);
			tabAutoexec.Controls.Add(txtPreAutoexec);
			tabAutoexec.Location = new Point(4, 24);
			tabAutoexec.Name = "tabAutoexec";
			tabAutoexec.Size = new Size(1227, 511);
			tabAutoexec.TabIndex = 7;
			tabAutoexec.Text = "Autoexec";
			// 
			// txtAutoexec
			// 
			txtAutoexec.Font = new Font("Courier New", 9.75F);
			txtAutoexec.Location = new Point(8, 92);
			txtAutoexec.Multiline = true;
			txtAutoexec.Name = "txtAutoexec";
			txtAutoexec.ScrollBars = ScrollBars.Vertical;
			txtAutoexec.Size = new Size(1211, 367);
			txtAutoexec.TabIndex = 20;
			txtAutoexec.Tag = "allowNewlines=true";
			// 
			// lblAutoexecScript
			// 
			lblAutoexecScript.AutoSize = true;
			lblAutoexecScript.Cursor = Cursors.Help;
			lblAutoexecScript.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
			lblAutoexecScript.Location = new Point(8, 74);
			lblAutoexecScript.Name = "lblAutoexecScript";
			lblAutoexecScript.Size = new Size(93, 15);
			lblAutoexecScript.TabIndex = 101;
			lblAutoexecScript.Text = "Autoexec Script:";
			lblAutoexecScript.Click += lblAutoexecScript_Click;
			// 
			// lblAutoexecEllipsis
			// 
			lblAutoexecEllipsis.AutoSize = true;
			lblAutoexecEllipsis.Font = new Font("Courier New", 9.75F);
			lblAutoexecEllipsis.Location = new Point(8, 49);
			lblAutoexecEllipsis.Name = "lblAutoexecEllipsis";
			lblAutoexecEllipsis.Size = new Size(47, 16);
			lblAutoexecEllipsis.TabIndex = 2;
			lblAutoexecEllipsis.Text = "[...]";
			// 
			// txtPostAutoexec
			// 
			txtPostAutoexec.BackColor = SystemColors.Info;
			txtPostAutoexec.Font = new Font("Courier New", 9.75F);
			txtPostAutoexec.Location = new Point(8, 465);
			txtPostAutoexec.Multiline = true;
			txtPostAutoexec.Name = "txtPostAutoexec";
			txtPostAutoexec.ReadOnly = true;
			txtPostAutoexec.ScrollBars = ScrollBars.Vertical;
			txtPostAutoexec.Size = new Size(1211, 39);
			txtPostAutoexec.TabIndex = 100;
			txtPostAutoexec.Tag = "ignore";
			// 
			// txtPreAutoexec
			// 
			txtPreAutoexec.BackColor = SystemColors.Info;
			txtPreAutoexec.Font = new Font("Courier New", 9.75F);
			txtPreAutoexec.Location = new Point(8, 7);
			txtPreAutoexec.Multiline = true;
			txtPreAutoexec.Name = "txtPreAutoexec";
			txtPreAutoexec.ReadOnly = true;
			txtPreAutoexec.ScrollBars = ScrollBars.Vertical;
			txtPreAutoexec.Size = new Size(1211, 39);
			txtPreAutoexec.TabIndex = 10;
			txtPreAutoexec.Tag = "ignore";
			// 
			// tabCustom
			// 
			tabCustom.BackColor = SystemColors.Control;
			tabCustom.Controls.Add(lblHeadingValue);
			tabCustom.Controls.Add(lblHeadingKey);
			tabCustom.Controls.Add(lblHeadingSection);
			tabCustom.Controls.Add(flowPnlCustom);
			tabCustom.Controls.Add(btnAddCustomSetting);
			tabCustom.Location = new Point(4, 24);
			tabCustom.Name = "tabCustom";
			tabCustom.Size = new Size(1227, 511);
			tabCustom.TabIndex = 4;
			tabCustom.Text = "Custom settings";
			// 
			// lblHeadingValue
			// 
			lblHeadingValue.AutoSize = true;
			lblHeadingValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblHeadingValue.Location = new Point(496, 7);
			lblHeadingValue.Name = "lblHeadingValue";
			lblHeadingValue.Size = new Size(37, 15);
			lblHeadingValue.TabIndex = 104;
			lblHeadingValue.Text = "Value";
			// 
			// lblHeadingKey
			// 
			lblHeadingKey.AutoSize = true;
			lblHeadingKey.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblHeadingKey.Location = new Point(190, 7);
			lblHeadingKey.Name = "lblHeadingKey";
			lblHeadingKey.Size = new Size(28, 15);
			lblHeadingKey.TabIndex = 103;
			lblHeadingKey.Text = "Key";
			// 
			// lblHeadingSection
			// 
			lblHeadingSection.AutoSize = true;
			lblHeadingSection.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblHeadingSection.Location = new Point(5, 7);
			lblHeadingSection.Name = "lblHeadingSection";
			lblHeadingSection.Size = new Size(49, 15);
			lblHeadingSection.TabIndex = 102;
			lblHeadingSection.Text = "Section";
			// 
			// flowPnlCustom
			// 
			flowPnlCustom.AutoScroll = true;
			flowPnlCustom.Location = new Point(0, 25);
			flowPnlCustom.Name = "flowPnlCustom";
			flowPnlCustom.Size = new Size(1227, 452);
			flowPnlCustom.TabIndex = 101;
			// 
			// btnAddCustomSetting
			// 
			btnAddCustomSetting.Location = new Point(5, 483);
			btnAddCustomSetting.Name = "btnAddCustomSetting";
			btnAddCustomSetting.Size = new Size(212, 23);
			btnAddCustomSetting.TabIndex = 100;
			btnAddCustomSetting.Text = "Add new custom setting";
			btnAddCustomSetting.UseVisualStyleBackColor = true;
			btnAddCustomSetting.Click += btnAddCustomSetting_Click;
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
			label2.Location = new Point(12, 629);
			label2.Name = "label2";
			label2.Size = new Size(47, 15);
			label2.TabIndex = 8;
			label2.Text = "Output";
			// 
			// lblIsRegistered
			// 
			lblIsRegistered.AutoSize = true;
			lblIsRegistered.Location = new Point(629, 622);
			lblIsRegistered.Name = "lblIsRegistered";
			lblIsRegistered.Size = new Size(83, 15);
			lblIsRegistered.TabIndex = 202;
			lblIsRegistered.Text = "Registered: ???";
			// 
			// mainMenuStrip
			// 
			mainMenuStrip.Dock = DockStyle.None;
			mainMenuStrip.Items.AddRange(new ToolStripItem[] { mnuFile, mnuTools, mnuHelp });
			mainMenuStrip.Location = new Point(0, 0);
			mainMenuStrip.Name = "mainMenuStrip";
			mainMenuStrip.RenderMode = ToolStripRenderMode.Professional;
			mainMenuStrip.Size = new Size(174, 24);
			mainMenuStrip.TabIndex = 203;
			mainMenuStrip.Text = "menuStrip1";
			// 
			// mnuFile
			// 
			mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuNew, mnuOpen, toolStripSeparator, mnuSave, mnuSaveAs, mnuSaveGlobals, toolStripSeparator2, mnuExit });
			mnuFile.Name = "mnuFile";
			mnuFile.Size = new Size(37, 20);
			mnuFile.Text = "&File";
			// 
			// mnuNew
			// 
			mnuNew.Image = (Image)resources.GetObject("mnuNew.Image");
			mnuNew.ImageTransparentColor = Color.Magenta;
			mnuNew.Name = "mnuNew";
			mnuNew.ShortcutKeys = Keys.Control | Keys.N;
			mnuNew.Size = new Size(194, 22);
			mnuNew.Text = "&New Shortcut";
			mnuNew.Click += mnuNew_Click;
			// 
			// mnuOpen
			// 
			mnuOpen.Image = (Image)resources.GetObject("mnuOpen.Image");
			mnuOpen.ImageTransparentColor = Color.Magenta;
			mnuOpen.Name = "mnuOpen";
			mnuOpen.ShortcutKeys = Keys.Control | Keys.O;
			mnuOpen.Size = new Size(194, 22);
			mnuOpen.Text = "&Open Shortcut";
			mnuOpen.Click += mnuOpen_Click;
			// 
			// toolStripSeparator
			// 
			toolStripSeparator.Name = "toolStripSeparator";
			toolStripSeparator.Size = new Size(191, 6);
			// 
			// mnuSave
			// 
			mnuSave.Image = (Image)resources.GetObject("mnuSave.Image");
			mnuSave.ImageTransparentColor = Color.Magenta;
			mnuSave.Name = "mnuSave";
			mnuSave.ShortcutKeys = Keys.Control | Keys.S;
			mnuSave.Size = new Size(194, 22);
			mnuSave.Text = "&Save Shortcut";
			mnuSave.Click += mnuSave_Click;
			// 
			// mnuSaveAs
			// 
			mnuSaveAs.Name = "mnuSaveAs";
			mnuSaveAs.Size = new Size(194, 22);
			mnuSaveAs.Text = "Save Shortcut &As";
			mnuSaveAs.Click += mnuSaveAs_Click;
			// 
			// mnuSaveGlobals
			// 
			mnuSaveGlobals.Image = (Image)resources.GetObject("mnuSaveGlobals.Image");
			mnuSaveGlobals.ImageTransparentColor = Color.Magenta;
			mnuSaveGlobals.Name = "mnuSaveGlobals";
			mnuSaveGlobals.Size = new Size(194, 22);
			mnuSaveGlobals.Text = "Save &Globals";
			mnuSaveGlobals.Click += mnuSaveGlobals_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(191, 6);
			// 
			// mnuExit
			// 
			mnuExit.Name = "mnuExit";
			mnuExit.Size = new Size(194, 22);
			mnuExit.Text = "E&xit";
			mnuExit.Click += mnuExit_Click;
			// 
			// mnuTools
			// 
			mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuOptions });
			mnuTools.Name = "mnuTools";
			mnuTools.Size = new Size(46, 20);
			mnuTools.Text = "&Tools";
			// 
			// mnuOptions
			// 
			mnuOptions.Name = "mnuOptions";
			mnuOptions.Size = new Size(116, 22);
			mnuOptions.Text = "&Options";
			mnuOptions.Click += mnuOptions_Click;
			// 
			// mnuHelp
			// 
			mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuInfo, toolStripSeparator5, mnuAbout });
			mnuHelp.Name = "mnuHelp";
			mnuHelp.Size = new Size(44, 20);
			mnuHelp.Text = "&Help";
			// 
			// mnuInfo
			// 
			mnuInfo.Name = "mnuInfo";
			mnuInfo.Size = new Size(116, 22);
			mnuInfo.Text = "&Info";
			mnuInfo.Click += mnuInfo_Click;
			// 
			// toolStripSeparator5
			// 
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new Size(113, 6);
			// 
			// mnuAbout
			// 
			mnuAbout.Name = "mnuAbout";
			mnuAbout.Size = new Size(116, 22);
			mnuAbout.Text = "&About...";
			mnuAbout.Click += mnuAbout_Click;
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
			pbBgMainMenuStrip.Dock = DockStyle.Top;
			pbBgMainMenuStrip.Location = new Point(0, 0);
			pbBgMainMenuStrip.Name = "pbBgMainMenuStrip";
			pbBgMainMenuStrip.Size = new Size(1259, 24);
			pbBgMainMenuStrip.TabIndex = 205;
			pbBgMainMenuStrip.TabStop = false;
			// 
			// txtOutput
			// 
			txtOutput.BackColor = SystemColors.Window;
			txtOutput.Location = new Point(12, 647);
			txtOutput.Name = "txtOutput";
			txtOutput.ReadOnly = true;
			txtOutput.Size = new Size(1231, 201);
			txtOutput.TabIndex = 206;
			txtOutput.Text = "";
			// 
			// MainForm
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1259, 860);
			Controls.Add(txtOutput);
			Controls.Add(mainMenuStripContainer);
			Controls.Add(lblIsRegistered);
			Controls.Add(label2);
			Controls.Add(tabsContainer);
			Controls.Add(txtShortcutFilePath);
			Controls.Add(btnRemoveAssoc);
			Controls.Add(btnAssoc);
			Controls.Add(label1);
			Controls.Add(radGlobal);
			Controls.Add(radShortcut);
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
			DragDrop += MainForm_DragDrop;
			DragEnter += MainForm_DragEnter;
			tabsContainer.ResumeLayout(false);
			tabGeneral.ResumeLayout(false);
			tabGeneral.PerformLayout();
			tabCpu.ResumeLayout(false);
			tabCpu.PerformLayout();
			tabAutoexec.ResumeLayout(false);
			tabAutoexec.PerformLayout();
			tabCustom.ResumeLayout(false);
			tabCustom.PerformLayout();
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
		private Label lblIsRegistered;
		private TabPage tabGeneral;
		private MenuStrip mainMenuStrip;
		private ToolStripMenuItem mnuFile;
		private ToolStripMenuItem mnuNew;
		private ToolStripMenuItem mnuOpen;
		private ToolStripSeparator toolStripSeparator;
		private ToolStripMenuItem mnuSave;
		private ToolStripMenuItem mnuSaveAs;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem mnuExit;
		private ToolStripMenuItem mnuTools;
		private ToolStripMenuItem mnuOptions;
		private ToolStripMenuItem mnuHelp;
		private ToolStripMenuItem mnuInfo;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripMenuItem mnuAbout;
		private ToolStripContainer mainMenuStripContainer;
		private PictureBox pbBgMainMenuStrip;
		private ToolStripMenuItem mnuSaveGlobals;
		private TextBox txtName;
		private Label lblName;
		private TextBox txtDescription;
		private Label lblDescription;
		private CheckBox cbBaseDirSet;
		private Label label6;
		private TextBox txtBaseDir;
		private Label lblBaseDir;
		private CheckBox cbExecutableSet;
		private TextBox txtExecutable;
		private Label lblExecutable;
		private ComboBox comboLimitBaseDirToOneGiB;
		private CheckBox cbLimitBaseDirToOneGiBSet;
		private Label lblLimitBaseDirToOneGiB;
		private Label lblNameDescriptionNote;
		private CheckBox cbCyclesSet;
		private Label label4;
		private TextBox txtCycles;
		private Label lblCycles;
		private RichTextBox txtOutput;
		private OpenFileDialog openFileDialog;
		private SaveFileDialog saveFileDialog;
		private Button btnExecutableBrowse;
		private TabPage tabAutoexec;
		private TextBox txtPreAutoexec;
		private TextBox txtPostAutoexec;
		private Label lblAutoexecScript;
		private Label lblAutoexecEllipsis;
		private TextBox txtAutoexec;
		private Button btnAddCustomSetting;
		private FlowLayoutPanel flowPnlCustom;
		private Label lblHeadingValue;
		private Label lblHeadingKey;
		private Label lblHeadingSection;
	}
}
