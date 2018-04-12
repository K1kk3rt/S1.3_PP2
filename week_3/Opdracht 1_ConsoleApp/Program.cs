using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1_ConsoleApp
{
    using MyTools;

    class Program
    {
        static void Main(string[] args)
        {
            
            int getal = LeesTools.LeesInt("tik een getal: ");
            Console.WriteLine("Je hebt {0} ingetikt.", getal);

            int leeftijd = LeesTools.LeesInt("Hoe oud ben je? ", 0, 120);
            Console.WriteLine("Je bent {0} jaar oud.", leeftijd);

            string naam = LeesTools.LeesString("Hoe heet je? ");
            Console.WriteLine("Aangenaam kennins met je te maken, {0}.", naam);
             
            Console.ReadKey();
        }
    }
}
