using AgendarCitasU2.Controllers;
using AgendarCitasU2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendarCitasU2.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUsuario = (USUARIOS)HttpContext.Current.Session["User"];
            if (oUsuario != null)
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Dashboard/Index");
                }
            }
            else if (oUsuario == null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}