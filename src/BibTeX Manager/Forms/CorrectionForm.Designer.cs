namespace BibtexManager
{
	partial class CorrectionForm
	{
		#region Fields

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button noButton;
		private System.Windows.Forms.Button yesToAllButton;
		private System.Windows.Forms.Button yesButton;
		private System.Windows.Forms.TextBox existingTextBox;
		private System.Windows.Forms.Label existingTextLabel;
		private System.Windows.Forms.Label replacementLabel;
		private System.Windows.Forms.TextBox replacementTextBox;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#endregion

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
			this.cancelButton = new System.Windows.Forms.Button();
			this.noButton = new System.Windows.Forms.Button();
			this.yesToAllButton = new System.Windows.Forms.Button();
			this.yesButton = new System.Windows.Forms.Button();
			this.existingTextBox = new System.Windows.Forms.TextBox();
			this.existingTextLabel = new System.Windows.Forms.Label();
			this.replacementLabel = new System.Windows.Forms.Label();
			this.replacementTextBox = new System.Windows.Forms.TextBox();
			this.contextLabel = new System.Windows.Forms.Label();
			this.contextTextBox = new System.Windows.Forms.TextBox();
			this.tagNameLabel = new System.Windows.Forms.Label();
			this.tagNameTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(342, 203);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 9;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// noButton
			// 
			this.noButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.noButton.Location = new System.Drawing.Point(261, 203);
			this.noButton.Name = "noButton";
			this.noButton.Size = new System.Drawing.Size(75, 23);
			this.noButton.TabIndex = 8;
			this.noButton.Text = "&No";
			this.noButton.UseVisualStyleBackColor = true;
			this.noButton.Click += new System.EventHandler(this.NoButton_Click);
			// 
			// yesToAllButton
			// 
			this.yesToAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.yesToAllButton.Location = new System.Drawing.Point(180, 203);
			this.yesToAllButton.Name = "yesToAllButton";
			this.yesToAllButton.Size = new System.Drawing.Size(75, 23);
			this.yesToAllButton.TabIndex = 7;
			this.yesToAllButton.Text = "Yes to &All";
			this.yesToAllButton.UseVisualStyleBackColor = true;
			this.yesToAllButton.Click += new System.EventHandler(this.YesToAllButton_Click);
			// 
			// yesButton
			// 
			this.yesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.yesButton.Location = new System.Drawing.Point(99, 203);
			this.yesButton.Name = "yesButton";
			this.yesButton.Size = new System.Drawing.Size(75, 23);
			this.yesButton.TabIndex = 6;
			this.yesButton.Text = "&Yes";
			this.yesButton.UseVisualStyleBackColor = true;
			this.yesButton.Click += new System.EventHandler(this.YesButton_Click);
			// 
			// existingTextBox
			// 
			this.existingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.existingTextBox.Location = new System.Drawing.Point(12, 109);
			this.existingTextBox.Name = "existingTextBox";
			this.existingTextBox.ReadOnly = true;
			this.existingTextBox.Size = new System.Drawing.Size(405, 20);
			this.existingTextBox.TabIndex = 10;
			this.existingTextBox.TabStop = false;
			// 
			// existingTextLabel
			// 
			this.existingTextLabel.AutoSize = true;
			this.existingTextLabel.Location = new System.Drawing.Point(12, 93);
			this.existingTextLabel.Name = "existingTextLabel";
			this.existingTextLabel.Size = new System.Drawing.Size(66, 13);
			this.existingTextLabel.TabIndex = 11;
			this.existingTextLabel.Text = "Existing text:";
			// 
			// replacementLabel
			// 
			this.replacementLabel.AutoSize = true;
			this.replacementLabel.Location = new System.Drawing.Point(12, 148);
			this.replacementLabel.Name = "replacementLabel";
			this.replacementLabel.Size = new System.Drawing.Size(93, 13);
			this.replacementLabel.TabIndex = 13;
			this.replacementLabel.Text = "Replacement text:";
			// 
			// replacementTextBox
			// 
			this.replacementTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.replacementTextBox.Location = new System.Drawing.Point(12, 164);
			this.replacementTextBox.Name = "replacementTextBox";
			this.replacementTextBox.Size = new System.Drawing.Size(405, 20);
			this.replacementTextBox.TabIndex = 12;
			this.replacementTextBox.TabStop = false;
			// 
			// contextLabel
			// 
			this.contextLabel.AutoSize = true;
			this.contextLabel.Location = new System.Drawing.Point(12, 43);
			this.contextLabel.Name = "contextLabel";
			this.contextLabel.Size = new System.Drawing.Size(46, 13);
			this.contextLabel.TabIndex = 15;
			this.contextLabel.Text = "Context:";
			// 
			// contextTextBox
			// 
			this.contextTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.contextTextBox.Location = new System.Drawing.Point(12, 59);
			this.contextTextBox.Name = "contextTextBox";
			this.contextTextBox.ReadOnly = true;
			this.contextTextBox.Size = new System.Drawing.Size(405, 20);
			this.contextTextBox.TabIndex = 14;
			this.contextTextBox.TabStop = false;
			// 
			// tagNameLabel
			// 
			this.tagNameLabel.AutoSize = true;
			this.tagNameLabel.Location = new System.Drawing.Point(12, 16);
			this.tagNameLabel.Name = "tagNameLabel";
			this.tagNameLabel.Size = new System.Drawing.Size(60, 13);
			this.tagNameLabel.TabIndex = 17;
			this.tagNameLabel.Text = "Tag Name:";
			// 
			// tagNameTextBox
			// 
			this.tagNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tagNameTextBox.Location = new System.Drawing.Point(89, 13);
			this.tagNameTextBox.Name = "tagNameTextBox";
			this.tagNameTextBox.ReadOnly = true;
			this.tagNameTextBox.Size = new System.Drawing.Size(328, 20);
			this.tagNameTextBox.TabIndex = 16;
			this.tagNameTextBox.TabStop = false;
			// 
			// CorrectionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 238);
			this.Controls.Add(this.tagNameLabel);
			this.Controls.Add(this.tagNameTextBox);
			this.Controls.Add(this.contextLabel);
			this.Controls.Add(this.contextTextBox);
			this.Controls.Add(this.replacementLabel);
			this.Controls.Add(this.replacementTextBox);
			this.Controls.Add(this.existingTextLabel);
			this.Controls.Add(this.existingTextBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.noButton);
			this.Controls.Add(this.yesToAllButton);
			this.Controls.Add(this.yesButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CorrectionForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Replace Text?";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label contextLabel;
		private System.Windows.Forms.TextBox contextTextBox;
		private System.Windows.Forms.Label tagNameLabel;
		private System.Windows.Forms.TextBox tagNameTextBox;
	} // End class.
} // End namespace.