using DigitalProduction.XML.Serialization;
using Google.Apis.CustomSearchAPI.v1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BibTeXLibrary;
using BibtexManager.Project;
using System.IO;
using System.Runtime.InteropServices;

namespace BibtexManager
{
	/// <summary>
	/// 
	/// </summary>
	public class SpeTitleImporter : ImporterBase, ISingleImporter
	{
		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SpeTitleImporter()
		{
		}

		#endregion

		#region Properties

		#endregion

		#region Interface Methods

		/// <summary>
		/// Search for and download the Bibtex entry for an SPE paper.
		/// </summary>
		/// <param name="searchTerms">Terms to search the web for the paper.</param>
		public BibEntry Import(string searchTerms)
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

		#endregion

	} // End class.
} // End namespace.