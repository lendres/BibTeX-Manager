namespace BibTeXManager
{
	partial class EditRawBibEntryForm
	{
		#region Fields

		private System.Windows.Forms.RichTextBox richTextBox;

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
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.checkQualityButton = new System.Windows.Forms.Button();
			this.pasteAndCheckQualityButton = new System.Windows.Forms.Button();
			this.pasteButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(392, 426);
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
			this.okButton.Location = new System.Drawing.Point(294, 426);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(80, 23);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// richTextBox
			// 
			this.richTextBox.AcceptsTab = true;
			this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox.Location = new System.Drawing.Point(13, 61);
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.Size = new System.Drawing.Size(459, 352);
			this.richTextBox.TabIndex = 26;
			this.richTextBox.Text = "";
			// 
			// checkQualityButton
			// 
			this.checkQualityButton.Image = global::BibTeXManager.Properties.Resources.Quality_Check_40;
			this.checkQualityButton.Location = new System.Drawing.Point(122, 12);
			this.checkQualityButton.Name = "checkQualityButton";
			this.checkQualityButton.Size = new System.Drawing.Size(40, 40);
			this.checkQualityButton.TabIndex = 29;
			this.checkQualityButton.UseVisualStyleBackColor = true;
			this.checkQualityButton.Click += new System.EventHandler(this.CheckQualityButton_Click);
			// 
			// pasteAndCheckQualityButton
			// 
			this.pasteAndCheckQualityButton.Image = global::BibTeXManager.Properties.Resources.Paste_Quality_40;
			this.pasteAndCheckQualityButton.Location = new System.Drawing.Point(59, 12);
			this.pasteAndCheckQualityButton.Name = "pasteAndCheckQualityButton";
			this.pasteAndCheckQualityButton.Size = new System.Drawing.Size(40, 40);
			this.pasteAndCheckQualityButton.TabIndex = 28;
			this.pasteAndCheckQualityButton.UseVisualStyleBackColor = true;
			this.pasteAndCheckQualityButton.Click += new System.EventHandler(this.PasteAndCheckQualityButton_Click);
			// 
			// pasteButton
			// 
			this.pasteButton.Image = global::BibTeXManager.Properties.Resources.Paste_40;
			this.pasteButton.Location = new System.Drawing.Point(13, 13);
			this.pasteButton.Name = "pasteButton";
			this.pasteButton.Size = new System.Drawing.Size(40, 40);
			this.pasteButton.TabIndex = 27;
			this.pasteButton.UseVisualStyleBackColor = true;
			this.pasteButton.Click += new System.EventHandler(this.PasteButton_Click);
			// 
			// EditRawBibEntryForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(484, 461);
			this.Controls.Add(this.checkQualityButton);
			this.Controls.Add(this.pasteAndCheckQualityButton);
			this.Controls.Add(this.pasteButton);
			this.Controls.Add(this.richTextBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(500, 500);
			this.Name = "EditRawBibEntryForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button pasteButton;
		private System.Windows.Forms.Button pasteAndCheckQualityButton;
		private System.Windows.Forms.Button checkQualityButton;
	} // End class.
} // End namespace.