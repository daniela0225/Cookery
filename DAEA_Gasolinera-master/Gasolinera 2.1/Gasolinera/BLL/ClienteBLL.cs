using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class ClienteBLL
    {
        ClienteDAL cli = new ClienteDAL();

        public List<CCliente> ListarBLL()
        {
            return cli.Listar();
        }

        public List<CCliente> ListaModalBLL()
        {
            return cli.ListaModal();
        }

        public CCliente GetBLL(int codigo)
        {
            return cli.Get(codigo);
        }

        public int AgregarBLL(String tipo_doc,
                                String documento,
                                String nom_ape,
                                String direccion)
        {
            CCliente nuevo = new CCliente
            {
                tipo_doc = tipo_doc,
                documento = documento,
                nom_ape = nom_ape,
                direccion = direccion
            };

            return cli.Agregar(nuevo);
        }

        public int EditarBLL(int codigo,
                                String tipo_doc,
                                String documento,
                                String nom_ape,
                                String direccion)
        {
            CCliente editado = new CCliente
            {
                codigo = codigo,
                tipo_doc = tipo_doc,
                documento = documento,
                nom_ape = nom_ape,
                direccion = direccion
            };

            return cli.Editar(editado);
        }

        public int EliminarBLL(int codigo)
        {
            return cli.Eliminar(codigo);
        }

        public List<CCliente> ListarVentasBLL(string cat)
        {

            return cli.Listar();
        }
    }
}
