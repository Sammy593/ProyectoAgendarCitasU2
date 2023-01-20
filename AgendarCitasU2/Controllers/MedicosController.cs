using AgendarCitasU2.Models;
using AgendarCitasU2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendarCitasU2.Controllers
{
    public class MedicosController : Controller
    {
        // GET: Medicos
        public ActionResult Index()
        {
            List<ListMedicosViewModel> lst;
            using(CLINICAEntities db = new CLINICAEntities())
            {
                lst = (from d in db.MEDICOS
                       select new ListMedicosViewModel
                       {
                           ID = d.ID,
                           NOMBRES = d.NOMBRES,
                           APELLIDOS = d.APELLIDOS,
                           DNI = d.DNI,
                           CORREO= d.CORREO,
                           USERNAME = d.USERNAME
                       }).ToList();
                 
            }


            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Nuevo(MedicosViewModel medicosViewModel)
        {

            try
            {
                //Validar los data annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido, se guardan los datos en la base
                    using (CLINICAEntities db = new CLINICAEntities())
                    {
                        var oMedico = new MEDICOS();
                        oMedico.NOMBRES = medicosViewModel.NOMBRES;
                        oMedico.APELLIDOS = medicosViewModel.APELLIDOS;
                        oMedico.DNI = medicosViewModel.DNI;
                        oMedico.DIRECCION = medicosViewModel.DIRECCION;
                        oMedico.CORREO = medicosViewModel.CORREO;
                        oMedico.TELEFONO = medicosViewModel.TELEFONO;
                        oMedico.SEXO = medicosViewModel.SEXO;
                        oMedico.NUMCOLEGIATURA = medicosViewModel.NUMCOLEGIATURA;
                        oMedico.FECHANACIMIENTO= (DateTime)medicosViewModel.FECHANACIMIENTO;
                        oMedico.USERNAME= medicosViewModel.USERNAME;
                        oMedico.PASSWORD = medicosViewModel.PASSWORD;
                        oMedico.ACTIVO = medicosViewModel.ACTIVO;

                        db.MEDICOS.Add(oMedico);
                        db.SaveChanges();

                    }

                    return Redirect("~/Medicos/Index");


                }
                return View(medicosViewModel);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }


        public ActionResult Editar(int id)
        {
            MedicosViewModel model = new MedicosViewModel();
            using(CLINICAEntities db = new CLINICAEntities())
            {
                var oMedico = db.MEDICOS.Find(id);
                model.NOMBRES = oMedico.NOMBRES;
                model.APELLIDOS = oMedico.APELLIDOS;
                model.DNI = oMedico.DNI;
                model.DIRECCION = oMedico.DIRECCION;
                model.CORREO = oMedico.CORREO;
                model.TELEFONO = oMedico.TELEFONO;
                model.SEXO = oMedico.SEXO;
                model.NUMCOLEGIATURA = oMedico.NUMCOLEGIATURA;
                model.FECHANACIMIENTO = (DateTime)oMedico.FECHANACIMIENTO;
                model.USERNAME = oMedico.USERNAME;
                model.PASSWORD = oMedico.PASSWORD;
                model.ACTIVO = oMedico.ACTIVO;
                model.ID = oMedico.ID;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(MedicosViewModel medicosViewModel)
        {

            try
            {
                //Validar los data annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido, se guardan los datos en la base
                    using (CLINICAEntities db = new CLINICAEntities())
                    {
                        var oMedico = new MEDICOS();
                        oMedico.ID = medicosViewModel.ID;
                        oMedico.NOMBRES = medicosViewModel.NOMBRES;
                        oMedico.APELLIDOS = medicosViewModel.APELLIDOS;
                        oMedico.DNI = medicosViewModel.DNI;
                        oMedico.DIRECCION = medicosViewModel.DIRECCION;
                        oMedico.CORREO = medicosViewModel.CORREO;
                        oMedico.TELEFONO = medicosViewModel.TELEFONO;
                        oMedico.SEXO = medicosViewModel.SEXO;
                        oMedico.NUMCOLEGIATURA = medicosViewModel.NUMCOLEGIATURA;
                        oMedico.FECHANACIMIENTO = medicosViewModel.FECHANACIMIENTO;
                        oMedico.USERNAME = medicosViewModel.USERNAME;
                        oMedico.PASSWORD = medicosViewModel.PASSWORD;
                        oMedico.ACTIVO = medicosViewModel.ACTIVO;

                        db.Entry(oMedico).State = System.Data.Entity.EntityState.Modified; 
                        db.SaveChanges();

                    }

                    return Redirect("~/Medicos/Index");


                }
                return View(medicosViewModel);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (CLINICAEntities db = new CLINICAEntities())
            {
                var oMedico = db.MEDICOS.Find(id);
                db.MEDICOS.Remove(oMedico);
                db.SaveChanges();
            }

            return Redirect("~/Medicos/Index");

        }



    }
}