using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProduction.Forms;

namespace BibTeXManager
{
	public partial class CorrectionForm : Form
	{
		#region Fields

		private MessageBoxYesNoToAllResult			_dialogresult				= MessageBoxYesNoToAllResult.Cancel;
		private Correction							_correction;

		#endregion

		#region Construction
		
		public CorrectionForm(Correction correction)
		{
			_correction = correction;
			InitializeComponent();
			PopulateControls();
		}

		#endregion

		#region Event Handlers

		private void YesButton_Click(object sender, EventArgs e)
		{
			_dialogresult = MessageBoxYesNoToAllResult.Yes;
			PushEntriesToDataStructure(true);
			Close();
		}

		private void YesToAllButton_Click(object sender, EventArgs e)
		{
			_dialogresult = MessageBoxYesNoToAllResult.YesToAll;
			PushEntriesToDataStructure(true);
			Close();
		}

		private void NoButton_Click(object sender, EventArgs e)
		{
			_dialogresult = MessageBoxYesNoToAllResult.No;
			PushEntriesToDataStructure(false);
			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			_dialogresult = MessageBoxYesNoToAllResult.Cancel;
			PushEntriesToDataStructure(false);
			Close();
		}

		#endregion

		#region Methods


		/// <summary>
		/// Initialize the controls with the values from the data structure.
		/// </summary>
		protected void PopulateControls()
		{
			this.existingTextBox.Text		= _correction.Existing;
			this.replacementTextBox.Text	= _correction.Replacement;
		}

		/// <summary>
		/// Save the data back to the data structure.
		/// </summary>
		protected void PushEntriesToDataStructure(bool replace)
		{
			_correction.Replacement	= this.replacementTextBox.Text;
			_correction.Replace		= replace;
		}

		#endregion

	} // End class.
} // End namespace.