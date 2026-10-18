using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.ciberelectrik.bal
{
    public class ProductoBAL
    {
        ProductoDAL dal = new ProductoDAL();

        public List<ProductoBO> MostrarProducto()
        {
            return dal.MostrarProducto();
        }

        public List<ProductoBO> MostrarProductoTodo()
        {
            return dal.MostrarProductoTodo();
        }

        public bool RegistrarProducto(ProductoBO p)
        {
            return dal.RegistrarProducto(p);
        }
        public bool ActualizarProducto(ProductoBO p)
        {
            return dal.ActualizarProducto(p);
        }
        public bool EliminarProducto(ProductoBO p)
        {
            return dal.EliminarProducto(p);
        }

        public bool HabilitarProducto(ProductoBO p)
        {
            return dal.HabilitarProducto(p);
        }

        public int MostrarCodigoProducto()
        {
            return dal.MostrarCodigoProducto();
        }

        public ProductoBO BuscarProductoXCodigo(ProductoBO p)
        {
            return dal.BuscarProductoXCodigo(p);
        }
    }
}
