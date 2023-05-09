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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BibManagerDataGridViewControl));
			this.addRawTemplateButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(307, 0);
			// 
			// addRawTemplateButton
			// 
			this.addRawTemplateButton.Image = ((System.Drawing.Image)(resources.GetObject("addRawTemplateButton.Image")));
			this.addRawTemplateButton.Location = new System.Drawing.Point(371, 0);
			this.addRawTemplateButton.Name = "addRawTemplateButton";
			this.addRawTemplateButton.Size = new System.Drawing.Size(40, 30);
			this.addRawTemplateButton.TabIndex = 7;
			this.addRawTemplateButton.UseVisualStyleBackColor = true;
			this.addRawTemplateButton.Click += new System.EventHandler(this.AddRawTemplateButton_Click);
			// 
			// BibManagerDataGridViewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
			this.ResumeLayout(false);

		}

		#endregion

		protected System.Windows.Forms.Button addRawTemplateButton;
	} // End class.
} // End namespace.
