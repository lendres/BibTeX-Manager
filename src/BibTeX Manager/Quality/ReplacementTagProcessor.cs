using DigitalProduction.XML.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibtexManager.Quality
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class ReplacementTagProcessor : TagProcessor
	{
		#region Fields

		protected string          _replacement;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ReplacementTagProcessor()
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

		#endregion

	} // End class.
} // End namespace.