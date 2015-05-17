using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientResultsSystem.Models
{
    /// <summary>
    /// Contains all information related to a set of answers
    /// </summary>
    class AnswerSet
    {
        private Int64? id_number;
        private List<Int64> answer_list = new List<Int64> ( );
        private DateTime date_answered;
        private string patient_id;
        private Int64 question_id;

        public Int64 idNumber { get { return id_number.GetValueOrDefault(); } set { id_number = value; } }
        public List<Int64> answerList { get { return answer_list; } set { answer_list = value; } }
        public DateTime dateAnswered { get { return date_answered; } set { date_answered = value; } }
        public string patientId { get { return patient_id; } set { patient_id = value; } }
        public Int64 questionId { get { return question_id; } set { question_id = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerSet"/> class. Because the database auto-increments
        /// the AnswerSet id_number, this constructor should be used for creating a new AnswerSet.
        /// </summary>
        /// <param name="answers">The answers.</param>
        /// <param name="date">The date.</param>
        /// <param name="patient">The patient.</param>
        /// <param name="questions">The questions.</param>
        public AnswerSet ( List<Int64> answers, DateTime date, string patient, Int64 questions )
        {
            this.id_number = null;
            this.answer_list = answers;
            this.date_answered = date;
            this.patient_id = patient;
            this.question_id = questions;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AnswerSet"/> class. This constructor should be used for
        /// getting an AnswerSet from the database.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="answers">The answers.</param>
        /// <param name="date">The date.</param>
        /// <param name="patient">The patient.</param>
        /// <param name="questions">The questions.</param>
        public AnswerSet ( Int64 id, List<Int64> answers, DateTime date, string patient, Int64 questions )
        {
            this.id_number = id;
            this.answer_list = answers;
            this.date_answered = date;
            this.patient_id = patient;
            this.question_id = questions;
        }
    }
}
