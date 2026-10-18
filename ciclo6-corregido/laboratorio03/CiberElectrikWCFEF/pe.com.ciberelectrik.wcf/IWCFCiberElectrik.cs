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

        //--------------------- Distrito --------------------------------------------------
        [OperationContract]
        List<DistritoBO> distritofindAll();
        [OperationContract]
        List<DistritoBO> distritofindAllCustom();
        [OperationContract]
        DistritoBO distritofindById(DistritoBO obj);
        [OperationContract]
        bool distritoadd(DistritoBO obj);
        [OperationContract]
        bool distritoupdate(DistritoBO obj);
        [OperationContract]
        bool distritodelete(DistritoBO obj);
        [OperationContract]
        bool distritoenable(DistritoBO obj);
        [OperationContract]
        int distritosetCode();
        //----------------------------------------------------------------------------------

        //--------------------- Rol --------------------------------------------------
        [OperationContract]
        List<RolBO> rolfindAll();
        [OperationContract]
        List<RolBO> rolfindAllCustom();
        [OperationContract]
        RolBO rolfindById(RolBO obj);
        [OperationContract]
        bool roladd(RolBO obj);
        [OperationContract]
        bool rolupdate(RolBO obj);
        [OperationContract]
        bool roldelete(RolBO obj);
        [OperationContract]
        bool rolenable(RolBO obj);
        [OperationContract]
        int rolsetCode();
        //----------------------------------------------------------------------------------

        //--------------------- TipoDocumento --------------------------------------------------
        [OperationContract]
        List<TipoDocumentoBO> tipodocumentofindAll();
        [OperationContract]
        List<TipoDocumentoBO> tipodocumentofindAllCustom();
        [OperationContract]
        TipoDocumentoBO tipodocumentofindById(TipoDocumentoBO obj);
        [OperationContract]
        bool tipodocumentoadd(TipoDocumentoBO obj);
        [OperationContract]
        bool tipodocumentoupdate(TipoDocumentoBO obj);
        [OperationContract]
        bool tipodocumentodelete(TipoDocumentoBO obj);
        [OperationContract]
        bool tipodocumentoenable(TipoDocumentoBO obj);
        [OperationContract]
        int tipodocumentosetCode();
        //----------------------------------------------------------------------------------

        //--------------------- Sexo --------------------------------------------------
        [OperationContract]
        List<SexoBO> sexofindAll();
        [OperationContract]
        List<SexoBO> sexofindAllCustom();
        [OperationContract]
        SexoBO sexofindById(SexoBO obj);
        [OperationContract]
        bool sexoadd(SexoBO obj);
        [OperationContract]
        bool sexoupdate(SexoBO obj);
        [OperationContract]
        bool sexodelete(SexoBO obj);
        [OperationContract]
        bool sexoenable(SexoBO obj);
        [OperationContract]
        int sexosetCode();
        //----------------------------------------------------------------------------------

        //--------------------- EstadoCivil --------------------------------------------------
        [OperationContract]
        List<EstadoCivilBO> estadocivilfindAll();
        [OperationContract]
        List<EstadoCivilBO> estadocivilfindAllCustom();
        [OperationContract]
        EstadoCivilBO estadocivilfindById(EstadoCivilBO obj);
        [OperationContract]
        bool estadociviladd(EstadoCivilBO obj);
        [OperationContract]
        bool estadocivilupdate(EstadoCivilBO obj);
        [OperationContract]
        bool estadocivildelete(EstadoCivilBO obj);
        [OperationContract]
        bool estadocivilenable(EstadoCivilBO obj);
        [OperationContract]
        int estadocivilsetCode();
        //----------------------------------------------------------------------------------

        //--------------------- Empleado --------------------------------------------------
        [OperationContract]
        List<EmpleadoBO> empleadofindAll();
        [OperationContract]
        List<EmpleadoBO> empleadofindAllCustom();
        [OperationContract]
        EmpleadoBO empleadofindById(EmpleadoBO obj);
        [OperationContract]
        bool empleadoadd(EmpleadoBO obj);
        [OperationContract]
        bool empleadoupdate(EmpleadoBO obj);
        [OperationContract]
        bool empleadodelete(EmpleadoBO obj);
        [OperationContract]
        bool empleadoenable(EmpleadoBO obj);
        [OperationContract]
        int empleadosetCode();
        //----------------------------------------------------------------------------------

        //--------------------- Cliente --------------------------------------------------
        [OperationContract]
        List<ClienteBO> clientefindAll();
        [OperationContract]
        List<ClienteBO> clientefindAllCustom();
        [OperationContract]
        ClienteBO clientefindById(ClienteBO obj);
        [OperationContract]
        bool clienteadd(ClienteBO obj);
        [OperationContract]
        bool clienteupdate(ClienteBO obj);
        [OperationContract]
        bool clientedelete(ClienteBO obj);
        [OperationContract]
        bool clienteenable(ClienteBO obj);
        [OperationContract]
        int clientesetCode();
        //----------------------------------------------------------------------------------
    }
}
