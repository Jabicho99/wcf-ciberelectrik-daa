using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.dal
{
    public class ConexionDAL
    {
        //cadena de conexion
        //con autenticacion en windows
        //private string cadena = "Data Source=.; Initial Catalog=bdciberelectrik2025; Integrated Security=True";
        private string cadena = "Data Source=YOUR_SERVER; Initial Catalog=bdciberelectrikapi20261; Integrated Security=True; TrustServerCertificate=true;";
        //con autenticacion SQL Server
        //private string cadena = "Data Source=YOUR_SERVER; Initial Catalog=bdciberelectrik2025; User ID=YOUR_USER;Password=YOUR_PASSWORD;";

        //objeto de tipo SqlConnection
        private SqlConnection xcon;

        //creamos una funcion para la conexion
        public SqlConnection Conectar()
        {
            //instanciando la conexion con la cadena
            xcon = new SqlConnection(cadena);
            //abriendo la cadena de conexion
            xcon.Open();
            //devolviendo la cadena de conexion
            return xcon;
        }

        //creamos un procedimiento para cerra la conexion
        public void CerrarConexion()
        {
            //cerramos la cadena de conexion
            xcon.Close();
            //liberamos los recursos
            xcon.Dispose();
        }
    }
}
