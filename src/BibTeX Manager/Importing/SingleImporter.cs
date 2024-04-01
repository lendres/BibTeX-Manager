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
	public abstract class SingleImporter : ImporterBase, ISingleImporter
	{
		#region Fields

		#endregion

		#region Construction

		/// <summary>	
		/// Default constructor.
		/// </summary>
		public SingleImporter()
		{
		}

		#endregion

		#region Properties

		#endregion

		#region Protected Methods

		#endregion

		#region Interface Methods

		/// <summary>
		/// Import a single entry from a search string.
		/// </summary>
		/// <param name="searchString">String containing search terms.</param>
		public abstract BibEntry Import(string searchString);

		#endregion

	} // End class.
} // End namespace.