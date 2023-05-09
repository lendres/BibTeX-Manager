using BibTeXLibrary;
using DigitalProduction.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BibtexManager
{
	/// <summary>
	/// A form for configuring a Project.
	/// </summary>
	public partial class ProjectSettingsForm : Form
	{
		#region Fields

		private readonly static string		_bibFileFilterString							= "\"BibTeX files (*.bib)|*.bib|Text files (*.txt)|*.txt|All files (*.*)|*.*\"";
		private readonly static string		_bibEntryInitializationFileFilterString			= "\"Bibliography Tag Order files (*.tagord)|*.tagord|XML files (*.xml)|*.xml|All files (*.*)|*.*\"";
		private readonly static string		_qualityProcessingFileFilterString				= "\"Quality Processing files (*.qlty)|*.qlty|XML files (*.xml)|*.xml|All files (*.*)|*.*\"";
		private readonly static string		_remappingFileFilterString						= "\"Bibliography entry mapping files (*.bibmap)|*.bibmap|XML files (*.xml)|*.xml|All files (*.*)|*.*\"";

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
		/// Browse for the BibTeX file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void BrowseBibFileButton_Click(object sender, EventArgs eventArgs)
		{
			string initialDirectory	= System.IO.Path.GetDirectoryName(_project.BibFile);

			string path = FileSelect.BrowseForAFile(this, _bibFileFilterString, "Select BibTeX File", initialDirectory, true);

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
		private void AddAssessoryFileButton_Click(object sender, EventArgs eventArgs)
		{
			string initialDirectory = System.IO.Path.GetDirectoryName(_project.BibFile);

			string[] paths = FileSelect.BrowseForMultipleFiles(this, _bibFileFilterString, "Select BibTeX File", initialDirectory, true);

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
		private void RemoveAssessoryFileButton_Click(object sender, EventArgs eventArgs)
		{
			ListBox.SelectedObjectCollection selectedItems = this.assessoryFilesListBox.SelectedItems;

			foreach (string file in selectedItems.OfType<string>().ToList())
			{
				this.assessoryFilesListBox.Items.Remove(file);
			}
		}

		/// <summary>
		/// Use bib entry initialization checked change event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void UseBibEntryInitializationCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
		{
			SetControls();
		}

		/// <summary>
		/// Browse for the bibliography tag order file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void BrowseBibEntryInitializationButton_Click(object sender, EventArgs eventArgs)
		{
			string initialDirectory = System.IO.Path.GetDirectoryName(_project.BibEntryInitializationFile);

			string path = FileSelect.BrowseForAFile(this, _bibEntryInitializationFileFilterString, "Select a Bibliography Tag Order File", initialDirectory, true);

			if (path != "")
			{
				this.bibEntryInitializationFileTextBox.Text = path;
			}
		}

		/// <summary>
		/// Browse for the quality processor file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void BrowseQualityProcessorButton_Click(object sender, EventArgs eventArgs)
		{
			string initialDirectory = System.IO.Path.GetDirectoryName(_project.QualityProcessingFile);

			string path = FileSelect.BrowseForAFile(this, _qualityProcessingFileFilterString, "Select a Quality Processing File", initialDirectory, true);

			if (path != "")
			{
				this.qualityProcessingFileTextBox.Text = path;
			}
		}

		/// <summary>
		/// Browse for the remapping file.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void RemappingFileBrowseButton_Click(object sender, EventArgs e)
		{
			string initialDirectory = System.IO.Path.GetDirectoryName(_project.RemappingFile);

			string path = FileSelect.BrowseForAFile(this, _remappingFileFilterString, "Select a Bibliography Remapping File", initialDirectory, true);

			if (path != "")
			{
				this.remappingFileTextBox.Text = path;
			}
		}

		/// <summary>
		/// Align tag values checked change event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void AlignTagValuesCheckBox_CheckedChanged(object sender, EventArgs eventArgs)
		{
			SetControls();
		}

		/// <summary>
		/// Ok button event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void ButtonOK_Click(object sender, EventArgs eventArgs)
		{
			// TODO: Validation code goes here.
			if (!System.IO.File.Exists(this.bibFileLocationTextBox.Text))
			{
				InvalidDataMessage("The bibliography file does not exist.");
				return;
			}

			if (this.bibEntryInitializationFileTextBox.Text != "" && !System.IO.File.Exists(this.bibEntryInitializationFileTextBox.Text))
			{
				InvalidDataMessage("The bibliography entry initialization file does not exist.");
				return;
			}

			// Ensure the data is valid.
			if (!ValidateChildren())
			{
				// Tell the user to fix the errors.
				MessageBox.Show(this, "Errors exist on the form.", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			PushEntriesToDataStructure();
		}

		/// <summary>
		/// Display a message that some data is not valid.
		/// </summary>
		/// <param name="message">Message to display.</param>
		private void InvalidDataMessage(string message)
		{
			MessageBox.Show(this, message, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
			// Have to set the DialogResult to none to prevent the form from closing.
			this.DialogResult = DialogResult.None;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Initialize the controls with the values from the data structure.
		/// </summary>
		protected void PopulateControls()
		{
			// Bibliography file.
			this.bibFileLocationTextBox.Text				= _project.BibFile;

			// Assessory files.
			this.assessoryFilesListBox.Items.AddRange(_project.AssessoryFiles.ToArray());

			// Bibliography entry initialization.
			this.useBibEntryInitializationCheckBox.Checked	= _project.UseBibEntryInitialization;
			this.bibEntryInitializationFileTextBox.Text		= _project.BibEntryInitializationFile;

			// Quality processing.
			this.useQualityProcessingCheckBox.Checked		= _project.UseQualityProcessing;
			this.qualityProcessingFileTextBox.Text			= _project.QualityProcessingFile;

			// BibEntry remapping.
			this.useRemappingCheckBox.Checked				= _project.UseBibEntryRemapping;
			this.remappingFileTextBox.Text					= _project.RemappingFile;
			
			// Write settings.
			WriteSettings writeSettings						= _project.WriteSettings;

			// Tabs.
			this.tabSizeNumericUpDown.Value					= writeSettings.TabSize;
			this.insertSpacesRadioButton.Checked			= writeSettings.WhiteSpace == WhiteSpace.Space;
			this.insertTabsRadioButton.Checked				= writeSettings.WhiteSpace == WhiteSpace.Tab;

			// Alignment.
			this.alignTagValuesCheckBox.Checked				= writeSettings.AlignTagValues;
			this.alignmentColumnNumericUpDown.Value			= writeSettings.AlignAtColumn;
			this.alignmentTabStopNumericUpDown.Value		= writeSettings.AlignAtTabStop;

			// Style.
			this.autoGenerateKeysCheckBox.Checked			= _project.AutoGenerateKeys;
			this.removeLastCommaCheckBox.Checked			= writeSettings.RemoveLastComma;
		}

		/// <summary>
		/// Save the data back to the data structure.
		/// </summary>
		protected void PushEntriesToDataStructure()
		{
			// Bibliography file.
			_project.BibFile						= this.bibFileLocationTextBox.Text;

			// Assessory files.
			ListBox.ObjectCollection items			= this.assessoryFilesListBox.Items;
			List<string> files						= new List<string>();
			foreach (object item in items)
			{
				files.Add(item.ToString());
			}
			_project.AssessoryFiles = files;

			// Bibliography entry initialization.
			_project.UseBibEntryInitialization		= this.useBibEntryInitializationCheckBox.Checked;
			_project.BibEntryInitializationFile		= this.bibEntryInitializationFileTextBox.Text;

			// Quality processing.
			_project.UseQualityProcessing			= this.useQualityProcessingCheckBox.Checked;
			_project.QualityProcessingFile			= this.qualityProcessingFileTextBox.Text;

			// BibEntry remapping.
			_project.UseBibEntryRemapping			= this.useRemappingCheckBox.Checked;
			_project.RemappingFile					= this.remappingFileTextBox.Text;

			// Write settings.
			WriteSettings writeSettings				= _project.WriteSettings;

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
			writeSettings.AlignTagValues			= this.alignTagValuesCheckBox.Checked;
			writeSettings.AlignAtColumn				= (int)this.alignmentColumnNumericUpDown.Value;
			writeSettings.AlignAtTabStop			= (int)this.alignmentTabStopNumericUpDown.Value;

			// Style
			_project.AutoGenerateKeys				= this.autoGenerateKeysCheckBox.Checked;
			writeSettings.RemoveLastComma			= this.removeLastCommaCheckBox.Checked;
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

			//this.bibEntryInitializationFileTextBox.Enabled		= this.useBibEntryInitializationCheckBox.Checked;
			//this.browseBibEntryInitializationFileButton.Enabled	= this.useBibEntryInitializationCheckBox.Checked;
		}

		#endregion

	} // End class.
} // End namespace.