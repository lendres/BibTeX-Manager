using BibTeXLibrary;
using BibtexManager.Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

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
		private List<string[]>						_bulkImportResults				= new List<string[]>();

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

				SaveResults(searchString, importResult);

				if (importResult.BibEntry != null)
				{
					yield return importResult;
				}
			}
		}

		protected virtual void SaveResults(string searchString, ImportResult importResult)
		{
			if (importResult.BibEntry is null)
			{
				// A bibliography entry was not found.
				AddResult(new string[] { "", "", searchString });
			}
			else
			{
				// A bibliography entry was found and returned.
				AddResult(
					new string[]
					{ 
						importResult.BibEntry.Key,
						importResult.BibEntry.Title,
						"\"" + searchString.Replace("\"", "\"\"") + "\""
					}
				);
			}
		}

		protected void AddResult(string[] resultArray)
		{
			_bulkImportResults.Add(resultArray);
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

		#region Methods

		protected ImportResult ImportTry(string searchString)
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
					for (int j = 0; j < _bulkImportResults[i].Length; j++)
					{
						writer.Write(_bulkImportResults[i][j]);
						if (j < _bulkImportResults[i].Length-1)
						{
							writer.Write(", ");
						}
					}

					// End the row with a new line.
					writer.WriteLine();
				}
			}
		}

		#endregion

	} // End class.
} // End namespace.