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
    public class VentaController : Controller
    {

        VentaBLL BLLinstance = new VentaBLL();

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

        public List<CVenta> GetListado()
        {
            List<CVenta> listado = BLLinstance.ListarBLL();

            return listado;
        }

        public ActionResult Listado()
        {
            if (Auth())
            {
                return (can("listar", "Venta")) ?
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
                return (can("listar", "Venta")) ?
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
                    CVenta venta = new CVenta();
                    return View(venta);
                }
                else
                {
                    CVenta venta = BLLinstance.GetBLL(codigo);
                    return (can("listar", "Venta")) ?
                        View(venta) : Index();
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
                    CVenta venta = new CVenta();
                    return View(venta);
                }
                else
                {
                    CVenta venta = BLLinstance.GetBLL(codigo);
                    return (can("listar", "Venta")) ?
                        View(venta) : Index();
                }
            }
            else
            {
                return View("../Usuario/LogInForm");
            }
        }

        [HttpPost]
        public ActionResult Crear(CVenta venta)
        {
            if (can("crear", "Venta"))
            {
                try
                {
                    int success = BLLinstance.AgregarBLL(
                        venta.usuario,
                        venta.producto,
                        venta.cantidad,
                        //venta.fecha.Date,
                        DateTime.Now,
                        venta.contribuyente,
                        venta.cliente,
                        venta.sede,
                        venta.placa,
                        venta.observacion
                    );
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }

                return View("Listado", GetListado());
            }
            else return Index();
        }
        [HttpPost]
        public ActionResult CrearE(CVenta venta)
        {
            if (can("crear", "Venta"))
            {
                try
                {
                    int success = BLLinstance.AgregarBLL(
                        venta.usuario,
                        venta.producto,
                        venta.cantidad,
                        //venta.fecha.Date,
                        DateTime.Now,
                        venta.contribuyente,
                        venta.cliente,
                        venta.sede,
                        venta.placa,
                        venta.observacion
                    );
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }

                return View("ListadoE", GetListado());
            }
            else return IndexE();
        }

        [HttpPost]
        public ActionResult Editar(CVenta venta)
        {
            if (can("editar", "Venta"))
            {
                int success = BLLinstance.EditarBLL(
                venta.codigo,
                venta.usuario,
                venta.producto,
                venta.cantidad,
                venta.fecha,
                venta.contribuyente,
                venta.cliente,
                venta.sede,
                venta.placa,
                venta.observacion
                );

                return View("Listado", GetListado());
            }
            else return Index();
        }

        public ActionResult Eliminar(int codigo)
        {
            if (can("eliminar", "Venta"))
            {
                int success = BLLinstance.EliminarBLL(codigo);
                return View("Listado", GetListado());
            }
            else return Index();
        }

        public void UsuarioSeleccionado(int codigo)
        {

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