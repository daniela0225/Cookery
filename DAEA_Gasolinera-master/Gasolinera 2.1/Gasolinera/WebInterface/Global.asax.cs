using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebInterface
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
           AreaRegistration.RegisterAllAreas();
           RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            int error = httpException != null ? httpException.GetHttpCode() : 0;

            Server.ClearError();
            switch (error)
            {
                case 505:
                    Response.Redirect(String.Format("~/Error/ErrorComp"));
                    break;

                case 404:
                    Response.Redirect(String.Format("~/Error/NotFound"));
                    break;

                default:
                   Response.Redirect(String.Format("~/Error/Index"));
                    break;
            }
            
        }
    }
}