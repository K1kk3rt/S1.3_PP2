using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_2
{
    class Program
    {
        struct Persoon {
            public string Voornaam;
            public string Achternaam;
            public int Leeftijd;
            public string Woonplaats;
        }

        static void Main(string[] args)
        {
            Persoon p = LeesPersoon();
            Persoon pp = PrintPersoon(); 

            Console.ReadKey();
        }

        static Persoon LeesPersoon()
        {
            Persoon p;

            Console.WriteLine("Voornaam: ");
            p.Voornaam = Console.ReadLine();
            Console.WriteLine("Achternaam: ");
            p.Achternaam = Console.ReadLine();
            Console.WriteLine("Leeftijd: ");
            p.Leeftijd = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Woonplaats: ");
            p.Woonplaats = Console.ReadLine();

            Console.ReadKey();

            return p;

        }

        static void PrintPersoon (Persoon p)
        {

            Persoon p = p;

            for (Persoon p = Persoon.Voornaam; p <= Persoon.Woonplaats; p++)
            {
                Console.WriteLine(p);
            }
        }
             

}
}
