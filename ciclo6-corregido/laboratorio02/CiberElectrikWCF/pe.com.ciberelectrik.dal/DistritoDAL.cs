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
    public class DistritoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        public List<DistritoBO> MostrarDistrito()
        {
            List<DistritoBO> lista = new List<DistritoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarDistrito";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DistritoBO obj = new DistritoBO();
                    obj.codigo = Convert.ToInt32(dr["coddis"].ToString());
                    obj.nombre = dr["nomdis"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estdis"].ToString());
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

        public List<DistritoBO> MostrarDistritoTodo()
        {
            List<DistritoBO> lista = new List<DistritoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarDistritoTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DistritoBO obj = new DistritoBO();
                    obj.codigo = Convert.ToInt32(dr["coddis"].ToString());
                    obj.nombre = dr["nomdis"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estdis"].ToString());
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

        public bool RegistrarDistrito(DistritoBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarDistrito";
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

        public bool ActualizarDistrito(DistritoBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarDistrito";
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

        public bool EliminarDistrito(DistritoBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarDistrito";
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

        public bool HabilitarDistrito(DistritoBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarDistrito";
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

        public int MostrarCodigoDistrito()
        {
            int resultadoCodigo = 0;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CodigoDistrito";
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

        public DistritoBO BuscarDistritoXCodigo(DistritoBO c)
        {
            DistritoBO obj = new DistritoBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarDistritoXCodigo";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["coddis"].ToString());
                    obj.nombre = dr["nomdis"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estdis"].ToString());
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
