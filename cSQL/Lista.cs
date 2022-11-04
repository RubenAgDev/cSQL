using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace cSQL
{
    class Lista
    {
        private Nodo Primero;

        public List<Error> Errores;

        static string[] PalabrasReservadas;
        static string[] Signos;

        public Lista()
        {
            Primero = null;

            Errores = new List<Error>();

            PalabrasReservadas = new string[]
            {
                "NUM",
                "TEXTO",
                "FECHA",
                "USAR",
                "CREAR",
                "TABLA",
                "BD",
                "INSERTAR",
                "EN",
                "VALORES",
                "ACTUALIZAR",
                "COLOCAR",
                "ALTERAR",
                "AÑADIR",
                "SELECCIONAR",
                "TODO",
                "DE",
                "LIMPIAR",
                "BORRAR",
                "COMO",
                "MIN",
                "MAX",
                "PROM",
                "SUM",
                "CONTAR",
                "DONDE",
                "ENTRE",
                "PARECE",
                "DISTINTO",
                "Y",
                "O",
                "ORDENAR",
                "POR",
                "DESC",
                "ASC",
                "REPETIR",
                "NO",
                "NULO",
                "CLAVE",
                "PRIMARIA"
            };

            Signos = new string[]
            {
                ",",
                ";",
                "(",
                ")",
                "{",
                "}",
                "\'",
                "+",
                "-",
                "*",
                "/",
                "=",
                "<",
                ">",
                "<>",
                "<=",
                ">=",
                "[",
                "]"
            };
        }

        public Lista(string[] PrimerValor)
        {
            Primero = new Nodo(PrimerValor, null);
        }

        public void InsertarAlFinal(string Valor, int LineaReferencia)
        {
            if (EsRepetido(Valor, LineaReferencia))
                return;

            string Patron = ObtenerPatron(Valor);
            string IdIdentificador;

            if (Patron.Equals("Identificador"))
                IdIdentificador = ObtenerSiguienteIdIdentificador();
            else
                IdIdentificador = "";

            if (Patron != "Patrón no reconocido")
            {
                if (!(Primero is Nodo))
                {
                    Primero = new Nodo(new string[] { "1", Valor, Patron, LineaReferencia.ToString(), IdIdentificador }, null);

                    return;
                }

                Nodo _Nodo = Primero;

                while (_Nodo.Siguiente is Nodo)
                    _Nodo = _Nodo.Siguiente;

                _Nodo.Siguiente = new Nodo(new string[] { Convert.ToString(int.Parse(_Nodo.Dato[0]) + 1), Valor, Patron, LineaReferencia.ToString(), IdIdentificador }, null);
            }
            else
            {
                if(Errores.Count < 1)
                {
                    Errores.Add(new Error(1, Valor, Patron, LineaReferencia));
                    return;
                }

                Errores.Add(new Error(Errores[Errores.Count - 1].Id + 1, Valor, Patron, LineaReferencia));
            }
                
        }

        public ArrayList ObtenerValores()
        {
            Nodo _Nodo = Primero;

            int NumeroValores = 0;

            while (_Nodo is Nodo)
            {
                NumeroValores++;
                _Nodo = _Nodo.Siguiente;
            }

            _Nodo = Primero;

            ArrayList Valores = new ArrayList();

            for (int i = 0; i < NumeroValores; i++)
            {
                Valores.Add(_Nodo.Dato);

                _Nodo = _Nodo.Siguiente;
            }

            return Valores;
        }

        private bool EsRepetido(string Valor, int Linea)
        {
            Nodo _Nodo = Primero;

            while (_Nodo is Nodo)
            {
                if (_Nodo.Dato[1].Equals(Valor))
                {
                    _Nodo.Dato[3] += ", " + Linea;

                    return true;
                }

                _Nodo = _Nodo.Siguiente;
            }

            return false;
        }

        private static bool EsPalabraReservada(string Simbolo)
        {
            foreach (string PalabraReservada in PalabrasReservadas)
            {
                if (PalabraReservada.Equals(Simbolo))
                    return true;
            }

            return false;
        }

        private static bool EsError(string identificador)
        {
            bool Error = false;
            char[] idvector = identificador.ToCharArray();

            if (!char.IsLetter(idvector[0]) && idvector[0] != '_')
                Error = true;
            else
            {
                for (int i = 1; i < idvector.Length; i++)
                {
                    if (!char.IsLetter(idvector[i]) && !char.IsNumber(idvector[i]) && idvector[i] != '_')
                    {
                        Error = true;
                        break;
                    }
                }
            }
            return Error;
        }

        private static bool EsNumero(string Simbolo)
        {
            char[] Caracteres = Simbolo.ToCharArray();
            bool HayPunto = false;

            for (int i = 0; i < Caracteres.Length; i++)
            {
                if (Caracteres[i].Equals('.'))
                {
                    if (HayPunto)
                        return false;
                    if (i < Caracteres.Length - 1)
                        HayPunto = true;
                    else
                        return false;

                    continue;
                }

                if (!char.IsNumber(Caracteres[i]))
                    return false;
            }

            return true;
        }

        private static bool EsSimbolo(string Simbolo)
        {
            foreach (string Token in Signos)
            {
                if (Token.Equals(Simbolo))
                    return true;
            }

            return false;
        }

        public static string ObtenerPatron(string Simbolo)
        {
            string Patron;

            if (EsPalabraReservada(Simbolo))
                Patron = "Palabra Reservada";
            else if (EsSimbolo(Simbolo))
                Patron = "Símbolo";
            else if (Simbolo.ToCharArray()[0].Equals('\'') && Simbolo.ToCharArray()[Simbolo.Length - 1].Equals('\''))
                Patron = "Texto";
            else if (EsNumero(Simbolo))
                Patron = "Número";
            else
            {
                if (EsError(Simbolo))
                    Patron = "Patrón no reconocido";
                else
                    Patron = "Identificador";
            }
            return Patron;
        }

        private string ObtenerSiguienteIdIdentificador()
        {
            if (!(Primero is Nodo))
                return "Id1";

            string VarId = "";

            Nodo _Nodo = Primero;

            while (_Nodo is Nodo)
            {
                if (_Nodo.Dato[2].Equals("Identificador"))
                    VarId = _Nodo.Dato[4];

                _Nodo = _Nodo.Siguiente;
            }

            if (VarId.Equals(""))
                return "Id1";

            string UltimoId = VarId.Substring(2, VarId.Length - 2);

            VarId = Convert.ToString(int.Parse(UltimoId) + 1);

            return "Id" + VarId;
        }
    }
}