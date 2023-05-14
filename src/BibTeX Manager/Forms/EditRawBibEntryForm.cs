using BibTeXLibrary;
using DigitalProduction.Forms;
using System;
using System.ComponentModel;
using System.Collections.Generic;
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
		/// Keyboard press event handler.
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

		#endregion

		#region Processing Methods

		/// <summary>
		/// Paste from the clipboard to the text box.
		/// </summary>
		private void Paste()
		{
			this.richTextBox.Text = Clipboard.GetText();
		}

		/// <summary>
		/// Check the quality of the text in the text box.
		/// </summary>
		private void CheckQuality()
		{
			if (Parse())
			{
				// Key.
				if (_addMode)
				{
					_project.GenerateNewKey(_bibEntry);
				}
				else
				{
				}

				// Mapping.
				if (this.useBibEntryMapCheckBox.Checked)
				{
					_project.RemapEntryNames(_bibEntry, this.bibEntryMapComboBox.Text);
				}

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
					correctionForm.ShowDialog(this);

					breakNext = correctionForm.DialogResult == MessageBoxYesNoToAllResult.Cancel;
				}

				// String constants replacement.
				_project.ApplyStringConstants(_bibEntry);

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
				BindingList<BibEntry> entries = _project.ParseText(this.richTextBox.Text);
				_bibEntry = entries[0];
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
		public DialogResultPair ShowDialog(IWin32Window parent, BibEntry bibEntry, WriteSettings writeSettings)
		{
			// Set tab size.  It is set in pixels, so we have to convert the font size to pixels.  We make an assumption the height is a good
			// proxy for a space width.  We multiply that the tab size (number of spaces in a tab) to get the tab size.
			int tabSize						= writeSettings.TabSize * (richTextBox.Font.Height);
			Size spaceSize = TextRenderer.MeasureText(new string(' ', writeSettings.TabSize), this.richTextBox.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.LeftAndRightPadding);
			tabSize = spaceSize.Width;
			this.richTextBox.SelectionTabs	= new int[] { tabSize, 2*tabSize, 3*tabSize, 4*tabSize, 5*tabSize, 6*tabSize, 7*tabSize, 8*tabSize };

			// If there is a BibEntry provided, populate the form.  Also, tract if we are adding or editing.
			if (bibEntry == null)
			{
				_addMode = true;
			}
			else
			{
				_addMode = false;
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

		private void SetControls()
		{
			this.bibEntryMapComboBox.Enabled = useBibEntryMapCheckBox.Checked;
		}

		/// <summary>
		/// Initialize the controls with the values from the data structure.
		/// </summary>
		protected void PopulateControls()
		{
			this.useBibEntryMapCheckBox.Checked = _project.UseBibEntryRemapping;
			SetControls();
			this.bibEntryMapComboBox.Items.Clear();
			this.bibEntryMapComboBox.Items.AddRange(_project.GetBibEntryMapNames());
			this.bibEntryMapComboBox.Text = _project.BibEntryMap;
			if (this.bibEntryMapComboBox.Text == "" && this.bibEntryMapComboBox.Items.Count > 0)
			{
				this.bibEntryMapComboBox.SelectedIndex = 0;
			}
		}

		/// <summary>
		/// Save the data back to the data structure.
		/// </summary>
		protected void PushEntriesToDataStructure()
		{
			_project.UseBibEntryRemapping	= this.useBibEntryMapCheckBox.Checked;
			if (this.bibEntryMapComboBox.SelectedIndex != -1)
			{
				_project.BibEntryMap            = this.bibEntryMapComboBox.SelectedItem.ToString();
			}
		}

		#endregion

	} // End class.
} // End namespace.