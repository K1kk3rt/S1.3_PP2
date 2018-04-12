using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCrusherLogica
{
    public struct CandyCrusher
    {
        public enum RegularCandies
        {
            JellyBean, Lozenge, LemonDrop, GumSquare, LollipopHead, JujubeCluster
        }

        public static bool ScoreRijAanwezig(RegularCandies[,] speelveld)
        {
            int currentCandy = -1;
            //int nextCandy = 1;
            int score = 1;

            for (int i = 0; i < speelveld.Length; i++)
            {
                int y = i % speelveld.GetLength(1);
                int x = i / speelveld.GetLength(1);

                int nextCandy = (int)speelveld[x, y];

                if (x == 0)
                {
                    score = 1;
                    currentCandy = -1;
                }

                if (nextCandy == currentCandy)
                {
                    score++;
                    if (score == 3)
                    {
                        return true;
                    }
                }
                else
                {
                    score = 1;
                }
                currentCandy = (int)speelveld[x, y];
            }
            return false;
        }

        public static bool ScoreKolomAanwezig(RegularCandies[,] speelveld)
        {
            int currentCandy = (int)speelveld[0, 0];
            int nextCandy = 0;
            int score = 1;

            for (int i = 0; i < speelveld.Length; i++)
            {
                int y = i / speelveld.GetLength(0);
                int x = i % speelveld.GetLength(0);

                nextCandy = (int)speelveld[x, y];

                if (nextCandy == currentCandy)
                {
                    score++;
                    if (score == 3)
                    {
                        return true;
                    }
                }
                else
                {
                    score = 1;
                }
                currentCandy = (int)speelveld[x, y];
            }
            return false;
        }
    }
}
