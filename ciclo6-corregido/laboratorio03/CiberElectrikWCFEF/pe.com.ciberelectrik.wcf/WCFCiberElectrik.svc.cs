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
                return contexto.categoria.Select(
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
                return contexto.categoria.Where(c=>c.estcat).Select(
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
                return contexto.categoria.Where(c => c.codcat==obj.codigo).Select(
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
                categoria cat = new categoria
                {
                    nomcat = obj.nombre,
                    estcat=obj.estado
                };
                contexto.categoria.Add(cat);
                return contexto.SaveChanges()==1;
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
                //buscar el valor para actualizar
                var cat = contexto.categoria.Find(obj.codigo);
                //evaluas que no sea nulo
                if (cat != null)
                {
                    cat.nomcat = obj.nombre;
                    cat.estcat = obj.estado;
                    return contexto.SaveChanges()==1;
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
                var cat = contexto.categoria.Find(obj.codigo);
                if (cat != null)
                {
                    cat.estcat = false;
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

        public bool categoriaenable(CategoriaBO obj)
        {
            try
            {
                var cat = contexto.categoria.Find(obj.codigo);
                if (cat != null)
                {
                    cat.estcat = true;
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

        public int categoriasetCode()
        {
            try
            {
                int siguiente = contexto.categoria.Any() ? contexto.categoria
                    .Max(c => c.codcat + 1) : 1;
                return siguiente;
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
                return contexto.producto.Select(
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
                            nombre=p.marca.nommar
                        },
                        categoria=new CategoriaBO
                        {
                            codigo=p.codcat,
                            nombre=p.categoria.nomcat
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
                return contexto.producto.Where(p=>p.estpro).Select(
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
                            nombre = p.marca.nommar
                        },
                        categoria = new CategoriaBO
                        {
                            codigo = p.codcat,
                            nombre = p.categoria.nomcat
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
                return contexto.producto.Where(p => p.codpro==obj.codigo).Select(
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
                            nombre = p.marca.nommar
                        },
                        categoria = new CategoriaBO
                        {
                            codigo = p.codcat,
                            nombre = p.categoria.nomcat
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
                producto pro = new producto
                {
                    nompro = obj.nombre,
                    despro = obj.descripcion,
                    fecing = obj.fechaingreso,
                    prepro = obj.precio,
                    canpro = obj.cantidad,
                    codmar = obj.marca.codigo,
                    codcat = obj.categoria.codigo,
                    estpro = obj.estado
                };
                contexto.producto.Add(pro);
                return contexto.SaveChanges() == 1;
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
                var pro = contexto.producto.Find(obj.codigo);
                if (pro != null)
                {
                    pro.nompro = obj.nombre;
                    pro.despro = obj.descripcion;
                    pro.fecing = obj.fechaingreso;
                    pro.prepro = obj.precio;
                    pro.canpro = obj.cantidad;
                    pro.codmar = obj.marca.codigo;
                    pro.codcat = obj.categoria.codigo;
                    pro.estpro = obj.estado;
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

        public bool productodelete(ProductoBO obj)
        {
            try
            {
                var pro = contexto.producto.Find(obj.codigo);
                if (pro != null)
                {
                    pro.estpro = false;
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

        public bool productoenable(ProductoBO obj)
        {
            try
            {
                var pro = contexto.producto.Find(obj.codigo);
                if (pro != null)
                {
                    pro.estpro = true;
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

        public int productosetCode()
        {
            try
            {
                int siguiente = contexto.producto.Any() ? contexto.producto
                    .Max(p => p.codpro + 1) : 1;
                return siguiente;
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
                return contexto.distrito.Select(
                    d => new DistritoBO { codigo = d.coddis, nombre = d.nomdis, estado = d.estdis }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<DistritoBO> distritofindAllCustom()
        {
            try
            {
                return contexto.distrito.Where(d => d.estdis).Select(
                    d => new DistritoBO { codigo = d.coddis, nombre = d.nomdis, estado = d.estdis }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public DistritoBO distritofindById(DistritoBO obj)
        {
            try
            {
                return contexto.distrito.Where(d => d.coddis == obj.codigo).Select(
                    d => new DistritoBO { codigo = d.coddis, nombre = d.nomdis, estado = d.estdis }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool distritoadd(DistritoBO obj)
        {
            try
            {
                distrito dis = new distrito { nomdis = obj.nombre, estdis = obj.estado };
                contexto.distrito.Add(dis);
                return contexto.SaveChanges() == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool distritoupdate(DistritoBO obj)
        {
            try
            {
                var dis = contexto.distrito.Find(obj.codigo);
                if (dis != null)
                {
                    dis.nomdis = obj.nombre;
                    dis.estdis = obj.estado;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool distritodelete(DistritoBO obj)
        {
            try
            {
                var dis = contexto.distrito.Find(obj.codigo);
                if (dis != null) { dis.estdis = false; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool distritoenable(DistritoBO obj)
        {
            try
            {
                var dis = contexto.distrito.Find(obj.codigo);
                if (dis != null) { dis.estdis = true; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int distritosetCode()
        {
            try
            {
                return contexto.distrito.Any() ? contexto.distrito.Max(d => d.coddis + 1) : 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- Rol ---------------------------------------------------
        public List<RolBO> rolfindAll()
        {
            try
            {
                return contexto.rol.Select(
                    r => new RolBO { codigo = r.codrol, nombre = r.nomrol, estado = r.estrol }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<RolBO> rolfindAllCustom()
        {
            try
            {
                return contexto.rol.Where(r => r.estrol).Select(
                    r => new RolBO { codigo = r.codrol, nombre = r.nomrol, estado = r.estrol }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public RolBO rolfindById(RolBO obj)
        {
            try
            {
                return contexto.rol.Where(r => r.codrol == obj.codigo).Select(
                    r => new RolBO { codigo = r.codrol, nombre = r.nomrol, estado = r.estrol }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool roladd(RolBO obj)
        {
            try
            {
                rol rl = new rol { nomrol = obj.nombre, estrol = obj.estado };
                contexto.rol.Add(rl);
                return contexto.SaveChanges() == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool rolupdate(RolBO obj)
        {
            try
            {
                var rl = contexto.rol.Find(obj.codigo);
                if (rl != null)
                {
                    rl.nomrol = obj.nombre;
                    rl.estrol = obj.estado;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool roldelete(RolBO obj)
        {
            try
            {
                var rl = contexto.rol.Find(obj.codigo);
                if (rl != null) { rl.estrol = false; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool rolenable(RolBO obj)
        {
            try
            {
                var rl = contexto.rol.Find(obj.codigo);
                if (rl != null) { rl.estrol = true; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int rolsetCode()
        {
            try
            {
                return contexto.rol.Any() ? contexto.rol.Max(r => r.codrol + 1) : 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- TipoDocumento ---------------------------------------------------
        public List<TipoDocumentoBO> tipodocumentofindAll()
        {
            try
            {
                return contexto.tipodocumento.Select(
                    t => new TipoDocumentoBO { codigo = t.codtipd, nombre = t.nomtipd, estado = t.esttipd }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<TipoDocumentoBO> tipodocumentofindAllCustom()
        {
            try
            {
                return contexto.tipodocumento.Where(t => t.esttipd).Select(
                    t => new TipoDocumentoBO { codigo = t.codtipd, nombre = t.nomtipd, estado = t.esttipd }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public TipoDocumentoBO tipodocumentofindById(TipoDocumentoBO obj)
        {
            try
            {
                return contexto.tipodocumento.Where(t => t.codtipd == obj.codigo).Select(
                    t => new TipoDocumentoBO { codigo = t.codtipd, nombre = t.nomtipd, estado = t.esttipd }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool tipodocumentoadd(TipoDocumentoBO obj)
        {
            try
            {
                tipodocumento td = new tipodocumento { nomtipd = obj.nombre, esttipd = obj.estado };
                contexto.tipodocumento.Add(td);
                return contexto.SaveChanges() == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool tipodocumentoupdate(TipoDocumentoBO obj)
        {
            try
            {
                var td = contexto.tipodocumento.Find(obj.codigo);
                if (td != null)
                {
                    td.nomtipd = obj.nombre;
                    td.esttipd = obj.estado;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool tipodocumentodelete(TipoDocumentoBO obj)
        {
            try
            {
                var td = contexto.tipodocumento.Find(obj.codigo);
                if (td != null) { td.esttipd = false; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool tipodocumentoenable(TipoDocumentoBO obj)
        {
            try
            {
                var td = contexto.tipodocumento.Find(obj.codigo);
                if (td != null) { td.esttipd = true; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int tipodocumentosetCode()
        {
            try
            {
                return contexto.tipodocumento.Any() ? contexto.tipodocumento.Max(t => t.codtipd + 1) : 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- Sexo ---------------------------------------------------
        public List<SexoBO> sexofindAll()
        {
            try
            {
                return contexto.sexo.Select(
                    s => new SexoBO { codigo = s.codsex, nombre = s.nomsex, estado = s.estsex }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<SexoBO> sexofindAllCustom()
        {
            try
            {
                return contexto.sexo.Where(s => s.estsex).Select(
                    s => new SexoBO { codigo = s.codsex, nombre = s.nomsex, estado = s.estsex }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public SexoBO sexofindById(SexoBO obj)
        {
            try
            {
                return contexto.sexo.Where(s => s.codsex == obj.codigo).Select(
                    s => new SexoBO { codigo = s.codsex, nombre = s.nomsex, estado = s.estsex }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool sexoadd(SexoBO obj)
        {
            try
            {
                sexo sx = new sexo { nomsex = obj.nombre, estsex = obj.estado };
                contexto.sexo.Add(sx);
                return contexto.SaveChanges() == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool sexoupdate(SexoBO obj)
        {
            try
            {
                var sx = contexto.sexo.Find(obj.codigo);
                if (sx != null)
                {
                    sx.nomsex = obj.nombre;
                    sx.estsex = obj.estado;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool sexodelete(SexoBO obj)
        {
            try
            {
                var sx = contexto.sexo.Find(obj.codigo);
                if (sx != null) { sx.estsex = false; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool sexoenable(SexoBO obj)
        {
            try
            {
                var sx = contexto.sexo.Find(obj.codigo);
                if (sx != null) { sx.estsex = true; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int sexosetCode()
        {
            try
            {
                return contexto.sexo.Any() ? contexto.sexo.Max(s => s.codsex + 1) : 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- EstadoCivil ---------------------------------------------------
        public List<EstadoCivilBO> estadocivilfindAll()
        {
            try
            {
                return contexto.estadocivil.Select(
                    ec => new EstadoCivilBO { codigo = ec.codestc, nombre = ec.nomestc, estado = ec.estestc }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<EstadoCivilBO> estadocivilfindAllCustom()
        {
            try
            {
                return contexto.estadocivil.Where(ec => ec.estestc).Select(
                    ec => new EstadoCivilBO { codigo = ec.codestc, nombre = ec.nomestc, estado = ec.estestc }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public EstadoCivilBO estadocivilfindById(EstadoCivilBO obj)
        {
            try
            {
                return contexto.estadocivil.Where(ec => ec.codestc == obj.codigo).Select(
                    ec => new EstadoCivilBO { codigo = ec.codestc, nombre = ec.nomestc, estado = ec.estestc }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool estadociviladd(EstadoCivilBO obj)
        {
            try
            {
                estadocivil ec = new estadocivil { nomestc = obj.nombre, estestc = obj.estado };
                contexto.estadocivil.Add(ec);
                return contexto.SaveChanges() == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool estadocivilupdate(EstadoCivilBO obj)
        {
            try
            {
                var ec = contexto.estadocivil.Find(obj.codigo);
                if (ec != null)
                {
                    ec.nomestc = obj.nombre;
                    ec.estestc = obj.estado;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool estadocivildelete(EstadoCivilBO obj)
        {
            try
            {
                var ec = contexto.estadocivil.Find(obj.codigo);
                if (ec != null) { ec.estestc = false; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool estadocivilenable(EstadoCivilBO obj)
        {
            try
            {
                var ec = contexto.estadocivil.Find(obj.codigo);
                if (ec != null) { ec.estestc = true; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int estadocivilsetCode()
        {
            try
            {
                return contexto.estadocivil.Any() ? contexto.estadocivil.Max(ec => ec.codestc + 1) : 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- Empleado ---------------------------------------------------
        public List<EmpleadoBO> empleadofindAll()
        {
            try
            {
                return contexto.empleado.Select(
                    e => new EmpleadoBO
                    {
                        codigo = e.codemp,
                        nombre = e.nomemp,
                        apepaterno = e.apepemp,
                        apematerno = e.apememp,
                        documento = e.docemp,
                        direccion = e.diremp,
                        fecha = e.fecemp,
                        nacionalidad = e.nacemp,
                        telefono = e.telemp,
                        celular = e.celemp,
                        correo = e.coremp,
                        usuario = e.usuemp,
                        clave = e.claemp,
                        estado = e.estemp,
                        distrito = new DistritoBO { codigo = e.coddis, nombre = e.distrito.nomdis },
                        rol = new RolBO { codigo = e.codrol, nombre = e.rol.nomrol },
                        tipoDocumento = new TipoDocumentoBO { codigo = e.codtipd, nombre = e.tipodocumento.nomtipd },
                        sexo = new SexoBO { codigo = e.codsex, nombre = e.sexo.nomsex },
                        estadoCivil = new EstadoCivilBO { codigo = e.codestc, nombre = e.estadocivil.nomestc }
                    }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<EmpleadoBO> empleadofindAllCustom()
        {
            try
            {
                return contexto.empleado.Where(e => e.estemp).Select(
                    e => new EmpleadoBO
                    {
                        codigo = e.codemp,
                        nombre = e.nomemp,
                        apepaterno = e.apepemp,
                        apematerno = e.apememp,
                        documento = e.docemp,
                        direccion = e.diremp,
                        fecha = e.fecemp,
                        nacionalidad = e.nacemp,
                        telefono = e.telemp,
                        celular = e.celemp,
                        correo = e.coremp,
                        usuario = e.usuemp,
                        clave = e.claemp,
                        estado = e.estemp,
                        distrito = new DistritoBO { codigo = e.coddis, nombre = e.distrito.nomdis },
                        rol = new RolBO { codigo = e.codrol, nombre = e.rol.nomrol },
                        tipoDocumento = new TipoDocumentoBO { codigo = e.codtipd, nombre = e.tipodocumento.nomtipd },
                        sexo = new SexoBO { codigo = e.codsex, nombre = e.sexo.nomsex },
                        estadoCivil = new EstadoCivilBO { codigo = e.codestc, nombre = e.estadocivil.nomestc }
                    }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public EmpleadoBO empleadofindById(EmpleadoBO obj)
        {
            try
            {
                return contexto.empleado.Where(e => e.codemp == obj.codigo).Select(
                    e => new EmpleadoBO
                    {
                        codigo = e.codemp,
                        nombre = e.nomemp,
                        apepaterno = e.apepemp,
                        apematerno = e.apememp,
                        documento = e.docemp,
                        direccion = e.diremp,
                        fecha = e.fecemp,
                        nacionalidad = e.nacemp,
                        telefono = e.telemp,
                        celular = e.celemp,
                        correo = e.coremp,
                        usuario = e.usuemp,
                        clave = e.claemp,
                        estado = e.estemp,
                        distrito = new DistritoBO { codigo = e.coddis, nombre = e.distrito.nomdis },
                        rol = new RolBO { codigo = e.codrol, nombre = e.rol.nomrol },
                        tipoDocumento = new TipoDocumentoBO { codigo = e.codtipd, nombre = e.tipodocumento.nomtipd },
                        sexo = new SexoBO { codigo = e.codsex, nombre = e.sexo.nomsex },
                        estadoCivil = new EstadoCivilBO { codigo = e.codestc, nombre = e.estadocivil.nomestc }
                    }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool empleadoadd(EmpleadoBO obj)
        {
            try
            {
                empleado emp = new empleado
                {
                    nomemp = obj.nombre,
                    apepemp = obj.apepaterno,
                    apememp = obj.apematerno,
                    docemp = obj.documento,
                    diremp = obj.direccion,
                    fecemp = obj.fecha,
                    nacemp = obj.nacionalidad,
                    telemp = obj.telefono,
                    celemp = obj.celular,
                    coremp = obj.correo,
                    usuemp = obj.usuario,
                    claemp = obj.clave,
                    estemp = obj.estado,
                    coddis = obj.distrito.codigo,
                    codrol = obj.rol.codigo,
                    codtipd = obj.tipoDocumento.codigo,
                    codsex = obj.sexo.codigo,
                    codestc = obj.estadoCivil.codigo
                };
                contexto.empleado.Add(emp);
                return contexto.SaveChanges() == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool empleadoupdate(EmpleadoBO obj)
        {
            try
            {
                var emp = contexto.empleado.Find(obj.codigo);
                if (emp != null)
                {
                    emp.nomemp = obj.nombre;
                    emp.apepemp = obj.apepaterno;
                    emp.apememp = obj.apematerno;
                    emp.docemp = obj.documento;
                    emp.diremp = obj.direccion;
                    emp.fecemp = obj.fecha;
                    emp.nacemp = obj.nacionalidad;
                    emp.telemp = obj.telefono;
                    emp.celemp = obj.celular;
                    emp.coremp = obj.correo;
                    emp.usuemp = obj.usuario;
                    emp.claemp = obj.clave;
                    emp.estemp = obj.estado;
                    emp.coddis = obj.distrito.codigo;
                    emp.codrol = obj.rol.codigo;
                    emp.codtipd = obj.tipoDocumento.codigo;
                    emp.codsex = obj.sexo.codigo;
                    emp.codestc = obj.estadoCivil.codigo;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool empleadodelete(EmpleadoBO obj)
        {
            try
            {
                var emp = contexto.empleado.Find(obj.codigo);
                if (emp != null) { emp.estemp = false; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool empleadoenable(EmpleadoBO obj)
        {
            try
            {
                var emp = contexto.empleado.Find(obj.codigo);
                if (emp != null) { emp.estemp = true; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int empleadosetCode()
        {
            try
            {
                return contexto.empleado.Any() ? contexto.empleado.Max(e => e.codemp + 1) : 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------

        //------------------- Cliente ---------------------------------------------------
        public List<ClienteBO> clientefindAll()
        {
            try
            {
                return contexto.cliente.Select(
                    c => new ClienteBO
                    {
                        codigo = c.codcli,
                        nombre = c.nomcli,
                        apepaterno = c.apepcli,
                        apematerno = c.apemcli,
                        documento = c.doccli,
                        fecha = c.feccli,
                        nacionalidad = c.naccli,
                        direccion = c.dircli,
                        telefono = c.telcli,
                        celular = c.celcli,
                        correo = c.corcli,
                        estado = c.estcli,
                        distrito = new DistritoBO { codigo = c.coddis, nombre = c.distrito.nomdis },
                        tipoDocumento = new TipoDocumentoBO { codigo = c.codtipd, nombre = c.tipodocumento.nomtipd },
                        sexo = new SexoBO { codigo = c.codsex, nombre = c.sexo.nomsex }
                    }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public List<ClienteBO> clientefindAllCustom()
        {
            try
            {
                return contexto.cliente.Where(c => c.estcli).Select(
                    c => new ClienteBO
                    {
                        codigo = c.codcli,
                        nombre = c.nomcli,
                        apepaterno = c.apepcli,
                        apematerno = c.apemcli,
                        documento = c.doccli,
                        fecha = c.feccli,
                        nacionalidad = c.naccli,
                        direccion = c.dircli,
                        telefono = c.telcli,
                        celular = c.celcli,
                        correo = c.corcli,
                        estado = c.estcli,
                        distrito = new DistritoBO { codigo = c.coddis, nombre = c.distrito.nomdis },
                        tipoDocumento = new TipoDocumentoBO { codigo = c.codtipd, nombre = c.tipodocumento.nomtipd },
                        sexo = new SexoBO { codigo = c.codsex, nombre = c.sexo.nomsex }
                    }
                    ).ToList();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public ClienteBO clientefindById(ClienteBO obj)
        {
            try
            {
                return contexto.cliente.Where(c => c.codcli == obj.codigo).Select(
                    c => new ClienteBO
                    {
                        codigo = c.codcli,
                        nombre = c.nomcli,
                        apepaterno = c.apepcli,
                        apematerno = c.apemcli,
                        documento = c.doccli,
                        fecha = c.feccli,
                        nacionalidad = c.naccli,
                        direccion = c.dircli,
                        telefono = c.telcli,
                        celular = c.celcli,
                        correo = c.corcli,
                        estado = c.estcli,
                        distrito = new DistritoBO { codigo = c.coddis, nombre = c.distrito.nomdis },
                        tipoDocumento = new TipoDocumentoBO { codigo = c.codtipd, nombre = c.tipodocumento.nomtipd },
                        sexo = new SexoBO { codigo = c.codsex, nombre = c.sexo.nomsex }
                    }
                    ).FirstOrDefault();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
        }

        public bool clienteadd(ClienteBO obj)
        {
            try
            {
                cliente cli = new cliente
                {
                    nomcli = obj.nombre,
                    apepcli = obj.apepaterno,
                    apemcli = obj.apematerno,
                    doccli = obj.documento,
                    feccli = obj.fecha,
                    naccli = obj.nacionalidad,
                    dircli = obj.direccion,
                    telcli = obj.telefono,
                    celcli = obj.celular,
                    corcli = obj.correo,
                    estcli = obj.estado,
                    coddis = obj.distrito.codigo,
                    codtipd = obj.tipoDocumento.codigo,
                    codsex = obj.sexo.codigo
                };
                contexto.cliente.Add(cli);
                return contexto.SaveChanges() == 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool clienteupdate(ClienteBO obj)
        {
            try
            {
                var cli = contexto.cliente.Find(obj.codigo);
                if (cli != null)
                {
                    cli.nomcli = obj.nombre;
                    cli.apepcli = obj.apepaterno;
                    cli.apemcli = obj.apematerno;
                    cli.doccli = obj.documento;
                    cli.feccli = obj.fecha;
                    cli.naccli = obj.nacionalidad;
                    cli.dircli = obj.direccion;
                    cli.telcli = obj.telefono;
                    cli.celcli = obj.celular;
                    cli.corcli = obj.correo;
                    cli.estcli = obj.estado;
                    cli.coddis = obj.distrito.codigo;
                    cli.codtipd = obj.tipoDocumento.codigo;
                    cli.codsex = obj.sexo.codigo;
                    return contexto.SaveChanges() == 1;
                }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool clientedelete(ClienteBO obj)
        {
            try
            {
                var cli = contexto.cliente.Find(obj.codigo);
                if (cli != null) { cli.estcli = false; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public bool clienteenable(ClienteBO obj)
        {
            try
            {
                var cli = contexto.cliente.Find(obj.codigo);
                if (cli != null) { cli.estcli = true; return contexto.SaveChanges() == 1; }
                return false;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return false; }
        }

        public int clientesetCode()
        {
            try
            {
                return contexto.cliente.Any() ? contexto.cliente.Max(c => c.codcli + 1) : 1;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); return 0; }
        }
        //---------------------------------------------------------------------------------
    }
}
