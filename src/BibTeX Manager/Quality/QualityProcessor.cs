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
	[XmlRoot("qualityprocessor")]
	public class QualityProcessor
	{
		#region Fields

		private BindingList<TagProcessor>				_tagProcessors			= new BindingList<TagProcessor>();

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public QualityProcessor()
		{
		}

		#endregion

		#region Properties

		[XmlArray("tagprocessors"), XmlArrayItem("tagprocessor")]
		public BindingList<TagProcessor> TagProcessors { get => _tagProcessors; set => _tagProcessors = value; }

		#endregion

		#region Methods

		public IEnumerable<Correction> Process(BibEntry entry)
		{
			foreach (TagProcessor processor in _tagProcessors)
			{
				foreach (Correction correction in processor.Corrections(entry))
				{
					yield return correction;
				}
			}
		}

	#endregion

	#region XML

	/// <summary>
	/// Create an instance from a file.
	/// </summary>
	/// <param name="path">The file to read from.</param>
	public static QualityProcessor Deserialize(string path)
		{
			return Serialization.DeserializeObject<QualityProcessor>(path);
		}

		#endregion

	} // End class.
} // End namespace.