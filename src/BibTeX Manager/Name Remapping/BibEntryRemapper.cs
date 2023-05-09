using BibTeXLibrary;
using DigitalProduction.XML.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibTeXManager
{
	/// <summary>
	/// 
	/// </summary>
	[XmlRoot("bibentryremap")]
	public class BibEntryRemapper
	{
		#region Fields

		private SerializableDictionary<string, BibEntryMap>		_maps		= new SerializableDictionary<string, BibEntryMap>();

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public BibEntryRemapper()
		{
		}

		#endregion

		#region Properties

		[XmlElement("maps")]
		public SerializableDictionary<string, BibEntryMap> Maps { get => _maps; set => _maps = value; }
		
		#endregion

		#region Methods

		public void RemapEntryNames(BibEntry entry, string mapName)
		{
			BibEntryMap map = _maps[mapName];

			// Check the Type of the bibliography entry.  I.e., this allows mapping
			// of "@proceedings" to "@inproceedings".
			if (map.FromTypes.Contains(entry.Type))
			{
				entry.Type = map.ToType;
			}

			List<string> tagNames = entry.TagNames;

			foreach (KeyValuePair<string, string> tagMap in map.TagMaps)
			{
				if (tagNames.Contains(tagMap.Key))
				{
					entry.RenameTagKey(tagMap.Key, tagMap.Value);
				}
			}
		}

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
			SerializationSettings settings = new SerializationSettings(this, path);
			settings.XmlSettings.NewLineOnAttributes = false;
			Serialization.SerializeObject(settings);
		}

		/// <summary>
		/// Create an instance from a file.
		/// </summary>
		/// <param name="path">The file to read from.</param>
		public static BibEntryRemapper Deserialize(string path)
		{
			return Serialization.DeserializeObject<BibEntryRemapper>(path);
		}

		#endregion

	} // End class.
} // End namespace.