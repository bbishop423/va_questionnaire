using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PatientResultsSystem.Models;
using PatientResultsSystem.Util;
using PatientResultsSystem.Views;

namespace PatientResultsSystem.ViewModels
{
	class SelectQuestionnaireViewModel : ViewModelBase
	{
		//
		// Private fields
		//
		private Patient _thisPatient;

		//
		// Properties
		//
		public Patient ThisPatient { set { _thisPatient = value; } }

		//
		// Command to switch the whichever questionnaire was selected
		//
		private ICommand _switchQuestionnaireCommand;

		public ICommand SwitchQuestionnaireCommand
		{
			get
			{
				if (_switchQuestionnaireCommand == null)
				{
					_switchQuestionnaireCommand = new RelayCommand(arg =>
					{
						// Get main window
						MainWindow mainWindow = WindowHelper.FindWindow (typeof (MainWindow)) as MainWindow;

						if ((arg as string) == "Patient")
						{
							if (mainWindow != null)
							{
								// Navigate to Patient Questionnaire View
								PatientQuestionnaireView patientQuestionnaireView = mainWindow.TryFindResource ("PatientQuestionnaireView")
									as PatientQuestionnaireView;

								if (patientQuestionnaireView != null)
								{
									if (patientQuestionnaireView.DataContext != null)
									{
										QuestionnaireViewModel viewModel = patientQuestionnaireView.DataContext as QuestionnaireViewModel;
										viewModel.ThisPatient = _thisPatient;

										mainWindow.PageFrame.Navigate (patientQuestionnaireView);
									}
								}
							}
						}

						if ((arg as string) == "Clinician")
						{
							if (mainWindow != null)
							{
								// Navigate to Clinician Questionnaire View
								ClinicianQuestionnaireView clinicianQuestionnaireView = mainWindow.TryFindResource ("ClinicianQuestionnaireView")
									as ClinicianQuestionnaireView;

								if (clinicianQuestionnaireView != null)
								{
									if (clinicianQuestionnaireView.DataContext != null)
									{
										QuestionnaireViewModel viewModel = clinicianQuestionnaireView.DataContext as QuestionnaireViewModel;
										viewModel.ThisPatient = _thisPatient;

										mainWindow.PageFrame.Navigate (clinicianQuestionnaireView);
									}
								}
							}
						}
					},
					arg => true);
				}

				return _switchQuestionnaireCommand;
			}
		}
	}
}
