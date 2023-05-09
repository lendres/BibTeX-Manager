using BibTeXLibrary;
using DigitalProduction.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibtexManager
{
	public partial class BibManagerDataGridViewControl : DigitalProduction.Forms.DataGridViewInterfaceControl
	{
		#region Fields

		private BibtexProject			_project;

		#endregion

		#region Construction

		public BibManagerDataGridViewControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Properties

		/// <summary>
		/// Use this to add a property to the designer.
		/// </summary>
		//[Category("")]
		public BibtexProject Project { get => _project; set => _project = value; }

		#endregion

		#region Events

		/// <summary>
		/// Add a new raw bibliography entry based on a template.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void AddRawTemplateButton_Click(object sender, EventArgs eventArgs)
		{
			SelectBibEntryType selectBibEntryType = new SelectBibEntryType(_project.BibEntryInitialization.TypeNames);
			DialogResult result = selectBibEntryType.ShowDialog();

			if (result == DialogResult.OK)
			{
				BibEntry entry = BibEntry.NewBibEntryTemplate(_project.BibEntryInitialization, selectBibEntryType.SelectedType);

				EditRawBibEntryForm editRawBibEntryForm = new EditRawBibEntryForm((BibtexManagerForm)this.Parent.Parent, this.Project);
				DialogResultPair dialogResultPair = editRawBibEntryForm.ShowDialog(this, entry, this.Project.WriteSettings);

				if (dialogResultPair.Result == DialogResult.OK)
				{
					AddNewObject(dialogResultPair.Object);
				}
			}
		}

		#endregion

		#region Methods

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
			location += 75;
			this.modifyButton.Location = new Point(location, 0);
			location += 75;
			this.deleteButton.Location = new Point(location, 0);
		}

		#endregion

	} // End class.
} // End namespace.
