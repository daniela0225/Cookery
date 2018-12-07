using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class ProductoDAL
    {
        GasolineraEntities context = new GasolineraEntities();

        public List<CProducto> Listar()
        {
            using (context)
            {
                var query = context.Producto.Select(p => new CProducto
                {
                    codigo = p.codigo,
                    nombre = p.nombre,
                    precio = (float) p.precio.Value,
                    cantidad = (float) p.cantidad.Value,
                    medida = p.medida
                });
                return query.ToList();
            }
        }

        public List<CProducto> ListaModal()
        {
            using (context)
            {
                var query = context.Producto.Select(p => new CProducto
                {
                    codigo = p.codigo,
                    nombre = p.nombre,
                    precio = (float)p.precio.Value,
                    cantidad = (float)p.cantidad.Value,
                    medida = p.medida
                });
                return query.ToList();
            }
        }

        public CProducto Get(int codigo)
        {
            var query = context.Producto.Select(p => new CProducto
            {
                codigo = p.codigo,
                nombre = p.nombre,
                precio = (float)p.precio.Value,
                cantidad = (float)p.cantidad.Value,
                medida = p.medida
            }).Where(p => p.codigo == codigo);

            return query.First();
        }

        public int Agregar(CProducto pro)
        {
            context.insertProducto(
                    pro.nombre,
                    pro.precio,
                    pro.cantidad,
                    pro.medida
            );
            return context.SaveChanges();
        }

        public int Editar(CProducto pro)
        {
            context.updateProducto(
                pro.codigo,
                pro.nombre,
                pro.precio,
                pro.cantidad,
                pro.medida
            );
            return context.SaveChanges();
        }

        public int Eliminar(int codigo)
        {
            context.deleteProducto(codigo);
            return context.SaveChanges();
        }
    }
}
