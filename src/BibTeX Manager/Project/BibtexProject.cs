using BibTeXLibrary;
using BibTeXManager;
using DigitalProduction.Projects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using static DigitalProduction.Forms.MessageBoxYesNoToAll;

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
		private string								_qualityProcessingFile;
		private QualityProcessor					_qualityProcessor				= new QualityProcessor();

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
		/// Determines if the bibiography entry initialization file.
		/// </summary>
		[XmlAttribute("usebibentryinitialization")]
		public bool UseBibEntryInitialization { get => _useBibEntryInitialization; set => _useBibEntryInitialization = value; }

		/// <summary>
		/// The path to the bibiography entry initialization file.
		/// </summary>
		[XmlAttribute("bibentryinitializationfile")]
		public string BibEntryInitializationFile { get => _bibEntryInitializationFile; set => _bibEntryInitializationFile = value; }

		/// <summary>
		/// The path to the quality processor file.
		/// </summary>
		[XmlAttribute("qualityprocessorfile")]
		public string QualityProcessingFile { get => _qualityProcessingFile; set => _qualityProcessingFile = value; }

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
				if (_assessoryFiles != value)
				{
					_assessoryFiles	= value;
					this.Modified	= true;
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
		public WriteSettings WriteSettings { get => _writeSettings; set => _writeSettings = value; }

		/// <summary>
		/// The settings for writing the bibliography file.
		/// </summary>
		[XmlAttribute("autogenerateekeys")]
		public bool AutoGenerateKeys { get => _autoGenerateKeys; set => _autoGenerateKeys = value; }

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
		/// Clean a single entry.
		/// </summary>
		/// <param name="entry">BibEntry to clean.</param>
		public IEnumerable<Correction> CleanEntry(BibEntry entry)
		{
			if (_autoGenerateKeys)
			{
				_bibliography.AutoKeyEntry(entry);
			}

			foreach (Correction correction in _qualityProcessor.Process(entry))
			{
				yield return correction;
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
			_qualityProcessor = QualityProcessor.Deserialize(_qualityProcessingFile);
		}

		#endregion

	} // End class.
} // End namespace.