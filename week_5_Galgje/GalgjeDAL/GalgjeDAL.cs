using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace GalgjeDAL
{

    public struct WoordenDAL
    {
        private static string connString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        

        public static string GetRandom(string bestandsNaam)
        {
            string woord = "";

            using (StreamReader reader = File.OpenText(bestandsNaam))
            {
                string[] bestand = File.ReadAllLines(bestandsNaam);

                Random random = new Random();
                int index = random.Next(1, bestand.Length + 1);

                woord = bestand[index];
            }

            return woord;
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