using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front
{
    public partial class FormNuevoArticulo : Form
    {
        public FormNuevoArticulo(int modo)
        {
            InitializeComponent();

            if(modo == 1)
            {
                lblTitulo.Text = "Agregar nuevo artículo";
            }
            else
            {
                lblTitulo.Text = "Modificar artículo";
            }
        }

        private void FormCargarArt_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Cancelar_Art_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
