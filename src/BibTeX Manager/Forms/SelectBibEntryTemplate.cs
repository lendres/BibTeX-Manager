using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BibtexManager
{
	/// <summary>
	/// 
	/// </summary>
	public partial class SelectBibEntryType : Form
	{
		#region Fields

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SelectBibEntryType(List<string> templateNames)
		{
			InitializeComponent();

			this.templateComboBox.Items.Clear();
			this.templateComboBox.Items.AddRange(templateNames.ToArray());
			if (templateNames.Count > 0)
			{
				this.templateComboBox.SelectedIndex = 0;
			}
			//PopulateControls();
		}

		#endregion

		#region Properties

		public string SelectedType { get => this.templateComboBox.SelectedItem as string; }

		#endregion

		#region Event Handlers

		/// <summary>
		/// Ok button event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void buttonOK_Click(object sender, EventArgs eventArgs)
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

			//PushEntriesToDataStructure();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Initialize the controls with the values from the data structure.
		/// </summary>
		protected void PopulateControls()
		{
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