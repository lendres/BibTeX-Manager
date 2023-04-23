using BibTeXManager;
using DigitalProduction.Forms;
using DigitalProduction.Projects;
using System;
using System.Windows.Forms;

namespace BibtexManager
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class BibtexManagerForm : DigitalProductionProjectForm
	{
        #region Members


		#endregion

		#region Construction

		public BibtexManagerForm() :
			base(BibtexProject.FilterString, "DigitalProduction", "BibTeX Manager")
		{
			InitializeComponent();

			// Registry access has to be created in constructor and done before setting controls.
			Program.Registry = new RegistryAccess(this);

			// Allows for the installation event to occur.  Largely useful for debugging or resetting the software if the
			// registry gets messed up.
			Program.Registry.RaiseInstallEvent();

			InitializeFromRegistry();
		}

		#endregion

		#region Abstract Function Implementations

		/// <summary>
		/// Create a new BibtexProject.
		/// </summary>
		protected override Project NewProject()
		{
			BibtexProject project	= new BibtexProject();

			ProjectForm projectForm	= new ProjectForm(project);
			DialogResult result		= projectForm.ShowDialog(this);

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
		}

		#endregion

		#region Get Files

		#region Event Handler

		/// <summary>
		/// Get files to count the lines of.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void ButtonGetFiles_Click(object sender, System.EventArgs e)
		{

		}

		#endregion

		#endregion

		#region Menu Event Handlers

		#region File

		/// <summary>
		/// Menu item click handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void MenuFileNew_Click(object sender, EventArgs e)
		{
			New();
		}

		/// <summary>
		/// Menu item click handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void MenuFileOpen_Click(object sender, EventArgs e)
		{
			Open();
		}

		/// <summary>
		/// Menu item click handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void MenuFileClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Menu item click handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void MenuFileSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		/// <summary>
		/// Menu item click handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void MenuFileSaveAs_Click(object sender, EventArgs e)
		{
			SaveAs();
		}

		/// <summary>
		/// Close the application.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void MenuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#endregion

		#region Help

		/// <summary>
		/// Show help.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void MenuHelp_Click(object sender, System.EventArgs e)
		{
			Help.ShowHelp(this, "Help\\Line Counter.chm");
		}

		#endregion

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

		#region Events

		/// Open the report when the link is clicked.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void lnkReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//System.Diagnostics.Process.Start(_logFile);
		}

		#endregion

	} // End class.
} // End namespace.