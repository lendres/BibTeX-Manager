using DigitalProduction.Forms;
using DigitalProduction.Registry;

namespace BibtexManager
{
	/// <summary>
	/// Windows registry access.
	/// </summary>
	public class RegistryAccess : FormWinRegistryAccess
    {
		#region Construction

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="owner">Owner of this registry access.</param>
		public RegistryAccess(DigitalProductionForm owner) :
            base(owner)
		{
            this.Install += this.OnInstall;
        }

        #endregion

        #region Installation

        /// <summary>
        /// Installation routine, mainly used for debugging.
        /// </summary>
        public void OnInstall()
        {
        }

        #endregion 

        #region Registry Key Access


        #endregion

        #region Properties

		/// <summary>
		/// Load last project as start up.
		/// </summary>
		public bool LoadLastProjectAtStartUp
		{
			get
			{
				return GetValue(OptionsKey(), "Load Last Project At Start Up", true);
			}

			set
			{
				SetValue(OptionsKey(), "Load Last Project At Start Up", value);
			}
		}

		/// <summary>
		/// Google search endige cx identifier.
		/// </summary>
		public string CustomSearchEngineIdentifier
		{
			get
			{
				return GetValue(OptionsKey(), "Custom Search Engine Identifier", "");
			}

			set
			{
				SetValue(OptionsKey(), "Custom Search Engine Identifier", value);
			}
		}

		/// <summary>
		/// Google search engine API key.
		/// </summary>
		public string SearchEngineApiKey
		{
			get
			{
				return GetValue(OptionsKey(), "Search Engine Api Key", "");
			}

			set
			{
				SetValue(OptionsKey(), "Search Engine Api Key", value);
			}
		}

		#endregion

	} // End class.
} // End namespace.