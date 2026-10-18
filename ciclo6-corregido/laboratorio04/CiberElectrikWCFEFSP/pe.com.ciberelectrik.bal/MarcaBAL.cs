using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class MarcaBAL
    {
        MarcaDAL dal = new MarcaDAL();

        public List<MarcaBO> MostrarMarca()
        {
            return dal.MostrarMarca();
        }

        public List<MarcaBO> MostrarMarcaTodo()
        {
            return dal.MostrarMarcaTodo();
        }
        public bool RegistrarMarca(MarcaBO m)
        {
            return dal.RegistrarMarca(m);
        }
        public bool ActualizarMarca(MarcaBO m)
        {
            return dal.ActualizarMarca(m);
        }
        public bool EliminarCategoria(MarcaBO m)
        {
            return dal.EliminarMarca(m);
        }

        public bool HabilitarMarca(MarcaBO m)
        {
            return dal.HabilitarMarca(m);
        }

        public int MostrarCodigoMarca()
        {
            return dal.MostrarCodigoMarca();
        }
        public MarcaBO BuscarMarcaXCodigo(MarcaBO m)
        {
            return dal.BuscarMarcaXCodigo(m);
        }
    }
}
