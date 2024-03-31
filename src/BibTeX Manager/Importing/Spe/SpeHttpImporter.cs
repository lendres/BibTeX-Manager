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
	public class SpeHttpImporter : Importer
	{
		#region Enumerations

		#endregion

		#region Delegates

		#endregion

		#region Events

		#endregion

		#region Fields

		private string			_importPath			= null;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SpeHttpImporter()
		{
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SpeHttpImporter(string importPath)
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
		public override BibEntry Import(string searchTerms)
		{
			string website          = "onepetro.org";

			//IList<Result> results   = DigitalProduction.Http.CustomSearch.SiteSearch(searchTerms, website);
			IList<Result> results   = DigitalProduction.Http.CustomSearch.Search(searchTerms + " " + website);

			foreach (Result result in results)
			{
				string webSiteUrl       = result.Link;
				WebPageType webPageType = SpeWebPageType(webSiteUrl, website);
				BibEntry bibEntry       = null;

				switch (webPageType)
				{
					case WebPageType.ArticlePage:
						bibEntry = DownloadSpeBibtex(webSiteUrl, searchTerms).Result;
						break;

					case WebPageType.ConferencePage:
						bibEntry = SearchConferencePageForArticle(webSiteUrl, searchTerms);
						break;

					case WebPageType.Unknown:
						// No nothing and keep searching.
						break;
				}

				// If we found the correct entry, return it, otherwise we keep searching.
				if (bibEntry != null)
				{
					return bibEntry;
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
			string outputPath = DigitalProduction.IO.Path.GetFullPathWithoutExtension(_importPath) + "-output.csv";
			WriteCsvBulkImportResults(outputPath);
		}

		private WebPageType SpeWebPageType(string result, string website)
		{
			// Look for resutls that contain the specified website.
			if (!result.Contains(website))
			{
				return WebPageType.Unknown;
			}

			string lastPathElement = result.Split('/').Last();

			if (result.Contains("conference"))
			{
				return WebPageType.ConferencePage;
			}

			// Did we find a OnePetro reference to a document or something else?  The documents end in a number.
			if (int.TryParse(lastPathElement, out int n))
			{
				return WebPageType.ArticlePage;
			}

			return WebPageType.Unknown;
		}


		async private Task<BibEntry> DownloadSpeBibtex(string result, string searchTerms)
		{
			// Extract the last path element.  For an SPE article, this should be the document ID.
			string docuementID = result.Split('/').Last();

			// Attempt to download the bitex entry.
			HttpResponseMessage response        = _client.GetAsync("https://onepetro.org/Citation/Download?resourceId="+docuementID+"&resourceType=3&citationFormat=2").Result;
			HttpContent         content         = response.Content;
			string              responseString  = await content.ReadAsStringAsync();
			responseString                      = DigitalProduction.Strings.Format.TrimStart(responseString, "\r\n");

			if (!String.IsNullOrEmpty(responseString))
			{
				BibEntry bibEntry = ParseSingleEntryText(responseString);

				// Check to see if we found the right bibliography entry by comparing the search terms to the title.
				if (DigitalProduction.Strings.Format.Similarity(bibEntry.Title, searchTerms) > 0.9)
				{
					return bibEntry;
				}
			}

			return null;
		}

		private BibEntry SearchConferencePageForArticle(string url, string searchTerms)
		{
			//List<string> links = DigitalProduction.Http.HttpGet.GetAllLinksOnPage(url);
			List<string[]> links = DigitalProduction.Http.HttpGet.GetAllLinksOnPage(url);

			foreach (string[] link in links)
			{
				if (DigitalProduction.Strings.Format.Similarity(link[0], searchTerms) > 0.9)
				{
					return DownloadSpeBibtex(link[1], searchTerms).Result;
				}
			}

			return null;
		}

		#endregion

	} // End class.
} // End namespace.