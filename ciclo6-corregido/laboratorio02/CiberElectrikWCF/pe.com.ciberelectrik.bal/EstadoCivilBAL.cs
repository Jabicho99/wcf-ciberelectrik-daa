using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class EstadoCivilBAL
    {
        EstadoCivilDAL dal = new EstadoCivilDAL();

        public List<EstadoCivilBO> MostrarEstadoCivil()
        {
            return dal.MostrarEstadoCivil();
        }

        public List<EstadoCivilBO> MostrarEstadoCivilTodo()
        {
            return dal.MostrarEstadoCivilTodo();
        }

        public bool RegistrarEstadoCivil(EstadoCivilBO c)
        {
            return dal.RegistrarEstadoCivil(c);
        }
        public bool ActualizarEstadoCivil(EstadoCivilBO c)
        {
            return dal.ActualizarEstadoCivil(c);
        }
        public bool EliminarEstadoCivil(EstadoCivilBO c)
        {
            return dal.EliminarEstadoCivil(c);
        }

        public bool HabilitarEstadoCivil(EstadoCivilBO c)
        {
            return dal.HabilitarEstadoCivil(c);
        }

        public int MostrarCodigoEstadoCivil()
        {
            return dal.MostrarCodigoEstadoCivil();
        }

        public EstadoCivilBO BuscarEstadoCivilXCodigo(EstadoCivilBO c)
        {
            return dal.BuscarEstadoCivilXCodigo(c);
        }
    }
}
