using BibTeXLibrary;
using BibtexManager.Forms;
using BibtexManager.Project;
using DigitalProduction.Forms;
using DigitalProduction.Projects;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace BibtexManager
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class BibtexManagerForm : DigitalProduction.Forms.ProjectForm
	{
		#region Fields

		private string						_findString			= null;
		private int							_findStartRow       = 0;

		private MessageBoxYesNoToAllResult  _messageBoxResult;
		private int							_retryCount			= 0;

		#endregion

		#region Construction

		/// <summary>
		/// Constructor.
		/// </summary>
		public BibtexManagerForm() :
			base(BibtexProject.FilterString, "Digital Production", "BibTeX Manager")
		{
			// Registry access has to be created in constructor and done before setting controls.
			Program.Registry = new RegistryAccess(this);

			// Allows for the installation event to occur.  Largely useful for debugging or resetting the software if the
			// registry gets messed up.
			Program.Registry.RaiseInstallEvent();

			// Have to add the file tool bar before calling InitializeComponent.
			InitializeComponent();

			// Establish event handles for the common File menu items.
			SetUpFileMenuItems(null, this.openToolStripMenuItem, this.saveToolStripMenuItem, this.saveAsToolStripMenuItem, this.closeToolStripMenuItem);

			// Add a recent files menu.
			SetUpRecentFilesList(this.recentFilesToolStripMenuItem, Program.Registry);
			
			FindProjectControls(this);

			InitializeFromRegistry();

			// Allow the form to see key presses.
			this.KeyPreview = true;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Casts the project variable to the specific type.
		/// </summary>
		private BibtexProject Project
		{
			get
			{
				return (BibtexProject)_project;
			}
		}

		#endregion

		#region Abstract Function Implementations

		/// <summary>
		/// Create a new BibtexProject.
		/// </summary>
		protected override DigitalProduction.Projects.Project NewProject()
		{
			BibtexProject project	= new BibtexProject();
			return (DigitalProduction.Projects.Project)project;
		}

		/// <summary>
		/// Have the subclass of this class create a new instance of the Subclass project type from a file.
		/// </summary>
		public override ProjectExtractor DeserializeProject(string path)
		{
			ProjectExtractor projectExtractor	= ProjectExtractor.ExtractAndDeserializeProject<BibtexProject>(path);
			_project							= (BibtexProject)projectExtractor.Project;
			return projectExtractor;
		}

		/// <summary>
		/// Set up a project.  An initialization related to the subclassed Project and any controls related to the subclassed Project.
		/// For example, Project related events can be hooked up.
		/// </summary>
		protected override void SetupProject()
		{
			this.dataGridViewInterfaceControl.Project = this.Project;
			InitializeDataBinding();
			this.Project.OnClosed += this.RemoveDataBinding;
		}

		#endregion

		#region Control Event Handlers

		/// <summary>
		/// The DataGridView seems to try to capture the F3 and sort which causes an error.  So we need to override
		/// this behavior.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void DataGridView_KeyUp(object sender, KeyEventArgs eventArgs)
		{
			switch (eventArgs.KeyCode)
			{
				case Keys.F3:
					eventArgs.Handled = true;
					FindOrShowFindDialog();
					break;

				case Keys.Enter:
					eventArgs.Handled = true;
					this.dataGridViewInterfaceControl.Edit();
					break;
			}
		}

		#endregion

		#region Form Event Handlers

		/// <summary>
		/// Form key press event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void Form_KeyUp(object sender, KeyEventArgs eventArgs)
		{
			switch (eventArgs.KeyCode)
			{
				case Keys.A:
					// Need to set this to true before opening the new form or that form will see the key press as well.
					eventArgs.Handled = true;
					this.dataGridViewInterfaceControl.Add();
					break;

				case Keys.E:
				case Keys.F2:
					// Need to set this to true before opening the new form or that form will see the key press as well.
					eventArgs.Handled = true;
					this.dataGridViewInterfaceControl.Edit();
					break;

				case Keys.F:
					if (eventArgs.Control)
					{
						eventArgs.Handled = true;
						ShowFindDialogBox();
					}
					break;
			}
		}

		/// <summary>
		/// If there is not a search string, we prompt the user for one.  Otherwise, continue searching with
		/// the existing search string.
		/// </summary>
		private void FindOrShowFindDialog()
		{
			if (_findString == null)
			{
				ShowFindDialogBox();
			}
			else
			{
				FindInDataGridView();
			}
		}

		/// <summary>
		/// Shows the find dialog box.
		/// </summary>
		private void ShowFindDialogBox()
		{
			FindEntryForm findEntryForm		= new FindEntryForm();
			DialogResult result				= findEntryForm.ShowDialog(this);
			if (result == DialogResult.OK)
			{
				_findString		= findEntryForm.FindString;
				_findStartRow	= this.bibEntriesDataGridView.SelectedRows[0].Index;
				FindInDataGridView();
			}
		}

		/// <summary>
		/// Select a row by finding a string.
		/// </summary>
		private void FindInDataGridView()
		{
			int currentRow  = this.bibEntriesDataGridView.SelectedRows[0].Index;

			// Search from the current location forward to the end.
			Tuple<int, int> cell = SearchRows(currentRow+1, this.bibEntriesDataGridView.Rows.Count);

			// If the previous search did not find anything, search from the start to the current position.
			if (cell.Item1 < 0)
			{
				cell = SearchRows(0, currentRow);
			}

			// If row index is negative, we got to the end and didn't find a match.
			// Therefore, display a message so the user knows nothing was found.
			if (cell.Item1 < 0)
			{
				string message = "The string \"" + _findString + "\" could not be found.";
				MessageBox.Show(message, "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				// We need to clear any selection first, so we don't have multiple rows selected.  Then the row that contains the
				// found string is selected (this doesn't seem to be needed when selected in the cell).  The cell is selected to
				// make it active.  Just selecting the row means when you use the keyboard keys, it jumps back to where the selected
				// cell is.  Note that selecting the cell seems to require the colums as the first value and the row as the second.
				// Finally, we scroll the DataGridView to the row that is selected.  We want to be able to see what is next so we don't
				// want the found item at the bottom of the window.
				this.bibEntriesDataGridView.ClearSelection();
				//this.bibEntriesDataGridView.Rows[cell.Item1].Selected		= true;
				this.bibEntriesDataGridView.CurrentCell                     = this.bibEntriesDataGridView[cell.Item2, cell.Item1];
				this.bibEntriesDataGridView.FirstDisplayedScrollingRowIndex	= this.bibEntriesDataGridView.SelectedRows[0].Index;
			}
		}

		/// <summary>
		/// Search from the start row to the last row for the string.
		/// </summary>
		/// <param name="startRow">Row to start searching from.</param>
		/// <param name="lastRow">Stop searching before this row.</param>
		private Tuple<int, int> SearchRows(int startRow, int lastRow)
		{
			DataGridViewRowCollection rows  = this.bibEntriesDataGridView.Rows;

			for (int i = startRow; i < lastRow; i++)
			{
				DataGridViewRow row = rows[i];

				// Loop over each column in the row.
				for (int j = 0; j < row.Cells.Count; j++)
				{
					// Need to check for null if new row is exposed.
					if (row.Cells[j].Value != null)
					{
						// Try to find the string in the contents of the cell.
						if (row.Cells[j].Value.ToString().ToLower().Contains(_findString.ToLower()))
						{
							return new Tuple<int, int>(row.Index, j);
						}
					}
				}
			}

			// Did not find a match.
			return new Tuple<int, int>(-1, -1);
		}

		#endregion

		#region Menu Event Handlers

		#region File

		/// <summary>
		/// New item click handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		protected override void NewToolStripItem_Click(object sender, EventArgs eventArgs)
		{
			base.NewToolStripItem_Click(sender, eventArgs);

			// After we create a new project, it needs to be set up.
			// Removing and adding the data binding is a hack to get this to work for now.
			RemoveDataBinding();
			ProjectSettingsForm projectForm	= new ProjectSettingsForm(this.Project);
			projectForm.ShowDialog(this);
			InitializeDataBinding();
		}

		/// <summary>
		/// Close the application.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void MenuExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		#endregion

		#region Project

		/// <summary>
		/// Modify the project.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void ModifyProjectToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProjectSettingsForm projectForm	= new ProjectSettingsForm(this.Project);
			DialogResult result				= projectForm.ShowDialog(this);
		}

		#endregion

		#region Tools

		/// <summary>
		/// Display the options dialog box.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event args.</param>
		private void OptionsToolStripMenuItem_Click(object sender, EventArgs eventArgs)
		{
			OptionsForm options = new OptionsForm();
			DialogResult result = options.ShowDialog(this);

			if (result == DialogResult.OK && this.IsProjectOpened)
			{
				// Do we need to update the project?
			}
		}

		/// <summary>
		/// Sort all entries in the bibliography.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event args.</param>
		private void SortBibliographyEntriesToolStripMenuItem_Click(object sender, EventArgs eventArgs)
		{
			this.Project.SortBibliographyEntries();
		}

		/// <summary>
		/// Quality check all the tags.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event args.</param>
		private void CheckTagQualityToolStripMenuItem_Click(object sender, EventArgs eventArgs)
		{
			bool breakNext = false;
			CorrectionForm correctionForm = new CorrectionForm();

			foreach (TagProcessingData tagProcessingData in this.Project.CleanAllEntries())
			{
				// If the processing was cancelled, we break.  We have to loop back around here to give the
				// processing a chance to finish (it was yielded).  Now exit before processing another entry.
				if (breakNext)
				{
					break;
				}

				correctionForm.TagProcessingData = tagProcessingData;
				DialogResult dialogResult = correctionForm.Show(this);

				breakNext = dialogResult == DialogResult.Cancel;
			}
		}

		/// <summary>
		/// Bulk import of SPE papers.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event args.</param>
		private void BulkSpeToolStripMenuItem1_Click(object sender, EventArgs eventArgs)
		{
			string file = DigitalProduction.Forms.FileSelect.BrowseForAFile(this, "", "Select a File with Search Terms");

			if (file != "")
			{
				_messageBoxResult = MessageBoxYesNoToAllResult.Yes;

				foreach (ImportResult importResult in this.Project.BulkSpeImport(file))
				{
					switch (importResult.Result)
					{
						case ResultType.Successful:
							int index = this.Project.GetEntryInsertIndex(importResult.BibEntry, 0);
							this.referencesBindingSource.Insert(index, importResult.BibEntry);
							break;

						case ResultType.NotFound:
							// Do nothing.
							break;

						case ResultType.Error:
							MessageBoxYesNoToAll messageBox = new MessageBoxYesNoToAll(this.StoreMessageBoxResult, true);
							string message = "An error occured during the search." + Environment.NewLine +
								"Error: " + importResult.Message + Environment.NewLine +
								"Do you wish to try again?";
							MessageBoxYesNoToAllResult result = messageBox.Show(this, message, "Import Error", MessageBoxYesNoToAllButtons.YesToAllNo);
							this.Project.SetContinue(result == MessageBoxYesNoToAllResult.Yes);

							// Have a retry limit.
							_retryCount++;
							if (_retryCount > 6)
							{
								_messageBoxResult	= MessageBoxYesNoToAllResult.Yes;
								_retryCount			= 0;
							}
							break;
					}
				}
			}
		}

		private void StoreMessageBoxResult(ref MessageBoxYesNoToAllResult result, bool setvalue)
		{
			if (setvalue)
			{
				_messageBoxResult = result;
			}
			else
			{
				result = _messageBoxResult;
			}
		}

		#endregion

		#region Help
		/// <summary>
		/// Show help.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void MenuHelp_Click(object sender, System.EventArgs eventArgs)
		{
			Help.ShowHelp(this, "Help\\Line Counter.chm");
		}

		/// <summary>
		/// Show the About dialog.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void AboutToolStripMenuItem_Click(object sender, EventArgs eventArgs)
		{
			// The resource manager will retrieve the value of the resource.
			ResourceManager resourceManager = BibtexManager.Properties.Resources.ResourceManager;
			Bitmap leftSideImage			= (Bitmap)resourceManager.GetObject("LELaTeX_Logo_Rotated_CroppedForAbout");
			AboutForm1 about				= new AboutForm1("lendres@fifthrace.com", leftSideImage);
			about.ShowDialog(this);
		}

		#endregion

		#endregion

		#region Data Binding

		///<summary>
		///Initialize the controls with the values from the data structure.
		///</summary>
		private void InitializeDataBinding()
		{
			if (_project != null)
			{
				// This will allow the entries to show up in the DataGridView.
				this.referencesBindingSource.DataSource = this.Project.Bibliography.Entries;
				this.Project.Bibliography.Entries.ListChanged += OnListChanged;
			}
		}

		/// <summary>
		/// Make sure the project knows when the list has been changed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void OnListChanged(object sender, ListChangedEventArgs e)
		{
			this.Project.Modified = true;
		}

		/// <summary>
		/// Handle the project closing.
		/// </summary>
		private void RemoveDataBinding()
		{
			this.referencesBindingSource.DataSource	= null;
			this.Project.Bibliography.Entries.ListChanged -= OnListChanged;
		}

		#endregion

		#region Helper Functions

		/// <summary>
		/// Initializes the controls from the stored settings.
		/// </summary>
		private void InitializeFromRegistry()
		{
			RegistryAccess registryAccess = Program.Registry;

			if (registryAccess.LoadLastProjectAtStartUp)
			{
				OpenRecentFile();
			}
		}

		#endregion

		//}
	} // End class.
} // End namespace.