using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class ContribuyenteDAL
    {
        GasolineraEntities context = new GasolineraEntities();

        public List<CContribuyente> Listar()
        {
            using (context)
            {
                var query = context.Contribuyente.Select(c => new CContribuyente
                {
                    codigo = c.codigo,
                    empresa = c.empresa,
                    ruc = c.ruc,
                    departamento = c.departamento,
                    provincia = c.provincia,
                    distrito = c.distrito,
                    direccion = c.direccion,
                    igv = (float) c.igv.Value,
                    impresora = c.impresora
                });
                return query.ToList();
            }
        }

        public List<CContribuyente> ListaModal()
        {
            using (context)
            {
                var query = context.Contribuyente.Select(c => new CContribuyente
                {
                    codigo = c.codigo,
                    empresa = c.empresa,
                    ruc = c.ruc
                });
                return query.ToList();
            }
        }

        public CContribuyente Get(int codigo)
        {
            var query = context.Contribuyente.Select(c => new CContribuyente
            {
                codigo = c.codigo,
                empresa = c.empresa,
                ruc = c.ruc,
                departamento = c.departamento,
                provincia = c.provincia,
                distrito = c.distrito,
                direccion = c.direccion,
                igv = (float)c.igv.Value,
                impresora = c.impresora
            }).Where(c => c.codigo == codigo);

            return query.First();
        }

        public int Agregar(CContribuyente con)
        {
            context.insertContribuyente(
                    con.empresa,
                    con.ruc,
                    con.departamento,
                    con.provincia,
                    con.distrito,
                    con.direccion,
                    con.igv,
                    con.impresora);
            return context.SaveChanges();
        }

        public int Editar(CContribuyente con)
        {
            context.updateContribuyente(
                con.codigo,
                con.empresa,
                con.ruc,
                con.departamento,
                con.provincia,
                con.distrito,
                con.direccion,
                con.igv,
                con.impresora
                );
            return context.SaveChanges();
        }

        public int Eliminar(int codigo)
        {
            context.deleteContribuyente(codigo);
            return context.SaveChanges();
        }
    }
}
