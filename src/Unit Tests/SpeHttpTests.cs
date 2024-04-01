using BibTeXLibrary;
using BibtexManager;
using BibTexManagerUnitTests;
using DigitalProduction.Http;
using DigitalProduction.Projects;
using Google.Apis.CustomSearchAPI.v1.Data;
using System.Runtime.Intrinsics.X86;
using System;
using BibtexManager.Project;

namespace BibtexManagerUnitTests
{
	[TestClass]
	public class SpeHttpTests
	{
		public SpeHttpTests()
		{
			CustomSearch.SetCxAndKey(CustomSearchKey.Deserialize(@"..\..\..\customsearchkey.xml"));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void SearchTest1()
		{
			SpeTitleImporter importer	= new SpeTitleImporter();
			BibEntry bibEntry			= importer.Import("A Novel Approach To Borehole Quality Measurement In Unconventional Drilling");
			//BibEntry bibEntry			= importer.Import("Advancements in Weight Material Sag Evaluation: A New Perspective with Advanced Laboratory Equipment");
			Assert.IsNotNull(bibEntry);
		}

		[TestMethod]
		public void SearchTest2()
		{
			//string search1 = "A Novel Approach To Borehole Quality Measurement In Unconventional Drilling";
			//string search2 = "Proven Well Stabilization Technology for Trouble-Free Drilling and Cost Savings in Pressurized Permeable Formations";
			string search3 = "Advancements in Weight Material Sag Evaluation: A New Perspective with Advanced Laboratory Equipment";
			string searchTerms = search3;

			string resultString = "Search: " + searchTerms + Environment.NewLine + Environment.NewLine;
			
			
			for (int i = 0; i < 1; i++)
			{
				//IList<Result> results = CustomSearch.SiteSearch(searchTerms, "onepetro.org");
				//IList<Result> results = CustomSearch.Search(searchTerms);
				IList<Result> results = CustomSearch.Search("site:onepetro.org "+searchTerms);

				foreach (Result result in results)
				{
					resultString += ResultString(result) + Environment.NewLine + Environment.NewLine + Environment.NewLine;
				}
			}
			//Assert.AreEqual(Statistics.Covariance(xValues, yValues), 2.9167, 0.0001, errorMessage);
		}

		private string ResultString(Result result)
		{
			string resultString = "";
			resultString += "Title:        " + result.Title + Environment.NewLine;
			resultString += "URL:          " + result.FormattedUrl + Environment.NewLine;
			//resultString += "HTML Title:   " + result.HtmlTitle + Environment.NewLine;
			resultString += "Display Link: " + result.DisplayLink + Environment.NewLine;
			resultString += "Link:         " + result.Link + Environment.NewLine;
			//resultString += "HtmlSnippet:  " + result.HtmlSnippet + Environment.NewLine;
			resultString += "Snippet:      " + result.Snippet + Environment.NewLine;
			//resultString += ": " + result + Environment.NewLine;
			return resultString;
		}

	} // End class.
} // End namespace.