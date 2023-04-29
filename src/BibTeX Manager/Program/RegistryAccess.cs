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

		#endregion

	} // End class.
} // End namespace.