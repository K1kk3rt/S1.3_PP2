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
            int[,] matrix = new int[12,12];

            int min = 0;
            int max = 82;

            //int zoekgetal = 0;
            Positie coordinaten = new Positie();

            InitMatrixRandom(matrix, min, max);
            PrintMatrix(matrix);

            int zoekgetal = VraagZoekGetal();
            coordinaten = ZoekGetal1(matrix, zoekgetal, coordinaten);
            PrintZoekGetal1(coordinaten, zoekgetal);
            coordinaten = ZoekGetal2(matrix, zoekgetal, coordinaten);
            PrintZoekGetal2(coordinaten, zoekgetal);

            //PrintZoekGetal(ZoekGetal(matrix, VraagZoekGetal()));


            Console.ReadKey();
        }

        public struct Positie
        {
            public int rij;
            public int kolom;
        }

        static void InitMatrix2D(int[,] matrix)
        {
            int inputGetal = 1;

            for (int hIndex = 0; hIndex < matrix.GetLength(0); hIndex++)
            {
                for (int vIndex = 0; vIndex < matrix.GetLength(1); vIndex++)
                {
                    matrix[hIndex, vIndex] = inputGetal;
                    inputGetal++;
                }
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int hIndex = 0; hIndex < matrix.GetLength(0); hIndex++)
            {
                for (int vIndex = 0; vIndex < matrix.GetLength(1); vIndex++)
                {
                    Console.Write("{0,4} ", matrix[hIndex, vIndex]);
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        static void InitMatrixLineair(int[,] matrix)
        {

            for (int i = 0; i < matrix.Length; i++)
            {
                int y = i % matrix.GetLength(1);
                int x = i / matrix.GetLength(1);
                matrix[x, y] = i + 1;

            }

            //ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Blue };
            //colors[(int)currentandy];
        }

        static void PrintMatrixWithCross(int[,] matrix)
        {
            for (int hIndex = 0; hIndex < matrix.GetLength(0); hIndex++)
            {
                for (int vIndex = 0; vIndex < matrix.GetLength(1); vIndex++)
                {
                    if ((hIndex == matrix.GetLength(0) / 2) && (vIndex == matrix.GetLength(1) / 2))
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0,4} ", matrix[hIndex, vIndex]);
                    }
                    else
                    {
                        if (hIndex == vIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0,4} ", matrix[hIndex, vIndex]);
                        }
                        else
                        {
                            if (hIndex + vIndex == (matrix.GetLength(0) - 1))
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write("{0,4} ", matrix[hIndex, vIndex]);
                            }
                            else
                            {
                                Console.ResetColor();
                                Console.Write("{0,4} ", matrix[hIndex, vIndex]);
                            }

                        }
                    }

                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        static void InitMatrixRandom(int[,] matrix, int min, int max)
        {
            Random random = new Random();

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    matrix[x, y] = random.Next(min, max);
                }
            }
        }

        static int VraagZoekGetal()
        {
            Console.WriteLine("Geef zoekgetal: ");
            int zoekGetal = Int32.Parse(Console.ReadLine());

            return zoekGetal;
        }

        static void PrintZoekGetal1(Positie coordinaten, int zoekGetal)
        {
            Console.WriteLine("Zoekgetal {0} komt het eerst voor op positie [{1},{2}]", zoekGetal, coordinaten.rij, coordinaten.kolom);
        }

        static void PrintZoekGetal2(Positie coordinaten, int zoekGetal)
        {
            Console.WriteLine("Zoekgetal {0} komt het laatst voor op positie [{1},{2}]", zoekGetal, coordinaten.rij, coordinaten.kolom);
        }

        static Positie ZoekGetal1(int[,] matrix, int zoekGetal, Positie coordinaten)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                int y = i % matrix.GetLength(1);
                int x = i / matrix.GetLength(1);

                if (matrix[x, y].Equals(zoekGetal))
                {
                    coordinaten.rij = x;
                    coordinaten.kolom = y;
                    return coordinaten;
                }
            }
            return coordinaten;
        }

        static Positie ZoekGetal2(int[,] matrix, int zoekGetal, Positie coordinaten)
        {

            for (int x = matrix.GetLength(0); x > 0; x--)
            {
                for (int y = matrix.GetLength(1); y > 0; y--)
                {
                    if (matrix[x-1, y-1].Equals(zoekGetal))
                    {
                        coordinaten.rij = x-1;
                        coordinaten.kolom = y-1;
                        return coordinaten;
                    }
                }
            }
            return coordinaten;
        }

        static void InitMatrixReverse(int[,] matrix)
        {
            int inputGetal = 1;

            for (int x = matrix.GetLength(0);x > 0; x--)
            {
                for (int y = matrix.GetLength(1); y > 0; y--)
                {
                    matrix[x-1, y-1] = inputGetal;
                    inputGetal++;
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

        }
    }
}
