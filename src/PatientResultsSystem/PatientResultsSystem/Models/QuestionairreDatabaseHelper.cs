using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientResultsSystem.Models
{
    class QuestionairreDatabaseHelper
    {
        private static string _connectionString = "Data Source=../../Database/SystemData;Version=3";
        private static SQLiteConnection _dbConnection = null;

        //
        // Method to connect to the database
        //
        public static void InitializeDb(string connectionString = null)
        {
            try
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    _dbConnection = new SQLiteConnection(_connectionString);
                }
                else
                {
                    _dbConnection = new SQLiteConnection(connectionString);
                }

                _dbConnection.Open();
            }
            catch (SQLiteException)
            {
                throw;
            }

        }

        //this method returns all the questionairres in the database. it returns a list of Questionairres
        public static List<Questionairre> GetQuestionairres()
        {
            Questionairre questionairre;
            List<Questionairre> questionairre_list = new List<Questionairre>();
            // Query the Users database table for all patients
            if (_dbConnection != null)
            {
                string queryString = string.Format("SELECT * FROM Questions");
                using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                {
                    SQLiteDataReader reader = sqlQuery.ExecuteReader();

                    while (reader.Read())
                    {
                        questionairre = new Questionairre((Int64)reader["idNumber"], new List<string> {(string)reader["Q1"],
                                (string)reader["Q2"], (string)reader["Q3"], (string)reader["Q4"], (string)reader["Q5"], 
                                (string)reader["Q6"], (string)reader["Q7"], (string)reader["Q8"], (string)reader["Q9"], 
                                (string)reader["Q10"], (string)reader["Q11"], (string)reader["Q12"], (string)reader["Q13"], 
                                (string)reader["Q14"], (string)reader["Q15"], (string)reader["Q16"], (string)reader["Q17"], 
                                (string)reader["Q18"], (string)reader["Q19"], (string)reader["Q20"], (string)reader["Q21"], 
                                (string)reader["Q22"], (string)reader["Q23"], (string)reader["Q24"]});
                        questionairre_list.Add(questionairre);
                    }
                }
                return questionairre_list;
            }
            return null;
        }

        //this method takes in a list of ints.  the ints represent the primary keys in the database for the question sets.
        //when you pass in the list it will grab every question set in the database for every primary key you have in the list
        //the primary keys for question sets are unsigned ints. NOT 0 based so first pk will be 1.
        //this method will return a list of Questionairres.
        public static List<Questionairre> GetQuestionairres(List<int> questionairres_to_select)
        {
            Questionairre questionairre;
            List<Questionairre> questionairre_list = new List<Questionairre>();
            // Query the Users database table for all patients
            if (_dbConnection != null)
            {
                string queryString = string.Format("SELECT * FROM Questions WHERE idNumber = {0}", questionairres_to_select[0]);
                if (questionairres_to_select.Count > 1)
                {
                    for (int i = 1; i < questionairres_to_select.Count; i++)
                    {
                        queryString += string.Format(" AND WHERE idNumber = {"+Convert.ToString(i)+"}", questionairres_to_select[i]);
                    }
                }
                    using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                    {
                        SQLiteDataReader reader = sqlQuery.ExecuteReader();

                        while (reader.Read())
                        {
                            questionairre = new Questionairre((int)reader["idNumber"], new List<string> {(string)reader["Q1"],
                                (string)reader["Q2"], (string)reader["Q3"], (string)reader["Q4"], (string)reader["Q5"], 
                                (string)reader["Q6"], (string)reader["Q7"], (string)reader["Q8"], (string)reader["Q9"], 
                                (string)reader["Q10"], (string)reader["Q11"], (string)reader["Q12"], (string)reader["Q13"], 
                                (string)reader["Q14"], (string)reader["Q15"], (string)reader["Q16"], (string)reader["Q17"], 
                                (string)reader["Q18"], (string)reader["Q19"], (string)reader["Q20"], (string)reader["Q21"], 
                                (string)reader["Q22"], (string)reader["Q23"], (string)reader["Q24"]});
                            questionairre_list.Add(questionairre);
                        }
                    }
                    return questionairre_list;
            }
            return null;
        }

        //this method returns all the answers that are in the database, there is a question id returned and a patient id 
        //returned with each answer set.  they are what you need to match up patients with their answers for the corresponding
        //questionairres that they have completed.  this returns a list of AnswerSets
        public static List<AnswerSet> GetAnswers()
        {
            AnswerSet answer_set;
            List<AnswerSet> answer_set_list = new List<AnswerSet>();
            // Query the Users database table for all patients
            if (_dbConnection != null)
            {
                string queryString = string.Format("SELECT * FROM Answers");
                using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                {
                    SQLiteDataReader reader = sqlQuery.ExecuteReader();

                    while (reader.Read())
                    {
                        answer_set = new AnswerSet((int)reader["idNumber"], new List<Int64> {(int)reader["A1"],
                                (int)reader["A2"], (int)reader["A3"], (int)reader["A4"], (int)reader["A5"], 
                                (int)reader["A6"], (int)reader["A7"], (int)reader["A8"], (int)reader["A9"], 
                                (int)reader["A10"], (int)reader["A11"], (int)reader["A12"], (int)reader["A13"], 
                                (int)reader["A14"], (int)reader["A15"], (int)reader["A16"], (int)reader["A17"], 
                                (int)reader["A18"], (int)reader["A19"], (int)reader["A20"], (int)reader["A21"], 
                                (int)reader["A22"], (int)reader["A23"], (int)reader["A24"]},
                                (DateTime) reader["DateAnswered"], (string) reader["PatientID"], (int) reader["QuestionID"]);
                        answer_set_list.Add(answer_set);
                    }
                }
                return answer_set_list;
            }
            return null;
        }

        //this method returns all the answer sets for a particular questionairre. all patients who have answered this 
        //questionairre will have their answers returned in a list of AnswerSets
        public static List<AnswerSet> GetAnswers(int question_id)
        {
            AnswerSet answer_set;
            List<AnswerSet> answer_set_list = new List<AnswerSet>();
            // Query the Users database table for all patients
            if (_dbConnection != null)
            {
                string queryString = string.Format("SELECT * FROM Answers WHERE QuestionID = {0}", question_id);
                using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                {
                    SQLiteDataReader reader = sqlQuery.ExecuteReader();

                    while (reader.Read())
                    {
                        answer_set = new AnswerSet ( (int)reader["idNumber"], new List<Int64> {(int)reader["A1"],
                                (int)reader["A2"], (int)reader["A3"], (int)reader["A4"], (int)reader["A5"], 
                                (int)reader["A6"], (int)reader["A7"], (int)reader["A8"], (int)reader["A9"], 
                                (int)reader["A10"], (int)reader["A11"], (int)reader["A12"], (int)reader["A13"], 
                                (int)reader["A14"], (int)reader["A15"], (int)reader["A16"], (int)reader["A17"], 
                                (int)reader["A18"], (int)reader["A19"], (int)reader["A20"], (int)reader["A21"], 
                                (int)reader["A22"], (int)reader["A23"], (int)reader["A24"]},
                                (DateTime)reader["DateAnswered"], (string)reader["PatientID"], (int)reader["QuestionID"]);
                        answer_set_list.Add(answer_set);
                    }
                }
                return answer_set_list;
            }
            return null;
        }

        //this method returns all the answer sets for a particular patient. all answer sets for all questionairres completed
        //by this patient will be returned. they are returned in a list of AnswerSets
        public static List<AnswerSet> GetAnswers(string patient_id)
        {
            AnswerSet answer_set;
            List<AnswerSet> answer_set_list = new List<AnswerSet>();
            // Query the Users database table for all patients
            if (_dbConnection != null)
            {
                string queryString = string.Format("SELECT * FROM Answers WHERE PatientID = '{0}'", patient_id);
                using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                {
                    SQLiteDataReader reader = sqlQuery.ExecuteReader();

                    while (reader.Read())
                    {
                        answer_set = new AnswerSet ( (int)reader["idNumber"], new List<Int64> {(int)reader["A1"],
                                (int)reader["A2"], (int)reader["A3"], (int)reader["A4"], (int)reader["A5"], 
                                (int)reader["A6"], (int)reader["A7"], (int)reader["A8"], (int)reader["A9"], 
                                (int)reader["A10"], (int)reader["A11"], (int)reader["A12"], (int)reader["A13"], 
                                (int)reader["A14"], (int)reader["A15"], (int)reader["A16"], (int)reader["A17"], 
                                (int)reader["A18"], (int)reader["A19"], (int)reader["A20"], (int)reader["A21"], 
                                (int)reader["A22"], (int)reader["A23"], (int)reader["A24"]},
                                (DateTime)reader["DateAnswered"], (string)reader["PatientID"], (int)reader["QuestionID"]);
                        answer_set_list.Add(answer_set);
                    }
                }
                return answer_set_list;
            }
            return null;
        }

        //this method returns the answer set for a particular questionairre for a particular user.  if the user has
        //completed this questionairre multiple times then all of them will be returned in a list of AnswerSets.
        //each AnswerSet has a date taken attribute so users can differentiate between the different answer sets.
        public static List<AnswerSet> GetAnswers(int question_id, string patient_id)
        {
            AnswerSet answer_set;
            List<AnswerSet> answer_set_list = new List<AnswerSet>();
            // Query the Users database table for all patients
            if (_dbConnection != null)
            {
                string queryString = string.Format("SELECT * FROM Answers WHERE QuestionID = {0} AND PatientID = '{1}'", question_id, patient_id);
                using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                {
                    SQLiteDataReader reader = sqlQuery.ExecuteReader();

                    while (reader.Read())
                    {
                        answer_set = new AnswerSet ( (Int64)reader["idNumber"], new List<Int64> {(Int64)reader["A1"],
                                (Int64)reader["A2"], (Int64)reader["A3"], (Int64)reader["A4"], (Int64)reader["A5"], 
                                (Int64)reader["A6"], (Int64)reader["A7"], (Int64)reader["A8"], (Int64)reader["A9"], 
                                (Int64)reader["A10"], (Int64)reader["A11"], (Int64)reader["A12"], (Int64)reader["A13"], 
                                (Int64)reader["A14"], (Int64)reader["A15"], (Int64)reader["A16"], (Int64)reader["A17"], 
                                (Int64)reader["A18"], (Int64)reader["A19"], (Int64)reader["A20"], (Int64)reader["A21"], 
                                (Int64)reader["A22"], (Int64)reader["A23"], (Int64)reader["A24"]},
								(DateTime)reader["DateAnswered"], (string)reader["PatientID"], (Int64)reader["QuestionID"]);
                        answer_set_list.Add(answer_set);
                    }
                }
                return answer_set_list;
            }
            return null;
        }

        //this method returns all the answer set for a particular questionairre. this returns a particular answer set for a 
        //particular questionairre taken by a particular patient on a particular date. returns a list with 1 AnswerSet
        public static List<AnswerSet> GetAnswers(int question_id, string patient_id, DateTime date_answered)
        {
            AnswerSet answer_set;
            List<AnswerSet> answer_set_list = new List<AnswerSet>();
            // Query the Users database table for all patients
            if (_dbConnection != null)
            {
                string queryString = string.Format("SELECT * FROM Answers WHERE QuestionID = {0} AND PatientID = '{1}' AND DateAnswered = '{2}'",
                    question_id, patient_id, DateTimeToSQLite(date_answered));
                using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                {
                    SQLiteDataReader reader = sqlQuery.ExecuteReader();

                    while (reader.Read())
                    {
                        answer_set = new AnswerSet ( (int)reader["idNumber"], new List<Int64> {(int)reader["A1"],
                                (int)reader["A2"], (int)reader["A3"], (int)reader["A4"], (int)reader["A5"], 
                                (int)reader["A6"], (int)reader["A7"], (int)reader["A8"], (int)reader["A9"], 
                                (int)reader["A10"], (int)reader["A11"], (int)reader["A12"], (int)reader["A13"], 
                                (int)reader["A14"], (int)reader["A15"], (int)reader["A16"], (int)reader["A17"], 
                                (int)reader["A18"], (int)reader["A19"], (int)reader["A20"], (int)reader["A21"], 
                                (int)reader["A22"], (int)reader["A23"], (int)reader["A24"]},
                                (DateTime)reader["DateAnswered"], (string)reader["PatientID"], (int)reader["QuestionID"]);
                        answer_set_list.Add(answer_set);
                    }
                }
                return answer_set_list;
            }
            return null;
        }

        //this method adds answer sets to the database.  it takes in an AnswerSet as a parameter and then inserts
        //all the data about that answer set into the database.
        public static void AddAnswers(AnswerSet answers)
        {
            if (_dbConnection != null)
            {
                int count = 0;
                string stmtToInsertAnswers = string.Format("INSERT INTO Answers Values(NULL,");
                foreach (int answer in answers.answerList)
                {
                    stmtToInsertAnswers += string.Format(answer + ",");
                    count++;
                }

                stmtToInsertAnswers += string.Format("'" + DateTimeToSQLite(answers.dateAnswered) + "','" + answers.patientId + "'," + answers.questionId + ")");
                using (SQLiteCommand sqlQuery = new SQLiteCommand(stmtToInsertAnswers, _dbConnection))
                {
                    sqlQuery.ExecuteNonQuery();
                }
            }
        }

        // Converts the .NET DateTime structure into proper format for being recognized by SQLite
        private static string DateTimeToSQLite(DateTime datetime)
        {
            return string.Format("{0:s}", datetime);
        }

    }
}
