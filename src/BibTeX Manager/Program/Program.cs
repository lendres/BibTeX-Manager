using System;
using System.Windows.Forms;

namespace BibtexManager
{
	/// <summary>
	/// Main program entry.
	/// </summary>
	static class Program
	{
		#region Fields

		/// <summary>
		/// Access to the registry settings.  Since there is only one registry, this is static.  It also is convenient to allow access to the registry
		/// from things like the Options dialog box.
		/// </summary>
		private static RegistryAccess _registry = null;

		#endregion
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BibtexManagerForm());
		}

		#region Properties

		/// <summary>
		/// Registry access.
		/// </summary>
		public static RegistryAccess Registry
		{
			get
			{
				System.Diagnostics.Debug.Assert(_registry != null, "The registry has not been set.");
				return _registry;
			}

			set
			{
				_registry = value;
			}
		}

		/// <summary>
		/// Contact person's email.  Used for reporting bugs, getting licenses, et cetera.
		/// </summary>
		public static string ContactEmail
		{
			get
			{
				return "lendres@fifthrace.com";
			}
		}

		#endregion

	} // End class.
} // End namespace.