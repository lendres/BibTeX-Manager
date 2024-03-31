using BibTeXLibrary;
using BibtexManager.Project;
using System.Collections.Generic;

namespace BibtexManager
{
	public interface IBulkImporter
	{
		void SetBibliographyInitialization(bool useBibEntryInitialization, BibEntryInitialization bibEntryInitialization);

		/// <summary>
		/// Bulk SPE paper search and import.
		/// </summary>
		IEnumerable<ImportResult> BulkImport();
	}
}
