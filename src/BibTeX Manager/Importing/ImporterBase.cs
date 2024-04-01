using BibTeXLibrary;
using BibtexManager.Project;
using DigitalProduction.XML.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibtexManager
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class ImporterBase
	{
		#region Fields

		protected static readonly HttpClient        _httpClient                         = new HttpClient();

		private bool                                _useBibEntryInitialization      = false;
		private BibEntryInitialization              _bibEntryInitialization         = new BibEntryInitialization();

		#endregion

		#region Construction

		/// <summary>	
		/// Default constructor.
		/// </summary>
		public ImporterBase()
		{
		}

		#endregion

		#region Properties

		protected HttpClient HttpClient { get => _httpClient; }

		#endregion

		#region Protected Methods

		/// <summary>
		/// Parse a string and return a single BibEntry.
		/// </summary>
		/// <param name="text">Text to process.</param>
		protected BibEntry ParseSingleEntryText(string text)
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

			return result.BibliographyEntries[0];
		}

		#endregion

		#region Interface Methods

		public void SetBibliographyInitialization(bool useBibEntryInitialization, BibEntryInitialization bibEntryInitialization)
		{
			_useBibEntryInitialization	= useBibEntryInitialization;
			_bibEntryInitialization     = bibEntryInitialization;
		}

		#endregion

	} // End class.
} // End namespace.