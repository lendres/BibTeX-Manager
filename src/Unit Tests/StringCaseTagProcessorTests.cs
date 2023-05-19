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
		/// Base line test to remove brackets.
		/// </summary>
		[TestMethod]
		public void ConvertAllCapsToTitle()
		{
			string solution = @"The Quick Brown Fox; Jumped!: Over the Lazy Dog.";
			string input	= @"THE QUICK BROWN FOX; JUMPED!: OVER THE LAZY DOG.";

			StringCaseTagProcessor processor  = new() { Pattern=@"^[A-Z\s\p{P}]*$",  TagsToProcess = TagsToProcess.All };
			//StringCaseTagProcessor processor  = new() { Pattern=@"^[A-Z\s\.]+$",  TagsToProcess = TagsToProcess.All };

			BibEntry entry	= new BibEntry() { Title = input };
			Utilities.RunProcessor(processor, entry);

			Assert.AreEqual(solution, entry.Title);
		}

		/// <summary>
		/// Base line test to remove brackets.
		/// </summary>
		[TestMethod]
		public void RemoveEndBracketsWithNewLines()
		{
			string replacement    = @"{THE QUICK BROWN FOX: JUMPED; OVER! THE LAZY DOG.}";
			//string[] splitText      = Regex.Split(replacement, @"(?<=[\s])|\s");
			string delimeters       = @"\p{P}\s";
			string[] splitText      = Regex.Split(replacement, @"(?=[" + delimeters + "])|(?<=[" + delimeters + "])");

			splitText      = replacement.Split(new char[] { ' ' });
		}

	} // End class.
} // End namespace.