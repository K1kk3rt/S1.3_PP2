using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3
{
    class Program
    {
        static void Main()
        {
            Dobbelsteen d1, d2;
            d1.waarde = 0;
            d2.waarde = 0;

            d1.Gooi();
            d2.Gooi();

            d1.ToonWaarde();
            d2.ToonWaarde();

            Console.ReadKey();
        }

        struct Dobbelsteen
        {
            public int waarde;
            static Random rnd = new Random();

            public void Gooi()
            {
                waarde = rnd.Next(1, 7);
            }

            public void ToonWaarde()
            {
                Console.WriteLine(waarde);
            }
        }

        struct YahtzeeGame
        {
            const int dobbelstenen = 5;
            int[] Dobbelsteen = new int[dobbelstenen];
           

            public void Gooi()
            {

            }

        }

    }
}
