using BibTeXLibrary;
using BibtexManager.Project;
using System.Collections.Generic;

namespace BibtexManager
{
	public interface IImporter
	{
		/// <summary>
		/// Import a single entry from a search string.
		/// </summary>
		/// <param name="searchString">String containing search terms.</param>
		BibEntry Import(string searchString);

		void SetBibliographyInitialization(bool useBibEntryInitialization, BibEntryInitialization bibEntryInitialization);

		/// <summary>
		/// Bulk SPE paper search and import.
		/// </summary>
		/// <param name="path">The path or URL to read the search items from.</param>
		IEnumerable<ImportResult> BulkImport(string path);
	}
}
