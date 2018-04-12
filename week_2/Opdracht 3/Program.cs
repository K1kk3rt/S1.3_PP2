using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Maakt list voor woordenlijst, voegt woorden toe aan list
            List<string> WoordenLijst = new List<string>();
            WoordenLijstMethode(WoordenLijst);
            string selecteerwoord = " ";

            //Maak 'galgje' van type galgjespel (struct in Galgjespel.cs)
            Galgjespel galgje;
            
            //Selecteert geheimewoord mbv method selecteerwoord, definieert geradenwoord, zet geradenwoord in puntjes.
            galgje.geheimwoord = SelecteerWoord(WoordenLijst, selecteerwoord) ;
            galgje.geradenwoord = "";
            galgje.Init();

            //als SpeelGalgje true returnt, print je hebt gewonnen
            if (true == SpeelGalgje(galgje))
            {
                Console.WriteLine("je hebt gewonnen!");               
            }
          


            Console.ReadKey();
        }

        static List<string> WoordenLijstMethode(List<string>WoordenLijst)
        {
            //Method met woordenlijst voor het galgjespel, returnt list met woorden naar main
            WoordenLijst.Add("pindakaaspot");
            WoordenLijst.Add("grafsteen");
            WoordenLijst.Add("voorbips");
            WoordenLijst.Add("backspace");
            WoordenLijst.Add("basilicum");

            WoordenLijst.Add("worstenbroodje");
            WoordenLijst.Add("vierkantsknoop");
            WoordenLijst.Add("brilpoetsdoekje");
            WoordenLijst.Add("caravandeur");
            WoordenLijst.Add("bloementjesgordijn");

            WoordenLijst.Add("koffiekopje");
            WoordenLijst.Add("olympische");
            WoordenLijst.Add("draaideur");
            WoordenLijst.Add("kraanwater");
            WoordenLijst.Add("rolstoel");

            WoordenLijst.Add("bejaarde");
            WoordenLijst.Add("chocoladekoekjes");
            WoordenLijst.Add("powerpoint");
            WoordenLijst.Add("streepjesbroek");
            WoordenLijst.Add("biertafel");

            return WoordenLijst;
        }

        static string SelecteerWoord(List<string>WoordenLijst, string selecteerwoord)
        {
            //method selecteert random woord uit de list en returnt deze naar main
            Random rnd = new Random();
            int i = rnd.Next(1, 20);
            selecteerwoord = WoordenLijst[i];
            return selecteerwoord;
        }

        static bool SpeelGalgje (Galgjespel galgje)
        {
            //method speelt het hele galgje spel

            //initialize variables
            string woord = galgje.geheimwoord;
            char Letter = ' ';
            int spelpogingen = 8;

            //Maak een list met verboden letters en voeg deze toe
            List<char> verbodenLetters = new List<char>();
            verbodenLetters.Add('/');
            verbodenLetters.Add('%');
            verbodenLetters.Add(')');
            verbodenLetters.Add('(');  
            
            //Maak een list met ingevoerde letters
            List<char> ingevoerdeLetters = new List<char>();
            
            //Speel galgje zo lang er nog spelpogingen zijn
            while(spelpogingen > 0)
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
                //als galgje is geraden return true, in de main wordt gewonnen geschreven
                if (galgje.isGeraden())
                {
                    return true;
                }
            }
            
            //Als je geen spelpogingen meer over hebt, return false en print je hebt verloren
            if (spelpogingen == 0)
                {
                    Console.WriteLine("je hebt verloren");
                    return false;
                }
            return false;
        }

        static void ToonWoord(string woord, Galgjespel galgje)
        {
            //method toon het geradenwoord
           
            // Console.WriteLine("Het geheime woord is: {0}", woord); //voor troubleshooting
            Console.WriteLine("Het geraden woord is: {0}", galgje.geradenwoord);
        }

        static void ToonLetters(List<char> ingevoerdeLetters)
        {
            //method toont de ingevoerde letters uit list ingevoerdeletters (aangemaakt in speelgalgje)
            Console.Write("De ingevoerde letters zijn: ");
            for (int i= 0; i < ingevoerdeLetters.Count; i++)
            {
                Console.Write(ingevoerdeLetters[i] + " ");
            } 
            Console.WriteLine("\n");
            
        }

        static char LeesLetter(List<char> verbodenLetters, List<char> ingevoerdeLetters, ref char Letter)
        {
            //leest ingevoerde letter en bepaalt of het een verboden letter is. Anders wordt ie gereturnt naar Speelgalgje()
            Console.Write("Geef een letter: ");

            Letter = char.Parse(Console.ReadLine());
            char leeg = ' ';
                        

            if (verbodenLetters.Contains(Letter)== true)
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
