using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibTeXManager
{
	/// <summary>
	/// 
	/// </summary>
	public class Correction
	{
		#region Fields

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Correction()
		{
		}

		#endregion

		#region Properties

		public string Existing { get; set; }

		public string Replacement { get; set; }

		public bool Replace { get; set; }

		#endregion

		#region Methods

		#endregion

		#region XML

		#endregion

	} // End class.
} // End namespace.