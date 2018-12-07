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
    public class ClienteController : Controller
    {
        ClienteBLL BLLinstance = new ClienteBLL();

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

        public List<CCliente> GetListado()
        {
            List<CCliente> listado = BLLinstance.ListarBLL();

            return listado;
        }

        public ActionResult Listado()
        {
            if (Auth())
            {
                return (can("listar", "Cliente")) ?
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
                return (can("listar", "Cliente")) ?
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
                    CCliente cliente = BLLinstance.GetBLL(codigo);
                    return (can("listar", "Cliente")) ?
                        View(cliente) : Index();
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
                    CCliente cliente = BLLinstance.GetBLL(codigo);
                    return (can("listar", "Cliente")) ?
                        View(cliente) : IndexE();
                }
            }
            else
            {
                return View("../Usuario/LogInForm");
            }
        }

        [HttpPost]
        public ActionResult Crear(CCliente cliente)
        {

            if (can("crear", "Cliente"))
            {
                int success = BLLinstance.AgregarBLL(
                cliente.tipo_doc,
                cliente.documento,
                cliente.nom_ape,
                cliente.direccion);

                return View("Listado", GetListado());
            }
            else return Index();
        }

        [HttpPost]
        public ActionResult Editar(CCliente cliente)
        {
            if (can("editar", "Cliente"))
            {
                int success = BLLinstance.EditarBLL(
                cliente.codigo,
                cliente.tipo_doc,
                cliente.documento,
                cliente.nom_ape,
                cliente.direccion);

                return View("Listado", GetListado());
            }
            else return Index();
        }
        [HttpPost]
        public ActionResult CrearE(CCliente cliente)
        {

            if (can("crear", "Cliente"))
            {
                int success = BLLinstance.AgregarBLL(
                cliente.tipo_doc,
                cliente.documento,
                cliente.nom_ape,
                cliente.direccion);

                return View("ListadoE", GetListado());
            }
            else return IndexE();
        }

        [HttpPost]
        public ActionResult EditarE(CCliente cliente)
        {
            if (can("editar", "Cliente"))
            {
                int success = BLLinstance.EditarBLL(
                cliente.codigo,
                cliente.tipo_doc,
                cliente.documento,
                cliente.nom_ape,
                cliente.direccion);

                return View("ListadoE", GetListado());
            }
            else return IndexE();
        }

        public ActionResult Eliminar(int codigo)
        {
            if (can("eliminar", "Cliente"))
            {
                int success = BLLinstance.EliminarBLL(codigo);
                return View("Listado", GetListado());
            }
            else return Index();
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