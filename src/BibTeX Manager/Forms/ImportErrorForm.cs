using BibtexManager.Importing;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalProduction.Forms
{
	/// <summary>
	/// </summary>
	internal partial class ImportErrorForm : Form
	{
		#region Fields

		private ImportErrorHandlingType				_dialogResult				= ImportErrorHandlingType.TryAgain;

		#endregion

		#region Construction

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="text">Message to display.</param>
		public ImportErrorForm(string text)
		{
			InitializeComponent();

			this.txtbxMessage.Text = text;
			Initialize();
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="text">Message to display.</param>
		/// <param name="caption">Title of message box.</param>
		public ImportErrorForm(string text, string caption)
		{
			InitializeComponent();

			this.txtbxMessage.Text	= text;
			this.Text				= caption;
			Initialize();
		}

		/// <summary>
		/// Common construction/initialization.
		/// </summary>
		private void Initialize()
		{
			//this.pictureBoxIcon.Image = (Image)SystemIcons.Exclamation.ToBitmap();
			this.pictureBoxIcon.Image	= (Image)SystemIcons.Error.ToBitmap();
			this.ActiveControl			= (Control)this.pictureBoxIcon;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Dialog result.
		/// </summary>
		public ImportErrorHandlingType Result
		{
			get
			{
				return _dialogResult;
			}
			set
			{
				_dialogResult = value;
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// No button pressed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void TryAgainButton_Click(object sender, EventArgs eventArgs)
		{
			_dialogResult = ImportErrorHandlingType.TryAgain;
			Close();
		}

		/// <summary>
		/// No to All button pressed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void SkipButton_Click(object sender, EventArgs eventArgs)
		{
			_dialogResult = ImportErrorHandlingType.Skip;
			Close();
		}

		/// <summary>
		/// Cancel button pressed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void CancelButton_Click(object sender, EventArgs eventArgs)
		{
			_dialogResult = ImportErrorHandlingType.Cancel;
			Close();
		}

		#endregion

	} // End class.
} // End namespace.