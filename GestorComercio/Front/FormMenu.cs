using Dominio;
using Negocio;
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

        List<Articulo> listaArticulos = new List<Articulo>();

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            cargarDgv();

        }




        //------------------------funciones-------------------------------------

        private void cargarDgv()
        {
            articuloNegocio articulos = new articuloNegocio();
            

            try
            {
                listaArticulos = articulos.listar();
                
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cargar datos...");
            }
            finally
            {
                dgvArticulos.DataSource = listaArticulos;
                ComboBoxCampo.Items.Clear();
                ComboBoxCampo.Items.Add("precio");
                ComboBoxCampo.Items.Add("nombre");
                ComboBoxCampo.Items.Add("categoría");
            }
        }


    }
}
