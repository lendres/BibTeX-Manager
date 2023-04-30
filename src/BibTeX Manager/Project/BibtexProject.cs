using BibTeXLibrary;
using DigitalProduction.Projects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
		private readonly Bibliography				_bibliography		= new Bibliography();
		private WriteSettings						_writeSettings		= new WriteSettings();

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
		/// Bibliography.
		/// </summary>
		[XmlIgnore()]
		public Bibliography Bibliography
		{
			get
			{
				return _bibliography;
			}
		}

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
				_writeSettings = value;
			}
		}

		#endregion

		#region Methods

		public void ReadBibFile()
		{
			_bibliography.Read(_bibFile);
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
		}

		#endregion

	} // End class.
} // End namespace.