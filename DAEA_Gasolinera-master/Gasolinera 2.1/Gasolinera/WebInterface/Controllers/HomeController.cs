using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebInterface.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public  ActionResult Index()
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