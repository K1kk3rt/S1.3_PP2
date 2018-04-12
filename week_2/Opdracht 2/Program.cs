using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //maak list vakken
            Vak[] vakken = new Vak[3];

            //maak list rapport, en vul  3x met naam van vak (met behulp van de method leesvak
            List<Vak> rapport = new List<Vak>();
            rapport.Add(LeesVak("Naam van het vak: "));
            rapport.Add(LeesVak("Naam van het vak: "));
            rapport.Add(LeesVak("Naam van het vak: "));

            ToonRapport(rapport);
            HoeveelHerkansingen(rapport);

            Console.ReadLine();
        }

        static Beoordeling LeesBeoordeling(string vraag)
        {
            //method vraagt en leest beoordeling. wordt in method LeesVak() in struct vak.Beoordeling gezet

            Console.WriteLine("0. Geen  1. Absent  2. Onvoldoende  3. Voldoende  4. Goed");
            Console.Write(vraag);
            string vak = Console.ReadLine();
            
            Beoordeling n = (Beoordeling)int.Parse(vak);
            return n;
        }

        static Vak LeesVak(string vraag)
        {
            //vraagt en leest het vak, en zet het in de stuct
            Vak vak = new Vak();

            Console.WriteLine("Voer een vak in.");
            vak.naam = LeesString("Naam van het vak: ");
            vak.cijfer = LeesInt("Cijfer voor het vak " + vak.naam + ": ");

            vak.Beoordeling = LeesBeoordeling("Practicumbeoordeling voor " + vak.naam + ": ");

            return vak;
        }

        static void ToonRapport(List<Vak> rapport)
        {
            //method toont rapport op t scherm, voor elk rapport in de method
            foreach (Vak v in rapport)
            {
                Console.Write(v.naam + "   :   " + v.cijfer + "   ");
                ToonBeoordeling(v.Beoordeling);
            }

        }

        static void HoeveelHerkansingen(List<Vak> rapport)
        {
            //method berekent hoeveel herkansingen er zijn
            bool isGeslaagd = true;
            int count = 0;
            int cumLaudeCount = 0;

            foreach (Vak v in rapport)
            {
                if (!v.IsBehaald())
                {
                    isGeslaagd = false;
                    count = count + 1;

                }

                if (v.IsCumLaude())
                {
                    cumLaudeCount = cumLaudeCount + 1;
                }
            }

            if (cumLaudeCount == 3)
            {
                Console.WriteLine("Gefeliciteerd je bent cumlaude geslaagd!");
            }

            if (count == 0)
            {
                Console.WriteLine("Je hebt geen herkansingen!");
            }

            else
            {
                Console.WriteLine("Helaas je bent gezakt en hebt " + count + " herkansing(en)");
            }

        }

        static void ToonBeoordeling(Beoordeling oordeel)
        {
            //method toont beoordeling
            Console.WriteLine(oordeel);
        }


        static string LeesString(string vraag)
        {
            //Leest naam van het vak
            Console.Write("{0}", vraag);
            return Console.ReadLine();
        }

        static int LeesInt(string vraag)
        {
            //Leest cijfer
            Console.Write("{0}", vraag);
            return Int32.Parse(Console.ReadLine());
        }

        


    }
}
