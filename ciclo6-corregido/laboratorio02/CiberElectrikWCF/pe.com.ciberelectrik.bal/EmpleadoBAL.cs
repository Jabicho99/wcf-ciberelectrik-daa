using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class EmpleadoBAL
    {
        EmpleadoDAL dal = new EmpleadoDAL();

        public List<EmpleadoBO> MostrarEmpleado()
        {
            return dal.MostrarEmpleado();
        }

        public List<EmpleadoBO> MostrarEmpleadoTodo()
        {
            return dal.MostrarEmpleadoTodo();
        }

        public bool RegistrarEmpleado(EmpleadoBO e)
        {
            return dal.RegistrarEmpleado(e);
        }
        public bool ActualizarEmpleado(EmpleadoBO e)
        {
            return dal.ActualizarEmpleado(e);
        }
        public bool EliminarEmpleado(EmpleadoBO e)
        {
            return dal.EliminarEmpleado(e);
        }

        public bool HabilitarEmpleado(EmpleadoBO e)
        {
            return dal.HabilitarEmpleado(e);
        }

        public int MostrarCodigoEmpleado()
        {
            return dal.MostrarCodigoEmpleado();
        }

        public EmpleadoBO BuscarEmpleadoXCodigo(EmpleadoBO e)
        {
            return dal.BuscarEmpleadoXCodigo(e);
        }
    }
}
