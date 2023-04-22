using DigitalProduction.Forms;
using DigitalProduction.Registry;

namespace DigitalProduction.LineCounter
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
		public RegistryAccess(DPMForm owner) :
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
            this.LastPathUsed			= "";
            this.LastCommentingStyle	= "All Types.xml";
        }

        #endregion 

        #region Registry Key Access


        #endregion

        #region Properties

        /// <summary>
        /// Comment mode.
        /// </summary>
        public CommentMode CommentMode
		{
			get
			{
				return (CommentMode)GetValue(AppKey(), "Comment Mode", (int)CommentMode.FileExtension);
			}

			set
			{
				SetValue(AppKey(), "Comment Mode", (int)value);
			}
		}

		/// <summary>
		/// The path (location) that the last set of files was openned from.
		/// </summary>
		public string LastPathUsed
		{
			get
			{
				return GetValue(AppKey(), "Last Path Used", "");
			}

			set
			{
				SetValue(AppKey(), "Last Path Used", value);
			}
		}

		/// <summary>
		/// The commenting style configuration file used.
		/// </summary>
		public string LastCommentingStyle
		{
			get
			{
				return GetValue(AppKey(), "Last Commenting Style", "All Types.xml");
			}

			set
			{
				SetValue(AppKey(), "Last Commenting Style", value);
			}
		}

		/// <summary>
		/// The last filter string selected in the file select dialog box.
		/// </summary>
		public int LastSelectedFilterString
		{
			get
			{
				return GetValue(AppKey(), "Last Selected Filter String", 1);
			}

			set
			{
				SetValue(AppKey(), "Last Selected Filter String", value);
			}
		}

		#endregion

	} // End class.
} // End namespace.