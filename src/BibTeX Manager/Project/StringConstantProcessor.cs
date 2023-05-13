using BibTeXLibrary;
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
	public class StringConstantProcessor
	{
		#region Fields

		private Dictionary<string, string>			_map		= new Dictionary<string, string>();

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public StringConstantProcessor()
		{
		}

		#endregion

		#region Properties

		#endregion

		#region Methods

		private void AddStringConstantsToMap(List<BibliographyDOM> bibliographyDOMs)
		{
			foreach (BibliographyDOM bibliographyDOM in bibliographyDOMs)
			{
				AddStringConstantsToMap(bibliographyDOM);
			}
		}

		private void AddStringConstantsToMap(BibliographyDOM bibliographyDOM)
		{
			foreach (BibEntry entry in bibliographyDOM.StringConstants)
			{
				//_map.Add(entry.)
			}

		}

		public void ApplyStringConstants(BibEntry entry)
		{
/*			foreach (BibliographyDOM bibliographyDOM in _assessoryFilesDOMs)
			{

			}*/

		}


		#endregion

		#region XML

		#endregion

	} // End class.
} // End namespace.