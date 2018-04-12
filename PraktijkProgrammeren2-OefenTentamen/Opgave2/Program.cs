using System;

namespace Opgave2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[5,10];

            VulMatrix(matrix);
            ToonMatrix(matrix);
            Console.WriteLine("Geef een getal: ");
            int zoekGetal = Int32.Parse(Console.ReadLine());
            VerschuifMatrix(matrix, zoekGetal);
            ToonMatrix(matrix);


            Console.ReadKey();
        }

        static void VulMatrix (int [,] matrix)
        {
            Random random = new Random();

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    matrix[x, y] = random.Next(1, 100);
                }
            }
        }

        static void ToonMatrix (int[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write("{0,2} ", matrix[x, y]);
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        static void VerschuifMatrix(int[,] matrix, int zoekGetal)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                int y = i % matrix.GetLength(1);
                int x = i / matrix.GetLength(1);

                if (matrix[x, y].Equals(zoekGetal))
                {
                    VerschuifRij(matrix, x, y);
                }
            }
        }

        static void VerschuifRij(int[,] matrix, int rij, int kolom)
        {
            int[] matrix1D = new int[matrix.GetLength(1)];

            for (int i = 0; i < matrix1D.Length; i++)
            {
                matrix1D[i] = matrix[rij, kolom];
                kolom++;
                if (kolom == matrix1D.Length)
                {
                    kolom = 0;
                }
            }

            for (int i = 0; i < matrix1D.Length; i++)
            {
                matrix[rij, i] = matrix1D[i];
            }
        }
    }
}
