using DigitalProduction.Forms;
using System;
using System.Windows.Forms;

namespace BibtexManager
{
	public partial class CorrectionForm : Form
	{
		#region Fields

		private MessageBoxYesNoToAllResult			_dialogResult				= MessageBoxYesNoToAllResult.Cancel;
		private TagProcessingData					_tagProcessingData;

		#endregion

		#region Construction

		/// <summary>
		/// Constructor.
		/// </summary>
		public CorrectionForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="correction">Correction to display to the user.</param>
		public CorrectionForm(TagProcessingData tagProcessingData)
		{
			InitializeComponent();
			this.TagProcessingData = tagProcessingData;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Result of the dialog.
		/// </summary>
		public new MessageBoxYesNoToAllResult DialogResult { get => _dialogResult; }

		/// <summary>
		/// Tag processing data.
		/// </summary>
		public TagProcessingData TagProcessingData
		{
			get
			{
				return _tagProcessingData;
			}

			set
			{
				_tagProcessingData = value;
				PopulateControls();
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
			_dialogResult = MessageBoxYesNoToAllResult.Yes;
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
			_dialogResult = MessageBoxYesNoToAllResult.YesToAll;
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
			_dialogResult = MessageBoxYesNoToAllResult.No;
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
			_dialogResult = MessageBoxYesNoToAllResult.Cancel;
			Close();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Show the dialog.
		/// </summary>
		/// <param name="owner">The owner dialog.</param>
		/// <exception cref="Exception">Bad value.</exception>
		public new DialogResult Show(IWin32Window owner)
		{
			if (_dialogResult == MessageBoxYesNoToAllResult.YesToAll)
			{
				PushEntriesToDataStructure(true);
				return System.Windows.Forms.DialogResult.Yes;
			}
			else
			{
				this.ShowDialog(owner);
				switch (_dialogResult)
				{
					case MessageBoxYesNoToAllResult.YesToAll:
					case MessageBoxYesNoToAllResult.Yes:
						return System.Windows.Forms.DialogResult.Yes;

					case MessageBoxYesNoToAllResult.No:
						return System.Windows.Forms.DialogResult.No;

					case MessageBoxYesNoToAllResult.Cancel:
						return System.Windows.Forms.DialogResult.Cancel;

					default:
						throw new Exception("Bad value.");
				}

			}
		}

		/// <summary>
		/// Initialize the controls with the values from the data structure.
		/// </summary>
		protected void PopulateControls()
		{
			this.contextTextBox.Text        = _tagProcessingData.Correction.Context;
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