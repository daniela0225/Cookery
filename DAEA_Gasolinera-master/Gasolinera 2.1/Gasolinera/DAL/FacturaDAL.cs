using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class FacturaDAL
    {
        GasolineraEntities context = new GasolineraEntities();

        public List<CFactura> Listar()
        {
            using (context)
            {
                var query = context.Factura.Select(f => new CFactura
                {
                    codigo = f.codigo,
                    venta = f.venta.Value,
                    raz_soc = f.raz_soc,
                    ruc = f.ruc,
                    pretotal = (float) f.pretotal,
                    igv = (float) f.igv,
                    total = (float) f.total
                });
                return query.ToList();
            }
        }

        public CFactura Get(int codigo)
        {
            var query = context.Factura.Select(f => new CFactura
            {
                codigo = f.codigo,
                venta = f.venta.Value,
                raz_soc = f.raz_soc,
                ruc = f.ruc,
                pretotal = (float)f.pretotal,
                igv = (float)f.igv,
                total = (float)f.total
            }).Where(f => f.codigo == codigo);

            return query.First();
        }

        public int Agregar(CFactura fac)
        {
            context.insertFactura(
                fac.venta,
                fac.raz_soc,
                fac.ruc,
                fac.pretotal,
                fac.igv,
                fac.total
            );
            return context.SaveChanges();
        }

        public int Editar(CFactura fac)
        {
            context.updateFactura(
                fac.codigo,
                fac.venta,
                fac.raz_soc,
                fac.ruc,
                fac.pretotal,
                fac.igv,
                fac.total
            );
            return context.SaveChanges();
        }

        public int Eliminar(int codigo)
        {
            context.deleteFactura(codigo);
            return context.SaveChanges();
        }
    }
}
