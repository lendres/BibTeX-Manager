namespace BibTeXManager.Forms
{
	partial class ProjectForm
	{

		#region Members

		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;

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
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.bibFileGroupBox = new System.Windows.Forms.GroupBox();
			this.bibFileLocationTextBox = new System.Windows.Forms.TextBox();
			this.browseBibFileButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.bibFileGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(629, 227);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 23);
			this.buttonCancel.TabIndex = 25;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(531, 227);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(80, 23);
			this.buttonOK.TabIndex = 24;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
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
			this.browseBibFileButton.Text = "Browse";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Location = new System.Drawing.Point(12, 69);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(697, 152);
			this.groupBox1.TabIndex = 27;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Assessory Files";
			// 
			// ProjectForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(721, 262);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.bibFileGroupBox);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProjectForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.bibFileGroupBox.ResumeLayout(false);
			this.bibFileGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox bibFileGroupBox;
		private System.Windows.Forms.TextBox bibFileLocationTextBox;
		private System.Windows.Forms.Button browseBibFileButton;
		private System.Windows.Forms.GroupBox groupBox1;
	} // End class.
} // End namespace.