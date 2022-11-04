using System;
using System.Collections.Generic;
using System.Text;

namespace cSQL
{
    class Arbol
    {
        private Rama _Raiz;

        public Rama Raiz
        {
            get { return _Raiz; }
        }

        public Arbol(string Cima)
        {
            _Raiz = new Rama(null, null, Cima);
        }

        public void InsertarHijo(Rama Padre, string Valor)
        {
            if (Padre.Hijo == null)
            {
                Padre.Hijo = new Rama(null, null, Valor);
                return;
            }

            Rama _Nodo = Padre.Hijo;

            while (_Nodo.Hermano != null)
                _Nodo = _Nodo.Hermano;

            _Nodo.Hermano = new Rama(null, null, Valor);
        }
    }
}