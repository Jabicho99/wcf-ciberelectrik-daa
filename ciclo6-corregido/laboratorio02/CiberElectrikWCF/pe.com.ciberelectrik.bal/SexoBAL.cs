using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class SexoBAL
    {
        SexoDAL dal = new SexoDAL();

        public List<SexoBO> MostrarSexo()
        {
            return dal.MostrarSexo();
        }

        public List<SexoBO> MostrarSexoTodo()
        {
            return dal.MostrarSexoTodo();
        }

        public bool RegistrarSexo(SexoBO c)
        {
            return dal.RegistrarSexo(c);
        }
        public bool ActualizarSexo(SexoBO c)
        {
            return dal.ActualizarSexo(c);
        }
        public bool EliminarSexo(SexoBO c)
        {
            return dal.EliminarSexo(c);
        }

        public bool HabilitarSexo(SexoBO c)
        {
            return dal.HabilitarSexo(c);
        }

        public int MostrarCodigoSexo()
        {
            return dal.MostrarCodigoSexo();
        }

        public SexoBO BuscarSexoXCodigo(SexoBO c)
        {
            return dal.BuscarSexoXCodigo(c);
        }
    }
}
