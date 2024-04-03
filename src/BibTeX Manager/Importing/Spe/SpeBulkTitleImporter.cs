using BibTeXLibrary;
using BibtexManager.Project;
using System;
using System.Collections.Generic;
using System.IO;

namespace BibtexManager
{
	/// <summary>
	/// 
	/// </summary>
	public class SpeBulkTitleImporter : BulkImporter, IBulkImporter
	{
		#region Fields

		private string			_importPath			= null;

		#endregion

		#region Construction


		/// <summary>
		/// Default constructor.
		/// </summary>
		public SpeBulkTitleImporter(string importPath)
		{
			_importPath = importPath;
		}

		#endregion

		#region Properties

		#endregion

		#region Interface Methods

		/// <summary>
		/// Search for and download the Bibtex entry for an SPE paper.
		/// </summary>
		/// <param name="searchTerms">Terms to search the web for the paper.</param>
		protected override BibEntry Import(string searchTerms)
		{
			foreach (string bibTexString in SpeImportUtilities.ArticleSearch(this.HttpClient, searchTerms))
			{
				if (!String.IsNullOrEmpty(bibTexString))
				{
					BibEntry bibEntry = ParseSingleEntryText(bibTexString);

					// Check to see if we found the right bibliography entry by comparing the search terms to the title.
					if (DigitalProduction.Strings.Format.Similarity(bibEntry.Title, searchTerms) > 0.9)
					{
						return bibEntry;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Bulk SPE paper search and import.
		/// </summary>
		/// <param name="path">The path to a file that contains a list of search strings.</param>
		public override IEnumerable<ImportResult> BulkImport()
		{
			string[] lines = File.ReadAllLines(_importPath);

			foreach (ImportResult importResult in BulkImport(lines))
			{
				yield return importResult;
			}

			// Write the results.
			string outputPath = DigitalProduction.IO.Path.GetFullPathWithoutExtension(_importPath) + "-output.xlsx";
			WriteBulkImportResults(outputPath);
		}

		#endregion

	} // End class.
} // End namespace.