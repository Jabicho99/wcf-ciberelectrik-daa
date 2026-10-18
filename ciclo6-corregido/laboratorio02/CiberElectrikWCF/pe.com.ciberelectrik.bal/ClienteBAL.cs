using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class ClienteBAL
    {
        ClienteDAL dal = new ClienteDAL();

        public List<ClienteBO> MostrarCliente()
        {
            return dal.MostrarCliente();
        }

        public List<ClienteBO> MostrarClienteTodo()
        {
            return dal.MostrarClienteTodo();
        }

        public bool RegistrarCliente(ClienteBO c)
        {
            return dal.RegistrarCliente(c);
        }
        public bool ActualizarCliente(ClienteBO c)
        {
            return dal.ActualizarCliente(c);
        }
        public bool EliminarCliente(ClienteBO c)
        {
            return dal.EliminarCliente(c);
        }

        public bool HabilitarCliente(ClienteBO c)
        {
            return dal.HabilitarCliente(c);
        }

        public int MostrarCodigoCliente()
        {
            return dal.MostrarCodigoCliente();
        }

        public ClienteBO BuscarClienteXCodigo(ClienteBO c)
        {
            return dal.BuscarClienteXCodigo(c);
        }
    }
}
