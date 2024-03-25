using System;
using System.Windows.Forms;

namespace BibtexManager
{
	/// <summary>
	/// A simple form for entering search terms in a text box.
	/// </summary>
	public partial class SearchForm : Form
	{
		#region Fields

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SearchForm()
		{
			InitializeComponent();

			PopulateControls();

			this.searchTermsTextBox.Focus();
			this.searchTermsTextBox.Select();
		}

		#endregion

		#region Properties

		/// <summary>
		/// The search terms from the text box.
		/// </summary>
		public string SearchTerms
		{
			get
			{
				return this.searchTermsTextBox.Text.Trim();
			}
		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Ok button event handler.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="eventArgs">Event arguments.</param>
		private void OkButton_Click(object sender, EventArgs eventArgs)
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