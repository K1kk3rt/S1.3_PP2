using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Opdracht_2
{
    class Program
    {
        static int x = 4;
        static int y = 4;

        static void Main(string[] args)
        {
            CandyCrusherLogica.CandyCrusher.RegularCandies[,] speelveld = new CandyCrusherLogica.CandyCrusher.RegularCandies[x,y];
            string bestandsNaam = "..\\..\\..\\CandyCrush.txt";

            //InitCandies(speelveld);
            //SchrijfSpeelveld(speelveld, bestandsNaam);
            speelveld =  LeesSpeelveld(bestandsNaam);
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
                        case CandyCrusherLogica.CandyCrusher.RegularCandies.error:
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.White;
                            candy = "x";
                            break;
                    }
                    Console.Write("{0,1} ", candy);
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        static void SchrijfSpeelveld (CandyCrusherLogica.CandyCrusher.RegularCandies[,] speelveld, string bestandsNaam)
        {
            using (StreamWriter writer = new StreamWriter(bestandsNaam))
            {
                string output = "";

                for (int i = 0; i < speelveld.GetLength(0); i++)
                {
                    for (int j = 0; j < speelveld.GetLength(1); j++)
                    {
                        output = output +  Convert.ToInt32(speelveld[i, j]).ToString() + " ";
                    }
                    writer.WriteLine(output);
                    output = "";
                }
            }
        }

        static CandyCrusherLogica.CandyCrusher.RegularCandies[,] LeesSpeelveld(string bestandsNaam)
        {
            CandyCrusherLogica.CandyCrusher.RegularCandies[,] output = new CandyCrusherLogica.CandyCrusher.RegularCandies[x,y]; 

            using (StreamReader reader = new StreamReader(bestandsNaam))
            {
                string[] input = File.ReadAllLines(bestandsNaam);

                int i = 0;
                int j = 0;
                foreach (var row in input)
                {
                    j = 0;
                    foreach (var col in row.Trim().Split(' '))
                    {
                        string candy = col.Trim();
                        //int candyI = Int32.Parse(candy);
                        output[i, j] = (CandyCrusherLogica.CandyCrusher.RegularCandies)Enum.Parse(typeof(CandyCrusherLogica.CandyCrusher.RegularCandies), candy);


                        //try
                        //{
                        //}
                        //catch
                        //{
                        //    output[i-1, j] = CandyCrusherLogica.CandyCrusher.RegularCandies.error;
                        //}
                        j++;
                    }
                    i++;
                }
            }

            return output;
        }
    }
}
