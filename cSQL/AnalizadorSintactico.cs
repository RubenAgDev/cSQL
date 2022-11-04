using System;
using System.Collections.Generic;
using System.Text;

namespace cSQL
{
    class AnalizadorSintactico
    {
        private TablaAnalisisSintactico Tabla;
        private Pila MiPila;
        private System.Collections.ArrayList Tokens;
    
        public AnalizadorSintactico(System.Collections.ArrayList LosTokens)
        {
            Tabla = new TablaAnalisisSintactico();
            MiPila = new Pila();
            Tokens = LosTokens;
            Tokens.Add("$");
        }

        public string AnalisisConPila()
        {
            MiPila.InsertarElemento("$");
            MiPila.InsertarElemento("A");

            string[] Nueva;
            int x = 0;

            while (x < Tokens.Count)
            {
                if(MiPila.ObtenerElemento().Equals("$"))
                    return "Análisis sintáctico aprobado correctamente";

                if (Tokens[x].ToString() == "$")
                    Nueva = Tabla.Buscar(MiPila.ObtenerElemento(), Tokens[x].ToString());
                else
                    Nueva = Tabla.Buscar(MiPila.ObtenerElemento(), ModificarPorPatron(Tokens[x].ToString()));

                if (Nueva[0].Equals("ERROR"))
                {
                    if (Tokens[x].ToString() == "$" && Tokens.Count > 1)
                        return "ERROR de sintáxis cerca de '" + Tokens[x - 1].ToString() + "'";
                    else
                        return "ERROR de sintáxis cerca de '" + Tokens[x].ToString() + "'";
                }
            
                MiPila.SacarElemento();

                for (int i = Nueva.Length - 1; i >= 0; i--)
                    MiPila.InsertarElemento(Nueva[i]);

                while (true)
                {
                    if (x >= Tokens.Count)
                        break;

                    if (MiPila.ObtenerElemento().Equals(ModificarPorPatron(Tokens[x].ToString())))
                    {
                        MiPila.SacarElemento();
                        x++;
                    }
                    else 
                    {
                        if (MiPila.ObtenerElemento().Equals("e"))
                            MiPila.SacarElemento();
                        else
                            break;
                    }
                }
            }
            return "ERROR Se esperaba ;";
        }

        public static string ModificarPorPatron(string Simbolo)
        {
            string Modificado;

            switch (Lista.ObtenerPatron(Simbolo))
            {
                case "Palabra Reservada":
                    Modificado = Simbolo;
                    break;
                case "Símbolo":
                    Modificado = Simbolo;
                    break;
                case "Texto":
                    Modificado = "texto";
                    break;
                case "Número":
                    Modificado = "num";
                    break;
                case "Identificador":
                    Modificado = "id";
                    break;
                default:
                    Modificado = "ERROR";
                    break;
            }

            return Modificado;
        }
    }
}