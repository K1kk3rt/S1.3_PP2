using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace GalgjeDAL
{

    public struct WoordenDAL
    {
        private static string connString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        

        public static string GetRandom()
        {
            SqlConnection dbConnection = new SqlConnection(connString);
            dbConnection.Open();

            string sqlQuerly = "SELECT TOP 1 * FROM Woorden ORDER BY NEWID()";
            SqlCommand command = new SqlCommand(sqlQuerly, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            string DBwoord = "";

            
            while (reader.Read())
            {
                DBwoord = ReadWoord(reader);

            }
            reader.Close();
            dbConnection.Close();

            return DBwoord;
        }

        public static string ReadWoord(SqlDataReader reader)
        {
            //hulp methode voor inlezen van een woord uit een SqlDataReader

            //haal gegevens op
            string woord = (string) reader["Woord"];

            return woord;
        }
    }
}