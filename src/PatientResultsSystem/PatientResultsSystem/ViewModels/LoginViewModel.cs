using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;
using PatientResultsSystem.Models;
using PatientResultsSystem.Util;
using PatientResultsSystem.Views;

namespace PatientResultsSystem.ViewModels
{
	internal class LoginViewModel : ViewModelBase
	{
		//
		// Private Fields
		//
		private string _userName;
		private string _password;
		private string _errorMessage;

		//
		// Properties
		//
		public string UserName
		{
			get
			{
				if (_userName == null)
					return string.Empty;

				return _userName;
			}
			set
			{
				_userName = value;
				OnPropertyChanged("UserName");
			}
		}

		public string Password
		{
			set { _password = value; }
		}

		public string ErrorMessage
		{
			get
			{
				if (_errorMessage == null)
					return string.Empty;

				return _errorMessage;
			}
			private set
			{
				_errorMessage = value;
				OnPropertyChanged("ErrorMessage");
			}
		}

		//
		// Commands
		//
		private ICommand _cancelCommand;

		public ICommand CancelCommand
		{
			get
			{
				if (_cancelCommand == null)
				{
					_cancelCommand = new RelayCommand(arg =>
					{
						Application.Current.Shutdown(Environment.ExitCode);
					},
						arg => true
						);
				}

				return _cancelCommand;
			}
		}

		private ICommand _logInCommand;

		public ICommand LogInCommand
		{
			get
			{
				if (_logInCommand == null)
				{
					_logInCommand = new RelayCommand(arg =>
					{
						// Use credentials to find user in database
						try
						{
							UserDatabaseHelper.InitializeDb();
						}
						catch (SQLiteException e)
						{
							MessageBox.Show("Error: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						}
						
						User user = UserDatabaseHelper.FindUser(_userName, _password);
						if (user != null)
						{
							// If user is found, set DialogResult to true to close login window
							Window loginWindow = WindowHelper.FindWindow(typeof (LoginWindow));
							if (loginWindow != null)
							{
								MainWindow mainWindow = new MainWindow(user);
								loginWindow.DialogResult = true;
								mainWindow.Show( );
							}
						}
						else
						{
							// If user is not found, set error message
							ErrorMessage = "Incorrect user name / password";
						}
					},
					arg =>
					{
						if ((_userName != null) && (_password != null))
							return true;

						return false;
					});
				}

				return _logInCommand;
			}
		}
	}
}
