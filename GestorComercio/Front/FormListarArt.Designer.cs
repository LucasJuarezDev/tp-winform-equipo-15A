namespace Front
{
    partial class FormListarArt
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
            this.DGV_VerArticulos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_VerArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_VerArticulos
            // 
            this.DGV_VerArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_VerArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGV_VerArticulos.Location = new System.Drawing.Point(12, 52);
            this.DGV_VerArticulos.MaximumSize = new System.Drawing.Size(652, 279);
            this.DGV_VerArticulos.MinimumSize = new System.Drawing.Size(652, 279);
            this.DGV_VerArticulos.MultiSelect = false;
            this.DGV_VerArticulos.Name = "DGV_VerArticulos";
            this.DGV_VerArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_VerArticulos.Size = new System.Drawing.Size(652, 279);
            this.DGV_VerArticulos.TabIndex = 1;
            // 
            // FormListarArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 371);
            this.Controls.Add(this.DGV_VerArticulos);
            this.MaximumSize = new System.Drawing.Size(692, 410);
            this.MinimumSize = new System.Drawing.Size(692, 410);
            this.Name = "FormListarArt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ver Articulos";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_VerArticulos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_VerArticulos;
    }
}