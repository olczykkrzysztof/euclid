/* Euclid# - Euclidean Geometry Constructions Simulator 
 * 
 * Copyright (c) 2006 Krzysztof Olczyk
 * 
 * Program written for Programming Project Course
 * at Technical University of Lodz, Fall 2006
 * 
 */

namespace Euclid
{
    partial class MainWnd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWnd));
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.sbComment = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmClock = new System.Windows.Forms.Timer(this.components);
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.WndContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pbOutput = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.mnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecentFile0 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecentFile1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecentFile2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecentFile3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecentFile4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHTMLraport = new System.Windows.Forms.ToolStripMenuItem();
            this.ffsdf = new System.Windows.Forms.ToolStripSeparator();
            this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEucasmRef = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSimulation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRewind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPause = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStepForward = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolBox = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.ConstructionControlBox = new System.Windows.Forms.ToolStrip();
            this.btnRestart = new System.Windows.Forms.ToolStripButton();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.btnPause = new System.Windows.Forms.ToolStripButton();
            this.btnStep = new System.Windows.Forms.ToolStripButton();
            this.tmAnimation = new System.Windows.Forms.Timer(this.components);
            this.emoticons = new System.Windows.Forms.ImageList(this.components);
            this.ExportDialog = new System.Windows.Forms.SaveFileDialog();
            this.ExportHTMLDialog = new System.Windows.Forms.SaveFileDialog();
            this.StatusBar.SuspendLayout();
            this.WndContainer.ContentPanel.SuspendLayout();
            this.WndContainer.TopToolStripPanel.SuspendLayout();
            this.WndContainer.SuspendLayout();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            this.MenuBar.SuspendLayout();
            this.ToolBox.SuspendLayout();
            this.ConstructionControlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbComment,
            this.cbClock});
            this.StatusBar.Location = new System.Drawing.Point(0, 483);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(771, 22);
            this.StatusBar.TabIndex = 1;
            // 
            // sbComment
            // 
            this.sbComment.AutoToolTip = true;
            this.sbComment.Name = "sbComment";
            this.sbComment.Size = new System.Drawing.Size(705, 17);
            this.sbComment.Spring = true;
            this.sbComment.Text = "Euclid# :)";
            this.sbComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sbComment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // cbClock
            // 
            this.cbClock.Name = "cbClock";
            this.cbClock.Size = new System.Drawing.Size(51, 17);
            this.cbClock.Text = "00:00:00";
            // 
            // tmClock
            // 
            this.tmClock.Enabled = true;
            this.tmClock.Tick += new System.EventHandler(this.tmClock_Tick);
            // 
            // OpenDialog
            // 
            this.OpenDialog.CheckFileExists = false;
            this.OpenDialog.CheckPathExists = false;
            this.OpenDialog.DefaultExt = "euc";
            this.OpenDialog.Filter = "Eucasm scripts (*.euc) |*.euc|All files (*.*)|*.*";
            this.OpenDialog.Title = "Open Euclid# script file...";
            // 
            // WndContainer
            // 
            // 
            // WndContainer.ContentPanel
            // 
            this.WndContainer.ContentPanel.Controls.Add(this.splitContainer);
            this.WndContainer.ContentPanel.Size = new System.Drawing.Size(771, 434);
            this.WndContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WndContainer.Location = new System.Drawing.Point(0, 0);
            this.WndContainer.Name = "WndContainer";
            this.WndContainer.Size = new System.Drawing.Size(771, 483);
            this.WndContainer.TabIndex = 5;
            this.WndContainer.Text = "toolStripContainer1";
            // 
            // WndContainer.TopToolStripPanel
            // 
            this.WndContainer.TopToolStripPanel.Controls.Add(this.MenuBar);
            this.WndContainer.TopToolStripPanel.Controls.Add(this.ToolBox);
            this.WndContainer.TopToolStripPanel.Controls.Add(this.ConstructionControlBox);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer.Panel1.Controls.Add(this.pbOutput);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer.Panel2.Controls.Add(this.txtOutput);
            this.splitContainer.Size = new System.Drawing.Size(771, 434);
            this.splitContainer.SplitterDistance = 479;
            this.splitContainer.TabIndex = 4;
            // 
            // pbOutput
            // 
            this.pbOutput.BackColor = System.Drawing.Color.White;
            this.pbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbOutput.Location = new System.Drawing.Point(0, 0);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(479, 434);
            this.pbOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOutput.TabIndex = 0;
            this.pbOutput.TabStop = false;
            this.pbOutput.Visible = false;
            this.pbOutput.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbOutput_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(108, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "CONSTRUCTION\'S CANVAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(288, 434);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "Construction\'s comments";
            // 
            // MenuBar
            // 
            this.MenuBar.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFile,
            this.mnHelp,
            this.mnSimulation});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(771, 24);
            this.MenuBar.TabIndex = 11;
            // 
            // mnFile
            // 
            this.mnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.mnuRecent,
            this.mnuExport,
            this.mnuHTMLraport,
            this.ffsdf,
            this.mniExit});
            this.mnFile.Name = "mnFile";
            this.mnFile.Size = new System.Drawing.Size(35, 20);
            this.mnFile.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFileOpen.Size = new System.Drawing.Size(191, 22);
            this.mnuFileOpen.Text = "&Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuRecent
            // 
            this.mnuRecent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRecentFile0,
            this.mnuRecentFile1,
            this.mnuRecentFile2,
            this.mnuRecentFile3,
            this.mnuRecentFile4,
            this.toolStripMenuItem1,
            this.mnuClearRecent});
            this.mnuRecent.Name = "mnuRecent";
            this.mnuRecent.Size = new System.Drawing.Size(191, 22);
            this.mnuRecent.Tag = "";
            this.mnuRecent.Text = "Open &recent";
            this.mnuRecent.Visible = false;
            // 
            // mnuRecentFile0
            // 
            this.mnuRecentFile0.Name = "mnuRecentFile0";
            this.mnuRecentFile0.Size = new System.Drawing.Size(145, 22);
            this.mnuRecentFile0.Text = "Recent file 0";
            this.mnuRecentFile0.Visible = false;
            this.mnuRecentFile0.Click += new System.EventHandler(this.mnuRecentFile0_Click);
            // 
            // mnuRecentFile1
            // 
            this.mnuRecentFile1.Name = "mnuRecentFile1";
            this.mnuRecentFile1.Size = new System.Drawing.Size(145, 22);
            this.mnuRecentFile1.Text = "Recent file 1";
            this.mnuRecentFile1.Visible = false;
            this.mnuRecentFile1.Click += new System.EventHandler(this.mnuRecentFile0_Click);
            // 
            // mnuRecentFile2
            // 
            this.mnuRecentFile2.Name = "mnuRecentFile2";
            this.mnuRecentFile2.Size = new System.Drawing.Size(145, 22);
            this.mnuRecentFile2.Text = "Recent file 2";
            this.mnuRecentFile2.Visible = false;
            this.mnuRecentFile2.Click += new System.EventHandler(this.mnuRecentFile0_Click);
            // 
            // mnuRecentFile3
            // 
            this.mnuRecentFile3.Name = "mnuRecentFile3";
            this.mnuRecentFile3.Size = new System.Drawing.Size(145, 22);
            this.mnuRecentFile3.Text = "Recent file 3";
            this.mnuRecentFile3.Visible = false;
            this.mnuRecentFile3.Click += new System.EventHandler(this.mnuRecentFile0_Click);
            // 
            // mnuRecentFile4
            // 
            this.mnuRecentFile4.Name = "mnuRecentFile4";
            this.mnuRecentFile4.Size = new System.Drawing.Size(145, 22);
            this.mnuRecentFile4.Text = "Recent file 4";
            this.mnuRecentFile4.Visible = false;
            this.mnuRecentFile4.Click += new System.EventHandler(this.mnuRecentFile0_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 6);
            // 
            // mnuClearRecent
            // 
            this.mnuClearRecent.Name = "mnuClearRecent";
            this.mnuClearRecent.Size = new System.Drawing.Size(145, 22);
            this.mnuClearRecent.Text = "&Clear list";
            this.mnuClearRecent.Click += new System.EventHandler(this.mnuClearRecent_Click);
            // 
            // mnuExport
            // 
            this.mnuExport.Enabled = false;
            this.mnuExport.Name = "mnuExport";
            this.mnuExport.Size = new System.Drawing.Size(191, 22);
            this.mnuExport.Text = "&Export...";
            this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
            // 
            // mnuHTMLraport
            // 
            this.mnuHTMLraport.Enabled = false;
            this.mnuHTMLraport.Name = "mnuHTMLraport";
            this.mnuHTMLraport.Size = new System.Drawing.Size(191, 22);
            this.mnuHTMLraport.Text = "Export &HTML raport...";
            this.mnuHTMLraport.Click += new System.EventHandler(this.mnuHTMLraport_Click);
            // 
            // ffsdf
            // 
            this.ffsdf.Name = "ffsdf";
            this.ffsdf.Size = new System.Drawing.Size(188, 6);
            // 
            // mniExit
            // 
            this.mniExit.Name = "mniExit";
            this.mniExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mniExit.Size = new System.Drawing.Size(191, 22);
            this.mniExit.Text = "E&xit";
            this.mniExit.Click += new System.EventHandler(this.mniExit_Click);
            // 
            // mnHelp
            // 
            this.mnHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEucasmRef,
            this.toolStripSeparator1,
            this.mnuAbout});
            this.mnHelp.Name = "mnHelp";
            this.mnHelp.Size = new System.Drawing.Size(40, 20);
            this.mnHelp.Text = "&Help";
            // 
            // mnuEucasmRef
            // 
            this.mnuEucasmRef.Name = "mnuEucasmRef";
            this.mnuEucasmRef.Size = new System.Drawing.Size(218, 22);
            this.mnuEucasmRef.Text = "&Eucasm language reference";
            this.mnuEucasmRef.Click += new System.EventHandler(this.mnuEucasmRef_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(218, 22);
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnSimulation
            // 
            this.mnSimulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRewind,
            this.mnuPlay,
            this.mnuPause,
            this.mnuStepForward,
            this.toolStripMenuItem2,
            this.mnuConfiguration});
            this.mnSimulation.Name = "mnSimulation";
            this.mnSimulation.Size = new System.Drawing.Size(67, 20);
            this.mnSimulation.Text = "&Simulation";
            // 
            // mnuRewind
            // 
            this.mnuRewind.Enabled = false;
            this.mnuRewind.Name = "mnuRewind";
            this.mnuRewind.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuRewind.Size = new System.Drawing.Size(175, 22);
            this.mnuRewind.Text = "&Rewind";
            this.mnuRewind.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // mnuPlay
            // 
            this.mnuPlay.Enabled = false;
            this.mnuPlay.Name = "mnuPlay";
            this.mnuPlay.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuPlay.Size = new System.Drawing.Size(175, 22);
            this.mnuPlay.Text = "&Play";
            this.mnuPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // mnuPause
            // 
            this.mnuPause.Enabled = false;
            this.mnuPause.Name = "mnuPause";
            this.mnuPause.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuPause.Size = new System.Drawing.Size(175, 22);
            this.mnuPause.Text = "P&ause";
            this.mnuPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // mnuStepForward
            // 
            this.mnuStepForward.Enabled = false;
            this.mnuStepForward.Name = "mnuStepForward";
            this.mnuStepForward.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuStepForward.Size = new System.Drawing.Size(175, 22);
            this.mnuStepForward.Text = "&Step forward";
            this.mnuStepForward.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // mnuConfiguration
            // 
            this.mnuConfiguration.Name = "mnuConfiguration";
            this.mnuConfiguration.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.mnuConfiguration.Size = new System.Drawing.Size(175, 22);
            this.mnuConfiguration.Text = "&Configuration";
            this.mnuConfiguration.Click += new System.EventHandler(this.mnuConfiguration_Click);
            // 
            // ToolBox
            // 
            this.ToolBox.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.toolStripSeparator2,
            this.btnAbout});
            this.ToolBox.Location = new System.Drawing.Point(3, 24);
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.Size = new System.Drawing.Size(64, 25);
            this.ToolBox.TabIndex = 12;
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.Text = "Open";
            this.btnOpen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOpen_MouseUp);
            this.btnOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAbout
            // 
            this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(23, 22);
            this.btnAbout.Text = "About";
            this.btnAbout.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAbout_MouseUp);
            this.btnAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // ConstructionControlBox
            // 
            this.ConstructionControlBox.Dock = System.Windows.Forms.DockStyle.None;
            this.ConstructionControlBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRestart,
            this.btnPlay,
            this.btnPause,
            this.btnStep});
            this.ConstructionControlBox.Location = new System.Drawing.Point(67, 24);
            this.ConstructionControlBox.Name = "ConstructionControlBox";
            this.ConstructionControlBox.Size = new System.Drawing.Size(104, 25);
            this.ConstructionControlBox.TabIndex = 13;
            // 
            // btnRestart
            // 
            this.btnRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRestart.Enabled = false;
            this.btnRestart.Image = ((System.Drawing.Image)(resources.GetObject("btnRestart.Image")));
            this.btnRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(23, 22);
            this.btnRestart.Text = "Draw again from begining";
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlay.Enabled = false;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.White;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(23, 22);
            this.btnPlay.Text = "Play";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPause.Enabled = false;
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(23, 22);
            this.btnPause.Text = "Pause";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStep
            // 
            this.btnStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStep.Enabled = false;
            this.btnStep.Image = ((System.Drawing.Image)(resources.GetObject("btnStep.Image")));
            this.btnStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(23, 22);
            this.btnStep.Text = "Play one step";
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // tmAnimation
            // 
            this.tmAnimation.Interval = 900;
            this.tmAnimation.Tick += new System.EventHandler(this.tmAnimation_Tick);
            // 
            // emoticons
            // 
            this.emoticons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("emoticons.ImageStream")));
            this.emoticons.TransparentColor = System.Drawing.Color.DimGray;
            this.emoticons.Images.SetKeyName(0, ":D");
            this.emoticons.Images.SetKeyName(1, "(loco)");
            // 
            // ExportDialog
            // 
            this.ExportDialog.Filter = "JPEG image (*.jpg,*.jpeg)|*.jpg;*.jpeg|PNG image (*.png)|*.png|GIF image (*.gif)|" +
                "*.gif|BMP bitmap (*.bmp)|*.bmp|Tiff graphics (*.tiff)|*.tiff|All images|*.jpg;*." +
                "jpeg;*.png;*.gif;*.bmp|All files|*.*";
            this.ExportDialog.FilterIndex = 2;
            this.ExportDialog.Title = "Exporting construction....";
            // 
            // ExportHTMLDialog
            // 
            this.ExportHTMLDialog.DefaultExt = "html";
            this.ExportHTMLDialog.Filter = "HTML files (*.html, *.htm)|*.html;*.htm|All files (*.*)|*.*";
            this.ExportHTMLDialog.Title = "Export HTML report of construction...";
            // 
            // MainWnd
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(771, 505);
            this.Controls.Add(this.WndContainer);
            this.Controls.Add(this.StatusBar);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWnd";
            this.Text = "Euclid#";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWnd_DragDrop);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWnd_FormClosing);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWnd_DragEnter);
            this.Load += new System.EventHandler(this.MainWnd_Load);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.WndContainer.ContentPanel.ResumeLayout(false);
            this.WndContainer.TopToolStripPanel.ResumeLayout(false);
            this.WndContainer.TopToolStripPanel.PerformLayout();
            this.WndContainer.ResumeLayout(false);
            this.WndContainer.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ToolBox.ResumeLayout(false);
            this.ToolBox.PerformLayout();
            this.ConstructionControlBox.ResumeLayout(false);
            this.ConstructionControlBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.Timer tmClock;
        private System.Windows.Forms.ToolStripStatusLabel sbComment;
        private System.Windows.Forms.ToolStripStatusLabel cbClock;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.ToolStripContainer WndContainer;
        private System.Windows.Forms.ToolStrip ToolBox;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem mnFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripSeparator ffsdf;
        private System.Windows.Forms.ToolStripMenuItem mniExit;
        private System.Windows.Forms.ToolStripMenuItem mnHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btnAbout;
        private System.Windows.Forms.ToolStrip ConstructionControlBox;
        private System.Windows.Forms.ToolStripButton btnPlay;
        private System.Windows.Forms.ToolStripButton btnStep;
        private System.Windows.Forms.ToolStripButton btnPause;
        private System.Windows.Forms.ToolStripButton btnRestart;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.Timer tmAnimation;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.ImageList emoticons;
        private System.Windows.Forms.SaveFileDialog ExportDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuRecent;
        private System.Windows.Forms.ToolStripMenuItem mnuRecentFile0;
        private System.Windows.Forms.ToolStripMenuItem mnuRecentFile1;
        private System.Windows.Forms.ToolStripMenuItem mnuRecentFile2;
        private System.Windows.Forms.ToolStripMenuItem mnuRecentFile3;
        private System.Windows.Forms.ToolStripMenuItem mnuRecentFile4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuClearRecent;
        private System.Windows.Forms.ToolStripMenuItem mnSimulation;
        private System.Windows.Forms.ToolStripMenuItem mnuRewind;
        private System.Windows.Forms.ToolStripMenuItem mnuPlay;
        private System.Windows.Forms.ToolStripMenuItem mnuPause;
        private System.Windows.Forms.ToolStripMenuItem mnuStepForward;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuConfiguration;
        private System.Windows.Forms.ToolStripMenuItem mnuHTMLraport;
        private System.Windows.Forms.SaveFileDialog ExportHTMLDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuEucasmRef;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

