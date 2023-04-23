using DigitalProduction.Forms;
using System;
using System.Windows.Forms;
using System.Linq;

namespace BibTeXManager
{
	/// <summary>
	/// 
	/// </summary>
	public partial class ProjectForm : Form
	{
		#region Members

		static string		_filterString		= "\"BibTeX files (*.bib)|*.bib|Text files (*.txt)|*.txt|All files (*.*)|*.*\"";

		BibtexProject		_project;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ProjectForm(BibtexProject project)
		{
			_project = project;

			InitializeComponent();
			PopulateControls();
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
		private void BrowseBibFileButton_Click(object sender, EventArgs e)
		{
			string initialDirectory	= System.IO.Path.GetDirectoryName(_project.BibFile);

			string path = FileSelect.BrowseForAFile(this, _filterString, "Select BibTeX File", initialDirectory, true);

			if (path != "")
			{
				this.bibFileLocationTextBox.Text = path;
			}
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			string initialDirectory = System.IO.Path.GetDirectoryName(_project.BibFile);

			string[] paths = FileSelect.BrowseForMultipleFiles(this, _filterString, "Select BibTeX File", initialDirectory, true);

			if (paths != null)
			{
				this.assessoryFilesListBox.Items.AddRange(paths);
			}

		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			ListBox.SelectedObjectCollection selectedItems = this.assessoryFilesListBox.SelectedItems;

			int size = selectedItems.Count;
			string[] names = new string[size];

			for (int i = 0; i < size; i++)
			{
				names[i] = selectedItems[i].ToString();
			}

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