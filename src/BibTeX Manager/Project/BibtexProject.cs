using BibTeXLibrary;
using DigitalProduction.Projects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BibtexManager
{
	/// <summary>
	/// The model.
	/// </summary>
	public class BibtexProject : Project
	{
		#region Members

		private string								_bibFile;
		private List<string>						_assessoryFiles		= new List<string>();
		private ObservableCollection<BibEntry>		_entries			= new ObservableCollection<BibEntry>();

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
				if (_bibFile != value)
				{
					_bibFile		= value;
					ReadBibFile();
					this.Modified	= true;
				}
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
				if (_assessoryFiles != value)
				{
					_assessoryFiles	= value;
					this.Modified	= true;
				}
			}
		}

		/// <summary>
		/// BibTeX entries.
		/// </summary>
		[XmlIgnore()]
		public ObservableCollection<BibEntry> Entries
		{
			get
			{
				return _entries;
			}
			set
			{
				_entries = value;
			}
		}

		#endregion

		#region Methods

		public void ReadBibFile()
		{
			BibParser parser		= new BibParser(new StreamReader(_bibFile, Encoding.Default));
			_entries.Clear();
			foreach (BibEntry bibEntry in parser.GetAllResult())
			{
				_entries.Add(bibEntry);
			}
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