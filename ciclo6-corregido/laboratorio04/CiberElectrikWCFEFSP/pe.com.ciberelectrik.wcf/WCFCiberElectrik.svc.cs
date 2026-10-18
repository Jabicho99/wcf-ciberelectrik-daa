using pe.com.ciberelectrik.bo;
using pe.com.ciberelectrik.dal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace pe.com.ciberelectrik.wcf
{
    //implementar la interfaz
    public class WCFCiberElectrik : IWCFCiberElectrik
    {
        //creamos un objeto 
        bdciberelectrikapi20262Entities contexto=new bdciberelectrikapi20262Entities();
        //-------------------- Categoria ---------------------------------------------
        public List<CategoriaBO> categoriafindAll()
        {
            try
            {
                return contexto.SP_MostrarCategoriaTodo().Select(
                    c => new CategoriaBO
                    {
                        codigo=c.codcat,
                        nombre=c.nomcat,
                        estado=c.estcat
                    }
                    ).ToList();
            }
            catch (Exception ex)
            {

                Debug.WriteLine( ex.Message);
                return null;
            }
        }

        public List<CategoriaBO> categoriafindAllCustom()
        {
            try
            {
                return contexto.SP_MostrarCategoria().Where(c=>c.estcat).Select(
                    c => new CategoriaBO
                    {
                        codigo = c.codcat,
                        nombre = c.nomcat,
                        estado = c.estcat
                    }
                    ).ToList();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public CategoriaBO categoriafindById(CategoriaBO obj)
        {
            try
            {
                return contexto.SP_BuscarCategoriaXCodigo(obj.codigo).Select(
                    c => new CategoriaBO
                    {
                        codigo = c.codcat,
                        nombre = c.nomcat,
                        estado = c.estcat
                    }
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public bool categoriaadd(CategoriaBO obj)
        {
            try
            {
                int res = contexto.SP_RegistrarCategoria(obj.nombre,obj.estado);
                return res == 1;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool categoriaupdate(CategoriaBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarCategoria(obj.codigo,obj.nombre, obj.estado);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool categoriadelete(CategoriaBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_EliminarCategoria(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool categoriaenable(CategoriaBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarCategoria(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public int categoriasetCode()
        {
            try
            {
                return Convert.ToInt32(contexto.SP_CodigoCategoria());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }


        //----------------------------------------------------------------------------


        //------------------- Marca ---------------------------------------------------
        public List<MarcaBO> marcafindAll()
        {
            try
            {
                return contexto.marca.Select(
                    m => new MarcaBO
                    {
                        codigo = m.codmar,
                        nombre = m.nommar,
                        estado = m.estmar
                    }
                    ).ToList();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<MarcaBO> marcafindAllCustom()
        {
            try
            {
                return contexto.marca.Where(m => m.estmar).Select(
                    m => new MarcaBO
                    {
                        codigo = m.codmar,
                        nombre = m.nommar,
                        estado = m.estmar
                    }
                    ).ToList();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public MarcaBO marcafindById(MarcaBO obj)
        {
            try{
                return contexto.marca.Where(m => m.codmar == obj.codigo).Select(
                    m => new MarcaBO
                    {
                        codigo = m.codmar,
                        nombre = m.nommar,
                        estado = m.estmar
                    }
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public bool marcaadd(MarcaBO obj)
        {
            try
            {
                marca mar = new marca
                {
                    nommar = obj.nombre,
                    estmar = obj.estado
                };
                contexto.marca.Add(mar);
                return contexto.SaveChanges() == 1;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool marcaupdate(MarcaBO obj)
        {
            try
            {
                var mar = contexto.marca.Find(obj.codigo);
                if (mar != null)
                {
                    mar.nommar = obj.nombre;
                    mar.estmar = obj.estado;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool marcadelete(MarcaBO obj)
        {
            try
            {
                var mar = contexto.marca.Find(obj.codigo);
                if (mar != null)
                {
                    mar.estmar = false;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool marcaenable(MarcaBO obj)
        {
            try
            {
                var mar = contexto.marca.Find(obj.codigo);
                if (mar != null)
                {
                    mar.estmar = true;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public int marcasetCode()
        {
            try
            {
                int siguiente = contexto.marca.Any() ? contexto.marca
                    .Max(m => m.codmar + 1) : 1;
                return siguiente;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        //-------------------------------------------------------------------------------

        //------------------- Producto ---------------------------------------------------
        public List<ProductoBO> productofindAll()
        {
            try
            {
                return contexto.SP_MostrarProductoTodo().Select(
                    p => new ProductoBO
                    {
                        codigo = p.codpro,
                        nombre = p.nompro,
                        descripcion = p.despro,
                        fechaingreso = p.fecing,
                        precio = p.prepro,
                        cantidad = p.canpro,
                        marca=new MarcaBO
                        {
                            codigo=p.codmar,
                            nombre=p.nommar
                        },
                        categoria=new CategoriaBO
                        {
                            codigo=p.codcat,
                            nombre=p.nomcat
                        },
                        estado = p.estpro
                    }
                    ).ToList();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<ProductoBO> productofindAllCustom()
        {
            try
            {
                return contexto.SP_MostrarProducto().Where(p=>p.estpro).Select(
                    p => new ProductoBO
                    {
                        codigo = p.codpro,
                        nombre = p.nompro,
                        descripcion = p.despro,
                        fechaingreso = p.fecing,
                        precio = p.prepro,
                        cantidad = p.canpro,
                        marca = new MarcaBO
                        {
                            codigo = p.codmar,
                            nombre = p.nommar
                        },
                        categoria = new CategoriaBO
                        {
                            codigo = p.codcat,
                            nombre = p.nomcat
                        },
                        estado = p.estpro
                    }
                    ).ToList();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public ProductoBO productofindById(ProductoBO obj)
        {
            try
            {
                return contexto.SP_BuscarProductoXCodigo(obj.codigo).Select(
                    p => new ProductoBO
                    {
                        codigo = p.codpro,
                        nombre = p.nompro,
                        descripcion = p.despro,
                        fechaingreso = p.fecing,
                        precio = p.prepro,
                        cantidad = p.canpro,
                        marca = new MarcaBO
                        {
                            codigo = p.codmar,
                            nombre = p.nommar
                        },
                        categoria = new CategoriaBO
                        {
                            codigo = p.codcat,
                            nombre = p.nomcat
                        },
                        estado = p.estpro
                    }
                    ).FirstOrDefault();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public bool productoadd(ProductoBO obj)
        {
            try
            {
                int res = contexto.SP_RegistrarProducto(obj.nombre,obj.descripcion,obj.precio,
                    obj.cantidad,obj.fechaingreso, obj.estado,obj.categoria.codigo,
                    obj.marca.codigo);
                return res == 1;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool productoupdate(ProductoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarProducto(obj.codigo, obj.nombre, 
                        obj.descripcion, obj.precio,obj.cantidad, obj.fechaingreso, 
                        obj.estado, obj.categoria.codigo,
                        obj.marca.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool productodelete(ProductoBO obj)
        {
            try
            {
                var pro = contexto.SP_BuscarProductoXCodigo(obj.codigo);
                if (pro != null)
                {
                    int res = contexto.SP_EliminarProducto(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool productoenable(ProductoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarProducto(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public int productosetCode()
        {
            try
            {
                return Convert.ToInt32(contexto.SP_CodigoProducto());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return 0;
            }
        }

        //---------------------------------------------------------------------------------

        //------------------- Distrito ---------------------------------------------------
        public List<DistritoBO> distritofindAll()
        {
            try
            {
                return contexto.SP_MostrarDistritoTodo().Select(
                    x => new DistritoBO { codigo = x.coddis, nombre = x.nomdis, estado = x.estdis }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<DistritoBO> distritofindAllCustom()
        {
            try
            {
                return contexto.SP_MostrarDistrito().Select(
                    x => new DistritoBO { codigo = x.coddis, nombre = x.nomdis, estado = x.estdis }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public DistritoBO distritofindById(DistritoBO obj)
        {
            try
            {
                return contexto.SP_BuscarDistritoXCodigo(obj.codigo).Select(
                    x => new DistritoBO { codigo = x.coddis, nombre = x.nomdis, estado = x.estdis }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool distritoadd(DistritoBO obj)
        {
            try
            {
                int res = contexto.SP_RegistrarDistrito(obj.nombre, obj.estado);
                return res == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool distritoupdate(DistritoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarDistrito(obj.codigo, obj.nombre, obj.estado);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool distritodelete(DistritoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_EliminarDistrito(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool distritoenable(DistritoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarDistrito(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int distritosetCode()
        {
            try
            {
                return Convert.ToInt32(contexto.SP_CodigoDistrito());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- Rol ---------------------------------------------------
        public List<RolBO> rolfindAll()
        {
            try
            {
                return contexto.SP_MostrarRolTodo().Select(
                    x => new RolBO { codigo = x.codrol, nombre = x.nomrol, estado = x.estrol }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<RolBO> rolfindAllCustom()
        {
            try
            {
                return contexto.SP_MostrarRol().Select(
                    x => new RolBO { codigo = x.codrol, nombre = x.nomrol, estado = x.estrol }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public RolBO rolfindById(RolBO obj)
        {
            try
            {
                return contexto.SP_BuscarRolXCodigo(obj.codigo).Select(
                    x => new RolBO { codigo = x.codrol, nombre = x.nomrol, estado = x.estrol }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool roladd(RolBO obj)
        {
            try
            {
                int res = contexto.SP_RegistrarRol(obj.nombre, obj.estado);
                return res == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool rolupdate(RolBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarRol(obj.codigo, obj.nombre, obj.estado);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool roldelete(RolBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_EliminarRol(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool rolenable(RolBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarRol(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int rolsetCode()
        {
            try
            {
                return Convert.ToInt32(contexto.SP_CodigoRol());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- TipoDocumento ---------------------------------------------------
        public List<TipoDocumentoBO> tipodocumentofindAll()
        {
            try
            {
                return contexto.SP_MostrarTipoDocumentoTodo().Select(
                    x => new TipoDocumentoBO { codigo = x.codtipd, nombre = x.nomtipd, estado = x.esttipd }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<TipoDocumentoBO> tipodocumentofindAllCustom()
        {
            try
            {
                return contexto.SP_MostrarTipoDocumento().Select(
                    x => new TipoDocumentoBO { codigo = x.codtipd, nombre = x.nomtipd, estado = x.esttipd }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public TipoDocumentoBO tipodocumentofindById(TipoDocumentoBO obj)
        {
            try
            {
                return contexto.SP_BuscarTipoDocumentoXCodigo(obj.codigo).Select(
                    x => new TipoDocumentoBO { codigo = x.codtipd, nombre = x.nomtipd, estado = x.esttipd }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool tipodocumentoadd(TipoDocumentoBO obj)
        {
            try
            {
                int res = contexto.SP_RegistrarTipoDocumento(obj.nombre, obj.estado);
                return res == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool tipodocumentoupdate(TipoDocumentoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarTipoDocumento(obj.codigo, obj.nombre, obj.estado);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool tipodocumentodelete(TipoDocumentoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_EliminarTipoDocumento(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool tipodocumentoenable(TipoDocumentoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarTipoDocumento(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int tipodocumentosetCode()
        {
            try
            {
                return Convert.ToInt32(contexto.SP_CodigoTipoDocumento());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- Sexo ---------------------------------------------------
        public List<SexoBO> sexofindAll()
        {
            try
            {
                return contexto.SP_MostrarSexoTodo().Select(
                    x => new SexoBO { codigo = x.codsex, nombre = x.nomsex, estado = x.estsex }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<SexoBO> sexofindAllCustom()
        {
            try
            {
                return contexto.SP_MostrarSexo().Select(
                    x => new SexoBO { codigo = x.codsex, nombre = x.nomsex, estado = x.estsex }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public SexoBO sexofindById(SexoBO obj)
        {
            try
            {
                return contexto.SP_BuscarSexoXCodigo(obj.codigo).Select(
                    x => new SexoBO { codigo = x.codsex, nombre = x.nomsex, estado = x.estsex }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool sexoadd(SexoBO obj)
        {
            try
            {
                int res = contexto.SP_RegistrarSexo(obj.nombre, obj.estado);
                return res == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool sexoupdate(SexoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarSexo(obj.codigo, obj.nombre, obj.estado);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool sexodelete(SexoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_EliminarSexo(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool sexoenable(SexoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarSexo(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int sexosetCode()
        {
            try
            {
                return Convert.ToInt32(contexto.SP_CodigoSexo());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- EstadoCivil ---------------------------------------------------
        public List<EstadoCivilBO> estadocivilfindAll()
        {
            try
            {
                return contexto.SP_MostrarEstadoCivilTodo().Select(
                    x => new EstadoCivilBO { codigo = x.codestc, nombre = x.nomestc, estado = x.estestc }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<EstadoCivilBO> estadocivilfindAllCustom()
        {
            try
            {
                return contexto.SP_MostrarEstadoCivil().Select(
                    x => new EstadoCivilBO { codigo = x.codestc, nombre = x.nomestc, estado = x.estestc }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public EstadoCivilBO estadocivilfindById(EstadoCivilBO obj)
        {
            try
            {
                return contexto.SP_BuscarEstadoCivilXCodigo(obj.codigo).Select(
                    x => new EstadoCivilBO { codigo = x.codestc, nombre = x.nomestc, estado = x.estestc }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool estadociviladd(EstadoCivilBO obj)
        {
            try
            {
                int res = contexto.SP_RegistrarEstadoCivil(obj.nombre, obj.estado);
                return res == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool estadocivilupdate(EstadoCivilBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarEstadoCivil(obj.codigo, obj.nombre, obj.estado);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool estadocivildelete(EstadoCivilBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_EliminarEstadoCivil(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool estadocivilenable(EstadoCivilBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarEstadoCivil(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int estadocivilsetCode()
        {
            try
            {
                return Convert.ToInt32(contexto.SP_CodigoEstadoCivil());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- Empleado ---------------------------------------------------
        public List<EmpleadoBO> empleadofindAll()
        {
            try
            {
                return contexto.SP_MostrarEmpleadoTodo().Select(
                    e => new EmpleadoBO
                    {
                        codigo = e.codemp, nombre = e.nomemp, apepaterno = e.apepemp, apematerno = e.apememp,
                        documento = e.docemp, direccion = e.diremp, fecha = e.fecemp, nacionalidad = e.nacemp,
                        telefono = e.telemp, celular = e.celemp, correo = e.coremp, usuario = e.usuemp, clave = e.claemp,
                        estado = e.estemp,
                        distrito = new DistritoBO { codigo = e.coddis, nombre = e.nomdis },
                        rol = new RolBO { codigo = e.codrol, nombre = e.nomrol },
                        tipoDocumento = new TipoDocumentoBO { codigo = e.codtipd, nombre = e.nomtipd },
                        sexo = new SexoBO { codigo = e.codsex, nombre = e.nomsex },
                        estadoCivil = new EstadoCivilBO { codigo = e.codestc, nombre = e.nomestc }
                    }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<EmpleadoBO> empleadofindAllCustom()
        {
            try
            {
                return contexto.SP_MostrarEmpleado().Select(
                    e => new EmpleadoBO
                    {
                        codigo = e.codemp, nombre = e.nomemp, apepaterno = e.apepemp, apematerno = e.apememp,
                        documento = e.docemp, direccion = e.diremp, fecha = e.fecemp, nacionalidad = e.nacemp,
                        telefono = e.telemp, celular = e.celemp, correo = e.coremp, usuario = e.usuemp, clave = e.claemp,
                        estado = e.estemp,
                        distrito = new DistritoBO { codigo = e.coddis, nombre = e.nomdis },
                        rol = new RolBO { codigo = e.codrol, nombre = e.nomrol },
                        tipoDocumento = new TipoDocumentoBO { codigo = e.codtipd, nombre = e.nomtipd },
                        sexo = new SexoBO { codigo = e.codsex, nombre = e.nomsex },
                        estadoCivil = new EstadoCivilBO { codigo = e.codestc, nombre = e.nomestc }
                    }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public EmpleadoBO empleadofindById(EmpleadoBO obj)
        {
            try
            {
                return contexto.SP_BuscarEmpleadoXCodigo(obj.codigo).Select(
                    e => new EmpleadoBO
                    {
                        codigo = e.codemp, nombre = e.nomemp, apepaterno = e.apepemp, apematerno = e.apememp,
                        documento = e.docemp, direccion = e.diremp, fecha = e.fecemp, nacionalidad = e.nacemp,
                        telefono = e.telemp, celular = e.celemp, correo = e.coremp, usuario = e.usuemp, clave = e.claemp,
                        estado = e.estemp,
                        distrito = new DistritoBO { codigo = e.coddis, nombre = e.nomdis },
                        rol = new RolBO { codigo = e.codrol, nombre = e.nomrol },
                        tipoDocumento = new TipoDocumentoBO { codigo = e.codtipd, nombre = e.nomtipd },
                        sexo = new SexoBO { codigo = e.codsex, nombre = e.nomsex },
                        estadoCivil = new EstadoCivilBO { codigo = e.codestc, nombre = e.nomestc }
                    }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool empleadoadd(EmpleadoBO obj)
        {
            try
            {
                int res = contexto.SP_RegistrarEmpleado(obj.nombre, obj.apepaterno, obj.apematerno, obj.documento,
                    obj.direccion, obj.fecha, obj.nacionalidad, obj.telefono, obj.celular, obj.correo,
                    obj.usuario, obj.clave, obj.estado, obj.distrito.codigo, obj.rol.codigo,
                    obj.tipoDocumento.codigo, obj.sexo.codigo, obj.estadoCivil.codigo);
                return res == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool empleadoupdate(EmpleadoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarEmpleado(obj.codigo, obj.nombre, obj.apepaterno, obj.apematerno,
                        obj.documento, obj.direccion, obj.fecha, obj.nacionalidad, obj.telefono, obj.celular, obj.correo,
                        obj.usuario, obj.clave, obj.estado, obj.distrito.codigo, obj.rol.codigo,
                        obj.tipoDocumento.codigo, obj.sexo.codigo, obj.estadoCivil.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool empleadodelete(EmpleadoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_EliminarEmpleado(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool empleadoenable(EmpleadoBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarEmpleado(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int empleadosetCode()
        {
            try
            {
                return Convert.ToInt32(contexto.SP_CodigoEmpleado());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- Cliente ---------------------------------------------------
        public List<ClienteBO> clientefindAll()
        {
            try
            {
                return contexto.SP_MostrarClienteTodo().Select(
                    c => new ClienteBO
                    {
                        codigo = c.codcli, nombre = c.nomcli, apepaterno = c.apepcli, apematerno = c.apemcli,
                        documento = c.doccli, fecha = c.feccli, nacionalidad = c.naccli, direccion = c.dircli,
                        telefono = c.telcli, celular = c.celcli, correo = c.corcli, estado = c.estcli,
                        distrito = new DistritoBO { codigo = c.coddis, nombre = c.nomdis },
                        tipoDocumento = new TipoDocumentoBO { codigo = c.codtipd, nombre = c.nomtipd },
                        sexo = new SexoBO { codigo = c.codsex, nombre = c.nomsex }
                    }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<ClienteBO> clientefindAllCustom()
        {
            try
            {
                return contexto.SP_MostrarCliente().Select(
                    c => new ClienteBO
                    {
                        codigo = c.codcli, nombre = c.nomcli, apepaterno = c.apepcli, apematerno = c.apemcli,
                        documento = c.doccli, fecha = c.feccli, nacionalidad = c.naccli, direccion = c.dircli,
                        telefono = c.telcli, celular = c.celcli, correo = c.corcli, estado = c.estcli,
                        distrito = new DistritoBO { codigo = c.coddis, nombre = c.nomdis },
                        tipoDocumento = new TipoDocumentoBO { codigo = c.codtipd, nombre = c.nomtipd },
                        sexo = new SexoBO { codigo = c.codsex, nombre = c.nomsex }
                    }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public ClienteBO clientefindById(ClienteBO obj)
        {
            try
            {
                return contexto.SP_BuscarClienteXCodigo(obj.codigo).Select(
                    c => new ClienteBO
                    {
                        codigo = c.codcli, nombre = c.nomcli, apepaterno = c.apepcli, apematerno = c.apemcli,
                        documento = c.doccli, fecha = c.feccli, nacionalidad = c.naccli, direccion = c.dircli,
                        telefono = c.telcli, celular = c.celcli, correo = c.corcli, estado = c.estcli,
                        distrito = new DistritoBO { codigo = c.coddis, nombre = c.nomdis },
                        tipoDocumento = new TipoDocumentoBO { codigo = c.codtipd, nombre = c.nomtipd },
                        sexo = new SexoBO { codigo = c.codsex, nombre = c.nomsex }
                    }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool clienteadd(ClienteBO obj)
        {
            try
            {
                int res = contexto.SP_RegistrarCliente(obj.nombre, obj.apepaterno, obj.apematerno, obj.documento,
                    obj.fecha, obj.nacionalidad, obj.direccion, obj.telefono, obj.celular, obj.correo,
                    obj.estado, obj.distrito.codigo, obj.tipoDocumento.codigo, obj.sexo.codigo);
                return res == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool clienteupdate(ClienteBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_ActualizarCliente(obj.codigo, obj.nombre, obj.apepaterno, obj.apematerno,
                        obj.documento, obj.fecha, obj.nacionalidad, obj.direccion, obj.telefono, obj.celular, obj.correo,
                        obj.estado, obj.distrito.codigo, obj.tipoDocumento.codigo, obj.sexo.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool clientedelete(ClienteBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_EliminarCliente(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool clienteenable(ClienteBO obj)
        {
            try
            {
                if (obj.codigo != 0)
                {
                    int res = contexto.SP_HabilitarCliente(obj.codigo);
                    return res == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int clientesetCode()
        {
            try
            {
                return Convert.ToInt32(contexto.SP_CodigoCliente());
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------
    }
}
