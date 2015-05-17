using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PatientResultsSystem.Models;
using PatientResultsSystem.ViewModels;

namespace PatientResultsSystem.Views
{
	/// <summary>
	/// Interaction logic for PatientInfoWindow.xaml
	/// </summary>
	public partial class PatientInfoWindow : Window
	{
		private Patient _selectedPatient;

		//
		// Patient selected from datagrid
		//
		public PatientInfoWindow (Patient selectedPatient)
		{
			_selectedPatient = selectedPatient;
			DataContext = new PatientInfoViewModel(selectedPatient);			
			InitializeComponent ( );
		}

		//
		// Window loaded event handler sets title and selected patient
		//
		private void OnLoaded(object sender, EventArgs e)
		{
			if (_selectedPatient != null)
			{
				Title += string.Format("{0}, {1} {2}",
					_selectedPatient.LastName, _selectedPatient.FirstName, _selectedPatient.MiddleInitial);
			}
		}
	}
}
