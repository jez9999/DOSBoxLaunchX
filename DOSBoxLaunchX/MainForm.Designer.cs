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
			comboMemSize = new ComboBox();
			cbMemSizeSet = new CheckBox();
			lblMemSize = new Label();
			comboMachine = new ComboBox();
			cbMachineSet = new CheckBox();
			lblMachine = new Label();
			comboCycleDown = new ComboBox();
			cbCycleDownSet = new CheckBox();
			lblCycleDown = new Label();
			comboCycleUp = new ComboBox();
			cbCycleUpSet = new CheckBox();
			lblCycleUp = new Label();
			comboCycles = new ComboBox();
			cbCyclesSet = new CheckBox();
			lblCycles = new Label();
			comboCore = new ComboBox();
			cbCoreSet = new CheckBox();
			lblCpuSet = new Label();
			lblCore = new Label();
			tabVideo = new TabPage();
			comboRefreshRate = new ComboBox();
			cbRefreshRateSet = new CheckBox();
			lblRefreshRate = new Label();
			comboDoublescan = new ComboBox();
			cbDoublescanSet = new CheckBox();
			lblDoublescan = new Label();
			comboScaler = new ComboBox();
			cbScalerSet = new CheckBox();
			lblScaler = new Label();
			comboVideoOutput = new ComboBox();
			cbVideoOutputSet = new CheckBox();
			lblVideoOutput = new Label();
			lblVideoSet = new Label();
			comboFrameskip = new ComboBox();
			cbFrameskipSet = new CheckBox();
			lblFrameskip = new Label();
			tabAudio = new TabPage();
			comboTandySound = new ComboBox();
			cbTandySoundSet = new CheckBox();
			lblTandySound = new Label();
			comboPcSpeaker = new ComboBox();
			cbPcSpeakerSet = new CheckBox();
			lblPcSpeaker = new Label();
			groupBox1 = new GroupBox();
			comboSbHighDma = new ComboBox();
			cbSbHighDmaSet = new CheckBox();
			lblSbHighDma = new Label();
			comboSbDma = new ComboBox();
			cbSbDmaSet = new CheckBox();
			lblSbDma = new Label();
			comboSbIrq = new ComboBox();
			cbSbIrqSet = new CheckBox();
			lblSbIrq = new Label();
			comboSbBase = new ComboBox();
			cbSbBaseSet = new CheckBox();
			lblSbBase = new Label();
			comboSbType = new ComboBox();
			cbSbTypeSet = new CheckBox();
			lblSbType = new Label();
			grpMidi = new GroupBox();
			btnMt32RomDirBrowse = new Button();
			comboMt32Model = new ComboBox();
			cbMt32ModelSet = new CheckBox();
			lblMt32Model = new Label();
			txtMt32RomDir = new TextBox();
			cbMt32RomDirSet = new CheckBox();
			lblMt32RomDir = new Label();
			comboMidiDevice = new ComboBox();
			cbMidiDeviceSet = new CheckBox();
			lblMidiDevice = new Label();
			comboMpu401 = new ComboBox();
			cbMpu401Set = new CheckBox();
			lblMpu401 = new Label();
			comboSampleRate = new ComboBox();
			cbSampleRateSet = new CheckBox();
			lblSampleRate = new Label();
			lblAudioSet = new Label();
			comboSilenced = new ComboBox();
			cbSilencedSet = new CheckBox();
			lblSilenced = new Label();
			tabPeripherals = new TabPage();
			comboMouseAutolockFeedback = new ComboBox();
			cbMouseAutolockFeedbackSet = new CheckBox();
			lblMouseAutolockFeedback = new Label();
			comboMouseAutolock = new ComboBox();
			cbMouseAutolockSet = new CheckBox();
			lblMouseAutolock = new Label();
			comboKbLayout = new ComboBox();
			cbKbLayoutSet = new CheckBox();
			lblKbLayout = new Label();
			comboMouseSensitivity = new ComboBox();
			cbMouseSensitivitySet = new CheckBox();
			lblMouseSensitivity = new Label();
			comboMouseEmulation = new ComboBox();
			cbMouseEmulationSet = new CheckBox();
			lblMouseEmulation = new Label();
			lblPeripheralsSet = new Label();
			comboMouseMiddleUnlock = new ComboBox();
			cbMouseMiddleUnlockSet = new CheckBox();
			lblMouseMiddleUnlock = new Label();
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
			folderBrowserDialog = new FolderBrowserDialog();
			tabsContainer.SuspendLayout();
			tabGeneral.SuspendLayout();
			tabCpu.SuspendLayout();
			tabVideo.SuspendLayout();
			tabAudio.SuspendLayout();
			groupBox1.SuspendLayout();
			grpMidi.SuspendLayout();
			tabPeripherals.SuspendLayout();
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
			tabCpu.Controls.Add(comboMemSize);
			tabCpu.Controls.Add(cbMemSizeSet);
			tabCpu.Controls.Add(lblMemSize);
			tabCpu.Controls.Add(comboMachine);
			tabCpu.Controls.Add(cbMachineSet);
			tabCpu.Controls.Add(lblMachine);
			tabCpu.Controls.Add(comboCycleDown);
			tabCpu.Controls.Add(cbCycleDownSet);
			tabCpu.Controls.Add(lblCycleDown);
			tabCpu.Controls.Add(comboCycleUp);
			tabCpu.Controls.Add(cbCycleUpSet);
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
			// comboMemSize
			// 
			comboMemSize.FormattingEnabled = true;
			comboMemSize.Items.AddRange(new object[] { "16", "32", "64", "128", "8", "4", "2", "1" });
			comboMemSize.Location = new Point(158, 170);
			comboMemSize.Name = "comboMemSize";
			comboMemSize.Size = new Size(439, 23);
			comboMemSize.TabIndex = 61;
			comboMemSize.Tag = "cb=cbMemSizeSet|assoc=lblMemSize|setting=dosbox.memsize";
			// 
			// cbMemSizeSet
			// 
			cbMemSizeSet.AutoSize = true;
			cbMemSizeSet.Location = new Point(11, 174);
			cbMemSizeSet.Name = "cbMemSizeSet";
			cbMemSizeSet.Size = new Size(15, 14);
			cbMemSizeSet.TabIndex = 60;
			cbMemSizeSet.Tag = "";
			cbMemSizeSet.UseVisualStyleBackColor = true;
			// 
			// lblMemSize
			// 
			lblMemSize.AutoSize = true;
			lblMemSize.Location = new Point(36, 173);
			lblMemSize.Name = "lblMemSize";
			lblMemSize.Size = new Size(106, 15);
			lblMemSize.TabIndex = 52;
			lblMemSize.Text = "Memory size (MB):";
			// 
			// comboMachine
			// 
			comboMachine.FormattingEnabled = true;
			comboMachine.Items.AddRange(new object[] { "svga_s3", "ega", "mcga", "cga", "cga_mono", "cga_rgb", "mda", "tandy", "hercules", "pcjr", "amstrad", "vgaonly" });
			comboMachine.Location = new Point(158, 141);
			comboMachine.Name = "comboMachine";
			comboMachine.Size = new Size(439, 23);
			comboMachine.TabIndex = 51;
			comboMachine.Tag = "cb=cbMachineSet|assoc=lblMachine|setting=dosbox.machine";
			// 
			// cbMachineSet
			// 
			cbMachineSet.AutoSize = true;
			cbMachineSet.Location = new Point(11, 145);
			cbMachineSet.Name = "cbMachineSet";
			cbMachineSet.Size = new Size(15, 14);
			cbMachineSet.TabIndex = 50;
			cbMachineSet.Tag = "";
			cbMachineSet.UseVisualStyleBackColor = true;
			// 
			// lblMachine
			// 
			lblMachine.AutoSize = true;
			lblMachine.Location = new Point(36, 144);
			lblMachine.Name = "lblMachine";
			lblMachine.Size = new Size(116, 15);
			lblMachine.TabIndex = 46;
			lblMachine.Text = "Machine to emulate:";
			// 
			// comboCycleDown
			// 
			comboCycleDown.FormattingEnabled = true;
			comboCycleDown.Items.AddRange(new object[] { "10", "20", "500", "1000", "5000" });
			comboCycleDown.Location = new Point(158, 112);
			comboCycleDown.Name = "comboCycleDown";
			comboCycleDown.Size = new Size(439, 23);
			comboCycleDown.TabIndex = 41;
			comboCycleDown.Tag = "cb=cbCycleDownSet|assoc=lblCycleDown|setting=cpu.cycledown";
			// 
			// cbCycleDownSet
			// 
			cbCycleDownSet.AutoSize = true;
			cbCycleDownSet.Location = new Point(11, 116);
			cbCycleDownSet.Name = "cbCycleDownSet";
			cbCycleDownSet.Size = new Size(15, 14);
			cbCycleDownSet.TabIndex = 40;
			cbCycleDownSet.Tag = "";
			cbCycleDownSet.UseVisualStyleBackColor = true;
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
			comboCycleUp.Location = new Point(158, 83);
			comboCycleUp.Name = "comboCycleUp";
			comboCycleUp.Size = new Size(439, 23);
			comboCycleUp.TabIndex = 31;
			comboCycleUp.Tag = "cb=cbCycleUpSet|assoc=lblCycleUp|setting=cpu.cycleup";
			// 
			// cbCycleUpSet
			// 
			cbCycleUpSet.AutoSize = true;
			cbCycleUpSet.Location = new Point(11, 87);
			cbCycleUpSet.Name = "cbCycleUpSet";
			cbCycleUpSet.Size = new Size(15, 14);
			cbCycleUpSet.TabIndex = 30;
			cbCycleUpSet.Tag = "";
			cbCycleUpSet.UseVisualStyleBackColor = true;
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
			comboCycles.Location = new Point(158, 54);
			comboCycles.Name = "comboCycles";
			comboCycles.Size = new Size(439, 23);
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
			comboCore.Location = new Point(158, 25);
			comboCore.Name = "comboCore";
			comboCore.Size = new Size(439, 23);
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
			tabVideo.Controls.Add(comboRefreshRate);
			tabVideo.Controls.Add(cbRefreshRateSet);
			tabVideo.Controls.Add(lblRefreshRate);
			tabVideo.Controls.Add(comboDoublescan);
			tabVideo.Controls.Add(cbDoublescanSet);
			tabVideo.Controls.Add(lblDoublescan);
			tabVideo.Controls.Add(comboScaler);
			tabVideo.Controls.Add(cbScalerSet);
			tabVideo.Controls.Add(lblScaler);
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
			// comboRefreshRate
			// 
			comboRefreshRate.FormattingEnabled = true;
			comboRefreshRate.Items.AddRange(new object[] { "50", "60" });
			comboRefreshRate.Location = new Point(139, 141);
			comboRefreshRate.Name = "comboRefreshRate";
			comboRefreshRate.Size = new Size(458, 23);
			comboRefreshRate.TabIndex = 51;
			comboRefreshRate.Tag = "cb=cbRefreshRateSet|assoc=lblRefreshRate|setting=video.forcerate";
			// 
			// cbRefreshRateSet
			// 
			cbRefreshRateSet.AutoSize = true;
			cbRefreshRateSet.Location = new Point(11, 145);
			cbRefreshRateSet.Name = "cbRefreshRateSet";
			cbRefreshRateSet.Size = new Size(15, 14);
			cbRefreshRateSet.TabIndex = 50;
			cbRefreshRateSet.Tag = "";
			cbRefreshRateSet.UseVisualStyleBackColor = true;
			// 
			// lblRefreshRate
			// 
			lblRefreshRate.AutoSize = true;
			lblRefreshRate.Location = new Point(36, 144);
			lblRefreshRate.Name = "lblRefreshRate";
			lblRefreshRate.Size = new Size(97, 15);
			lblRefreshRate.TabIndex = 59;
			lblRefreshRate.Text = "Refresh rate (Hz):";
			// 
			// comboDoublescan
			// 
			comboDoublescan.FormattingEnabled = true;
			comboDoublescan.Items.AddRange(new object[] { "true", "false" });
			comboDoublescan.Location = new Point(139, 112);
			comboDoublescan.Name = "comboDoublescan";
			comboDoublescan.Size = new Size(458, 23);
			comboDoublescan.TabIndex = 41;
			comboDoublescan.Tag = "cb=cbDoublescanSet|assoc=lblDoublescan|setting=render.doublescan";
			// 
			// cbDoublescanSet
			// 
			cbDoublescanSet.AutoSize = true;
			cbDoublescanSet.Location = new Point(11, 116);
			cbDoublescanSet.Name = "cbDoublescanSet";
			cbDoublescanSet.Size = new Size(15, 14);
			cbDoublescanSet.TabIndex = 40;
			cbDoublescanSet.Tag = "";
			cbDoublescanSet.UseVisualStyleBackColor = true;
			// 
			// lblDoublescan
			// 
			lblDoublescan.AutoSize = true;
			lblDoublescan.Location = new Point(36, 115);
			lblDoublescan.Name = "lblDoublescan";
			lblDoublescan.Size = new Size(72, 15);
			lblDoublescan.TabIndex = 56;
			lblDoublescan.Text = "Doublescan:";
			// 
			// comboScaler
			// 
			comboScaler.FormattingEnabled = true;
			comboScaler.Items.AddRange(new object[] { "normal2x", "normal3x", "normal4x", "normal5x", "hq2x", "hq3x", "advmame2x", "advmame3x", "advinterp2x", "advinterp3x", "2xsai", "super2xsai", "supereagle", "tv2x", "tv3x", "rgb2x", "rgb3x", "scan2x", "scan3x", "gray2x", "xbrz", "xbrz_bilinear", "none" });
			comboScaler.Location = new Point(139, 83);
			comboScaler.Name = "comboScaler";
			comboScaler.Size = new Size(458, 23);
			comboScaler.TabIndex = 31;
			comboScaler.Tag = "cb=cbScalerSet|assoc=lblScaler|setting=render.scaler";
			// 
			// cbScalerSet
			// 
			cbScalerSet.AutoSize = true;
			cbScalerSet.Location = new Point(11, 87);
			cbScalerSet.Name = "cbScalerSet";
			cbScalerSet.Size = new Size(15, 14);
			cbScalerSet.TabIndex = 30;
			cbScalerSet.Tag = "";
			cbScalerSet.UseVisualStyleBackColor = true;
			// 
			// lblScaler
			// 
			lblScaler.AutoSize = true;
			lblScaler.Cursor = Cursors.Help;
			lblScaler.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
			lblScaler.Location = new Point(36, 86);
			lblScaler.Name = "lblScaler";
			lblScaler.Size = new Size(41, 15);
			lblScaler.TabIndex = 53;
			lblScaler.Text = "Scaler:";
			lblScaler.Click += lblScaler_Click;
			// 
			// comboVideoOutput
			// 
			comboVideoOutput.FormattingEnabled = true;
			comboVideoOutput.Items.AddRange(new object[] { "default", "ttf", "surface", "overlay", "opengl", "openglpp", "openglnb", "openglhq", "ddraw", "direct3d" });
			comboVideoOutput.Location = new Point(139, 54);
			comboVideoOutput.Name = "comboVideoOutput";
			comboVideoOutput.Size = new Size(458, 23);
			comboVideoOutput.TabIndex = 21;
			comboVideoOutput.Tag = "cb=cbVideoOutputSet|assoc=lblVideoOutput|setting=sdl.output";
			// 
			// cbVideoOutputSet
			// 
			cbVideoOutputSet.AutoSize = true;
			cbVideoOutputSet.Location = new Point(11, 58);
			cbVideoOutputSet.Name = "cbVideoOutputSet";
			cbVideoOutputSet.Size = new Size(15, 14);
			cbVideoOutputSet.TabIndex = 20;
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
			comboFrameskip.Location = new Point(139, 25);
			comboFrameskip.Name = "comboFrameskip";
			comboFrameskip.Size = new Size(458, 23);
			comboFrameskip.TabIndex = 11;
			comboFrameskip.Tag = "cb=cbFrameskipSet|assoc=lblFrameskip|setting=render.frameskip";
			// 
			// cbFrameskipSet
			// 
			cbFrameskipSet.AutoSize = true;
			cbFrameskipSet.Location = new Point(11, 29);
			cbFrameskipSet.Name = "cbFrameskipSet";
			cbFrameskipSet.Size = new Size(15, 14);
			cbFrameskipSet.TabIndex = 10;
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
			tabAudio.Controls.Add(comboTandySound);
			tabAudio.Controls.Add(cbTandySoundSet);
			tabAudio.Controls.Add(lblTandySound);
			tabAudio.Controls.Add(comboPcSpeaker);
			tabAudio.Controls.Add(cbPcSpeakerSet);
			tabAudio.Controls.Add(lblPcSpeaker);
			tabAudio.Controls.Add(groupBox1);
			tabAudio.Controls.Add(grpMidi);
			tabAudio.Controls.Add(comboSampleRate);
			tabAudio.Controls.Add(cbSampleRateSet);
			tabAudio.Controls.Add(lblSampleRate);
			tabAudio.Controls.Add(lblAudioSet);
			tabAudio.Controls.Add(comboSilenced);
			tabAudio.Controls.Add(cbSilencedSet);
			tabAudio.Controls.Add(lblSilenced);
			tabAudio.Location = new Point(4, 24);
			tabAudio.Name = "tabAudio";
			tabAudio.Size = new Size(1227, 528);
			tabAudio.TabIndex = 2;
			tabAudio.Text = "Audio";
			// 
			// comboTandySound
			// 
			comboTandySound.FormattingEnabled = true;
			comboTandySound.Items.AddRange(new object[] { "auto", "on", "off" });
			comboTandySound.Location = new Point(139, 417);
			comboTandySound.Name = "comboTandySound";
			comboTandySound.Size = new Size(458, 23);
			comboTandySound.TabIndex = 131;
			comboTandySound.Tag = "cb=cbTandySoundSet|assoc=lblTandySound|setting=speaker.tandy";
			// 
			// cbTandySoundSet
			// 
			cbTandySoundSet.AutoSize = true;
			cbTandySoundSet.Location = new Point(11, 421);
			cbTandySoundSet.Name = "cbTandySoundSet";
			cbTandySoundSet.Size = new Size(15, 14);
			cbTandySoundSet.TabIndex = 130;
			cbTandySoundSet.Tag = "";
			cbTandySoundSet.UseVisualStyleBackColor = true;
			// 
			// lblTandySound
			// 
			lblTandySound.AutoSize = true;
			lblTandySound.Location = new Point(36, 420);
			lblTandySound.Name = "lblTandySound";
			lblTandySound.Size = new Size(77, 15);
			lblTandySound.TabIndex = 122;
			lblTandySound.Text = "Tandy sound:";
			// 
			// comboPcSpeaker
			// 
			comboPcSpeaker.FormattingEnabled = true;
			comboPcSpeaker.Items.AddRange(new object[] { "true", "false" });
			comboPcSpeaker.Location = new Point(139, 388);
			comboPcSpeaker.Name = "comboPcSpeaker";
			comboPcSpeaker.Size = new Size(458, 23);
			comboPcSpeaker.TabIndex = 121;
			comboPcSpeaker.Tag = "cb=cbPcSpeakerSet|assoc=lblPcSpeaker|setting=speaker.pcspeaker";
			// 
			// cbPcSpeakerSet
			// 
			cbPcSpeakerSet.AutoSize = true;
			cbPcSpeakerSet.Location = new Point(11, 392);
			cbPcSpeakerSet.Name = "cbPcSpeakerSet";
			cbPcSpeakerSet.Size = new Size(15, 14);
			cbPcSpeakerSet.TabIndex = 120;
			cbPcSpeakerSet.Tag = "";
			cbPcSpeakerSet.UseVisualStyleBackColor = true;
			// 
			// lblPcSpeaker
			// 
			lblPcSpeaker.AutoSize = true;
			lblPcSpeaker.Location = new Point(36, 391);
			lblPcSpeaker.Name = "lblPcSpeaker";
			lblPcSpeaker.Size = new Size(85, 15);
			lblPcSpeaker.TabIndex = 73;
			lblPcSpeaker.Text = "PC speaker on:";
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(comboSbHighDma);
			groupBox1.Controls.Add(cbSbHighDmaSet);
			groupBox1.Controls.Add(lblSbHighDma);
			groupBox1.Controls.Add(comboSbDma);
			groupBox1.Controls.Add(cbSbDmaSet);
			groupBox1.Controls.Add(lblSbDma);
			groupBox1.Controls.Add(comboSbIrq);
			groupBox1.Controls.Add(cbSbIrqSet);
			groupBox1.Controls.Add(lblSbIrq);
			groupBox1.Controls.Add(comboSbBase);
			groupBox1.Controls.Add(cbSbBaseSet);
			groupBox1.Controls.Add(lblSbBase);
			groupBox1.Controls.Add(comboSbType);
			groupBox1.Controls.Add(cbSbTypeSet);
			groupBox1.Controls.Add(lblSbType);
			groupBox1.Location = new Point(4, 218);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(603, 164);
			groupBox1.TabIndex = 70;
			groupBox1.TabStop = false;
			groupBox1.Text = "Sound Blaster";
			// 
			// comboSbHighDma
			// 
			comboSbHighDma.FormattingEnabled = true;
			comboSbHighDma.Items.AddRange(new object[] { "5", "0", "3", "6", "7", "1", "-1" });
			comboSbHighDma.Location = new Point(135, 132);
			comboSbHighDma.Name = "comboSbHighDma";
			comboSbHighDma.Size = new Size(458, 23);
			comboSbHighDma.TabIndex = 111;
			comboSbHighDma.Tag = "cb=cbSbHighDmaSet|assoc=lblSbHighDma|setting=sblaster.hdma";
			// 
			// cbSbHighDmaSet
			// 
			cbSbHighDmaSet.AutoSize = true;
			cbSbHighDmaSet.Location = new Point(7, 136);
			cbSbHighDmaSet.Name = "cbSbHighDmaSet";
			cbSbHighDmaSet.Size = new Size(15, 14);
			cbSbHighDmaSet.TabIndex = 110;
			cbSbHighDmaSet.Tag = "";
			cbSbHighDmaSet.UseVisualStyleBackColor = true;
			// 
			// lblSbHighDma
			// 
			lblSbHighDma.AutoSize = true;
			lblSbHighDma.Location = new Point(32, 135);
			lblSbHighDma.Name = "lblSbHighDma";
			lblSbHighDma.Size = new Size(66, 15);
			lblSbHighDma.TabIndex = 102;
			lblSbHighDma.Text = "High DMA:";
			// 
			// comboSbDma
			// 
			comboSbDma.FormattingEnabled = true;
			comboSbDma.Items.AddRange(new object[] { "1", "5", "0", "3", "6", "7", "-1" });
			comboSbDma.Location = new Point(135, 103);
			comboSbDma.Name = "comboSbDma";
			comboSbDma.Size = new Size(458, 23);
			comboSbDma.TabIndex = 101;
			comboSbDma.Tag = "cb=cbSbDmaSet|assoc=lblSbDma|setting=sblaster.dma";
			// 
			// cbSbDmaSet
			// 
			cbSbDmaSet.AutoSize = true;
			cbSbDmaSet.Location = new Point(7, 107);
			cbSbDmaSet.Name = "cbSbDmaSet";
			cbSbDmaSet.Size = new Size(15, 14);
			cbSbDmaSet.TabIndex = 100;
			cbSbDmaSet.Tag = "";
			cbSbDmaSet.UseVisualStyleBackColor = true;
			// 
			// lblSbDma
			// 
			lblSbDma.AutoSize = true;
			lblSbDma.Location = new Point(32, 106);
			lblSbDma.Name = "lblSbDma";
			lblSbDma.Size = new Size(37, 15);
			lblSbDma.TabIndex = 92;
			lblSbDma.Text = "DMA:";
			// 
			// comboSbIrq
			// 
			comboSbIrq.FormattingEnabled = true;
			comboSbIrq.Items.AddRange(new object[] { "7", "5", "3", "9", "10", "11", "12", "0", "-1" });
			comboSbIrq.Location = new Point(135, 74);
			comboSbIrq.Name = "comboSbIrq";
			comboSbIrq.Size = new Size(458, 23);
			comboSbIrq.TabIndex = 91;
			comboSbIrq.Tag = "cb=cbSbIrqSet|assoc=lblSbIrq|setting=sblaster.irq";
			// 
			// cbSbIrqSet
			// 
			cbSbIrqSet.AutoSize = true;
			cbSbIrqSet.Location = new Point(7, 78);
			cbSbIrqSet.Name = "cbSbIrqSet";
			cbSbIrqSet.Size = new Size(15, 14);
			cbSbIrqSet.TabIndex = 90;
			cbSbIrqSet.Tag = "";
			cbSbIrqSet.UseVisualStyleBackColor = true;
			// 
			// lblSbIrq
			// 
			lblSbIrq.AutoSize = true;
			lblSbIrq.Location = new Point(32, 77);
			lblSbIrq.Name = "lblSbIrq";
			lblSbIrq.Size = new Size(29, 15);
			lblSbIrq.TabIndex = 82;
			lblSbIrq.Text = "IRQ:";
			// 
			// comboSbBase
			// 
			comboSbBase.FormattingEnabled = true;
			comboSbBase.Items.AddRange(new object[] { "220", "240", "260", "280" });
			comboSbBase.Location = new Point(135, 45);
			comboSbBase.Name = "comboSbBase";
			comboSbBase.Size = new Size(458, 23);
			comboSbBase.TabIndex = 81;
			comboSbBase.Tag = "cb=cbSbBaseSet|assoc=lblSbBase|setting=sblaster.sbbase";
			// 
			// cbSbBaseSet
			// 
			cbSbBaseSet.AutoSize = true;
			cbSbBaseSet.Location = new Point(7, 49);
			cbSbBaseSet.Name = "cbSbBaseSet";
			cbSbBaseSet.Size = new Size(15, 14);
			cbSbBaseSet.TabIndex = 80;
			cbSbBaseSet.Tag = "";
			cbSbBaseSet.UseVisualStyleBackColor = true;
			// 
			// lblSbBase
			// 
			lblSbBase.AutoSize = true;
			lblSbBase.Location = new Point(32, 48);
			lblSbBase.Name = "lblSbBase";
			lblSbBase.Size = new Size(34, 15);
			lblSbBase.TabIndex = 60;
			lblSbBase.Text = "Base:";
			// 
			// comboSbType
			// 
			comboSbType.FormattingEnabled = true;
			comboSbType.Items.AddRange(new object[] { "sb1", "sb1.5", "sb2", "sbpro1", "sbpro2", "sb16", "gb", "ess688", "ess1688", "reveal_sc400", "none" });
			comboSbType.Location = new Point(135, 16);
			comboSbType.Name = "comboSbType";
			comboSbType.Size = new Size(458, 23);
			comboSbType.TabIndex = 71;
			comboSbType.Tag = "cb=cbSbTypeSet|assoc=lblSbType|setting=sblaster.sbtype";
			// 
			// cbSbTypeSet
			// 
			cbSbTypeSet.AutoSize = true;
			cbSbTypeSet.Location = new Point(7, 20);
			cbSbTypeSet.Name = "cbSbTypeSet";
			cbSbTypeSet.Size = new Size(15, 14);
			cbSbTypeSet.TabIndex = 70;
			cbSbTypeSet.Tag = "";
			cbSbTypeSet.UseVisualStyleBackColor = true;
			// 
			// lblSbType
			// 
			lblSbType.AutoSize = true;
			lblSbType.Location = new Point(32, 19);
			lblSbType.Name = "lblSbType";
			lblSbType.Size = new Size(49, 15);
			lblSbType.TabIndex = 57;
			lblSbType.Text = "SB type:";
			// 
			// grpMidi
			// 
			grpMidi.Controls.Add(btnMt32RomDirBrowse);
			grpMidi.Controls.Add(comboMt32Model);
			grpMidi.Controls.Add(cbMt32ModelSet);
			grpMidi.Controls.Add(lblMt32Model);
			grpMidi.Controls.Add(txtMt32RomDir);
			grpMidi.Controls.Add(cbMt32RomDirSet);
			grpMidi.Controls.Add(lblMt32RomDir);
			grpMidi.Controls.Add(comboMidiDevice);
			grpMidi.Controls.Add(cbMidiDeviceSet);
			grpMidi.Controls.Add(lblMidiDevice);
			grpMidi.Controls.Add(comboMpu401);
			grpMidi.Controls.Add(cbMpu401Set);
			grpMidi.Controls.Add(lblMpu401);
			grpMidi.Location = new Point(4, 77);
			grpMidi.Name = "grpMidi";
			grpMidi.Size = new Size(603, 135);
			grpMidi.TabIndex = 30;
			grpMidi.TabStop = false;
			grpMidi.Text = "MIDI";
			// 
			// btnMt32RomDirBrowse
			// 
			btnMt32RomDirBrowse.Location = new Point(518, 74);
			btnMt32RomDirBrowse.Name = "btnMt32RomDirBrowse";
			btnMt32RomDirBrowse.Size = new Size(75, 23);
			btnMt32RomDirBrowse.TabIndex = 52;
			btnMt32RomDirBrowse.Text = "&Browse...";
			btnMt32RomDirBrowse.UseVisualStyleBackColor = true;
			btnMt32RomDirBrowse.Click += btnMt32RomDirBrowse_Click;
			// 
			// comboMt32Model
			// 
			comboMt32Model.FormattingEnabled = true;
			comboMt32Model.Items.AddRange(new object[] { "auto", "cm32l", "mt32" });
			comboMt32Model.Location = new Point(135, 103);
			comboMt32Model.Name = "comboMt32Model";
			comboMt32Model.Size = new Size(458, 23);
			comboMt32Model.TabIndex = 61;
			comboMt32Model.Tag = "cb=cbMt32ModelSet|assoc=lblMt32Model|setting=midi.mt32.model";
			// 
			// cbMt32ModelSet
			// 
			cbMt32ModelSet.AutoSize = true;
			cbMt32ModelSet.Location = new Point(7, 107);
			cbMt32ModelSet.Name = "cbMt32ModelSet";
			cbMt32ModelSet.Size = new Size(15, 14);
			cbMt32ModelSet.TabIndex = 60;
			cbMt32ModelSet.Tag = "";
			cbMt32ModelSet.UseVisualStyleBackColor = true;
			// 
			// lblMt32Model
			// 
			lblMt32Model.AutoSize = true;
			lblMt32Model.Location = new Point(32, 106);
			lblMt32Model.Name = "lblMt32Model";
			lblMt32Model.Size = new Size(81, 15);
			lblMt32Model.TabIndex = 70;
			lblMt32Model.Text = "MT-32 model:";
			// 
			// txtMt32RomDir
			// 
			txtMt32RomDir.Location = new Point(135, 74);
			txtMt32RomDir.Name = "txtMt32RomDir";
			txtMt32RomDir.Size = new Size(377, 23);
			txtMt32RomDir.TabIndex = 51;
			txtMt32RomDir.Tag = "cb=cbMt32RomDirSet|assoc=lblMt32RomDir,btnMt32RomDirBrowse|setting=midi.mt32.romdir";
			// 
			// cbMt32RomDirSet
			// 
			cbMt32RomDirSet.AutoSize = true;
			cbMt32RomDirSet.Location = new Point(7, 78);
			cbMt32RomDirSet.Name = "cbMt32RomDirSet";
			cbMt32RomDirSet.Size = new Size(15, 14);
			cbMt32RomDirSet.TabIndex = 50;
			cbMt32RomDirSet.Tag = "";
			cbMt32RomDirSet.UseVisualStyleBackColor = true;
			// 
			// lblMt32RomDir
			// 
			lblMt32RomDir.AutoSize = true;
			lblMt32RomDir.Location = new Point(32, 77);
			lblMt32RomDir.Name = "lblMt32RomDir";
			lblMt32RomDir.Size = new Size(91, 15);
			lblMt32RomDir.TabIndex = 66;
			lblMt32RomDir.Text = "MT-32 ROM dir:";
			// 
			// comboMidiDevice
			// 
			comboMidiDevice.FormattingEnabled = true;
			comboMidiDevice.Items.AddRange(new object[] { "mt32", "win32", "alsa", "oss", "coreaudio", "coremidi", "synth", "fluidsynth", "timidity", "default", "none" });
			comboMidiDevice.Location = new Point(135, 45);
			comboMidiDevice.Name = "comboMidiDevice";
			comboMidiDevice.Size = new Size(458, 23);
			comboMidiDevice.TabIndex = 41;
			comboMidiDevice.Tag = "cb=cbMidiDeviceSet|assoc=lblMidiDevice|setting=midi.mididevice";
			// 
			// cbMidiDeviceSet
			// 
			cbMidiDeviceSet.AutoSize = true;
			cbMidiDeviceSet.Location = new Point(7, 49);
			cbMidiDeviceSet.Name = "cbMidiDeviceSet";
			cbMidiDeviceSet.Size = new Size(15, 14);
			cbMidiDeviceSet.TabIndex = 40;
			cbMidiDeviceSet.Tag = "";
			cbMidiDeviceSet.UseVisualStyleBackColor = true;
			// 
			// lblMidiDevice
			// 
			lblMidiDevice.AutoSize = true;
			lblMidiDevice.Location = new Point(32, 48);
			lblMidiDevice.Name = "lblMidiDevice";
			lblMidiDevice.Size = new Size(45, 15);
			lblMidiDevice.TabIndex = 63;
			lblMidiDevice.Text = "Device:";
			// 
			// comboMpu401
			// 
			comboMpu401.FormattingEnabled = true;
			comboMpu401.Items.AddRange(new object[] { "intelligent", "uart", "none" });
			comboMpu401.Location = new Point(135, 16);
			comboMpu401.Name = "comboMpu401";
			comboMpu401.Size = new Size(458, 23);
			comboMpu401.TabIndex = 31;
			comboMpu401.Tag = "cb=cbMpu401Set|assoc=lblMpu401|setting=midi.mpu401";
			// 
			// cbMpu401Set
			// 
			cbMpu401Set.AutoSize = true;
			cbMpu401Set.Location = new Point(7, 20);
			cbMpu401Set.Name = "cbMpu401Set";
			cbMpu401Set.Size = new Size(15, 14);
			cbMpu401Set.TabIndex = 30;
			cbMpu401Set.Tag = "";
			cbMpu401Set.UseVisualStyleBackColor = true;
			// 
			// lblMpu401
			// 
			lblMpu401.AutoSize = true;
			lblMpu401.Location = new Point(32, 19);
			lblMpu401.Name = "lblMpu401";
			lblMpu401.Size = new Size(85, 15);
			lblMpu401.TabIndex = 60;
			lblMpu401.Text = "MPU-401 type:";
			// 
			// comboSampleRate
			// 
			comboSampleRate.FormattingEnabled = true;
			comboSampleRate.Items.AddRange(new object[] { "44100", "48000" });
			comboSampleRate.Location = new Point(139, 54);
			comboSampleRate.Name = "comboSampleRate";
			comboSampleRate.Size = new Size(458, 23);
			comboSampleRate.TabIndex = 21;
			comboSampleRate.Tag = "cb=cbSampleRateSet|assoc=lblSampleRate|setting=mixer.rate";
			// 
			// cbSampleRateSet
			// 
			cbSampleRateSet.AutoSize = true;
			cbSampleRateSet.Location = new Point(11, 58);
			cbSampleRateSet.Name = "cbSampleRateSet";
			cbSampleRateSet.Size = new Size(15, 14);
			cbSampleRateSet.TabIndex = 20;
			cbSampleRateSet.Tag = "";
			cbSampleRateSet.UseVisualStyleBackColor = true;
			// 
			// lblSampleRate
			// 
			lblSampleRate.AutoSize = true;
			lblSampleRate.Location = new Point(36, 57);
			lblSampleRate.Name = "lblSampleRate";
			lblSampleRate.Size = new Size(97, 15);
			lblSampleRate.TabIndex = 54;
			lblSampleRate.Text = "Sample rate (Hz):";
			// 
			// lblAudioSet
			// 
			lblAudioSet.AutoSize = true;
			lblAudioSet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblAudioSet.Location = new Point(5, 7);
			lblAudioSet.Name = "lblAudioSet";
			lblAudioSet.Size = new Size(26, 15);
			lblAudioSet.TabIndex = 51;
			lblAudioSet.Text = "Set";
			// 
			// comboSilenced
			// 
			comboSilenced.FormattingEnabled = true;
			comboSilenced.Items.AddRange(new object[] { "true", "false" });
			comboSilenced.Location = new Point(139, 25);
			comboSilenced.Name = "comboSilenced";
			comboSilenced.Size = new Size(458, 23);
			comboSilenced.TabIndex = 11;
			comboSilenced.Tag = "cb=cbSilencedSet|assoc=lblSilenced|setting=mixer.nosound";
			// 
			// cbSilencedSet
			// 
			cbSilencedSet.AutoSize = true;
			cbSilencedSet.Location = new Point(11, 29);
			cbSilencedSet.Name = "cbSilencedSet";
			cbSilencedSet.Size = new Size(15, 14);
			cbSilencedSet.TabIndex = 10;
			cbSilencedSet.Tag = "";
			cbSilencedSet.UseVisualStyleBackColor = true;
			// 
			// lblSilenced
			// 
			lblSilenced.AutoSize = true;
			lblSilenced.Location = new Point(36, 28);
			lblSilenced.Name = "lblSilenced";
			lblSilenced.Size = new Size(90, 15);
			lblSilenced.TabIndex = 50;
			lblSilenced.Text = "Sound silenced:";
			// 
			// tabPeripherals
			// 
			tabPeripherals.BackColor = SystemColors.Control;
			tabPeripherals.Controls.Add(comboMouseAutolockFeedback);
			tabPeripherals.Controls.Add(cbMouseAutolockFeedbackSet);
			tabPeripherals.Controls.Add(lblMouseAutolockFeedback);
			tabPeripherals.Controls.Add(comboMouseAutolock);
			tabPeripherals.Controls.Add(cbMouseAutolockSet);
			tabPeripherals.Controls.Add(lblMouseAutolock);
			tabPeripherals.Controls.Add(comboKbLayout);
			tabPeripherals.Controls.Add(cbKbLayoutSet);
			tabPeripherals.Controls.Add(lblKbLayout);
			tabPeripherals.Controls.Add(comboMouseSensitivity);
			tabPeripherals.Controls.Add(cbMouseSensitivitySet);
			tabPeripherals.Controls.Add(lblMouseSensitivity);
			tabPeripherals.Controls.Add(comboMouseEmulation);
			tabPeripherals.Controls.Add(cbMouseEmulationSet);
			tabPeripherals.Controls.Add(lblMouseEmulation);
			tabPeripherals.Controls.Add(lblPeripheralsSet);
			tabPeripherals.Controls.Add(comboMouseMiddleUnlock);
			tabPeripherals.Controls.Add(cbMouseMiddleUnlockSet);
			tabPeripherals.Controls.Add(lblMouseMiddleUnlock);
			tabPeripherals.Location = new Point(4, 24);
			tabPeripherals.Name = "tabPeripherals";
			tabPeripherals.Size = new Size(1227, 528);
			tabPeripherals.TabIndex = 3;
			tabPeripherals.Text = "Peripherals";
			// 
			// comboMouseAutolockFeedback
			// 
			comboMouseAutolockFeedback.FormattingEnabled = true;
			comboMouseAutolockFeedback.Items.AddRange(new object[] { "beep", "flash", "none" });
			comboMouseAutolockFeedback.Location = new Point(188, 170);
			comboMouseAutolockFeedback.Name = "comboMouseAutolockFeedback";
			comboMouseAutolockFeedback.Size = new Size(409, 23);
			comboMouseAutolockFeedback.TabIndex = 61;
			comboMouseAutolockFeedback.Tag = "cb=cbMouseAutolockFeedbackSet|assoc=lblMouseAutolockFeedback|setting=sdl.autolock_feedback";
			// 
			// cbMouseAutolockFeedbackSet
			// 
			cbMouseAutolockFeedbackSet.AutoSize = true;
			cbMouseAutolockFeedbackSet.Location = new Point(11, 174);
			cbMouseAutolockFeedbackSet.Name = "cbMouseAutolockFeedbackSet";
			cbMouseAutolockFeedbackSet.Size = new Size(15, 14);
			cbMouseAutolockFeedbackSet.TabIndex = 60;
			cbMouseAutolockFeedbackSet.Tag = "";
			cbMouseAutolockFeedbackSet.UseVisualStyleBackColor = true;
			// 
			// lblMouseAutolockFeedback
			// 
			lblMouseAutolockFeedback.AutoSize = true;
			lblMouseAutolockFeedback.Location = new Point(36, 173);
			lblMouseAutolockFeedback.Name = "lblMouseAutolockFeedback";
			lblMouseAutolockFeedback.Size = new Size(135, 15);
			lblMouseAutolockFeedback.TabIndex = 74;
			lblMouseAutolockFeedback.Text = "Autolock feedback type:";
			// 
			// comboMouseAutolock
			// 
			comboMouseAutolock.FormattingEnabled = true;
			comboMouseAutolock.Items.AddRange(new object[] { "true", "false" });
			comboMouseAutolock.Location = new Point(188, 141);
			comboMouseAutolock.Name = "comboMouseAutolock";
			comboMouseAutolock.Size = new Size(409, 23);
			comboMouseAutolock.TabIndex = 51;
			comboMouseAutolock.Tag = "cb=cbMouseAutolockSet|assoc=lblMouseAutolock|setting=sdl.autolock";
			// 
			// cbMouseAutolockSet
			// 
			cbMouseAutolockSet.AutoSize = true;
			cbMouseAutolockSet.Location = new Point(11, 145);
			cbMouseAutolockSet.Name = "cbMouseAutolockSet";
			cbMouseAutolockSet.Size = new Size(15, 14);
			cbMouseAutolockSet.TabIndex = 50;
			cbMouseAutolockSet.Tag = "";
			cbMouseAutolockSet.UseVisualStyleBackColor = true;
			// 
			// lblMouseAutolock
			// 
			lblMouseAutolock.AutoSize = true;
			lblMouseAutolock.Location = new Point(36, 144);
			lblMouseAutolock.Name = "lblMouseAutolock";
			lblMouseAutolock.Size = new Size(95, 15);
			lblMouseAutolock.TabIndex = 71;
			lblMouseAutolock.Text = "Mouse autolock:";
			// 
			// comboKbLayout
			// 
			comboKbLayout.FormattingEnabled = true;
			comboKbLayout.Items.AddRange(new object[] { "auto", "us", "cf", "uk", "fr", "gr", "sv", "no", "ru", "sp", "dk", "it", "nl", "pl", "su", "po", "br", "be", "hu", "sf", "sg", "dv103" });
			comboKbLayout.Location = new Point(188, 25);
			comboKbLayout.Name = "comboKbLayout";
			comboKbLayout.Size = new Size(409, 23);
			comboKbLayout.TabIndex = 11;
			comboKbLayout.Tag = "cb=cbKbLayoutSet|assoc=lblKbLayout|setting=dos.keyboardlayout";
			// 
			// cbKbLayoutSet
			// 
			cbKbLayoutSet.AutoSize = true;
			cbKbLayoutSet.Location = new Point(11, 29);
			cbKbLayoutSet.Name = "cbKbLayoutSet";
			cbKbLayoutSet.Size = new Size(15, 14);
			cbKbLayoutSet.TabIndex = 10;
			cbKbLayoutSet.Tag = "";
			cbKbLayoutSet.UseVisualStyleBackColor = true;
			// 
			// lblKbLayout
			// 
			lblKbLayout.AutoSize = true;
			lblKbLayout.Location = new Point(36, 28);
			lblKbLayout.Name = "lblKbLayout";
			lblKbLayout.Size = new Size(96, 15);
			lblKbLayout.TabIndex = 68;
			lblKbLayout.Text = "Keyboard layout:";
			// 
			// comboMouseSensitivity
			// 
			comboMouseSensitivity.FormattingEnabled = true;
			comboMouseSensitivity.Items.AddRange(new object[] { "100", "50,100", "35,75", "100,-50" });
			comboMouseSensitivity.Location = new Point(188, 112);
			comboMouseSensitivity.Name = "comboMouseSensitivity";
			comboMouseSensitivity.Size = new Size(409, 23);
			comboMouseSensitivity.TabIndex = 41;
			comboMouseSensitivity.Tag = "cb=cbMouseSensitivitySet|assoc=lblMouseSensitivity|setting=sdl.sensitivity";
			// 
			// cbMouseSensitivitySet
			// 
			cbMouseSensitivitySet.AutoSize = true;
			cbMouseSensitivitySet.Location = new Point(11, 116);
			cbMouseSensitivitySet.Name = "cbMouseSensitivitySet";
			cbMouseSensitivitySet.Size = new Size(15, 14);
			cbMouseSensitivitySet.TabIndex = 40;
			cbMouseSensitivitySet.Tag = "";
			cbMouseSensitivitySet.UseVisualStyleBackColor = true;
			// 
			// lblMouseSensitivity
			// 
			lblMouseSensitivity.AutoSize = true;
			lblMouseSensitivity.Location = new Point(36, 115);
			lblMouseSensitivity.Name = "lblMouseSensitivity";
			lblMouseSensitivity.Size = new Size(101, 15);
			lblMouseSensitivity.TabIndex = 65;
			lblMouseSensitivity.Text = "Mouse sensitivity:";
			// 
			// comboMouseEmulation
			// 
			comboMouseEmulation.FormattingEnabled = true;
			comboMouseEmulation.Items.AddRange(new object[] { "integration", "locked", "always", "never" });
			comboMouseEmulation.Location = new Point(188, 54);
			comboMouseEmulation.Name = "comboMouseEmulation";
			comboMouseEmulation.Size = new Size(409, 23);
			comboMouseEmulation.TabIndex = 21;
			comboMouseEmulation.Tag = "cb=cbMouseEmulationSet|assoc=lblMouseEmulation|setting=sdl.mouse_emulation";
			// 
			// cbMouseEmulationSet
			// 
			cbMouseEmulationSet.AutoSize = true;
			cbMouseEmulationSet.Location = new Point(11, 58);
			cbMouseEmulationSet.Name = "cbMouseEmulationSet";
			cbMouseEmulationSet.Size = new Size(15, 14);
			cbMouseEmulationSet.TabIndex = 20;
			cbMouseEmulationSet.Tag = "";
			cbMouseEmulationSet.UseVisualStyleBackColor = true;
			// 
			// lblMouseEmulation
			// 
			lblMouseEmulation.AutoSize = true;
			lblMouseEmulation.Location = new Point(36, 57);
			lblMouseEmulation.Name = "lblMouseEmulation";
			lblMouseEmulation.Size = new Size(103, 15);
			lblMouseEmulation.TabIndex = 62;
			lblMouseEmulation.Text = "Mouse emulation:";
			// 
			// lblPeripheralsSet
			// 
			lblPeripheralsSet.AutoSize = true;
			lblPeripheralsSet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblPeripheralsSet.Location = new Point(5, 7);
			lblPeripheralsSet.Name = "lblPeripheralsSet";
			lblPeripheralsSet.Size = new Size(26, 15);
			lblPeripheralsSet.TabIndex = 54;
			lblPeripheralsSet.Text = "Set";
			// 
			// comboMouseMiddleUnlock
			// 
			comboMouseMiddleUnlock.FormattingEnabled = true;
			comboMouseMiddleUnlock.Items.AddRange(new object[] { "none", "auto", "manual", "both" });
			comboMouseMiddleUnlock.Location = new Point(188, 83);
			comboMouseMiddleUnlock.Name = "comboMouseMiddleUnlock";
			comboMouseMiddleUnlock.Size = new Size(409, 23);
			comboMouseMiddleUnlock.TabIndex = 31;
			comboMouseMiddleUnlock.Tag = "cb=cbMouseMiddleUnlockSet|assoc=lblMouseMiddleUnlock|setting=sdl.middle_unlock";
			// 
			// cbMouseMiddleUnlockSet
			// 
			cbMouseMiddleUnlockSet.AutoSize = true;
			cbMouseMiddleUnlockSet.Location = new Point(11, 87);
			cbMouseMiddleUnlockSet.Name = "cbMouseMiddleUnlockSet";
			cbMouseMiddleUnlockSet.Size = new Size(15, 14);
			cbMouseMiddleUnlockSet.TabIndex = 30;
			cbMouseMiddleUnlockSet.Tag = "";
			cbMouseMiddleUnlockSet.UseVisualStyleBackColor = true;
			// 
			// lblMouseMiddleUnlock
			// 
			lblMouseMiddleUnlock.AutoSize = true;
			lblMouseMiddleUnlock.Cursor = Cursors.Help;
			lblMouseMiddleUnlock.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
			lblMouseMiddleUnlock.Location = new Point(36, 86);
			lblMouseMiddleUnlock.Name = "lblMouseMiddleUnlock";
			lblMouseMiddleUnlock.Size = new Size(146, 15);
			lblMouseMiddleUnlock.TabIndex = 53;
			lblMouseMiddleUnlock.Text = "Middle mouse btn unlock:";
			lblMouseMiddleUnlock.Click += lblMouseMiddleUnlock_Click;
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
			// folderBrowserDialog
			// 
			folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
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
			tabAudio.ResumeLayout(false);
			tabAudio.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			grpMidi.ResumeLayout(false);
			grpMidi.PerformLayout();
			tabPeripherals.ResumeLayout(false);
			tabPeripherals.PerformLayout();
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
		private CheckBox cbCycleDownSet;
		private Label lblCycleDown;
		private ComboBox comboCycleUp;
		private CheckBox cbCycleUpSet;
		private Label lblCycleUp;
		private Label lblVideoSet;
		private ComboBox comboFrameskip;
		private CheckBox cbFrameskipSet;
		private Label lblFrameskip;
		private ComboBox comboVideoOutput;
		private CheckBox cbVideoOutputSet;
		private Label lblVideoOutput;
		private ComboBox comboMouseMiddleUnlock;
		private CheckBox cbMouseMiddleUnlockSet;
		private Label lblMouseMiddleUnlock;
		private Label lblPeripheralsSet;
		private ComboBox comboMouseEmulation;
		private CheckBox cbMouseEmulationSet;
		private Label lblMouseEmulation;
		private ComboBox comboMouseSensitivity;
		private CheckBox cbMouseSensitivitySet;
		private Label lblMouseSensitivity;
		private ComboBox comboMachine;
		private CheckBox cbMachineSet;
		private Label lblMachine;
		private ComboBox comboScaler;
		private CheckBox cbScalerSet;
		private Label lblScaler;
		private ComboBox comboDoublescan;
		private CheckBox cbDoublescanSet;
		private Label lblDoublescan;
		private ComboBox comboRefreshRate;
		private CheckBox cbRefreshRateSet;
		private Label lblRefreshRate;
		private Label lblAudioSet;
		private ComboBox comboSilenced;
		private CheckBox cbSilencedSet;
		private Label lblSilenced;
		private ComboBox comboSampleRate;
		private CheckBox cbSampleRateSet;
		private Label lblSampleRate;
		private GroupBox grpMidi;
		private ComboBox comboMpu401;
		private CheckBox cbMpu401Set;
		private Label lblMpu401;
		private ComboBox comboMidiDevice;
		private CheckBox cbMidiDeviceSet;
		private Label lblMidiDevice;
		private CheckBox cbMt32RomDirSet;
		private Label lblMt32RomDir;
		private TextBox txtMt32RomDir;
		private ComboBox comboMt32Model;
		private CheckBox cbMt32ModelSet;
		private Label lblMt32Model;
		private Button btnMt32RomDirBrowse;
		private FolderBrowserDialog folderBrowserDialog;
		private GroupBox groupBox1;
		private ComboBox comboSbType;
		private CheckBox cbSbTypeSet;
		private Label lblSbType;
		private ComboBox comboSbBase;
		private CheckBox cbSbBaseSet;
		private Label lblSbBase;
		private ComboBox comboSbIrq;
		private CheckBox cbSbIrqSet;
		private Label lblSbIrq;
		private ComboBox comboSbDma;
		private CheckBox cbSbDmaSet;
		private Label lblSbDma;
		private ComboBox comboSbHighDma;
		private CheckBox cbSbHighDmaSet;
		private Label lblSbHighDma;
		private ComboBox comboPcSpeaker;
		private CheckBox cbPcSpeakerSet;
		private Label lblPcSpeaker;
		private ComboBox comboTandySound;
		private CheckBox cbTandySoundSet;
		private Label lblTandySound;
		private ComboBox comboKbLayout;
		private CheckBox cbKbLayoutSet;
		private Label lblKbLayout;
		private ComboBox comboMemSize;
		private CheckBox cbMemSizeSet;
		private Label lblMemSize;
		private ComboBox comboMouseAutolock;
		private CheckBox cbMouseAutolockSet;
		private Label lblMouseAutolock;
		private ComboBox comboMouseAutolockFeedback;
		private CheckBox cbMouseAutolockFeedbackSet;
		private Label lblMouseAutolockFeedback;
	}
}
