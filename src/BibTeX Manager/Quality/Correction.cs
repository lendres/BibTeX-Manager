using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibtexManager
{
	/// <summary>
	/// 
	/// </summary>
	public class Correction
	{
		#region Fields

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public Correction()
		{
			this.ReplaceText	= false;
			this.PromptUser	= true;
		}

		#endregion

		#region Properties

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

		#endregion

		#region Methods

		#endregion

	} // End class.
} // End namespace.