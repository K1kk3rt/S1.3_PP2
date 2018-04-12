using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_2
{
    public struct Vak
    {
        //struct met: naam voord e naam van het vak, cijfer voor het theoriecijfer, practicum voor de practicumbeoordeling. 
        //deze bevat bepaalde waarden, zie enum

        public string naam;
        public int cijfer;
        public Beoordeling Beoordeling;

        public bool IsBehaald()
        {
            return cijfer > 55 && (Beoordeling == Beoordeling.Voldoende || Beoordeling == Beoordeling.Goed);
        }

        public bool IsCumLaude()
        {
            return cijfer > 80 && Beoordeling == Beoordeling.Goed;
        }

    }

    //Enum Beoordeling
    public enum Beoordeling
    {
        Geen, Absent, Onvoldoende, Voldoende, Goed
    }
}
