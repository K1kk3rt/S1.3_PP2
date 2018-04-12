using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_0
{
    class Program
    {
        static void Main()
        {
            int getal = LeesInt("tik een getal: ");
            Console.WriteLine("Je hebt {0} ingetikt.", getal);

            int leeftijd = LeesInt("Hoe oud ben je? ", 0, 120);
            Console.WriteLine("Je bent {0} jaar oud.", leeftijd);

            string naam = LeesString("Hoe heet je? ");
            Console.WriteLine("Aangenaam kennins met je te maken, {0}.", naam);

            Console.ReadKey();

        }

        static int LeesInt (string vraag)
        {
            int getal = Int32.Parse(Console.ReadLine());
            return getal;
        }

        static int LeesInt( string vraag, int min, int max)
        {
            int leeftijd = Int32.Parse(Console.ReadLine());
            return leeftijd;
        }

        static string LeesString(string vraag)
        {
            string naam = Console.ReadLine();
            return naam;
        }

    }
}
