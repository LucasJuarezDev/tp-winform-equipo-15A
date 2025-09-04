namespace Front
{
    partial class FormCargarArt
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
            this.Titulo = new System.Windows.Forms.Label();
            this.txtBox_description = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_description = new System.Windows.Forms.Label();
            this.txtBox_name = new System.Windows.Forms.TextBox();
            this.Subrayado = new System.Windows.Forms.Label();
            this.TXT_PrecioVenta = new System.Windows.Forms.TextBox();
            this.Titulo_PrecioVenta = new System.Windows.Forms.Label();
            this.CB_Categoria = new System.Windows.Forms.ComboBox();
            this.TIT_Categoria = new System.Windows.Forms.Label();
            this.CB_Marca = new System.Windows.Forms.ComboBox();
            this.TIT_Marca = new System.Windows.Forms.Label();
            this.BTN_Cancelar_Art = new System.Windows.Forms.Button();
            this.BTN_Cargar_Art = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Arial Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(149, 41);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(168, 23);
            this.Titulo.TabIndex = 23;
            this.Titulo.Text = "NUEVO ARTÍCULO";
            // 
            // txtBox_description
            // 
            this.txtBox_description.Location = new System.Drawing.Point(110, 154);
            this.txtBox_description.MaxLength = 50;
            this.txtBox_description.Name = "txtBox_description";
            this.txtBox_description.Size = new System.Drawing.Size(255, 20);
            this.txtBox_description.TabIndex = 1;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(33, 102);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(63, 16);
            this.lbl_name.TabIndex = 27;
            this.lbl_name.Text = "NOMBRE";
            // 
            // lbl_description
            // 
            this.lbl_description.AutoSize = true;
            this.lbl_description.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description.Location = new System.Drawing.Point(11, 159);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(85, 15);
            this.lbl_description.TabIndex = 26;
            this.lbl_description.Text = "DESCRIPCION";
            // 
            // txtBox_name
            // 
            this.txtBox_name.Location = new System.Drawing.Point(110, 102);
            this.txtBox_name.MaxLength = 50;
            this.txtBox_name.Name = "txtBox_name";
            this.txtBox_name.Size = new System.Drawing.Size(255, 20);
            this.txtBox_name.TabIndex = 0;
            // 
            // Subrayado
            // 
            this.Subrayado.AutoSize = true;
            this.Subrayado.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.Subrayado.Location = new System.Drawing.Point(99, 289);
            this.Subrayado.Name = "Subrayado";
            this.Subrayado.Size = new System.Drawing.Size(268, 19);
            this.Subrayado.TabIndex = 37;
            this.Subrayado.Text = "_____________________________________";
            // 
            // TXT_PrecioVenta
            // 
            this.TXT_PrecioVenta.Location = new System.Drawing.Point(110, 189);
            this.TXT_PrecioVenta.MaxLength = 7;
            this.TXT_PrecioVenta.Name = "TXT_PrecioVenta";
            this.TXT_PrecioVenta.Size = new System.Drawing.Size(88, 20);
            this.TXT_PrecioVenta.TabIndex = 2;
            // 
            // Titulo_PrecioVenta
            // 
            this.Titulo_PrecioVenta.AutoSize = true;
            this.Titulo_PrecioVenta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo_PrecioVenta.Location = new System.Drawing.Point(71, 193);
            this.Titulo_PrecioVenta.Name = "Titulo_PrecioVenta";
            this.Titulo_PrecioVenta.Size = new System.Drawing.Size(25, 16);
            this.Titulo_PrecioVenta.TabIndex = 36;
            this.Titulo_PrecioVenta.Text = "PU";
            // 
            // CB_Categoria
            // 
            this.CB_Categoria.FormattingEnabled = true;
            this.CB_Categoria.Location = new System.Drawing.Point(110, 265);
            this.CB_Categoria.Name = "CB_Categoria";
            this.CB_Categoria.Size = new System.Drawing.Size(255, 21);
            this.CB_Categoria.TabIndex = 4;
            // 
            // TIT_Categoria
            // 
            this.TIT_Categoria.AutoSize = true;
            this.TIT_Categoria.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIT_Categoria.Location = new System.Drawing.Point(2, 271);
            this.TIT_Categoria.Name = "TIT_Categoria";
            this.TIT_Categoria.Size = new System.Drawing.Size(94, 15);
            this.TIT_Categoria.TabIndex = 35;
            this.TIT_Categoria.Text = "CLASIFICACION";
            // 
            // CB_Marca
            // 
            this.CB_Marca.FormattingEnabled = true;
            this.CB_Marca.Location = new System.Drawing.Point(110, 221);
            this.CB_Marca.Name = "CB_Marca";
            this.CB_Marca.Size = new System.Drawing.Size(255, 21);
            this.CB_Marca.TabIndex = 3;
            // 
            // TIT_Marca
            // 
            this.TIT_Marca.AutoSize = true;
            this.TIT_Marca.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIT_Marca.Location = new System.Drawing.Point(42, 226);
            this.TIT_Marca.Name = "TIT_Marca";
            this.TIT_Marca.Size = new System.Drawing.Size(54, 16);
            this.TIT_Marca.TabIndex = 34;
            this.TIT_Marca.Text = "MARCA";
            // 
            // BTN_Cancelar_Art
            // 
            this.BTN_Cancelar_Art.Location = new System.Drawing.Point(290, 325);
            this.BTN_Cancelar_Art.Name = "BTN_Cancelar_Art";
            this.BTN_Cancelar_Art.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cancelar_Art.TabIndex = 6;
            this.BTN_Cancelar_Art.Text = "Cancelar";
            this.BTN_Cancelar_Art.UseVisualStyleBackColor = true;
            // 
            // BTN_Cargar_Art
            // 
            this.BTN_Cargar_Art.Location = new System.Drawing.Point(103, 325);
            this.BTN_Cargar_Art.Name = "BTN_Cargar_Art";
            this.BTN_Cargar_Art.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cargar_Art.TabIndex = 5;
            this.BTN_Cargar_Art.Text = "Cargar";
            this.BTN_Cargar_Art.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 19);
            this.label1.TabIndex = 38;
            this.label1.Text = "_____________________________________";
            // 
            // FormCargarArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(434, 375);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Subrayado);
            this.Controls.Add(this.TXT_PrecioVenta);
            this.Controls.Add(this.Titulo_PrecioVenta);
            this.Controls.Add(this.CB_Categoria);
            this.Controls.Add(this.TIT_Categoria);
            this.Controls.Add(this.CB_Marca);
            this.Controls.Add(this.TIT_Marca);
            this.Controls.Add(this.BTN_Cancelar_Art);
            this.Controls.Add(this.BTN_Cargar_Art);
            this.Controls.Add(this.txtBox_name);
            this.Controls.Add(this.txtBox_description);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_description);
            this.Controls.Add(this.Titulo);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 414);
            this.MinimumSize = new System.Drawing.Size(450, 414);
            this.Name = "FormCargarArt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.TextBox txtBox_description;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_description;
        private System.Windows.Forms.TextBox txtBox_name;
        private System.Windows.Forms.Label Subrayado;
        private System.Windows.Forms.TextBox TXT_PrecioVenta;
        private System.Windows.Forms.Label Titulo_PrecioVenta;
        private System.Windows.Forms.ComboBox CB_Categoria;
        private System.Windows.Forms.Label TIT_Categoria;
        private System.Windows.Forms.ComboBox CB_Marca;
        private System.Windows.Forms.Label TIT_Marca;
        private System.Windows.Forms.Button BTN_Cancelar_Art;
        private System.Windows.Forms.Button BTN_Cargar_Art;
        private System.Windows.Forms.Label label1;
    }
}