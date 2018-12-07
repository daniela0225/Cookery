using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entities;
using DAL;
using BLL;


namespace WebInterface.Controllers
{
    public class ProductoController : Controller
    {

        ProductoBLL BLLinstance = new ProductoBLL();

        public ActionResult Index()
        {
            if (Auth())
            {
                return View();
            }
            else
            {
                return View("../Usuario/LogInForm");
            }
        }
        public ActionResult IndexE()
        {
            if (Auth())
            {
                return View();
            }
            else
            {
                return View("../Usuario/LogInForm");
            }
        }

        public List<CProducto> GetListado()
        {
            List<CProducto> listado = BLLinstance.ListarBLL();

            return listado;
        }

        public ActionResult Listado()
        {
            if (Auth())
            {
                return (can("listar", "Producto")) ?
                    View(GetListado()) : View("../Error/ErrorPerm");
            }
            else
            {
                return View("../Usuario/LogInForm");
            }
        }
        public ActionResult ListadoE()
        {
            if (Auth())
            {
                return (can("listar", "Producto")) ?
                    View(GetListado()) : View("../Error/ErrorPerm");
            }
            else
            {
                return View("../Usuario/LogInForm");
            }
        }

        public ActionResult Formulario(int codigo)
        {
            if (Auth())
            {
                if (codigo == 0)
                {
                    return View();
                }
                else
                {
                    CProducto producto = BLLinstance.GetBLL(codigo);
                    return (can("listar", "Producto")) ?
                        View(producto) : Index();
                }
            }
            else
            {
                return View("../Usuario/LogInForm");
            }
        }
        public ActionResult FormularioE(int codigo)
        {
            if (Auth())
            {
                if (codigo == 0)
                {
                    return View();
                }
                else
                {
                    CProducto producto = BLLinstance.GetBLL(codigo);
                    return (can("listar", "Producto")) ?
                        View(producto) : IndexE();
                }
            }
            else
            {
                return View("../Usuario/LogInForm");
            }
        }

        [HttpPost]
        public ActionResult Crear(CProducto producto)
        {
            if (can("crear", "Producto"))
            {
                int success = BLLinstance.AgregarBLL(
                producto.nombre,
                producto.precio,
                producto.cantidad,
                producto.medida);

                return View("Listado", GetListado());
            }
            else return Index();
        }

        [HttpPost]
        public ActionResult Editar(CProducto producto)
        {

            if (can("editar", "Producto"))
            {
                int success = BLLinstance.EditarBLL(
                producto.codigo,
                producto.nombre,
                producto.precio,
                producto.cantidad,
                producto.medida);

                return View("Listado", GetListado());
            }
            else return Index();
        }
        [HttpPost]
        public ActionResult CrearE(CProducto producto)
        {
            if (can("crear", "Producto"))
            {
                int success = BLLinstance.AgregarBLL(
                producto.nombre,
                producto.precio,
                producto.cantidad,
                producto.medida);

                return View("ListadoE", GetListado());
            }
            else return IndexE();
        }

        [HttpPost]
        public ActionResult EditarE(CProducto producto)
        {

            if (can("editar", "Producto"))
            {
                int success = BLLinstance.EditarBLL(
                producto.codigo,
                producto.nombre,
                producto.precio,
                producto.cantidad,
                producto.medida);

                return View("ListadoE", GetListado());
            }
            else return IndexE();
        }

        public ActionResult Eliminar(int codigo)
        {
            if (can("eliminar", "Producto"))
            {
                int success = BLLinstance.EliminarBLL(codigo);
                return View("Listado", GetListado());
            }
            else return View("Listado");
        }

        /* Session */

        public bool can(string action, string table)
        {
            return (AccessMiddleware.can(Session["dni"].ToString(), action, table));
        }
        public bool Auth()
        {
            if (Session["dni"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}