using DigitalProduction.XML.Serialization;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BibtexManager
{
	/// <summary>
	/// A class for mapping BibEntry data.
	/// </summary>
	public class BibEntryMap
	{
		#region Fields

		private string											_name;
		private string											_toType;
		private List<string>									_fromTypes			= new List<string>();
		private SerializableDictionary<string, string>			_tagMaps			= new SerializableDictionary<string, string>();

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public BibEntryMap()
		{
		}

		#endregion

		#region Properties

		[XmlAttribute("name")]
		public string Name { get => _name; set => _name = value; }

		[XmlAttribute("totype")]
		public string ToType { get => _toType; set => _toType = value; }
		
		[XmlElement("tagmaps")]
		public SerializableDictionary<string, string> TagMaps { get => _tagMaps; set => _tagMaps = value; }

		#endregion

		#region Methods

		#endregion

	} // End class.
} // End namespace.