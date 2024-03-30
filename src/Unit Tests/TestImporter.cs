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
	public class TestImporter : Importer
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
		public override BibEntry Import(string searchString)
		{
			return ParseSingleEntryText(this.BibEntryStrings[0]);
		}

		/// <summary>
		/// Bulk SPE paper search and import.
		/// </summary>
		/// <param name="path">The path or URL to read the search items from.</param>
		public override IEnumerable<ImportResult> BulkImport(string path)
		{
			foreach (string bibString in this.BibEntryStrings)
			{
				yield return new ImportResult(ResultType.Successful, ParseSingleEntryText(bibString), "");
			}

		}

		#endregion

	} // End class.
} // End namespace.