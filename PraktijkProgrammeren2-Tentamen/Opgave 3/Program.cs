using System;
using static Opgave3.MedailleTypeClass;
using static Opgave3.EventMedailleClass;
using System.Collections.Generic;
using System.IO;

namespace Opgave_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string bestand = "..\\..\\..\\OlympicGames-Medals.csv";
            List<EventMedaille> test = LeesMedailles(bestand);
            Console.WriteLine(test);



            Console.ReadKey();
        }

        static List<EventMedaille> LeesMedailles(string bestand)
        {
            List<EventMedaille> medailles = new List<EventMedaille>();

            StreamReader reader = new StreamReader(bestand);

            while (!reader.EndOfStream)
            {
                string regel = reader.ReadLine();
                string[] velden = regel.Split(';');

                EventMedaille medaille = new EventMedaille();
                medaille.sportEvent = velden[0] + "|" + velden[1];
                medaille.country = velden[2];
                medaille.medailleType = (MedailleType)Enum.Parse(typeof(MedailleType), velden[3]);
                medailles.Add(medaille);
            }

            reader.Close();

            return medailles;
        }

        static List<string> AlleSportEvents(List<EventMedaille> eventMedailles)
        {
            List<string> sportOnderdelen = new List<string>();
            for (int i=0; i < eventMedailles.Count; i++)
            {
                if (!sportOnderdelen.Contains(eventMedailles[i].sportEvent))
                {
                    sportOnderdelen.Add(eventMedailles[i].sportEvent);
                    sportOnderdelen.Add(eventMedailles[i].country);
                }
            }

            return sportOnderdelen;
        }

        static void ToonCleanSweeps(List<EventMedaille> eventMedailles)
        {
            List<string> sportOnderdelen = AlleSportEvents(eventMedailles);

            bool cleanSweep = false;

            for (int i = 0; i < sportOnderdelen.Count; i++)
            {
                for (int i = 0; i < eventMedailles.Count; i++)
                {
                    if(eventMedailles[i] != sportOnderdelen[i])
                    {
                        continue;
                    }
                }
            }
        }
    }
}
