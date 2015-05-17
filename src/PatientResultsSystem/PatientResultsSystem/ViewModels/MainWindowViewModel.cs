using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PatientResultsSystem.Models;
using PatientResultsSystem.Util;
using PatientResultsSystem.Views;

namespace PatientResultsSystem.ViewModels
{
	class MainWindowViewModel : ViewModelBase
	{
		//
		// Private Fields
		//
		private User _currentUser;
		private ICollection<Patient> _userPatients; 

		//
		// Properties
		//
		public User CurrentUser
		{
			set
			{
				_currentUser = value; 
				OnPropertyChanged("CurrentUser");
			}
			get { return _currentUser; }
		}

		public ICollection<Patient> UserPatients
		{
			private set
			{
				_userPatients = value;
				OnPropertyChanged("UserPatients");
			}
			get
			{
				if(_userPatients == null)
					_userPatients = new ObservableCollection<Patient>();

				return _userPatients;
			}
		}

		//
		// Constructor
		//
		public MainWindowViewModel()
		{
			// Open the database file
			PatientDatabaseHelper.InitializeDb();
		}

		//
		// Add Patient navigation command
		//
		private ICommand _homeCommand;
		public ICommand HomeCommand
		{
			get
			{
				if (_homeCommand == null)
				{
					_homeCommand = new RelayCommand (arg =>
					{
						// Get main window
						MainWindow mainWindow = WindowHelper.FindWindow(typeof (MainWindow)) as MainWindow;

						if (mainWindow != null)
						{
							// Navigate to Add Patient View
							object mainView = mainWindow.TryFindResource ("MainView");

							if (mainView != null)
							{
								mainWindow.PageFrame.Navigate (mainView);
							}
						}
					},
					arg => true);
				}

				return _homeCommand;
			}
		}

		//
		// Add Patient navigation command
		//
		private ICommand _addPatientCommand;
		public ICommand AddPatientCommand
		{
			get
			{
				if (_addPatientCommand == null)
				{
					_addPatientCommand = new RelayCommand(arg =>
					{
						// Get main window
						MainWindow mainWindow = WindowHelper.FindWindow(typeof (MainWindow)) as MainWindow;

						if (mainWindow != null)
						{
							// Navigate to Add Patient View
							object addPatientView = mainWindow.TryFindResource("AddPatientView");

							if (addPatientView != null)
							{
								mainWindow.PageFrame.Navigate(addPatientView);
							}
						}
					},
					arg => true);
				}

				return _addPatientCommand;
			}
		}

		//
		// Add User navigation command
		//
		private ICommand _addUserCommand;
		public ICommand AddUserCommand
		{
			get
			{
				if (_addUserCommand == null)
				{
					_addUserCommand = new RelayCommand (arg =>
					{
						// Get main window
						MainWindow mainWindow = WindowHelper.FindWindow (typeof (MainWindow)) as MainWindow;

						if (mainWindow != null)
						{
							// Navigate to Add Patient View
							AddUserView addUserView = mainWindow.TryFindResource ("AddUserView") as AddUserView;

							if (addUserView != null)
							{
								mainWindow.PageFrame.Navigate (addUserView);
							}
						}
					},
					arg => true);
				}

				return _addUserCommand;
			}
		}

		//
		// Commmand to exit the app
		//
		private ICommand _exitCommand;

		public ICommand ExitCommand
		{
			get
			{
				if (_exitCommand == null)
				{
					_exitCommand = new RelayCommand(arg =>
					{
						Application.Current.Shutdown(Environment.ExitCode);
					},
					arg => true);
				}

				return _exitCommand;
			}
		}
	}
}
