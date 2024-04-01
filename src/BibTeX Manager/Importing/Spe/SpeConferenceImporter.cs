using BibTeXLibrary;
using BibtexManager.Importing.Spe;
using BibtexManager.Project;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BibtexManager
{
	/// <summary>
	/// 
	/// </summary>
	public class SpeConferenceImporter : BulkImporter, IBulkImporter
	{
		#region Fields

		private string						_importPath					= null;

		private int							_currentReferenceItem		= 0;

		List<ConferenceReferenceItem>		_conferenceItems			= new List<ConferenceReferenceItem>();
		List<string>						_articleLinks				= new List<string>();

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SpeConferenceImporter(string importPath)
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
		protected override BibEntry Import(string url)
		{
			string bibTexString = SpeImportUtilities.DownloadSpeBibtex(this.HttpClient, url).Result;

			if (!String.IsNullOrEmpty(bibTexString))
			{
				return ParseSingleEntryText(bibTexString);
			}

			return null;
		}

		/// <summary>
		/// Bulk SPE paper search and import.
		/// </summary>
		/// <param name="path">The path to a file that contains a list of search strings.</param>
		public override IEnumerable<ImportResult> BulkImport()
		{
			string[] conferencePageUrls = File.ReadAllLines(_importPath);

			_currentReferenceItem = 0;

			GenerateConferenceLinks(conferencePageUrls);

			foreach (ImportResult importResult in BulkImport(_articleLinks.ToArray()))
			{
				yield return importResult;
			}

			// Write the results.
			string outputPath = DigitalProduction.IO.Path.GetFullPathWithoutExtension(_importPath) + "-output.csv";
			WriteCsvBulkImportResults(outputPath);
		}

		private void GenerateConferenceLinks(string[] conferencePageUrls)
		{
			foreach (string conferencePageUrl in conferencePageUrls)
			{
				List<HtmlNode> sessionSections = GetSessionSections(conferencePageUrl);

				foreach (HtmlNode sessionSection in sessionSections)
				{
					string sessionName = sessionSection.FirstChild.InnerText;

					foreach (string articleLink in GetArticleLinks(sessionSection))
					{
						_conferenceItems.Add(
							new ConferenceReferenceItem()
							{
								Day         = conferencePageUrl,
								Session     = sessionName,
								Url         = articleLink
							}
						);

						_articleLinks.Add(articleLink);
					}
				}
			}
		}

		protected override void SaveResults(string searchString, ImportResult importResult)
		{
			ConferenceReferenceItem referenceItem = _conferenceItems[_currentReferenceItem++];

			if (importResult.BibEntry != null)
			{
				referenceItem.Reference	= importResult.BibEntry.Key;
				referenceItem.Title		= importResult.BibEntry.Title;
			}

			AddResult(referenceItem.ToStringArray());
		}

		private List<HtmlNode> GetSessionSections(string url)
		{
			HtmlNode articleList = GetArticleListSection(url);
			IEnumerable<HtmlNode> sessionSections = articleList.Descendants("section");
			return sessionSections.ToList();
		}

		private HtmlNode GetArticleListSection(string url)
		{
			HtmlDocument htmlDocument				= new HtmlWeb().Load(url);
			IEnumerable<HtmlNode> articleSection	= htmlDocument.DocumentNode.Descendants("div")
				.Select(div => div)
				.Where(u => u.GetAttributeValue("id", null) == "ArticleList");

			return articleSection.ToList<HtmlNode>()[0];
		}

		private List<string> GetArticleLinks(HtmlNode sessionSection)
		{
			IEnumerable<HtmlNode> articleLinks = sessionSection.Descendants("a")
				.Select(a => a)
				.Where(u => u.GetAttributeValue("class", null) == "viewArticleLink");

			List<string> links = new List<string>();

			foreach (HtmlNode link in articleLinks)
			{
				links.Add(link.GetAttributeValue("href", null));
			}

			return links;
		}

		//<a href="/SPEDC/proceedings/24DC/1-24DC/D011S002R002/542896" class="viewArticleLink" data-feathr-click-track="true" data-feathr-link-aids="5d7a72b3d3708ff60b15b26c">View Article<span class="screenreader-text">titled, Blind Trust: Challenges in Data Sharing for Oil and Gas Well Construction</span></a>

		#endregion

	} // End class.
} // End namespace.