using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace HelloWorld
{
	static class DbProxy
	{
		private static SQLiteConnection dbConnection;

		public static bool ConnectToDb(string connectionString)
		{
			try
			{
				dbConnection = new SQLiteConnection(connectionString);
				dbConnection.Open();
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public static string FindStringByName(string name)
		{
			if (dbConnection != null)
			{
				SQLiteCommand query = new SQLiteCommand("SELECT value FROM strings WHERE name='" + name + "'", dbConnection);
				SQLiteDataReader results = query.ExecuteReader( );
				
				if(results.HasRows)
					return results["value"] as string;
			}

			return String.Empty;
		}
	}
}
