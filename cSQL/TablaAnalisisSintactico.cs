using System;
using System.Collections.Generic;
using System.Text;

namespace cSQL
{
    class TablaAnalisisSintactico
    {
        public System.Collections.ArrayList[,] TablaAS;

        public TablaAnalisisSintactico()
        {
            TablaAS = new System.Collections.ArrayList[41, 63];

            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 63; j++)
                    TablaAS[i, j] = new System.Collections.ArrayList();
            }

            //No terminales
            TablaAS[1, 0].Add("A");
            TablaAS[2, 0].Add("B");
            TablaAS[3, 0].Add("B'");
            TablaAS[4, 0].Add("Z"); //NO EXISTE
            TablaAS[5, 0].Add("R");
            TablaAS[6, 0].Add("T");
            TablaAS[7, 0].Add("T'");
            TablaAS[8, 0].Add("Q");
            TablaAS[9, 0].Add("Q'");
            TablaAS[10, 0].Add("D");
            TablaAS[11, 0].Add("D'");
            TablaAS[12, 0].Add("U");
            TablaAS[13, 0].Add("V");
            TablaAS[14, 0].Add("P");
            TablaAS[15, 0].Add("P'");
            TablaAS[16, 0].Add("M");
            TablaAS[17, 0].Add("M'");
            TablaAS[18, 0].Add("W");
            TablaAS[19, 0].Add("W'");
            TablaAS[20, 0].Add("X");
            TablaAS[21, 0].Add("C");
            TablaAS[22, 0].Add("C'");
            TablaAS[23, 0].Add("N");
            TablaAS[24, 0].Add("N'");
            TablaAS[25, 0].Add("Ñ");
            TablaAS[26, 0].Add("I");
            TablaAS[27, 0].Add("I'");
            TablaAS[28, 0].Add("L");
            TablaAS[29, 0].Add("K"); //NO EXISTE
            TablaAS[30, 0].Add("K'");
            TablaAS[31, 0].Add("J");
            TablaAS[32, 0].Add("S");
            TablaAS[33, 0].Add("S'");
            TablaAS[34, 0].Add("E");
            TablaAS[35, 0].Add("E'");
            TablaAS[36, 0].Add("F");
            TablaAS[37, 0].Add("F'");
            TablaAS[38, 0].Add("G");
            TablaAS[39, 0].Add("G'");
            TablaAS[40, 0].Add("H");

            //Terminales
            TablaAS[0, 1].Add("id");
            TablaAS[0, 2].Add("texto");
            TablaAS[0, 3].Add("num");
            TablaAS[0, 4].Add("NUM");
            TablaAS[0, 5].Add("TEXTO");
            TablaAS[0, 6].Add("FECHA");
            TablaAS[0, 7].Add("USAR");
            TablaAS[0, 8].Add("CREAR");
            TablaAS[0, 9].Add("BD");
            TablaAS[0, 10].Add("TABLA");
            TablaAS[0, 11].Add("INSERTAR");
            TablaAS[0, 12].Add("EN");
            TablaAS[0, 13].Add("VALORES");
            TablaAS[0, 14].Add("ACTUALIZAR");
            TablaAS[0, 15].Add("COLOCAR");
            TablaAS[0, 16].Add("SELECCIONAR");
            TablaAS[0, 17].Add("ALTERAR");
            TablaAS[0, 18].Add("AÑADIR");
            TablaAS[0, 19].Add("TODO");
            TablaAS[0, 20].Add("DE");
            TablaAS[0, 21].Add("LIMPIAR");
            TablaAS[0, 22].Add("BORRAR");
            TablaAS[0, 23].Add("COMO");
            TablaAS[0, 24].Add("MIN");
            TablaAS[0, 25].Add("MAX");
            TablaAS[0, 26].Add("PROM");
            TablaAS[0, 27].Add("SUM");
            TablaAS[0, 28].Add("CONTAR");
            TablaAS[0, 29].Add("DONDE");
            TablaAS[0, 30].Add("ENTRE");
            TablaAS[0, 31].Add("PARECE");
            TablaAS[0, 32].Add("DISTINTO");
            TablaAS[0, 33].Add("Y");
            TablaAS[0, 34].Add("O");
            TablaAS[0, 35].Add("ORDENAR");
            TablaAS[0, 36].Add("POR");
            TablaAS[0, 37].Add("ASC");
            TablaAS[0, 38].Add("DESC");
            TablaAS[0, 39].Add("REPETIR");
            TablaAS[0, 40].Add("NO");
            TablaAS[0, 41].Add("NULO");
            TablaAS[0, 42].Add("CLAVE");
            TablaAS[0, 43].Add("PRIMARIA");
            TablaAS[0, 44].Add("(");
            TablaAS[0, 45].Add(")");
            TablaAS[0, 46].Add("{");
            TablaAS[0, 47].Add("}");
            TablaAS[0, 48].Add("[");
            TablaAS[0, 49].Add("]");
            TablaAS[0, 50].Add("<");
            TablaAS[0, 51].Add(">");
            TablaAS[0, 52].Add("=");
            TablaAS[0, 53].Add("<>");
            TablaAS[0, 54].Add("<=");
            TablaAS[0, 55].Add(">=");
            TablaAS[0, 56].Add("+");
            TablaAS[0, 57].Add("-");
            TablaAS[0, 58].Add("*");
            TablaAS[0, 59].Add("/");
            TablaAS[0, 60].Add(",");
            TablaAS[0, 61].Add(";");
            TablaAS[0, 62].Add("$");

            //PRODUCCIONES
            TablaAS[1, 7].Add(new string[] { "USAR", "id", ";", "B" });
            TablaAS[1, 8].Add(new string[] { "CREAR", "BD", "id", ";", "B" });
            //TablaAS[2, 7].Add(new string[] { "USAR", "id", ";", "B" });
            TablaAS[2, 8].Add(new string[] { "CREAR", "TABLA", "id", "(", "id", "W", ")", ";", "B" });
            TablaAS[2, 11].Add(new string[] { "INSERTAR", "EN", "id", "(", "id", "V", "P", ")", ";", "B" });
            TablaAS[2, 14].Add(new string[] { "ACTUALIZAR", "id", "COLOCAR", "id", "=", "M", "B'", ";", "B" });
            TablaAS[2, 16].Add(new string[] { "SELECCIONAR", "Q", "DE", "id", "B'", "T", ";", "B" });
            TablaAS[2, 17].Add(new string[] { "ALTERAR", "TABLA", "id", "H", ";", "B" });
            TablaAS[2, 21].Add(new string[] { "LIMPIAR", "id", ";", "B" });
            TablaAS[2, 22].Add(new string[] { "BORRAR", "R", "id", ";", "B" });
            TablaAS[2, 39].Add(new string[] { "REPETIR", "(", "X", "B" });
            TablaAS[2, 62].Add(new string[] { "e" });
            TablaAS[3, 29].Add(new string[] { "DONDE", "id", "I" });
            TablaAS[3, 35].Add(new string[] { "e" });
            TablaAS[3, 49].Add(new string[] { "e" });
            TablaAS[3, 61].Add(new string[] { "e" });
            TablaAS[3, 62].Add(new string[] { "e" });
            //TablaAS[4, 9].Add(new string[] { "BD", "id" });
            //TablaAS[4, 10].Add(new string[] { "TABLA", "id", "(", "id", "W", ")" });
            TablaAS[5, 9].Add(new string[] { "BD" });
            TablaAS[5, 10].Add(new string[] { "TABLA" });
            TablaAS[6, 35].Add(new string[] { "ORDENAR", "POR", "id", "T'" });
            TablaAS[6, 61].Add(new string[] { "e" });
            TablaAS[7, 37].Add(new string[] { "ASC" });
            TablaAS[7, 38].Add(new string[] { "DESC" });
            TablaAS[7, 61].Add(new string[] { "e" });
            TablaAS[8, 1].Add(new string[] { "D" });
            TablaAS[8, 2].Add(new string[] { "D" });
            TablaAS[8, 3].Add(new string[] { "D" });
            TablaAS[8, 19].Add(new string[] { "D" });
            TablaAS[8, 24].Add(new string[] { "D" });
            TablaAS[8, 25].Add(new string[] { "D" });
            TablaAS[8, 26].Add(new string[] { "D" });
            TablaAS[8, 27].Add(new string[] { "D" });
            TablaAS[8, 28].Add(new string[] { "D" });
            TablaAS[8, 32].Add(new string[] { "DISTINTO", "id", "Q'" });
            TablaAS[8, 44].Add(new string[] { "D" });
            TablaAS[9, 20].Add(new string[] { "e" });
            TablaAS[9, 60].Add(new string[] { ",", "id", "Q'" });
            TablaAS[10, 1].Add(new string[] { "S", "U", "K'" });
            TablaAS[10, 2].Add(new string[] { "texto", "D'" });
            TablaAS[10, 3].Add(new string[] { "S", "U", "K'" });
            TablaAS[10, 19].Add(new string[] { "TODO", "D'" });
            TablaAS[10, 24].Add(new string[] { "S", "U", "K'" });
            TablaAS[10, 25].Add(new string[] { "S", "U", "K'" });
            TablaAS[10, 26].Add(new string[] { "S", "U", "K'" });
            TablaAS[10, 27].Add(new string[] { "S", "U", "K'" });
            TablaAS[10, 28].Add(new string[] { "S", "U", "K'" });
            TablaAS[10, 44].Add(new string[] { "S", "U", "K'" });
            TablaAS[11, 20].Add(new string[] { "e" });
            TablaAS[11, 60].Add(new string[] { ",", "D" });
            TablaAS[12, 20].Add(new string[] { "e" });
            TablaAS[12, 23].Add(new string[] { "COMO", "id" });
            TablaAS[12, 60].Add(new string[] { "e" });
            TablaAS[13, 45].Add(new string[] { ")", "VALORES", "(" });
            TablaAS[13, 60].Add(new string[] { ",", "id", "V", "P'" });
            TablaAS[14, 2].Add(new string[] { "texto" });
            TablaAS[14, 3].Add(new string[] { "num" });
            TablaAS[15, 2].Add(new string[] { "texto", "," });
            TablaAS[15, 3].Add(new string[] { "num", "," });
            TablaAS[16, 1].Add(new string[] { "S", "M'" });
            TablaAS[16, 2].Add(new string[] { "texto", "M'" });
            TablaAS[16, 3].Add(new string[] { "S", "M'" });
            TablaAS[16, 24].Add(new string[] { "S", "M'" });
            TablaAS[16, 25].Add(new string[] { "S", "M'" });
            TablaAS[16, 26].Add(new string[] { "S", "M'" });
            TablaAS[16, 27].Add(new string[] { "S", "M'" });
            TablaAS[16, 28].Add(new string[] { "S", "M'" });
            TablaAS[16, 44].Add(new string[] { "S", "M'" });
            TablaAS[17, 29].Add(new string[] { "e" });
            TablaAS[17, 47].Add(new string[] { "e" });
            TablaAS[17, 60].Add(new string[] { ",", "id", "=", "M" });
            
            TablaAS[17, 61].Add(new string[] { "e" }); //ERROR NO PREVISTO..........
            
            TablaAS[17, 62].Add(new string[] { "e" });
            
            TablaAS[18, 4].Add(new string[] { "NUM", "J", "W'" });
            TablaAS[18, 5].Add(new string[] { "TEXTO", "J", "W'" });
            TablaAS[18, 6].Add(new string[] { "FECHA", "J", "W'" });
            
            TablaAS[19, 45].Add(new string[] { "e" });
            TablaAS[19, 60].Add(new string[] { ",", "id", "W" });
            TablaAS[19, 61].Add(new string[] { "e" });

            TablaAS[20, 11].Add(new string[] { "INSERTAR", "EN", "id", ")", "{", "C", "}" });
            TablaAS[20, 14].Add(new string[] { "ACTUALIZAR", "id", "COLOCAR", ")", "{", "N", "}" });

            TablaAS[21, 44].Add(new string[] { "(", "id", "V", "P", ")", ";", "C'" });

            TablaAS[22, 44].Add(new string[] { "(", "id", "V", "P", ")", ";", "C'" });
            TablaAS[22, 47].Add(new string[] { "e" });

            TablaAS[23, 1].Add(new string[] { "id", "=", "M", "B'", ";", "N'" });

            TablaAS[24, 1].Add(new string[] { "id", "=", "M", "B'", ";", "N'" });
            TablaAS[24, 47].Add(new string[] { "e" });

            TablaAS[25, 18].Add(new string[] { "AÑADIR", "id", "W" });
            TablaAS[25, 22].Add(new string[] { "BORRAR", "id", "Q'" });

            TablaAS[26, 30].Add(new string[] { "ENTRE", "num", "Y", "num", "I'" });
            TablaAS[26, 31].Add(new string[] { "PARECE", "texto", "I'" });
            TablaAS[26, 50].Add(new string[] { "<", "L", "I'" });
            TablaAS[26, 51].Add(new string[] { ">", "L", "I'" });
            TablaAS[26, 52].Add(new string[] { "=", "L", "I'" });
            TablaAS[26, 53].Add(new string[] { "<>", "L", "I'" });
            TablaAS[26, 54].Add(new string[] { "<=", "L", "I'" });
            TablaAS[26, 55].Add(new string[] { ">=", "L", "I'" });
            TablaAS[27, 33].Add(new string[] { "Y", "DONDE", "id", "I" });
            TablaAS[27, 34].Add(new string[] { "O", "DONDE", "id", "I" });
            TablaAS[27, 35].Add(new string[] { "e" });
            TablaAS[27, 49].Add(new string[] { "e" });
            TablaAS[27, 61].Add(new string[] { "e" });
            TablaAS[27, 62].Add(new string[] { "e" });

            TablaAS[28, 1].Add(new string[] { "S" });
            TablaAS[28, 3].Add(new string[] { "S" });
            TablaAS[28, 24].Add(new string[] { "S" });
            TablaAS[28, 25].Add(new string[] { "S" });
            TablaAS[28, 26].Add(new string[] { "S" });
            TablaAS[28, 27].Add(new string[] { "S" });
            TablaAS[28, 28].Add(new string[] { "S" });
            TablaAS[28, 44].Add(new string[] { "S" });
            TablaAS[28, 48].Add(new string[] { "[", "SELECCIONAR", "S", "DE", "id", "B'", "]" });
            
            TablaAS[30, 20].Add(new string[] { "e" });
            TablaAS[30, 60].Add(new string[] { ",", "S", "U", "K'" });
            TablaAS[31, 40].Add(new string[] { "NO", "NULO" });
            TablaAS[31, 42].Add(new string[] { "CLAVE", "PRIMARIA" });
            TablaAS[31, 45].Add(new string[] { "e" });
            TablaAS[31, 60].Add(new string[] { "e" });
            TablaAS[31, 61].Add(new string[] { "e" });
            TablaAS[32, 1].Add(new string[] { "E", "S'" });
            TablaAS[32, 3].Add(new string[] { "E", "S'" });
            TablaAS[32, 24].Add(new string[] { "E", "S'" });
            TablaAS[32, 25].Add(new string[] { "E", "S'" });
            TablaAS[32, 26].Add(new string[] { "E", "S'" });
            TablaAS[32, 27].Add(new string[] { "E", "S'" });
            TablaAS[32, 28].Add(new string[] { "E", "S'" });
            TablaAS[32, 44].Add(new string[] { "E", "S'" });
            TablaAS[33, 20].Add(new string[] { "e" }); 
            TablaAS[33, 23].Add(new string[] { "e" });
            TablaAS[33, 29].Add(new string[] { "e" });
            TablaAS[33, 33].Add(new string[] { "e" });
            TablaAS[33, 34].Add(new string[] { "e" });
            TablaAS[33, 35].Add(new string[] { "e" });
            TablaAS[33, 45].Add(new string[] { "e" });
            TablaAS[33, 47].Add(new string[] { "e" });
            TablaAS[33, 56].Add(new string[] { "+", "E", "S'" });
            TablaAS[33, 60].Add(new string[] { "e" });
            TablaAS[33, 61].Add(new string[] { "e" });
            TablaAS[33, 62].Add(new string[] { "e" });

            TablaAS[34, 1].Add(new string[] { "F", "E'" });
            TablaAS[34, 3].Add(new string[] { "F", "E'" });
            TablaAS[34, 24].Add(new string[] { "F", "E'" });
            TablaAS[34, 25].Add(new string[] { "F", "E'" });
            TablaAS[34, 26].Add(new string[] { "F", "E'" });
            TablaAS[34, 27].Add(new string[] { "F", "E'" });
            TablaAS[34, 28].Add(new string[] { "F", "E'" });
            TablaAS[34, 44].Add(new string[] { "F", "E'" });

            TablaAS[35, 20].Add(new string[] { "e" });
            TablaAS[35, 23].Add(new string[] { "e" });
            TablaAS[35, 29].Add(new string[] { "e" });
            TablaAS[35, 33].Add(new string[] { "e" });
            TablaAS[35, 34].Add(new string[] { "e" });
            TablaAS[35, 35].Add(new string[] { "e" });
            TablaAS[35, 45].Add(new string[] { "e" });
            TablaAS[35, 47].Add(new string[] { "e" });
            TablaAS[35, 49].Add(new string[] { "e" });
            TablaAS[35, 56].Add(new string[] { "e" });
            TablaAS[35, 58].Add(new string[] { "*", "F", "E'" });
            TablaAS[35, 60].Add(new string[] { "e" });
            TablaAS[35, 61].Add(new string[] { "e" });
            TablaAS[35, 62].Add(new string[] { "e" });

            TablaAS[36, 1].Add(new string[] { "G", "F'" });
            TablaAS[36, 3].Add(new string[] { "G", "F'" });
            TablaAS[36, 24].Add(new string[] { "G", "F'" });
            TablaAS[36, 25].Add(new string[] { "G", "F'" });
            TablaAS[36, 26].Add(new string[] { "G", "F'" });
            TablaAS[36, 27].Add(new string[] { "G", "F'" });
            TablaAS[36, 28].Add(new string[] { "G", "F'" });
            TablaAS[36, 44].Add(new string[] { "G", "F'" });

            TablaAS[37, 20].Add(new string[] { "e" });
            TablaAS[37, 23].Add(new string[] { "e" });
            TablaAS[37, 29].Add(new string[] { "e" });
            TablaAS[37, 33].Add(new string[] { "e" });
            TablaAS[37, 34].Add(new string[] { "e" });
            TablaAS[37, 35].Add(new string[] { "e" });
            TablaAS[37, 45].Add(new string[] { "e" });
            TablaAS[37, 47].Add(new string[] { "e" });
            TablaAS[37, 49].Add(new string[] { "e" });
            TablaAS[37, 56].Add(new string[] { "e" });
            TablaAS[37, 57].Add(new string[] { "-", "G", "F'" });
            TablaAS[37, 58].Add(new string[] { "e" });
            TablaAS[37, 60].Add(new string[] { "e" });
            TablaAS[37, 61].Add(new string[] { "e" });
            TablaAS[37, 62].Add(new string[] { "e" });

            TablaAS[38, 1].Add(new string[] { "H", "G'" });
            TablaAS[38, 3].Add(new string[] { "H", "G'" });
            TablaAS[38, 24].Add(new string[] { "H", "G'" });
            TablaAS[38, 25].Add(new string[] { "H", "G'" });
            TablaAS[38, 26].Add(new string[] { "H", "G'" });
            TablaAS[38, 27].Add(new string[] { "H", "G'" });
            TablaAS[38, 28].Add(new string[] { "H", "G'" });
            TablaAS[38, 44].Add(new string[] { "H", "G'" });

            TablaAS[39, 20].Add(new string[] { "e" });
            TablaAS[39, 23].Add(new string[] { "e" });
            TablaAS[39, 29].Add(new string[] { "e" });
            TablaAS[39, 33].Add(new string[] { "e" });
            TablaAS[39, 34].Add(new string[] { "e" });
            TablaAS[39, 35].Add(new string[] { "e" });
            TablaAS[39, 45].Add(new string[] { "e" });
            TablaAS[39, 47].Add(new string[] { "e" });
            TablaAS[39, 49].Add(new string[] { "e" });
            TablaAS[39, 56].Add(new string[] { "e" });
            TablaAS[39, 57].Add(new string[] { "e" });
            TablaAS[39, 58].Add(new string[] { "e" });
            TablaAS[39, 59].Add(new string[] { "/", "H", "G'" });
            TablaAS[39, 60].Add(new string[] { "e" });
            TablaAS[39, 61].Add(new string[] { "e" });
            TablaAS[39, 62].Add(new string[] { "e" });

            TablaAS[40, 1].Add(new string[] { "id" });
            TablaAS[40, 3].Add(new string[] { "num" });
            TablaAS[40, 24].Add(new string[] { "MIN", "(", "id", ")" });
            TablaAS[40, 25].Add(new string[] { "MAX", "(", "id", ")" });
            TablaAS[40, 26].Add(new string[] { "PROM", "(", "id", ")" });
            TablaAS[40, 27].Add(new string[] { "SUM", "(", "id", ")" });
            TablaAS[40, 28].Add(new string[] { "CONTAR", "(", "id", ")" });
            TablaAS[40, 44].Add(new string[] { "(", "S", ")" });

            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 63; j++)
                {
                    if (TablaAS[i, j].Count.Equals(0))
                        TablaAS[i, j].Add(new string[] { "ERROR" });
                }
            }
        }

        public string[] Buscar(string cFila, string cColumna)
        {
            int Fila = 0, Columna = 0;

            for (int i = 1; i < 41; i++)
            {
                if (((string)TablaAS[i, 0][0]).Equals(cFila))
                {
                    Fila = i;
                    break;
                }
            }

            for (int i = 1; i < 63; i++)
            {
                if (((string)TablaAS[0, i][0]).Equals(cColumna))
                {
                    Columna = i;
                    break;
                }
            }

            if (Fila.Equals(0) || Columna.Equals(0))
                return new string[] { "ERROR" };

            return ((string[])TablaAS[Fila, Columna][0]);
        }
    }
}