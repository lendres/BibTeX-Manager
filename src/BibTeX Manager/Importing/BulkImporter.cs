using BibTeXLibrary;
using BibtexManager.Project;
using DigitalProduction.XML.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibtexManager
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class BulkImporter : ImporterBase
	{
		#region Fields

		private System.Diagnostics.Stopwatch		_stopWatch						= null;
		private bool								_continue						= true;

		List<string[]>                              _bulkImportResults              = new List<string[]>();

		#endregion

		#region Construction

		/// <summary>	
		/// Default constructor.
		/// </summary>
		public BulkImporter()
		{
		}

		#endregion

		#region Properties

		public bool Continue { get => _continue; set => _continue=value; }

		#endregion

		#region Protected Methods

		/// <summary>
		/// Bulk SPE paper search and import.
		/// </summary>
		/// <param name="path">The path to a file that contains a list of search strings.</param>
		protected IEnumerable<ImportResult> BulkImport(string[] lines)
		{
			_continue = true;

			foreach (string searchString in lines)
			{
				ImportResult importResult = null;
				do
				{
					importResult = ImportTry(searchString);

					if (importResult.Result == ResultType.Error)
					{
						yield return importResult;
						if (_continue)
						{
							// Wait 10 minutes.  60s/m * 1000ms/s * 10m.
							Wait(60*1000*10);
							//Wait(10);
						}
					}
				}
				while (importResult.Result==ResultType.Error & _continue);

				if (!_continue)
				{
					break;
				}

				if (importResult.BibEntry is null)
				{
					// A bibliography entry was not found.
					_bulkImportResults.Add(new string[] { "", "", searchString });
				}
				else
				{
					// A bibliography entry was found and returned.
					_bulkImportResults.Add(new string[] { importResult.BibEntry.Key, importResult.BibEntry.Title, searchString });
					yield return importResult;
				}
			}
		}

		#endregion

		#region Interface Methods

		/// <summary>
		/// Import a single entry from a search string.
		/// </summary>
		/// <param name="searchString">String containing search terms.</param>
		protected abstract BibEntry Import(string searchString);

		/// <summary>
		/// Bulk SPE paper search and import.
		/// </summary>
		public abstract IEnumerable<ImportResult> BulkImport();

		#endregion

		#region Private Methods

		private ImportResult ImportTry(string searchString)
		{
			_stopWatch = System.Diagnostics.Stopwatch.StartNew();

			try
			{
				BibEntry bibEntry       = Import(searchString);
				ResultType resultType   = bibEntry==null ? ResultType.NotFound : ResultType.Successful;
				return new ImportResult(resultType, bibEntry, "");
			}
			catch (Exception exception)
			{
				return new ImportResult(ResultType.Error, null, exception.Message);
			}
		}

		private void Wait(long timeToWait)
		{
			_stopWatch.Stop();
			long elapsedMs = _stopWatch.ElapsedMilliseconds;

			if (elapsedMs > timeToWait)
			{
				return;
			}
			else
			{
				Thread.Sleep((int)(timeToWait-elapsedMs));
			}
		}

		/// <summary>
		/// Writes the names of the references and titles to a file.
		/// </summary>
		/// <param name="filePath">The path and file name to write to.</param>
		/// <param name="_bulkImportResults">The reference names to write.</param>
		/// <param name="searchedTerms">The terms searched for references.</param>
		protected void WriteCsvBulkImportResults(string filePath)
		{
			// Open or create the CSV file for writing.
			using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
			{
				// Write each row of data to the file.
				for (int i = 0; i < _bulkImportResults.Count; i++)
				{
					writer.Write(_bulkImportResults[i][0]);
					writer.Write(", ");
					writer.Write(_bulkImportResults[i][1]);
					writer.Write(", ");
					string formatedTerm = "\"" + _bulkImportResults[i][2].Replace("\"", "\"\"") + "\"";
					writer.Write(formatedTerm);

					// End the row with a new line.
					writer.WriteLine();
				}
			}
		}

		#endregion

	} // End class.
} // End namespace.