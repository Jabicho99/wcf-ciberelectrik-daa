using pe.com.ciberelectrik.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.dal
{
    public class MarcaDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        //funcion para mostrar la categoria
        public List<MarcaBO> MostrarMarca()
        {
            List<MarcaBO> marcas = new List<MarcaBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarMarca";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MarcaBO obj = new MarcaBO();
                    obj.codigo = Convert.ToInt32(dr["codmar"].ToString());
                    obj.nombre = dr["nommar"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estmar"].ToString());
                    marcas.Add(obj);
                }
                return marcas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //funcion para mostrar la categoria
        public List<MarcaBO> MostrarMarcaTodo()
        {
            List<MarcaBO> marcas = new List<MarcaBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarMarcaTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MarcaBO obj = new MarcaBO();
                    obj.codigo = Convert.ToInt32(dr["codmar"].ToString());
                    obj.nombre = dr["nommar"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estmar"].ToString());
                    marcas.Add(obj);
                }
                return marcas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //creamos una funcion para registrar
        public bool RegistrarMarca(MarcaBO m)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarMarca";
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que registraremos por parametros
                cmd.Parameters.AddWithValue("@nombre", m.nombre);
                cmd.Parameters.AddWithValue("@estado", m.estado);
                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();
                //evaluamos
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //creamos una funcion para actualizar
        public bool ActualizarMarca(MarcaBO m)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarMarca";
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", m.codigo);
                cmd.Parameters.AddWithValue("@nombre", m.nombre);
                cmd.Parameters.AddWithValue("@estado", m.estado);
                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();
                //evaluamos
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //creamos una funcion para actualizar
        public bool EliminarMarca(MarcaBO m)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarMarca";
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", m.codigo);
                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();
                //evaluamos
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }
        //creamos una funcion para habilitar
        public bool HabilitarMarca(MarcaBO m)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarMarca";
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", m.codigo);
                //ejecutamos el procedimiento almacenado
                res = cmd.ExecuteNonQuery();
                //evaluamos
                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        //funcion para mostrar la categoria
        public int MostrarCodigoMarca()
        {
            //creamos una lista de tipo CategoriaBO
            int categorias = 0;
            try
            {
                //instanciamos el SQLCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SQLCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento
                cmd.CommandText = "SP_CodigoMarca";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos la consulta y guardamos el resultado en el SQLDataReader
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    categorias = (int)resultado;
                }

                //devolvemos la lista
                return categorias;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        //creamos una funcion para buscar
        public MarcaBO BuscarMarcaXCodigo(MarcaBO c)
        {
            //creamos una objeto de tipo CategoriaBO
            MarcaBO marcas = new MarcaBO();
            try
            {
                //instanciamos el SQLCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SQLCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento
                cmd.CommandText = "SP_BuscarMarcaXCodigo";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                //ejecutamos la consulta y guardamos el resultado en el SQLDataReader
                dr = cmd.ExecuteReader();
                //cargamos los datos del SQLDataReader en la lista
                while (dr.Read())
                {
                    //leemos los datos y los asignamos al objeto
                    marcas.codigo = Convert.ToInt32(dr["codmar"].ToString());
                    marcas.nombre = dr["nommar"].ToString();
                    marcas.estado = Convert.ToBoolean(dr["estmar"].ToString());
                }
                //devolvemos la lista
                return marcas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }
    }
}
