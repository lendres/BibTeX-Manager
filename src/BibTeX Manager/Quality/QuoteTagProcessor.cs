using DigitalProduction.Strings;

namespace BibtexManager
{
	/// <summary>
	/// Changes quotation marks ("...") to LaTeX quotations (``...'').
	/// </summary>
	public class QuoteTagProcessor : TagProcessor
	{
		#region Fields

		private StringCase          _toCase             = StringCase.TitleCase;
		private string              _culture            = "en-US";

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public QuoteTagProcessor()
		{
		}

		#endregion

		#region Properties
		
		#endregion

		#region Methods

		/// <summary>
		/// Gets the replacement string for the input (original) string.
		/// </summary>
		/// <param name="correction">Correction information.</param>
		protected override void ProcessPatternMatch(Correction correction)
		{
			correction.ReplacementText  = "``" + correction.MatchedText.Substring(1, correction.MatchedText.Length-2) + "''";
			correction.ReplaceText		= true;
			correction.PromptUser		= true;
		}

		#endregion

	} // End class.
} // End namespace.