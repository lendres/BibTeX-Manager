using BibTeXLibrary;
using BibTeXManager;
using BibTeXManager.Quality;
using DigitalProduction.Projects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace BibtexManager
{
	/// <summary>
	/// The model.
	/// </summary>
	[XmlRoot("bibtexproject")]
	public class BibtexProject : Project
	{
		#region Fields

		private string								_bibFile;
		private List<string>						_assessoryFiles					= new List<string>();
		
		private bool								_useBibEntryInitialization;
		private string								_bibEntryInitializationFile;

		private bool								_useTagQualityProcessing;
		private string								_tagQualityProcessingFile;
		private QualityProcessor					_tagQualityProcessor			= new QualityProcessor();

		private bool								_useNameRemapping				= false;
		private string								_nameRemappingFile;
		private string								_currentBibEntryMap				= "";
		private BibEntryRemapper					_nameRemapper					= new BibEntryRemapper();

		private readonly Bibliography				_bibliography					= new Bibliography();
		private WriteSettings						_writeSettings					= new WriteSettings();
		private bool								_autoGenerateKeys				= true;

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

		/// <summary>
		/// The path to the bibiography file.
		/// </summary>
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
					ReadBibliographyFile();
					this.Modified	= true;
				}
			}
		}

		/// <summary>
		/// Assessory files that contain things like strings.
		/// </summary>
		[XmlArray("assessoryfiles"), XmlArrayItem("file")]
		public List<string> AssessoryFiles
		{
			get
			{
				return _assessoryFiles;
			}

			set
			{
				if (!_assessoryFiles.SequenceEqual(value))
				{
					_assessoryFiles = value;
					this.Modified = true;
				}
			}
		}

		/// <summary>
		/// Determines if the bibiography entry initialization file.
		/// </summary>
		[XmlAttribute("usebibentryinitialization")]
		public bool UseBibEntryInitialization
		{
			get
			{
				return _useBibEntryInitialization;
			}

			set
			{
				if (_useBibEntryInitialization != value)
				{
					_useBibEntryInitialization = value;
					this.Modified = true;
				}
			}
		}

		/// <summary>
		/// The path to the bibiography entry initialization file.
		/// </summary>
		[XmlAttribute("bibentryinitializationfile")]
		public string BibEntryInitializationFile
		{
			get
			{
				return _bibEntryInitializationFile;
			}

			set
			{
				if (_bibEntryInitializationFile != value)
				{
					_bibEntryInitializationFile = value;
					this.Modified = true;
				}
			}
		}

		/// <summary>
		/// Specifies if the tags should be processed to ensure their quality.
		/// </summary>
		[XmlAttribute("usequalityprocessing")]
		public bool UseQualityProcessing
		{
			get
			{
				return _useTagQualityProcessing;
			}

			set
			{
				if (_useTagQualityProcessing != value)
				{
					_useTagQualityProcessing = value;
					this.Modified = true;
				}
			}
		}

		/// <summary>
		/// The path to the quality processor file.
		/// </summary>
		[XmlAttribute("qualityprocessorfile")]
		public string QualityProcessingFile
		{
			get
			{
				return _tagQualityProcessingFile;
			}

			set
			{
				if (_tagQualityProcessingFile != value)
				{
					_tagQualityProcessingFile = value;
					this.Modified = true;
				}
			}
		}

		/// <summary>
		/// Use BibEntry remapping.
		/// </summary>
		[XmlAttribute("usebibentryremapping")]
		public bool UseBibEntryRemapping
		{
			get
			{
				return _useNameRemapping;
			}
			set
			{
				if (_useNameRemapping != value)
				{
					_useNameRemapping = value;
					this.Modified = true;
				}
			}
		}

		/// <summary>
		/// The path to the bibliography remapping file.
		/// </summary>
		[XmlAttribute("remappingfile")]
		public string RemappingFile
		{
			get
			{
				return _nameRemappingFile;
			}

			set
			{
				if (_nameRemappingFile != value)
				{
					_nameRemappingFile = value;
					this.Modified = true;
				}
			}
		}

	
		/// <summary>
		/// The BibEntryMap to use for remapping.
		/// </summary>
		[XmlAttribute("bibentrymap")]
		public string BibEntryMap
		{
			get
			{
				return _currentBibEntryMap;
			}
			set
			{
				if (_currentBibEntryMap != value)
				{
					_currentBibEntryMap = value;
					this.Modified = true;
				}
			}
		}

		/// <summary>
		/// Bibliography.
		/// </summary>
		[XmlIgnore()]
		public Bibliography Bibliography { get => _bibliography; }

		/// <summary>
		/// The settings for writing the bibliography file.
		/// </summary>
		[XmlElement("writesettings")]
		public WriteSettings WriteSettings
		{
			get
			{
				return _writeSettings;
			}

			set
			{
				// WriteSettings needs to be able to override != ==.
				if (_writeSettings != value)
				{
					_writeSettings = value;
					_writeSettings.OnModifiedChanged += SetAsModified;
					this.Modified = true;
				}
			}
		}

		/// <summary>
		/// The settings for writing the bibliography file.
		/// </summary>
		[XmlAttribute("autogenerateekeys")]
		public bool AutoGenerateKeys
		{
			get
			{
				return _autoGenerateKeys;
			}

			set
			{
				if (_autoGenerateKeys != value)
				{
					_autoGenerateKeys = value;
					this.Modified = true;
				}
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Read the bibliography file.
		/// </summary>
		public void ReadBibliographyFile()
		{
			if (_useBibEntryInitialization)
			{
				_bibliography.Read(_bibFile, _bibEntryInitializationFile);
			}
			else
			{
				_bibliography.Read(_bibFile);
			}
		}

		/// <summary>
		/// Get an array of all the names of the maps.
		/// </summary>
		public string[] GetBibEntryMapNames()
		{
			return _nameRemapper.Maps.Keys.ToArray();
		}

		/// <summary>
		/// Parse a string and return BibEntrys.
		/// </summary>
		/// <param name="text">Text to process.</param>
		public List<BibEntry> ParseText(string text)
		{
			StringReader textReader = new StringReader(text);
			Tuple<List<string>, List<BibEntry>> result;
			if (_useBibEntryInitialization)
			{
				result = BibParser.Parse(textReader, _bibEntryInitializationFile);
			}
			else
			{
				result = BibParser.Parse(textReader);
			}

			return result.Item2;
		}

		/// <summary>
		/// If the option for automatically generating keys is on, a key is generated for the entry.
		/// </summary>
		/// <param name="entry">BibEntry.</param>
		public void GenerateKey(BibEntry entry)
		{
			if (_autoGenerateKeys)
			{
				_bibliography.AutoKeyEntry(entry);
			}
		}

		/// <summary>
		/// Clean a single entry.
		/// </summary>
		/// <param name="entry">BibEntry.</param>
		public IEnumerable<TagProcessingData> CleanEntry(BibEntry entry)
		{

			foreach (TagProcessingData tagProcessingData in _tagQualityProcessor.Process(entry))
			{
				yield return tagProcessingData;
			}
		}

		/// <summary>
		/// Remaps the Key and Tag Keys to new names.
		/// </summary>
		/// <param name="entry">BibEntry.</param>
		public void RemapEntryNames(BibEntry entry)
		{
			if (_useNameRemapping)
			{
				_nameRemapper.RemapEntryNames(entry, _currentBibEntryMap);
			}
		}

		/// <summary>
		/// Clean up.
		/// </summary>
		public override void Close()
		{
			// Must call base first.  This calls the OnClose event which should clear all forms (unbind) and
			// make it safe to close the Bibliography.
			base.Close();
			_bibliography.Close();
		}

		#endregion

		#region XML

		/// <summary>
		/// Writes a Project file (compressed file containing all the project's files).  Uses a ProjectCompressor to zip all files.  An
		/// event of RaiseOnSavingEvent fires allowing other files to be added to the project.
		///
		/// The this.Path must be set and represent a valid path or this method will throw an exception.
		/// </summary>
		/// <exception cref="InvalidOperationException">Thrown when the projects path is not set or not valid.</exception>
		public override void Serialize()
		{
			_bibliography.Write(_bibFile+".output.bib", _writeSettings);
			base.Serialize();
		}

		/// <summary>
		/// Initialize references.
		/// </summary>
		public override void DeserializationInitialization()
		{
			if (System.IO.File.Exists(_tagQualityProcessingFile))
			{
				_tagQualityProcessor = QualityProcessor.Deserialize(_tagQualityProcessingFile);
			}

			if (System.IO.File.Exists(_nameRemappingFile))
			{
				_nameRemapper = BibEntryRemapper.Deserialize(_nameRemappingFile);
			}
		}

		#endregion

	} // End class.
} // End namespace.