using Dominio;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class imagenNegocio
    {
        private AccesoDatos dataImage = new AccesoDatos();
        public List<Imagen> ListarImagenes()
        {
            List<Imagen> ListaImagenes = new List<Imagen>();

            try
            {
                dataImage.SetearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES");
                dataImage.EjecutarLectura();

                while (dataImage.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = dataImage.Lector.GetInt32(0);
                    aux.IdArticulo =  dataImage.Lector.GetInt32(1);
                    aux.Url = (string)dataImage.Lector["ImagenUrl"];
                    ListaImagenes.Add(aux);
                }
                return ListaImagenes;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dataImage.CerrarConeccion();
            }

        }
    }
}
