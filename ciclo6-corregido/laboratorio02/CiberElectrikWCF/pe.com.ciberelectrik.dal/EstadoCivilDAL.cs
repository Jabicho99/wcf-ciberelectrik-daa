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
    public class EstadoCivilDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        public List<EstadoCivilBO> MostrarEstadoCivil()
        {
            List<EstadoCivilBO> lista = new List<EstadoCivilBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarEstadoCivil";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EstadoCivilBO obj = new EstadoCivilBO();
                    obj.codigo = Convert.ToInt32(dr["codestc"].ToString());
                    obj.nombre = dr["nomestc"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estestc"].ToString());
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

        public List<EstadoCivilBO> MostrarEstadoCivilTodo()
        {
            List<EstadoCivilBO> lista = new List<EstadoCivilBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarEstadoCivilTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EstadoCivilBO obj = new EstadoCivilBO();
                    obj.codigo = Convert.ToInt32(dr["codestc"].ToString());
                    obj.nombre = dr["nomestc"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estestc"].ToString());
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

        public bool RegistrarEstadoCivil(EstadoCivilBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarEstadoCivil";
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

        public bool ActualizarEstadoCivil(EstadoCivilBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarEstadoCivil";
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

        public bool EliminarEstadoCivil(EstadoCivilBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarEstadoCivil";
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

        public bool HabilitarEstadoCivil(EstadoCivilBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarEstadoCivil";
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

        public int MostrarCodigoEstadoCivil()
        {
            int resultadoCodigo = 0;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CodigoEstadoCivil";
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

        public EstadoCivilBO BuscarEstadoCivilXCodigo(EstadoCivilBO c)
        {
            EstadoCivilBO obj = new EstadoCivilBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarEstadoCivilXCodigo";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.codigo = Convert.ToInt32(dr["codestc"].ToString());
                    obj.nombre = dr["nomestc"].ToString();
                    obj.estado = Convert.ToBoolean(dr["estestc"].ToString());
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
