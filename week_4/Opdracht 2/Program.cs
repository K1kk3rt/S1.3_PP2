using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_2
{
    //using CandyCrusher;
    class Program
    {
        //enum RegularCandies
        //{
        //    JellyBean, Lozenge, LemonDrop, GumSquare, LollipopHead, JujubeCluster
        //}

        static void Main(string[] args)
        {
            CandyCrusherLogica.CandyCrusher.RegularCandies[,] speelveld = new CandyCrusherLogica.CandyCrusher.RegularCandies[9, 9];

            InitCandies(speelveld);
            PrintCandies(speelveld);
            if (CandyCrusherLogica.CandyCrusher.ScoreRijAanwezig(speelveld))
            {
                Console.ResetColor();
                Console.WriteLine("Ja, er is een score rij aanwezig");
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("Nee, er is geen score rij aanwezig");
            }
            if (CandyCrusherLogica.CandyCrusher.ScoreKolomAanwezig(speelveld))
            {
                Console.ResetColor();
                Console.WriteLine("Ja, er is een score kolom aanwezig");
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("Nee, er is geen score kolom aanwezig");
            }


            Console.ReadKey();
        }

        static void InitCandies(CandyCrusherLogica.CandyCrusher.RegularCandies[,] speelveld)
        {
            Random randomCandy = new Random();


            for (int x = 0; x < speelveld.GetLength(0); x++)
            {
                for (int y = 0; y < speelveld.GetLength(1); y++)
                {
                    speelveld[x, y] = (CandyCrusherLogica.CandyCrusher.RegularCandies)randomCandy.Next(0, 6);
                }
            }
        }

        static void PrintCandies(CandyCrusherLogica.CandyCrusher.RegularCandies[,] speelveld)
        {
            string candy = "";

            for (int x = 0; x < speelveld.GetLength(0); x++)
            {
                for (int y = 0; y < speelveld.GetLength(1); y++)
                {
                    switch (speelveld[x, y])
                    {
                        case CandyCrusherLogica.CandyCrusher.RegularCandies.JellyBean:
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Red;
                            candy = "#";
                            break;
                        case CandyCrusherLogica.CandyCrusher.RegularCandies.Lozenge:
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            candy = "#";
                            break;
                        case CandyCrusherLogica.CandyCrusher.RegularCandies.LemonDrop:
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            candy = "#";
                            break;
                        case CandyCrusherLogica.CandyCrusher.RegularCandies.GumSquare:
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            candy = "#";
                            break;
                        case CandyCrusherLogica.CandyCrusher.RegularCandies.LollipopHead:
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Blue;
                            candy = "#";
                            break;
                        case CandyCrusherLogica.CandyCrusher.RegularCandies.JujubeCluster:
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            candy = "#";
                            break;
                    }
                    Console.Write("{0,1} ", candy);
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

       
    }
}
