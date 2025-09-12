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

        ///////////////////////////////////////  OTROS METODOS    ////////////////////////////////////////////
        private void cmbImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string url = ((Imagen)cmbImagenes.SelectedItem).Url;
                pbxAgregado.Load(url);
            }
            catch (Exception)
            {
                pbxAgregado.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
            }
        }

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
            imagenNegocio imagenNegocio = new imagenNegocio();
            txtIdArt.Text = this.Tipo == "Agregar" ? articuloNegocio.ReturnID().ToString() : this.Articulo.Id.ToString();

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

                    cmbImagenes.DataSource = imagenNegocio.ListarImagenes();
                    cmbImagenes.ValueMember = "IdArticulo";
                    cmbImagenes.DisplayMember = "Url";

                    try
                    {
                        pbxAgregado.Load(imagenNegocio.ListarImagenes()[0].Url);
                    }
                    catch (Exception)
                    {
                        pbxAgregado.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
                    }

                    if (Articulo != null)
                    {
                        txtCodigo.Text = Articulo.Codigo;
                        txtNombre.Text = Articulo.Nombre;
                        txtDescripcion.Text = Articulo.Descripcion;
                        txtPrecio.Text = Articulo.Precio.ToString(); //toString por ser flotante
                        cboMarca.SelectedValue = Articulo.TipoMarca.Id;
                        cboCategoria.SelectedValue = Articulo.TipoCategoria.Id;
                        cmbImagenes.SelectedValue = Articulo.imagenArticulo.IdArticulo;
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

                    cmbImagenes.DataSource = imagenNegocio.ListarImagenes();
                    cmbImagenes.ValueMember = "IdArticulo";
                    cmbImagenes.DisplayMember = "Url";

                    pbxAgregado.Load(imagenNegocio.ListarImagenes()[0].Url);
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
            && cboCategoria.SelectedIndex != -1 && cboMarca.SelectedIndex != -1
            && cmbImagenes.SelectedIndex != -1 && txtCodigo.Text != ""
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
            try
            {
                if (ValidarCampos())
                {
                    Articulo.Codigo = txtCodigo.Text;
                    Articulo.Nombre = txtNombre.Text;
                    Articulo.Descripcion = txtDescripcion.Text;
                    Articulo.TipoMarca = (Marca)cboMarca.SelectedItem;
                    Articulo.TipoCategoria = (Categoria)cboCategoria.SelectedItem;
                    Articulo.Precio = decimal.Parse(txtPrecio.Text);
                    //Articulo.imagenArticulo = (Imagen)cmbImagenes.SelectedItem;
                    if(this.Tipo == "Modificar")
                    {
                    articuloNegocio.ModifyArt(Articulo);
                    Imagen obj = (Imagen)cmbImagenes.SelectedItem;
                    articuloNegocio.modifyImage(obj, Articulo.Id);
                    MessageBox.Show("Articulo Modificado", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if(this.Tipo == "Agregar")
                    {
                        
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("Cargue Correctamente Los Campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
