using BibTeXLibrary;
using DigitalProduction.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BibtexManager
{
	public partial class BibManagerDataGridViewControl : DigitalProduction.Forms.DataGridViewInterfaceControl
	{
		#region Fields

		private BibtexProject					_project;

		#endregion

		#region Construction

		/// <summary>
		/// Constructor.
		/// </summary>
		public BibManagerDataGridViewControl()
		{
			InitializeComponent();

			this.ShowEditDialog	= this.ShowEditRawBibEntryDialog;
			this.ShowAddDialog	= this.ShowAddRawBibEntryDialog;
			
			this.dataGridViewControlToolTip.SetToolTip(this.addButton, "Add a New Entry");
		}

		#endregion

		#region Properties

		/// <summary>
		/// Use this to add a property to the designer.
		/// </summary>
		[Browsable(false)]
		public BibtexProject Project { get => _project; set => _project = value; }

		[Browsable(false)]
		private BibtexManagerForm BibtexManagerForm { get => (BibtexManagerForm) this.Parent.Parent; }

		/// <summary>
		/// Delegate for showing the edit dialog.
		/// </summary>
		//[Browsable(false)]
		//public override ShowEditDialogDelegate ShowEditDialog
		//{
		//	get
		//	{
		//		return base.ShowEditDialog;
		//	}

		//	set
		//	{
		//		base.ShowEditDialog = this.ShowEditRawBibEntryDialog;
		//	}
		//}

		///// <summary>
		///// Delegate for showing the add dialog.
		///// </summary>
		//[Browsable(false)]
		//public override ShowAddDialogDelegate ShowAddDialog
		//{
		//	get
		//	{
		//		return base.ShowAddDialog;
		//	}

		//	set
		//	{
		//		base.ShowAddDialog = this.ShowAddRawBibEntryDialog;
		//	}
		//}

		#endregion

		#region Events

		/// <summary>
		/// Add a new raw bibliography entry based on a template.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void AddRawTemplateButton_Click(object sender, EventArgs eventArgs)
		{
			AddRawTemplate();
		}

		/// <summary>
		/// Add a new raw bibliography based on a web search for an SPE paper.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void AddSpeButton_Click(object sender, EventArgs eventArgs)
		{
			AddFromSpeSearch();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Show the Edit Raw BibTeX Entry form.
		/// </summary>
		/// <param name="obj">Object to edit, the BibEntry.</param>
		public DialogResultPair ShowEditRawBibEntryDialog(object obj)
		{
			EditRawBibEntryForm editRawBibEntryForm = new EditRawBibEntryForm(this.BibtexManagerForm, this.Project);
			return editRawBibEntryForm.ShowDialog(this, (BibEntry)obj, this.Project.WriteSettings);
		}

		/// <summary>
		/// Show the Add dialog box.
		/// </summary>
		public DialogResultPair ShowAddRawBibEntryDialog()
		{
			EditRawBibEntryForm editRawBibEntryForm = new EditRawBibEntryForm(this.BibtexManagerForm, this.Project);
			return editRawBibEntryForm.ShowDialog(this, this.Project.WriteSettings);
		}

		/// <summary>
		/// Add a new entry based on a template.
		/// </summary>
		private void AddRawTemplate()
		{
			SelectBibEntryType selectBibEntryType	= new SelectBibEntryType(_project.BibEntryInitialization.TypeNames);
			DialogResult result						= selectBibEntryType.ShowDialog();

			if (result == DialogResult.OK)
			{
				BibEntry entry = BibEntry.NewBibEntryTemplate(_project.BibEntryInitialization, selectBibEntryType.SelectedType);

				EditRawBibEntryForm	editRawBibEntryForm	= new EditRawBibEntryForm(this.BibtexManagerForm, this.Project);
				DialogResultPair	dialogResultPair	= editRawBibEntryForm.ShowDialog(this, entry, this.Project.WriteSettings);

				if (dialogResultPair.Result == DialogResult.OK)
				{
					Add(dialogResultPair.Object);
				}
			}
		}

		/// <summary>
		/// Create an entry from a web search for an SPE paper.
		/// </summary>
		private void AddFromSpeSearch()
		{
			SearchForm searchForm       = new SearchForm();
			DialogResult dialogResult   = searchForm.ShowDialog();

			if (dialogResult == DialogResult.OK)
			{
				try
				{
					BibEntry bibEntry = this.Project.SpeBibtexGet(searchForm.SearchTerms);

					if (bibEntry != null)
					{
						EditRawBibEntryForm editRawBibEntryForm = new EditRawBibEntryForm(this.BibtexManagerForm, this.Project);
						DialogResultPair    dialogResultPair    = editRawBibEntryForm.ShowDialog(this, bibEntry, this.Project.WriteSettings);

						if (dialogResultPair.Result == DialogResult.OK)
						{
							Add(dialogResultPair.Object);
						}
					}
					else
					{
						MessageBox.Show(this.Parent, "A bibliography entry was not found.", "Entry Not Found", MessageBoxButtons.OK);
					}

				}
				catch (Exception exception)
				{
					MessageBox.Show(this.Parent, "An error occured during the search.\nError: "+exception.Message, "Search Error", MessageBoxButtons.OK);
				}
			}
		}

		#endregion

		#region Override and New Methods

		/// <summary>
		/// Insert a new object at the specified location.
		/// </summary>
		/// <param name="index">Index to insert the at.</param>
		/// <param name="newObject">New object instance to add.</param>
		protected override void Insert(int index, object newObject)
		{
			// The project can override the insertion location based on the settings.
			index = _project.GetEntryInsertIndex((BibEntry)newObject, index);

			base.Insert(index, newObject);
		}

		#endregion

		#region Protected Button Visibility and Enabling Methods

		/// <summary>
		/// Sets the location of buttons based on which buttons are hidden or shown.
		/// </summary>
		protected override void SetButtonsLocations()
		{
			// Subtract 96 for the hidden move buttons and for the hidden insert buttons.
			int location = 232 - 96*2;
			this.addRawTemplateButton.Location = new Point(location, 0);

			// Set the location of the remaining buttons.
			location += 41;
			this.addSpeButton.Location = new Point(location, 0);
			location += 75;
			this.modifyButton.Location = new Point(location, 0);
			location += 75;
			this.deleteButton.Location = new Point(location, 0);
		}

		#endregion

	} // End class.
} // End namespace.
