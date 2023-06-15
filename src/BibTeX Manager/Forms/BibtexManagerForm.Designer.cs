namespace BibtexManager
{
	/// <summary>
	/// Summary not provided for the class LineCounter.
	/// </summary>
	partial class BibtexManagerForm
	{
		#region Fields

		// Menu.
		private System.Windows.Forms.MenuStrip									menuMain;

		// File menu.
		private System.Windows.Forms.ToolStripMenuItem							fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem							newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem							openToolStripMenuItem;
		private DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem		closeToolStripMenuItem;
		private DigitalProduction.Forms.SaveToolStripMenuItem					saveToolStripMenuItem;
		private DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem		saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator							toolStripSeparatorFile1;
		private System.Windows.Forms.ToolStripMenuItem							recentFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator							toolStripSeparatorFile2;
		private System.Windows.Forms.ToolStripMenuItem							exitToolStripMenuItem;

		// Project menu.
		private DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem		projectToolStripMenuItem;
		private DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem		modifyProjectToolStripMenuItem;

		// Tools menu.
		private System.Windows.Forms.ToolStripMenuItem							toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem							optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem							qualityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem							sortBibliographyEntriesToolStripMenuItem;

		// Help menu.
		private System.Windows.Forms.ToolStripMenuItem							helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem							viewHelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem							aboutToolStripMenuItem;

		// Containers.
		private DigitalProduction.Forms.EnableOpenProjectPanel					enableOpenProjectPanel;

		// DataGridView.
		internal System.Windows.Forms.DataGridView								bibEntriesDataGridView;
		private System.Windows.Forms.BindingSource								referencesBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn					Key;
		//private System.Windows.Forms.DataGridViewTextBoxColumn					keyDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn					authorDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn					Title;

		private BibManagerDataGridViewControl									dataGridViewInterfaceControl;

		// Components.
		private System.ComponentModel.IContainer								components;

		#endregion

		#region Disposing

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

		#region Windows Form Designer Generated Code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibtexManagerForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.referencesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new DigitalProduction.Forms.SaveToolStripMenuItem();
			this.saveAsToolStripMenuItem = new DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem();
			this.closeToolStripMenuItem = new DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem();
			this.toolStripSeparatorFile1 = new System.Windows.Forms.ToolStripSeparator();
			this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparatorFile2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectToolStripMenuItem = new DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem();
			this.modifyProjectToolStripMenuItem = new DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.qualityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sortBibliographyEntriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkTagQualityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.enableOpenProjectPanel = new DigitalProduction.Forms.EnableOpenProjectPanel();
			this.bibEntriesDataGridView = new System.Windows.Forms.DataGridView();
			this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewInterfaceControl = new BibtexManager.BibManagerDataGridViewControl();
			((System.ComponentModel.ISupportInitialize)(this.referencesBindingSource)).BeginInit();
			this.menuMain.SuspendLayout();
			this.enableOpenProjectPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bibEntriesDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// referencesBindingSource
			// 
			this.referencesBindingSource.DataSource = typeof(BibTeXLibrary.BibEntry);
			// 
			// menuMain
			// 
			this.menuMain.BackColor = System.Drawing.SystemColors.Control;
			this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.toolsToolStripMenuItem,
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
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparatorFile1,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparatorFile2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.newToolStripMenuItem.Text = "&New...";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openToolStripMenuItem.Text = "&Open..";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Enabled = false;
			this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As...";
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Enabled = false;
			this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			// 
			// toolStripSeparatorFile1
			// 
			this.toolStripSeparatorFile1.Name = "toolStripSeparatorFile1";
			this.toolStripSeparatorFile1.Size = new System.Drawing.Size(149, 6);
			// 
			// recentFilesToolStripMenuItem
			// 
			this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
			this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.recentFilesToolStripMenuItem.Text = "&Recent Files";
			// 
			// toolStripSeparatorFile2
			// 
			this.toolStripSeparatorFile2.Name = "toolStripSeparatorFile2";
			this.toolStripSeparatorFile2.Size = new System.Drawing.Size(149, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuExit_Click);
			// 
			// projectToolStripMenuItem
			// 
			this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyProjectToolStripMenuItem});
			this.projectToolStripMenuItem.Enabled = false;
			this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
			this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.projectToolStripMenuItem.Text = "&Project";
			// 
			// modifyProjectToolStripMenuItem
			// 
			this.modifyProjectToolStripMenuItem.Enabled = false;
			this.modifyProjectToolStripMenuItem.Name = "modifyProjectToolStripMenuItem";
			this.modifyProjectToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.modifyProjectToolStripMenuItem.Text = "Project &Settings";
			this.modifyProjectToolStripMenuItem.Click += new System.EventHandler(this.ModifyProjectToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.qualityToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
			// 
			// qualityToolStripMenuItem
			// 
			this.qualityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortBibliographyEntriesToolStripMenuItem,
            this.checkTagQualityToolStripMenuItem});
			this.qualityToolStripMenuItem.Name = "qualityToolStripMenuItem";
			this.qualityToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.qualityToolStripMenuItem.Text = "Quality";
			// 
			// sortBibliographyEntriesToolStripMenuItem
			// 
			this.sortBibliographyEntriesToolStripMenuItem.Name = "sortBibliographyEntriesToolStripMenuItem";
			this.sortBibliographyEntriesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.sortBibliographyEntriesToolStripMenuItem.Text = "Sort Bibliography Entries";
			this.sortBibliographyEntriesToolStripMenuItem.Click += new System.EventHandler(this.SortBibliographyEntriesToolStripMenuItem_Click);
			// 
			// checkTagQualityToolStripMenuItem
			// 
			this.checkTagQualityToolStripMenuItem.Name = "checkTagQualityToolStripMenuItem";
			this.checkTagQualityToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.checkTagQualityToolStripMenuItem.Text = "Check Tag Quality";
			this.checkTagQualityToolStripMenuItem.Click += new System.EventHandler(this.CheckTagQualityToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// viewHelpToolStripMenuItem
			// 
			this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
			this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.viewHelpToolStripMenuItem.Text = "&View Help";
			this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.MenuHelp_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// enableOpenProjectPanel
			// 
			this.enableOpenProjectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.enableOpenProjectPanel.Controls.Add(this.bibEntriesDataGridView);
			this.enableOpenProjectPanel.Controls.Add(this.dataGridViewInterfaceControl);
			this.enableOpenProjectPanel.Enabled = false;
			this.enableOpenProjectPanel.Location = new System.Drawing.Point(0, 50);
			this.enableOpenProjectPanel.Name = "enableOpenProjectPanel";
			this.enableOpenProjectPanel.Size = new System.Drawing.Size(540, 535);
			this.enableOpenProjectPanel.TabIndex = 26;
			// 
			// bibEntriesDataGridView
			// 
			this.bibEntriesDataGridView.AllowUserToAddRows = false;
			this.bibEntriesDataGridView.AllowUserToDeleteRows = false;
			this.bibEntriesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bibEntriesDataGridView.AutoGenerateColumns = false;
			this.bibEntriesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.bibEntriesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.bibEntriesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.bibEntriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.bibEntriesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.authorDataGridViewTextBoxColumn,
            this.Title});
			this.bibEntriesDataGridView.DataSource = this.referencesBindingSource;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.bibEntriesDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
			this.bibEntriesDataGridView.Location = new System.Drawing.Point(12, 48);
			this.bibEntriesDataGridView.Name = "bibEntriesDataGridView";
			this.bibEntriesDataGridView.ReadOnly = true;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.bibEntriesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.bibEntriesDataGridView.RowHeadersVisible = false;
			this.bibEntriesDataGridView.RowHeadersWidth = 20;
			this.bibEntriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.bibEntriesDataGridView.Size = new System.Drawing.Size(516, 484);
			this.bibEntriesDataGridView.TabIndex = 24;
			this.bibEntriesDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView_KeyUp);
			// 
			// Key
			// 
			this.Key.DataPropertyName = "Key";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.Key.DefaultCellStyle = dataGridViewCellStyle2;
			this.Key.FillWeight = 10F;
			this.Key.HeaderText = "Key";
			this.Key.MinimumWidth = 100;
			this.Key.Name = "Key";
			this.Key.ReadOnly = true;
			// 
			// authorDataGridViewTextBoxColumn
			// 
			this.authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
			this.authorDataGridViewTextBoxColumn.FillWeight = 80F;
			this.authorDataGridViewTextBoxColumn.HeaderText = "Author";
			this.authorDataGridViewTextBoxColumn.MinimumWidth = 80;
			this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
			this.authorDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// Title
			// 
			this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Title.DataPropertyName = "Title";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.Format = "N1";
			dataGridViewCellStyle3.NullValue = null;
			this.Title.DefaultCellStyle = dataGridViewCellStyle3;
			this.Title.FillWeight = 150F;
			this.Title.HeaderText = "Title";
			this.Title.MinimumWidth = 120;
			this.Title.Name = "Title";
			this.Title.ReadOnly = true;
			// 
			// dataGridViewInterfaceControl
			// 
			this.dataGridViewInterfaceControl.AddLocation = DigitalProduction.Forms.DataGridViewAddLocation.Bottom;
			this.dataGridViewInterfaceControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridViewInterfaceControl.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.dataGridViewInterfaceControl.BindingSource = this.referencesBindingSource;
			this.dataGridViewInterfaceControl.DataGridView = this.bibEntriesDataGridView;
			this.dataGridViewInterfaceControl.Location = new System.Drawing.Point(12, 13);
			this.dataGridViewInterfaceControl.Name = "dataGridViewInterfaceControl";
			this.dataGridViewInterfaceControl.Project = null;
			this.dataGridViewInterfaceControl.ReadOnly = false;
			this.dataGridViewInterfaceControl.ShowInsertButtons = false;
			this.dataGridViewInterfaceControl.ShowMoveButtons = false;
			this.dataGridViewInterfaceControl.Size = new System.Drawing.Size(516, 31);
			this.dataGridViewInterfaceControl.TabIndex = 25;
			// 
			// BibtexManagerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(540, 609);
			this.Controls.Add(this.enableOpenProjectPanel);
			this.Controls.Add(this.menuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuMain;
			this.MinimumSize = new System.Drawing.Size(330, 530);
			this.Name = "BibtexManagerForm";
			this.ShowProjectToolbar = true;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "BibTeX Manager";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.referencesBindingSource)).EndInit();
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			this.enableOpenProjectPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bibEntriesDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private System.Windows.Forms.ToolStripMenuItem checkTagQualityToolStripMenuItem;
	} // End class.
} // End namespace.