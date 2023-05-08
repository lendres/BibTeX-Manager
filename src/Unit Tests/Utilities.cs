using BibTeXLibrary;
using BibTeXManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibTexManagerUnitTests
{
	/// <summary>
	/// 
	/// </summary>
	public static class Utilities
	{
		#region Fields

		#endregion

		#region Properties

		#endregion

		#region Methods

		public static void RunProcessor(TagProcessor processor, BibEntry entry)
		{
			foreach (Correction correction in processor.Corrections(entry))
			{
				if (correction.PromptUser)
				{
					correction.ReplaceText = true;
				}
			}
		}

		#endregion

	} // End class.
} // End namespace.