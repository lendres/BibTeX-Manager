using BibTeXLibrary;
using DigitalProduction.XML.Serialization;
using System;
using System.Xml.Serialization;

namespace BibtexManager.Project
{
	/// <summary>
	/// 
	/// </summary>
	[XmlRoot("ImportResult")]
	public class ImportResult
	{
		#region Fields

		private ResultType		_resultType					= ResultType.NotAttempted;
		private BibEntry		_bibEntry                   = null;
		private string			_message					= string.Empty;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ImportResult(ResultType resultType, BibEntry bibEntry, string message)
		{
			_resultType		= resultType;
			_bibEntry		= bibEntry;
			_message		= message;
		}

		#endregion

		#region Properties

		/// <summary>
		/// The result type.
		/// </summary>
		public ResultType Result { get => _resultType; set => _resultType=value; }

		/// <summary>
		/// The BibEntry.
		/// </summary>
		public BibEntry BibEntry { get => _bibEntry; set => _bibEntry=value; }

		/// <summary>
		/// A message, if one is supplied.
		/// </summary>
		public string Message { get => _message; set => _message=value; }

		#endregion

		#region Methods

		#endregion

		#region XML

		/// <summary>
		/// Write this object to a file to the provided path.
		/// </summary>
		/// <param name="path">Path (full path and filename) to write to.</param>
		/// <exception cref="InvalidOperationException">Thrown when the projects path is not valid.</exception>
		public void Serialize(string path)
		{
			if (!DigitalProduction.IO.Path.PathIsWritable(path))
			{
				throw new InvalidOperationException("The file cannot be saved.  A valid path must be specified.");
			}

			Serialization.SerializeObject(this, path);
		}

		/// <summary>
		/// Create an instance from a file.
		/// </summary>
		/// <param name="path">The file to read from.</param>
		public static ImportResult Deserialize(string path)
		{
			return Serialization.DeserializeObject<ImportResult>(path);
		}

		#endregion

	} // End class.
} // End namespace.