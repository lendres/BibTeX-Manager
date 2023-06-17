using BibTeXLibrary;
using BibtexManager;
using BibtexManager.Quality;
using System.Text.RegularExpressions;

namespace BibtexManagerUnitTests
{
	[TestClass]
	public class StringCaseTagProcessorTests
	{
		/// <summary>
		/// Convert all caps to title case.
		/// </summary>
		[TestMethod]
		public void ConvertAllCapsToTitle()
		{
			string solution = @"The Quick Brown Fox; Jumped!: Over the Lazy Dog.";
			string input	= @"THE QUICK BROWN FOX; JUMPED!: OVER THE LAZY DOG.";

			StringCaseTagProcessor processor  = new() { Pattern=@"^[A-Z\s\p{P}]*$",  TagsToProcess = TagsToProcess.All };

			BibEntry entry	= new BibEntry() { Title = input };
			Utilities.RunProcessor(processor, entry);

			Assert.AreEqual(solution, entry.Title);
		}

	} // End class.
} // End namespace.