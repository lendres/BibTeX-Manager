using DigitalProduction.XML.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BibTeXLibrary;
using BibtexManager;
using BibtexManager.Project;


namespace BibTexManagerUnitTests
{
	/// <summary>
	/// 
	/// </summary>
	public class TestImporter : ImporterBase, ISingleImporter
	{
		#region Fields

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TestImporter()
		{
			this.BibEntryStrings = new string[] { "" };
		}

		#endregion

		#region Properties

		public string[] BibEntryStrings { get; set; }

		#endregion

		#region Interface Methods

		/// <summary>
		/// Import a single entry from a search string.
		/// </summary>
		/// <param name="searchString">String containing search terms.</param>
		public BibEntry Import(string searchString)
		{
			return ParseSingleEntryText(this.BibEntryStrings[0]);
		}

		#endregion

	} // End class.
} // End namespace.