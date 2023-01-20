using AgendarCitasU2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendarCitasU2.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string usuario, string passwd)
        {
            try
            {
                using (CLINICAEntities1 db = new CLINICAEntities1())
                {
                    //Hacer consulta a la base de datos
                    var lst = from d in db.USUARIOS
                              where d.USERNAME == usuario && d.PASSWORD == passwd && d.ISADMIN == true
                              select d;
                    if (lst.Count() > 0)
                    {
                        //Guardar datos de usuario en una variable de sesion
                        USUARIOS oUsuario = lst.First();
                        Session["User"] = oUsuario;
                        //Se retorna valor "1" que será evaluado en el script ajax de la vista 
                        return Content("1");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error: ( " + ex.Message + " )");
            }

            return Content("1");
        }

    }
}