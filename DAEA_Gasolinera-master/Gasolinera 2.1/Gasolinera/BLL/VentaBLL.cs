using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BLL
{
    public class VentaBLL
    {
        VentaDAL ven = new VentaDAL();
        /*
        UsuarioDAL usu = new UsuarioDAL();
        ProductoDAL pro = new ProductoDAL();
        ContribuyenteDAL con = new ContribuyenteDAL();
        ClienteDAL cli = new ClienteDAL();
        */

        public List<CVenta> ListarBLL()
        {
            /*return ven.Listar().Join(usu.Listar(), v => v.cliente, u => u.codigo,
                            (v, u) => new { Venta = v, Usuario = u })
                        .Join(pro.Listar(), v => v.Venta.producto, p => p.codigo,
                            (v, p) => new { Venta = v.Venta, Usuario = v.Usuario, Producto = p })
                        .Join(con.Listar(), v => v.Venta.contribuyente, c => c.codigo,
                            (v, c) => new { Ven = v.Venta, Usu = v.Usuario, Pro = v.Producto, Con = c })
                        .Join(cli.Listar(), v => v.Ven.cliente, c => c.codigo,
                            (v, c) => new { Ven = v.Ven, Usu = v.Usu, Pro = v.Pro, Con = v.Con, Cli = c })
                        .Select(v => new
                        {
                            codigo = v.Ven.codigo,
                            usuario = v.Usu,
                            producto = v.Pro,
                            cantidad = v.Ven.cantidad,
                            fecha = v.Ven.fecha,
                            contribuyente = v.Con,
                            cliente = v.Cli,
                            sede = v.Ven.sede,
                            placa = v.Ven.placa,
                            observacion = v.Ven.observacion
                        });
            */
            return ven.Listar();
        }

        public List<CVenta> ListaModalBLL()
        {
            return ven.ListaModal();
        }

        public CVenta GetBLL(int codigo)
        {
            return ven.Get(codigo);
        }

        public int AgregarBLL(int usuario,
                                int producto,
                                float cantidad,
                                DateTime fecha,
                                int contribuyente,
                                int cliente,
                                string sede,
                                string placa,
                                string observacion)
        {
            CVenta nuevo = new CVenta
            {
                usuario = usuario,
                producto = producto,
                cantidad = cantidad,
                fecha = fecha,
                contribuyente = contribuyente,
                cliente = cliente,
                sede = sede,
                placa = placa,
                observacion = observacion
            };

            return ven.Agregar(nuevo);
        }

        public int EditarBLL(int codigo,
                                int usuario,
                                int producto,
                                float cantidad,
                                DateTime fecha,
                                int contribuyente,
                                int cliente,
                                string sede,
                                string placa,
                                string observacion)
        {
            CVenta editado = new CVenta
            {
                codigo = codigo,
                usuario = usuario,
                producto = producto,
                cantidad = cantidad,
                fecha = fecha,
                contribuyente = contribuyente,
                cliente = cliente,
                sede = sede,
                placa = placa,
                observacion = observacion
            };

            return ven.Editar(editado);
        }

        public int EliminarBLL(int codigo)
        {
            return ven.Eliminar(codigo);
        }
    }
}
