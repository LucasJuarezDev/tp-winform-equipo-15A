using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Manager;


namespace Negocio
{
    public class categoriaNegocio
    {
        private AccesoDatos DataBaseCat = new AccesoDatos();
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> ListaCategorias = new List<Categoria>();

            try
            {
                DataBaseCat.SetearConsulta("select Id, Descripcion from Categorias");
                DataBaseCat.EjecutarLectura();

                while (DataBaseCat.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = DataBaseCat.Lector.GetInt32(0);
                    aux.Descripcion = (string)DataBaseCat.Lector["Descripcion"];
                    ListaCategorias.Add(aux);
                }
                return ListaCategorias;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                DataBaseCat.CerrarConeccion();
            }

        }
    }
}
