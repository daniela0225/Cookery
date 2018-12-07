using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class FacturaBLL
    {
        FacturaDAL fac = new FacturaDAL();

        public List<CFactura> ListarBLL()
        {
            return fac.Listar();
        }

        public CFactura GetBLL(int codigo)
        {
            return fac.Get(codigo);
        }

        public int AgregarBLL(int venta,
                                String raz_soc,
                                String ruc,
                                float pretotal,
                                float igv,
                                float total)
        {
            CFactura nuevo = new CFactura
            {
                venta = venta,
                raz_soc = raz_soc,
                ruc = ruc,
                pretotal = pretotal,
                igv = igv,
                total = total
            };

            return fac.Agregar(nuevo);
        }

        public int EditarBLL(int codigo,
                                int venta,
                                String raz_soc,
                                String ruc,
                                float pretotal,
                                float igv,
                                float total)
        {
            CFactura editado = new CFactura
            {
                codigo = codigo,
                venta = venta,
                raz_soc = raz_soc,
                ruc = ruc,
                pretotal = pretotal,
                igv = igv,
                total = total
            };

            return fac.Editar(editado);
        }

        public int EliminarBLL(int codigo)
        {
            return fac.Eliminar(codigo);
        }

        public List<CFactura> ListarPorFechaBLL()
        {
            return fac.Listar();
        }

        public List<CFactura> ListarPorCliente()
        {
            return fac.Listar();
        }

        public List<CFactura> ListarPorUsuarioBLL()
        {
            return fac.Listar();
        }
    }
}
