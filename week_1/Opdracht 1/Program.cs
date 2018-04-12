using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Maand printmaand = PrintMaand(Maand);
        }

        static void PrintMaand(Maand maand)
        {
            for (Maand m = Maand.januari; m <= Maand.december; m++)
            {
                Console.WriteLine(m);
            }
        }

        public enum Maand
        {
            januari, februari, maart, april, mei, juni, juli, augustus, september, oktober, november, december
        }
    }
}
