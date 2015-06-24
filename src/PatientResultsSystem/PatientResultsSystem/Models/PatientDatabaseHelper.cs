using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace PatientResultsSystem.Models
{
    class PatientDatabaseHelper
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

        //
        // Method to return all patients in the database. Return NULL if not found.
        // To get the patients AND the hearing aid information you need to call these 2 methods in concert
        // with the second method taking in the results from the first as its parameter
        // example: List<Patient> my_patients = patient_db_helper_obj.GetPatientsHearingAids(patient_db_helper_obj.GetPatients());
        // that will return a list of all patients and the hearing aids that are associated with them. calling GetPatients alone
        // will return only a list of patients with no hearing aids
        //
        public static List<Patient> GetPatients()
        {
            Patient patient;
            List<Patient> patientList = new List<Patient>();

            // Query the Users database table for all patients
             if (_dbConnection != null)
            {
                string queryString = string.Format("SELECT * FROM Patients");
                using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                {
                    SQLiteDataReader reader = sqlQuery.ExecuteReader();

                    while (reader.Read())
                    {
                        patient = new Patient((string)reader["FirstName"], (string)reader["LastName"], ((string)reader["MiddleInitial"])[0],
                            (string)reader["idNumber"], (DateTime)reader["TestDate"], (DateTime)reader["DOB"], (string)reader["Comments"],
                            (string)reader["ProviderName"], (string)reader["ClinicianID"]);
                        patientList.Add(patient);                        
                    }
                }
                return patientList;
            }
            return null;
        }

        //again this method will return a list of Patients where you are searching for a specific attribute
        //to get the hearing aids associated with those patients you have to call this method in concert with
        //GetPatientsHearingAids()
        //example: List<Patient> my_patients = patient_db_helper_obj.GetPatientsHearingAids(patient_db_helper_obj.GetPatients(query_list));
        //this method takes in a list of string arrays as its parameter, with each string array containing 2 values, the first value
        //is the column name, the second value is the value you are searching for in that column so you can you this method to search
        //for 1 or many different combinations of searches depending on the number of arrays you add to the list
        //example, list contains: {"LastName","Smith"},{"LastName","Jones"} that will return a list of patients with the last
        //names of jones and the last name of smith
        public static List<Patient> GetPatients(List<string[]> queries)
        {
            Patient patient;
            List<Patient> patientList = new List<Patient>();

            // Query the Users database table for all patients
            if (_dbConnection != null)
            {
                foreach (string[] query in queries)
                {
                    string queryString = string.Format("SELECT * FROM Patients WHERE {0} = '{1}'", query[0], query[1]);
                    using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                    {
                        SQLiteDataReader reader = sqlQuery.ExecuteReader();

                        while (reader.Read())
                        {
                            patient = new Patient((string)reader["FirstName"], (string)reader["LastName"], ((string)reader["MiddleInitial"])[0],
                                (string)reader["idNumber"], (DateTime)reader["TestDate"], (DateTime)reader["DOB"], (string)reader["Comments"],
                                (string)reader["ProviderName"], (string)reader["ClinicianID"]);
                            patientList.Add(patient);
                        }
                    }
                }
                return patientList;
            }
            return null;
        }

        //this method selects patients using AND logic, if you do not pass in true for the second parameter here
        //then all patients will be selected and added to the list based on OR logic (using the above method) with
        //your queries you passed in as your first parameter
        public static List<Patient> GetPatients(List<string[]> queries, Boolean and)
        {
            Patient patient;
            List<Patient> patient_list = new List<Patient>();
            int arg_count = 2;
            // Query the Users database table for all patients
            if (_dbConnection != null)
            {
                if (and == true)
                {
                    string queryString = string.Format("SELECT * FROM Patients WHERE {0} = '{1}'", queries[0][0], queries[0][1]);
                    for (int i = 1; i < queries.Count; i++)
                    {
                        queryString += string.Format(" AND WHERE {" + Convert.ToString(arg_count) + "} = '{"+Convert.ToString(arg_count+1)+"}'", queries[i][0], queries[i][1]);
                        arg_count += 2;
                    }
                    using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                    {
                        SQLiteDataReader reader = sqlQuery.ExecuteReader();

                        while (reader.Read())
                        {
                            patient = new Patient((string)reader["FirstName"], (string)reader["LastName"], ((string)reader["MiddleInitial"])[0],
                                (string)reader["idNumber"], (DateTime)reader["TestDate"], (DateTime)reader["DOB"], (string)reader["Comments"],
                                (string)reader["ProviderName"], (string)reader["ClinicianID"]);
                            patient_list.Add(patient);
                        }
                    }
                    return patient_list;
                }
            }
            return null;
        }

        //the way i did this is first you get all the patients out of the database, then you get returned a list of patients
        //you then take that list of patients and pass it in here to get all the hearing aids related to that patient and
        //add them as hearing aid properties of that patient, then the patient list is returned again with the hearing aids
        //added as properties to each patient.
        public static List<Patient> GetPatientsHearingAids(List<Patient> patientList)
        {
             // Query the Users database table for all patients
            if (_dbConnection != null)
            {
                foreach (Patient patient in patientList)
                {
                    HearingAid hearingAid;
                    string queryString = string.Format("SELECT * FROM EarInfo WHERE PatientID = '{0}'", patient.ID);
                    using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                    {
                        SQLiteDataReader reader = sqlQuery.ExecuteReader();

                        while (reader.Read())
                        {
                            hearingAid = new HearingAid((string)reader["Make"],(string)reader["Model"],(string)reader["Serial"],
								(DateTime)reader["FitDate"], (StyleOfHearingAid)Enum.Parse (typeof (StyleOfHearingAid), (string)reader["Style"]), ((string)reader["SideOfHead"])[0]);
                            if ((string)reader["SideOfHead"] == "L")
                            {
                                patient.LeftEar = hearingAid;
                            }
                            else
                            {
                                patient.RightEar = hearingAid;
                            }
                        }
                    }
                }
                return patientList;
            }
            return null;
        }


        /*the below method has NOT been tested and DOES need to be cleaned up. 
         * However it is an idea of what we may want to do to add a patient     Jason */
        public static void AddPatient(Patient patient)
        {
            if (_dbConnection != null)
            {
                string stmtToInsertPatient = string.Format("INSERT INTO Patients Values('" + patient.ID + "','" + patient.FirstName + "','" +
                     patient.LastName + "','" + patient.MiddleInitial + "','" + patient.ProviderName + "','" +
                     DateTimeToSQLite(patient.TestDate) + "','" + DateTimeToSQLite(patient.DoB) + "','" + patient.Comments +
                     "','" + patient.ClinicianID + "')");

                using (SQLiteCommand sqlQuery = new SQLiteCommand(stmtToInsertPatient, _dbConnection))
                {
                    sqlQuery.ExecuteNonQuery();
                }

                if (patient.LeftEar.Make != "")
                {
                    string stmtToAddLeftHearingAid = string.Format("Insert into EarInfo Values(NULL,'" + patient.LeftEar.Make +
						"','" + patient.LeftEar.Model + "','" + patient.LeftEar.Serial + "','" +
                        DateTimeToSQLite(patient.LeftEar.FitDate) + "','" + Enum.GetName(typeof(StyleOfHearingAid), patient.LeftEar.Style) + "','" +
                        patient.LeftEar.SideOfHead + "','" + patient.ID +"')");
                   
                    using (SQLiteCommand sqlQuery = new SQLiteCommand(stmtToAddLeftHearingAid, _dbConnection))
                    {
                        sqlQuery.ExecuteNonQuery();
                    }
                }

                if (patient.RightEar.Make != "")
                {
                    string stmtToAddRightHearingAid = string.Format("Insert into EarInfo Values(NULL,'" + patient.RightEar.Make +
                         "','" + patient.RightEar.Model + "','" + patient.RightEar.Serial + "','" +
						 DateTimeToSQLite (patient.RightEar.FitDate) + "','" + Enum.GetName (typeof (StyleOfHearingAid), patient.RightEar.Style) + "','" +
                         patient.RightEar.SideOfHead + "','" + patient.ID + "')");

                    /*put in a using statement so that it will dispose of it afterwards whether if it fails or not,
                     * maybe consider doing a try finally here assuming we need to dispose of something*/
                    using (SQLiteCommand sqlQuery = new SQLiteCommand(stmtToAddRightHearingAid, _dbConnection))
                    {
                        sqlQuery.ExecuteNonQuery();
                    }
                }
            }
        }

		// 
		// Method to update the passed patient's database entry with new values
		//
	    public static void UpdatePatient(Patient patient)
	    {
			if (_dbConnection != null)
			{
				string stmtToUpdatePatient = string.Format ("UPDATE Patients SET FirstName='" + patient.FirstName + "', LastName='" + patient.LastName + 
					"', MiddleInitial='" + patient.MiddleInitial + "', ProviderName='" + patient.ProviderName + "', TestDate='" + DateTimeToSQLite (patient.TestDate) + 
					"', DOB='" + DateTimeToSQLite(patient.DoB) + "', Comments='" + patient.Comments + "' WHERE idNumber='" + patient.ID + "'");

				using (SQLiteCommand sqlQuery = new SQLiteCommand (stmtToUpdatePatient, _dbConnection))
				{
					sqlQuery.ExecuteNonQuery ( );
				}

				if (patient.LeftEar.Make != "")
				{
					string stmtToUpdateLeftHearingAid = string.Format ("UPDATE EarInfo SET Make='" + patient.LeftEar.Make + "', Model='" + patient.LeftEar.Model + 
						"', Serial='" + patient.LeftEar.Serial + "', FitDate='" + DateTimeToSQLite (patient.LeftEar.FitDate) + "', Style='" + 
						Enum.GetName (typeof (StyleOfHearingAid), patient.LeftEar.Style) + "' WHERE PatientID='" + patient.ID + "' AND SideOfHead='L'");

					using (SQLiteCommand sqlQuery = new SQLiteCommand (stmtToUpdateLeftHearingAid, _dbConnection))
					{
						sqlQuery.ExecuteNonQuery ( );
					}
				}

				if (patient.RightEar.Make != "")
				{
					string stmtToUpdateRightHearingAid = string.Format ("UPDATE EarInfo SET Make='" + patient.RightEar.Make + "', Model='" + patient.RightEar.Model +
						"', Serial='" + patient.RightEar.Serial + "', FitDate='" + DateTimeToSQLite (patient.RightEar.FitDate) + "', Style='" +
						Enum.GetName (typeof (StyleOfHearingAid), patient.RightEar.Style) + "' WHERE PatientID='" + patient.ID + "' AND SideOfHead='R'");

					/*put in a using statement so that it will dispose of it afterwards whether if it fails or not,
					 * maybe consider doing a try finally here assuming we need to dispose of something*/
					using (SQLiteCommand sqlQuery = new SQLiteCommand (stmtToUpdateRightHearingAid, _dbConnection))
					{
						sqlQuery.ExecuteNonQuery ( );
					}
				}
			}
	    }

		// Converts the .NET DateTime structure into proper format for being recognized by SQLite
		private static string DateTimeToSQLite (DateTime datetime)
		{
			return string.Format ("{0:s}", datetime);
		}
    }
}
