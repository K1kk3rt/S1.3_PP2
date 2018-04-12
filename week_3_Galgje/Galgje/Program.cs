using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Opdracht_2
{
    using GalgjeLogica;
    using GalgjeDAL;

    class Program
    {
        static void Main(string[] args)
        {
            //Maak 'galgje' van type galgjespel (struct in Galgjespel.cs)
            Galgjespel galgje;

            //Selecteert geheimewoord mbv method selecteerwoord, definieert geradenwoord, zet geradenwoord in puntjes.
            galgje.geheimwoord = WoordenStruct.SelecteerWoord();
            galgje.geradenwoord = "";
            galgje.Init();

            //als SpeelGalgje true returnt, print je hebt gewonnen
            if (true == SpeelGalgje(galgje))
            {
                Console.WriteLine("je hebt gewonnen!");
                Console.WriteLine("Het woord was: " + galgje.geheimwoord);
            }



            Console.ReadKey();
        }



        static bool SpeelGalgje(Galgjespel galgje)
        {
            //method speelt het hele galgje spel

            //initialize variables
            string woord = galgje.geheimwoord;
            char Letter = ' ';
            int spelpogingen = galgje.geheimwoord.Length + (galgje.geheimwoord.Length / 3);

            ///LOOP MAKEN, ALLES DAT NIET EEN LETTER VAN HET ALPHABET IS, PRINT LINE EN DOE ALLES OPNIEUW
            //Maak een list met verboden letters en voeg deze toe
            List<char> verbodenLetters = new List<char>();
            verbodenLetters.Add('/');
            verbodenLetters.Add('%');
            verbodenLetters.Add(')');
            verbodenLetters.Add('(');


            List<char> ingevoerdeLetters = new List<char>();

            //Speel galgje zo lang er nog spelpogingen zijn
            while (spelpogingen > 0)
            {
                ToonWoord(woord, galgje);
                LeesLetter(verbodenLetters, ingevoerdeLetters, ref Letter);
                ToonLetters(ingevoerdeLetters);
                galgje.RaadLetter(Letter);

                //als de letter niet overeenkomt, gaat er een spelpoging af
                if (false == galgje.RaadLetter(Letter))
                {
                    spelpogingen = spelpogingen - 1;
                }
                Console.WriteLine("Aantal pogingen: {0}", spelpogingen);

                ///MAAK DIT NETTER IN APARTE METHOD
                //als galgje is geraden return true, in de main wordt gewonnen geschreven
                if (galgje.isGeraden())
                {
                    return true;
                }
            }
            ///MAAK DIT OOK NETTER IN APARTE METHOD
            //Als je geen spelpogingen meer over hebt, return false en print je hebt verloren
            if (spelpogingen == 0)
            {
                Console.WriteLine("je hebt verloren");
                Console.WriteLine("Het woord was: " + galgje.geheimwoord);
                return false;
            }
            return false;
        }

        static void ToonWoord(string woord, Galgjespel galgje)
        {
            //method toont het geradenwoord

            // Console.WriteLine("Het geheime woord is: {0}", woord); //voor troubleshooting
            Console.WriteLine("Het geraden woord is: {0}", galgje.geradenwoord);
        }

        static void ToonLetters(List<char> ingevoerdeLetters)
        {
            //method toont de ingevoerde letters uit list ingevoerdeletters (aangemaakt in speelgalgje)
            Console.Write("De ingevoerde letters zijn: ");
            for (int i = 0; i < ingevoerdeLetters.Count; i++)
            {
                Console.Write(ingevoerdeLetters[i] + " ");
            }
            Console.WriteLine("\n");

        }

        static char LeesLetter(List<char> verbodenLetters, List<char> ingevoerdeLetters, ref char Letter)
        {
            ///VERBODEN LETTERS ZIJN ALLES BEHALVE HET ALPHABET
            ///VERPLAATS METHOD NAAR GALGJELOGICA
            //leest ingevoerde letter en bepaalt of het een verboden letter is. Anders wordt ie gereturnt naar Speelgalgje()
            Console.Write("Geef een letter: ");


            Letter = char.Parse(Console.ReadLine());
            char leeg = ' ';
            Console.Write("\n");


            if (verbodenLetters.Contains(Letter) == true)
            {
                return leeg;
            }
            else
            {
                ingevoerdeLetters.Add(Letter);

                return Letter;
            }
        }
    }
}
