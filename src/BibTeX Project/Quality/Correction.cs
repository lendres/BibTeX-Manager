namespace BibtexManager
{
	/// <summary>
	/// 
	/// </summary>
	public class Correction
	{
		#region Fields

		private static int contextPrefix = 25;
		private static int contextSuffix = 25;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Correction()
		{
			this.ReplaceText	= false;
			this.PromptUser		= true;
		}

		#endregion

		#region Properties

		/// <summary>
		/// The tag being processed.
		/// </summary>
		public string TagName { get; set; }

		/// <summary>
		/// The full, original text.
		/// </summary>
		public string FullText { get; set; }

		/// <summary>
		/// The matched text.
		/// </summary>
		public string MatchedText { get; set; }

		/// <summary>
		/// Starting index of the match within the full text.
		/// </summary>
		public int MatchStartIndex { get; set; }

		/// <summary>
		/// Replacement text.
		/// </summary>
		public string ReplacementText { get; set; }

		/// <summary>
		/// Specifies if the text should be replaced.  Output from user prompting or if the tag processor
		/// determines that the text should not be replaced.
		/// </summary>
		public bool ReplaceText { get; set; }

		/// <summary>
		/// Specifies if the user should be prompted for replacement.
		/// </summary>
		public bool PromptUser { get; set; }

		/// <summary>
		/// Get the text surrounding the matched text.
		/// </summary>
		public string Context
		{
			get
			{
				int startIndex = this.MatchStartIndex - contextPrefix;
				if (startIndex < 0)
				{
					startIndex = 0;
				}

				int length = contextPrefix + this.MatchedText.Length + contextSuffix;
				if (startIndex+length > this.FullText.Length)
				{
					length = this.FullText.Length - startIndex;
				}

				return this.FullText.Substring(startIndex, length);
			}
		}

		#endregion

		#region Methods

		#endregion

	} // End class.
} // End namespace.