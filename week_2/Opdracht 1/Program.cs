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
            //initialize veriables
            double gemiddelde = 0;
            int koudste = 1;
            int uur = koudste / 60;

            //create lists
            List<double> temperaturen = new List<double>();
            List<double> metingen = new List<double>();

            //verwijzingen naar methoden
            MeetTemperaturen(metingen);
            PrintTemperaturen(metingen);
            BerekenGemiddelde(metingen, ref gemiddelde);
            Console.WriteLine("gemiddelde:{0}", gemiddelde.ToString("0.000"));
            ZoekKoudsteMinuut(metingen, ref koudste);
            
            //Schrijf koudste graad
            Console.WriteLine("Koudste graad is:{0} -> {1}", uur.ToString("0.00"), metingen[koudste].ToString("0.000"));

            Console.ReadKey();

        }

        static List<double> MeetTemperaturen(List<double> metingen)
        {
            Random rnd = new Random();

            //van nacht tot nacht (24 uur)
            int aantalMinInDag = 24 * 60;
            double f = (2 * Math.PI) / aantalMinInDag;
            for(int  i = 0; i < aantalMinInDag; i++)
            {
                double x = 1.5 * Math.PI + i * f;
                double temperatuur = 18 + 6 * Math.Sin(x) + rnd.Next(10) / 10.0f;

                metingen.Add(temperatuur);
            }

            //sommige metingen zijn niet geldig
            for (int r = 0; r<10; r++)
            {
                metingen[rnd.Next(aantalMinInDag)] = -999;            
            }            
            return metingen;

        }

        static void PrintTemperaturen(List<double> metingen)
        {
            //method toont van elk heel uur de gemten temperatuur (24 metingen)

            //initialize veriables
            int aantalMinInDag = 24 * 60;

            //doorloop alle 24*60 metingen, print de metingen die op het hele uur zijn gedaan.
            for (int index = 1; index < aantalMinInDag; index++)
            {
                if ((index % 60) != 0)
                {
                    continue;
                }
                int uur = index / 60;
                Console.WriteLine("{0,2}.00 = {1}", uur, metingen[index].ToString("0.000"));
            }
        }

        static double BerekenGemiddelde(List<double> metingen, ref double gemiddelde)
        {
            //method berekent gemiddelde temperatuur

            //telt metingen van het hele uur bij elkaar op, slaat ongeldige metingen over (else {continue})(< -50°C en > +100°C)
            for (int i= 1; i<24*60; i++)
            {
                if ((i % 60) == 0)
                {
                    if ((-50 < metingen[i]) && (metingen[i] < 100))
                    {
                        gemiddelde = gemiddelde + metingen[i];
                    }
                }
                else
                {
                    continue;
                }                
            }
            gemiddelde = gemiddelde / 24;                      
            return gemiddelde;
        }

        static int ZoekKoudsteMinuut (List<double> metingen, ref int koudste)
        {
            //method doorzoektde lijst met metingen naar de laagste temperatuur. de methdoe retourneert de minuut (index)
            //waarop deze koudste temperatuur als eerste gemeten is. De ongeldige metingen worden geskipt (< -50°C en > +100°C)
            //in de main worden het tijdstip en de daarbij behorende laagste tempertuur getoont.

            for (int i=1; i<(24*60); i++)
            {
                if((-50 < metingen[i]) && (metingen[i] < 100))
                {
                    if (metingen[koudste] > metingen[i])
                    {
                        koudste = i;
                    }
                    else
                    {
                        continue;
                    }
                }           
            }
            return koudste;
        }

    }

}
