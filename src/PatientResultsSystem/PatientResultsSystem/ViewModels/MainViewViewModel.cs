using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PatientResultsSystem.Models;
using PatientResultsSystem.Util;
using PatientResultsSystem.Views;

namespace PatientResultsSystem.ViewModels
{
	class MainViewViewModel : ViewModelBase
	{
		//
		// Private Fields
		//
		private ICollection<Patient> _patients;
		private Patient _selectedPatient;

		//
		// Properties
		//
		public ICollection<Patient> Patients
		{
			set
			{
				_patients = value;
				OnPropertyChanged("Patients");
			}
			get
			{
				if(_patients == null)
					_patients = new ObservableCollection<Patient>();

				return _patients;
			}
		}

		public Patient SelectedPatient
		{
			set
			{
				_selectedPatient = value;
				OnPropertyChanged("SelectedPatient");
			}
			get { return _selectedPatient; }
		}

		//
		// Constructor
		//
		public MainViewViewModel()
		{
			// Get patients from database
			Patients = PatientDatabaseHelper.GetPatientsHearingAids(PatientDatabaseHelper.GetPatients());
		}
        
		//
		// Command to show popup window with patient info
		//
		private ICommand _viewPatientInfoCommand;

		public ICommand ViewPatientInfoCommand
		{
			get
			{
				if (_viewPatientInfoCommand == null)
				{
					_viewPatientInfoCommand = new RelayCommand(arg =>
					{
						if (_selectedPatient != null)
						{
							PatientInfoWindow patientInfoWindow = new PatientInfoWindow(_selectedPatient);

							patientInfoWindow.ShowDialog();
						}
					},
					arg => _selectedPatient != null);
				}

				return _viewPatientInfoCommand;
			}
		}

		//
		// Command to allow clinician to view the report for the patient
		//
		private ICommand _viewReportCommand;

		public ICommand ViewReportCommand
		{
			get
			{
				if (_viewReportCommand == null)
				{
					_viewReportCommand = new RelayCommand (arg =>
					{
						if (_selectedPatient != null)
						{
							// Get main window
							MainWindow mainWindow = WindowHelper.FindWindow (typeof (MainWindow)) as MainWindow;

							if (mainWindow != null)
							{
								// Navigate to select questionnaire View
								ReportView reportView = mainWindow.TryFindResource ("ReportView")
									as ReportView;

								if (reportView != null)
								{
									if (reportView.DataContext != null)
									{
										ReportViewModel viewModel = reportView.DataContext as ReportViewModel;
										viewModel.Initialize(_selectedPatient);

										mainWindow.PageFrame.Navigate (reportView);
									}
								}
							}
						}
					},
					arg =>
					{
						if (_selectedPatient != null)
						{
							QuestionairreDatabaseHelper.InitializeDb();
							List<AnswerSet> answers = QuestionairreDatabaseHelper.GetAnswers(1, _selectedPatient.ID);
							if (answers.Count > 0)
							{
								return true;
							}
						}

						return false;
					});
				}

				return _viewReportCommand;
			}
		}

		//
		// Command to allow clinician to complete a questionnaire for the patient
		//
		private ICommand _completeQuestionnaireCommand;

		public ICommand CompleteQuestionnaireCommand
		{
			get
			{
				if (_completeQuestionnaireCommand == null)
				{
					_completeQuestionnaireCommand = new RelayCommand(arg =>
					{
						if (_selectedPatient != null)
						{
							// Get main window
							MainWindow mainWindow = WindowHelper.FindWindow (typeof (MainWindow)) as MainWindow;

							if (mainWindow != null)
							{
								// Navigate to select questionnaire View
								SelectQuestionnaireView selectQuestionnaireView = mainWindow.TryFindResource ("SelectQuestionnaireView")
									as SelectQuestionnaireView;

								if (selectQuestionnaireView != null)
								{
									if (selectQuestionnaireView.DataContext != null)
									{
										SelectQuestionnaireViewModel viewModel = selectQuestionnaireView.DataContext as SelectQuestionnaireViewModel;
										viewModel.ThisPatient = _selectedPatient;

										mainWindow.PageFrame.Navigate (selectQuestionnaireView);
									}
								}
							}
						}
					},
					arg => _selectedPatient != null);
				}

				return _completeQuestionnaireCommand;
			}
		}
	}
}
