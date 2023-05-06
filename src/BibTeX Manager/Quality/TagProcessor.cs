using BibTeXLibrary;
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
	/// 
	/// </summary>
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
		public BindingList<string> TagNames { get => _tagNames; set => _tagNames = value; }

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
				if (_processAllTags || _tagNames.Contains(tagName))
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
					Correction correction	= new Correction() { Existing = match.Value };
					correction.Replacement	= GetReplacement(correction.Existing);

					yield return correction;

					lastIndex = ProcessCorrectionResult(tagValue, correction, output, lastIndex, match.Index);
				}
			}

			// Add the remaining part of the string.
			if (lastIndex < tagValue.Length)
			{
				output.Append(tagValue.Substring(lastIndex));
			}

			entry[tagName] = output.ToString();
		}

		protected int ProcessCorrectionResult(string tagValue, Correction correction, StringBuilder output, int lastIndex, int startIndex)
		{
			if (correction.Replace)
			{
				output.Append(tagValue.Substring(lastIndex, startIndex-lastIndex));
				output.Append(correction.Replacement);

				lastIndex = startIndex + correction.Existing.Length;
			}

			return lastIndex;
		}

		protected abstract string GetReplacement(string original);

		#endregion

		#region XML

		#endregion

	} // End class.
} // End namespace.