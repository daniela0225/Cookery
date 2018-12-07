using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class ProductoBLL
    {
        ProductoDAL pro = new ProductoDAL();

        public List<CProducto> ListarBLL()
        {
            return pro.Listar();
        }

        public List<CProducto> ListaModalBLL()
        {
            return pro.ListaModal();
        }

        public CProducto GetBLL(int codigo)
        {
            return pro.Get(codigo);
        }

        public int AgregarBLL(String nombre,
                                float precio,
                                float cantidad,
                                String medida)
        {
            CProducto nuevo = new CProducto
            {
                nombre = nombre,
                precio = precio,
                cantidad = cantidad,
                medida = medida
            };

            return pro.Agregar(nuevo);
        }

        public int EditarBLL(int codigo,
                                String nombre,
                                float precio,
                                float cantidad,
                                String medida)
        {
            CProducto editado = new CProducto
            {
                codigo = codigo,
                nombre = nombre,
                precio = precio,
                cantidad = cantidad,
                medida = medida
            };

            return pro.Editar(editado);
        }

        public int EliminarBLL(int codigo)
        {
            return pro.Eliminar(codigo);
        }

        public List<CProducto> ListarCategoriaBLL(string cat)
        {
            return pro.Listar();
        }
    }
}
