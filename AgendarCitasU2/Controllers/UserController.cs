using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Llamar a la carpeta model
using AgendarCitasU2.Models;
// Llamar a tableViewModelS
using AgendarCitasU2.Models.TableViewModels;
// Llamar a ViewModel
using AgendarCitasU2.Models.ViewModels;

namespace AgendarCitasU2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (CLINICAEntities db = new CLINICAEntities())
            {
                // Va a traer los datos de la BDD y va a llenar el objeto creado en el ViewModel
                lst = (from d in db.USUARIOS
                       // Busca a los usuarios que estén activos
                       //where d.ISACTIVE == true
                       // Los ordena por correo
                       orderby d.USERNAME
                       // Que sea de tipo UserTableViewModel
                       select new UserTableViewModel
                       {
                           ID = d.ID,
                           USERNAME = d.USERNAME,
                           ISADMIN = (bool)d.ISADMIN,
                           ISACTIVE = (bool)d.ISACTIVE
                       }).ToList();
            }
            // Se envia
            return View(lst);
        }

        // Funcion para la agregacion de datos esta retorna
        public ActionResult Nuevo()
        {
            return View();
        }

        // Aqui se implementan las respectivas acciones de Agregar
        [HttpPost]
        public ActionResult Nuevo(UserViewModel userModel)
        {

            try
            {
                //Validar la data Annottacions 
                if (ModelState.IsValid)
                {
                    //si todo es valido vamos a guardar los datos en la BDD 
                    using (CLINICAEntities db = new CLINICAEntities())
                    {
                        var oUser = new USUARIOS();
                        oUser.ID = userModel.ID;
                        oUser.USERNAME = userModel.USERNAME;
                        oUser.PASSWORD = userModel.PASSWORD;
                        oUser.ISADMIN = userModel.ISADMIN;
                        oUser.ISACTIVE = userModel.ISACTIVE;

                        db.USUARIOS.Add(oUser);
                        db.SaveChanges();
                    }
                    return Redirect("~/User/Index");
                }
                return View(userModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //PARA REALIZAR LA FUNCION DE EDITAR
        // funcion para la editar de datos esta retorna
        public ActionResult Editar(int id)
        {
            UserViewModel model = new UserViewModel();
            using (CLINICAEntities db = new CLINICAEntities())
            {
                var oUser = db.USUARIOS.Find(id);
                model.ID = oUser.ID;
                model.USERNAME = oUser.USERNAME;
                model.PASSWORD = oUser.PASSWORD;
                model.ISADMIN = (bool)oUser.ISADMIN;
                model.ISACTIVE = (bool)oUser.ISACTIVE;
            }
            return View(model);
        }

        // Aqui se implementan las respectivas acciones de editar
        [HttpPost]
        public ActionResult Editar(UserViewModel userModel)
        {
            try
            {
                //Validar la data Annottacions 
                if (ModelState.IsValid)
                {
                    //si todo es valido vamos a guardar los datos en la BDD 
                    using (CLINICAEntities db = new CLINICAEntities())
                    {
                        var oUser = new USUARIOS();
                        oUser.ID = userModel.ID;
                        oUser.USERNAME = userModel.USERNAME;
                        oUser.PASSWORD = userModel.PASSWORD;
                        oUser.ISADMIN = (bool)userModel.ISADMIN;
                        oUser.ISACTIVE = (bool)userModel.ISACTIVE;

                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/User/Index");
                }
                return View(userModel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //ACCION DE ELIMINAR LA ESPECIALIDAD es get
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (CLINICAEntities db = new CLINICAEntities())
            {
                var oUser = db.USUARIOS.Find(id);
                db.USUARIOS.Remove(oUser);
                db.SaveChanges();

            }
            return Redirect("~/User/");

        }

    } // fin de la clase 
}