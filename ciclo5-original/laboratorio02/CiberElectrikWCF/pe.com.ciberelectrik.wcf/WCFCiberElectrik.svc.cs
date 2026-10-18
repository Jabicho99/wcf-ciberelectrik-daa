using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace pe.com.ciberelectrik.wcf
{
    //implementar la interfaz
    public class WCFCiberElectrik : IWCFCiberElectrik
    {
        //creamos un objeto de la clase DAL
        CategoriaDAL dalcat=new CategoriaDAL();
        MarcaDAL dalmar=new MarcaDAL();
        ProductoDAL dalpro=new ProductoDAL();

        //-------------------- Categoria ---------------------------------------------
        public List<CategoriaBO> categoriafindAll()
        {
            return dalcat.MostrarCategoriaTodo();
        }

        public List<CategoriaBO> categoriafindAllCustom()
        {
            return dalcat.MostrarCategoria();
        }

        public CategoriaBO categoriafindById(CategoriaBO obj)
        {
            return dalcat.BuscarCategoriaXCodigo(obj);
        }

        public bool categoriaadd(CategoriaBO obj)
        {
            return dalcat.RegistrarCategoria(obj);
        }

        public bool categoriaupdate(CategoriaBO obj)
        {
            return dalcat.ActualizarCategoria(obj);
        }

        public bool categoriadelete(CategoriaBO obj)
        {
            return dalcat.EliminarCategoria(obj);
        }

        public bool categoriaenable(CategoriaBO obj)
        {
            return dalcat.HabilitarCategoria(obj);
        }

        public int categoriasetCode()
        {
            return dalcat.MostrarCodigoCategoria();
        }


        //----------------------------------------------------------------------------


        //------------------- Marca ---------------------------------------------------
        public List<MarcaBO> marcafindAll()
        {
            return dalmar.MostrarMarcaTodo();
        }

        public List<MarcaBO> marcafindAllCustom()
        {
            return dalmar.MostrarMarca();
        }

        public MarcaBO marcafindById(MarcaBO obj)
        {
            return dalmar.BuscarMarcaXCodigo(obj);
        }

        public bool marcaadd(MarcaBO obj)
        {
            return dalmar.RegistrarMarca(obj);
        }

        public bool marcaupdate(MarcaBO obj)
        {
            return dalmar.ActualizarMarca(obj);
        }

        public bool marcadelete(MarcaBO obj)
        {
            return dalmar.EliminarMarca(obj);
        }

        public bool marcaenable(MarcaBO obj)
        {
            return dalmar.HabilitarMarca(obj);
        }

        public int marcasetCode()
        {
            return dalmar.MostrarCodigoMarca();
        }

        //-------------------------------------------------------------------------------

        //------------------- Producto ---------------------------------------------------
        public List<ProductoBO> productofindAll()
        {
            return dalpro.MostrarProductoTodo();
        }

        public List<ProductoBO> productofindAllCustom()
        {
            return dalpro.MostrarProducto();
        }

        public ProductoBO productofindById(ProductoBO obj)
        {
            return dalpro.BuscarProductoXCodigo(obj);
        }

        public bool productoadd(ProductoBO obj)
        {
            return dalpro.RegistrarProducto(obj);
        }

        public bool productoupdate(ProductoBO obj)
        {
            return dalpro.ActualizarProducto(obj);
        }

        public bool productodelete(ProductoBO obj)
        {
            return dalpro.EliminarProducto(obj);
        }

        public bool productoenable(ProductoBO obj)
        {
            return dalpro.HabilitarProducto(obj);
        }

        public int productosetCode()
        {
            return dalpro.MostrarCodigoProducto();
        }

        //---------------------------------------------------------------------------------
    }
}
