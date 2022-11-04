using System;
using System.Collections.Generic;
using System.Text;

namespace cSQL
{
    class Rama
    {
        public Rama Hijo;
        public Rama Hermano;
        public string Dato;
        public string Tipo;
        
        public Rama(Rama Son, Rama Brother, string Value)
        {
            Hijo = Son;
            Hermano = Brother;
            Dato = Value;
            Tipo = "No es identificador";
        }

        public Rama(Rama Son, Rama Brother, string Value, string Type)
        {
            Hijo = Son;
            Hermano = Brother;
            Dato = Value;
            Tipo = Type;
        }
    }
}