using AgendarCitasU2.Models;
using AgendarCitasU2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendarCitasU2.Controllers
{
    public class PacientesController : Controller
    {
        // GET: Pacientes
        public ActionResult Index()
        {
            //Crear lista de tipo ListClienteViewModel
            List<PacientesViewModel> lst;
            //Realizamos consulta de lectura a la base de datos
            using (CLINICAEntities1 db = new CLINICAEntities1())
            {
                lst = (from d in db.PACIENTES where d.ACTIVO == true
                       select new PacientesViewModel
                       {
                           idPaciente = d.ID,
                           dniPaciente = d.DNI,
                           nombresPaciente = d.NOMBRES,
                           apellidosPaciente = d.APELLIDOS
                       }).ToList(); //Convertimos datos recibimos a formato de lista
            }
            return View(lst); //Retornamos la vista con la lista
        }

        public ActionResult verPaciente(int id)
        {
            PacienteFullViewModel model = new PacienteFullViewModel();
            using (CLINICAEntities1 db = new CLINICAEntities1())
            {
                var oPaciente = db.PACIENTES.Find(id);
                model.nombresP = oPaciente.NOMBRES;
                model.apellidosP = oPaciente.APELLIDOS;
                model.dniP = oPaciente.DNI;
                model.direccionP = oPaciente.DIRECCION;
                model.telefonoP = oPaciente.TELEFONO;
                model.sexoP = oPaciente.SEXO;
                model.fNacP = oPaciente.FECHANACIMIENTO;
                model.fRegP = (DateTime)oPaciente.FECHAREGISTRO;
                model.fModP = (DateTime)oPaciente.FECHAMODIFICACION;
                model.userRegP = oPaciente.USUARIOREGISTRO;
                model.userModP = oPaciente.USUARIOMODIFICACION;
                model.activoP = oPaciente.ACTIVO;
            }

            return View(model);
        }


        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PacienteFullViewModel pacienteModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new PACIENTES();
                    model.NOMBRES = pacienteModel.nombresP;
                    model.APELLIDOS = pacienteModel.apellidosP;
                    model.DNI = pacienteModel.dniP;
                    model.DIRECCION = pacienteModel.direccionP;
                    model.TELEFONO = pacienteModel.telefonoP;
                    model.SEXO = pacienteModel.sexoP;
                    model.FECHANACIMIENTO = pacienteModel.fNacP;
                    model.FECHAREGISTRO = DateTime.Today;
                    model.FECHAMODIFICACION = DateTime.Today;
                    model.USUARIOREGISTRO = "";
                    model.USUARIOMODIFICACION = "";
                    model.ACTIVO = true;

                    using (var db = new CLINICAEntities1())
                    {
                        db.PACIENTES.Add(model);
                        db.SaveChanges();
                        return Redirect("~/Pacientes/Index");
                    }
                }
                return View(pacienteModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            PacienteFullViewModel model = new PacienteFullViewModel();
            using (CLINICAEntities1 db = new CLINICAEntities1())
            {
                var oPaciente = db.PACIENTES.Find(id);
                model.idP = oPaciente.ID;
                model.nombresP = oPaciente.NOMBRES;
                model.apellidosP = oPaciente.APELLIDOS;
                model.dniP = oPaciente.DNI;
                model.direccionP = oPaciente.DIRECCION;
                model.telefonoP = oPaciente.TELEFONO;
                model.sexoP = oPaciente.SEXO;
                model.fNacP = oPaciente.FECHANACIMIENTO;
                model.fRegP = (DateTime)oPaciente.FECHAREGISTRO;
                model.fModP = (DateTime)oPaciente.FECHAMODIFICACION;
                model.activoP = oPaciente.ACTIVO;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(PacienteFullViewModel pacienteModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oPaciente = new PACIENTES();
                    oPaciente.ID = pacienteModel.idP;
                    oPaciente.NOMBRES = pacienteModel.nombresP;
                    oPaciente.APELLIDOS = pacienteModel.apellidosP;
                    oPaciente.DNI = pacienteModel.dniP;
                    oPaciente.DIRECCION = pacienteModel.direccionP;
                    oPaciente.TELEFONO = pacienteModel.telefonoP;
                    oPaciente.SEXO = pacienteModel.sexoP;
                    oPaciente.FECHANACIMIENTO = pacienteModel.fNacP;
                    oPaciente.FECHAREGISTRO = pacienteModel.fRegP;
                    oPaciente.FECHAMODIFICACION = DateTime.Today;
                    oPaciente.USUARIOREGISTRO = pacienteModel.userRegP;
                    oPaciente.USUARIOMODIFICACION = pacienteModel.userModP;
                    oPaciente.ACTIVO = pacienteModel.activoP;

                    using (var db = new CLINICAEntities1())
                    {
                        db.Entry(oPaciente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return Redirect("~/Pacientes/Index");
                    }
                }
                return View(pacienteModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Eliminar(int id)
        {
            using (CLINICAEntities1 db = new CLINICAEntities1())
            {
                var oPaciente = db.PACIENTES.Find(id);
                oPaciente.ACTIVO = false;
                db.Entry(oPaciente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Content("1");
        }
    }
}