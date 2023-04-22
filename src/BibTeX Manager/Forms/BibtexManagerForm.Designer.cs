using System;

namespace DigitalProduction.LineCounter
{
	/// <summary>
	/// Summary not provided for the class LineCounter.
	/// </summary>
	partial class BibtexManagerForm
	{
		#region Members

		private DigitalProduction.Forms.StatusBarWithProgress		statusBar;
		private System.Windows.Forms.StatusBarPanel					statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel					statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel					statusBarPanel3;
		private System.Windows.Forms.Timer							timerClock;

		private System.Windows.Forms.Button btnCount;
		private System.Windows.Forms.Button							btnGetFiles;
		private System.Windows.Forms.TextBox						txtbxFileLocation;
		private System.Windows.Forms.Label							lblFileLocation;

		private System.Windows.Forms.MenuStrip						menuMain;
		private System.Windows.Forms.ToolStripMenuItem				fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem				newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem				openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem				closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem				saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem				saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem				exitToolStripMenuItem;


		private System.Windows.Forms.ToolStripSeparator				toolStripSeparatorFile1;
		private System.Windows.Forms.ToolStripMenuItem				viewHelpToolStripMenuItem;

		private System.ComponentModel.IContainer					components;

		#endregion

		#region Disposing.

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#endregion

		#region Windows Form Designer generated code.

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibtexManagerForm));
			this.btnCount = new System.Windows.Forms.Button();
			this.timerClock = new System.Windows.Forms.Timer(this.components);
			this.btnGetFiles = new System.Windows.Forms.Button();
			this.txtbxFileLocation = new System.Windows.Forms.TextBox();
			this.lblFileLocation = new System.Windows.Forms.Label();
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparatorFile1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.grpbxFiles = new System.Windows.Forms.GroupBox();
			this.lnkReport = new System.Windows.Forms.LinkLabel();
			this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuMain.SuspendLayout();
			this.grpbxFiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCount
			// 
			this.btnCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCount.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCount.Location = new System.Drawing.Point(457, 450);
			this.btnCount.Name = "btnCount";
			this.btnCount.Size = new System.Drawing.Size(75, 23);
			this.btnCount.TabIndex = 6;
			this.btnCount.Text = "&Count";
			// 
			// btnGetFiles
			// 
			this.btnGetFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGetFiles.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnGetFiles.Location = new System.Drawing.Point(439, 33);
			this.btnGetFiles.Name = "btnGetFiles";
			this.btnGetFiles.Size = new System.Drawing.Size(75, 23);
			this.btnGetFiles.TabIndex = 4;
			this.btnGetFiles.Text = "&Get Files";
			this.btnGetFiles.Click += new System.EventHandler(this.ButtonGetFiles_Click);
			// 
			// txtbxFileLocation
			// 
			this.txtbxFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtbxFileLocation.Location = new System.Drawing.Point(10, 35);
			this.txtbxFileLocation.Name = "txtbxFileLocation";
			this.txtbxFileLocation.ReadOnly = true;
			this.txtbxFileLocation.Size = new System.Drawing.Size(423, 20);
			this.txtbxFileLocation.TabIndex = 3;
			this.txtbxFileLocation.TabStop = false;
			// 
			// lblFileLocation
			// 
			this.lblFileLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblFileLocation.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblFileLocation.Location = new System.Drawing.Point(11, 19);
			this.lblFileLocation.Name = "lblFileLocation";
			this.lblFileLocation.Size = new System.Drawing.Size(100, 23);
			this.lblFileLocation.TabIndex = 2;
			this.lblFileLocation.Text = "Location of Files:";
			this.lblFileLocation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// menuMain
			// 
			this.menuMain.BackColor = System.Drawing.SystemColors.Control;
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuMain.Location = new System.Drawing.Point(0, 0);
			this.menuMain.Name = "menuMain";
			this.menuMain.Size = new System.Drawing.Size(540, 24);
			this.menuMain.TabIndex = 0;
			this.menuMain.Text = "Menu Bar";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparatorFile1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.newToolStripMenuItem.Text = "&New...";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.MenuFileNew_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.openToolStripMenuItem.Text = "&Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.MenuFileOpen_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.MenuFileClose_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.MenuFileSave_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.MenuFileSaveAs_Click);
			// 
			// toolStripSeparatorFile1
			// 
			this.toolStripSeparatorFile1.Name = "toolStripSeparatorFile1";
			this.toolStripSeparatorFile1.Size = new System.Drawing.Size(177, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuExit_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// viewHelpToolStripMenuItem
			// 
			this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
			this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.viewHelpToolStripMenuItem.Text = "&View Help";
			this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.MenuHelp_Click);
			// 
			// grpbxFiles
			// 
			this.grpbxFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpbxFiles.Controls.Add(this.txtbxFileLocation);
			this.grpbxFiles.Controls.Add(this.btnGetFiles);
			this.grpbxFiles.Controls.Add(this.lblFileLocation);
			this.grpbxFiles.Location = new System.Drawing.Point(8, 32);
			this.grpbxFiles.Name = "grpbxFiles";
			this.grpbxFiles.Size = new System.Drawing.Size(524, 65);
			this.grpbxFiles.TabIndex = 11;
			this.grpbxFiles.TabStop = false;
			this.grpbxFiles.Text = "Files";
			// 
			// lnkReport
			// 
			this.lnkReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lnkReport.AutoSize = true;
			this.lnkReport.Location = new System.Drawing.Point(5, 455);
			this.lnkReport.Name = "lnkReport";
			this.lnkReport.Size = new System.Drawing.Size(65, 13);
			this.lnkReport.TabIndex = 12;
			this.lnkReport.TabStop = true;
			this.lnkReport.Text = "View Report";
			this.lnkReport.Visible = false;
			this.lnkReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReport_LinkClicked);
			// 
			// projectToolStripMenuItem
			// 
			this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
			this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.projectToolStripMenuItem.Text = "&Project";
			// 
			// BibtexManagerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(540, 502);
			this.Controls.Add(this.lnkReport);
			this.Controls.Add(this.grpbxFiles);
			this.Controls.Add(this.btnCount);
			this.Controls.Add(this.menuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuMain;
			this.MinimumSize = new System.Drawing.Size(330, 530);
			this.Name = "BibtexManagerForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "BibTeX Manager";
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.grpbxFiles.ResumeLayout(false);
			this.grpbxFiles.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.GroupBox grpbxFiles;
		private System.Windows.Forms.LinkLabel lnkReport;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
	} // End class.
} // End namespace.