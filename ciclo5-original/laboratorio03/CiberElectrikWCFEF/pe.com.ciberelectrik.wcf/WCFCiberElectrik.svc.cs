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
        bdciberelectrikapi20261Entities contexto=new bdciberelectrikapi20261Entities();
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
    }
}
