using System;

namespace Opgave1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een zin: ");
            string zinNormaal = Console.ReadLine();

            string zinHussel = HusselZinWoorden(zinNormaal);

            Console.WriteLine("De aangepaste zin is geworden: " + zinHussel);

            Console.ReadKey();
        }

        static string HusselZinWoorden(string zinNormaal)
        {
            string[] zinArray = zinNormaal.Split(' ');
            string zinHussel = "";

            for (int i = 0; i < zinArray.Length; i++)
            {
                string woordHussel = HusselWoord(zinArray[i]);
                zinHussel = zinHussel + " " + woordHussel;
            }

            return zinHussel;
        }

        static string HusselWoord(string woord)
        {
            string nieuwWoord = woord[0].ToString();

            if (woord.Length <= 3)
            { 
                return woord;
            }
            else
            {
                string restWoord = woord.Substring(1, (woord.Length -1));

                //foreach(char letter in restWoord)
                //{
                //    Random random = new Random();
                //    int index = random.Next(0, restWoord.Length - 1);
                //    string letter1 = restWoord[index].ToString();
                //    restWoord = restWoord.Remove(index, 1);
                //    nieuwWoord = nieuwWoord + letter1;
                //}


                for (int i = 0; i < woord.Length-1; i++)
                {
                    Random random = new Random();
                    int index = random.Next(0, restWoord.Length - 1);
                    //index is niet nul op het moment dat er nog 2 letters zijn, waardoor er 1 letter overgeslagen wordt.
                    string letter = restWoord[index].ToString();
                    restWoord = restWoord.Remove(index, 1);
                    nieuwWoord = nieuwWoord + letter;
                }

                //nieuwWoord = nieuwWoord + woord[woord.Length-1];
                return nieuwWoord;
            }

            
        }
    }
}
