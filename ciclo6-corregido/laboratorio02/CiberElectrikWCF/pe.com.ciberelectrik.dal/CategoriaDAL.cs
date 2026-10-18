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
    public class CategoriaDAL
    {
        //crear un objeto de la clase Conexion
        private ConexionDAL objconexion = new ConexionDAL();

        //comando SQL
        private SqlCommand cmd;

        //lectura de datos
        private SqlDataReader dr;

        //creamos una variable para los resultados de SQL de actualizacion
        int res = 0;

        //funcion para mostrar la categoria
        public List<CategoriaBO> MostrarCategoria()
        {
            //creamos una lista de tipo CategoriaBO
            List<CategoriaBO> categorias = new List<CategoriaBO>();
            try
            {
                //instanciamos el SQLCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SQLCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento
                cmd.CommandText = "SP_MostrarCategoria";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos la consulta y guardamos el resultado en el SQLDataReader
                dr = cmd.ExecuteReader();
                //cargamos los datos del SQLDataReader en la lista
                while (dr.Read())
                {
                    //creamos un objeto de tipo CategoriaBO
                    CategoriaBO obj = new CategoriaBO();
                    //leemos los datos y los asignamos al objeto
                    obj.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    obj.nombre = dr["nomcat"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcat"].ToString());
                    //agregar el objeto a la lista
                    categorias.Add(obj);
                }
                //devolvemos la lista
                return categorias;
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
        public List<CategoriaBO> MostrarCategoriaTodo()
        {
            //creamos una lista de tipo CategoriaBO
            List<CategoriaBO> categorias = new List<CategoriaBO>();
            try
            {
                //instanciamos el SQLCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SQLCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento
                cmd.CommandText = "SP_MostrarCategoriaTodo";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                //ejecutamos la consulta y guardamos el resultado en el SQLDataReader
                dr = cmd.ExecuteReader();
                //cargamos los datos del SQLDataReader en la lista
                while (dr.Read())
                {
                    //creamos un objeto de tipo CategoriaBO
                    CategoriaBO obj = new CategoriaBO();
                    //leemos los datos y los asignamos al objeto
                    obj.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    obj.nombre = dr["nomcat"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estcat"].ToString());
                    //agregar el objeto a la lista
                    categorias.Add(obj);
                }
                //devolvemos la lista
                return categorias;
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
        public bool RegistrarCategoria(CategoriaBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarCategoria";
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que registraremos por parametros
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@estado", c.estado);
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
        public bool ActualizarCategoria(CategoriaBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarCategoria";
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@estado", c.estado);
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
        public bool EliminarCategoria(CategoriaBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarCategoria";
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
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
        public bool HabilitarCategoria(CategoriaBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarCategoria";
                cmd.Connection = objconexion.Conectar();
                //pasamos los datos que registraremos por parametros
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
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
        public int MostrarCodigoCategoria()
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
                cmd.CommandText = "SP_CodigoCategoria";
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
        public CategoriaBO BuscarCategoriaXCodigo(CategoriaBO c)
        {
            //creamos una objeto de tipo CategoriaBO
            CategoriaBO categorias = new CategoriaBO();
            try
            {
                //instanciamos el SQLCommand
                cmd = new SqlCommand();
                //especificamos el tipo de SQLCommand
                cmd.CommandType = CommandType.StoredProcedure;
                //especificamos el nombre del procedimiento
                cmd.CommandText = "SP_BuscarCategoriaXCodigo";
                //instanciamos la conexion
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo",c.codigo);
                //ejecutamos la consulta y guardamos el resultado en el SQLDataReader
                dr = cmd.ExecuteReader();
                //cargamos los datos del SQLDataReader en la lista
                while (dr.Read())
                {
                    //leemos los datos y los asignamos al objeto
                    categorias.codigo = Convert.ToInt32(dr["codcat"].ToString());
                    categorias.nombre = dr["nomcat"].ToString();
                    categorias.estado = Convert.ToBoolean(dr["estcat"].ToString());
                }
                //devolvemos la lista
                return categorias;
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
