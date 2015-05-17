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
    /// ViewModel for Chart View
    /// </summary>
    class ReportViewModel : ViewModelBase
    {
        /***************************************
         * Private attributes
        ****************************************/

        private Patient _thisPatient;               // The patient
        private Questionairre _qnnaire;             // The questionnaire
	    private IList<AverageValuesWrapper> _avgValues; 
        private List<AnswerSet> _listOfAnswerSets;  // List of all answersets from patient + questionnaire id
        private AnswerSet _currentAnswerSet;        // The most recent set of answers from patient

        // Answer lists for each group
        private List<Int64> _allAnswers;
        private List<Int64> _basicAnswers;
        private List<Int64> _advancedAnswers;
        private List<Int64> _adjustAnswers;
        private List<Int64> _aidedAnswers;

        // Hard-coded briefs from questions
        private List<string> _basicBriefs = new List<string> { "1. Battery insertion", "2. Battery removal", "3. Right vs. left",
                                            "4. Insert hearing aids", "5. Remove hearing aids", "7. Operate controls",
                                            "10. Clean and care" };
        private List<string> _advancedBriefs = new List<string> { "6. Identify components", "8. Feedback management",
                                            "9. Troubleshooting", "11. Make and model", "12. Battery size" };
        private List<string> _adjustBriefs = new List<string> { "13. Adjust to sound quality", "14. Physical feel of aid",
                                            "15. Adjust to own voice" };
        private List<string> _aidedBriefs = new List<string> { "16. 1:1 conversion in quiet", "17. 1:1 conversation in quiet small group",
                                            "18. Regular telephone", "19. Television", "20. Speaker/lecturer in meeting",
                                            "21. 1:1 conversation in noise", "22. Small group conversation in noise",
                                            "23. Public service announcement", "24. Conversation in car" };


        /***************************************
         * Propertes for getting/setting/binding
        ****************************************/

        public Patient ThisPatient { set { _thisPatient = value; } get { return _thisPatient; } }

		public IDictionary<string, int> AverageChart { get; private set; }
        public IDictionary<string, long> AvgChartPatient { get; private set; }
		public IDictionary<string, long> BasicChart { get; private set; }
		public IDictionary<string, long> AdvancedChart { get; private set; }
		public IDictionary<string, long> AdjustChart { get; private set; }
		public IDictionary<string, long> AidedChart { get; private set; }

	    public IList<AverageValuesWrapper> AvgValues
	    {
			set { _avgValues = value; }
		    get
		    {
			    if(_avgValues == null)
				    _avgValues = new List<AverageValuesWrapper>();

			    return _avgValues;
		    }
	    }

        // Answer groups to bind to
        // Contains the values for each answer
        public List<Int64> AllAnswers { get { return _allAnswers; } }
        public List<Int64> BasicAnswers { get { return _basicAnswers; } }
        public List<Int64> AdvancedAnswers { get { return _advancedAnswers; } }
        public List<Int64> AdjustAnswers { get { return _adjustAnswers; } }
        public List<Int64> AidedAnswers { get { return _aidedAnswers; } }

        // Binding to each group of question summaries
        public List<string> BasicBriefs    { get { return _basicBriefs; } }
        public List<string> AdvancedBriefs { get { return _advancedBriefs; } }
        public List<string> AdjustBriefs   { get { return _adjustBriefs; } }
        public List<string> AidedBriefs    { get { return _aidedBriefs; } }

        // Hearing Aid Summary Formatted as string
        public string HearingAidSummary { get; private set; }

		//
		// Public initialization method to be called since init cant be done in constructor
		//
	    public void Initialize(Patient thisPatient)
	    {
			// Set patient
		    ThisPatient = thisPatient;
            OnPropertyChanged ( "ThisPatient" );

			// List of Answersets for this thisPatient using questionnaire ID 1;
			QuestionairreDatabaseHelper.InitializeDb();
			_listOfAnswerSets = QuestionairreDatabaseHelper.GetAnswers (1, _thisPatient.ID);

			// get the most current answerset based on most recent date taken
			if (_listOfAnswerSets.Count != 0)
			{
				_currentAnswerSet = _listOfAnswerSets[0];
			}
			if (_listOfAnswerSets.Count > 1)
			{
				foreach (AnswerSet set in _listOfAnswerSets)
				{
					if (set.dateAnswered > _currentAnswerSet.dateAnswered)
					{
						_currentAnswerSet = set;
					}
				}
			}

			// Initialize group lists
            _allAnswers = new List<Int64> ( );
            _basicAnswers = new List<Int64> ( );
            _advancedAnswers = new List<Int64> ( );
            _adjustAnswers = new List<Int64> ( );
            _aidedAnswers = new List<Int64> ( );


			// fill the group lists with appropriate answer values
			for (int i = 0; i < _currentAnswerSet.answerList.Count ( ); i++)
			{
				// all question/answersets should be in this group
				_allAnswers.Add (_currentAnswerSet.answerList[i]);

				// i corresponds to question number
				// i = 1-5,7,10
				if (i <= 4 || i == 6 || i == 9)
				{
					_basicAnswers.Add (_currentAnswerSet.answerList[i]);
				} // i = 6,8,9,11,12
				else if (i <= 11)
				{
					_advancedAnswers.Add (_currentAnswerSet.answerList[i]);
				}// i = 13,14,15
				else if (i <= 14)
				{
					_adjustAnswers.Add (_currentAnswerSet.answerList[i]);
				} // i = 16-24
				else
				{
					_aidedAnswers.Add (_currentAnswerSet.answerList[i]);
				}
			}

			// Set average values
			AvgValues.Add (new AverageValuesWrapper (_allAnswers.Sum ( ) / _allAnswers.Count ( ), _basicAnswers.Sum ( ) / _basicAnswers.Count ( ),
				_advancedAnswers.Sum ( ) / _advancedAnswers.Count ( ), _adjustAnswers.Sum ( ) / _adjustAnswers.Count ( ),
				_aidedAnswers.Sum ( ) / _aidedAnswers.Count ( )));

			// Populate charts
			FillChartingDictionaries();

			FormatHearingAidSummary ( );
            OnPropertyChanged ( "HearingAidSummary" );
	    }

	    private void FillChartingDictionaries()
	    {
			// Fill average chart
			AverageChart = new Dictionary<string, int> ( );
			AverageChart.Add ("Total", 81);
			AverageChart.Add ("Basic", 90);
			AverageChart.Add ("Advanced", 65);
			AverageChart.Add ("Adjust", 85);
			AverageChart.Add ("Aided", 87);
			OnPropertyChanged("AverageChart");

			// Fill patient values for average chart
			AvgChartPatient = new Dictionary<string, long> ( );
			AvgChartPatient.Add ("Total", AvgValues[0].AvgTotal);
			AvgChartPatient.Add ("Basic", AvgValues[0].AvgBasic);
			AvgChartPatient.Add ("Advanced", AvgValues[0].AvgAdvanced);
			AvgChartPatient.Add ("Adjust", AvgValues[0].AvgAdjust);
			AvgChartPatient.Add ("Aided", AvgValues[0].AvgAided);
			OnPropertyChanged ("AvgChartPatient");

			// Fill basic chart dictionary
			BasicChart = new Dictionary<string, long> ( );
			for (int i = 0; i < _basicBriefs.Count; i++)
			{
				BasicChart.Add (_basicBriefs[i], _basicAnswers[i]);
			}
			OnPropertyChanged ("BasicChart");

			// Fill advanced chart dictionary
			AdvancedChart = new Dictionary<string, long> ( );
			for (int i = 0; i < _advancedBriefs.Count; i++)
			{
				AdvancedChart.Add (_advancedBriefs[i], _advancedAnswers[i]);
			}
			OnPropertyChanged ("AdvancedChart");

			// Fill adjust chart dictionary
			AdjustChart = new Dictionary<string, long> ( );
			for (int i = 0; i < _adjustBriefs.Count; i++)
			{
				AdjustChart.Add (_adjustBriefs[i], _adjustAnswers[i]);
			}
			OnPropertyChanged ("AdjustChart");

			// Fill aided chart dictionary
			AidedChart = new Dictionary<string, long> ( );
			for (int i = 0; i < _aidedBriefs.Count; i++)
			{
				AidedChart.Add (_aidedBriefs[i], _aidedAnswers[i]);
			}
			OnPropertyChanged ("AidedChart");
	    }

        /// <summary>
        /// Formats the hearing aid summary.
        /// </summary>
        private void FormatHearingAidSummary ( )
        {
            StringBuilder sb = new StringBuilder ( );
            sb.Append ( "Left Ear Make: " );
            sb.Append ( _thisPatient.LeftEar.Make != null ?_thisPatient.LeftEar.Make.ToString ( ) : "N/A" );
            sb.Append ( ", Model: " );
			sb.AppendLine (_thisPatient.LeftEar.Model != null ? _thisPatient.LeftEar.Model.ToString ( ) : "N/A");
            sb.Append ( "Left Ear - HA Style: " );
			sb.Append (_thisPatient.LeftEar.Style != null ? _thisPatient.LeftEar.Style.ToString ( ) : "N/A");
            sb.Append ( ", Fit Date: " );
			sb.AppendLine (_thisPatient.LeftEar.FitDate != null ? _thisPatient.LeftEar.FitDate.ToString ( ) : "N/A");
            sb.Append ( "Right Ear Make: " );
			sb.Append (_thisPatient.RightEar.Make != null ? _thisPatient.RightEar.Make.ToString ( ) : "N/A");
            sb.Append ( ", Model: " );
			sb.AppendLine (_thisPatient.RightEar.Model != null ? _thisPatient.RightEar.Model.ToString ( ) : "N/A");
            sb.Append ( "Right Ear - HA Style: " );
			sb.Append (_thisPatient.RightEar.Style != null ? _thisPatient.RightEar.Style.ToString ( ) : "N/A");
            sb.Append ( ", Fit Date: " );
			sb.AppendLine (_thisPatient.RightEar.FitDate != null ? _thisPatient.RightEar.FitDate.ToString ( ) : "N/A");

            HearingAidSummary = sb.ToString ( );
        }

    }
}
