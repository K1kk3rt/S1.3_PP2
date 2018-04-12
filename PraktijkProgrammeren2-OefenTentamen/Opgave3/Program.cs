using System;
using System.IO;
using System.Collections.Generic;

namespace Opgave3
{
    using Stelling;
    using Partij;

    class Program
    {
        static List<Stelling> stellingen = new List<Stelling>();
        static List<Partij> partijen = new List<Partij>();

        static void Main(string[] args)
        {
            string bestandStellingen = "..\\..\\..\\stellingen.txt";
            string bestandPartijen = "..\\..\\..\\partijen.txt";

            LeesStellingen(bestandStellingen);
            LeesPartijen(bestandPartijen);

            DoorloopStellingen(stellingen);

            Console.ReadKey();
        }

        static List<Stelling> LeesStellingen(string bestand)
        {
            StreamReader reader = new StreamReader(bestand);

            while (!reader.EndOfStream)
            {
                Stelling stelling = new Stelling();
                stelling.titel = reader.ReadLine();
                stelling.tekst = reader.ReadLine();
                stellingen.Add(stelling);
            }

            return stellingen;
        }

        static List<Partij> LeesPartijen(string bestand)
        {
            StreamReader reader = new StreamReader(bestand);

            while (!reader.EndOfStream)
            {
                Partij partij = new Partij();
                partij.naam = reader.ReadLine();
                partij.antwoorden = reader.ReadLine();
                partijen.Add(partij);
            }

            return partijen;
        }

        static string DoorloopStellingen(List<Stelling> stellingen)
        {
            string antwoorden = "";
            int i = 0;
            foreach(Stelling element in stellingen)
            {
                Stelling stelling = new Stelling();
                stelling = stellingen[i];
                Console.ForegroundColor = System.ConsoleColor.Yellow;
                Console.WriteLine(stelling.titel);
                Console.ResetColor();
                Console.WriteLine(stelling.tekst);
                Console.WriteLine();
                Console.Write("Geef uw mening (1=eens / 2=oneens / 3=geen): ");
                antwoorden = antwoorden + Console.ReadLine();
                Console.WriteLine();
                i++;
            }
            return antwoorden;
        }

        static double[] BepaalMatchPercentage(string gebruiker, double[] percentage)
        {
            double[] antwoorden = Array.ConvertAll(gebruiker.Split(','), Double.Parse);
            

            for (int i = 0; i < antwoorden.Length; i++)
            {
                percentage[i] = antwoorden[i] / 30 * 100;
            }

            return percentage;
        }

        static void VergelijkPartijen(string gebruiker, List<Partij> partijen)
        {
            int VVD = 0;
            int PVV = 0;
            int CDA = 0;
            int D66 = 0;
            int GL = 0;
            int SP = 0;
            int PvdA = 0;
            int CU = 0;

            for (int i = 0; i < 30; i++)
            {
                //VDD
                if (gebruiker == partijen[0].antwoorden.Split(' ')[i])
                {
                    VVD++;
                }
                //PVV
                if (gebruiker == partijen[1].antwoorden.Split(' ')[i])
                {
                    PVV++;
                }
                //CDA
                if (gebruiker == partijen[2].antwoorden.Split(' ')[i])
                {
                    CDA++;
                }
                //D66
                if (gebruiker == partijen[3].antwoorden.Split(' ')[i])
                {
                    D66++;
                }
                //GL
                if (gebruiker == partijen[4].antwoorden.Split(' ')[i])
                {
                    GL++;
                }
                //SP
                if (gebruiker == partijen[5].antwoorden.Split(' ')[i])
                {
                    SP++;
                }
                //PvdA
                if (gebruiker == partijen[6].antwoorden.Split(' ')[i])
                {
                    PvdA++;
                }
                //CU
                if (gebruiker == partijen[7].antwoorden.Split(' ')[i])
                {
                    CU++;
                }

            }

            double[] antwoorden = Array.ConvertAll(gebruiker.Split(','), Double.Parse);
            double[] percentage = new double[antwoorden.Length];
            string aantalGelijkeAntwoorden = VVD + " " + PVV + " " + CDA + " " + D66 + " " + GL + " " + SP + " " + PvdA + " " + CU;

            BepaalMatchPercentage(aantalGelijkeAntwoorden, percentage);

            for(int i = 0; i < percentage.Length; i++)
            {
                Console.WriteLine(partijen[i].naam + ": " + percentage[i] + " % ");
            }
        }
    }
}
