namespace BibtexManager
{
	partial class SearchForm
	{
		#region Members

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label searchTermsLabel;
		private System.Windows.Forms.TextBox searchTermsTextBox;

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
			this.searchTermsLabel = new System.Windows.Forms.Label();
			this.searchTermsTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(415, 61);
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
			this.okButton.Location = new System.Drawing.Point(317, 61);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(80, 23);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// searchTermsLabel
			// 
			this.searchTermsLabel.AutoSize = true;
			this.searchTermsLabel.Location = new System.Drawing.Point(12, 9);
			this.searchTermsLabel.Name = "searchTermsLabel";
			this.searchTermsLabel.Size = new System.Drawing.Size(76, 13);
			this.searchTermsLabel.TabIndex = 26;
			this.searchTermsLabel.Text = "Search Terms:";
			// 
			// searchTermsTextBox
			// 
			this.searchTermsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.searchTermsTextBox.Location = new System.Drawing.Point(13, 26);
			this.searchTermsTextBox.Name = "searchTermsTextBox";
			this.searchTermsTextBox.Size = new System.Drawing.Size(482, 20);
			this.searchTermsTextBox.TabIndex = 27;
			// 
			// Windows_Form_for_Fixed_Dialog1
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(507, 96);
			this.Controls.Add(this.searchTermsTextBox);
			this.Controls.Add(this.searchTermsLabel);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1500, 135);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(523, 135);
			this.Name = "Windows_Form_for_Fixed_Dialog1";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	} // End class.
} // End namespace.