namespace cSQL
{
    partial class TablaSimbolos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listaSimbolos = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.NumeroSimbolosLbl = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ListaErrores = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaSimbolos
            // 
            this.listaSimbolos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listaSimbolos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listaSimbolos.FullRowSelect = true;
            this.listaSimbolos.GridLines = true;
            this.listaSimbolos.Location = new System.Drawing.Point(3, 3);
            this.listaSimbolos.Name = "listaSimbolos";
            this.listaSimbolos.Size = new System.Drawing.Size(523, 506);
            this.listaSimbolos.TabIndex = 0;
            this.listaSimbolos.UseCompatibleStateImageBehavior = false;
            this.listaSimbolos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Id";
            this.columnHeader5.Width = 30;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Token";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Patrón";
            this.columnHeader2.Width = 128;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Línea de referencia";
            this.columnHeader3.Width = 119;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Id Identificador";
            this.columnHeader4.Width = 90;
            // 
            // NumeroSimbolosLbl
            // 
            this.NumeroSimbolosLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NumeroSimbolosLbl.AutoSize = true;
            this.NumeroSimbolosLbl.Location = new System.Drawing.Point(6, 512);
            this.NumeroSimbolosLbl.Name = "NumeroSimbolosLbl";
            this.NumeroSimbolosLbl.Size = new System.Drawing.Size(0, 13);
            this.NumeroSimbolosLbl.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(537, 556);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listaSimbolos);
            this.tabPage1.Controls.Add(this.NumeroSimbolosLbl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(529, 530);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tabla de Símbolos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ListaErrores);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(529, 530);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tabla de Errores";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ListaErrores
            // 
            this.ListaErrores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.ListaErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaErrores.FullRowSelect = true;
            this.ListaErrores.GridLines = true;
            this.ListaErrores.Location = new System.Drawing.Point(3, 3);
            this.ListaErrores.Name = "ListaErrores";
            this.ListaErrores.Size = new System.Drawing.Size(523, 524);
            this.ListaErrores.TabIndex = 0;
            this.ListaErrores.UseCompatibleStateImageBehavior = false;
            this.ListaErrores.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Id";
            this.columnHeader6.Width = 44;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Token";
            this.columnHeader7.Width = 169;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Descripcion";
            this.columnHeader8.Width = 197;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Linea de referencia";
            this.columnHeader9.Width = 106;
            // 
            // TablaSimbolos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 556);
            this.Controls.Add(this.tabControl1);
            this.Name = "TablaSimbolos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tablas";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listaSimbolos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label NumeroSimbolosLbl;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView ListaErrores;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}