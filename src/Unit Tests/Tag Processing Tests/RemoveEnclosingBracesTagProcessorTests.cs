using BibTeXLibrary;
using BibtexManager;
using BibtexManager.Quality;

namespace BibtexManagerUnitTests
{
	[TestClass]
	public class RemoveEnclosingBracesTagProcessorTests
	{
		private static RemoveEnclosingBracesTagProcessor	_bracketProcessor  = new() { TagsToProcess = TagsToProcess.All };

		/// <summary>
		/// Base line test to remove brackets.
		/// </summary>
		[TestMethod]
		public void RemoveEndBrackets()
		{
			string solution = @"The quick brown fox jumped over the lazy dog.";
			string input	= @"{The quick brown fox jumped over the lazy dog.}";

			BibEntry entry	= new BibEntry() { Title = input };
			Utilities.RunProcessor(_bracketProcessor, entry);

			Assert.AreEqual(solution, entry.Title);
		}

		/// <summary>
		/// Base line test to remove brackets.
		/// </summary>
		[TestMethod]
		public void RemoveEndBracketsWithNewLines()
		{
			string solution = @"The quick brown \nfox jumped over the lazy dog.";
			string input    = @"{The quick brown \nfox jumped over the lazy dog.}";

			BibEntry entry  = new BibEntry() { Title = input };
			Utilities.RunProcessor(_bracketProcessor, entry);

			Assert.AreEqual(solution, entry.Title);
		}

		/// <summary>
		/// Run a test on a string without brackets.
		/// </summary>
		[TestMethod]
		public void NoBrackets()
		{
			string solution = @"The quick brown fox jumped over the lazy dog.";
			string input    = @"The quick brown fox jumped over the lazy dog.";

			BibEntry entry  = new BibEntry() { Title = input };
			Utilities.RunProcessor(_bracketProcessor, entry);

			Assert.AreEqual(solution, entry.Title);
		}

		/// <summary>
		/// Test that a string will not be replaced if the matched string is a substring of the replacement string.
		/// </summary>
		[TestMethod]
		public void DontReplaceStartBrace()
		{
			string solution = @"{The} quick brown fox jumped over the lazy dog.";
			string input    = @"{The} quick brown fox jumped over the lazy dog.";

			BibEntry entry  = new BibEntry() { Title = input };
			Utilities.RunProcessor(_bracketProcessor, entry);

			Assert.AreEqual(solution, entry.Title);
		}

		/// <summary>
		/// Test that a string will not be replaced if the matched string is a substring of the replacement string.
		/// </summary>
		[TestMethod]
		public void DontReplaceEndBrace()
		{
			string solution = @"The quick brown fox jumped over the lazy {dog.}";
			string input    = @"The quick brown fox jumped over the lazy {dog.}";

			BibEntry entry  = new BibEntry() { Title = input };
			Utilities.RunProcessor(_bracketProcessor, entry);

			Assert.AreEqual(solution, entry.Title);
		}

		/// <summary>
		/// Test that a string will not be replaced if the matched string is a substring of the replacement string.
		/// </summary>
		[TestMethod]
		public void DontReplaceStartOrEndBrace()
		{
			string solution = @"{The} quick brown fox jumped over the lazy {dog.}";
			string input    = @"{The} quick brown fox jumped over the lazy {dog.}";

			BibEntry entry  = new BibEntry() { Title = input };
			Utilities.RunProcessor(_bracketProcessor, entry);

			Assert.AreEqual(solution, entry.Title);
		}

	} // End class.
} // End namespace.