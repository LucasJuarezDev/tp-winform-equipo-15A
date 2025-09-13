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
        List<Imagen> listaImagenes = new List<Imagen>();

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
            imagenNegocio imagenes = new imagenNegocio();


            try
            {
                listaArticulos = articulos.listar();
                listaImagenes = imagenes.listar();

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
                    pbxArticulo.Load(url);
                }
                catch (Exception)
                {
                    pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
                }

            }
        }

        private void cargaImagen(int IdArt)
        {

            try
            {
                Imagen nuevaImagen = listaImagenes.Find(x => x.IdArticulo == IdArt);
                if (nuevaImagen != null)
                    pbxArticulo.Load(nuevaImagen.Url);
                else
                    pbxArticulo.Load("https://myemotos.cl/wp-content/uploads/2024/06/sin_imagen.jpg");
            }
            catch (Exception)
            {
                pbxArticulo.Load("https://myemotos.cl/wp-content/uploads/2024/06/sin_imagen.jpg");

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

        private bool validarFiltro()
        {
            if (ComboBoxCampo.SelectedIndex < 0) //pregunto si campo no tiene nada seleccionado
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar.");
                return true;
            }
            if (ComboBoxCriterio.SelectedIndex < 0) //pregunto si criterio no tiene nada seleccionado
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar.");
                return true;
            }
            if (ComboBoxCampo.SelectedItem.ToString() == "precio")//pregunto si campo es precio
            {
                if (string.IsNullOrEmpty(textBoxFiltroAvanzado.Text))//si el filtro esta vacio o null
                {
                    MessageBox.Show("Debes cargar el filtro...");
                    return true;
                }
                if (!(soloNumeros(textBoxFiltroAvanzado.Text))) //por q esta en op numumerico
                {
                    MessageBox.Show("Solo nros para filtrar por un campo numerico...");
                    return true;
                }
            }
            if (ComboBoxCampo.SelectedItem.ToString() == "nombre" || ComboBoxCampo.SelectedItem.ToString() == "categoría")
            {
                if (string.IsNullOrEmpty(textBoxFiltroAvanzado.Text))//si el filtro esta vacio o null
                {
                    MessageBox.Show("Debes cargar el filtro...");
                    return true;
                }
                if ((soloNumeros(textBoxFiltroAvanzado.Text))) //por q esta en op text
                {
                    MessageBox.Show("Solo letras para filtrar por un campo de texto...");
                    return true;
                }
            }

            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargaImagen(seleccionado.Id);

            }
            catch (Exception)
            {
                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTxdAOY_-vITFVI-ej84s2U_ErxhOly-z3y_Q&s");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            articuloNegocio ArtiNegocio = new articuloNegocio();
            Articulo ArtiSeleccionado = new Articulo();

            try
            {

                DialogResult respuesta = MessageBox.Show("¿De verdad querés eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    ArtiSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    ArtiNegocio.eliminarLogico(ArtiSeleccionado.Id);
                    cargarDgv();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BotonFiltrar_Click(object sender, EventArgs e)
        {
            articuloNegocio ArtiNegocio = new articuloNegocio();
            try
            {
                if (validarFiltro()) //si hay q validar corta la ejecucion
                {
                    cargarDgv();
                    return;
                }

                string campo = ComboBoxCampo.SelectedItem.ToString();
                string criterio = ComboBoxCriterio.SelectedItem.ToString();
                string filtro = textBoxFiltroAvanzado.Text;
                dgvArticulos.DataSource = ArtiNegocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ComboBoxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = ComboBoxCampo.SelectedItem.ToString(); //capturo la seleccion
            if (opcion == "precio")
            {
                ComboBoxCriterio.Items.Clear();
                ComboBoxCriterio.Items.Add("Mayor a");
                ComboBoxCriterio.Items.Add("Menor a");
                ComboBoxCriterio.Items.Add("Igual a");
            }
            else
            {
                ComboBoxCriterio.Items.Clear();
                ComboBoxCriterio.Items.Add("Comienza con");
                ComboBoxCriterio.Items.Add("Termina con");
                ComboBoxCriterio.Items.Add("Contiene");
            }
        }

        private void txtFitro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;

            string texto = txtFitro.Text.ToString().ToLower();

            if (txtFitro.Text.Length >= 3)
                listaFiltrada = listaArticulos.FindAll(
                    x => x.Nombre.ToLower().Contains(texto) ||
                    x.Codigo.ToLower().Contains(texto) ||
                    x.TipoMarca.Descripcion.ToLower().Contains(texto)
                    );
            else
                listaFiltrada = listaArticulos;

            dgvArticulos.DataSource = null;

            if (listaFiltrada.Count != 0)
            {
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.Columns.Remove("imagenArticulo"); //ocultar esta columna cada vez que filtremos
                //aca tendria que poner algo para que filtre las img tambien ya que van a ser a parte del articulo
            }
        }

        private void txtFitro_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<Articulo> listaFiltrada;
            string texto = txtFitro.Text.ToString().ToLower();

            if(texto != "")
            {
                listaFiltrada = listaArticulos.FindAll(
                    x => x.Nombre.ToLower().Contains(texto) ||
                    x.Codigo.ToLower().Contains(texto) ||
                    x.TipoMarca.Descripcion.ToLower().Contains(texto)
                );
            }
            else
            {
                listaFiltrada = listaArticulos;
            }
            dgvArticulos.DataSource = null;
            if(listaFiltrada.Count != 0)
            {
                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.Columns.Remove("imagenArticulo");
            }
        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
