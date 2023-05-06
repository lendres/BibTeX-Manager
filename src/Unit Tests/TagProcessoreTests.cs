using BibTeXLibrary;
using BibTeXManager;
using BibTeXManager.Quality;

namespace BibTexManagerUnitTests
{
	[TestClass]
	public class TagProcessoreTests
	{
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

			foreach (Correction correction in processor.Corrections(entry))
			{
				correction.Replace = true;
			}

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

			foreach (Correction correction in processor.Corrections(entry))
			{
				correction.Replace = true;
			}

			Assert.AreEqual(solution, entry.Title);
			Assert.AreEqual(solution, entry.Abstract);
		}

	} // End class.
} // End namespace.