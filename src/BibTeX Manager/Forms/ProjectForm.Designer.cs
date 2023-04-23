namespace BibTeXManager
{
	partial class ProjectForm
	{

		#region Members

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button oKbutton;

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
			this.oKbutton = new System.Windows.Forms.Button();
			this.bibFileGroupBox = new System.Windows.Forms.GroupBox();
			this.bibFileLocationTextBox = new System.Windows.Forms.TextBox();
			this.browseBibFileButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.addButton = new System.Windows.Forms.Button();
			this.removeButton = new System.Windows.Forms.Button();
			this.assessoryFilesListBox = new System.Windows.Forms.ListBox();
			this.bibFileGroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(629, 227);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(80, 23);
			this.cancelButton.TabIndex = 25;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// oKbutton
			// 
			this.oKbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.oKbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.oKbutton.Location = new System.Drawing.Point(531, 227);
			this.oKbutton.Name = "oKbutton";
			this.oKbutton.Size = new System.Drawing.Size(80, 23);
			this.oKbutton.TabIndex = 24;
			this.oKbutton.Text = "&OK";
			this.oKbutton.UseVisualStyleBackColor = true;
			this.oKbutton.Click += new System.EventHandler(this.ButtonOK_Click);
			// 
			// bibFileGroupBox
			// 
			this.bibFileGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bibFileGroupBox.Controls.Add(this.bibFileLocationTextBox);
			this.bibFileGroupBox.Controls.Add(this.browseBibFileButton);
			this.bibFileGroupBox.Location = new System.Drawing.Point(12, 12);
			this.bibFileGroupBox.Name = "bibFileGroupBox";
			this.bibFileGroupBox.Size = new System.Drawing.Size(697, 51);
			this.bibFileGroupBox.TabIndex = 26;
			this.bibFileGroupBox.TabStop = false;
			this.bibFileGroupBox.Text = "Bib File";
			// 
			// bibFileLocationTextBox
			// 
			this.bibFileLocationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.bibFileLocationTextBox.Location = new System.Drawing.Point(10, 21);
			this.bibFileLocationTextBox.Name = "bibFileLocationTextBox";
			this.bibFileLocationTextBox.ReadOnly = true;
			this.bibFileLocationTextBox.Size = new System.Drawing.Size(596, 20);
			this.bibFileLocationTextBox.TabIndex = 3;
			this.bibFileLocationTextBox.TabStop = false;
			// 
			// browseBibFileButton
			// 
			this.browseBibFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.browseBibFileButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.browseBibFileButton.Location = new System.Drawing.Point(612, 19);
			this.browseBibFileButton.Name = "browseBibFileButton";
			this.browseBibFileButton.Size = new System.Drawing.Size(75, 23);
			this.browseBibFileButton.TabIndex = 4;
			this.browseBibFileButton.Text = "Brow&se";
			this.browseBibFileButton.Click += new System.EventHandler(this.BrowseBibFileButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.addButton);
			this.groupBox1.Controls.Add(this.removeButton);
			this.groupBox1.Controls.Add(this.assessoryFilesListBox);
			this.groupBox1.Location = new System.Drawing.Point(12, 69);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(697, 152);
			this.groupBox1.TabIndex = 27;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Assessory Files";
			// 
			// addButton
			// 
			this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.addButton.Location = new System.Drawing.Point(612, 19);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(80, 23);
			this.addButton.TabIndex = 4;
			this.addButton.Text = "&Add";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.AddButton_Click);
			// 
			// removeButton
			// 
			this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.removeButton.Location = new System.Drawing.Point(612, 48);
			this.removeButton.Name = "removeButton";
			this.removeButton.Size = new System.Drawing.Size(80, 23);
			this.removeButton.TabIndex = 3;
			this.removeButton.Text = "&Remove";
			this.removeButton.UseVisualStyleBackColor = true;
			this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
			// 
			// assessoryFilesListBox
			// 
			this.assessoryFilesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.assessoryFilesListBox.FormattingEnabled = true;
			this.assessoryFilesListBox.Location = new System.Drawing.Point(10, 18);
			this.assessoryFilesListBox.Name = "assessoryFilesListBox";
			this.assessoryFilesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.assessoryFilesListBox.Size = new System.Drawing.Size(596, 121);
			this.assessoryFilesListBox.TabIndex = 2;
			// 
			// ProjectForm
			// 
			this.AcceptButton = this.oKbutton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(721, 262);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.bibFileGroupBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.oKbutton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProjectForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.bibFileGroupBox.ResumeLayout(false);
			this.bibFileGroupBox.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox bibFileGroupBox;
		private System.Windows.Forms.TextBox bibFileLocationTextBox;
		private System.Windows.Forms.Button browseBibFileButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button removeButton;
		private System.Windows.Forms.ListBox assessoryFilesListBox;
	} // End class.
} // End namespace.