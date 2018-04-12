using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1
{
    class Program
    {
        //letters die in het bericht gebruikt kunnen worden
        static string alphabet = "abcdefghijklmnopqrstuvwxyz";

        static void Main(string[] args)
        {
            //Maak geheime sleutel, en print deze
            int lengte = 40;
            string sleutel = MaakGeheimeSleutel(lengte);
            Console.Write("Geheime sleutel: " + sleutel);

            //vraag bericht en ecrypt deze, en print
            bool encrypt = true;
            Console.WriteLine();
            Console.Write("Geef het bericht: ");
            string bericht = Console.ReadLine();
            Console.WriteLine("Versleuteld bericht: " + OneTimePad(bericht, sleutel, encrypt));
            
            //decrypt bericht, en print
            encrypt = false;
            Console.Write("Ontsleuteld bericht: " + OneTimePad(bericht, sleutel, encrypt));


            Console.ReadKey();
        }

        static string MaakGeheimeSleutel(int lengte)
        {
            string sleutel = "";

            //genereert random getal, gebruikt random getal als index en voegt deze toe aan sleutel
            for (int i = 0; i < lengte; i++)
            {
                Random random = new Random();
                int index = random.Next(0, alphabet.Length);
                sleutel = sleutel + alphabet[index];
            }

            return sleutel;
        }

        static string OneTimePad (string bericht, string sleutel, bool encrypt)
        {
            string resultaat = "";

            //loopt door alle carachers van bericht
            for (int i = 0; i < bericht.Length; i++)
            {
                //bepaald alphabet positie van bericht en sleutel
                int berichtPos= alphabet.IndexOf(bericht[i]);
                int sleutelPos = alphabet.IndexOf(sleutel[i]);

                //voor encrypen
                if (encrypt)
                {
                    int encrypted = (berichtPos + sleutelPos) % alphabet.Length;
                    resultaat = resultaat + alphabet[encrypted];
                }
                //voor decrypten
                else
                {
                    int decrypt = berichtPos - sleutelPos;

                    //als decrypt negatief, tel lengte alphabet op
                    if (decrypt < 0)
                    {
                        decrypt = decrypt + alphabet.Length;
                    }

                    resultaat = resultaat + alphabet[decrypt];
                }   
            }

            return resultaat;
        }
    }
}
