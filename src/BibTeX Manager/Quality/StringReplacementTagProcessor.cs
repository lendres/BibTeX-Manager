using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibTeXManager.Quality
{
	/// <summary>
	/// 
	/// </summary>
	public class StringReplacementTagProcessor : TagProcessor
	{
		#region Fields

		private string			_replacement;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StringReplacementTagProcessor()
		{
		}

		#endregion

		#region Properties

		[XmlAttribute("replacement")]
		public string Replacement { get => _replacement; set => _replacement = value; }

		#endregion

		#region Methods

		protected override string GetReplacement(string original)
		{
			return _replacement;
		}

		#endregion

		#region XML

		#endregion

	} // End class.
} // End namespace.