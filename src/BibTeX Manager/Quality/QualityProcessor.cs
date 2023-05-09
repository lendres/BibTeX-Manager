using BibTeXLibrary;
using BibTeXManager.Quality;
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

		/// <summary>
		/// Process a BibEntry and correct errors.
		/// </summary>
		/// <param name="entry">BibEntry to process and clean.</param>
		public IEnumerable<TagProcessingData> Process(BibEntry entry)
		{
			foreach (TagProcessor processor in _tagProcessors)
			{
				TagProcessingData tagProcessingData = new TagProcessingData();
				foreach (Correction correction in processor.Corrections(entry))
				{
					tagProcessingData.Correction = correction;
					if (tagProcessingData.AcceptAll)
					{
						correction.ReplaceText = true;
					}
					else
					{
						yield return tagProcessingData;
					}
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