using BibTeXLibrary;
using DigitalProduction.Forms;
using DigitalProduction.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Data.SqlTypes;
using System.Text;

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
		private bool								_useRelativePaths				= true;
		private readonly Bibliography               _bibliography                   = new Bibliography();

		private List<string>						_assessoryFiles					= new List<string>();
		private List<BibliographyDOM>				_assessoryFilesDOMs				= new List<BibliographyDOM>();

		private bool								_useStringConstants				= true;
		private StringConstantProcessor				_stringConstantProcessor		= new StringConstantProcessor();

		private bool								_useBibEntryInitialization;
		private string								_bibEntryInitializationFile;
		private BibEntryInitialization				_bibEntryInitialization			= new BibEntryInitialization();

		private bool								_useTagQualityProcessing;
		private string								_tagQualityProcessingFile;
		private QualityProcessor					_tagQualityProcessor			= new QualityProcessor();

		private bool								_useNameRemapping				= false;
		private string								_nameRemappingFile;
		private string								_currentBibEntryMap				= "";
		private BibEntryRemapper					_nameRemapper					= new BibEntryRemapper();

		private WriteSettings						_writeSettings					= new WriteSettings();
		private bool								_autoGenerateKeys				= true;
		private bool								_copyCiteKeyOnEntryAdd			= true;
		private bool                                _sortBibliography				= true;
		private SortBy                              _bibliographySortMethod			= SortBy.Key;

		private static readonly HttpClient			_client							= new HttpClient();

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
		public string BibliographyFile
		{
			get
			{
				return _bibFile;
			}

			set
			{
				if (_bibFile != value)
				{
					_bibFile = value;
					this.Modified = true;
					if (this.Initialized)
					{
						ReadBibliographyFile();
						BuildStringConstantMap();
					}
				}
			}
		}

		/// <summary>
		/// Use paths relative to the bibliography file.
		/// </summary>
		[XmlAttribute("userelativepaths")]
		public bool UsePathsRelativeToBibFile
		{
			get
			{
				return _useRelativePaths;
			}

			set
			{
				if (_useRelativePaths != value)
				{
					_useRelativePaths = value;
					this.Modified = true;
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
					if (this.Initialized)
					{
						ReadAccessoryFiles();
						BuildStringConstantMap();
					}
				}
			}
		}

		/// <summary>
		/// Replace tag values with string constants.
		/// </summary>
		public bool UseStringConstants
		{
			get
			{
				return _useStringConstants;
			}

			set
			{
				if (!_useStringConstants == value)
				{
					_useStringConstants = value;
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
					if (this.Initialized)
					{
						ReadBibEntryInitializationFiles();
					}
				}
			}
		}

		/// <summary>
		/// BibEntryInitialization.
		/// </summary>
		[XmlIgnore()]
		public BibEntryInitialization BibEntryInitialization { get => _bibEntryInitialization; }

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
		public string TagQualityProcessingFile
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
					if (this.Initialized)
					{
						ReadTagQualityProcessingFile();
					}
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
					if (this.Initialized)
					{
						ReadNameMappingFile();
					}
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

		/// <summary>
		/// Copy the bibliography entry's cite key when the entry is added.
		/// </summary>
		[XmlAttribute("copycitekeyonadd")]
		public bool CopyCiteKeyOnEntryAdd
		{
			get
			{
				return _copyCiteKeyOnEntryAdd;
			}

			set
			{
				if (_copyCiteKeyOnEntryAdd != value)
				{
					_copyCiteKeyOnEntryAdd = value;
					this.Modified = true;
				}
			}
		}

		/// <summary>
		/// Sort the bibliography.
		/// </summary>
		[XmlAttribute("sortbibliography")]
		public bool SortBibliography
		{
			get
			{
				return _sortBibliography;
			}

			set
			{
				if (_sortBibliography != value)
				{
					_sortBibliography = value;
					this.Modified = true;
				}
			}
		}

		/// <summary>
		/// Method to sort the bibliography by.
		/// </summary>
		[XmlAttribute("bibliographysortmethod")]
		public SortBy BibliographySortMethod
		{
			get
			{
				return _bibliographySortMethod;
			}

			set
			{
				if (_bibliographySortMethod != value)
				{
					_bibliographySortMethod = value;
					this.Modified = true;
				}
			}
		}

		#endregion

		#region File Reading Methods

		/// <summary>
		/// Read the bibliography file.
		/// </summary>
		private void ReadBibliographyFile()
		{
			if (_useBibEntryInitialization)
			{
				string absolutePath = ConvertToAbsolutePath(_bibEntryInitializationFile);
				if (!System.IO.File.Exists(absolutePath))
				{
					throw new Exception("The file \"" + absolutePath +" does not exist.\"");
				}
				_bibliography.Read(_bibFile, absolutePath);
			}
			else
			{
				_bibliography.Read(_bibFile);
			}
		}

		/// <summary>
		/// Read the bibliography entry initialization file.
		/// </summary>
		private void ReadBibEntryInitializationFiles()
		{
			string absolutePath = ConvertToAbsolutePath(_bibEntryInitializationFile);
			if (!System.IO.File.Exists(absolutePath))
			{
				throw new Exception("The file \"" + absolutePath +" does not exist.\"");
			}
			_bibEntryInitialization = BibEntryInitialization.Deserialize(absolutePath);
		}

		/// <summary>
		/// Read tag quality processing file.
		/// </summary>
		private void ReadTagQualityProcessingFile()
		{
			string absolutePath = ConvertToAbsolutePath(_tagQualityProcessingFile);
			if (!System.IO.File.Exists(absolutePath))
			{
				throw new Exception("The file \"" + absolutePath +" does not exist.\"");
			}
			_tagQualityProcessor = QualityProcessor.Deserialize(absolutePath);
		}

		/// <summary>
		/// Read name mapping file.
		/// </summary>
		private void ReadNameMappingFile()
		{
			string absolutePath = ConvertToAbsolutePath(_nameRemappingFile);
			if (!System.IO.File.Exists(absolutePath))
			{
				throw new Exception("The file \"" + absolutePath +" does not exist.\"");
			}
			_nameRemapper = BibEntryRemapper.Deserialize(absolutePath);
		}

		/// <summary>
		/// Read assessory files.
		/// </summary>
		private void ReadAccessoryFiles()
		{
			foreach (string file in _assessoryFiles)
			{
				string absolutePath = ConvertToAbsolutePath(file);
				if (!System.IO.File.Exists(absolutePath))
				{
					throw new Exception("The file \"" + absolutePath +" does not exist.\"");
				}

				_assessoryFilesDOMs.Add(BibParser.Parse(absolutePath));
			}
		}

		/// <summary>
		/// Convert a path to absolute path if the relative path option is in use.
		/// </summary>
		/// <param name="path">Path to convert.</param>
		private string ConvertToAbsolutePath(string path)
		{
			if (this.UsePathsRelativeToBibFile)
			{
				path = DigitalProduction.IO.Path.ConvertToAbsolutePath(path, System.IO.Path.GetDirectoryName(_bibFile));
			}
			return path;
		}

		/// <summary>
		/// Build the string constants map.
		/// </summary>
		private void BuildStringConstantMap()
		{
			_stringConstantProcessor.Clear();
			_stringConstantProcessor.AddStringConstantsToMap(_bibliography.DocumentObjectModel);
			_stringConstantProcessor.AddStringConstantsToMap(_assessoryFilesDOMs);
		}

		#endregion

		#region Methods

		/// <summary>
		/// Get an array of all the names of the maps.
		/// </summary>
		public string[] GetBibEntryMapNames()
		{
			return _nameRemapper.Maps.Keys.ToArray();
		}

		/// <summary>
		/// Parse a string and return a single BibEntry.
		/// </summary>
		/// <param name="text">Text to process.</param>

		public BibEntry ParseSingleEntryText(string text)
		{
			BindingList<BibEntry> entries = ParseText(text);
			return entries[0];
		}

		/// <summary>
		/// Parse a string and return BibEntrys.
		/// </summary>
		/// <param name="text">Text to process.</param>
		public BindingList<BibEntry> ParseText(string text)
		{
			StringReader textReader = new StringReader(text);
			BibliographyDOM result;

			if (_useBibEntryInitialization)
			{
				result = BibParser.Parse(textReader, _bibEntryInitialization);
			}
			else
			{
				result = BibParser.Parse(textReader);
			}

			return result.BibliographyEntries;
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

		#region Quality and Automation Methods

		#region Entry Automation and Quality

		/// <summary>
		/// If the option for automatically generating keys is on, a key is generated for the entry.
		/// </summary>
		/// <param name="entry">BibEntry.</param>
		public void GenerateNewKey(BibEntry entry)
		{
			if (_autoGenerateKeys)
			{
				_bibliography.GenerateUniqueCiteKey(entry);
			}
		}

		/// <summary>
		/// If the option for automatically generating keys is on, a key is generated for the entry.
		/// </summary>
		/// <param name="entry">BibEntry.</param>
		public void ValidateKey(BibEntry entry)
		{
			if (_autoGenerateKeys)
			{
				if (!_bibliography.HasValidAutoCiteKey(entry))
				{
					_bibliography.GenerateUniqueCiteKey(entry);
				}
			}
		}

		/// <summary>
		/// Clean a single entry.
		/// </summary>
		/// <param name="entry">BibEntry.</param>
		public IEnumerable<TagProcessingData> CleanEntry(BibEntry entry)
		{
			if (_useTagQualityProcessing)
			{
				foreach (TagProcessingData tagProcessingData in _tagQualityProcessor.Process(entry))
				{
					yield return tagProcessingData;
				}
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
				_nameRemapper.RemapEntryNames(entry);
			}
		}

		/// <summary>
		/// Search for text that can be replaced with string constants.
		/// </summary>
		/// <param name="entry"></param>
		public void ApplyStringConstants(BibEntry entry)
		{
			if (_useStringConstants)
			{
				_stringConstantProcessor.ApplyStringConstants(entry);
			}
		}

		/// <summary>
		/// Get the location to re-insert and editted entry.
		/// </summary>
		/// <param name="entry">BibEntry.</param>
		/// <param name="proposedIndex">The current index of the BibEntry.</param>
		public int GetEntryInsertIndex(BibEntry entry, int proposedIndex)
		{
			if (_sortBibliography)
			{
				return _bibliography.DocumentObjectModel.FindInsertIndex(entry, _bibliographySortMethod);
			}
			else
			{
				return proposedIndex;
			}
		}

		/// <summary>
		/// Apply all cleaning to an entry.  Automatically accepts suggested changes.
		/// </summary>
		/// <param name="entry">BibEntry to clean.</param>
		public void ApplyAllCleaning(BibEntry entry)
		{
			// Mapping.
			RemapEntryNames(entry);

			// Cleaning.
			foreach (TagProcessingData tagProcessingData in CleanEntry(entry))
			{
				tagProcessingData.AcceptAll = true;
			}

			// String constants replacement.
			ApplyStringConstants(entry);

			// Key.
			GenerateNewKey(entry);
		}

		#endregion

		#region Entire Bibliography

		/// <summary>
		/// Sort the bibliography entries.
		/// </summary>
		public void SortBibliographyEntries()
		{
			if (_sortBibliography)
			{
				_bibliography.DocumentObjectModel.SortBibEntries(_bibliographySortMethod);
			}
		}

		/// <summary>
		/// Sort the bibliography entries.
		/// </summary>
		public IEnumerable<TagProcessingData> CleanAllEntries()
		{
			if (_useTagQualityProcessing)
			{
				bool modified = false;

				foreach (BibEntry entry in _bibliography.DocumentObjectModel.BibliographyEntries)
				{
					foreach (TagProcessingData tagProcessingData in _tagQualityProcessor.Process(entry))
					{
						if (tagProcessingData.Correction.ReplaceText)
						{
							modified = true;
						}
						yield return tagProcessingData;
					}
				}

				if (modified)
				{
					this.Modified = true;
				}
			}
		}

		#endregion

		#endregion

		#region Importing

		/// <summary>
		/// Bulk SPE paper search and import.
		/// </summary>
		/// <param name="path">The path to a file that contains a list of search strings.</param>
		public IEnumerable<BibEntry> BulkSpeImport(string path)
		{
			string[] lines			= File.ReadAllLines(path);
			List<string> references	= new List<string>();

			foreach (BibEntry bibtexEntry in BulkSpeImport(lines))
			{
				references.Add(bibtexEntry.Key);
				yield return bibtexEntry;
			}

			string outputPath = DigitalProduction.IO.Path.GetFullPathWithoutExtension(path) + "-output.csv";
			WriteCsvBulkImportResults(outputPath, references, lines);
		}

		/// <summary>
		/// Writes the names of the references and titles to a file.
		/// </summary>
		/// <param name="filePath">The path and file name to write to.</param>
		/// <param name="references">The reference names to write.</param>
		/// <param name="searchedTerms">The terms searched for references.</param>
		static void WriteCsvBulkImportResults(string filePath, List<string> references, string[] searchedTerms)
		{
			// Open or create the CSV file for writing.
			using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
			{
				// Write each row of data to the file.
				for (int i = 0; i < references.Count; i++)
				{
					writer.Write(references[i]);
					writer.Write(", ");
					string formatedTerm = "\"" + searchedTerms[i].Replace("\"", "\"\"") + "\"";
					writer.Write(formatedTerm);

					// End the row with a new line.
					writer.WriteLine();
				}
			}
		}

		/// <summary>
		/// Bulk SPE paper search and import.
		/// </summary>
		/// <param name="searchStrings">Strings to search the internet for the papers.</param>
		public IEnumerable<BibEntry> BulkSpeImport(string[] searchStrings)
		{
			foreach (string searchString in searchStrings)
			{
				string bibentryString	= SpeBibtexGet(searchString).Result;
				BibEntry bibEntry		= ParseSingleEntryText(bibentryString);
				ApplyAllCleaning(bibEntry);
				yield return bibEntry;
			}
		}

		/// <summary>
		/// Search for and download the Bibtex entry for an SPE paper.
		/// </summary>
		/// <param name="searchTerms">Terms to search the web for the paper.</param>
		async public Task<string> SpeBibtexGet(string searchTerms)
		{
			string website          = "onepetro.org";
			List<string> results    = DigitalProduction.Http.Search.GoogleSearchResults(searchTerms);

			foreach (string result in results)
			{
				if (result.Contains(website))
				{
					string				documentId		= result.Split('/').Last();
					HttpResponseMessage	response		= _client.GetAsync("https://onepetro.org/Citation/Download?resourceId="+documentId+"&resourceType=3&citationFormat=2").Result;
					HttpContent			content			= response.Content;
					string				responseString	= await content.ReadAsStringAsync();

					return DigitalProduction.Strings.Format.TrimStart(responseString, "\r\n");
				}
			}

			return string.Empty;
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
			string file = _bibFile;
			//file += ".output.bib";
			_bibliography.Write(file, _writeSettings);
			base.Serialize();
		}

		/// <summary>
		/// Initialize references.
		/// </summary>
		public override void DeserializationInitialization()
		{
			ReadBibEntryInitializationFiles();
			ReadTagQualityProcessingFile();
			ReadNameMappingFile();
			ReadBibliographyFile();
			ReadAccessoryFiles();
			BuildStringConstantMap();
		}

		#endregion

	} // End class.
} // End namespace.