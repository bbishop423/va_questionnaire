using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PatientResultsSystem.Models;
using PatientResultsSystem.Util;
using PatientResultsSystem.Views;

namespace PatientResultsSystem.ViewModels
{
	class AddPatientViewModel : ViewModelBase
	{
		//
		// Private Fields
		//
		private string _firstName;
		private string _lastName;
		private char _middleInitial;
		private string _id;
		private DateTime _dateOfBirth;
		private DateTime _testDate;
		private string _leftEarMake;
		private string _leftEarModel;
		private string _leftEarSerial;
		private DateTime _leftEarFitDate;
        private StyleOfHearingAid _leftEarStyle;
		private string _rightEarMake;
		private string _rightEarModel;
		private string _rightEarSerial;
        private StyleOfHearingAid _rightEarStyle;
		private DateTime _rightEarFitDate;
		private string _comments;
        private string _providerName;
        private string _clinicianID;

		//
		// Properties
		//
        public string ProviderName { set { _providerName = value; } }

        public string ClinicianID { set { _clinicianID = value; } }

		public string FirstName { set { _firstName = value; } }

		public string LastName { set { _lastName = value; } }

		public string MiddleInitial
		{
			set
			{	
				if(!string.IsNullOrEmpty(value))
					_middleInitial = value[0];
			}
		}

		public string Id { set { _id = value; } }

		public DateTime DateOfBirth { set { _dateOfBirth = value; } }

		public DateTime TestDate { set { _testDate = value; } }

		public string LeftEarMake { set { _leftEarMake = value; } }

		public string LeftEarModel { set { _leftEarModel = value; } }

		public string LeftEarSerial { set { _leftEarSerial = value; } }

		public DateTime LeftEarFitDate { set { _leftEarFitDate = value; } }

        public StyleOfHearingAid LeftEarStyle { set { _leftEarStyle = value; } }

        public StyleOfHearingAid RightEarStyle { set { _rightEarStyle = value; } }

		public string RightEarMake { set { _rightEarMake = value; } }

		public string RightEarModel { set { _rightEarModel = value; } }

		public string RightEarSerial { set { _rightEarSerial = value; } }

		public DateTime RightEarFitDate { set { _rightEarFitDate = value; } }

		public string Comments { set { _comments = value; } }

		public IEnumerable<int> MonthSpan { get { return Enumerable.Range (1, 12); } }

		public IEnumerable<int> DaySpan { get { return Enumerable.Range(1, 31); } } 

		public IEnumerable<int> YearSpan { get { return Enumerable.Range(1920, DateTime.Now.Year - 1920); } }

		public IEnumerable HearingAidStyles { get { return Enum.GetValues(typeof (StyleOfHearingAid)); } }

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
		// Add Patient command
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
                        
                        
                        // Create hearing aid structs
						HearingAid leftEar = new HearingAid(_leftEarMake, _leftEarModel, _leftEarSerial, _leftEarFitDate, _leftEarStyle, 'L');
						HearingAid rightEar = new HearingAid(_rightEarMake, _rightEarModel, _rightEarSerial, _rightEarFitDate, _rightEarStyle, 'R');

						// Create patient from user input
						Patient newPatient = new Patient(_firstName, _lastName, _middleInitial, _id, _testDate, _dateOfBirth, 
							_comments, leftEar, rightEar, _providerName, _clinicianID);

						//
						// ********* ADD PATIENT TO DATABASE **************
						//
						PatientDatabaseHelper.AddPatient(newPatient);

						// Display message box notifying user of success
						MessageBox.Show("Patient '" + _lastName + ", " + _firstName + "' added successfully.", "Success",
							MessageBoxButton.OK, MessageBoxImage.Information);

						// Get main window and main view handles
						MainWindow mainWindow = WindowHelper.FindWindow(typeof (MainWindow)) as MainWindow;

						if (mainWindow != null)
						{
							MainView mainView = mainWindow.TryFindResource("MainView") as MainView;

							// Navigate back to main view
							if (mainView != null)
							{
								if (mainView.DataContext != null)
								{
									MainViewViewModel viewModel = mainView.DataContext as MainViewViewModel;
									viewModel.Patients = PatientDatabaseHelper.GetPatientsHearingAids (PatientDatabaseHelper.GetPatients ( ));
								}

								mainWindow.PageFrame.Navigate(mainView);
							}
						}
					},
					arg =>
					{
						return (_firstName != null) && (_lastName != null) && (_middleInitial != null) && (_id != null)
						       && (_dateOfBirth != null) && (_testDate != null) && (_leftEarMake != null) && (_leftEarModel != null)
						       && (_leftEarSerial != null) && (_leftEarFitDate != null) && (_rightEarMake != null) 
						       && (_rightEarModel != null) && (_rightEarSerial != null) && (_rightEarFitDate != null);
					});
				}

				return _addPatientCommand;
			}
		}
	}
}
