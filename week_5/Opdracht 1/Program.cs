using System;
using System.IO;

namespace Opdracht_1
{

    public struct Persoon
    {
        public string naam;
        public string woonplaats;
        public int leeftijd;
        public bool isBekend;
    }


    class Program
    {
        static void Main(string[] args)
        {
            string bestandsNaam = "..\\..\\..\\output.txt";

            Persoon p = LeesNaam(bestandsNaam);

            if (p.isBekend)
            {
                ToonPersoon(p, bestandsNaam);
            }
            else
            {
                p = LeesPersoon(p);
                SchrijfPersoon(p, bestandsNaam);
            }

            Console.ReadKey();
        }

        static Persoon LeesNaam(string bestandsNaam)
        {
            Persoon p = new Persoon();

            Console.WriteLine("Naam: ");
            p.naam = Console.ReadLine();

            //open file

            using (StreamReader reader = File.OpenText(bestandsNaam))
            {
                string[] bestand = File.ReadAllLines(bestandsNaam);
                p.isBekend = false;

                for (int i = 0; i < bestand.Length -1; i++)
                {
                    if (p.naam == bestand[i])
                    {
                        p.isBekend = true;
                        Console.WriteLine("Welkom terug! Dit weten we over jou");
                        break;
                    }
                }
                if (!p.isBekend)
                {
                    Console.WriteLine("Ik ken jou niet, vul je shit in!");
                }
            }
            return p;
        }

        static void ToonPersoon(Persoon p, string bestandsNaam)
        {
            using (StreamReader reader = File.OpenText(bestandsNaam))
            {
                string[] bestand = File.ReadAllLines(bestandsNaam);

                for (int i = 0; i < bestand.Length - 1; i++)
                {
                    if (p.naam == bestand[i])
                    {
                        string naam = reader.ReadLine();
                        Console.Write("Naam: " + naam);
                        string woonplaats = reader.ReadLine();
                        Console.Write("Woonplaats: " + woonplaats);
                        int leeftijd = Int32.Parse(reader.ReadLine());
                        Console.Write("Leeftijd: " + leeftijd);
                        break;
                    }
                }
            } 
        }

        static void SchrijfPersoon (Persoon p, string bestandsNaam)
        {

            //open file
            StreamWriter writer = new StreamWriter(bestandsNaam);

            //schrijf alle regels (van de gebruiker) naar de file
            writer.WriteLine(p.naam);
            writer.WriteLine(p.woonplaats);
            writer.WriteLine(p.leeftijd);

            //sluit file
            writer.Close();

            Console.WriteLine("Opgeslagen!");
        }

        static Persoon LeesPersoon(Persoon P)
        {
            Persoon p = new Persoon();

            Console.Write("Naam: ");
            p.naam = Console.ReadLine();

            Console.Write("Woonplaats: ");
            p.woonplaats = Console.ReadLine();

            Console.Write("Leeftijd: ");
            p.leeftijd = Int32.Parse(Console.ReadLine());

            return p;
        }
    }
}
