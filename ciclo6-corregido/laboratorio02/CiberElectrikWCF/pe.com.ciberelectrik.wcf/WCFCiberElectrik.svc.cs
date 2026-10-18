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
        DistritoDAL daldis=new DistritoDAL();
        RolDAL dalrol=new RolDAL();
        TipoDocumentoDAL daltipd=new TipoDocumentoDAL();
        SexoDAL dalsex=new SexoDAL();
        EstadoCivilDAL dalestc=new EstadoCivilDAL();
        EmpleadoDAL dalemp=new EmpleadoDAL();
        ClienteDAL dalcli=new ClienteDAL();

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

        //------------------- Distrito ---------------------------------------------------
        public List<DistritoBO> distritofindAll()
        {
            return daldis.MostrarDistritoTodo();
        }

        public List<DistritoBO> distritofindAllCustom()
        {
            return daldis.MostrarDistrito();
        }

        public DistritoBO distritofindById(DistritoBO obj)
        {
            return daldis.BuscarDistritoXCodigo(obj);
        }

        public bool distritoadd(DistritoBO obj)
        {
            return daldis.RegistrarDistrito(obj);
        }

        public bool distritoupdate(DistritoBO obj)
        {
            return daldis.ActualizarDistrito(obj);
        }

        public bool distritodelete(DistritoBO obj)
        {
            return daldis.EliminarDistrito(obj);
        }

        public bool distritoenable(DistritoBO obj)
        {
            return daldis.HabilitarDistrito(obj);
        }

        public int distritosetCode()
        {
            return daldis.MostrarCodigoDistrito();
        }
        //---------------------------------------------------------------------------------

        //------------------- Rol ---------------------------------------------------
        public List<RolBO> rolfindAll()
        {
            return dalrol.MostrarRolTodo();
        }

        public List<RolBO> rolfindAllCustom()
        {
            return dalrol.MostrarRol();
        }

        public RolBO rolfindById(RolBO obj)
        {
            return dalrol.BuscarRolXCodigo(obj);
        }

        public bool roladd(RolBO obj)
        {
            return dalrol.RegistrarRol(obj);
        }

        public bool rolupdate(RolBO obj)
        {
            return dalrol.ActualizarRol(obj);
        }

        public bool roldelete(RolBO obj)
        {
            return dalrol.EliminarRol(obj);
        }

        public bool rolenable(RolBO obj)
        {
            return dalrol.HabilitarRol(obj);
        }

        public int rolsetCode()
        {
            return dalrol.MostrarCodigoRol();
        }
        //---------------------------------------------------------------------------------

        //------------------- TipoDocumento ---------------------------------------------------
        public List<TipoDocumentoBO> tipodocumentofindAll()
        {
            return daltipd.MostrarTipoDocumentoTodo();
        }

        public List<TipoDocumentoBO> tipodocumentofindAllCustom()
        {
            return daltipd.MostrarTipoDocumento();
        }

        public TipoDocumentoBO tipodocumentofindById(TipoDocumentoBO obj)
        {
            return daltipd.BuscarTipoDocumentoXCodigo(obj);
        }

        public bool tipodocumentoadd(TipoDocumentoBO obj)
        {
            return daltipd.RegistrarTipoDocumento(obj);
        }

        public bool tipodocumentoupdate(TipoDocumentoBO obj)
        {
            return daltipd.ActualizarTipoDocumento(obj);
        }

        public bool tipodocumentodelete(TipoDocumentoBO obj)
        {
            return daltipd.EliminarTipoDocumento(obj);
        }

        public bool tipodocumentoenable(TipoDocumentoBO obj)
        {
            return daltipd.HabilitarTipoDocumento(obj);
        }

        public int tipodocumentosetCode()
        {
            return daltipd.MostrarCodigoTipoDocumento();
        }
        //---------------------------------------------------------------------------------

        //------------------- Sexo ---------------------------------------------------
        public List<SexoBO> sexofindAll()
        {
            return dalsex.MostrarSexoTodo();
        }

        public List<SexoBO> sexofindAllCustom()
        {
            return dalsex.MostrarSexo();
        }

        public SexoBO sexofindById(SexoBO obj)
        {
            return dalsex.BuscarSexoXCodigo(obj);
        }

        public bool sexoadd(SexoBO obj)
        {
            return dalsex.RegistrarSexo(obj);
        }

        public bool sexoupdate(SexoBO obj)
        {
            return dalsex.ActualizarSexo(obj);
        }

        public bool sexodelete(SexoBO obj)
        {
            return dalsex.EliminarSexo(obj);
        }

        public bool sexoenable(SexoBO obj)
        {
            return dalsex.HabilitarSexo(obj);
        }

        public int sexosetCode()
        {
            return dalsex.MostrarCodigoSexo();
        }
        //---------------------------------------------------------------------------------

        //------------------- EstadoCivil ---------------------------------------------------
        public List<EstadoCivilBO> estadocivilfindAll()
        {
            return dalestc.MostrarEstadoCivilTodo();
        }

        public List<EstadoCivilBO> estadocivilfindAllCustom()
        {
            return dalestc.MostrarEstadoCivil();
        }

        public EstadoCivilBO estadocivilfindById(EstadoCivilBO obj)
        {
            return dalestc.BuscarEstadoCivilXCodigo(obj);
        }

        public bool estadociviladd(EstadoCivilBO obj)
        {
            return dalestc.RegistrarEstadoCivil(obj);
        }

        public bool estadocivilupdate(EstadoCivilBO obj)
        {
            return dalestc.ActualizarEstadoCivil(obj);
        }

        public bool estadocivildelete(EstadoCivilBO obj)
        {
            return dalestc.EliminarEstadoCivil(obj);
        }

        public bool estadocivilenable(EstadoCivilBO obj)
        {
            return dalestc.HabilitarEstadoCivil(obj);
        }

        public int estadocivilsetCode()
        {
            return dalestc.MostrarCodigoEstadoCivil();
        }
        //---------------------------------------------------------------------------------

        //------------------- Empleado ---------------------------------------------------
        public List<EmpleadoBO> empleadofindAll()
        {
            return dalemp.MostrarEmpleadoTodo();
        }

        public List<EmpleadoBO> empleadofindAllCustom()
        {
            return dalemp.MostrarEmpleado();
        }

        public EmpleadoBO empleadofindById(EmpleadoBO obj)
        {
            return dalemp.BuscarEmpleadoXCodigo(obj);
        }

        public bool empleadoadd(EmpleadoBO obj)
        {
            return dalemp.RegistrarEmpleado(obj);
        }

        public bool empleadoupdate(EmpleadoBO obj)
        {
            return dalemp.ActualizarEmpleado(obj);
        }

        public bool empleadodelete(EmpleadoBO obj)
        {
            return dalemp.EliminarEmpleado(obj);
        }

        public bool empleadoenable(EmpleadoBO obj)
        {
            return dalemp.HabilitarEmpleado(obj);
        }

        public int empleadosetCode()
        {
            return dalemp.MostrarCodigoEmpleado();
        }
        //---------------------------------------------------------------------------------

        //------------------- Cliente ---------------------------------------------------
        public List<ClienteBO> clientefindAll()
        {
            return dalcli.MostrarClienteTodo();
        }

        public List<ClienteBO> clientefindAllCustom()
        {
            return dalcli.MostrarCliente();
        }

        public ClienteBO clientefindById(ClienteBO obj)
        {
            return dalcli.BuscarClienteXCodigo(obj);
        }

        public bool clienteadd(ClienteBO obj)
        {
            return dalcli.RegistrarCliente(obj);
        }

        public bool clienteupdate(ClienteBO obj)
        {
            return dalcli.ActualizarCliente(obj);
        }

        public bool clientedelete(ClienteBO obj)
        {
            return dalcli.EliminarCliente(obj);
        }

        public bool clienteenable(ClienteBO obj)
        {
            return dalcli.HabilitarCliente(obj);
        }

        public int clientesetCode()
        {
            return dalcli.MostrarCodigoCliente();
        }
        //---------------------------------------------------------------------------------
    }
}
