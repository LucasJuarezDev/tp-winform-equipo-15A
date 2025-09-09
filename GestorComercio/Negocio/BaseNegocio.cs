using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class BaseNegocio
    {
        // FIJARSE LA CONEXION POR LA MAQUINA LOCAL POR SI NO FUNCIONA EL "server = .\\SQLEXPRESS"
        // DIRECCION DE BD LOCAL LUCAS -> server = DESKTOP-N8976U7\\SQLEXPRESS ; database = Dietetica ; integrated security = true
        // DIRECCION DE BD LOCAL AXEL ->  server = ............\\SQLEXPRESS ; database = Dietetica ; integrated security = true

        private string IPConexion = "server =.\\SQLEXPRESS ; database = CATALOGO_P3_DB ; integrated security = true";
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private SqlDataReader Lector;

        public SqlDataReader LectorPublico //  propiedad para leer el lector desde afuera en caso que lo necesitara
        {
            get { return Lector; }

        }
        public BaseNegocio() // constructor vacio con acceso a la DB
        {
            Conexion = new SqlConnection(IPConexion);
            Comando = new SqlCommand();
        }

        public void SetQuery(string Consulta) // metodo generico para traer la consulta
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Consulta;
        }

        public void CloseRead() // Metodo para cerrar la conexion al terminar de pegarle a la bd, y si el lector esta abierto tmb
        {
            if (Lector != null)
            {
                Lector.Close();
            }
            if (Conexion.State == System.Data.ConnectionState.Open)
            {
                Conexion.Close();
            }
        }
    }
}
