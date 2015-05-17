using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PatientResultsSystem.Models
{
	public static class UserDatabaseHelper
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
        // Method to find the user with the specified credentials in the database. Return NULL if not found.
        //
        public static User FindUser(string userName, string password)
        {
            // Query the Users database table for the userName
	        if (_dbConnection != null)
	        {
		        string queryString = string.Format("SELECT * FROM Users WHERE Username='{0}'", userName);
		        using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
		        {
			        SQLiteDataReader reader = sqlQuery.ExecuteReader();

			        while (reader.Read())
			        {
				        if (reader["Password"].Equals(EncryptPassword(password)))
				        {
					        if (reader["UserType"].Equals("administrator"))
					        {
						        return new User((string) reader["Username"], UserTypes.Administrator,
									(string) reader["FirstName"], (string) reader["LastName"]);
					        }

							if (reader["UserType"].Equals("clinician"))
							{
								return new User((string) reader["Username"], UserTypes.Clinician,
									(string) reader["FirstName"], (string) reader["LastName"]);
							}
				        }
			        }
		        }
	        }

	        return null;
        }


        //method to attempt to add a new user to the database. takes in a User object and the proposed clear text
        //unhashed password of the new user.  if the method is successful it returns true. it returns false if it fails.
        public static bool AddUser(User user, string password)
        {
            if (CheckUserNames(user.UserName))
            {
                if (_dbConnection != null)
                {
	                string userType = (user.Type == UserTypes.Administrator) ? "administrator" : "clinician";

                    string stmtToInsertUser = string.Format("INSERT INTO Users Values('" + user.UserName + "','" + 
                        EncryptPassword(password) + "','" + user.FirstName + "','" + user.Lastname + "','" + 
                        userType + "')");

                    using (SQLiteCommand sqlQuery = new SQLiteCommand(stmtToInsertUser, _dbConnection))
                    {
                        sqlQuery.ExecuteNonQuery();
                    }
                    return true; //added user to database successfully
                }
            }
            return false; //failed because no database connection or username is already in use
        }

        //method to delete user from database.  pass in a user object. method returns true if delete was successful
        //method returns false if method failed to perform delete.
        public static bool DeleteUser(User user)
        {
            if (!(CheckUserNames(user.UserName))) //check if user exists in database
            {
                if (_dbConnection != null)
                {
                    string stmtToDeleteUser = string.Format("DELETE FROM Users WHERE Username = '" + user.UserName + "')");
                    using (SQLiteCommand sqlQuery = new SQLiteCommand(stmtToDeleteUser, _dbConnection))
                    {
                        sqlQuery.ExecuteNonQuery();
                    }
                    return true; //deleted user from database successfully
                }
            }
            return false; //return false if could not find that user in the database or no database connection found
        }

        //method to get all the usernames from the database to test if the new user
        //being created has a unique username. returns true if the proposed username is 
        //not already being used in the database
        public static bool CheckUserNames(string username)
        {
            // Query the Users database table for all usernames
            if (_dbConnection != null)
            {
                string name = "";
                string queryString = string.Format("SELECT * FROM Users");
                using (SQLiteCommand sqlQuery = new SQLiteCommand(queryString, _dbConnection))
                {
                    SQLiteDataReader reader = sqlQuery.ExecuteReader();

                    while (reader.Read())
                    {
                        name = (string)reader["Username"];
                        if (username == name)
                        {
                            return false; //proposed username is the same as a username in the table
                        }
                    }
                }
                return true; //no usernames found in the table that match the proposed username
            }
            return false; //no database connection
        }


        //Method to convert strings entered as passwords to MD5 encrypted strings
        //This is for testing passwords entered against encrypted passwords in the database
        public static string EncryptPassword(string password)
        {
            string hash = ""; //empty string which will store the hex md5 encryption of the password later
            byte[] textToBytes; //byte array to store the bytes returned after the conversion
            MD5 algorithm = MD5.Create( ); //md5 algorithm object created to encrypt strings

            textToBytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password)); //password encrypted and stored as byte array
            hash = BitConverter.ToString(textToBytes).Replace("-", ""); //byte array converted into a hex string to store in db

            return hash; //returning the encrypted hex string to test against the encrypted passwords in the db
        }
    }
}
