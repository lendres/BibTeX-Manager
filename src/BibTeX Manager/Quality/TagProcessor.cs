using BibTeXLibrary;
using BibTeXManager.Quality;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibTeXManager
{
	/// <summary>
	/// Base class for tag processors.
	/// </summary>
	[XmlInclude(typeof(StringReplacementTagProcessor))]
	public abstract class TagProcessor
	{
		#region Fields

		private bool						_processAllTags				= true;
		private BindingList<string>			_tagNames					= new BindingList<string>();
		protected string					_pattern;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TagProcessor()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Process any tag or just those specified.
		/// </summary>
		[XmlAttribute("processalltages")]
		public bool ProcessAllTags { get => _processAllTags; set => _processAllTags = value; }

		/// <summary>
		/// Tag names to process.
		/// </summary>
		[XmlArray("tags"), XmlArrayItem("tag")]
		public BindingList<string> TagNames
		{
			get
			{
				return _tagNames;
			}

			set
			{
				_tagNames.Clear();
				foreach (string tagName in value)
				{
					_tagNames.Add(tagName.ToLower());
				}
			}
		}

		[XmlAttribute("pattern")]
		public string Pattern { get => _pattern; set => _pattern = value; }

		#endregion

		#region Methods

		/// <summary>
		/// Processes all the corrections for a single BibEntry.
		/// </summary>
		/// <param name="entry">BibEntry to process.</param>
		public IEnumerable<Correction> Corrections(BibEntry entry)
		{
			foreach (string tagName in entry.TagNames)
			{
				// If we are processing all tags or if the current tag name was specified as one to process.
				// We do a case insensitive comparison of tag names.  See this.TagNames set for where this objects
				// tag names are set to lower case.
				if (_processAllTags || _tagNames.Contains(tagName.ToLower()))
				{
					foreach (Correction correction in ProcessTag(entry, tagName))
					{
						yield return correction;
					}
				}
			}
		}

		/// <summary>
		/// Process a single tag.
		/// </summary>
		/// <param name="entry">BibEntry.</param>
		/// <param name="tagName">Name of the tag to process.</param>
		private IEnumerable<Correction> ProcessTag(BibEntry entry, string tagName)
		{
			StringBuilder output	= new StringBuilder();
			string tagValue			= entry[tagName];
			int lastIndex			= 0;

			foreach (Match match in Regex.Matches(tagValue, _pattern))
			{
				if (match.Success && match.Groups.Count > 0)
				{
					Correction correction		= new Correction() { FullText = tagValue, MatchedText = match.Value, MatchStartIndex = match.Index };
					GetReplacement(correction);

					if (correction.PromptUser)
					{
						yield return correction;
					}

					lastIndex = ProcessCorrectionResult(correction, output, lastIndex);
				}
			}

			// Add the remaining part of the string.
			if (lastIndex < tagValue.Length)
			{
				output.Append(tagValue.Substring(lastIndex));
			}

			entry[tagName] = output.ToString();
		}

		/// <summary>
		/// Uses the information provided to update the output string.
		/// </summary>
		/// <param name="correction">Correction data.</param>
		/// <param name="output">Output string that is being built.</param>
		/// <param name="lastIndex">The index position in the string that was last processed.</param>
		protected int ProcessCorrectionResult(Correction correction, StringBuilder output, int lastIndex)
		{
			if (correction.ReplaceText)
			{
				output.Append(correction.FullText.Substring(lastIndex, correction.MatchStartIndex-lastIndex));
				output.Append(correction.ReplacementText);

				lastIndex = correction.MatchStartIndex + correction.MatchedText.Length;
			}

			return lastIndex;
		}

		/// <summary>
		/// Gets the replacement string for the input (original) string.
		/// </summary>
		/// <param name="correction">Correction information.</param>
		protected abstract void GetReplacement(Correction correction);

		#endregion

		#region XML

		#endregion

	} // End class.
} // End namespace.