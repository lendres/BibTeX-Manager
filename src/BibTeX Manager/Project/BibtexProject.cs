using BibTeXLibrary;
using DigitalProduction.Projects;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BibTeXManager
{
	/// <summary>
	/// The model.
	/// </summary>
	internal class BibtexProject : Project
	{
		#region Members

		private string				_bibFile;
		private List<string>		_assessoryFiles = new List<string>();

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public BibtexProject()
		{
		}

		#endregion

		#region Static Properties

		/// <summary>
		/// The filter string used to select files.
		/// </summary>
		public static string FilterString
		{
			get
			{
				return "BibTeX Manager project files (*.bibproj)|*.bibproj|Text files (*.txt)|*.txt|All files (*.*)|*.*";
			}
		}

		#endregion

		#region Properties

		[XmlAttribute("bibfile")]
		public string BibFile
		{
			get
			{
				return _bibFile;
			}

			set
			{
				_bibFile = value;
			}
		}

		/// <summary>
		/// Assessory files that contain things like strings.
		/// </summary>
		[XmlArray("datanames"), XmlArrayItem("name")]
		public List<string> AssessoryFiles
		{
			get
			{
				return _assessoryFiles;
			}

			set
			{
				_assessoryFiles = value;
			}
		}


		#endregion

		#region Methods

		public void ReadBibFile()
		{
			BibParser parser		= new BibParser(new StreamReader(_bibFile, Encoding.Default));
			List<BibEntry> entries	= parser.GetAllResult();
		}

		#endregion

		#region XML

		/// <summary>
		/// Initialize references.
		/// </summary>
		public override void DeserializationInitialization()
		{
		}

		#endregion

	} // End class.
} // End namespace.