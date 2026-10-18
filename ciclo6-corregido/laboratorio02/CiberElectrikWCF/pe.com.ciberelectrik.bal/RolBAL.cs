using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class RolBAL
    {
        RolDAL dal = new RolDAL();

        public List<RolBO> MostrarRol()
        {
            return dal.MostrarRol();
        }

        public List<RolBO> MostrarRolTodo()
        {
            return dal.MostrarRolTodo();
        }

        public bool RegistrarRol(RolBO c)
        {
            return dal.RegistrarRol(c);
        }
        public bool ActualizarRol(RolBO c)
        {
            return dal.ActualizarRol(c);
        }
        public bool EliminarRol(RolBO c)
        {
            return dal.EliminarRol(c);
        }

        public bool HabilitarRol(RolBO c)
        {
            return dal.HabilitarRol(c);
        }

        public int MostrarCodigoRol()
        {
            return dal.MostrarCodigoRol();
        }

        public RolBO BuscarRolXCodigo(RolBO c)
        {
            return dal.BuscarRolXCodigo(c);
        }
    }
}
