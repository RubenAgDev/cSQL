using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cSQL
{
    public partial class ArbolForm : Form
    {
        private TablaAnalisisSintactico Tabla;
        private Arbol MiArbol;
        private ArrayList Simbolos;
        private ArrayList SimbolosConTipo;
        private int Index;
        public int Repeticiones;
        public string TipoError;
        public string TextoOperaciones = "";
 
        public ArbolForm(ArrayList LosSimbolos)
        {
            InitializeComponent();

            SimbolosTree.Nodes.Clear();

            Index = 0;
            Tabla = new TablaAnalisisSintactico();
            MiArbol = new Arbol("A");
            Repeticiones = 0;

            Simbolos = LosSimbolos;

            ObtenerTipos();

            if (!VerificarExpresiones())
            {
                Repeticiones += 2;
                TipoError = "Los tipos en la expresion no son compatibles";
                return;
            }
            
            LlenarArbol(MiArbol.Raiz);

            SimbolosTree.Nodes.Add(new TreeNode(MiArbol.Raiz.Dato, ObtenerDescendientes(MiArbol.Raiz)));
        }

        private void LlenarArbol(Rama Padre)
        {
            string[] Nuevo;

            if (Simbolos[Index].Equals("$"))
                Nuevo = Tabla.Buscar(Padre.Dato, "$");
            else
                Nuevo = Tabla.Buscar(Padre.Dato, AnalizadorSintactico.ModificarPorPatron(Simbolos[Index].ToString()));

            if (Nuevo[0].Equals("e"))
                return;

            int x = 0;

            if (EsTerminal(Nuevo[x]))
            {
                if (Lista.ObtenerPatron(Simbolos[Index].ToString()).Equals("Palabra Reservada") || Lista.ObtenerPatron(Simbolos[Index].ToString()).Equals("Símbolo"))
                    Padre.Hijo = new Rama(null, null, Simbolos[Index].ToString());
                else
                    Padre.Hijo = new Rama(null, null, Simbolos[Index].ToString(), ((string[])SimbolosConTipo[Index])[1]);

                Index++;
            }
            else
            {
                Padre.Hijo = new Rama(null, null, Nuevo[x]);
                LlenarArbol(Padre.Hijo);
            }

            Rama _Nodo = Padre.Hijo;

            x++;

            while (x < Nuevo.Length)
            {
                if (EsTerminal(Nuevo[x]))
                {
                    if (Lista.ObtenerPatron(Simbolos[Index].ToString()).Equals("Identificador"))
                        _Nodo.Hermano = new Rama(null, null, Simbolos[Index].ToString(), ((string[])SimbolosConTipo[Index])[1]);
                    else
                        _Nodo.Hermano = new Rama(null, null, Simbolos[Index].ToString());

                    Index++;
                }
                else
                {
                    _Nodo.Hermano = new Rama(null, null, Nuevo[x]);
                    LlenarArbol(_Nodo.Hermano);
                }

                _Nodo = _Nodo.Hermano;

                x++;
            }
        }

        private bool EsTerminal(string Simbolo)
        {
            for (int i = 1; i < 63; i++)
            {
                if (((string)Tabla.TablaAS[0, i][0]).Equals(Simbolo))
                    return true;
            }

            return false;
        }

        private void ObtenerTipos()
        {
            SimbolosConTipo = new ArrayList();

            for (int i = 0; i < Simbolos.Count; i++)
            {
                if (Lista.ObtenerPatron(Simbolos[i].ToString()).Equals("Identificador"))
                {
                    if (Simbolos[i - 1].ToString().Equals("TABLA") && Simbolos[i - 2].ToString().Equals("CREAR"))
                    {
                        ArrayList Campos = new ArrayList();

                        for (int j = i + 2; ; j++)
                        {
                            if (Simbolos[j].ToString().Equals(")") && Simbolos[j + 1].ToString().Equals(";"))
                                break;
                            else if (Lista.ObtenerPatron(Simbolos[j].ToString()).Equals("Identificador"))
                                Campos.Add(Simbolos[j].ToString());
                        }

                        for (int j = 0; j < Campos.Count; j++)
                        {
                            for (int k = 0; k < Campos.Count; k++)
                            {
                                if (Campos[k].ToString().Equals(Campos[j].ToString()))
                                    Repeticiones++;
                            }
                            if (Repeticiones > 1)
                            {
                                TipoError = "El campo '" + Campos[j].ToString() + "' se ha declarado mas de una vez en la tabla '" + Simbolos[i] + "'";
                                break;
                            }
                            else
                                Repeticiones = 0;
                        }
                    }

                    if (Simbolos[i - 1].ToString().Equals("BD") || Simbolos[i - 1].ToString().Equals("TABLA"))
                        SimbolosConTipo.Add(new string[] { Simbolos[i].ToString(), Simbolos[i - 1].ToString() });
                    else if (Simbolos[i + 1].ToString().Equals("NUM") || Simbolos[i + 1].ToString().Equals("TEXTO") || Simbolos[i + 1].ToString().Equals("FECHA"))
                        SimbolosConTipo.Add(new string[] { Simbolos[i].ToString(), Simbolos[i + 1].ToString() });
                    else if (Simbolos[i - 1].ToString().Equals("USAR"))
                        SimbolosConTipo.Add(new string[] { Simbolos[i].ToString(), "BD" });
                    else
                        SimbolosConTipo.Add(new string[] { Simbolos[i].ToString(), BuscarTipoAnterior(Simbolos[i].ToString(), i) });

                    if (i > 1)
                    {
                        if (Simbolos[i - 2].ToString().Equals("SUM") || Simbolos[i - 2].ToString().Equals("MIN") || Simbolos[i - 2].ToString().Equals("MAX") || Simbolos[i - 2].ToString().Equals("PROM"))
                        {
                            if (!((string[])SimbolosConTipo[i])[1].Equals("NUM"))
                            {
                                Repeticiones++;
                                TipoError = "El parámetro del campo agregado no corresponde al requerido ' " + Simbolos[i].ToString() + " '";
                            }
                        }
                    }
                }
                else if (Lista.ObtenerPatron(Simbolos[i].ToString()).Equals("Número"))
                    SimbolosConTipo.Add(new string[] { Simbolos[i].ToString(), "NUM" });
                else if(Lista.ObtenerPatron(Simbolos[i].ToString()).Equals("Texto"))
                    SimbolosConTipo.Add(new string[] { Simbolos[i].ToString(), "TEXTO" });
                else
                    SimbolosConTipo.Add(new string[] { Simbolos[i].ToString(), "" });
            }
        }

        private string BuscarTipoAnterior(string Identificador, int Indice)
        {
            for (int i = Indice - 1; i > 0; i--)
            {
                if (Simbolos[i].ToString().Equals(Identificador))
                    return ((string[])SimbolosConTipo[i])[1];
            }

            return "";
        }
        
        private bool VerificarExpresiones()
        {
            ArrayList Expresion;
            Postfija PFija;
            
            for (int i = 0; i < SimbolosConTipo.Count; i++)
            {
                if (((string[])SimbolosConTipo[i])[0].Equals("+") || ((string[])SimbolosConTipo[i])[0].Equals("-") || ((string[])SimbolosConTipo[i])[0].Equals("*") || ((string[])SimbolosConTipo[i])[0].Equals("/"))
                {
                    Expresion = new ArrayList();

                    for (int j = ObtenerIndiceInicioExpresion(i); ; j++)
                    {
                        if (Lista.ObtenerPatron(Simbolos[j].ToString()).Equals("Identificador"))
                        {
                            if (!((string[])SimbolosConTipo[j])[1].Equals("NUM"))
                                return false;
                            else
                                Expresion.Add(Simbolos[j].ToString());
                        }
                        else if (Simbolos[j].Equals(",") || Simbolos[j].Equals("DE") || Simbolos[j].Equals(";"))
                        {
                            i = j;
                            break;
                        }
                        else if (Simbolos[j].Equals("+") || Simbolos[j].Equals("-") || Simbolos[j].Equals("*") ||
                            Simbolos[j].Equals("/") || Simbolos[j].Equals("(") || Simbolos[j].Equals(")") ||
                            Lista.ObtenerPatron(Simbolos[j].ToString()).Equals("Número") || Simbolos[j].Equals("PROM") || Simbolos[j].Equals("SUM") ||
                            Simbolos[j].Equals("MIN") || Simbolos[j].Equals("MAX") || Simbolos[j].Equals("CONTAR"))
                            Expresion.Add(Simbolos[j].ToString());
                    }

                    if (Expresion.Count > 0)
                    {
                        PFija = new Postfija(Expresion);
                        TextoOperaciones += PFija.ElTexto + "\r\n";
                    }
                }
            }

            return CompararTipos();
        }

        private bool CompararTipos()
        {
            ArrayList TiposIzquierda = new ArrayList();
            ArrayList TiposDerecha = new ArrayList();
            bool FinIzquierda;

            for (int i = 0; i < SimbolosConTipo.Count; i++)
            {
                if (TiposIzquierda.Count > 0)
                {
                    TiposIzquierda = new ArrayList();
                    TiposDerecha = new ArrayList();
                }

                if (Simbolos[i].Equals("INSERTAR"))
                {
                    if (Simbolos[i + 3].Equals(")"))
                        i += 2;

                    FinIzquierda = false;

                    for (int j = i + 4; ; j++)
                    {
                        if (Simbolos[j].Equals(","))
                            continue;

                        if (FinIzquierda)
                            TiposDerecha.Add(ObtenerTipo(ref j));
                        else
                            TiposIzquierda.Add(ObtenerTipo(ref j));

                        if (Simbolos[j + 1].Equals(")"))
                        {
                            if (FinIzquierda)
                            {
                                if (Simbolos[j + 3].Equals("}"))
                                    break;
                                else
                                {
                                    if (Simbolos[j + 3].Equals("$") || !Simbolos[j + 3].Equals("("))
                                        break;

                                    for (int k = 0; k < TiposIzquierda.Count; k++)
                                    {
                                        if (!TiposIzquierda[k].Equals(TiposDerecha[k]))
                                            return false;
                                    }

                                    FinIzquierda = false;
                                    TiposIzquierda = new ArrayList();
                                    TiposDerecha = new ArrayList();

                                    j += 3;
                                }
                            }
                            else
                            {
                                j += 3;
                                FinIzquierda = true;
                            }
                        }
                    }
                }
                else if (Simbolos[i].Equals("COLOCAR"))
                {
                    string PrimerTipo = "";

                    if (Simbolos[i + 1].Equals(")"))
                        i += 2;

                    for (int j = i + 1; ; j++)
                    {
                        if (!Simbolos[j + 1].Equals("="))
                        {
                            PrimerTipo = "NUM";

                            while (!Simbolos[j].Equals("="))
                                j++;
                        }
                        else
                        {
                            PrimerTipo = ((string[])SimbolosConTipo[j])[1];
                            j++;
                        }

                        j++;

                        if (Simbolos[j + 1].Equals(",") || Simbolos[j + 1].Equals(";") || !Simbolos[j + 1].Equals("DONDE"))
                        {
                            if (!PrimerTipo.Equals(((string[])SimbolosConTipo[j])[1]))
                                return false;
                            else
                                j++;
                        }
                        else
                        {
                            if (!PrimerTipo.Equals("NUM"))
                                return false;
                            else
                            {
                                for (int k = j; ; k++)
                                {
                                    if (Simbolos[j].Equals(",") || Simbolos[j].Equals(";"))
                                        break;
                                    else
                                        j++;
                                }
                            }
                        }

                        if (Simbolos[j].Equals("DONDE"))
                            break;

                        if (Simbolos[j].Equals(";"))
                        {
                            if (Simbolos[j + 1].Equals("}"))
                                break;
                            else
                            {
                                if (Lista.ObtenerPatron(Simbolos[j + 1].ToString()).Equals("Identificador"))
                                    continue;
                                else
                                    break;
                            }
                        }
                    }
                }

                for (int j = 0; j < TiposIzquierda.Count; j++)
                {
                    if (!TiposIzquierda[j].Equals(TiposDerecha[j]))
                        return false;
                }
            }

            return true;
        }

        private string ObtenerTipo(ref int Indice)
        {
            if (Simbolos[Indice + 1].Equals(",") || Simbolos[Indice + 1].Equals(")"))
                return ((string[])SimbolosConTipo[Indice])[1];
            else
            {
                for (int i = Indice; ; i++)
                {
                    if (Simbolos[i + 1].Equals(",") || Simbolos[i + 1].Equals(")"))
                        break;
                    else
                        Indice++;
                }

                return "NUM";
            }
        }

        private int ObtenerIndiceInicioExpresion(int IndiceActual)
        {
            for (int i = IndiceActual; ; i--)
            {
                if (Simbolos[i].ToString().Equals("SELECCIONAR") || Simbolos[i].ToString().Equals(",") || Simbolos[i].ToString().Equals("="))
                    return i + 1;
            }
        }

        private TreeNode[] ObtenerDescendientes(Rama Padre)
        {
            Rama _Rama = Padre.Hijo;
            int TotalHermanos = 1;

            while (_Rama.Hermano != null)
            {
                TotalHermanos++;
                _Rama = _Rama.Hermano;
            }

            TreeNode[] Hermanos = new TreeNode[TotalHermanos];

            _Rama = Padre.Hijo;

            for (int i = 0; i < Hermanos.Length; i++)
            {
                if (_Rama.Hijo != null)
                    Hermanos[i] = new TreeNode(_Rama.Dato + "    ( " + _Rama.Tipo + " )", ObtenerDescendientes(_Rama));
                else
                    Hermanos[i] = new TreeNode(_Rama.Dato + "    ( " + _Rama.Tipo + " )");

                _Rama = _Rama.Hermano;
            }

            return Hermanos;
        }
    }
}