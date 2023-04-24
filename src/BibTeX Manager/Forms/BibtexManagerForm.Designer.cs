namespace BibtexManager
{
	/// <summary>
	/// Summary not provided for the class LineCounter.
	/// </summary>
	partial class BibtexManagerForm
	{
		#region Members

		private System.Windows.Forms.MenuStrip									menuMain;
		private System.Windows.Forms.ToolStripMenuItem							fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem							newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem							openToolStripMenuItem;
		private DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem		closeToolStripMenuItem;
		private DigitalProduction.Forms.SaveToolStripMenuItem					saveToolStripMenuItem;
		private DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem		saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator							toolStripSeparatorFile1;
		private System.Windows.Forms.ToolStripMenuItem							exitToolStripMenuItem;


		private DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem		projectToolStripMenuItem;
		private DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem		modifyProjectToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem							helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem							viewHelpToolStripMenuItem;

		private System.ComponentModel.IContainer								components;

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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibtexManagerForm));
			this.menuMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem();
			this.saveToolStripMenuItem = new DigitalProduction.Forms.SaveToolStripMenuItem();
			this.saveAsToolStripMenuItem = new DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem();
			this.toolStripSeparatorFile1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectToolStripMenuItem = new DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem();
			this.modifyProjectToolStripMenuItem = new DigitalProduction.Forms.EnableOpenProjectToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bibEntriesDataGridView = new System.Windows.Forms.DataGridView();
			this.referencesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.menuMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bibEntriesDataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.referencesBindingSource)).BeginInit();
			this.SuspendLayout();
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
			this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.newToolStripMenuItem.Text = "&New...";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.MenuFileNew_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.openToolStripMenuItem.Text = "&Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.MenuFileOpen_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Enabled = false;
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.MenuFileSave_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Enabled = false;
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.MenuFileSaveAs_Click);
			// 
			// toolStripSeparatorFile1
			// 
			this.toolStripSeparatorFile1.Name = "toolStripSeparatorFile1";
			this.toolStripSeparatorFile1.Size = new System.Drawing.Size(152, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
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
			this.modifyProjectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.modifyProjectToolStripMenuItem.Text = "&Modify Project";
			this.modifyProjectToolStripMenuItem.Click += new System.EventHandler(this.ModifyProjectToolStripMenuItem_Click);
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
			this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.viewHelpToolStripMenuItem.Text = "&View Help";
			this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.MenuHelp_Click);
			// 
			// bibEntriesDataGridView
			// 
			this.bibEntriesDataGridView.AllowUserToAddRows = false;
			this.bibEntriesDataGridView.AllowUserToDeleteRows = false;
			this.bibEntriesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bibEntriesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.bibEntriesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.bibEntriesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.bibEntriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.bibEntriesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Title});
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.bibEntriesDataGridView.DefaultCellStyle = dataGridViewCellStyle9;
			this.bibEntriesDataGridView.Location = new System.Drawing.Point(12, 140);
			this.bibEntriesDataGridView.Name = "bibEntriesDataGridView";
			this.bibEntriesDataGridView.ReadOnly = true;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.bibEntriesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.bibEntriesDataGridView.RowHeadersVisible = false;
			this.bibEntriesDataGridView.RowHeadersWidth = 20;
			this.bibEntriesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.bibEntriesDataGridView.Size = new System.Drawing.Size(516, 273);
			this.bibEntriesDataGridView.TabIndex = 24;
			// 
			// referencesBindingSource
			// 
			this.referencesBindingSource.DataSource = typeof(BibTeXLibrary.BibEntry);
			// 
			// Key
			// 
			this.Key.DataPropertyName = "Key";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.Key.DefaultCellStyle = dataGridViewCellStyle7;
			this.Key.FillWeight = 10F;
			this.Key.HeaderText = "Key";
			this.Key.MinimumWidth = 100;
			this.Key.Name = "Key";
			this.Key.ReadOnly = true;
			// 
			// Title
			// 
			this.Title.DataPropertyName = "Title";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle8.Format = "N1";
			dataGridViewCellStyle8.NullValue = null;
			this.Title.DefaultCellStyle = dataGridViewCellStyle8;
			this.Title.FillWeight = 90F;
			this.Title.HeaderText = "Title";
			this.Title.MinimumWidth = 90;
			this.Title.Name = "Title";
			this.Title.ReadOnly = true;
			// 
			// BibtexManagerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(540, 502);
			this.Controls.Add(this.bibEntriesDataGridView);
			this.Controls.Add(this.menuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuMain;
			this.MinimumSize = new System.Drawing.Size(330, 530);
			this.Name = "BibtexManagerForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "BibTeX Manager";
			this.menuMain.ResumeLayout(false);
			this.menuMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bibEntriesDataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.referencesBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		internal System.Windows.Forms.DataGridView bibEntriesDataGridView;
		private System.Windows.Forms.BindingSource referencesBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn Key;
		private System.Windows.Forms.DataGridViewTextBoxColumn Title;
	} // End class.
} // End namespace.