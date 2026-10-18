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
    public class EmpleadoDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        private EmpleadoBO LeerEmpleado(SqlDataReader dr)
        {
            EmpleadoBO obj = new EmpleadoBO();
            obj.codigo = Convert.ToInt32(dr["codemp"].ToString());
            obj.nombre = dr["nomemp"].ToString();
            obj.apepaterno = dr["apepemp"].ToString();
            obj.apematerno = dr["apememp"].ToString();
            obj.documento = dr["docemp"].ToString();
            obj.direccion = dr["diremp"].ToString();
            obj.fecha = Convert.ToDateTime(dr["fecemp"].ToString());
            obj.nacionalidad = dr["nacemp"].ToString();
            obj.telefono = dr["telemp"].ToString();
            obj.celular = dr["celemp"].ToString();
            obj.correo = dr["coremp"].ToString();
            obj.usuario = dr["usuemp"].ToString();
            obj.clave = dr["claemp"].ToString();
            obj.estado = Convert.ToBoolean(dr["estemp"].ToString());

            DistritoBO objdis = new DistritoBO();
            objdis.codigo = Convert.ToInt32(dr["coddis"].ToString());
            objdis.nombre = dr["nomdis"].ToString();
            obj.distrito = objdis;

            RolBO objrol = new RolBO();
            objrol.codigo = Convert.ToInt32(dr["codrol"].ToString());
            objrol.nombre = dr["nomrol"].ToString();
            obj.rol = objrol;

            TipoDocumentoBO objtipd = new TipoDocumentoBO();
            objtipd.codigo = Convert.ToInt32(dr["codtipd"].ToString());
            objtipd.nombre = dr["nomtipd"].ToString();
            obj.tipoDocumento = objtipd;

            SexoBO objsex = new SexoBO();
            objsex.codigo = Convert.ToInt32(dr["codsex"].ToString());
            objsex.nombre = dr["nomsex"].ToString();
            obj.sexo = objsex;

            EstadoCivilBO objestc = new EstadoCivilBO();
            objestc.codigo = Convert.ToInt32(dr["codestc"].ToString());
            objestc.nombre = dr["nomestc"].ToString();
            obj.estadoCivil = objestc;

            return obj;
        }

        public List<EmpleadoBO> MostrarEmpleado()
        {
            List<EmpleadoBO> lista = new List<EmpleadoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarEmpleado";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(LeerEmpleado(dr));
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

        public List<EmpleadoBO> MostrarEmpleadoTodo()
        {
            List<EmpleadoBO> lista = new List<EmpleadoBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarEmpleadoTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(LeerEmpleado(dr));
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

        public bool RegistrarEmpleado(EmpleadoBO e)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarEmpleado";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@nombre", e.nombre);
                cmd.Parameters.AddWithValue("@apepat", e.apepaterno);
                cmd.Parameters.AddWithValue("@apemat", e.apematerno);
                cmd.Parameters.AddWithValue("@documento", e.documento);
                cmd.Parameters.AddWithValue("@direccion", e.direccion);
                cmd.Parameters.AddWithValue("@fecha", e.fecha);
                cmd.Parameters.AddWithValue("@nacionalidad", e.nacionalidad);
                cmd.Parameters.AddWithValue("@telefono", e.telefono);
                cmd.Parameters.AddWithValue("@celular", e.celular);
                cmd.Parameters.AddWithValue("@correo", e.correo);
                cmd.Parameters.AddWithValue("@usuario", e.usuario);
                cmd.Parameters.AddWithValue("@clave", e.clave);
                cmd.Parameters.AddWithValue("@estado", e.estado);
                cmd.Parameters.AddWithValue("@coddis", e.distrito.codigo);
                cmd.Parameters.AddWithValue("@codrol", e.rol.codigo);
                cmd.Parameters.AddWithValue("@codtipd", e.tipoDocumento.codigo);
                cmd.Parameters.AddWithValue("@codsex", e.sexo.codigo);
                cmd.Parameters.AddWithValue("@codestc", e.estadoCivil.codigo);
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

        public bool ActualizarEmpleado(EmpleadoBO e)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarEmpleado";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
                cmd.Parameters.AddWithValue("@nombre", e.nombre);
                cmd.Parameters.AddWithValue("@apepat", e.apepaterno);
                cmd.Parameters.AddWithValue("@apemat", e.apematerno);
                cmd.Parameters.AddWithValue("@documento", e.documento);
                cmd.Parameters.AddWithValue("@direccion", e.direccion);
                cmd.Parameters.AddWithValue("@fecha", e.fecha);
                cmd.Parameters.AddWithValue("@nacionalidad", e.nacionalidad);
                cmd.Parameters.AddWithValue("@telefono", e.telefono);
                cmd.Parameters.AddWithValue("@celular", e.celular);
                cmd.Parameters.AddWithValue("@correo", e.correo);
                cmd.Parameters.AddWithValue("@usuario", e.usuario);
                cmd.Parameters.AddWithValue("@clave", e.clave);
                cmd.Parameters.AddWithValue("@estado", e.estado);
                cmd.Parameters.AddWithValue("@coddis", e.distrito.codigo);
                cmd.Parameters.AddWithValue("@codrol", e.rol.codigo);
                cmd.Parameters.AddWithValue("@codtipd", e.tipoDocumento.codigo);
                cmd.Parameters.AddWithValue("@codsex", e.sexo.codigo);
                cmd.Parameters.AddWithValue("@codestc", e.estadoCivil.codigo);
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

        public bool EliminarEmpleado(EmpleadoBO e)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarEmpleado";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
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

        public bool HabilitarEmpleado(EmpleadoBO e)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarEmpleado";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
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

        public int MostrarCodigoEmpleado()
        {
            int resultadoCodigo = 0;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CodigoEmpleado";
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

        public EmpleadoBO BuscarEmpleadoXCodigo(EmpleadoBO e)
        {
            EmpleadoBO obj = new EmpleadoBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarEmpleadoXCodigo";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", e.codigo);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = LeerEmpleado(dr);
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
