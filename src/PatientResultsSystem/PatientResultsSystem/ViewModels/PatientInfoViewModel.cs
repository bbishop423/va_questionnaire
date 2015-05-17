using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PatientResultsSystem.Models;
using PatientResultsSystem.Util;
using PatientResultsSystem.Views;

namespace PatientResultsSystem.ViewModels
{
	class PatientInfoViewModel : ViewModelBase
	{
		//
		// Private Fields
		//
		private Patient _selectedPatient;

		private int _dobDay;
		private int _dobMonth;
		private int _dobYear;

		private int _testDateDay;
		private int _testDateMonth;
		private int _testDateYear;
		
		private string _leftEarMake;
		private string _leftEarModel;
		private string _leftEarSerial;
		private int _leftEarFitDay;
		private int _leftEarFitMonth;
		private int _leftEarFitYear;
		private StyleOfHearingAid _leftEarStyle;

		private string _rightEarMake;
		private string _rightEarModel;
		private string _rightEarSerial;
		private int _rightEarFitDay;
		private int _rightEarFitMonth;
		private int _rightEarFitYear;
		private StyleOfHearingAid _rightEarStyle;

		private bool _fieldsEnabled = false;

		//
		// Properties
		//
		public Patient SelectedPatient
		{
			set
			{
				_selectedPatient = value;
				OnPropertyChanged("SelectedPatient");
			}
			get { return _selectedPatient; }
		}

		public int DobDay
		{
			set
			{
				_dobDay = value;
				OnPropertyChanged("DobDay");
			}
			get { return _dobDay; }
		}

		public int DobMonth
		{
			set
			{
				_dobMonth = value;
				OnPropertyChanged ("DobMonth");
			}
			get { return _dobMonth; }
		}

		public int DobYear
		{
			set
			{
				_dobYear = value;
				OnPropertyChanged ("DobYear");
			}
			get { return _dobYear; }
		}

		public int TestDateDay
		{
			set
			{
				_testDateDay = value;
				OnPropertyChanged ("TestDateDay");
			}
			get { return _testDateDay; }
		}

		public int TestDateMonth
		{
			set
			{
				_testDateMonth = value;
				OnPropertyChanged ("TestDateMonth");
			}
			get { return _testDateMonth; }
		}

		public int TestDateYear
		{
			set
			{
				_testDateYear = value;
				OnPropertyChanged ("TestDateYear");
			}
			get { return _testDateYear; }
		}

		public string LeftEarMake
		{
			set
			{
				_leftEarMake = value;
				OnPropertyChanged("LeftEarMake");
			}
			get { return _leftEarMake; }
		}

		public string LeftEarModel
		{
			set
			{
				_leftEarModel = value;
				OnPropertyChanged ("LeftEarModel");
			}
			get { return _leftEarModel; }
		}

		public string LeftEarSerial
		{
			set
			{
				_leftEarSerial = value;
				OnPropertyChanged ("LeftEarSerial");
			}
			get { return _leftEarSerial; }
		}

		public int LeftEarFitDay
		{
			set
			{
				_leftEarFitDay = value;
				OnPropertyChanged("LeftEarFitDay");
			}
			get { return _leftEarFitDay; }
		}

		public int LeftEarFitMonth
		{
			set
			{
				_leftEarFitMonth = value;
				OnPropertyChanged ("LeftEarFitMonth");
			}
			get { return _leftEarFitMonth; }
		}

		public int LeftEarFitYear
		{
			set
			{
				_leftEarFitYear = value;
				OnPropertyChanged ("LeftEarFitYear");
			}
			get { return _leftEarFitYear; }
		}

		public StyleOfHearingAid LeftEarStyle
		{
			set
			{
				_leftEarStyle = value;
				OnPropertyChanged ("LeftEarStyle");
			}
			get { return _leftEarStyle; }
		}

		public string RightEarMake
		{
			set
			{
				_rightEarMake = value;
				OnPropertyChanged ("RightEarMake");
			}
			get { return _rightEarMake; }
		}

		public string RightEarModel
		{
			set
			{
				_rightEarModel = value;
				OnPropertyChanged ("RightEarModel");
			}
			get { return _rightEarModel; }
		}

		public string RightEarSerial
		{
			set
			{
				_rightEarSerial = value;
				OnPropertyChanged ("RightEarSerial");
			}
			get { return _rightEarSerial; }
		}

		public int RightEarFitDay
		{
			set
			{
				_rightEarFitDay = value; 
				OnPropertyChanged("RightEarFitDay");
			}
			get { return _rightEarFitDay; }
		}

		public int RightEarFitMonth
		{
			set
			{
				_rightEarFitMonth = value;
				OnPropertyChanged ("RightEarFitMonth");
			}
			get { return _rightEarFitMonth; }
		}

		public int RightEarFitYear
		{
			set
			{
				_rightEarFitYear = value;
				OnPropertyChanged ("RightEarFitYear");
			}
			get { return _rightEarFitYear; }
		}

		public StyleOfHearingAid RightEarStyle
		{
			set
			{
				_rightEarStyle = value;
				OnPropertyChanged ("RightEarStyle");
			}
			get { return _rightEarStyle; }
		}

		public IEnumerable<int> MonthSpan { get { return Enumerable.Range (1, 12); } }

		public IEnumerable<int> DaySpan { get { return Enumerable.Range (1, 31); } }

		public IEnumerable<int> YearSpan { get { return Enumerable.Range (1920, DateTime.Now.Year - 1920); } }

		public IEnumerable HearingAidStyles { get { return Enum.GetValues (typeof (StyleOfHearingAid)); } }

		public bool FieldsEnabled
		{
			get { return _fieldsEnabled; }
			set
			{
				_fieldsEnabled = value;
				OnPropertyChanged("FieldsEnabled");
			}
		}

		//
		// Consructor
		//
		public PatientInfoViewModel(Patient selectedPatient)
		{
			// Set selected patient
			SelectedPatient = selectedPatient;

			// Set private fields using passed patient
			_dobDay = _selectedPatient.DoB.Day;
			_dobMonth = _selectedPatient.DoB.Month;
			_dobYear = _selectedPatient.DoB.Year;

			_testDateDay = _selectedPatient.TestDate.Day;
			_testDateMonth = _selectedPatient.TestDate.Month;
			_testDateYear = _selectedPatient.TestDate.Year;

			_leftEarMake = _selectedPatient.LeftEar.Make;
			_leftEarModel = _selectedPatient.LeftEar.Model;
			_leftEarSerial = _selectedPatient.LeftEar.Serial;
			_leftEarFitDay = _selectedPatient.LeftEar.FitDate.Day;
			_leftEarFitMonth = _selectedPatient.LeftEar.FitDate.Month;
			_leftEarFitYear = _selectedPatient.LeftEar.FitDate.Year;
			_leftEarStyle = _selectedPatient.LeftEar.Style;

			_rightEarMake = _selectedPatient.RightEar.Make;
			_rightEarModel = _selectedPatient.RightEar.Model;
			_rightEarSerial = _selectedPatient.RightEar.Serial;
			_rightEarFitDay = _selectedPatient.RightEar.FitDate.Day;
			_rightEarFitMonth = _selectedPatient.RightEar.FitDate.Month;
			_rightEarFitYear = _selectedPatient.RightEar.FitDate.Year;
			_rightEarStyle = _selectedPatient.RightEar.Style;
		}

		//
		// Close command
		//
		private ICommand _closeCommand;

		public ICommand CloseCommand
		{
			get
			{
				if (_closeCommand == null)
				{
					_closeCommand = new RelayCommand(arg =>
					{
						Window thisWindow = WindowHelper.FindWindow(typeof (PatientInfoWindow));

						if (thisWindow != null)
						{
							thisWindow.DialogResult = false;
						}
					},
					arg => true);
				}

				return _closeCommand;
			}
		}

		//
		// Edit Patient command
		//
		private ICommand _editPatientCommand;

		public ICommand EditPatientCommand
		{
			get
			{
				if (_editPatientCommand == null)
				{
					_editPatientCommand = new RelayCommand(arg =>
					{
						// Enable all fields for editing patient info
						FieldsEnabled = true;
					},
					arg => true);
				}

				return _editPatientCommand;
			}
		}

		//
		// Command to save edited patient info
		//
		private ICommand _saveCommand;

		public ICommand SaveCommand
		{
			get
			{
				if (_saveCommand == null)
				{
					_saveCommand = new RelayCommand(arg =>
					{
						// Create datetimes from user input
						DateTime doB = new DateTime(_dobYear, _dobMonth, _dobDay);
						DateTime testDate = new DateTime(_testDateYear, _testDateMonth, _testDateDay);
						
						// Create hearing aids from user input
						HearingAid leftEar = new HearingAid(_leftEarMake, _leftEarModel, _leftEarSerial, 
							new DateTime(_leftEarFitYear, _leftEarFitMonth, _leftEarFitDay), _leftEarStyle, 'L');
						HearingAid rightEar = new HearingAid(_rightEarMake, _rightEarModel, _rightEarSerial, 
							new DateTime(_rightEarFitYear, _rightEarFitMonth, _rightEarFitDay), _rightEarStyle, 'R');

						// Update patient info that could not be bound to directly
						_selectedPatient.DoB = doB;
						_selectedPatient.TestDate = testDate;
						_selectedPatient.LeftEar = leftEar;
						_selectedPatient.RightEar = rightEar;

						// Call database method to update the passed patient's info
						PatientDatabaseHelper.UpdatePatient(_selectedPatient);

						// Display message box informing user that patient has been updated
						MessageBox.Show(string.Format("Patient '{0}, {1}' updated successfully", _selectedPatient.LastName, _selectedPatient.FirstName),
							"Patient Updated", MessageBoxButton.OK, MessageBoxImage.Information);

						// Re-disable fields in patient info window
						FieldsEnabled = false;

						// Refresh patient list in main view
						MainWindow mainWindow = WindowHelper.FindWindow (typeof (MainWindow)) as MainWindow;

						if (mainWindow != null)
						{
							MainView mainView = mainWindow.TryFindResource ("MainView") as MainView;

							// Navigate back to main view
							if (mainView != null)
							{
								if (mainView.DataContext != null)
								{
									MainViewViewModel viewModel = mainView.DataContext as MainViewViewModel;
									viewModel.Patients = PatientDatabaseHelper.GetPatients ( );
								}
							}
						}
					},
					arg => true);
				}

				return _saveCommand;
			}
		}
	}
}
