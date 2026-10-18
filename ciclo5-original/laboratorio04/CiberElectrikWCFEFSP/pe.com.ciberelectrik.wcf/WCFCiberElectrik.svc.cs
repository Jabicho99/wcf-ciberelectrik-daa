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
    }
}
