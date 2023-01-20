using AgendarCitasU2.Models;
using AgendarCitasU2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AgendarCitasU2.Controllers
{
    public class EspecialidadesController : Controller
    {
        // GET: Especialidades
        public ActionResult Index()
        {
            List<ListEspecialidadViewModel> lst;
            using (CLINICAEntities db = new CLINICAEntities())
            {
                lst = (from d in db.ESPECIALIDADES
                       select new ListEspecialidadViewModel
                       {
                           ID = d.ID,
                           NOMBRE = d.NOMBRE,
                           DESCRIPCION = d.DESCRIPCION,
                           FECHAREGISTRO = (DateTime)d.FECHAREGISTRO
                       }).ToList();


            }

            return View(lst); //retornamos la vista con la respectiva lista 
        }

        //CREACION DE LOS CONTROLADORES DEL CRUD

        // *******************************************************************************
        // CRUD DE NUEVO 
        // *******************************************************************************

        // funcion para la agregacion de datos esta retorna
        public ActionResult Nuevo()
        {
            return View();
        }

        // Aqui se implementan las respectivas acciones de Agregar
        [HttpPost]
        public ActionResult Nuevo(EspecialidadesViewModel especialidadModel)
        {

            try
            {
                //Validar la data Annottacions 
                if (ModelState.IsValid)
                {
                    //si todo es valido vamos a guardar los datos en la BDD 
                    using (CLINICAEntities db = new CLINICAEntities())
                    {
                        var oEspecialidad = new ESPECIALIDADES();
                        oEspecialidad.ID = especialidadModel.ID;
                        oEspecialidad.NOMBRE = especialidadModel.NOMBRE;
                        oEspecialidad.DESCRIPCION = especialidadModel.DESCRIPCION;
                        oEspecialidad.FECHAREGISTRO = especialidadModel.FECHAREGISTRO;
                        oEspecialidad.FECHAMODIFICACION = especialidadModel.FECHAMODIFICACION;
                        oEspecialidad.USUARIOREGISTRO = especialidadModel.USUARIOREGISTRO;
                        oEspecialidad.USUARIOMODIFICACION = especialidadModel.USUARIOMODIFICACION;
                        oEspecialidad.ACTIVO = especialidadModel.ACTIVO;

                        db.ESPECIALIDADES.Add(oEspecialidad);
                        db.SaveChanges();
                    }
                    return Redirect("~/Especialidades/Index");
                }
                return View(especialidadModel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //PARA REALIZAR LA FUNCION DE EDITAR/ACTUALIZAR
        // funcion para la editar de datos esta retorna
        public ActionResult Editar(int id)
        {
            EspecialidadesViewModel model = new EspecialidadesViewModel();
            using (CLINICAEntities db = new CLINICAEntities())
            {
                var oEspecialidad = db.ESPECIALIDADES.Find(id);
                model.NOMBRE = oEspecialidad.NOMBRE;
                model.DESCRIPCION = oEspecialidad.DESCRIPCION;
                model.FECHAREGISTRO = (DateTime)oEspecialidad.FECHAREGISTRO;
                model.FECHAMODIFICACION = (DateTime)oEspecialidad.FECHAMODIFICACION;
                model.USUARIOREGISTRO = oEspecialidad.USUARIOREGISTRO;
                model.USUARIOMODIFICACION = oEspecialidad.USUARIOMODIFICACION;
                model.ACTIVO = oEspecialidad.ACTIVO;
                model.ID = oEspecialidad.ID;
            }
            return View(model);
        }

        // Aqui se implementan las respectivas acciones de Agregar
        [HttpPost]
        public ActionResult Editar(EspecialidadesViewModel especialidadModel)
        {
            try
            {
                //Validar la data Annottacions 
                if (ModelState.IsValid)
                {
                    //si todo es valido vamos a guardar los datos en la BDD 
                    using (CLINICAEntities db = new CLINICAEntities())
                    {
                        var oEspecialidad = new ESPECIALIDADES();
                        oEspecialidad.ID = especialidadModel.ID;
                        oEspecialidad.NOMBRE = especialidadModel.NOMBRE;
                        oEspecialidad.DESCRIPCION = especialidadModel.DESCRIPCION;
                        oEspecialidad.FECHAREGISTRO = especialidadModel.FECHAREGISTRO;
                        oEspecialidad.FECHAMODIFICACION = especialidadModel.FECHAMODIFICACION;
                        oEspecialidad.USUARIOREGISTRO = especialidadModel.USUARIOREGISTRO;
                        oEspecialidad.USUARIOMODIFICACION = especialidadModel.USUARIOMODIFICACION;
                        oEspecialidad.ACTIVO = especialidadModel.ACTIVO;

                        db.Entry(oEspecialidad).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Especialidades/Index");
                }
                return View(especialidadModel);

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
                var oEspecialidad = db.ESPECIALIDADES.Find(id);
                db.ESPECIALIDADES.Remove(oEspecialidad);
                db.SaveChanges();

            }
            return Redirect("~/Especialidades/");

        }






    } // fin de la clase 
}