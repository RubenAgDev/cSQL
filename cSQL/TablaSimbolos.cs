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
    public partial class TablaSimbolos : Form
    {
        public TablaSimbolos(ArrayList Valores, List<Error> Errores)
        {
            InitializeComponent();

            foreach (string[] Simbolo in Valores)
                listaSimbolos.Items.Add(new ListViewItem(Simbolo));

            NumeroSimbolosLbl.Text = Valores.Count + " símbolos encontrados";

            foreach (Error MiError in Errores)
                ListaErrores.Items.Add(new ListViewItem(new string[] { MiError.Id.ToString(), MiError.Token, MiError.Descripcion, MiError.LineaReferencia.ToString() }));
        }
    }
}