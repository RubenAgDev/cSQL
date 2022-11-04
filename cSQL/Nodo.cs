using System;
using System.Collections.Generic;
using System.Text;

namespace cSQL
{
    class Nodo
    {
        public Nodo Siguiente;
        public string[] Dato;

        public Nodo(string[] Valor, Nodo SiguienteNodo)
        {
            Dato = Valor;
            Siguiente = SiguienteNodo;
        }
    }
}
