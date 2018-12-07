using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public class VentaDAL
    {
        GasolineraEntities context = new GasolineraEntities();

        public List<CVenta> Listar()
        {
            using (context)
            {
                var query = context.Venta.Select(v => new CVenta
                {
                    codigo = v.codigo,
                    usuario = v.usuario.Value,
                    producto = v.producto.Value,
                    cantidad = (float) v.cantidad.Value,
                    fecha = v.fecha.Value,
                    contribuyente = v.contribuyente.Value,
                    cliente = v.cliente.Value,
                    sede = v.sede,
                    placa = v.placa,
                    observacion = v.observacion
                });

                return query.ToList();
            }
        }

        public List<CVenta> ListaModal()
        {
            using (context)
            {
                var query = context.Venta.Select(v => new CVenta
                {
                    codigo = v.codigo,
                    producto = v.producto.Value,
                    cantidad = (float)v.cantidad.Value,
                    fecha = v.fecha.Value,
                    cliente = v.cliente.Value,
                    placa = v.placa
                });
                return query.ToList();
            }
        }

        public CVenta Get(int codigo)
        {
            var query = context.Venta.Select(v => new CVenta
            {
                codigo = v.codigo,
                usuario = v.usuario.Value,
                producto = v.producto.Value,
                cantidad = (float)v.cantidad.Value,
                fecha = v.fecha.Value,
                contribuyente = v.contribuyente.Value,
                cliente = v.cliente.Value,
                sede = v.sede,
                placa = v.placa,
                observacion = v.observacion
            }).Where(v => v.codigo == codigo);

            return query.First();
        }

        public int Agregar(CVenta ven)
        {
            context.insertVenta(
                ven.usuario,
                ven.producto,
                ven.cantidad,
                ven.fecha,
                ven.contribuyente,
                ven.cliente,
                ven.sede,
                ven.placa,
                ven.observacion
            );
            return context.SaveChanges();
        }

        public int Editar(CVenta ven)
        {
            context.updateVenta(
                ven.codigo,
                ven.usuario,
                ven.producto,
                ven.cantidad,
                ven.fecha,
                ven.contribuyente,
                ven.cliente,
                ven.sede,
                ven.placa,
                ven.observacion
            );
            return context.SaveChanges();
        }

        public int Eliminar(int codigo)
        {
            context.deleteVenta(codigo);
            return context.SaveChanges();
        }
    }
}
