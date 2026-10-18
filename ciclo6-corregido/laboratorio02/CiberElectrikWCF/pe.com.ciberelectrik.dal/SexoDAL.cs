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
    public class SexoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        public List<SexoBO> MostrarSexo()
        {
            List<SexoBO> lista = new List<SexoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarSexo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SexoBO obj = new SexoBO();
                    obj.codigo = Convert.ToInt32(dr["codsex"].ToString());
                    obj.nombre = dr["nomsex"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estsex"].ToString());
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

        public List<SexoBO> MostrarSexoTodo()
        {
            List<SexoBO> lista = new List<SexoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarSexoTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SexoBO obj = new SexoBO();
                    obj.codigo = Convert.ToInt32(dr["codsex"].ToString());
                    obj.nombre = dr["nomsex"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estsex"].ToString());
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

        public bool RegistrarSexo(SexoBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarSexo";
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

        public bool ActualizarSexo(SexoBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarSexo";
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

        public bool EliminarSexo(SexoBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarSexo";
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

        public bool HabilitarSexo(SexoBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarSexo";
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

        public int MostrarCodigoSexo()
        {
            int resultadoCodigo = 0;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CodigoSexo";
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

        public SexoBO BuscarSexoXCodigo(SexoBO c)
        {
            SexoBO obj = new SexoBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarSexoXCodigo";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["codsex"].ToString());
                    obj.nombre = dr["nomsex"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estsex"].ToString());
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
