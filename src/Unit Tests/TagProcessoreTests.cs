using BibTeXLibrary;
using BibTeXManager;
using BibTeXManager.Quality;

namespace BibTexManagerUnitTests
{
	[TestClass]
	public class TagProcessoreTests
	{
		[TestMethod]
		public void ReplaceStrings()
		{
			string solution = @"The quick brown fox \& quicker red squirrel jumped over the fence \& lazy dog.";
			string input	= @"The quick brown fox &amp; quicker red squirrel jumped over the fence &amp; lazy dog.";

			BibEntry entry								= new BibEntry() { Abstract = input };
			StringReplacementTagProcessor processor		= new StringReplacementTagProcessor() { ProcessAllTags = true };

			processor.Replacement	= @"\&";
			processor.Pattern		= "&amp;";

			foreach (Correction correction in processor.Corrections(entry))
			{
				correction.Replace = true;
			}

			Assert.AreEqual(solution, entry.Abstract);
		}

		[TestMethod]
		public void ReplaceStringAtEnd()
		{
			string solution	= @"The quick brown fox \& quicker red squirrel jumped over the fence lazy dog.\&";
			string input	= @"The quick brown fox &amp; quicker red squirrel jumped over the fence lazy dog.&amp;";

			BibEntry entry								= new BibEntry() { Abstract = input };
			StringReplacementTagProcessor processor		= new StringReplacementTagProcessor() { ProcessAllTags = true };

			processor.Replacement	= @"\&";
			processor.Pattern		= "&amp;";

			foreach (Correction correction in processor.Corrections(entry))
			{
				correction.Replace = true;
			}

			Assert.AreEqual(solution, entry.Abstract);
		}

	} // End class.
} // End namespace.