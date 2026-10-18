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
    public class RolDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        public List<RolBO> MostrarRol()
        {
            List<RolBO> lista = new List<RolBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarRol";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RolBO obj = new RolBO();
                    obj.codigo = Convert.ToInt32(dr["codrol"].ToString());
                    obj.nombre = dr["nomrol"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estrol"].ToString());
                    lista.Add(obj);
                }
                return lista;
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

        public List<RolBO> MostrarRolTodo()
        {
            List<RolBO> lista = new List<RolBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarRolTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RolBO obj = new RolBO();
                    obj.codigo = Convert.ToInt32(dr["codrol"].ToString());
                    obj.nombre = dr["nomrol"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estrol"].ToString());
                    lista.Add(obj);
                }
                return lista;
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

        public bool RegistrarRol(RolBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarRol";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@estado", c.estado);
                res = cmd.ExecuteNonQuery();
                return res == 1;
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

        public bool ActualizarRol(RolBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarRol";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@estado", c.estado);
                res = cmd.ExecuteNonQuery();
                return res == 1;
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

        public bool EliminarRol(RolBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarRol";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                res = cmd.ExecuteNonQuery();
                return res == 1;
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

        public bool HabilitarRol(RolBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarRol";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                res = cmd.ExecuteNonQuery();
                return res == 1;
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

        public int MostrarCodigoRol()
        {
            int resultadoCodigo = 0;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CodigoRol";
                cmd.Connection = objconexion.Conectar();
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    resultadoCodigo = (int)resultado;
                }
                return resultadoCodigo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public RolBO BuscarRolXCodigo(RolBO c)
        {
            RolBO obj = new RolBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarRolXCodigo";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["codrol"].ToString());
                    obj.nombre = dr["nomrol"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estrol"].ToString());
                }
                return obj;
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
