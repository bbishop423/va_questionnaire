using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PatientResultsSystem.Models;
using PatientResultsSystem.Util;
using PatientResultsSystem.Views;

namespace PatientResultsSystem.ViewModels
{
    /// <summary>
    /// Workhorse for creating and viewing a Questionnaire
    /// </summary>
    class QuestionnaireViewModel : ViewModelBase
    {
	    private Patient _thisPatient;					// Patient that the questionnaire goes with
        private Questionairre _qnnaire;                 // The questionnaire
	    private ICollection<QuestionWrapper> _questionAnswerSet;
        private QuestionWrapper _currentQuestion;       // the current question/answer pair
        private int index;                              // index into _questionAnserSet
        private Int64 _questionnaireID;                 // id of the questionnaire

		public Patient ThisPatient { set { _thisPatient = value; } }
        public Int64 QuestionnaireID { get { return _questionnaireID; } }

	    public ICollection<QuestionWrapper> QuestionAnswerSet
	    {
		    get
		    {
			    if(_questionAnswerSet == null)
					_questionAnswerSet = new ObservableCollection<QuestionWrapper>();
				
				return _questionAnswerSet;
		    }
		    set
		    {
			    _questionAnswerSet = value;
			    OnPropertyChanged("QuestionAnswerSet");
		    }
	    }

        public QuestionWrapper CurrentQuestion
        {
            get
            {
                return _questionAnswerSet.ElementAt(index);
            }
            set
            {
                _questionAnswerSet.ElementAt ( index ).Answer = value.Answer;
                OnPropertyChanged ( "CurrentQuestion" );
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionnaireViewModel"/> class.
        /// </summary>
        public QuestionnaireViewModel ( )
        {

            QuestionairreDatabaseHelper.InitializeDb ( );
            // Get 1st questionnaire in the database
            _qnnaire = QuestionairreDatabaseHelper.GetQuestionairres ( )[0];

            _questionnaireID = _qnnaire.idNumber;

			// Populate questionnaire with questions for binding
	        foreach (string question in _qnnaire.questionList)
	        {
		        QuestionAnswerSet.Add(new QuestionWrapper(question));
	        }

            index = 0;
        }


        // Specify actions to take place if cancelled
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

        // Specify actions to take when finished
        private ICommand _finishCommand;
        public ICommand FinishCommand
        {
            get
            {
                if (_finishCommand == null)
                {
                    _finishCommand = new RelayCommand ( arg =>
                    {
	                    List<Int64> answerList = (from q in _questionAnswerSet
											   select q.Answer).ToList().ConvertAll(i => (long)i);

                        

                        // Create a new answer set from the answers given and add them to the table.
                        AnswerSet answers = new AnswerSet ( answerList, DateTime.Now, _thisPatient.ID, _questionnaireID );
                        QuestionairreDatabaseHelper.AddAnswers ( answers );

                        // Display message box notifying user of success
                        MessageBox.Show ( "Questionnaire " + _questionnaireID + " for " + _thisPatient.FirstName +
                            " " + _thisPatient.LastName + " added successfully.", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information );

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
                    },
                    arg => true
                    );
                }

                return _finishCommand;
            }
        }

        // Specify actions to take place if exited
        private ICommand _exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                {
                    _exitCommand = new RelayCommand ( arg =>
                    {
                        // Get main window
                        MainWindow mainWindow = WindowHelper.FindWindow ( typeof ( MainWindow ) ) as MainWindow;

                        if (mainWindow != null)
                        {
                            // Get main window and main view handles
                            object mainView = mainWindow.TryFindResource ( "MainView" );

                            // Navigate back to main view
                            if (mainView != null)
                            {
                                mainWindow.PageFrame.Navigate ( mainView );
                            }
                        }
                    },
                    arg => true
                    );
                }

                return _exitCommand;
            }
        }

        // Specify actions to take place if next
        private ICommand _nextCommand;
        public ICommand NextCommand
        {
            get
            {
                if (_nextCommand == null)
                {
                    _nextCommand = new RelayCommand ( arg =>
                    {
                        index++;
						OnPropertyChanged("CurrentQuestion");
                    },
                    arg =>
                    {
                        return (index != (_questionAnswerSet.Count - 1));
                    }
                    );
                }

                return _nextCommand;
            }
        }

        // Specify actions to take place if previous
        private ICommand _previousCommand;
        public ICommand PreviousCommand
        {
            get
            {
                if (_previousCommand == null)
                {
                    _previousCommand = new RelayCommand ( arg =>
                    {
                        index--;
						OnPropertyChanged("CurrentQuestion");
                    },
                    arg =>
                    {
                        return (index != 0);
                    });
                }

                return _previousCommand;
            }
        }

    }
}
