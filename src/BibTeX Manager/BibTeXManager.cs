using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using DigitalProduction.Forms;
using DigitalProduction.IO;

namespace DigitalProduction.LineCounter
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class BibTeXManager : DPMForm
	{
        #region Members


		#endregion

		#region Construction / Timer

		public BibTeXManager() :
			base("DPM", "Line Counter")
		{
			InitializeComponent();

			// Registry access has to be created in constructor and done before setting controls.
			Program.Registry = new RegistryAccess(this);

			// Registry access has to be created in constructor and done before setting controls.
			Program.Registry = new RegistryAccess(this);

			// Allows for the installation event to occur.  Largely useful for debugging or resetting the software if the
			// registry gets messed up.
			Program.Registry.RaiseInstallEvent();

			InitializeFromRegistry();


			#region Status Bar

			this.statusBar						= new DigitalProduction.Forms.StatusBarWithProgress();
			this.statusBarPanel1				= new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel2				= new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanel3				= new System.Windows.Forms.StatusBarPanel();

			this.statusBar.Location				= new System.Drawing.Point(0, 488);
			this.statusBar.Name					= "Status Bar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {this.statusBarPanel1,
																					  this.statusBarPanel3,
																					  this.statusBarPanel2});
			this.statusBar.SetProgressBarPanel	= 1;
			this.statusBar.ShowPanels			= true;
			this.statusBar.Size					= new System.Drawing.Size(492, 22);
			this.statusBar.TabStop				= false;
			
			this.statusBarPanel1.AutoSize		= System.Windows.Forms.StatusBarPanelAutoSize.None;
			this.statusBarPanel1.MinWidth		= 80;
			this.statusBarPanel1.Text			= "Ready.";
			this.statusBarPanel1.Width			= 100;

			this.statusBarPanel3.AutoSize		= System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanel3.Style			= System.Windows.Forms.StatusBarPanelStyle.OwnerDraw;
			this.statusBarPanel3.Width			= 188;

			this.statusBar.ProgressBar.Visible	= false;
			this.statusBar.ProgressBar.Step		= 1;
			this.statusBar.ProgressBar.Minimum	= 0;

			this.statusBarPanel2.Text			= System.DateTime.Now.ToLongTimeString();
			this.tmrClock.Interval				= 1000;
			this.tmrClock.Enabled				= true;
			this.tmrClock.Tick					+= new EventHandler(tmrClock_Tick);

			this.Controls.Add(this.statusBar);

			#endregion
		}

		/// <summary>
		/// Updates the clock on the status bar.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void tmrClock_Tick(object sender, EventArgs e)
		{
			this.statusBarPanel2.Text = System.DateTime.Now.ToLongTimeString();
		}

		#endregion

		#region Get Files

		#region Event Handler

		/// <summary>
		/// Get files to count the lines of.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void btnGetFiles_Click(object sender, System.EventArgs e)
		{

		}

		#endregion

		#endregion

		#region Menu Event Handlers

		/// <summary>
		/// Close the application.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Show help.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void mnuHelp_Click(object sender, System.EventArgs e)
		{
			Help.ShowHelp(this, "Help\\Line Counter.chm");
		}

		#endregion

		#region Count

		#endregion

		#region Helper Functions

		/// <summary>
		/// Initializes the controls from the stored settings.
		/// </summary>
		private void InitializeFromRegistry()
		{
			//this.textBoxInputFile.Text = Program.Registry.InputFile;
			//this.textBoxXsltFile.Text = Program.Registry.XsltFile;
			//this.textBoxXsltArguments.Text = Program.Registry.XsltArguments;
			//this.textBoxOutputFile.Text = Program.Registry.OutputFile;
			//this.checkBoxPostProcessor.Checked = Program.Registry.RunPostProcessor;
			//this.textBoxPostProcessor.Text = Program.Registry.PostProcessorFile;
		}

		#endregion

		#region Events

		/// Open the report when the link is clicked.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		private void lnkReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//System.Diagnostics.Process.Start(_logFile);
		}

		#endregion

	} // End class.
} // End namespace.