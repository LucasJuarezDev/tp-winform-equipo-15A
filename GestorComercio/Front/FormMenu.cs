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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormNuevoArticulo VentanaNuevoArticulo = new FormNuevoArticulo(1);
            VentanaNuevoArticulo.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormNuevoArticulo VentanaNuevoArticulo = new FormNuevoArticulo(2);
            VentanaNuevoArticulo.ShowDialog();
        }
    }
}
