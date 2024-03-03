namespace BibtexManager
{
	partial class BibManagerDataGridViewControl
	{
		#region Members

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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.addRawTemplateButton = new System.Windows.Forms.Button();
			this.addSpeButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// modifyButton
			// 
			this.dataGridViewControlToolTip.SetToolTip(this.modifyButton, "Edit Selected Entry");
			// 
			// moveDownButton
			// 
			this.dataGridViewControlToolTip.SetToolTip(this.moveDownButton, "Move Selected Entry Down");
			// 
			// moveUpButton
			// 
			this.dataGridViewControlToolTip.SetToolTip(this.moveUpButton, "Move Selected Entry Up");
			// 
			// addButton
			// 
			this.dataGridViewControlToolTip.SetToolTip(this.addButton, "Insert New at Top");
			// 
			// insertAboveButton
			// 
			this.dataGridViewControlToolTip.SetToolTip(this.insertAboveButton, "Insert New Above Current");
			// 
			// insertBelowButton
			// 
			this.dataGridViewControlToolTip.SetToolTip(this.insertBelowButton, "Insert New Below Current");
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(307, 0);
			this.dataGridViewControlToolTip.SetToolTip(this.deleteButton, "Delete Selected Entry");
			// 
			// addRawTemplateButton
			// 
			this.addRawTemplateButton.Image = global::BibtexManager.Properties.Resources.PlusGreenAndTemplate_16x;
			this.addRawTemplateButton.Location = new System.Drawing.Point(371, 0);
			this.addRawTemplateButton.Name = "addRawTemplateButton";
			this.addRawTemplateButton.Size = new System.Drawing.Size(40, 30);
			this.addRawTemplateButton.TabIndex = 7;
			this.dataGridViewControlToolTip.SetToolTip(this.addRawTemplateButton, "Add Entry from Template");
			this.addRawTemplateButton.UseVisualStyleBackColor = true;
			this.addRawTemplateButton.Click += new System.EventHandler(this.AddRawTemplateButton_Click);
			// 
			// addSpeButton
			// 
			this.addSpeButton.Image = global::BibtexManager.Properties.Resources.PlusGreenAndTemplate_16x;
			this.addSpeButton.Location = new System.Drawing.Point(461, 0);
			this.addSpeButton.Name = "addSpeButton";
			this.addSpeButton.Size = new System.Drawing.Size(40, 30);
			this.addSpeButton.TabIndex = 8;
			this.dataGridViewControlToolTip.SetToolTip(this.addSpeButton, "Add Entry from Template");
			this.addSpeButton.UseVisualStyleBackColor = true;
			this.addSpeButton.Click += new System.EventHandler(this.AddSpeButton_Click);
			// 
			// BibManagerDataGridViewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.addSpeButton);
			this.Controls.Add(this.addRawTemplateButton);
			this.Name = "BibManagerDataGridViewControl";
			this.Size = new System.Drawing.Size(569, 31);
			this.Controls.SetChildIndex(this.insertBelowButton, 0);
			this.Controls.SetChildIndex(this.deleteButton, 0);
			this.Controls.SetChildIndex(this.addButton, 0);
			this.Controls.SetChildIndex(this.moveUpButton, 0);
			this.Controls.SetChildIndex(this.moveDownButton, 0);
			this.Controls.SetChildIndex(this.modifyButton, 0);
			this.Controls.SetChildIndex(this.insertAboveButton, 0);
			this.Controls.SetChildIndex(this.addRawTemplateButton, 0);
			this.Controls.SetChildIndex(this.addSpeButton, 0);
			this.ResumeLayout(false);

		}

		#endregion

		protected System.Windows.Forms.Button addRawTemplateButton;
		protected System.Windows.Forms.Button addSpeButton;
	} // End class.
} // End namespace.
