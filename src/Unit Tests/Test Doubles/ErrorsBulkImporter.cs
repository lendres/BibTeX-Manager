using BibTeXLibrary;
using BibtexManager;
using BibtexManager.Project;


namespace BibTexManagerUnitTests
{
	/// <summary>
	/// 
	/// </summary>
	public class ErrorsBulkImporter : BulkImporter, IBulkImporter
	{
		#region Fields

		int _tryCount	= 0;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ErrorsBulkImporter()
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
		protected override BibEntry? Import(string searchString)
		{
			switch (_tryCount++)
			{
				case 0:
					// Not found.
					return null;

				case 1:
					throw new Exception("Error and try again.");

				default:
					return ParseSingleEntryText(searchString);
			}
		}

		/// <summary>
		/// Bulk SPE paper search and import.
		/// </summary>
		public override IEnumerable<ImportResult> BulkImport()
		{
			foreach (ImportResult importResult in BulkImport(this.BibEntryStrings))
			{
				yield return importResult;
			}
		}

		#endregion

	} // End class.
} // End namespace.