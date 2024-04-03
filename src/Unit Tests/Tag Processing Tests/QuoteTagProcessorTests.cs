using BibTeXLibrary;
using BibtexManager;

namespace BibtexManagerUnitTests
{
	[TestClass]
	public class QuoteProcessorTests
	{
		/// <summary>
		/// Test replacing "text" with ``text''.
		/// </summary>
		[TestMethod]
		public void ReplaceQuotes()
		{
			string solution = @"The ``quick'' brown fox jumped over the lazy dog.";
			string input = "The \"quick\" brown fox jumped over the lazy dog.";

			BibEntry entry = new BibEntry() { Title = input };
			QuoteTagProcessor processor = new() { TagsToProcess = TagsToProcess.All };

			processor.Pattern = "\".*\"";

			// Test lower case tag name.
			Utilities.RunProcessor(processor, entry);
			Assert.AreEqual(solution, entry.Title);
		}

	} // End class.
} // End namespace.