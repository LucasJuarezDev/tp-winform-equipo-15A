using Dominio;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        public List<Imagen> listImagesById(int id)
        {
            List<Imagen> ListaImagenes = new List<Imagen>();
            try
            {
                dataImage.limpiarParametros();
                dataImage.SetearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @IdArticulo");
                dataImage.SetearParametro("@IdArticulo", id);

                dataImage.EjecutarLectura();

                while (dataImage.Lector.Read())
                {
                    Imagen aux = new Imagen();
                    aux.Id = dataImage.Lector.GetInt32(0);
                    aux.IdArticulo = dataImage.Lector.GetInt32(1);
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

        public void addImage(string url, int id)
        {
            try
            {
                dataImage.limpiarParametros();
                dataImage.SetearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                dataImage.SetearParametro("@IdArticulo", id);
                dataImage.SetearParametro("@ImagenUrl", url);

                dataImage.ejecutarAccion();
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

        public void modifyImage(string url, int idArticulo, int idImagen)
        {
            try
            {
                dataImage.limpiarParametros();
                dataImage.SetearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE IdArticulo = @IdArticulo AND Id = @Id");
                dataImage.SetearParametro("@ImagenUrl", url);
                dataImage.SetearParametro("@IdArticulo", idArticulo);
                dataImage.SetearParametro("@Id", idImagen);

                dataImage.ejecutarAccion();
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
