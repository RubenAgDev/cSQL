using System;
using System.Collections.Generic;
using System.Text;

namespace cSQL
{
    class TraduccionSQL
    {
        private string TextoEnSQL;
        private List<string[]> Palabras;

        #region Propiedades
        public string TextoTraducido
        {
            get { return TextoEnSQL; }
        }
        #endregion

        public TraduccionSQL(System.Collections.ArrayList cSQL_Simbolos)
        {
            TextoEnSQL = "";
            Palabras = new List<string[]>();

            Palabras.Add(new string[] { "NUM", "INT" });
            Palabras.Add(new string[] { "TEXTO", "VARCHAR(255)" });
            Palabras.Add(new string[] { "FECHA", "DATETIME" });
            Palabras.Add(new string[] { "USAR", "USE" });
            Palabras.Add(new string[] { "CREAR", "CREATE" });
            Palabras.Add(new string[] { "TABLA", "TABLE" });
            Palabras.Add(new string[] { "BD", "DATABASE" });
            Palabras.Add(new string[] { "INSERTAR", "INSERT" });
            Palabras.Add(new string[] { "EN", "INTO" });
            Palabras.Add(new string[] { "VALORES", "VALUES" });
            Palabras.Add(new string[] { "ACTUALIZAR", "UPDATE" });
            Palabras.Add(new string[] { "COLOCAR", "SET" });
            Palabras.Add(new string[] { "ALTERAR", "ALTER" });
            Palabras.Add(new string[] { "AÑADIR", "ADD" });
            Palabras.Add(new string[] { "SELECCIONAR", "SELECT" });
            Palabras.Add(new string[] { "TODO", "*" });
            Palabras.Add(new string[] { "DE", "FROM" });
            Palabras.Add(new string[] { "LIMPIAR", "DELETE" });
            Palabras.Add(new string[] { "BORRAR", "DROP" });
            Palabras.Add(new string[] { "COMO", "AS" });
            Palabras.Add(new string[] { "MIN", "MIN" });
            Palabras.Add(new string[] { "MAX", "MAX" });
            Palabras.Add(new string[] { "PROM", "AVG" });
            Palabras.Add(new string[] { "SUM", "SUM" });
            Palabras.Add(new string[] { "CONTAR", "COUNT" });
            Palabras.Add(new string[] { "DONDE", "WHERE" });
            Palabras.Add(new string[] { "ENTRE", "BETWEEN" });
            Palabras.Add(new string[] { "PARECE", "LIKE" });
            Palabras.Add(new string[] { "DISTINTO", "DISTINCT" });
            Palabras.Add(new string[] { "Y", "AND" });
            Palabras.Add(new string[] { "O", "OR" });
            Palabras.Add(new string[] { "ORDENAR", "ORDER" });
            Palabras.Add(new string[] { "POR", "BY" });
            Palabras.Add(new string[] { "DESC", "DESC" });
            Palabras.Add(new string[] { "ASC", "ASC" });
            Palabras.Add(new string[] { "NO", "NOT" });
            Palabras.Add(new string[] { "NULO", "NULL" });
            Palabras.Add(new string[] { "PRIMARIA", "KEY" });
            Palabras.Add(new string[] { "CLAVE", "PRIMARY" });
            
            Tradujir(cSQL_Simbolos);
            TextoEnSQL = TextoEnSQL.Substring(0, TextoEnSQL.Length - 3);
        }

        public void Tradujir(System.Collections.ArrayList CodigocSQL)
        {
            for (int i = 0; i < CodigocSQL.Count; i++)
            {
                if (Lista.ObtenerPatron(CodigocSQL[i].ToString()).Equals("Palabra Reservada"))
                {
                    if (CodigocSQL[i].ToString().Equals("REPETIR"))
                        TextoEnSQL += Traducir(CodigocSQL, ref i) + " ";
                    else
                        TextoEnSQL += Traducir(CodigocSQL[i].ToString()) + " ";
                }
                else
                {
                    if (CodigocSQL[i].Equals(";"))
                        continue;
                    else
                        TextoEnSQL += CodigocSQL[i] + " ";
                }
            }
        }

        public string Traducir(string Palabra)
        {
            foreach (string[] ElSimbolo in Palabras)
            {
                if (ElSimbolo[0].Equals(Palabra))
                    return ElSimbolo[1];
            }

            return "--No se encontró la palabra ";
        }

        public string Traducir(System.Collections.ArrayList Simbolos, ref int Indice)
        {
            string FragmentoNuevo = "";
            Indice += 2;
            string Temporal;

            if (Simbolos[Indice].ToString().Equals("INSERTAR"))
                Temporal = Traducir(Simbolos[Indice].ToString()) + " " +
                    Traducir(Simbolos[Indice + 1].ToString()) + " " + Simbolos[Indice + 2].ToString() + " ";
            else
                Temporal = Traducir(Simbolos[Indice].ToString()) + " " +
                    Simbolos[Indice + 1].ToString() + " " + Traducir(Simbolos[Indice + 2].ToString()) + " ";

            for (int i = Indice + 5; ; i++)
            {
                if (Simbolos[i - 1].ToString().Equals("{"))
                    FragmentoNuevo += Temporal + Simbolos[i] + " ";
                else if (Simbolos[i - 1].ToString().Equals(";") && !Simbolos[i].ToString().Equals("}"))
                    FragmentoNuevo += Temporal + Simbolos[i] + " ";
                else if (Simbolos[i].ToString().Equals("}"))
                {
                    Indice = i;
                    return FragmentoNuevo;
                }
                else if (Simbolos[i].ToString().Equals(";"))
                    continue;
                else
                {
                    if (Lista.ObtenerPatron(Simbolos[i].ToString()).Equals("Palabra Reservada"))
                        FragmentoNuevo += Traducir(Simbolos[i].ToString()) + " ";
                    else
                        FragmentoNuevo += Simbolos[i] + " ";
                }
            }
        }
    }
}