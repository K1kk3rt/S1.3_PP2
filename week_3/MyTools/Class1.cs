using System;

namespace MyTools
{
        public struct LeesTools
        {
            public static int LeesInt(string vraag)
            {
                Console.Write(vraag);
                int getal = Int32.Parse(Console.ReadLine());
                return getal;
            }

           public static int LeesInt(string vraag, int min, int max)
            {
                Console.Write(vraag);
                int leeftijd = Int32.Parse(Console.ReadLine());
                return leeftijd;
            }

            public static string LeesString(string vraag)
            {
                Console.Write(vraag);
                string naam = Console.ReadLine();
                return naam;
            }
        }
}
