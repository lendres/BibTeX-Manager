namespace BibtexManager
{
	partial class ProjectSettingsForm
	{

		#region Fields

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#endregion

		#region Disposing

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

		#endregion

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.bibFileGroupBox = new System.Windows.Forms.GroupBox();
			this.useRelativePathsCheckBox = new System.Windows.Forms.CheckBox();
			this.bibFileLocationTextBox = new System.Windows.Forms.TextBox();
			this.browseBibFileButton = new System.Windows.Forms.Button();
			this.accessoryFilesGroupBox = new System.Windows.Forms.GroupBox();
			this.addButton = new System.Windows.Forms.Button();
			this.removeButton = new System.Windows.Forms.Button();
			this.assessoryFilesListBox = new System.Windows.Forms.ListBox();
			this.tabsGroupBox = new System.Windows.Forms.GroupBox();
			this.tabSizeLabel = new System.Windows.Forms.Label();
			this.tabSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.insertTabsRadioButton = new System.Windows.Forms.RadioButton();
			this.insertSpacesRadioButton = new System.Windows.Forms.RadioButton();
			this.alignmentGroupBox = new System.Windows.Forms.GroupBox();
			this.alignmentTabStopLabel = new System.Windows.Forms.Label();
			this.alignmentTabStopNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.alignmentColumnLabel = new System.Windows.Forms.Label();
			this.alignmentColumnNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.alignTagValuesCheckBox = new System.Windows.Forms.CheckBox();
			this.styleGroupBox = new System.Windows.Forms.GroupBox();
			this.useBibEntryMapCheckBox = new System.Windows.Forms.CheckBox();
			this.useConstantStringsCheckBox = new System.Windows.Forms.CheckBox();
			this.copyCiteKeyCheckBox = new System.Windows.Forms.CheckBox();
			this.autoGenerateKeysCheckBox = new System.Windows.Forms.CheckBox();
			this.removeLastCommaCheckBox = new System.Windows.Forms.CheckBox();
			this.bibEntryInitializationGroupBox = new System.Windows.Forms.GroupBox();
			this.useBibEntryInitializationCheckBox = new System.Windows.Forms.CheckBox();
			this.bibEntryInitializationFileTextBox = new System.Windows.Forms.TextBox();
			this.browseBibEntryInitializationFileButton = new System.Windows.Forms.Button();
			this.qualityProcessorGroupBox = new System.Windows.Forms.GroupBox();
			this.useQualityProcessingCheckBox = new System.Windows.Forms.CheckBox();
			this.qualityProcessingFileTextBox = new System.Windows.Forms.TextBox();
			this.browseQualityProcessorButton = new System.Windows.Forms.Button();
			this.remappingFileGroupBox = new System.Windows.Forms.GroupBox();
			this.useRemappingCheckBox = new System.Windows.Forms.CheckBox();
			this.remappingFileTextBox = new System.Windows.Forms.TextBox();
			this.remappingFileBrowseButton = new System.Windows.Forms.Button();
			this.organizationGroupBox = new System.Windows.Forms.GroupBox();
			this.sortBibliographyEntriesComboBox = new System.Windows.Forms.ComboBox();
			this.sortBibliographyEntriesCheckBox = new System.Windows.Forms.CheckBox();
			this.bibFileGroupBox.SuspendLayout();
			this.accessoryFilesGroupBox.SuspendLayout();
			this.tabsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tabSizeNumericUpDown)).BeginInit();
			this.alignmentGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.alignmentTabStopNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.alignmentColumnNumericUpDown)).BeginInit();
			this.styleGroupBox.SuspendLayout();
			this.bibEntryInitializationGroupBox.SuspendLayout();
			this.qualityProcessorGroupBox.SuspendLayout();
			this.remappingFileGroupBox.SuspendLayout();
			this.organizationGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(499, 662);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(80, 23);
			this.cancelButton.TabIndex = 25;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(401, 662);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(80, 23);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.ButtonOK_Click);
			// 
			// bibFileGroupBox
			// 
			this.bibFileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bibFileGroupBox.Controls.Add(this.bibFileLocationTextBox);
			this.bibFileGroupBox.Controls.Add(this.browseBibFileButton);
			this.bibFileGroupBox.Location = new System.Drawing.Point(12, 38);
			this.bibFileGroupBox.Name = "bibFileGroupBox";
			this.bibFileGroupBox.Size = new System.Drawing.Size(567, 51);
			this.bibFileGroupBox.TabIndex = 26;
			this.bibFileGroupBox.TabStop = false;
			this.bibFileGroupBox.Text = "Bibliography File";
			// 
			// useRelativePathsCheckBox
			// 
			this.useRelativePathsCheckBox.AutoSize = true;
			this.useRelativePathsCheckBox.Location = new System.Drawing.Point(22, 12);
			this.useRelativePathsCheckBox.Name = "useRelativePathsCheckBox";
			this.useRelativePathsCheckBox.Size = new System.Drawing.Size(177, 17);
			this.useRelativePathsCheckBox.TabIndex = 28;
			this.useRelativePathsCheckBox.Text = "Use paths relative to project file.";
			this.useRelativePathsCheckBox.UseVisualStyleBackColor = true;
			this.useRelativePathsCheckBox.CheckedChanged += new System.EventHandler(this.useRelativePathsCheckBox_CheckedChanged);
			// 
			// bibFileLocationTextBox
			// 
			this.bibFileLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bibFileLocationTextBox.Location = new System.Drawing.Point(10, 21);
			this.bibFileLocationTextBox.Name = "bibFileLocationTextBox";
			this.bibFileLocationTextBox.Size = new System.Drawing.Size(466, 20);
			this.bibFileLocationTextBox.TabIndex = 3;
			this.bibFileLocationTextBox.TabStop = false;
			// 
			// browseBibFileButton
			// 
			this.browseBibFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.browseBibFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.browseBibFileButton.Location = new System.Drawing.Point(482, 19);
			this.browseBibFileButton.Name = "browseBibFileButton";
			this.browseBibFileButton.Size = new System.Drawing.Size(75, 23);
			this.browseBibFileButton.TabIndex = 4;
			this.browseBibFileButton.Text = "Brow&se";
			this.browseBibFileButton.Click += new System.EventHandler(this.BrowseBibFileButton_Click);
			// 
			// accessoryFilesGroupBox
			// 
			this.accessoryFilesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.accessoryFilesGroupBox.Controls.Add(this.addButton);
			this.accessoryFilesGroupBox.Controls.Add(this.removeButton);
			this.accessoryFilesGroupBox.Controls.Add(this.assessoryFilesListBox);
			this.accessoryFilesGroupBox.Location = new System.Drawing.Point(12, 101);
			this.accessoryFilesGroupBox.Name = "accessoryFilesGroupBox";
			this.accessoryFilesGroupBox.Size = new System.Drawing.Size(567, 79);
			this.accessoryFilesGroupBox.TabIndex = 27;
			this.accessoryFilesGroupBox.TabStop = false;
			this.accessoryFilesGroupBox.Text = "Assessory Files";
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.addButton.Location = new System.Drawing.Point(482, 17);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(80, 23);
			this.addButton.TabIndex = 4;
			this.addButton.Text = "&Add";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.AddAssessoryFileButton_Click);
			// 
			// removeButton
			// 
			this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.removeButton.Location = new System.Drawing.Point(482, 46);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(80, 23);
			this.removeButton.TabIndex = 3;
			this.removeButton.Text = "&Remove";
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new System.EventHandler(this.RemoveAssessoryFileButton_Click);
			// 
			// assessoryFilesListBox
			// 
			this.assessoryFilesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.assessoryFilesListBox.BackColor = System.Drawing.SystemColors.Control;
			this.assessoryFilesListBox.FormattingEnabled = true;
			this.assessoryFilesListBox.Location = new System.Drawing.Point(10, 18);
			this.assessoryFilesListBox.Name = "assessoryFilesListBox";
			this.assessoryFilesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.assessoryFilesListBox.Size = new System.Drawing.Size(466, 43);
			this.assessoryFilesListBox.TabIndex = 2;
			// 
			// tabsGroupBox
			// 
			this.tabsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tabsGroupBox.Controls.Add(this.tabSizeLabel);
			this.tabsGroupBox.Controls.Add(this.tabSizeNumericUpDown);
			this.tabsGroupBox.Controls.Add(this.insertTabsRadioButton);
			this.tabsGroupBox.Controls.Add(this.insertSpacesRadioButton);
			this.tabsGroupBox.Location = new System.Drawing.Point(12, 451);
			this.tabsGroupBox.Name = "tabsGroupBox";
			this.tabsGroupBox.Size = new System.Drawing.Size(164, 100);
			this.tabsGroupBox.TabIndex = 28;
			this.tabsGroupBox.TabStop = false;
			this.tabsGroupBox.Text = "Tabs";
			// 
			// tabSizeLabel
			// 
			this.tabSizeLabel.AutoSize = true;
			this.tabSizeLabel.Location = new System.Drawing.Point(7, 22);
			this.tabSizeLabel.Name = "tabSizeLabel";
			this.tabSizeLabel.Size = new System.Drawing.Size(50, 13);
			this.tabSizeLabel.TabIndex = 3;
			this.tabSizeLabel.Text = "Tab size:";
			// 
			// tabSizeNumericUpDown
			// 
			this.tabSizeNumericUpDown.Location = new System.Drawing.Point(101, 18);
			this.tabSizeNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.tabSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.tabSizeNumericUpDown.Name = "tabSizeNumericUpDown";
			this.tabSizeNumericUpDown.Size = new System.Drawing.Size(54, 20);
			this.tabSizeNumericUpDown.TabIndex = 2;
			this.tabSizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// insertTabsRadioButton
			// 
			this.insertTabsRadioButton.AutoSize = true;
			this.insertTabsRadioButton.Location = new System.Drawing.Point(10, 73);
			this.insertTabsRadioButton.Name = "insertTabsRadioButton";
			this.insertTabsRadioButton.Size = new System.Drawing.Size(74, 17);
			this.insertTabsRadioButton.TabIndex = 1;
			this.insertTabsRadioButton.TabStop = true;
			this.insertTabsRadioButton.Text = "Insert tabs";
			this.insertTabsRadioButton.UseVisualStyleBackColor = true;
			this.insertTabsRadioButton.CheckedChanged += new System.EventHandler(this.AlignTagValuesCheckBox_CheckedChanged);
			// 
			// insertSpacesRadioButton
			// 
			this.insertSpacesRadioButton.AutoSize = true;
			this.insertSpacesRadioButton.Location = new System.Drawing.Point(10, 49);
			this.insertSpacesRadioButton.Name = "insertSpacesRadioButton";
			this.insertSpacesRadioButton.Size = new System.Drawing.Size(88, 17);
			this.insertSpacesRadioButton.TabIndex = 0;
			this.insertSpacesRadioButton.TabStop = true;
			this.insertSpacesRadioButton.Text = "Insert spaces";
			this.insertSpacesRadioButton.UseVisualStyleBackColor = true;
			this.insertSpacesRadioButton.CheckedChanged += new System.EventHandler(this.AlignTagValuesCheckBox_CheckedChanged);
			// 
			// alignmentGroupBox
			// 
			this.alignmentGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.alignmentGroupBox.Controls.Add(this.alignmentTabStopLabel);
			this.alignmentGroupBox.Controls.Add(this.alignmentTabStopNumericUpDown);
			this.alignmentGroupBox.Controls.Add(this.alignmentColumnLabel);
			this.alignmentGroupBox.Controls.Add(this.alignmentColumnNumericUpDown);
			this.alignmentGroupBox.Controls.Add(this.alignTagValuesCheckBox);
			this.alignmentGroupBox.Location = new System.Drawing.Point(192, 451);
			this.alignmentGroupBox.Name = "alignmentGroupBox";
			this.alignmentGroupBox.Size = new System.Drawing.Size(170, 100);
			this.alignmentGroupBox.TabIndex = 29;
			this.alignmentGroupBox.TabStop = false;
			this.alignmentGroupBox.Text = "Alignment";
			// 
			// alignmentTabStopLabel
			// 
			this.alignmentTabStopLabel.AutoSize = true;
			this.alignmentTabStopLabel.Location = new System.Drawing.Point(7, 70);
			this.alignmentTabStopLabel.Name = "alignmentTabStopLabel";
			this.alignmentTabStopLabel.Size = new System.Drawing.Size(97, 13);
			this.alignmentTabStopLabel.TabIndex = 7;
			this.alignmentTabStopLabel.Text = "Alignment tab stop:";
			// 
			// alignmentTabStopNumericUpDown
			// 
			this.alignmentTabStopNumericUpDown.Location = new System.Drawing.Point(106, 66);
			this.alignmentTabStopNumericUpDown.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.alignmentTabStopNumericUpDown.Name = "alignmentTabStopNumericUpDown";
			this.alignmentTabStopNumericUpDown.Size = new System.Drawing.Size(54, 20);
			this.alignmentTabStopNumericUpDown.TabIndex = 6;
			this.alignmentTabStopNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
			// 
			// alignmentColumnLabel
			// 
			this.alignmentColumnLabel.AutoSize = true;
			this.alignmentColumnLabel.Location = new System.Drawing.Point(7, 45);
			this.alignmentColumnLabel.Name = "alignmentColumnLabel";
			this.alignmentColumnLabel.Size = new System.Drawing.Size(93, 13);
			this.alignmentColumnLabel.TabIndex = 5;
			this.alignmentColumnLabel.Text = "Alignment column:";
			// 
			// alignmentColumnNumericUpDown
			// 
			this.alignmentColumnNumericUpDown.Location = new System.Drawing.Point(106, 41);
			this.alignmentColumnNumericUpDown.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
			this.alignmentColumnNumericUpDown.Name = "alignmentColumnNumericUpDown";
			this.alignmentColumnNumericUpDown.Size = new System.Drawing.Size(54, 20);
			this.alignmentColumnNumericUpDown.TabIndex = 4;
			this.alignmentColumnNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
			// 
			// alignTagValuesCheckBox
			// 
			this.alignTagValuesCheckBox.AutoSize = true;
			this.alignTagValuesCheckBox.Location = new System.Drawing.Point(7, 20);
			this.alignTagValuesCheckBox.Name = "alignTagValuesCheckBox";
			this.alignTagValuesCheckBox.Size = new System.Drawing.Size(104, 17);
			this.alignTagValuesCheckBox.TabIndex = 0;
			this.alignTagValuesCheckBox.Text = "Align tag values.";
			this.alignTagValuesCheckBox.UseVisualStyleBackColor = true;
			this.alignTagValuesCheckBox.CheckedChanged += new System.EventHandler(this.AlignTagValuesCheckBox_CheckedChanged);
			// 
			// styleGroupBox
			// 
			this.styleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.styleGroupBox.Controls.Add(this.useBibEntryMapCheckBox);
			this.styleGroupBox.Controls.Add(this.useConstantStringsCheckBox);
			this.styleGroupBox.Controls.Add(this.copyCiteKeyCheckBox);
			this.styleGroupBox.Controls.Add(this.autoGenerateKeysCheckBox);
			this.styleGroupBox.Controls.Add(this.removeLastCommaCheckBox);
			this.styleGroupBox.Location = new System.Drawing.Point(12, 560);
			this.styleGroupBox.Name = "styleGroupBox";
			this.styleGroupBox.Size = new System.Drawing.Size(567, 92);
			this.styleGroupBox.TabIndex = 30;
			this.styleGroupBox.TabStop = false;
			this.styleGroupBox.Text = "Automation";
			// 
			// useBibEntryMapCheckBox
			// 
			this.useBibEntryMapCheckBox.AutoSize = true;
			this.useBibEntryMapCheckBox.Location = new System.Drawing.Point(233, 43);
			this.useBibEntryMapCheckBox.Name = "useBibEntryMapCheckBox";
			this.useBibEntryMapCheckBox.Size = new System.Drawing.Size(211, 17);
			this.useBibEntryMapCheckBox.TabIndex = 32;
			this.useBibEntryMapCheckBox.Text = "Use bibliography entry name remapping";
			this.useBibEntryMapCheckBox.UseVisualStyleBackColor = true;
			// 
			// useConstantStringsCheckBox
			// 
			this.useConstantStringsCheckBox.AutoSize = true;
			this.useConstantStringsCheckBox.Location = new System.Drawing.Point(233, 20);
			this.useConstantStringsCheckBox.Name = "useConstantStringsCheckBox";
			this.useConstantStringsCheckBox.Size = new System.Drawing.Size(220, 17);
			this.useConstantStringsCheckBox.TabIndex = 3;
			this.useConstantStringsCheckBox.Text = "Replace tag values with constant strings.";
			this.useConstantStringsCheckBox.UseVisualStyleBackColor = true;
			// 
			// copyCiteKeyCheckBox
			// 
			this.copyCiteKeyCheckBox.AutoSize = true;
			this.copyCiteKeyCheckBox.Location = new System.Drawing.Point(7, 43);
			this.copyCiteKeyCheckBox.Name = "copyCiteKeyCheckBox";
			this.copyCiteKeyCheckBox.Size = new System.Drawing.Size(191, 17);
			this.copyCiteKeyCheckBox.TabIndex = 2;
			this.copyCiteKeyCheckBox.Text = "Copy cite key when entry is added.";
			this.copyCiteKeyCheckBox.UseVisualStyleBackColor = true;
			// 
			// autoGenerateKeysCheckBox
			// 
			this.autoGenerateKeysCheckBox.AutoSize = true;
			this.autoGenerateKeysCheckBox.Location = new System.Drawing.Point(7, 20);
			this.autoGenerateKeysCheckBox.Name = "autoGenerateKeysCheckBox";
			this.autoGenerateKeysCheckBox.Size = new System.Drawing.Size(181, 17);
			this.autoGenerateKeysCheckBox.TabIndex = 1;
			this.autoGenerateKeysCheckBox.Text = "Automatically generate cite keys.";
			this.autoGenerateKeysCheckBox.UseVisualStyleBackColor = true;
			// 
			// removeLastCommaCheckBox
			// 
			this.removeLastCommaCheckBox.AutoSize = true;
			this.removeLastCommaCheckBox.Location = new System.Drawing.Point(7, 66);
			this.removeLastCommaCheckBox.Name = "removeLastCommaCheckBox";
			this.removeLastCommaCheckBox.Size = new System.Drawing.Size(167, 17);
			this.removeLastCommaCheckBox.TabIndex = 0;
			this.removeLastCommaCheckBox.Text = "Remove comma after last tag.";
			this.removeLastCommaCheckBox.UseVisualStyleBackColor = true;
			// 
			// bibEntryInitializationGroupBox
			// 
			this.bibEntryInitializationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bibEntryInitializationGroupBox.Controls.Add(this.useBibEntryInitializationCheckBox);
			this.bibEntryInitializationGroupBox.Controls.Add(this.bibEntryInitializationFileTextBox);
			this.bibEntryInitializationGroupBox.Controls.Add(this.browseBibEntryInitializationFileButton);
			this.bibEntryInitializationGroupBox.Location = new System.Drawing.Point(12, 192);
			this.bibEntryInitializationGroupBox.Name = "bibEntryInitializationGroupBox";
			this.bibEntryInitializationGroupBox.Size = new System.Drawing.Size(567, 73);
			this.bibEntryInitializationGroupBox.TabIndex = 27;
			this.bibEntryInitializationGroupBox.TabStop = false;
			this.bibEntryInitializationGroupBox.Text = "Bibliography Entry Tag Order";
			// 
			// useBibEntryInitializationCheckBox
			// 
			this.useBibEntryInitializationCheckBox.AutoSize = true;
			this.useBibEntryInitializationCheckBox.Location = new System.Drawing.Point(10, 20);
			this.useBibEntryInitializationCheckBox.Name = "useBibEntryInitializationCheckBox";
			this.useBibEntryInitializationCheckBox.Size = new System.Drawing.Size(169, 17);
			this.useBibEntryInitializationCheckBox.TabIndex = 5;
			this.useBibEntryInitializationCheckBox.Text = "Keep tags in a specified order.";
			this.useBibEntryInitializationCheckBox.UseVisualStyleBackColor = true;
			this.useBibEntryInitializationCheckBox.CheckedChanged += new System.EventHandler(this.UseBibEntryInitializationCheckBox_CheckedChanged);
			// 
			// bibEntryInitializationFileTextBox
			// 
			this.bibEntryInitializationFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bibEntryInitializationFileTextBox.Location = new System.Drawing.Point(10, 43);
			this.bibEntryInitializationFileTextBox.Name = "bibEntryInitializationFileTextBox";
			this.bibEntryInitializationFileTextBox.Size = new System.Drawing.Size(466, 20);
			this.bibEntryInitializationFileTextBox.TabIndex = 3;
			this.bibEntryInitializationFileTextBox.TabStop = false;
			// 
			// browseBibEntryInitializationFileButton
			// 
			this.browseBibEntryInitializationFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.browseBibEntryInitializationFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.browseBibEntryInitializationFileButton.Location = new System.Drawing.Point(482, 41);
			this.browseBibEntryInitializationFileButton.Name = "browseBibEntryInitializationFileButton";
			this.browseBibEntryInitializationFileButton.Size = new System.Drawing.Size(75, 23);
			this.browseBibEntryInitializationFileButton.TabIndex = 4;
			this.browseBibEntryInitializationFileButton.Text = "Browse";
			this.browseBibEntryInitializationFileButton.Click += new System.EventHandler(this.BrowseBibEntryInitializationButton_Click);
			// 
			// qualityProcessorGroupBox
			// 
			this.qualityProcessorGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.qualityProcessorGroupBox.Controls.Add(this.useQualityProcessingCheckBox);
			this.qualityProcessorGroupBox.Controls.Add(this.qualityProcessingFileTextBox);
			this.qualityProcessorGroupBox.Controls.Add(this.browseQualityProcessorButton);
			this.qualityProcessorGroupBox.Location = new System.Drawing.Point(12, 279);
			this.qualityProcessorGroupBox.Name = "qualityProcessorGroupBox";
			this.qualityProcessorGroupBox.Size = new System.Drawing.Size(567, 73);
			this.qualityProcessorGroupBox.TabIndex = 27;
			this.qualityProcessorGroupBox.TabStop = false;
			this.qualityProcessorGroupBox.Text = "Bibliography Entry Tag Quality";
			// 
			// useQualityProcessingCheckBox
			// 
			this.useQualityProcessingCheckBox.AutoSize = true;
			this.useQualityProcessingCheckBox.Location = new System.Drawing.Point(10, 20);
			this.useQualityProcessingCheckBox.Name = "useQualityProcessingCheckBox";
			this.useQualityProcessingCheckBox.Size = new System.Drawing.Size(327, 17);
			this.useQualityProcessingCheckBox.TabIndex = 6;
			this.useQualityProcessingCheckBox.Text = "Perform quality checking on the tag values of bibliography entry.";
			this.useQualityProcessingCheckBox.UseVisualStyleBackColor = true;
			// 
			// qualityProcessingFileTextBox
			// 
			this.qualityProcessingFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.qualityProcessingFileTextBox.Location = new System.Drawing.Point(10, 43);
			this.qualityProcessingFileTextBox.Name = "qualityProcessingFileTextBox";
			this.qualityProcessingFileTextBox.Size = new System.Drawing.Size(466, 20);
			this.qualityProcessingFileTextBox.TabIndex = 3;
			this.qualityProcessingFileTextBox.TabStop = false;
			// 
			// browseQualityProcessorButton
			// 
			this.browseQualityProcessorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.browseQualityProcessorButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.browseQualityProcessorButton.Location = new System.Drawing.Point(482, 41);
			this.browseQualityProcessorButton.Name = "browseQualityProcessorButton";
			this.browseQualityProcessorButton.Size = new System.Drawing.Size(75, 23);
			this.browseQualityProcessorButton.TabIndex = 4;
			this.browseQualityProcessorButton.Text = "Brow&se";
			this.browseQualityProcessorButton.Click += new System.EventHandler(this.BrowseQualityProcessorButton_Click);
			// 
			// remappingFileGroupBox
			// 
			this.remappingFileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.remappingFileGroupBox.Controls.Add(this.useRemappingCheckBox);
			this.remappingFileGroupBox.Controls.Add(this.remappingFileTextBox);
			this.remappingFileGroupBox.Controls.Add(this.remappingFileBrowseButton);
			this.remappingFileGroupBox.Location = new System.Drawing.Point(12, 365);
			this.remappingFileGroupBox.Name = "remappingFileGroupBox";
			this.remappingFileGroupBox.Size = new System.Drawing.Size(567, 73);
			this.remappingFileGroupBox.TabIndex = 28;
			this.remappingFileGroupBox.TabStop = false;
			this.remappingFileGroupBox.Text = "Remapping Names of Bibliography Entries";
			// 
			// useRemappingCheckBox
			// 
			this.useRemappingCheckBox.AutoSize = true;
			this.useRemappingCheckBox.Location = new System.Drawing.Point(10, 20);
			this.useRemappingCheckBox.Name = "useRemappingCheckBox";
			this.useRemappingCheckBox.Size = new System.Drawing.Size(282, 17);
			this.useRemappingCheckBox.TabIndex = 6;
			this.useRemappingCheckBox.Text = "Remap the type and tag names of bibliography entries.";
			this.useRemappingCheckBox.UseVisualStyleBackColor = true;
			// 
			// remappingFileTextBox
			// 
			this.remappingFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.remappingFileTextBox.Location = new System.Drawing.Point(10, 43);
			this.remappingFileTextBox.Name = "remappingFileTextBox";
			this.remappingFileTextBox.Size = new System.Drawing.Size(466, 20);
			this.remappingFileTextBox.TabIndex = 3;
			this.remappingFileTextBox.TabStop = false;
			// 
			// remappingFileBrowseButton
			// 
			this.remappingFileBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.remappingFileBrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.remappingFileBrowseButton.Location = new System.Drawing.Point(482, 41);
			this.remappingFileBrowseButton.Name = "remappingFileBrowseButton";
			this.remappingFileBrowseButton.Size = new System.Drawing.Size(75, 23);
			this.remappingFileBrowseButton.TabIndex = 4;
			this.remappingFileBrowseButton.Text = "Brow&se";
			this.remappingFileBrowseButton.Click += new System.EventHandler(this.RemappingFileBrowseButton_Click);
			// 
			// organizationGroupBox
			// 
			this.organizationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.organizationGroupBox.Controls.Add(this.sortBibliographyEntriesComboBox);
			this.organizationGroupBox.Controls.Add(this.sortBibliographyEntriesCheckBox);
			this.organizationGroupBox.Location = new System.Drawing.Point(379, 454);
			this.organizationGroupBox.Name = "organizationGroupBox";
			this.organizationGroupBox.Size = new System.Drawing.Size(200, 100);
			this.organizationGroupBox.TabIndex = 31;
			this.organizationGroupBox.TabStop = false;
			this.organizationGroupBox.Text = "Organization";
			// 
			// sortBibliographyEntriesComboBox
			// 
			this.sortBibliographyEntriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.sortBibliographyEntriesComboBox.FormattingEnabled = true;
			this.sortBibliographyEntriesComboBox.Location = new System.Drawing.Point(7, 43);
			this.sortBibliographyEntriesComboBox.Name = "sortBibliographyEntriesComboBox";
			this.sortBibliographyEntriesComboBox.Size = new System.Drawing.Size(183, 21);
			this.sortBibliographyEntriesComboBox.TabIndex = 1;
			// 
			// sortBibliographyEntriesCheckBox
			// 
			this.sortBibliographyEntriesCheckBox.AutoSize = true;
			this.sortBibliographyEntriesCheckBox.Location = new System.Drawing.Point(7, 20);
			this.sortBibliographyEntriesCheckBox.Name = "sortBibliographyEntriesCheckBox";
			this.sortBibliographyEntriesCheckBox.Size = new System.Drawing.Size(141, 17);
			this.sortBibliographyEntriesCheckBox.TabIndex = 0;
			this.sortBibliographyEntriesCheckBox.Text = "Sort bibliography entries.";
			this.sortBibliographyEntriesCheckBox.UseVisualStyleBackColor = true;
			this.sortBibliographyEntriesCheckBox.CheckedChanged += new System.EventHandler(this.SortBibliographyEntriesCheckBox_CheckedChanged);
			// 
			// ProjectSettingsForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(591, 697);
			this.Controls.Add(this.useRelativePathsCheckBox);
			this.Controls.Add(this.organizationGroupBox);
			this.Controls.Add(this.remappingFileGroupBox);
			this.Controls.Add(this.qualityProcessorGroupBox);
			this.Controls.Add(this.bibEntryInitializationGroupBox);
			this.Controls.Add(this.styleGroupBox);
			this.Controls.Add(this.alignmentGroupBox);
			this.Controls.Add(this.tabsGroupBox);
			this.Controls.Add(this.accessoryFilesGroupBox);
			this.Controls.Add(this.bibFileGroupBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1081, 951);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(607, 720);
			this.Name = "ProjectSettingsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.bibFileGroupBox.ResumeLayout(false);
			this.bibFileGroupBox.PerformLayout();
			this.accessoryFilesGroupBox.ResumeLayout(false);
			this.tabsGroupBox.ResumeLayout(false);
			this.tabsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tabSizeNumericUpDown)).EndInit();
			this.alignmentGroupBox.ResumeLayout(false);
			this.alignmentGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.alignmentTabStopNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.alignmentColumnNumericUpDown)).EndInit();
			this.styleGroupBox.ResumeLayout(false);
			this.styleGroupBox.PerformLayout();
			this.bibEntryInitializationGroupBox.ResumeLayout(false);
			this.bibEntryInitializationGroupBox.PerformLayout();
			this.qualityProcessorGroupBox.ResumeLayout(false);
			this.qualityProcessorGroupBox.PerformLayout();
			this.remappingFileGroupBox.ResumeLayout(false);
			this.remappingFileGroupBox.PerformLayout();
			this.organizationGroupBox.ResumeLayout(false);
			this.organizationGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox bibFileGroupBox;
		private System.Windows.Forms.TextBox bibFileLocationTextBox;
		private System.Windows.Forms.Button browseBibFileButton;
		private System.Windows.Forms.GroupBox accessoryFilesGroupBox;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.ListBox assessoryFilesListBox;
		private System.Windows.Forms.GroupBox tabsGroupBox;
		private System.Windows.Forms.RadioButton insertTabsRadioButton;
		private System.Windows.Forms.RadioButton insertSpacesRadioButton;
		private System.Windows.Forms.Label tabSizeLabel;
		private System.Windows.Forms.NumericUpDown tabSizeNumericUpDown;
		private System.Windows.Forms.GroupBox alignmentGroupBox;
		private System.Windows.Forms.Label alignmentColumnLabel;
		private System.Windows.Forms.NumericUpDown alignmentColumnNumericUpDown;
		private System.Windows.Forms.CheckBox alignTagValuesCheckBox;
		private System.Windows.Forms.Label alignmentTabStopLabel;
		private System.Windows.Forms.NumericUpDown alignmentTabStopNumericUpDown;
		private System.Windows.Forms.GroupBox styleGroupBox;
		private System.Windows.Forms.CheckBox removeLastCommaCheckBox;
		private System.Windows.Forms.GroupBox bibEntryInitializationGroupBox;
		private System.Windows.Forms.TextBox bibEntryInitializationFileTextBox;
		private System.Windows.Forms.Button browseBibEntryInitializationFileButton;
		private System.Windows.Forms.CheckBox useBibEntryInitializationCheckBox;
		private System.Windows.Forms.CheckBox autoGenerateKeysCheckBox;
		private System.Windows.Forms.GroupBox qualityProcessorGroupBox;
		private System.Windows.Forms.TextBox qualityProcessingFileTextBox;
		private System.Windows.Forms.Button browseQualityProcessorButton;
		private System.Windows.Forms.GroupBox remappingFileGroupBox;
		private System.Windows.Forms.TextBox remappingFileTextBox;
		private System.Windows.Forms.Button remappingFileBrowseButton;
		private System.Windows.Forms.CheckBox useQualityProcessingCheckBox;
		private System.Windows.Forms.CheckBox useRemappingCheckBox;
		private System.Windows.Forms.CheckBox copyCiteKeyCheckBox;
		private System.Windows.Forms.CheckBox useConstantStringsCheckBox;
		private System.Windows.Forms.GroupBox organizationGroupBox;
		private System.Windows.Forms.ComboBox sortBibliographyEntriesComboBox;
		private System.Windows.Forms.CheckBox sortBibliographyEntriesCheckBox;
		private System.Windows.Forms.CheckBox useRelativePathsCheckBox;
		private System.Windows.Forms.CheckBox useBibEntryMapCheckBox;
	} // End class.
} // End namespace.