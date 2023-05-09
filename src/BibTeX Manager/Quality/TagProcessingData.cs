using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BibTeXManager.Quality
{
	/// <summary>
	/// Data used for processing by a single TagProcessor.
	/// </summary>
	public class TagProcessingData
	{
		#region Fields

		private bool			_acceptAll			= false;
		private Correction		_correction;

		#endregion

		#region Construction

		/// <summary>
		/// Default constructor.
		/// </summary>
		public TagProcessingData()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Accept all default replacements/corrections.
		/// </summary>
		public bool AcceptAll { get => _acceptAll; set => _acceptAll = value; }

		/// <summary>
		/// Correction.
		/// </summary>
		public Correction Correction { get => _correction; set => _correction = value; }

		#endregion

	} // End class.
} // End namespace.