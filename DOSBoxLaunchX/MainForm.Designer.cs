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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			label1 = new Label();
			txtShortcutFilePath = new TextBox();
			tabsContainer = new TabControl();
			tabGeneral = new TabPage();
			lblNotApplicable = new DOSBoxLaunchX.Controls.TransparentLabel();
			txtDescription = new TextBox();
			btnExecutableBrowse = new Button();
			lblNameDescriptionNote = new Label();
			comboLimitBaseDirFreeSpace = new ComboBox();
			cbLimitBaseDirFreeSpaceSet = new CheckBox();
			lblLimitBaseDirFreeSpace = new Label();
			cbExecutableSet = new CheckBox();
			txtExecutable = new TextBox();
			lblExecutable = new Label();
			cbBaseDirSet = new CheckBox();
			lblGeneralSet = new Label();
			txtBaseDir = new TextBox();
			lblBaseDir = new Label();
			lblDescription = new Label();
			txtName = new TextBox();
			lblName = new Label();
			tabCpu = new TabPage();
			comboCycleDown = new ComboBox();
			cbCycleDown = new CheckBox();
			lblCycleDown = new Label();
			comboCycleUp = new ComboBox();
			cbCycleUp = new CheckBox();
			lblCycleUp = new Label();
			comboCycles = new ComboBox();
			cbCyclesSet = new CheckBox();
			lblCycles = new Label();
			comboCore = new ComboBox();
			cbCoreSet = new CheckBox();
			lblCpuSet = new Label();
			lblCore = new Label();
			tabVideo = new TabPage();
			lblVideoSet = new Label();
			comboFrameskip = new ComboBox();
			cbFrameskipSet = new CheckBox();
			lblFrameskip = new Label();
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
			grpMapperNotFound = new GroupBox();
			lblMapperNotFound = new Label();
			btnMapperRescan = new Button();
			dataGridMappings = new DataGridView();
			mainMenuStrip = new MenuStrip();
			mnuFile = new ToolStripMenuItem();
			mnuNew = new ToolStripMenuItem();
			mnuOpen = new ToolStripMenuItem();
			toolStripSeparator10 = new ToolStripSeparator();
			mnuSave = new ToolStripMenuItem();
			mnuSaveAs = new ToolStripMenuItem();
			toolStripSeparator11 = new ToolStripSeparator();
			mnuEditGlobals = new ToolStripMenuItem();
			toolStripSeparator12 = new ToolStripSeparator();
			mnuExit = new ToolStripMenuItem();
			mnuTools = new ToolStripMenuItem();
			mnuOptions = new ToolStripMenuItem();
			mnuHelp = new ToolStripMenuItem();
			mnuInfo = new ToolStripMenuItem();
			toolStripSeparator30 = new ToolStripSeparator();
			mnuAbout = new ToolStripMenuItem();
			mainMenuStripContainer = new ToolStripContainer();
			pbBgMainMenuStrip = new PictureBox();
			openFileDialog = new OpenFileDialog();
			saveFileDialog = new SaveFileDialog();
			timerRefreshNa = new System.Windows.Forms.Timer(components);
			comboVideoOutput = new ComboBox();
			cbVideoOutputSet = new CheckBox();
			lblVideoOutput = new Label();
			tabsContainer.SuspendLayout();
			tabGeneral.SuspendLayout();
			tabCpu.SuspendLayout();
			tabVideo.SuspendLayout();
			tabAutoexec.SuspendLayout();
			tabCustom.SuspendLayout();
			tabKbMappings.SuspendLayout();
			grpMapperNotFound.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridMappings).BeginInit();
			mainMenuStrip.SuspendLayout();
			mainMenuStripContainer.TopToolStripPanel.SuspendLayout();
			mainMenuStripContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pbBgMainMenuStrip).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 34);
			label1.Name = "label1";
			label1.Size = new Size(128, 15);
			label1.TabIndex = 3;
			label1.Text = "Editing config settings:";
			// 
			// txtShortcutFilePath
			// 
			txtShortcutFilePath.BackColor = Color.WhiteSmoke;
			txtShortcutFilePath.Location = new Point(146, 31);
			txtShortcutFilePath.Name = "txtShortcutFilePath";
			txtShortcutFilePath.ReadOnly = true;
			txtShortcutFilePath.Size = new Size(1099, 23);
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
			tabsContainer.Location = new Point(12, 59);
			tabsContainer.Name = "tabsContainer";
			tabsContainer.SelectedIndex = 0;
			tabsContainer.Size = new Size(1235, 556);
			tabsContainer.TabIndex = 100;
			// 
			// tabGeneral
			// 
			tabGeneral.BackColor = SystemColors.Control;
			tabGeneral.Controls.Add(lblNotApplicable);
			tabGeneral.Controls.Add(txtDescription);
			tabGeneral.Controls.Add(btnExecutableBrowse);
			tabGeneral.Controls.Add(lblNameDescriptionNote);
			tabGeneral.Controls.Add(comboLimitBaseDirFreeSpace);
			tabGeneral.Controls.Add(cbLimitBaseDirFreeSpaceSet);
			tabGeneral.Controls.Add(lblLimitBaseDirFreeSpace);
			tabGeneral.Controls.Add(cbExecutableSet);
			tabGeneral.Controls.Add(txtExecutable);
			tabGeneral.Controls.Add(lblExecutable);
			tabGeneral.Controls.Add(cbBaseDirSet);
			tabGeneral.Controls.Add(lblGeneralSet);
			tabGeneral.Controls.Add(txtBaseDir);
			tabGeneral.Controls.Add(lblBaseDir);
			tabGeneral.Controls.Add(lblDescription);
			tabGeneral.Controls.Add(txtName);
			tabGeneral.Controls.Add(lblName);
			tabGeneral.Location = new Point(4, 24);
			tabGeneral.Name = "tabGeneral";
			tabGeneral.Size = new Size(1227, 528);
			tabGeneral.TabIndex = 6;
			tabGeneral.Text = "General";
			// 
			// lblNotApplicable
			// 
			lblNotApplicable.Font = new Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblNotApplicable.ForeColor = SystemColors.GrayText;
			lblNotApplicable.Location = new Point(59, 7);
			lblNotApplicable.Name = "lblNotApplicable";
			lblNotApplicable.Size = new Size(27, 19);
			lblNotApplicable.TabIndex = 54;
			lblNotApplicable.TabStop = false;
			lblNotApplicable.Text = "N/A";
			lblNotApplicable.TextAlign = ContentAlignment.TopLeft;
			// 
			// txtDescription
			// 
			txtDescription.Location = new Point(127, 54);
			txtDescription.Multiline = true;
			txtDescription.Name = "txtDescription";
			txtDescription.ScrollBars = ScrollBars.Vertical;
			txtDescription.Size = new Size(470, 85);
			txtDescription.TabIndex = 21;
			txtDescription.Tag = "nl=true";
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
			lblNameDescriptionNote.Size = new Size(451, 15);
			lblNameDescriptionNote.TabIndex = 19;
			lblNameDescriptionNote.Text = "(Name/Description are purely descriptive and don't affect the DOSBox configuration)";
			// 
			// comboLimitBaseDirFreeSpace
			// 
			comboLimitBaseDirFreeSpace.DropDownStyle = ComboBoxStyle.DropDownList;
			comboLimitBaseDirFreeSpace.FormattingEnabled = true;
			comboLimitBaseDirFreeSpace.Items.AddRange(new object[] { "10MiB", "64MiB", "128MiB", "512MiB", "1GiB (1024MiB)" });
			comboLimitBaseDirFreeSpace.Location = new Point(258, 174);
			comboLimitBaseDirFreeSpace.Name = "comboLimitBaseDirFreeSpace";
			comboLimitBaseDirFreeSpace.Size = new Size(110, 23);
			comboLimitBaseDirFreeSpace.TabIndex = 41;
			comboLimitBaseDirFreeSpace.Tag = "cb=cbLimitBaseDirFreeSpaceSet|assoc=lblLimitBaseDirFreeSpace";
			// 
			// cbLimitBaseDirFreeSpaceSet
			// 
			cbLimitBaseDirFreeSpaceSet.AutoSize = true;
			cbLimitBaseDirFreeSpaceSet.Location = new Point(11, 178);
			cbLimitBaseDirFreeSpaceSet.Name = "cbLimitBaseDirFreeSpaceSet";
			cbLimitBaseDirFreeSpaceSet.Size = new Size(15, 14);
			cbLimitBaseDirFreeSpaceSet.TabIndex = 40;
			cbLimitBaseDirFreeSpaceSet.Tag = "";
			cbLimitBaseDirFreeSpaceSet.UseVisualStyleBackColor = true;
			// 
			// lblLimitBaseDirFreeSpace
			// 
			lblLimitBaseDirFreeSpace.AutoSize = true;
			lblLimitBaseDirFreeSpace.Location = new Point(36, 177);
			lblLimitBaseDirFreeSpace.Name = "lblLimitBaseDirFreeSpace";
			lblLimitBaseDirFreeSpace.Size = new Size(216, 15);
			lblLimitBaseDirFreeSpace.TabIndex = 15;
			lblLimitBaseDirFreeSpace.Text = "^ Limit reported free hard disk space at:";
			// 
			// cbExecutableSet
			// 
			cbExecutableSet.AutoSize = true;
			cbExecutableSet.Location = new Point(11, 207);
			cbExecutableSet.Name = "cbExecutableSet";
			cbExecutableSet.Size = new Size(15, 14);
			cbExecutableSet.TabIndex = 50;
			cbExecutableSet.Tag = "";
			cbExecutableSet.UseVisualStyleBackColor = true;
			// 
			// txtExecutable
			// 
			txtExecutable.Location = new Point(127, 203);
			txtExecutable.Name = "txtExecutable";
			txtExecutable.Size = new Size(389, 23);
			txtExecutable.TabIndex = 51;
			txtExecutable.Tag = "cb=cbExecutableSet|assoc=lblExecutable,btnExecutableBrowse";
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
			cbBaseDirSet.Tag = "";
			cbBaseDirSet.UseVisualStyleBackColor = true;
			// 
			// lblGeneralSet
			// 
			lblGeneralSet.AutoSize = true;
			lblGeneralSet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblGeneralSet.Location = new Point(5, 7);
			lblGeneralSet.Name = "lblGeneralSet";
			lblGeneralSet.Size = new Size(26, 15);
			lblGeneralSet.TabIndex = 6;
			lblGeneralSet.Text = "Set";
			// 
			// txtBaseDir
			// 
			txtBaseDir.Location = new Point(127, 145);
			txtBaseDir.Name = "txtBaseDir";
			txtBaseDir.Size = new Size(470, 23);
			txtBaseDir.TabIndex = 31;
			txtBaseDir.Tag = "cb=cbBaseDirSet|assoc=lblBaseDir";
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
			txtName.Tag = "nl=false";
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
			tabCpu.Controls.Add(comboCycleDown);
			tabCpu.Controls.Add(cbCycleDown);
			tabCpu.Controls.Add(lblCycleDown);
			tabCpu.Controls.Add(comboCycleUp);
			tabCpu.Controls.Add(cbCycleUp);
			tabCpu.Controls.Add(lblCycleUp);
			tabCpu.Controls.Add(comboCycles);
			tabCpu.Controls.Add(cbCyclesSet);
			tabCpu.Controls.Add(lblCycles);
			tabCpu.Controls.Add(comboCore);
			tabCpu.Controls.Add(cbCoreSet);
			tabCpu.Controls.Add(lblCpuSet);
			tabCpu.Controls.Add(lblCore);
			tabCpu.Location = new Point(4, 24);
			tabCpu.Name = "tabCpu";
			tabCpu.Padding = new Padding(3);
			tabCpu.Size = new Size(1227, 528);
			tabCpu.TabIndex = 0;
			tabCpu.Text = "CPU";
			// 
			// comboCycleDown
			// 
			comboCycleDown.FormattingEnabled = true;
			comboCycleDown.Items.AddRange(new object[] { "10", "20", "500", "1000", "5000" });
			comboCycleDown.Location = new Point(127, 112);
			comboCycleDown.Name = "comboCycleDown";
			comboCycleDown.Size = new Size(470, 23);
			comboCycleDown.TabIndex = 41;
			comboCycleDown.Tag = "cb=cbCycleDown|assoc=lblCycleDown|setting=cpu.cycledown";
			// 
			// cbCycleDown
			// 
			cbCycleDown.AutoSize = true;
			cbCycleDown.Location = new Point(11, 116);
			cbCycleDown.Name = "cbCycleDown";
			cbCycleDown.Size = new Size(15, 14);
			cbCycleDown.TabIndex = 40;
			cbCycleDown.Tag = "";
			cbCycleDown.UseVisualStyleBackColor = true;
			// 
			// lblCycleDown
			// 
			lblCycleDown.AutoSize = true;
			lblCycleDown.Location = new Point(36, 115);
			lblCycleDown.Name = "lblCycleDown";
			lblCycleDown.Size = new Size(72, 15);
			lblCycleDown.TabIndex = 43;
			lblCycleDown.Text = "Cycle down:";
			// 
			// comboCycleUp
			// 
			comboCycleUp.FormattingEnabled = true;
			comboCycleUp.Items.AddRange(new object[] { "10", "20", "500", "1000", "5000" });
			comboCycleUp.Location = new Point(127, 83);
			comboCycleUp.Name = "comboCycleUp";
			comboCycleUp.Size = new Size(470, 23);
			comboCycleUp.TabIndex = 31;
			comboCycleUp.Tag = "cb=cbCycleUp|assoc=lblCycleUp|setting=cpu.cycleup";
			// 
			// cbCycleUp
			// 
			cbCycleUp.AutoSize = true;
			cbCycleUp.Location = new Point(11, 87);
			cbCycleUp.Name = "cbCycleUp";
			cbCycleUp.Size = new Size(15, 14);
			cbCycleUp.TabIndex = 30;
			cbCycleUp.Tag = "";
			cbCycleUp.UseVisualStyleBackColor = true;
			// 
			// lblCycleUp
			// 
			lblCycleUp.AutoSize = true;
			lblCycleUp.Location = new Point(36, 86);
			lblCycleUp.Name = "lblCycleUp";
			lblCycleUp.Size = new Size(56, 15);
			lblCycleUp.TabIndex = 40;
			lblCycleUp.Text = "Cycle up:";
			// 
			// comboCycles
			// 
			comboCycles.FormattingEnabled = true;
			comboCycles.Items.AddRange(new object[] { "auto", "max", "30000", "60000", "100000", "150000" });
			comboCycles.Location = new Point(127, 54);
			comboCycles.Name = "comboCycles";
			comboCycles.Size = new Size(470, 23);
			comboCycles.TabIndex = 21;
			comboCycles.Tag = "cb=cbCyclesSet|assoc=lblCycles|setting=cpu.cycles";
			// 
			// cbCyclesSet
			// 
			cbCyclesSet.AutoSize = true;
			cbCyclesSet.Location = new Point(11, 58);
			cbCyclesSet.Name = "cbCyclesSet";
			cbCyclesSet.Size = new Size(15, 14);
			cbCyclesSet.TabIndex = 20;
			cbCyclesSet.Tag = "";
			cbCyclesSet.UseVisualStyleBackColor = true;
			// 
			// lblCycles
			// 
			lblCycles.AutoSize = true;
			lblCycles.Location = new Point(36, 57);
			lblCycles.Name = "lblCycles";
			lblCycles.Size = new Size(44, 15);
			lblCycles.TabIndex = 37;
			lblCycles.Text = "Cycles:";
			// 
			// comboCore
			// 
			comboCore.FormattingEnabled = true;
			comboCore.Items.AddRange(new object[] { "auto", "normal", "full", "dynamic", "simple" });
			comboCore.Location = new Point(127, 25);
			comboCore.Name = "comboCore";
			comboCore.Size = new Size(470, 23);
			comboCore.TabIndex = 11;
			comboCore.Tag = "cb=cbCoreSet|assoc=lblCore|setting=cpu.core";
			// 
			// cbCoreSet
			// 
			cbCoreSet.AutoSize = true;
			cbCoreSet.Location = new Point(11, 29);
			cbCoreSet.Name = "cbCoreSet";
			cbCoreSet.Size = new Size(15, 14);
			cbCoreSet.TabIndex = 10;
			cbCoreSet.Tag = "";
			cbCoreSet.UseVisualStyleBackColor = true;
			// 
			// lblCpuSet
			// 
			lblCpuSet.AutoSize = true;
			lblCpuSet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblCpuSet.Location = new Point(5, 7);
			lblCpuSet.Name = "lblCpuSet";
			lblCpuSet.Size = new Size(26, 15);
			lblCpuSet.TabIndex = 35;
			lblCpuSet.Text = "Set";
			// 
			// lblCore
			// 
			lblCore.AutoSize = true;
			lblCore.Location = new Point(36, 28);
			lblCore.Name = "lblCore";
			lblCore.Size = new Size(35, 15);
			lblCore.TabIndex = 34;
			lblCore.Text = "Core:";
			// 
			// tabVideo
			// 
			tabVideo.BackColor = SystemColors.Control;
			tabVideo.Controls.Add(comboVideoOutput);
			tabVideo.Controls.Add(cbVideoOutputSet);
			tabVideo.Controls.Add(lblVideoOutput);
			tabVideo.Controls.Add(lblVideoSet);
			tabVideo.Controls.Add(comboFrameskip);
			tabVideo.Controls.Add(cbFrameskipSet);
			tabVideo.Controls.Add(lblFrameskip);
			tabVideo.Location = new Point(4, 24);
			tabVideo.Name = "tabVideo";
			tabVideo.Padding = new Padding(3);
			tabVideo.Size = new Size(1227, 528);
			tabVideo.TabIndex = 1;
			tabVideo.Text = "Video";
			// 
			// lblVideoSet
			// 
			lblVideoSet.AutoSize = true;
			lblVideoSet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblVideoSet.Location = new Point(5, 7);
			lblVideoSet.Name = "lblVideoSet";
			lblVideoSet.Size = new Size(26, 15);
			lblVideoSet.TabIndex = 47;
			lblVideoSet.Text = "Set";
			// 
			// comboFrameskip
			// 
			comboFrameskip.FormattingEnabled = true;
			comboFrameskip.Items.AddRange(new object[] { "0", "5", "10", "20" });
			comboFrameskip.Location = new Point(127, 25);
			comboFrameskip.Name = "comboFrameskip";
			comboFrameskip.Size = new Size(470, 23);
			comboFrameskip.TabIndex = 45;
			comboFrameskip.Tag = "cb=cbFrameskipSet|assoc=lblFrameskip|setting=render.frameskip";
			// 
			// cbFrameskipSet
			// 
			cbFrameskipSet.AutoSize = true;
			cbFrameskipSet.Location = new Point(11, 29);
			cbFrameskipSet.Name = "cbFrameskipSet";
			cbFrameskipSet.Size = new Size(15, 14);
			cbFrameskipSet.TabIndex = 44;
			cbFrameskipSet.Tag = "";
			cbFrameskipSet.UseVisualStyleBackColor = true;
			// 
			// lblFrameskip
			// 
			lblFrameskip.AutoSize = true;
			lblFrameskip.Location = new Point(36, 28);
			lblFrameskip.Name = "lblFrameskip";
			lblFrameskip.Size = new Size(64, 15);
			lblFrameskip.TabIndex = 46;
			lblFrameskip.Text = "Frameskip:";
			// 
			// tabAudio
			// 
			tabAudio.BackColor = SystemColors.Control;
			tabAudio.Location = new Point(4, 24);
			tabAudio.Name = "tabAudio";
			tabAudio.Size = new Size(1227, 528);
			tabAudio.TabIndex = 2;
			tabAudio.Text = "Audio";
			// 
			// tabPeripherals
			// 
			tabPeripherals.BackColor = SystemColors.Control;
			tabPeripherals.Location = new Point(4, 24);
			tabPeripherals.Name = "tabPeripherals";
			tabPeripherals.Size = new Size(1227, 528);
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
			tabAutoexec.Size = new Size(1227, 528);
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
			txtAutoexec.Size = new Size(1211, 383);
			txtAutoexec.TabIndex = 20;
			txtAutoexec.Tag = "nl=true";
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
			txtPostAutoexec.Location = new Point(8, 481);
			txtPostAutoexec.Multiline = true;
			txtPostAutoexec.Name = "txtPostAutoexec";
			txtPostAutoexec.ReadOnly = true;
			txtPostAutoexec.ScrollBars = ScrollBars.Vertical;
			txtPostAutoexec.Size = new Size(1211, 39);
			txtPostAutoexec.TabIndex = 100;
			txtPostAutoexec.Tag = "ignore=true";
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
			txtPreAutoexec.Tag = "ignore=true";
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
			tabCustom.Size = new Size(1227, 528);
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
			flowPnlCustom.Size = new Size(1227, 471);
			flowPnlCustom.TabIndex = 50;
			// 
			// btnAddCustomSetting
			// 
			btnAddCustomSetting.Location = new Point(5, 502);
			btnAddCustomSetting.Name = "btnAddCustomSetting";
			btnAddCustomSetting.Size = new Size(212, 23);
			btnAddCustomSetting.TabIndex = 1;
			btnAddCustomSetting.Text = "Add new custom setting";
			btnAddCustomSetting.UseVisualStyleBackColor = true;
			btnAddCustomSetting.Click += btnAddCustomSetting_Click;
			// 
			// tabKbMappings
			// 
			tabKbMappings.BackColor = SystemColors.Control;
			tabKbMappings.Controls.Add(grpMapperNotFound);
			tabKbMappings.Controls.Add(dataGridMappings);
			tabKbMappings.Location = new Point(4, 24);
			tabKbMappings.Name = "tabKbMappings";
			tabKbMappings.Size = new Size(1227, 528);
			tabKbMappings.TabIndex = 5;
			tabKbMappings.Text = "Keyboard mappings";
			// 
			// grpMapperNotFound
			// 
			grpMapperNotFound.Controls.Add(lblMapperNotFound);
			grpMapperNotFound.Controls.Add(btnMapperRescan);
			grpMapperNotFound.Location = new Point(440, 2);
			grpMapperNotFound.Name = "grpMapperNotFound";
			grpMapperNotFound.Size = new Size(274, 78);
			grpMapperNotFound.TabIndex = 200;
			grpMapperNotFound.TabStop = false;
			// 
			// lblMapperNotFound
			// 
			lblMapperNotFound.AutoSize = true;
			lblMapperNotFound.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
			lblMapperNotFound.Location = new Point(6, 21);
			lblMapperNotFound.Name = "lblMapperNotFound";
			lblMapperNotFound.Size = new Size(264, 15);
			lblMapperNotFound.TabIndex = 101;
			lblMapperNotFound.Text = "Mapper file not found in base DOSBox directory...";
			// 
			// btnMapperRescan
			// 
			btnMapperRescan.Location = new Point(97, 43);
			btnMapperRescan.Name = "btnMapperRescan";
			btnMapperRescan.Size = new Size(75, 23);
			btnMapperRescan.TabIndex = 102;
			btnMapperRescan.Text = "Rescan";
			btnMapperRescan.UseVisualStyleBackColor = true;
			btnMapperRescan.Click += btnMapperRescan_Click;
			// 
			// dataGridMappings
			// 
			dataGridMappings.BackgroundColor = SystemColors.Control;
			dataGridMappings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridMappings.Location = new Point(0, 0);
			dataGridMappings.Name = "dataGridMappings";
			dataGridMappings.Size = new Size(1227, 528);
			dataGridMappings.TabIndex = 111;
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
			mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuNew, mnuOpen, toolStripSeparator10, mnuSave, mnuSaveAs, toolStripSeparator11, mnuEditGlobals, toolStripSeparator12, mnuExit });
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
			// toolStripSeparator10
			// 
			toolStripSeparator10.Name = "toolStripSeparator10";
			toolStripSeparator10.Size = new Size(191, 6);
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
			// toolStripSeparator11
			// 
			toolStripSeparator11.Name = "toolStripSeparator11";
			toolStripSeparator11.Size = new Size(191, 6);
			// 
			// mnuEditGlobals
			// 
			mnuEditGlobals.ImageTransparentColor = Color.Magenta;
			mnuEditGlobals.Name = "mnuEditGlobals";
			mnuEditGlobals.Size = new Size(194, 22);
			mnuEditGlobals.Text = "Edit &Globals";
			mnuEditGlobals.Click += mnuEditGlobals_Click;
			// 
			// toolStripSeparator12
			// 
			toolStripSeparator12.Name = "toolStripSeparator12";
			toolStripSeparator12.Size = new Size(191, 6);
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
			mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuInfo, toolStripSeparator30, mnuAbout });
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
			// toolStripSeparator30
			// 
			toolStripSeparator30.Name = "toolStripSeparator30";
			toolStripSeparator30.Size = new Size(113, 6);
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
			// timerRefreshNa
			// 
			timerRefreshNa.Interval = 1000;
			timerRefreshNa.Tick += timerRefreshNa_Tick;
			// 
			// comboVideoOutput
			// 
			comboVideoOutput.FormattingEnabled = true;
			comboVideoOutput.Items.AddRange(new object[] { "default", "ttf", "surface", "overlay", "opengl", "openglpp", "openglnb", "openglhq", "ddraw", "direct3d" });
			comboVideoOutput.Location = new Point(127, 54);
			comboVideoOutput.Name = "comboVideoOutput";
			comboVideoOutput.Size = new Size(470, 23);
			comboVideoOutput.TabIndex = 49;
			comboVideoOutput.Tag = "cb=cbVideoOutputSet|assoc=lblVideoOutput|setting=sdl.output";
			// 
			// cbVideoOutputSet
			// 
			cbVideoOutputSet.AutoSize = true;
			cbVideoOutputSet.Location = new Point(11, 58);
			cbVideoOutputSet.Name = "cbVideoOutputSet";
			cbVideoOutputSet.Size = new Size(15, 14);
			cbVideoOutputSet.TabIndex = 48;
			cbVideoOutputSet.Tag = "";
			cbVideoOutputSet.UseVisualStyleBackColor = true;
			// 
			// lblVideoOutput
			// 
			lblVideoOutput.AutoSize = true;
			lblVideoOutput.Location = new Point(36, 57);
			lblVideoOutput.Name = "lblVideoOutput";
			lblVideoOutput.Size = new Size(48, 15);
			lblVideoOutput.TabIndex = 50;
			lblVideoOutput.Text = "Output:";
			// 
			// MainForm
			// 
			AllowDrop = true;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1259, 625);
			Controls.Add(mainMenuStripContainer);
			Controls.Add(tabsContainer);
			Controls.Add(txtShortcutFilePath);
			Controls.Add(label1);
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
			tabVideo.ResumeLayout(false);
			tabVideo.PerformLayout();
			tabAutoexec.ResumeLayout(false);
			tabAutoexec.PerformLayout();
			tabCustom.ResumeLayout(false);
			tabCustom.PerformLayout();
			tabKbMappings.ResumeLayout(false);
			grpMapperNotFound.ResumeLayout(false);
			grpMapperNotFound.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridMappings).EndInit();
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
		private Label label1;
		private TextBox txtShortcutFilePath;
		private TabControl tabsContainer;
		private TabPage tabCpu;
		private TabPage tabVideo;
		private TabPage tabAudio;
		private TabPage tabPeripherals;
		private TabPage tabCustom;
		private TabPage tabKbMappings;
		private TabPage tabGeneral;
		private MenuStrip mainMenuStrip;
		private ToolStripMenuItem mnuFile;
		private ToolStripMenuItem mnuNew;
		private ToolStripMenuItem mnuOpen;
		private ToolStripSeparator toolStripSeparator10;
		private ToolStripMenuItem mnuSave;
		private ToolStripMenuItem mnuSaveAs;
		private ToolStripSeparator toolStripSeparator12;
		private ToolStripMenuItem mnuExit;
		private ToolStripMenuItem mnuTools;
		private ToolStripMenuItem mnuOptions;
		private ToolStripMenuItem mnuHelp;
		private ToolStripMenuItem mnuInfo;
		private ToolStripSeparator toolStripSeparator30;
		private ToolStripMenuItem mnuAbout;
		private ToolStripContainer mainMenuStripContainer;
		private PictureBox pbBgMainMenuStrip;
		private ToolStripMenuItem mnuEditGlobals;
		private TextBox txtName;
		private Label lblName;
		private TextBox txtDescription;
		private Label lblDescription;
		private CheckBox cbBaseDirSet;
		private Label lblGeneralSet;
		private TextBox txtBaseDir;
		private Label lblBaseDir;
		private CheckBox cbExecutableSet;
		private TextBox txtExecutable;
		private Label lblExecutable;
		private ComboBox comboLimitBaseDirFreeSpace;
		private CheckBox cbLimitBaseDirFreeSpaceSet;
		private Label lblLimitBaseDirFreeSpace;
		private Label lblNameDescriptionNote;
		private CheckBox cbCoreSet;
		private Label lblCpuSet;
		private Label lblCore;
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
		private Controls.TransparentLabel lblNotApplicable;
		private ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.Timer timerRefreshNa;
		private GroupBox grpMapperNotFound;
		private Label lblMapperNotFound;
		private Button btnMapperRescan;
		private DataGridView dataGridMappings;
		private ComboBox comboCore;
		private Label lblCycles;
		private CheckBox cbCyclesSet;
		private ComboBox comboCycles;
		private ComboBox comboCycleDown;
		private CheckBox cbCycleDown;
		private Label lblCycleDown;
		private ComboBox comboCycleUp;
		private CheckBox cbCycleUp;
		private Label lblCycleUp;
		private Label lblVideoSet;
		private ComboBox comboFrameskip;
		private CheckBox cbFrameskipSet;
		private Label lblFrameskip;
		private ComboBox comboVideoOutput;
		private CheckBox cbVideoOutputSet;
		private Label lblVideoOutput;
	}
}
