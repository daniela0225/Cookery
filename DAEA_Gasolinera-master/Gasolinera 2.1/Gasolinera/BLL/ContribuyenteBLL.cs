using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class ContribuyenteBLL
    {
        ContribuyenteDAL con = new ContribuyenteDAL();

        public List<CContribuyente> ListarBLL()
        {
            return con.Listar();
        }

        public List<CContribuyente> ListaModalBLL()
        {
            return con.ListaModal();
        }

        public CContribuyente GetBLL(int codigo)
        {
            return con.Get(codigo);
        }

        public int AgregarBLL(String empresa,
                                String ruc,
                                String departamento,
                                String provincia,
                                String distrito,
                                String direccion,
                                float igv,
                                String impresora)
        {
            CContribuyente nuevo = new CContribuyente
            {
                empresa = empresa,
                ruc = ruc,
                departamento = departamento,
                provincia = provincia,
                distrito = distrito,
                direccion = direccion,
                igv = igv,
                impresora = impresora
            };

            return con.Agregar(nuevo);
        }

        public int EditarBLL(int codigo,
                                String empresa,
                                String ruc,
                                String departamento,
                                String provincia,
                                String distrito,
                                String direccion,
                                float igv,
                                String impresora)
        {
            CContribuyente editado = new CContribuyente
            {
                codigo = codigo,
                empresa = empresa,
                ruc = ruc,
                departamento = departamento,
                provincia = provincia,
                distrito = distrito,
                direccion = direccion,
                igv = igv,
                impresora = impresora
            };

            return con.Editar(editado);
        }

        public int EliminarBLL(int codigo)
        {
            return con.Eliminar(codigo);
        }
    }
}
