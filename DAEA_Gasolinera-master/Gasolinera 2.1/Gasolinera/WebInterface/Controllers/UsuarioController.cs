using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entities;
using DAL;
using BLL;
using System.Diagnostics;

namespace WebInterface.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioBLL BLLinstance = new UsuarioBLL();

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

        public List<CUsuario> GetListado()
        {
            List<CUsuario> listado = BLLinstance.ListarBLL();

            return listado;
        }
        
        
       

        public ActionResult Listado()
        {
            if (Auth())
            {
                return (can("listar", "Usuario")) ?
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
                    CUsuario usuario = BLLinstance.GetBLL(codigo);

                    return (can("listar", "Usuario")) ?
                        View(usuario) : Index();
                }
            }
            else
            {
                return View("../Usuario/LogInForm");
            }
        }

        [HttpPost]
        public ActionResult Crear(CUsuario usuario)
        {
            if (can("crear", "Usuario"))
            {
                int success = BLLinstance.AgregarBLL(
                usuario.dni,
                usuario.nom_ape,
                usuario.nickname,
                usuario.password,
                usuario.tipo);

                return View("Listado", GetListado());
            }
            else return Index();
            
        }

        [HttpPost]
        public ActionResult Editar(CUsuario usuario)
        {
            if (can("editar", "Usuario"))
            {
                int success = BLLinstance.EditarBLL(
                usuario.codigo,
                usuario.dni,
                usuario.nom_ape,
                usuario.nickname,
                usuario.password,
                usuario.tipo);

                return View("Listado", GetListado());
            }
            else return Index();
            
        }

        public ActionResult Eliminar(int codigo)
        {
            if (can("eliminar", "Usuario"))
            {
                int success = BLLinstance.EliminarBLL(codigo);
                return View("Listado", GetListado());
            }
            else return Index();
        }

        /* Session */

        public ActionResult LogInForm()
        {
            return View();
        }
        public ActionResult Admin()
        {
            if (Auth())
            {
                return View("../Home/Index");
            }
            else
            {
                return View("../Usuario/LogInForm");
            }
        }

        public String ErrorAuth()
        {
            String error = "Sus credenciales no son correctas, vuelva a intentarlo";

            return error;
        }

        [HttpPost]
        public ActionResult LogIn(String nickname, String password)
        {
            string success = BLLinstance.LogIn(nickname, password);

            Debug.WriteLine("Usuario: " + nickname);
            Debug.WriteLine("Clave: " + password);

            Debug.WriteLine("SUCCESS: " + success);
            if (success.Substring(0,1) == "2")
            {
                Session["dni"] = success.Substring(1);
                Session["tipo"] = "2";
                return View("../Home/Index");
            }
            if (success.Substring(0, 1) == "1")
            {
                Session["dni"] = success.Substring(1);
                Session["tipo"] = "1";
                return View("../Home/IndexE");
            }

            ViewBag.error = "Su credenciales son incorrectas, intentelo de nuevo";
            return View("LogInForm");
        }

        public bool can(String action, String table)
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
        public ActionResult LogOut()
        {
            Session["dni"] = null;
            return View("LogInForm");
        }
    }
}