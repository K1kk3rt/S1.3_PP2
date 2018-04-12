using System;

namespace Opgave2
{
    class Program
    {
        static void Main(string[] args)
        {
            //maak matrix met 8 rijen en 10 kolommen
            int aantalRijen = 8;
            int aantalKolommen = 3;
            int[,] matrix = new int[aantalRijen, aantalKolommen];
            int kolom = 1;

            VulMatrix(matrix);
            ToonMatrix(matrix);
            GetallenLatenVallen(matrix, kolom);

            Console.WriteLine("Gevallen Matrix met puntjes: ");
            ToonMatrix(matrix);

            VerwijderLegeRuimtes(matrix, kolom);

            Console.WriteLine("Gevallen Matrix met verwijderde lege ruimtes: ");
            ToonMatrix(matrix);

            Console.ReadKey();
        }

        static void VulMatrix(int[,] matrix)
        {
            //Vul 2D array met random waardes
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Random random = new Random();
                    int waarde = random.Next(1, 100);
                    matrix[x, y] = waarde;
                }
            }
        }

        static void ToonMatrix(int[,] matrix)
        {
            //Print 2D array
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    string waarde = matrix[x, y].ToString();

                    //wanneer een veld 0 is, maak er een . van 
                    if (matrix[x,y] == 0)
                    {
                        waarde = ".";
                    }
                    Console.Write("{0,-2} ", waarde);
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        static void GetallenLatenVallen(int[,] matrix, int kolom)
        {
            //laat van elke kolom de hogere getallen naar beneden vallen, en daarmee de kleinere verwijderen

            //doorloop rijen vanaf de 1e tm de een na laatste rij
            for (int x = 0; x < matrix.GetLength(1); x++)
            {
                for (int y = 0; y < kolom-1; y++)
                {
                    //controleer of het getal groter is dan het getal er onder. 
                    //if true, getal van huidige cel komt in cel eronder, huidige cel wordt 0
                    if(matrix[x,y] < matrix[x + 1, y])
                    {
                        matrix[x + 1, y] = matrix[x, y];
                        matrix[x, y] = 0;
                    }
                }
            }
        }

        static void VerwijderLegeRuimtes(int[,] matrix, int kolom)
        {
            //lege ruimtes worden opgevult met de getallen erboven.
            int laagsteLegeRij = -1;

            for (int y = matrix.GetLength(1); y > 0; y--)
            {
                if(matrix[y,kolom] == 0)
                {
                    laagsteLegeRij = matrix[y,kolom];
                }
                else
                {
                    if (laagsteLegeRij != 0)
                    {
                        matrix[y, kolom] = laagsteLegeRij;
                        laagsteLegeRij--;
                    }
                }
            }
        }

        static void VerwerkMatrix(int[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(1); x++)
            {
                GetallenLatenVallen(matrix, x);
                VerwijderLegeRuimtes(matrix, x);
            }
        }
    }
}
