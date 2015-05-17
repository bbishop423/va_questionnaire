using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientResultsSystem.Models
{
	class QuestionWrapper
	{
		//
		// Private Fields
		//
		private string _question;
		private int _answer;

		//
		// Properties
		//
		public string Question
		{
			get { return _question; }
		}

		public int Answer
		{
			get { return _answer; }
			set { _answer = value; }
		}

		//
		// Constructor
		//
		public QuestionWrapper(string question)
		{
			// Set question to passed question, init answer to 50
			_question = question;
			_answer = 50;
		}
	}
}
