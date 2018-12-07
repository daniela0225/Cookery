using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class ClienteDAL
    {
        GasolineraEntities context = new GasolineraEntities();

        public List<CCliente> Listar()
        {
            using (context)
            {
                var query = context.Cliente.Select(c => new CCliente
                {
                    codigo = c.codigo,
                    tipo_doc = c.tipo_doc,
                    documento = c.documento,
                    nom_ape = c.nom_ape,
                    direccion = c.direccion
                });
                return query.ToList();
            }
        }

        public List<CCliente> ListaModal()
        {
            using (context)
            {
                var query = context.Cliente.Select(c => new CCliente
                {
                    codigo = c.codigo,
                    tipo_doc = c.tipo_doc,
                    documento = c.documento,
                    nom_ape = c.nom_ape
                });
                return query.ToList();
            }
        }

        public CCliente Get(int codigo)
        {
            var query = context.Cliente.Select(c => new CCliente
            {
                codigo = c.codigo,
                tipo_doc = c.tipo_doc,
                documento = c.documento,
                nom_ape = c.nom_ape,
                direccion = c.direccion
            }).Where(c => c.codigo == codigo);

            return query.First();
        }

        public int Agregar(CCliente cli)
        {
            context.insertCliente(
                cli.tipo_doc, 
                cli.documento,
                cli.nom_ape, 
                cli.direccion
            );
            return context.SaveChanges();
        }

        public int Editar(CCliente cli)
        {
            context.updateCliente(
                cli.codigo,
                cli.tipo_doc,
                cli.documento,
                cli.nom_ape,
                cli.direccion
            );
            return context.SaveChanges();
        }

        public int Eliminar(int codigo)
        {
            context.deleteCliente(codigo);
            return context.SaveChanges();
        }
    }
}
