using System;
using System.Collections.Generic;
using System.Text;

namespace cSQL
{
    class Pila
    {
        private Nodo Actual;

        public Nodo ElementoActual
        {
            get { return Actual; }
        }

        public bool EstaVacia
        {
            get
            {
                if (Actual == null)
                    return true;
                else
                    return false;
            }
        }
        
        public Pila()
        {
            Actual = null;
        }

        public void InsertarElemento(string Valor)
        {
            if (Actual == null)
            {
                Actual = new Nodo(new string[] { Valor }, null);
                return;
            }

            Actual = new Nodo(new string[] { Valor }, Actual);
        }

        public void SacarElemento()
        {
            if (Actual == null)
                return;

            Actual = Actual.Siguiente;
        }

        public string ObtenerElemento()
        {
            return Actual.Dato[0];
        }
    }
}