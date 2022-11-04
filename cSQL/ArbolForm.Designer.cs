namespace cSQL
{
    partial class ArbolForm
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
            this.SimbolosTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // SimbolosTree
            // 
            this.SimbolosTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SimbolosTree.Location = new System.Drawing.Point(12, 12);
            this.SimbolosTree.Name = "SimbolosTree";
            this.SimbolosTree.Size = new System.Drawing.Size(714, 559);
            this.SimbolosTree.TabIndex = 0;
            // 
            // ArbolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 583);
            this.Controls.Add(this.SimbolosTree);
            this.Name = "ArbolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArbolForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView SimbolosTree;


    }
}