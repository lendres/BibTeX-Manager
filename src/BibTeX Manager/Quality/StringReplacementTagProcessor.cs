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
	/// Replaces each pattern found with the replacement string.
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

		/// <summary>
		/// String that replaces each found pattern.
		/// </summary>
		[XmlAttribute("replacement")]
		public string Replacement { get => _replacement; set => _replacement = value; }

		#endregion

		#region Methods

		/// <summary>
		/// Gets the replacement string for the input (original) string.
		/// </summary>
		/// <param name="original">Original string (matched pattern).</param>
		protected override string GetReplacement(string original)
		{
			return _replacement;
		}

		#endregion

		#region XML

		#endregion

	} // End class.
} // End namespace.