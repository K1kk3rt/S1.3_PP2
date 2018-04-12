using System;
using System.IO;
using System.Linq;

namespace Opdracht_3
{
    class Program
    {
        static string bestandsNaam = "..\\..\\..\\2014-co2-emissions.csv";
        static string regel = "";


        static void Main(string[] args)
        {

            string woord = VraagWoord();

            if (ZitWoordInRegel(woord, regel))
            {
                Console.WriteLine();
                int aantalRijen = ZoekWoordInBestand(woord);
                ToonWoordInRegel(woord);
                Console.WriteLine();
                Console.WriteLine("Aantal reels met zoekwood: " + aantalRijen);
                Console.WriteLine("Zoekwoord komt voor op: " + regel);
            }
            else
            {
                Console.WriteLine("Helaas, niks gevonden... Type ff wat anders in ofzo!!");
            }

            Console.ReadKey();
        }

        static string VraagWoord()
        {
            Console.Write("Geef het zoekwoord: ");
            string woord = Console.ReadLine();

            return woord;

        }

        static bool ZitWoordInRegel(string woord, string regel)
        {
            bool woordInRegel = false;

            using (StreamReader reader = File.OpenText(bestandsNaam))
            {
                string[] bestand = File.ReadAllLines(bestandsNaam);

                for (int i = 0; i < bestand.Length - 1; i++)
                {
                    if(System.Text.RegularExpressions.Regex.IsMatch(bestand[i], woord, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    //if (bestand[i].Contains("woord", StringComparison.OrdinalIgnoreCase))
                    {
                        woordInRegel = true;
                    }
                }
            }

            return woordInRegel;
        }

        static int ZoekWoordInBestand(string woord)
        {
            int aantalRijen = 0;

            using (StreamReader reader = File.OpenText(bestandsNaam))
            {
                string[] bestand = File.ReadAllLines(bestandsNaam);

                for (int i = 0; i < bestand.Length; i++)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(bestand[i], woord, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    //if (bestand[i].Contains("woord", StringComparison.OrdinalIgnoreCase))
                    {
                        aantalRijen++;
                        regel = regel + i + ", ";
                    }
                }
            }
            return aantalRijen;
        }

        static void ToonWoordInRegel(string woord)
        {
            using (StreamReader reader = File.OpenText(bestandsNaam))
            {
                string[] bestand = File.ReadAllLines(bestandsNaam);

                for (int i = 0; i < bestand.Length; i++)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(bestand[i], woord, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    //if (bestand[i].Contains("woord", StringComparison.OrdinalIgnoreCase))
                    {
                        int woordLocatie = bestand[i].IndexOf(woord, StringComparison.CurrentCultureIgnoreCase);
                        string zoekWoord = bestand[i].Substring(woordLocatie);

                        var punctuation = zoekWoord.Where(char.IsPunctuation).Distinct().ToArray();
                        var words = zoekWoord.Split().Select(x => x.Trim(punctuation));

                        //if (zoekWoord == words)
                        //{

                        //}

                        Console.WriteLine(bestand[i]);
                    }
                }
            }
        }
    }
}
