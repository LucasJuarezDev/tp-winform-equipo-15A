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
using static System.Net.Mime.MediaTypeNames;

namespace Front
{
    public partial class FormNuevoArticulo : Form
    {
        private string Tipo = "";
        private Articulo Articulo = null;
        articuloNegocio articuloNegocio = new articuloNegocio();

        ///////////////////////////////////////  CARGAR ARTICULO  ////////////////////////////////////////////
        public FormNuevoArticulo(string tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
            lblTitulo.Text = "Agrega tu nuevo articulo";
            BTN_Cargar_Art.Text = "Cargar";

        }
        ///////////////////////////////////////  MODIFICAR ARTICULO  ////////////////////////////////////////////
        public FormNuevoArticulo(string tipo, Articulo articulo)
        {
            InitializeComponent();
            this.Tipo = tipo;
            lblTitulo.Text = "Modificar articulo";
            BTN_Cargar_Art.Text = "Modificar";
            this.Articulo = articulo;
        }

        private void FormNuevoArticulo_Load(object sender, EventArgs e)
        {
            marcaNegocio marcaNegocio = new marcaNegocio();
            categoriaNegocio categoriaNegocio = new categoriaNegocio();
            txtCodigo.Text = articuloNegocio.ReturnID().ToString();

            try
            {
                if (this.Tipo == "Modificar")
                {
                    cboMarca.DataSource = marcaNegocio.ListarMarcas();
                    cboMarca.ValueMember = "Id"; //     ID DE LOS OBJETOS QUE SE MUESTRAN
                    cboMarca.DisplayMember = "Descripcion"; //     VALOR QUE SE MOSTRARA EN EL COMBOBOX
                    cboCategoria.DataSource = categoriaNegocio.ListarCategorias();
                    cboCategoria.ValueMember = "Id";
                    cboCategoria.DisplayMember = "Descripcion";

                    if (Articulo != null)
                    {
                        txtNombre.Text = Articulo.Nombre;
                        txtDescripcion.Text = Articulo.Descripcion;
                        txtPrecio.Text = Articulo.Precio.ToString(); //toString por ser flotante
                        cboMarca.SelectedValue = Articulo.TipoMarca.Id;
                        cboCategoria.SelectedValue = Articulo.TipoCategoria.Id;
                    }
                }
                else if (this.Tipo == "Agregar")
                {
                    cboMarca.SelectedItem = -1;
                    cboCategoria.SelectedItem = -1;

                    cboCategoria.DataSource = categoriaNegocio.ListarCategorias();
                    cboCategoria.ValueMember = "Id";
                    cboCategoria.DisplayMember = "Descripcion";

                    cboMarca.DataSource = marcaNegocio.ListarMarcas();
                    cboMarca.ValueMember = "Id"; 
                    cboMarca.DisplayMember = "Descripcion";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        ///////////////////////////////////////  VALIDACIONES  ////////////////////////////////////////////

        private void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool ValidarCampos()
        {
            if 
            (
            txtNombre.Text != "" && txtDescripcion.Text != "" && 
            txtPrecio.Text != "" && cboCategoria.SelectedIndex >= 0 
            && cboMarca.SelectedIndex >= 0 && cmbImagenes.SelectedIndex >= 0
            )
            {
                    return true;
            }
            return false;
        }
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        ///////////////////////////////////  CERRAR Y CARGAR | MODIFICAR ARTICULO  ///////////////////////////////////
        private void BTN_Cancelar_Art_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BTN_Cargar_Art_Click(object sender, EventArgs e)
        {
            if(this.Tipo == "Modificar")
            {

            }
            else if(this.Tipo == "Agregar")
            {

            }
        }
    }
}
