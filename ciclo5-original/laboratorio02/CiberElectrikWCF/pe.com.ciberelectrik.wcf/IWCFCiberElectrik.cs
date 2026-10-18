using pe.com.ciberelectrik.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace pe.com.ciberelectrik.wcf
{
    //[ServiceContract] -> marca a la interfaz como un contrato de servicio WCF
    [ServiceContract]
    public interface IWCFCiberElectrik
    {
        //[OperationContract] -> expone las operaciones en el servicio
        //----------------------- Categoria ----------------------------------------------
        [OperationContract]
        List<CategoriaBO> categoriafindAll();
        [OperationContract]
        List<CategoriaBO> categoriafindAllCustom();
        [OperationContract]
        CategoriaBO categoriafindById(CategoriaBO obj);
        [OperationContract]
        bool categoriaadd(CategoriaBO obj);
        [OperationContract]
        bool categoriaupdate(CategoriaBO obj);
        [OperationContract]
        bool categoriadelete(CategoriaBO obj);
        [OperationContract]
        bool categoriaenable(CategoriaBO obj);
        [OperationContract]
        int categoriasetCode();
        //----------------------------------------------------------------------------------

        //----------------------- Marca ----------------------------------------------------
        [OperationContract]
        List<MarcaBO> marcafindAll();
        [OperationContract]
        List<MarcaBO> marcafindAllCustom();
        [OperationContract]
        MarcaBO marcafindById(MarcaBO obj);
        [OperationContract]
        bool marcaadd(MarcaBO obj);
        [OperationContract]
        bool marcaupdate(MarcaBO obj);
        [OperationContract]
        bool marcadelete(MarcaBO obj);
        [OperationContract]
        bool marcaenable(MarcaBO obj);
        [OperationContract]
        int marcasetCode();

        //--------------------------------------------------------------------------------

        //--------------------- Producto --------------------------------------------------
        [OperationContract]
        List<ProductoBO> productofindAll();
        [OperationContract]
        List<ProductoBO> productofindAllCustom();
        [OperationContract]
        ProductoBO productofindById(ProductoBO obj);
        [OperationContract]
        bool productoadd(ProductoBO obj);
        [OperationContract]
        bool productoupdate(ProductoBO obj);
        [OperationContract]
        bool productodelete(ProductoBO obj);
        [OperationContract]
        bool productoenable(ProductoBO obj);
        [OperationContract]
        int productosetCode();

        //----------------------------------------------------------------------------------
    }
}
