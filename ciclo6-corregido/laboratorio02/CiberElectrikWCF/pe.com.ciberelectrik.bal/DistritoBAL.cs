using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class DistritoBAL
    {
        DistritoDAL dal = new DistritoDAL();

        public List<DistritoBO> MostrarDistrito()
        {
            return dal.MostrarDistrito();
        }

        public List<DistritoBO> MostrarDistritoTodo()
        {
            return dal.MostrarDistritoTodo();
        }

        public bool RegistrarDistrito(DistritoBO c)
        {
            return dal.RegistrarDistrito(c);
        }
        public bool ActualizarDistrito(DistritoBO c)
        {
            return dal.ActualizarDistrito(c);
        }
        public bool EliminarDistrito(DistritoBO c)
        {
            return dal.EliminarDistrito(c);
        }

        public bool HabilitarDistrito(DistritoBO c)
        {
            return dal.HabilitarDistrito(c);
        }

        public int MostrarCodigoDistrito()
        {
            return dal.MostrarCodigoDistrito();
        }

        public DistritoBO BuscarDistritoXCodigo(DistritoBO c)
        {
            return dal.BuscarDistritoXCodigo(c);
        }
    }
}
