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
            catch (Exception ex)
            {

                MessageBox.Show("Error al cargar datos..." + ex);
            }
            finally
            {
                dgvArticulos.DataSource = listaArticulos;
                dgvArticulos.Columns.Remove("imagenArticulo");
                ComboBoxCampo.Items.Clear();
                ComboBoxCampo.Items.Add("precio");
                ComboBoxCampo.Items.Add("nombre");
                ComboBoxCampo.Items.Add("categoría");
                var url = listaArticulos[0].imagenArticulo.Url;
                try
                {
                    pcBox_Principal.Load(url);
                }
                catch (Exception)
                {
                    pcBox_Principal.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
                }

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormNuevoArticulo formNuevoArticulo = new FormNuevoArticulo("Agregar");
            formNuevoArticulo.ShowDialog();
            cargarDgv();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo Seleccionado;
            btnModificar.Enabled = false;
            if (dgvArticulos.SelectedRows.Count > 0)
            {
                btnModificar.Enabled = true;
                Seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                FormNuevoArticulo formNuevoArticulo = new FormNuevoArticulo("Modificar", Seleccionado);
                formNuevoArticulo.ShowDialog();
                cargarDgv();
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                pcBox_Principal.Load(seleccionado.imagenArticulo.Url);

            }
            catch (Exception)
            {
                pcBox_Principal.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
            }
        }
    }
}
