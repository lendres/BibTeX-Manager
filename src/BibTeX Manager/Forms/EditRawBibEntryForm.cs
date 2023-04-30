using BibTeXLibrary;
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

namespace BibTeXManager
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EditRawBibEntryForm : Form
	{
		#region Fields

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public EditRawBibEntryForm()
		{
			InitializeComponent();

			PopulateControls();
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
			int tabSize = writeSettings.TabSize * (richTextBox.Font.Height);

			this.richTextBox.SelectionTabs	= new int[] { tabSize, 2*tabSize, 3*tabSize, 4*tabSize, 5*tabSize, 6*tabSize, 7*tabSize, 8*tabSize };
			this.richTextBox.Text			= bibEntry.ToString(writeSettings);

			// Create the new return instance.
			DialogResultPair dialogResultPair = new DialogResultPair();

			// Show the dialog.
			dialogResultPair.Result = this.ShowDialog(parent);

			if (dialogResultPair.Result == DialogResult.OK)
			{
				StringReader textReader						= new StringReader(this.richTextBox.Text);
				Tuple<List<string>, List<BibEntry>> result	= BibParser.Parse(textReader);
				dialogResultPair.Object						= result.Item2[0];
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