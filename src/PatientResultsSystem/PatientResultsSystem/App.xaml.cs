using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PatientResultsSystem.Views;

namespace PatientResultsSystem
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void OnStartup(object sender, StartupEventArgs e)
		{
			LoginWindow loginView = new LoginWindow();

			if (!loginView.ShowDialog().Value)
			{
				Shutdown(Environment.ExitCode);
			}
		}
	}
}
