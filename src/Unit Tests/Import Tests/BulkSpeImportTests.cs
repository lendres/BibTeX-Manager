using BibtexManager;
using BibtexManager.Project;
using DigitalProduction.Http;

namespace BibtexManagerUnitTests
{
	[TestClass]
	public class BulkSpeImportTests
	{
		public BulkSpeImportTests()
		{
			CustomSearch.SetCxAndKey(CustomSearchKey.Deserialize(@"..\..\..\customsearchkey.xml"));
		}

		/// <summary>
		/// 
		/// </summary>
		[TestMethod]
		public void ConferenceImportTest()
		{
			string search1					= "https://onepetro.org/SPEDC/24DC/conference/2-24DC";
			SpeConferenceImporter importer	= new(new string[] { search1 });
			string resultString				= "Search: " + search1 + Environment.NewLine + Environment.NewLine;

			foreach (ImportResult result in importer.BulkImport())
			{
				resultString += result.BibEntry.ToString();
			}

			//Assert.AreEqual(Statistics.Covariance(xValues, yValues), 2.9167, 0.0001, errorMessage);
		}

	} // End class.
} // End namespace.