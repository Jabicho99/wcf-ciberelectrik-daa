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
    public class ClienteDAL
    {
        private ConexionDAL objconexion = new ConexionDAL();
        private SqlCommand cmd;
        private SqlDataReader dr;
        int res = 0;

        private ClienteBO LeerCliente(SqlDataReader dr)
        {
            ClienteBO obj = new ClienteBO();
            obj.codigo = Convert.ToInt32(dr["codcli"].ToString());
            obj.nombre = dr["nomcli"].ToString();
            obj.apepaterno = dr["apepcli"].ToString();
            obj.apematerno = dr["apemcli"].ToString();
            obj.documento = dr["doccli"].ToString();
            obj.fecha = Convert.ToDateTime(dr["feccli"].ToString());
            obj.nacionalidad = dr["naccli"].ToString();
            obj.direccion = dr["dircli"].ToString();
            obj.telefono = dr["telcli"].ToString();
            obj.celular = dr["celcli"].ToString();
            obj.correo = dr["corcli"].ToString();
            obj.estado = Convert.ToBoolean(dr["estcli"].ToString());

            DistritoBO objdis = new DistritoBO();
            objdis.codigo = Convert.ToInt32(dr["coddis"].ToString());
            objdis.nombre = dr["nomdis"].ToString();
            obj.distrito = objdis;

            TipoDocumentoBO objtipd = new TipoDocumentoBO();
            objtipd.codigo = Convert.ToInt32(dr["codtipd"].ToString());
            objtipd.nombre = dr["nomtipd"].ToString();
            obj.tipoDocumento = objtipd;

            SexoBO objsex = new SexoBO();
            objsex.codigo = Convert.ToInt32(dr["codsex"].ToString());
            objsex.nombre = dr["nomsex"].ToString();
            obj.sexo = objsex;

            return obj;
        }

        public List<ClienteBO> MostrarCliente()
        {
            List<ClienteBO> lista = new List<ClienteBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarCliente";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(LeerCliente(dr));
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

        public List<ClienteBO> MostrarClienteTodo()
        {
            List<ClienteBO> lista = new List<ClienteBO>();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MostrarClienteTodo";
                cmd.Connection = objconexion.Conectar();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(LeerCliente(dr));
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

        public bool RegistrarCliente(ClienteBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_RegistrarCliente";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@apepat", c.apepaterno);
                cmd.Parameters.AddWithValue("@apemat", c.apematerno);
                cmd.Parameters.AddWithValue("@documento", c.documento);
                cmd.Parameters.AddWithValue("@fecha", c.fecha);
                cmd.Parameters.AddWithValue("@nacionalidad", c.nacionalidad);
                cmd.Parameters.AddWithValue("@direccion", c.direccion);
                cmd.Parameters.AddWithValue("@telefono", c.telefono);
                cmd.Parameters.AddWithValue("@celular", c.celular);
                cmd.Parameters.AddWithValue("@correo", c.correo);
                cmd.Parameters.AddWithValue("@estado", c.estado);
                cmd.Parameters.AddWithValue("@coddis", c.distrito.codigo);
                cmd.Parameters.AddWithValue("@codtipd", c.tipoDocumento.codigo);
                cmd.Parameters.AddWithValue("@codsex", c.sexo.codigo);
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

        public bool ActualizarCliente(ClienteBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ActualizarCliente";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                cmd.Parameters.AddWithValue("@nombre", c.nombre);
                cmd.Parameters.AddWithValue("@apepat", c.apepaterno);
                cmd.Parameters.AddWithValue("@apemat", c.apematerno);
                cmd.Parameters.AddWithValue("@documento", c.documento);
                cmd.Parameters.AddWithValue("@fecha", c.fecha);
                cmd.Parameters.AddWithValue("@nacionalidad", c.nacionalidad);
                cmd.Parameters.AddWithValue("@direccion", c.direccion);
                cmd.Parameters.AddWithValue("@telefono", c.telefono);
                cmd.Parameters.AddWithValue("@celular", c.celular);
                cmd.Parameters.AddWithValue("@correo", c.correo);
                cmd.Parameters.AddWithValue("@estado", c.estado);
                cmd.Parameters.AddWithValue("@coddis", c.distrito.codigo);
                cmd.Parameters.AddWithValue("@codtipd", c.tipoDocumento.codigo);
                cmd.Parameters.AddWithValue("@codsex", c.sexo.codigo);
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

        public bool EliminarCliente(ClienteBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_EliminarCliente";
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

        public bool HabilitarCliente(ClienteBO c)
        {
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_HabilitarCliente";
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

        public int MostrarCodigoCliente()
        {
            int resultadoCodigo = 0;
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_CodigoCliente";
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

        public ClienteBO BuscarClienteXCodigo(ClienteBO c)
        {
            ClienteBO obj = new ClienteBO();
            try
            {
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_BuscarClienteXCodigo";
                cmd.Connection = objconexion.Conectar();
                cmd.Parameters.AddWithValue("@codigo", c.codigo);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj = LeerCliente(dr);
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
