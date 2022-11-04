using System;
using System.Text;

namespace cSQL
{
    class Postfija
    {
        private Pila Operadores;
        //private Pila Numeros;
        private System.Collections.ArrayList ExpresionInicial;
        private System.Collections.ArrayList ExpresionPostfija;
        public string ElTexto;

        public Postfija(System.Collections.ArrayList Oper)
        {
            Operadores = new Pila();
            //Numeros = new Pila();
            ExpresionPostfija = new System.Collections.ArrayList();
            ExpresionInicial = Oper;
            GenerarExpresion();
            ElTexto = "";

            foreach (string Posicion in ExpresionPostfija)
                ElTexto += Posicion + " ";

            //EvaluarExpresion();
        }

        public void GenerarExpresion()
        {
            for (int i = 0; i < ExpresionInicial.Count; i++)
            {
                if (Lista.ObtenerPatron(ExpresionInicial[i].ToString()).Equals("Identificador") || Lista.ObtenerPatron(ExpresionInicial[i].ToString()).Equals("Número"))
                    ExpresionPostfija.Add(ExpresionInicial[i].ToString());

                else if (Lista.ObtenerPatron(ExpresionInicial[i].ToString()).Equals("Palabra Reservada") || ExpresionInicial[i].ToString().Equals("(") || Operadores.EstaVacia)
                    Operadores.InsertarElemento(ExpresionInicial[i].ToString());

                else if (ExpresionInicial[i].ToString().Equals(")"))
                {
                    while (!Lista.ObtenerPatron(Operadores.ObtenerElemento()).Equals("Palabra Reservada") && !Operadores.ObtenerElemento().Equals("("))
                    {
                        ExpresionPostfija.Add(Operadores.ObtenerElemento());
                        Operadores.SacarElemento();
                    }
              
                    if (Lista.ObtenerPatron(Operadores.ObtenerElemento()).Equals("Palabra Reservada"))
                        ExpresionPostfija.Add(Operadores.ObtenerElemento());

                    Operadores.SacarElemento();
                }

                else
                {
                    if (this.PrioridadOperador(ExpresionInicial[i].ToString()) <= this.PrioridadOperador(Operadores.ObtenerElemento()))
                    {
                        ExpresionPostfija.Add(Operadores.ObtenerElemento());
                        Operadores.SacarElemento();
                        Operadores.InsertarElemento(ExpresionInicial[i].ToString());
                    }
                    else
                        Operadores.InsertarElemento(ExpresionInicial[i].ToString());
                }

                if (Lista.ObtenerPatron(ExpresionInicial[i].ToString()).Equals("Palabra Reservada"))
                    i++;
            }

            while (!Operadores.EstaVacia)
            {
                ExpresionPostfija.Add(Operadores.ObtenerElemento());
                Operadores.SacarElemento();
            }
        }

        public int PrioridadOperador(string Operador)
        {
            if (Operador.Equals("+") || Operador.Equals("-"))
                return 0;
            else if (Operador.Equals("*") || Operador.Equals("/"))
                return 1;
            else
                return -1;
        }

        /*public void EvaluarExpresion()
        {
            string SubExpresion = "";

            for (int i = 0; i < ExpresionPostfija.Count; i++)
            {
                if (Lista.ObtenerPatron(ExpresionPostfija[i].ToString()).Equals("Identificador") || Lista.ObtenerPatron(ExpresionPostfija[i].ToString()).Equals("Número"))
                    Numeros.InsertarElemento(ExpresionPostfija[i].ToString());
                else if (Lista.ObtenerPatron(ExpresionPostfija[i].ToString()).Equals("Palabra Reservada"))
                {
                    SubExpresion = ExpresionPostfija[i].ToString() + "(" + Numeros.ObtenerElemento() + ")";
                    Numeros.SacarElemento();
                    Numeros.InsertarElemento(SubExpresion);
                }
                else
                {
                    SubExpresion = Numeros.ObtenerElemento() + ExpresionPostfija[i].ToString();
                    Numeros.SacarElemento();
                    SubExpresion = SubExpresion + Numeros.ObtenerElemento();
                    Numeros.SacarElemento();
                    Numeros.InsertarElemento(SubExpresion);
                }
            }
        }*/
    }
}