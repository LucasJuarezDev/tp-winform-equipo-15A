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
        private int idImageToModify = 0;
        private string Tipo = "";
        private string placeHolderImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s";
        private bool hasImageLoad = false;
        private Articulo Articulo = null;
        articuloNegocio articuloNegocio = new articuloNegocio();
        imagenNegocio imagenNegocio = new imagenNegocio();

        private Articulo articulo = null;
        private List<Imagen> imagenesArt = null;


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
                pbxAgregado.Load(this.placeHolderImage);
            }
        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUrlImagen.TextLength > 0)
                {
                    this.hasImageLoad = true;
                    btnNuevaImagen.Enabled = true;
                }
                else
                {
                    this.hasImageLoad = false;
                    btnNuevaImagen.Enabled = false;
                }
                pbxAgregado.Load(txtUrlImagen.Text);
            }
            catch (Exception)
            {
                pbxAgregado.Load(this.placeHolderImage);
            }
        }

        private void btnModificarUrlImagen_Click(object sender, EventArgs e)
        {
            Imagen obj = (Imagen)cmbImagenes.SelectedItem;
            this.idImageToModify = obj.Id;
            txtUrlImagen.Text = cmbImagenes.Text;
        }

        private void btnNuevaImagen_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultSobrescribir = MessageBox.Show(
                    "¿Quieres sobreescribir la imagen?",
                    "Modificar imagen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultSobrescribir == DialogResult.Yes)
                {
                    imagenNegocio.modifyImage(txtUrlImagen.Text, this.Articulo.Id, this.idImageToModify);
                    this.idImageToModify = 0;
                    MessageBox.Show("Imagen cambiada con éxito!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult resultNueva = MessageBox.Show(
                        "¿Quieres guardarla como nueva?",
                        "Guardar imagen",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultNueva == DialogResult.Yes)
                    {
                        imagenNegocio.addImage(txtUrlImagen.Text, this.Articulo.Id);
                        MessageBox.Show("Imagen guardada como nueva!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///////////////////////////////////////  CONSTRUCTORES  ////////////////////////////////////////////
        public FormNuevoArticulo(string tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
            lblTitulo.Text = "Agrega tu nuevo articulo";
            BTN_Cargar_Art.Text = "Cargar";

            cmbImagenes.Visible = false;
            lblcomboboxImagenes.Visible = false;
            btnModificarUrlImagen.Visible = false;
            btnNuevaImagen.Visible = false;
        }

        public FormNuevoArticulo(string tipo, Articulo articulo)
        {
            InitializeComponent();
            this.Tipo = tipo;
            lblTitulo.Text = "Modificar articulo";
            BTN_Cargar_Art.Text = "Modificar";
            this.Articulo = articulo;
        }

        ///////////////////////////////////////  MANIPULACION DE ARTICULO  ////////////////////////////////////////////
        private void FormNuevoArticulo_Load(object sender, EventArgs e)
        {
            marcaNegocio marcaNegocio = new marcaNegocio();
            categoriaNegocio categoriaNegocio = new categoriaNegocio();
            btnNuevaImagen.Enabled = false;
            txtIdArt.Text = this.Tipo == "Agregar" ? articuloNegocio.ReturnID().ToString() : this.Articulo.Id.ToString();

            try
            {
                if (this.Tipo == "Modificar")
                {
                    cboMarca.DataSource = marcaNegocio.ListarMarcas();
                    cboMarca.ValueMember = "Id";
                    cboMarca.DisplayMember = "Descripcion";

                    cboCategoria.DataSource = categoriaNegocio.ListarCategorias();
                    cboCategoria.ValueMember = "Id";
                    cboCategoria.DisplayMember = "Descripcion";

                    cmbImagenes.DataSource = imagenNegocio.listImagesById(this.Articulo.Id);
                    cmbImagenes.ValueMember = "Id";
                    cmbImagenes.DisplayMember = "Url";

                    if (cmbImagenes.Items.Count > 0)
                    {
                        Imagen primera = (Imagen)cmbImagenes.Items[0];
                        pbxAgregado.Load(primera.Url);
                    }
                    else
                    {
                        pbxAgregado.Load(this.placeHolderImage);
                    }

                    if (Articulo != null)
                    {
                        txtCodigo.Text = Articulo.Codigo;
                        txtNombre.Text = Articulo.Nombre;
                        txtDescripcion.Text = Articulo.Descripcion;
                        txtPrecio.Text = Articulo.Precio.ToString();
                        cboMarca.SelectedValue = Articulo.TipoMarca.Id;
                        cboCategoria.SelectedValue = Articulo.TipoCategoria.Id;
                        cmbImagenes.SelectedValue = Articulo.imagenArticulo.Id;
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

                    pbxAgregado.Load(this.placeHolderImage);
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
                    if (Articulo == null) { Articulo = new Articulo(); }

                    Articulo.Codigo = txtCodigo.Text;
                    Articulo.Nombre = txtNombre.Text;
                    Articulo.Descripcion = txtDescripcion.Text;
                    Articulo.TipoMarca = (Marca)cboMarca.SelectedItem;
                    Articulo.TipoCategoria = (Categoria)cboCategoria.SelectedItem;
                    Articulo.Precio = decimal.Parse(txtPrecio.Text);
                    if (this.Tipo == "Modificar")
                    {
                        articuloNegocio.ModifyArt(Articulo);
                        MessageBox.Show("Articulo Modificado", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (this.Tipo == "Agregar")
                    {
                        articuloNegocio.Agregar(Articulo);
                        if (this.hasImageLoad)
                        {
                            string parametro = txtUrlImagen.Text.Trim();

                            if (!parametro.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                            {
                                parametro = this.placeHolderImage;
                            }
                            imagenNegocio.addImage(parametro, articuloNegocio.ReturnID() - 1);
                        }
                        else
                        {
                            string parametro = this.placeHolderImage;
                            imagenNegocio.addImage(parametro, articuloNegocio.ReturnID() - 1);
                        }
                        MessageBox.Show("Articulo Agregado!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
