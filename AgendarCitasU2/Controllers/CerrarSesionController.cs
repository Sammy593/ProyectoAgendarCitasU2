using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendarCitasU2.Controllers
{
    public class CerrarSesionController : Controller
    {
        // GET: CerrarSesion
        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Access");
        }
    }
}