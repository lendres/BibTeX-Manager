using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibTeXManager.Quality
{
	/// <summary>
	/// 
	/// </summary>
	public class SentanceEndingSpacesTagProcessor : TagProcessor
	{
		#region Fields

		private bool			_frenchSpacing			= false;
		private List<string>	_excudedPatterns		= new List<string>();

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public SentanceEndingSpacesTagProcessor()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Specifies if French spacing (single space after sentance) should be used or a double space.
		/// </summary>
		[XmlAttribute("frenchspacing")]
		public bool FrenchSpacing { get => _frenchSpacing; set => _frenchSpacing = value; }

		/// <summary>
		/// Get the end of sentance spacing.
		/// </summary>
		private string Spacing
		{
			get
			{
				return _frenchSpacing ? " " : "  ";
			}
		}

		/// <summary>
		/// String patterns that are abbreviations and not end of sentances.
		/// </summary>
		[XmlArray("exceptions"), XmlArrayItem("exception")]
		public List<string> ExcludePatterns { get => _excudedPatterns; set => _excudedPatterns = value; }

		#endregion

		#region Methods

		/// <summary>
		/// Gets the replacement string for the input (original) string.
		/// </summary>
		/// <param name="correction">Correction information.</param>
		protected override void ProcessPatternMatch(Correction correction)
		{
			foreach (string excludeString in _excudedPatterns)
			{
				int index = -1;

				while ((index = excludeString.IndexOf('.', index+1)) > - 1)
				{
					// Don't process the last period in an exlude string.  We should add spaces after after a word,
					// we only want to prevent spaces being added mid-word.
					if (index == excludeString.Length-1)
					{
						break;
					}

					// Find out if we have enouch to extract.  If we are at the end of the string, compare the end of the
					// string to the exclude string.
					int extractionStart = correction.MatchStartIndex - index;
					if (extractionStart+excludeString.Length > correction.FullText.Length)
					{
						extractionStart = correction.FullText.Length - excludeString.Length;
					}

					string extractedTagSection = correction.FullText.Substring(extractionStart, excludeString.Length);
					if (extractedTagSection == excludeString)
					{
						correction.ReplaceText	= false;
						correction.PromptUser	= false;
						return;
					}

				}
			}

			// For the current setup, this isn't really needed, but if the pattern is changed, it might be.
			int indexOf = correction.MatchedText.LastIndexOf(".", new StringComparison());

			if (indexOf < 0)
			{
				throw new IndexOutOfRangeException("A period was not found.");
			}

			correction.ReplacementText	= correction.MatchedText.Substring(0, indexOf+1) + this.Spacing + correction.MatchedText.Substring(indexOf+1);
			correction.ReplaceText		= true;
		}
		
		#endregion

	} // End class.
} // End namespace.