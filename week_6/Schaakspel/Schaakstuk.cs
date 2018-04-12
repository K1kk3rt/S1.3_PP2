using System;
using System.Collections.Generic;
using System.Text;

namespace Schaakspel
{
    public class Schaakstuk
    {
        public SchaakstukType type;
        public SchaakstukKleur kleur;

        public Schaakstuk(SchaakstukType type, SchaakstukKleur kleur)
        {
            this.type = type;
            this.kleur = kleur;
        }
    }
}
