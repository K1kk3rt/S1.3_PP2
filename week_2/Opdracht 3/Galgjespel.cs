using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3
{
    struct Galgjespel
    {
        public string geheimwoord;
        public string geradenwoord;

        public void Init()
        {
            //method zet geradenwoord in puntjes
            for(int i=0; i < geheimwoord.Length; i++)
            {
                geradenwoord = geradenwoord + ".";
                
            }

        }

        public bool RaadLetter (char Letter)
        {
            //method controleert of ingevoerde 'Letter' in geradenwoord zit

            //maak geradenwoord Array, en zet hierin de letters van string geradenwoord
            char[] geradenwoordArray = geradenwoord.ToCharArray();

            //vergelijkt de ingevoerde letter met elke letter in geradenarray, 
            for (int i=0; i<geheimwoord.Length; i++)
            {
                if (geheimwoord[i]==(Letter))
                {
                    geradenwoordArray[i] = Letter;
                    
                }
                //zet array om in string
                geradenwoord = new string(geradenwoordArray);
            }

            //return naar GalgjeSpel()
            if (geradenwoord.Contains(Letter))
            {
                return true;
            }
            
            return false;
        }
        public bool isGeraden()
        {
            //method bepaalt of het hele woord geraden is
            if(geheimwoord == geradenwoord)
            {
                return true;
            }
            
            return false;
        }
    }
    

}
