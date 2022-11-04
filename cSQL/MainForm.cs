using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace cSQL
{
    public partial class MainForm : Form
    {
        private AnalizadorSintactico AnalizadorSint;
        private AnalizadorLexico AnalizadorLex;
        private TablaSimbolos TSimbolos;
        private ArbolForm ArbFrm;
        private string RutaGuardar;
        private string RutaGuardar2;
        private TraduccionSQL Traduccion;

        private ArrayList Simbolos;

        public MainForm()
        {
            InitializeComponent();
            openDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            saveDialog.Filter = "Archivo de SQL (*.sql)|*.sql";
            RutaGuardar = "";
            RutaGuardar2 = "";
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void compilarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compilar();
            if (EstadoLB.Text == "Listo")
                GuardarArchivo();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Compilar();
            if (EstadoLB.Text == "Listo")
                GuardarArchivo();
        }

        private void Compilar()
        {
            AnalizadorLex = new AnalizadorLexico(CodeBox.Text);

            Simbolos = AnalizadorLex.ObtenerSimbolos();

            EstadoLB.Text += "Listo";

            if (AnalizadorLex.ObtenerErrores().Count.Equals(0))
            {
                AnalizadorSint = new AnalizadorSintactico(AnalizadorLex.LosSimbolos);
                EstadoLB.Text = AnalizadorSint.AnalisisConPila();

                if (EstadoLB.Text == "Análisis sintáctico aprobado correctamente")
                {
                    ArbFrm = new ArbolForm(AnalizadorLex.LosSimbolos);
                    EstadoLB.Text = "Listo";

                    if (ArbFrm.Repeticiones > 1)
                        EstadoLB.Text = "Error Semántico: " + ArbFrm.TipoError;
                    else
                        Traduccion = new TraduccionSQL(AnalizadorLex.LosSimbolos);
                }
            }
            else
                EstadoLB.Text = "Error Léxico";
        }

        private void verCódigoFormateadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(AnalizadorLex is AnalizadorLexico))
            {
                MessageBox.Show("Aún no se ha compilado código...", "No puedes continuar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(AnalizadorLex.CodigoNuevo);
        }

        private void verTablaDeSímbolosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(Simbolos is ArrayList))
            {
                MessageBox.Show("No se ha compilado código aún", "No puedes continuar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            TSimbolos = new TablaSimbolos(Simbolos, AnalizadorLex.ObtenerErrores());

            TSimbolos.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void AbrirArchivo()
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string RutaAbrir = openDialog.FileName;
                StreamReader SR = new StreamReader(RutaAbrir);
                CodeBox.Text = SR.ReadToEnd();
                SR.Close();
            }
        }

        private void GuardarArchivo()
        {
            StreamWriter SW;
            if (RutaGuardar.Equals(""))
            {
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    RutaGuardar = saveDialog.FileName;
                    SW = new StreamWriter(RutaGuardar);
                    SW.Write(Traduccion.TextoTraducido);
                    SW.Close();

                    RutaGuardar2 = RutaGuardar.Substring(0, RutaGuardar.LastIndexOf('.') - 1);
                    RutaGuardar2 += ".txt";
                    SW = new StreamWriter(RutaGuardar2);
                    SW.Write(ArbFrm.TextoOperaciones);
                    SW.Close();
                }
            }
            else
            {
                SW = new StreamWriter(RutaGuardar);
                SW.Write(Traduccion.TextoTraducido);
                SW.Close();

                SW = new StreamWriter(RutaGuardar2);
                SW.Write(ArbFrm.TextoOperaciones);
                SW.Close();
            }
        }

        private void CodeBox_TextChanged(object sender, EventArgs e)
        {
            NumCaracteres.Text = "Car " + (CodeBox.Text.Length + 1).ToString();
            EstadoLB.Text = "Existen cambios que no se han guardado";
        }

        private void BtnArbol_Click(object sender, EventArgs e)
        {
            if (ArbFrm is ArbolForm)
                ArbFrm.ShowDialog();
            else
                MessageBox.Show("No has compilado código aún, o existen errores en el código", "No puedes continuar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}