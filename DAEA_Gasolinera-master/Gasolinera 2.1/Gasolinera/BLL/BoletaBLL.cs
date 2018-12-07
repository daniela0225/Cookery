using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class BoletaBLL
    {
        BoletaDAL bol = new BoletaDAL();

        public List<CBoleta> ListarBLL()
        {
            return bol.Listar();
        }

        public CBoleta GetBLL(int codigo)
        {
            return bol.Get(codigo);
        }

        public int AgregarBLL(int venta,
                                String dni,
                                float total)
        {
            CBoleta nuevo = new CBoleta
            {
                venta = venta,
                dni = dni,
                total = total
            };

            return bol.Agregar(nuevo);
        }

        public int EditarBLL(int codigo,
                                int venta,
                                String dni,
                                float total)
        {
            CBoleta editado = new CBoleta
            {
                codigo = codigo,
                venta = venta,
                dni = dni,
                total = total
            };

            return bol.Editar(editado);
        }

        public int EliminarBLL(int codigo)
        {
            return bol.Eliminar(codigo);
        }
    }
}
