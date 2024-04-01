namespace BibtexManager.Importing.Spe
{
	/// <summary>
	/// Class for holding information related to an article.
	/// </summary>
	public class ConferenceReferenceItem
	{
		#region Fields

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ConferenceReferenceItem()
		{
		}

		#endregion

		#region Properties

		public string Reference {  get; set; }

		public string Title { get; set; }

		public string Session {  get; set; }

		public string Day { get; set; }

		public string Url { get; set; }

		#endregion

		#region Methods

		public string[] ToStringArray()
		{
			return new string[]
			{
				Reference,
				Title,
				Session,
				Day,
				Url
			};
		}

		#endregion

	} // End class.
} // End namespace.