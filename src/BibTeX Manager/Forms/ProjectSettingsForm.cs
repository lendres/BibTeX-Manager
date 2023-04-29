using DigitalProduction.Forms;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using BibTeXLibrary;

namespace BibtexManager
{
	/// <summary>
	/// 
	/// </summary>
	public partial class ProjectSettingsForm : Form
	{
		#region Members

		private static string				_filterString		= "\"BibTeX files (*.bib)|*.bib|Text files (*.txt)|*.txt|All files (*.*)|*.*\"";

		private readonly BibtexProject		_project;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ProjectSettingsForm(BibtexProject project)
		{
			_project = project;

			InitializeComponent();
			PopulateControls();
			SetControls();
		}

		#endregion

		#region Properties

		#endregion

		#region Event Handlers

		/// <summary>
		/// Align tag values checked change event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void alignTagValuesCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
		{
			SetControls();
		}

		/// <summary>
		/// Browse for the BibTeX file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void BrowseBibFileButton_Click(object sender, EventArgs eventArgs)
		{
			string initialDirectory	= System.IO.Path.GetDirectoryName(_project.BibFile);

			string path = FileSelect.BrowseForAFile(this, _filterString, "Select BibTeX File", initialDirectory, true);

			if (path != "")
			{
				this.bibFileLocationTextBox.Text = path;
			}
		}

		/// <summary>
		/// Add assessory files.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void AddButton_Click(object sender, EventArgs eventArgs)
		{
			string initialDirectory = System.IO.Path.GetDirectoryName(_project.BibFile);

			string[] paths = FileSelect.BrowseForMultipleFiles(this, _filterString, "Select BibTeX File", initialDirectory, true);

			if (paths != null)
			{
				this.assessoryFilesListBox.Items.AddRange(paths);
			}

		}

		/// <summary>
		/// Remove assessory files.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void RemoveButton_Click(object sender, EventArgs eventArgs)
		{
			ListBox.SelectedObjectCollection selectedItems = this.assessoryFilesListBox.SelectedItems;

			foreach (string file in selectedItems.OfType<string>().ToList())
			{
				this.assessoryFilesListBox.Items.Remove(file);
			}
		}

		/// <summary>
		/// Ok button event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void ButtonOK_Click(object sender, EventArgs eventArgs)
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
		/// Initialize the controls with the values from the data structure.
		/// </summary>
		protected void PopulateControls()
		{
			this.bibFileLocationTextBox.Text = _project.BibFile;
			this.assessoryFilesListBox.Items.AddRange(_project.AssessoryFiles.ToArray());

			// Write settings.
			WriteSettings writeSettings					= _project.WriteSettings;

			// Tabs.
			this.tabSizeNumericUpDown.Value				= writeSettings.TabSize;
			this.insertSpacesRadioButton.Checked		= writeSettings.WhiteSpace == WhiteSpace.Space;
			this.insertTabsRadioButton.Checked			= writeSettings.WhiteSpace == WhiteSpace.Tab;

			// Alignment.
			this.alignTagValuesCheckBox.Checked			= writeSettings.AlignTagValues;
			this.alignmentColumnNumericUpDown.Value		= writeSettings.AlignAtColumn;
			this.alignmentTabStopNumericUpDown.Value	= writeSettings.AlignAtTabStop;
		}

		/// <summary>
		/// Save the data back to the data structure.
		/// </summary>
		protected void PushEntriesToDataStructure()
		{
			_project.BibFile				= this.bibFileLocationTextBox.Text;
			
			ListBox.ObjectCollection items	= this.assessoryFilesListBox.Items;
			List<string> files				= new List<string>();
			foreach (object item in items)
			{
				files.Add(item.ToString());
			}
			_project.AssessoryFiles = files;

			// Write settings.
			WriteSettings writeSettings = _project.WriteSettings;

			// Tabs.
			_project.WriteSettings.TabSize			= (int)this.tabSizeNumericUpDown.Value;
			if (this.insertSpacesRadioButton.Checked)
			{
				writeSettings.WhiteSpace = WhiteSpace.Space;
			}
			else
			{
				writeSettings.WhiteSpace = WhiteSpace.Tab;
			}

			// Alignment.
			writeSettings.AlignTagValues	= this.alignTagValuesCheckBox.Checked;
			writeSettings.AlignAtColumn		= (int)this.alignmentColumnNumericUpDown.Value;
			writeSettings.AlignAtTabStop	= (int)this.alignmentTabStopNumericUpDown.Value;
		}

		/// <summary>
		/// Sets the control states.  For this simple form, just use one catch all function.
		/// </summary>
		private void SetControls()
		{
			if (this.alignTagValuesCheckBox.Checked)
			{
				this.alignmentColumnNumericUpDown.Enabled	= this.insertSpacesRadioButton.Checked;
				this.alignmentTabStopNumericUpDown.Enabled	= this.insertTabsRadioButton.Checked;
			}
			else
			{
				this.alignmentColumnNumericUpDown.Enabled	= false;
				this.alignmentTabStopNumericUpDown.Enabled	= false;
			}
		}

		#endregion

	} // End class.
} // End namespace.