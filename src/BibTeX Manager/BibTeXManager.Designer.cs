using System;

namespace DigitalProduction.LineCounter
{
	/// <summary>
	/// Summary not provided for the class LineCounter.
	/// </summary>
	partial class BibTeXManager
	{
		#region Members / Variables.

		private DigitalProduction.Forms.StatusBarWithProgress		statusBar;
		private System.Windows.Forms.StatusBarPanel					statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel					statusBarPanel2;
		private System.Windows.Forms.StatusBarPanel					statusBarPanel3;
		private System.Windows.Forms.Timer							tmrClock;

		private System.Windows.Forms.Button btnCount;
		private System.Windows.Forms.Button							btnGetFiles;
		private System.Windows.Forms.TextBox						txtbxFileLocation;
		private System.Windows.Forms.Label							lblFileLocation;

		private System.Windows.Forms.MenuStrip						mnuMain;
		private System.Windows.Forms.ToolStripMenuItem				mnuFile;
		private System.Windows.Forms.ToolStripMenuItem				mnuExit;
		private System.Windows.Forms.ToolStripSeparator				mnusepFile1;
		private System.Windows.Forms.ToolStripMenuItem				mnuHelp;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibTeXManager));
			this.btnCount = new System.Windows.Forms.Button();
			this.tmrClock = new System.Windows.Forms.Timer(this.components);
			this.btnGetFiles = new System.Windows.Forms.Button();
			this.txtbxFileLocation = new System.Windows.Forms.TextBox();
			this.lblFileLocation = new System.Windows.Forms.Label();
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnusepFile1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.grpbxFiles = new System.Windows.Forms.GroupBox();
			this.lnkReport = new System.Windows.Forms.LinkLabel();
			this.mnuMain.SuspendLayout();
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
			this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
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
			// mnuMain
			// 
			this.mnuMain.BackColor = System.Drawing.SystemColors.Control;
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(540, 24);
			this.mnuMain.TabIndex = 0;
			this.mnuMain.Text = "Menu Bar";
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelp,
            this.mnusepFile1,
            this.mnuExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(37, 20);
			this.mnuFile.Text = "&File";
			// 
			// mnuHelp
			// 
			this.mnuHelp.Name = "mnuHelp";
			this.mnuHelp.Size = new System.Drawing.Size(99, 22);
			this.mnuHelp.Text = "&Help";
			this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
			// 
			// mnusepFile1
			// 
			this.mnusepFile1.Name = "mnusepFile1";
			this.mnusepFile1.Size = new System.Drawing.Size(96, 6);
			// 
			// mnuExit
			// 
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(99, 22);
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
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
			// BibTeXManager
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(540, 502);
			this.Controls.Add(this.lnkReport);
			this.Controls.Add(this.grpbxFiles);
			this.Controls.Add(this.btnCount);
			this.Controls.Add(this.mnuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mnuMain;
			this.MinimumSize = new System.Drawing.Size(330, 530);
			this.Name = "BibTeXManager";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "BibTeX Manager";
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.grpbxFiles.ResumeLayout(false);
			this.grpbxFiles.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.GroupBox grpbxFiles;
		private System.Windows.Forms.LinkLabel lnkReport;

	} // End class.
} // End namespace.