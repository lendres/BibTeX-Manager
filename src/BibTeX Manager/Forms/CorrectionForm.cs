using DigitalProduction.Forms;
using System;
using System.Windows.Forms;

namespace BibtexManager
{
	public partial class CorrectionForm : Form
	{
		#region Fields

		private MessageBoxYesNoToAllResult			_dialogresult				= MessageBoxYesNoToAllResult.Cancel;
		private TagProcessingData					_tagProcessingData;

		#endregion

		#region Construction

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="correction">Correction to display to the user.</param>
		public CorrectionForm(TagProcessingData tagProcessingData)
		{
			_tagProcessingData = tagProcessingData;
			InitializeComponent();
			PopulateControls();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Result of the dialog.
		/// </summary>
		public new MessageBoxYesNoToAllResult DialogResult
		{ 
			get
			{ 
				return _dialogresult;
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Yes button click event handler.
		/// </summary>
		/// <param name="sender">Senders.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void YesButton_Click(object sender, EventArgs eventArgs)
		{
			_dialogresult = MessageBoxYesNoToAllResult.Yes;
			PushEntriesToDataStructure(true);
			Close();
		}

		/// <summary>
		/// Yes to all button click event handlers.
		/// </summary>
		/// <param name="sender">Senders.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void YesToAllButton_Click(object sender, EventArgs eventArgs)
		{
			_dialogresult = MessageBoxYesNoToAllResult.YesToAll;
			_tagProcessingData.AcceptAll = true;
			PushEntriesToDataStructure(true);
			Close();
		}

		/// <summary>
		/// No button click event handler.
		/// </summary>
		/// <param name="sender">Senders.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void NoButton_Click(object sender, EventArgs eventArgs)
		{
			_dialogresult = MessageBoxYesNoToAllResult.No;
			PushEntriesToDataStructure(false);
			Close();
		}

		/// <summary>
		/// Cancel button click event handler
		/// </summary>
		/// <param name="sender">Senders.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void CancelButton_Click(object sender, EventArgs eventArgs)
		{
			_dialogresult = MessageBoxYesNoToAllResult.Cancel;
			Close();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Initialize the controls with the values from the data structure.
		/// </summary>
		protected void PopulateControls()
		{
			this.existingTextBox.Text		= _tagProcessingData.Correction.MatchedText;
			this.replacementTextBox.Text	= _tagProcessingData.Correction.ReplacementText;
		}

		/// <summary>
		/// Save the data back to the data structure.
		/// </summary>
		protected void PushEntriesToDataStructure(bool replace)
		{
			_tagProcessingData.Correction.ReplacementText	= this.replacementTextBox.Text;
			_tagProcessingData.Correction.ReplaceText		= replace;
		}

		#endregion

	} // End class.
} // End namespace.