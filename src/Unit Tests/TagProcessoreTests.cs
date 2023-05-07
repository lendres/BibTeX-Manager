using BibTeXLibrary;
using BibTeXManager;
using BibTeXManager.Quality;

namespace BibTexManagerUnitTests
{
	[TestClass]
	public class TagProcessoreTests
	{
		/// <summary>
		/// Base line test to replace text.
		/// </summary>
		[TestMethod]
		public void ReplaceOneString()
		{
			string solution = @"The quick brown fox \& quicker red squirrel jumped over the fence \& lazy dog.";
			string input	= @"The quick brown fox &amp; quicker red squirrel jumped over the fence &amp; lazy dog.";

			BibEntry entry								= new BibEntry() { Title = input, Abstract = input };
			StringReplacementTagProcessor processor		= new StringReplacementTagProcessor() { ProcessAllTags = false };
			processor.TagNames.Add("abstract");

			processor.Pattern		= "&amp;";
			processor.Replacement	= @"\&";

			RunProcessor(processor, entry);

			Assert.AreEqual(input, entry.Title);
			Assert.AreEqual(solution, entry.Abstract);
		}

		/// <summary>
		/// Tests that all tags are processed and that strings at the end of a line are replaced.
		/// </summary>
		[TestMethod]
		public void ReplaceAllStringsAtEnd()
		{
			string solution	= @"The quick brown fox \& quicker red squirrel jumped over the fence lazy dog.\&";
			string input	= @"The quick brown fox &amp; quicker red squirrel jumped over the fence lazy dog.&amp;";

			BibEntry entry								= new BibEntry() { Title = input, Abstract = input };
			StringReplacementTagProcessor processor		= new StringReplacementTagProcessor() { ProcessAllTags = true };

			processor.Pattern		= "&amp;";
			processor.Replacement	= @"\&";

			RunProcessor(processor, entry);

			Assert.AreEqual(solution, entry.Title);
			Assert.AreEqual(solution, entry.Abstract);
		}

		/// <summary>
		/// Test that a string will not be replaced if the matched string is a substring of the replacement string.
		/// </summary>
		[TestMethod]
		public void DontReplaceMatchedSubStrings()
		{
			string solution = @"The quick {Red} fox & quicker {Red} squirrel jumped over the fence & lazy dog.";
			string input	= @"The quick {Red} fox & quicker Red squirrel jumped over the fence & lazy dog.";

			BibEntry entry = new BibEntry() { Title = input};
			StringReplacementTagProcessor processor = new StringReplacementTagProcessor() { ProcessAllTags = true };

			processor.Pattern		= "Red";
			processor.Replacement	= "{Red}";
			processor.TagNames.Add("title");

			// Test lower case tag name.
			RunProcessor(processor, entry);
			Assert.AreEqual(solution, entry.Title);

			// Test upper case tage name.
			processor.TagNames.Clear();
			processor.TagNames.Add("Title");
			RunProcessor(processor, entry);
			Assert.AreEqual(solution, entry.Title);
		}

		private void RunProcessor(TagProcessor processor, BibEntry entry)
		{
			foreach (Correction correction in processor.Corrections(entry))
			{
				if (correction.PromptUser)
				{
					correction.ReplaceText = true;
				}
			}
		}

	} // End class.
} // End namespace.