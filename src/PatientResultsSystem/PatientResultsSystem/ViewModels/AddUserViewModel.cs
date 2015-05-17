using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PatientResultsSystem.Models;
using PatientResultsSystem.Util;

namespace PatientResultsSystem.ViewModels
{
    class AddUserViewModel
    {
        // Private Fields
        private string _username;
        private string _password;
        private string _firstName;
        private string _lastName;
        private UserTypes _type;    // Type of user (Clinician, Administrator)
        private bool _exists;       // if username exists in database

        public string UserName { set { _username = value; } }
        public string Password { set { _password = value; } }
        public string FirstName { set { _firstName = value; } }
        public string LastName { set { _lastName = value; } }
        public UserTypes Type { set { _type = value; } }
		public IEnumerable UserTypes { get { return Enum.GetValues (typeof (UserTypes)); } }

        //
		// Cancel command
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
						// Get main window
						MainWindow mainWindow = WindowHelper.FindWindow(typeof (MainWindow)) as MainWindow;

						if (mainWindow != null)
						{
							// Get main window and main view handles
							object mainView = mainWindow.TryFindResource("MainView");

							// Navigate back to main view
							if (mainView != null)
							{
								mainWindow.PageFrame.Navigate(mainView);
							}
						}
					},
					arg => true
					);
				}

				return _cancelCommand;
			}
		}

		//
		// Add User command
		//
		private ICommand _addUserCommand;
        public ICommand AddUserCommand
        {
            get
            {
                if (_addUserCommand == null)
                {
                    _addUserCommand = new RelayCommand ( arg =>
                    {


                        //Create User
                        User newUser = new User ( _username, _type, _firstName, _lastName );

                        //
                        // ********* ADD User TO DATABASE **************
                        //
                        if (UserDatabaseHelper.AddUser ( newUser, _password ))
                        {
                            // Display message box notifying user of success
                            MessageBox.Show ( "User '" + _username + "' added successfully.", "Success",
                                MessageBoxButton.OK, MessageBoxImage.Information );
                            _exists = false;
                        }
                        else if(!UserDatabaseHelper.CheckUserNames(_username))
                        {
                            // Display message box notifying user that username already exists
                            MessageBox.Show ( "A user with that username already exists!", "Invalid Username",
                                MessageBoxButton.OK, MessageBoxImage.Information );
                            _exists = true;
                        }
                        else
                        {
                            // Display message box notifying user of unknown error
                            MessageBox.Show ( "Uknown error adding user", "Error",
                                MessageBoxButton.OK, MessageBoxImage.Information );
                            _exists = false;
                        }                        

                        // if successful add or unknown error, go back to main view
                        if (!_exists)
                        {
                            // Get main window and main view handles
                            MainWindow mainWindow = WindowHelper.FindWindow ( typeof ( MainWindow ) ) as MainWindow;

                            if (mainWindow != null)
                            {
                                object mainView = mainWindow.TryFindResource ( "MainView" );

                                // Navigate back to main view
                                if (mainView != null)
                                {
                                    mainWindow.PageFrame.Navigate ( mainView );
                                }
                            } 
                        }
                    },
                    arg =>
                    {
                        return (_firstName != null) && (_lastName != null) && (_username != null) && (_password != null)
                               && (_type != null);
                    } );
                }

                return _addUserCommand;
            }
        }
    }
}
