using BibTeXLibrary;
using BibtexManager;
using DigitalProduction.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static DigitalProduction.Forms.MessageBoxYesNoToAll;

namespace BibTeXManager
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EditRawBibEntryForm : DigitalProductionForm
	{
		#region Fields

		private BibEntry		_bibEntry;
		private BibtexProject	_project;

		#endregion

		#region Construction

		/// <summary>
		/// Constructor.
		/// </summary>
		public EditRawBibEntryForm(BibtexManagerForm parentForm, BibtexProject project) :
			base(parentForm, "Edit Raw BibTeX Entry Form")
		{
			_project = project;
			InitializeComponent();
			this.richTextBox.Select();

			//PopulateControls();
		}

		#endregion

		#region Properties

		#endregion

		#region Event Handlers

		/// <summary>
		/// Ok button event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void OkButton_Click(object sender, EventArgs eventArgs)
		{
			// TODO: Validation code goes here.
			try
			{
				List<BibEntry> entries = _project.ParseText(this.richTextBox.Text);
				_bibEntry = entries[0];

			}
			catch (Exception exception)
			{
				// The text entered contained an error.  Display it and cancel the "ok" (return).
				MessageBox.Show(this, exception.Message, "Error Parsing Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);

				// Have to set the DialogResult to none to prevent the form from closing.
				this.DialogResult = DialogResult.None;
				return;
			}

			// Ensure the data is valid.
			if (!ValidateChildren())
			{
				// Tell the user to fix the errors.
				MessageBox.Show(this, "Errors exist on the form.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

				// Have to set the DialogResult to none to prevent the form from closing.
				this.DialogResult = DialogResult.None;
				return;
			}

			PushEntriesToDataStructure();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Show the edit dialog.
		/// </summary>
		/// <param name="parent">Parent form.</param>
		public DialogResultPair ShowDialog(IWin32Window parent, BibEntry bibEntry, WriteSettings writeSettings)
		{
			// Set tab size.  It is set in pixels, so we have to convert the font size to pixels.  We make an assumption the height is a good
			// proxy for a space width.  We multiply that the tab size (number of spaces in a tab) to get the tab size.
			int tabSize						= writeSettings.TabSize * (richTextBox.Font.Height);
			this.richTextBox.SelectionTabs	= new int[] { tabSize, 2*tabSize, 3*tabSize, 4*tabSize, 5*tabSize, 6*tabSize, 7*tabSize, 8*tabSize };

			// If there is a BibEntry provided, populate the form.
			if (bibEntry != null)
			{
				this.richTextBox.Text = bibEntry.ToString(writeSettings);
			}

			// Create the new return instance and show the dialog, storing the result.
			DialogResultPair dialogResultPair	= new DialogResultPair();
			dialogResultPair.Result				= this.ShowDialog(parent);

			// If the Ok button was pressed, we try to create a new BibEntry.
			if (dialogResultPair.Result == DialogResult.OK)
			{
				dialogResultPair.Object = _bibEntry;
			}

			// Returned value.
			return dialogResultPair;
		}

		/// <summary>
		/// Initialize the controls with the values from the data structure.
		/// </summary>
		protected void PopulateControls()
		{
		}

		/// <summary>
		/// Save the data back to the data structure.
		/// </summary>
		protected void PushEntriesToDataStructure()
		{
		}

		#endregion

	} // End class.
} // End namespace.