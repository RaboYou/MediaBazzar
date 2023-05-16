using System;
using System.Windows.Forms;

namespace MediaBazaar
{
	public static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new LoginForm());
			SQLConPersonHandling con = new SQLConPersonHandling();
			Application.Run(new Bazaar(con.GetPerson("goddmi")));
		}
	}
}
