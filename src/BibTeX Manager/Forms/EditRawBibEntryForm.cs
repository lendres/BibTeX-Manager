using BibTeXLibrary;
using DigitalProduction.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BibtexManager
{
	/// <summary>
	/// 
	/// </summary>
	public partial class EditRawBibEntryForm : DigitalProductionForm
	{
		#region Fields

		private BibEntry		_bibEntry;
		private BibtexProject	_project;
		private bool            _addMode;

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
			this.KeyPreview = true;

			PopulateControls();
		}

		#endregion

		#region Properties

		#endregion

		#region Form Event Handlers

		/// <summary>
		/// Keyboard press event handler for the form.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void Form_KeyUp(object sender, KeyEventArgs eventArgs)
		{
			switch (eventArgs.KeyCode)
			{
				case Keys.V:
					if (eventArgs.Control && eventArgs.Shift)
					{
						eventArgs.Handled = true;
						Paste();
						CheckQuality();
					}
					break;

				case Keys.F4:
					eventArgs.Handled = true;
					Paste();
					CheckQuality();
					break;

				case Keys.F5:
					eventArgs.Handled = true;
					PerformOk();
					break;

				case Keys.F6:
					eventArgs.Handled = true;
					CheckQuality();
					break;
			}
		}

		#endregion

		#region Control Event Handlers

		/// <summary>
		/// Paste button event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void PasteButton_Click(object sender, EventArgs eventArgs)
		{
			Paste();
		}

		/// <summary>
		/// Paste and check quality button event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void PasteAndCheckQualityButton_Click(object sender, EventArgs eventArgs)
		{
			Paste();
			CheckQuality();
		}

		/// <summary>
		/// Quality check button event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void CheckQualityButton_Click(object sender, EventArgs eventArgs)
		{
			CheckQuality();
		}

		/// <summary>
		/// Copy the cite key.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void CopyCiteKeyButton_Click(object sender, EventArgs eventArgs)
		{
			if (Parse())
			{
				CopyCiteKeyToClipboard();
			}
		}

		/// <summary>
		/// BibEntryMap check box changed event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void BibEntryCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
		{
			SetControls();
		}

		/// <summary>
		/// Ok button event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void OkButton_Click(object sender, EventArgs eventArgs)
		{
			PerformOk();
		}

		/// <summary>
		/// Intercept pasting into text box to remove formatting of pasted text.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void RichTextBox_KeyDown(object sender, KeyEventArgs eventArgs)
		{
			if (eventArgs.Control && eventArgs.KeyCode == Keys.V)
			{
				// Paste the text.
				Paste();

				// Cancel the event.
				eventArgs.Handled = true;
			}
		}

		#endregion

		#region Processing Methods

		/// <summary>
		/// Paste from the clipboard to the text box.
		/// </summary>
		private void Paste()
		{
			// Suspend layout to avoid blinking.
			this.richTextBox.SuspendLayout();

			// Get the insertion point.
			int insPt = this.richTextBox.SelectionStart;

			// Get the current text.
			string text = this.richTextBox.Text;

			// Preserve text from after the selcted text to end of RTF content.
			string postRTFContent = text.Substring(insPt + this.richTextBox.SelectionLength);

			// Remove the content after the insertion point.
			text = text.Substring(0, insPt);

			// Add the clipboard content and then the preserved postRTF content
			this.richTextBox.Text = text + (string)Clipboard.GetData("Text") + postRTFContent;

			// Adjust the insertion point to just after the inserted text.
			this.richTextBox.SelectionStart = this.richTextBox.TextLength - postRTFContent.Length;

			// Restore layout.
			this.richTextBox.ResumeLayout();
		}

		/// <summary>
		/// Check the quality of the text in the text box.
		/// </summary>
		private void CheckQuality()
		{
			if (Parse())
			{
				// Mapping.
				_project.RemapEntryNames(_bibEntry);

				// Cleaning.
				bool breakNext = false;
				foreach (TagProcessingData tagProcessingData in _project.CleanEntry(_bibEntry))
				{
					// If the processing was cancelled, we break.  We have to loop back around here to give the
					// processing a chance to finish (it was yielded).  Now exit before processing another entry.
					if (breakNext)
					{
						break;
					}

					CorrectionForm correctionForm = new CorrectionForm(tagProcessingData);
					DialogResult dialogResult = correctionForm.Show(this);

					breakNext = dialogResult == DialogResult.Cancel;
				}

				// String constants replacement.
				_project.ApplyStringConstants(_bibEntry);

				// Key.
				if (_addMode)
				{
					_project.GenerateNewKey(_bibEntry);
				}
				else
				{
					_project.ValidateKey(_bibEntry);
				}

				this.richTextBox.Text = _bibEntry.ToString(_project.WriteSettings);
			}
		}

		/// <summary>
		/// Parse the text in the text box.  Returns true if successful and false otherwise.
		/// </summary>
		private bool Parse()
		{
			bool success = true;

			try
			{
				_bibEntry = _project.ParseSingleEntryText(this.richTextBox.Text);
			}
			catch (Exception exception)
			{
				// The text entered contained an error.  Display it and cancel the "ok" (return).
				MessageBox.Show(this, exception.Message, "Error Parsing Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
				success = false;
			}

			return success;
		}

		#endregion

		#region Dialog Methods

		/// <summary>
		/// The main work of the ok button.
		/// </summary>
		private void PerformOk()
		{
			if (!Parse())
			{
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

			if (_project.CopyCiteKeyOnEntryAdd)
			{
				CopyCiteKeyToClipboard();
			}

			PushEntriesToDataStructure();
		}

		/// <summary>
		/// Copy the citation key to the clipboard.
		/// </summary>
		private void CopyCiteKeyToClipboard()
		{
			// Clipboard copy might fail, so catch an errors.
			try
			{
				Clipboard.SetDataObject(_bibEntry.Key);
			}
			catch (Exception)
			{
				MessageBox.Show("Clipboard copy of cite key failed.  This feature can be turned off in the project settings.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		/// <summary>
		/// Show the edit dialog.
		/// </summary>
		/// <param name="parent">Parent form.</param>
		/// <param name="writeSettings">Settings to use when formatting the text for display.</param>
		public DialogResultPair ShowDialog(IWin32Window parent, WriteSettings writeSettings)
		{
			// If there is a BibEntry provided, populate the form.  Also, tract if we are adding or editing.
			_addMode = true;
			return ShowDialog(parent, string.Empty, writeSettings);
		}
		/// <summary>
		/// Show the edit dialog.
		/// </summary>
		/// <param name="parent">Parent form.</param>
		/// <param name="bibEntry">BibEntry to populate the rich text box with.</param>
		/// /// <param name="writeSettings">Settings to use when formatting the text for display.</param>
		public DialogResultPair ShowDialog(IWin32Window parent, BibEntry bibEntry, WriteSettings writeSettings)
		{
			// If there is a BibEntry provided, populate the form.  Also, tract if we are adding or editing.
			_addMode = false;
			return ShowDialog(parent, bibEntry.ToString(writeSettings), writeSettings);
		}

		/// <summary>
		/// Show the edit dialog.
		/// </summary>
		/// <param name="parent">Parent form.</param>
		/// <param name="text">Text to populate the rich text box with.</param>
		/// <param name="writeSettings">Settings to use when formatting the text for display.</param>
		public DialogResultPair ShowDialog(IWin32Window parent, string text, WriteSettings writeSettings)
		{
			// Set tab size.  It is set in pixels, so we have to convert the font size to pixels.  We make an assumption the height is a good
			// proxy for a space width.  We multiply that the tab size (number of spaces in a tab) to get the tab size.
			int tabSize		= writeSettings.TabSize * (richTextBox.Font.Height);
			Size spaceSize	= TextRenderer.MeasureText(new string(' ', writeSettings.TabSize), this.richTextBox.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.LeftAndRightPadding);
			tabSize = spaceSize.Width;
			this.richTextBox.SelectionTabs	= new int[] { tabSize, 2*tabSize, 3*tabSize, 4*tabSize, 5*tabSize, 6*tabSize, 7*tabSize, 8*tabSize };

			// If there is a BibEntry provided, populate the form.  Also, tract if we are adding or editing.
			this.richTextBox.Text = text;
	
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

		private void SetControls()
		{
		}

		/// <summary>
		/// Initialize the controls with the values from the data structure.
		/// </summary>
		protected void PopulateControls()
		{
			SetControls();
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