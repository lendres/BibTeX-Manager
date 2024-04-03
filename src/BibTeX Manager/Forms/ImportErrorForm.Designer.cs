using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProduction.Forms
{
	partial class ImportErrorForm
	{
		#region Fields

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
		private TextBox txtbxMessage;
		private PictureBox pictureBoxIcon;
		private Button tryAgainButton;
		private Button skipButton;
		private Button cancelButton;

		#endregion

		#region Disposing

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		#endregion

		#region Windows Form Designer Generated Code

		private void InitializeComponent()
		{
			this.tryAgainButton = new System.Windows.Forms.Button();
			this.skipButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.txtbxMessage = new System.Windows.Forms.TextBox();
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// tryAgainButton
			// 
			this.tryAgainButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tryAgainButton.Location = new System.Drawing.Point(225, 157);
			this.tryAgainButton.Name = "tryAgainButton";
			this.tryAgainButton.Size = new System.Drawing.Size(75, 23);
			this.tryAgainButton.TabIndex = 3;
			this.tryAgainButton.Text = "Try Again";
			this.tryAgainButton.UseVisualStyleBackColor = true;
			this.tryAgainButton.Click += new System.EventHandler(this.TryAgainButton_Click);
			// 
			// skipButton
			// 
			this.skipButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.skipButton.Location = new System.Drawing.Point(306, 157);
			this.skipButton.Name = "skipButton";
			this.skipButton.Size = new System.Drawing.Size(75, 23);
			this.skipButton.TabIndex = 4;
			this.skipButton.Text = "Skip";
			this.skipButton.UseVisualStyleBackColor = true;
			this.skipButton.Click += new System.EventHandler(this.SkipButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(387, 157);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// txtbxMessage
			// 
			this.txtbxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtbxMessage.BackColor = System.Drawing.SystemColors.Control;
			this.txtbxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtbxMessage.Location = new System.Drawing.Point(61, 12);
			this.txtbxMessage.Multiline = true;
			this.txtbxMessage.Name = "txtbxMessage";
			this.txtbxMessage.Size = new System.Drawing.Size(401, 139);
			this.txtbxMessage.TabIndex = 0;
			this.txtbxMessage.TabStop = false;
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(32, 32);
			this.pictureBoxIcon.TabIndex = 6;
			this.pictureBoxIcon.TabStop = false;
			// 
			// ImportErrorForm
			// 
			this.AcceptButton = this.tryAgainButton;
			this.ClientSize = new System.Drawing.Size(474, 192);
			this.Controls.Add(this.pictureBoxIcon);
			this.Controls.Add(this.txtbxMessage);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.skipButton);
			this.Controls.Add(this.tryAgainButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ImportErrorForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

	} // End class.
} // End namespace.
