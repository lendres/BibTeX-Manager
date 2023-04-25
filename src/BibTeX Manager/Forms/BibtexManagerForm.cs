using BibTeXLibrary;
using DigitalProduction.Forms;
using DigitalProduction.Projects;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Resources;
using System.Drawing;

namespace BibtexManager
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class BibtexManagerForm : DigitalProduction.Forms.ProjectForm
	{
        #region Members


		#endregion

		#region Construction

		public BibtexManagerForm() :
			base(BibtexProject.FilterString, "DigitalProduction", "BibTeX Manager")
		{
			// Registry access has to be created in constructor and done before setting controls.
			Program.Registry = new RegistryAccess(this);

			// Allows for the installation event to occur.  Largely useful for debugging or resetting the software if the
			// registry gets messed up.
			Program.Registry.RaiseInstallEvent();

			AddFileToolBar();
			InitializeComponent();
			SetUpFileMenuItems(null, this.openToolStripMenuItem, this.saveToolStripMenuItem, this.saveAsToolStripMenuItem, this.closeToolStripMenuItem);

			// Add a recent files menu.
			SetUpRecentFilesList(this.recentFilesToolStripMenuItem, Program.Registry);
			
			FindProjectControls(this);

			InitializeFromRegistry();
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
		protected override Project NewProject()
		{
			BibtexProject project	= new BibtexProject();

			return (Project)project;
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
			InitializeDataBinding();
			this.Project.OnClosed += this.RemoveDataBinding;
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
			ProjectForm projectForm	= new ProjectForm(this.Project);
			DialogResult result		= projectForm.ShowDialog(this);
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
			ProjectForm projectForm	= new ProjectForm(this.Project);
			DialogResult result		= projectForm.ShowDialog(this);
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
			ResourceManager resourceManager = BibTeXManager.Properties.Resources.ResourceManager;
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
				BindingList<BibEntry> bindingList = new BindingList<BibEntry>(this.Project.Bibliography.Entries);
				this.referencesBindingSource.DataSource = bindingList;
				bindingList.ListChanged += OnListChanged;
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
			this.referencesBindingSource.DataSource = null;
		}

		/// <summary>
		/// Add a new entry to the references.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void AddButton_Click(object sender, EventArgs eventArgs)
		{
			BibEntry entry = new BibEntry { Type = "inbook", Key = "ref:weasel2023a", ["author"] = "Weasel, Thanksgiving", ["Title"] = "A treaty in testing." };
			this.referencesBindingSource.Add(entry);
		}


		#endregion

		#region Helper Functions

		/// <summary>
		/// Initializes the controls from the stored settings.
		/// </summary>
		private void InitializeFromRegistry()
		{
			//this.textBoxInputFile.Text = Program.Registry.InputFile;
			//this.textBoxXsltFile.Text = Program.Registry.XsltFile;
			//this.textBoxXsltArguments.Text = Program.Registry.XsltArguments;
			//this.textBoxOutputFile.Text = Program.Registry.OutputFile;
			//this.checkBoxPostProcessor.Checked = Program.Registry.RunPostProcessor;
			//this.textBoxPostProcessor.Text = Program.Registry.PostProcessorFile;
		}

		#endregion

	} // End class.
} // End namespace.