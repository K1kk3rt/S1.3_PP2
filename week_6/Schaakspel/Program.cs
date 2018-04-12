using System;

namespace Schaakspel
{
    class Program
    {
        static void Main(string[] args)
        {
            Schaakstuk[,] schaakbord = new Schaakstuk[8,8];

            InitSchaakbord(schaakbord);
            ToonsSchaakbord(schaakbord);
            VerplaatsStukken(schaakbord);

            Console.ReadKey();
        }

        static public void InitSchaakbord(Schaakstuk[,] schaakbord)
        {
            //maak schaakbord leeg
            for (int r = 0; r < schaakbord.GetLength(0); r++)
            {
                for (int k = 0; k < schaakbord.GetLength(1); k++)
                {
                    schaakbord[r, k] = null;
                }
            }

            //plaats witte schaakstukken ('bovenaan')
            schaakbord[0, 0] = new Schaakstuk(SchaakstukType.Toren, SchaakstukKleur.Wit);
            schaakbord[0, 1] = new Schaakstuk(SchaakstukType.Paard, SchaakstukKleur.Wit);
            schaakbord[0, 2] = new Schaakstuk(SchaakstukType.Loper, SchaakstukKleur.Wit);
            schaakbord[0, 3] = new Schaakstuk(SchaakstukType.Koning, SchaakstukKleur.Wit);
            schaakbord[0, 4] = new Schaakstuk(SchaakstukType.Koningin, SchaakstukKleur.Wit);
            schaakbord[0, 5] = new Schaakstuk(SchaakstukType.Loper, SchaakstukKleur.Wit);
            schaakbord[0, 6] = new Schaakstuk(SchaakstukType.Paard, SchaakstukKleur.Wit);
            schaakbord[0, 7] = new Schaakstuk(SchaakstukType.Toren, SchaakstukKleur.Wit);

            schaakbord[1, 0] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Wit);
            schaakbord[1, 1] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Wit);
            schaakbord[1, 2] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Wit);
            schaakbord[1, 3] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Wit);
            schaakbord[1, 4] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Wit);
            schaakbord[1, 5] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Wit);
            schaakbord[1, 6] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Wit);
            schaakbord[1, 7] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Wit);

            //plaats zwarte schaakstukken ('onderaan')
            schaakbord[7, 0] = new Schaakstuk(SchaakstukType.Toren, SchaakstukKleur.Zwart);
            schaakbord[7, 1] = new Schaakstuk(SchaakstukType.Paard, SchaakstukKleur.Zwart);
            schaakbord[7, 2] = new Schaakstuk(SchaakstukType.Loper, SchaakstukKleur.Zwart);
            schaakbord[7, 3] = new Schaakstuk(SchaakstukType.Koning, SchaakstukKleur.Zwart);
            schaakbord[7, 4] = new Schaakstuk(SchaakstukType.Koningin, SchaakstukKleur.Zwart);
            schaakbord[7, 5] = new Schaakstuk(SchaakstukType.Loper, SchaakstukKleur.Zwart);
            schaakbord[7, 6] = new Schaakstuk(SchaakstukType.Paard, SchaakstukKleur.Zwart);
            schaakbord[7, 7] = new Schaakstuk(SchaakstukType.Toren, SchaakstukKleur.Zwart);

            schaakbord[6, 0] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Zwart);
            schaakbord[6, 1] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Zwart);
            schaakbord[6, 2] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Zwart);
            schaakbord[6, 3] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Zwart);
            schaakbord[6, 4] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Zwart);
            schaakbord[6, 5] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Zwart);
            schaakbord[6, 6] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Zwart);
            schaakbord[6, 7] = new Schaakstuk(SchaakstukType.Pion, SchaakstukKleur.Zwart);

        }

        static void ToonsSchaakbord(Schaakstuk[,] schaakbord)
        {
            //Print letters bovenaan schaakbord
            Console.WriteLine("  A  B  C  D  E  F  G  H ");

            // verwerk alle rijen
            for (int r = 0; r < schaakbord.GetLength(0); r++)
            {
                Console.Write("{0}", r + 1);
                // verwerk alle kolommen
                for (int k = 0; k < schaakbord.GetLength(1); k++)
                {
                    // toggle background color
                    if ((r + k) % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    
                    Schaakstuk schaakstuk = schaakbord[r, k];

                    if (schaakstuk == null)
                    {
                        string empty = " ";
                        Console.Write("{0,3}", empty);
                        continue;
                    }
                    // stel de fontkleur in, afhankelijk van de kleur van het schaakstuk
                    if (schaakstuk.kleur == SchaakstukKleur.Wit)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }    
                    else if (schaakstuk.kleur == SchaakstukKleur.Zwart)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                        
                    // print het schaakstuk
                    switch (schaakstuk.type)
                    {
                        case SchaakstukType.Pion:
                            string pion = "p";
                            Console.Write("{0,3}", pion);
                            break;
                        case SchaakstukType.Toren:
                            string toren = "T";
                            Console.Write("{0,3}", toren);
                            break;
                        case SchaakstukType.Paard:
                            string paard = "P";
                            Console.Write("{0,3}", paard);
                            break;
                        case SchaakstukType.Loper:
                            string loper = "L";
                            Console.Write("{0,3}", loper);
                            break;
                        case SchaakstukType.Koningin:
                            string koningin = "Q";
                            Console.Write("{0,3}", koningin);
                            break;
                        case SchaakstukType.Koning:
                            string koning = "K";
                            Console.Write("{0,3}", koning);
                            break;
                    }
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        static void VerplaatsStukken (Schaakstuk[,] schaakbord)
        {
            Positie vanPos = new Positie();
            Positie naarPos = new Positie();

            while (true)
            {
                Console.Write("Geef 'van-positie' <bv A2>: ");
                string vanPosS = Console.ReadLine();
                StringToPositie(vanPosS, out vanPos);

                Console.Write("Geef 'naar-positie' <bv A3>: ");
                string naarPosS = Console.ReadLine();
                StringToPositie(naarPosS, out naarPos);

                MaakSprong(schaakbord, vanPos, naarPos);
                ToonsSchaakbord(schaakbord);


                //if(StringToPositie(vanPos, out pos))
                //{
                //    Schaakstuk item = (Schaakstuk)schaakbord.GetValue(pos.rij, pos.kolom);
                //    SchaakstukType type = item.type;
                //    Console.WriteLine("er staat een schaakstuk op van-positie: " + type);

                //}
                //else
                //{
                //    Console.WriteLine("false");
                //}
            }
        }

        static bool StringToPositie(string txt, out Positie pos)
        {
            pos = new Positie();

            // "A2": "A" => kolom 0, "2" => rij 1
            try
            {
                pos.kolom = txt[0] - 'A';
                pos.rij = Int32.Parse(txt[1].ToString()) - 1;
                return true;
            }
            catch
            {
                Console.WriteLine("Ongeldige invoer");
                return false;
            }

        }

        static void MaakSprong(Schaakstuk[,] schaakbord, Positie vanPos, Positie naarPos)
        {
            if (schaakbord[vanPos.rij, vanPos.kolom] != null)
            {

                Schaakstuk schaakstuk = (Schaakstuk)schaakbord.GetValue(vanPos.rij, vanPos.kolom);
                int type = (int)schaakstuk.type;
                int paard = (int)SchaakstukType.Paard;

                if (type == paard)
                {
                    if (GeldigePaardZet(vanPos, naarPos))
                    {
                        schaakbord[naarPos.rij, naarPos.kolom] = schaakstuk;
                        schaakbord[vanPos.rij, vanPos.kolom] = null;
                    }
                    else
                    {
                        Console.WriteLine("Ongeldige zet");
                        VerplaatsStukken(schaakbord);
                    }
                }
                else
                {
                    schaakbord[naarPos.rij, naarPos.kolom] = schaakstuk;
                    schaakbord[vanPos.rij, vanPos.kolom] = null;
                } 
            }
            else
            {
                Console.WriteLine("Er staat geen schaakstuk op deze positie!");
            }
        }

        static bool GeldigePaardZet(Positie vanPos, Positie naarPos)
        {
            bool isCorrect = false;

            int y = vanPos.rij;
            int x = vanPos.kolom;

            int newY = naarPos.rij;
            int newX = naarPos.kolom;

            if (x == newX -1 && y == newY-2)
            {
                isCorrect = true;
            }
            if (x == newX - 1 && y == newY + 2)
            {
                isCorrect = true;
            }
            if (x == newX + 1 && y == newY - 2)
            {
                isCorrect = true;
            }
            if (x == newX + 1 && y == newY + 2)
            {
                isCorrect = true;
            }

            return isCorrect;

        }
    }
}
