﻿using DigitalProduction.XML.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibtexManager.Quality
{
	/// <summary>
	/// 
	/// </summary>
	public class RemoveEnclosingBracesTagProcessor : ReplacementTagProcessor
	{
		#region Fields

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public RemoveEnclosingBracesTagProcessor()
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
			throw new NotImplementedException();

			// We need to make sure we don't replace a string with the intended output.  I.e., we have to make sure we
			// don't replace "XXX" with "{XXX}" when the brackets already exist.  The matching (searching) part will find
			// the "XXX" inside of "{XXX}" so we could end up with "{{XXX}}" if we don't check.

			// Initialize.
			correction.ReplacementText = _replacement;

			// See if the replacement contains the original.  If it does, we needto do more checks.  Not every case will need
			// this.  If we are replacing "&amp;" with "\&" we won't need to do anything.
			int indexOf = _replacement.IndexOf(correction.MatchedText);

			if (indexOf > -1)
			{
				string beginsWith       = _replacement.Substring(0, indexOf);
				int startIndex          = correction.MatchStartIndex-beginsWith.Length;

				if (startIndex > -1 && correction.FullText.Length > startIndex+_replacement.Length)
				{
					string extendedMatch    = correction.FullText.Substring(startIndex, _replacement.Length);

					if (extendedMatch == _replacement)
					{
						// The replacement string already exists so don't prompt the user and don't replace the text.
						correction.PromptUser   = false;
						correction.ReplaceText  = false;
					}
				}
			}
		}

		#endregion

	} // End class.
} // End namespace.