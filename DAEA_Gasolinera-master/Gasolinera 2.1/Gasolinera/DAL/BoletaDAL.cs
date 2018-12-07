using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class BoletaDAL
    {
        GasolineraEntities context = new GasolineraEntities();

        public List<CBoleta> Listar()
        {
            using(context)
            {
                var query = context.Boleta.Select(b => new CBoleta {
                    codigo = b.codigo,
                    venta = b.venta.Value,
                    dni = b.dni,
                    total = (float) b.total.Value
                });
                return query.ToList();
            }
        }

        public CBoleta Get(int codigo)
        {
            var query = context.Boleta.Select(b => new CBoleta
            {
                codigo = b.codigo,
                venta = b.venta.Value,
                dni = b.dni,
                total = (float)b.total.Value
            }).Where(b => b.codigo == codigo);

            return query.First();
        }

        public int Agregar(CBoleta bol)
        {
            context.insertBoleta(
                bol.venta,
                bol.dni,
                bol.total
            );
            return context.SaveChanges();
        }

        public int Editar(CBoleta bol)
        {
            context.updateBoleta(
                bol.codigo, 
                bol.venta,
                bol.dni,
                bol.total);
                return context.SaveChanges();
        }

        public int Eliminar(int codigo)
        {
            context.deleteBoleta(codigo);
            return context.SaveChanges();
        }
    }
}
