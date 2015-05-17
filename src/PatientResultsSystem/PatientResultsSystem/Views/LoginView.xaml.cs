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
using PatientResultsSystem.ViewModels;

namespace PatientResultsSystem.Views
{
	/// <summary>
	/// Interaction logic for LoginView.xaml
	/// </summary>
	public partial class LoginView : Window
	{
		public LoginView( )
		{
			InitializeComponent( );
		}

		private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
		{
			LoginViewModel viewModel = DataContext as LoginViewModel;
			viewModel.Password = PasswordBox.Password;
		}
	}
}
