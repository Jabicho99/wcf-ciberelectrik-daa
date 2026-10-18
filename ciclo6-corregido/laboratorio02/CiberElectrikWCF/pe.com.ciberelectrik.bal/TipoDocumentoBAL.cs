using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class TipoDocumentoBAL
    {
        TipoDocumentoDAL dal = new TipoDocumentoDAL();

        public List<TipoDocumentoBO> MostrarTipoDocumento()
        {
            return dal.MostrarTipoDocumento();
        }

        public List<TipoDocumentoBO> MostrarTipoDocumentoTodo()
        {
            return dal.MostrarTipoDocumentoTodo();
        }

        public bool RegistrarTipoDocumento(TipoDocumentoBO c)
        {
            return dal.RegistrarTipoDocumento(c);
        }
        public bool ActualizarTipoDocumento(TipoDocumentoBO c)
        {
            return dal.ActualizarTipoDocumento(c);
        }
        public bool EliminarTipoDocumento(TipoDocumentoBO c)
        {
            return dal.EliminarTipoDocumento(c);
        }

        public bool HabilitarTipoDocumento(TipoDocumentoBO c)
        {
            return dal.HabilitarTipoDocumento(c);
        }

        public int MostrarCodigoTipoDocumento()
        {
            return dal.MostrarCodigoTipoDocumento();
        }

        public TipoDocumentoBO BuscarTipoDocumentoXCodigo(TipoDocumentoBO c)
        {
            return dal.BuscarTipoDocumentoXCodigo(c);
        }
    }
}
