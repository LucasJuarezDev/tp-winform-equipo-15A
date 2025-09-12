using Dominio;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class articuloNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();

            try
            {
                datos.SetearConsulta
                    (
                    "SELECT " +
                    "A.Id, " +
                    "A.Codigo, " +
                    "A.Nombre, " +
                    "A.Descripcion, " +
                    "A.IdMarca, " +
                    "M.Descripcion AS MarcaDescripcion, " +
                    "A.IdCategoria, " +
                    "CAT.Descripcion AS CategoriaDescripcion, " +
                    "A.Precio, " +
                    "IMG.ImagenUrl AS 'URL', " +
                    "IMG.Id AS 'idImagen', " +
                    "IMG.IdArticulo " +
                    "FROM ARTICULOS A " +
                    "INNER JOIN MARCAS M ON M.Id = A.IdMarca " +
                    "INNER JOIN CATEGORIAS CAT ON CAT.Id = A.IdCategoria " +
                    "INNER JOIN IMAGENES IMG ON IMG.IdArticulo = A.Id " +
                    "WHERE A.Precio > 0"
                    );
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.TipoMarca = new Marca();
                    aux.TipoMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.TipoMarca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    aux.TipoCategoria = new Categoria();
                    aux.TipoCategoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.TipoCategoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

                    aux.imagenArticulo = new Imagen();
                    aux.imagenArticulo.Id = (int)datos.Lector["idImagen"];
                    aux.imagenArticulo.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.imagenArticulo.Url = (string)datos.Lector["URL"];

                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Precio = Math.Round(aux.Precio, 2);

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }

        public void createArt(Articulo articulo)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModifyArt(Articulo articulo)
        {
            try
            {
                datos.SetearConsulta
               (
                "UPDATE ARTICULOS " +
                "SET  Codigo = @Codigo, " +
                "Nombre = @Nombre, " +
                "Descripcion = @Descripcion, " +
                "IdMarca = @IdMarca, " +
                "IdCategoria = @IdCategoria, " +
                "Precio = @Precio " +
                "WHERE Id = @Id "
               );
                datos.SetearParametro("@Codigo", articulo.Codigo);
                datos.SetearParametro("@Nombre", articulo.Nombre);
                datos.SetearParametro("@Descripcion", articulo.Descripcion);
                datos.SetearParametro("@IdMarca", articulo.TipoMarca.Id);
                datos.SetearParametro("@IdCategoria", articulo.TipoCategoria.Id);
                datos.SetearParametro("@Precio", articulo.Precio);
                datos.SetearParametro("@Id", articulo.Id);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }
        
        public void modifyImage(Imagen imagen, int id)
        {
            try
            {
                datos.limpiarParametros();
                datos.SetearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE IdArticulo = @IdArticulo");
                datos.SetearParametro("@ImagenUrl", imagen.Url);
                datos.SetearParametro("@IdArticulo", id);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConeccion();
            }
        }

        public int ReturnID()
        {
            int CodigoRetorno = 0;
            try
            {
                datos.SetearConsulta("SELECT ISNULL(MAX(Id), 0) + 1 AS Id FROM ARTICULOS");
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    CodigoRetorno = (int)datos.Lector["Id"];
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConeccion();
            }
            return CodigoRetorno;
        }



    }
}
