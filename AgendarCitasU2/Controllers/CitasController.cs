using AgendarCitasU2.Models.ViewModels;
using AgendarCitasU2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace AgendarCitasU2.Controllers
{
    public class CitasController : Controller
    {
        // GET: Citas
        public ActionResult Index()
        {
            List<ListCitasViewModel> lst;
            using (CLINICAEntities1 db = new CLINICAEntities1())
            {
                lst = (from c in db.CITAS
                       join m in db.MEDICOS on c.MEDICOID equals m.ID
                       join p in db.PACIENTES on c.PACIENTEID equals p.ID
                       where c.ACTIVO == true
                       select new ListCitasViewModel
                       {
                           id = c.ID,
                           medicoId = c.MEDICOID,
                           nombreMedico = m.NOMBRES,
                           apellidoMedico = m.APELLIDOS,
                           pacienteId = c.PACIENTEID,
                           apellidoPaciente = p.APELLIDOS,
                           nombrePaciente = p.NOMBRES,
                           estado = c.ESTADO
                       }).ToList();
            }
            return View(lst); //Retornamos la vista con la lista
        }

        public ActionResult historial()
        {
            List<ListCitasViewModel> lst;
            using (CLINICAEntities1 db = new CLINICAEntities1())
            {
                lst = (from c in db.CITAS
                       join m in db.MEDICOS on c.MEDICOID equals m.ID
                       join p in db.PACIENTES on c.PACIENTEID equals p.ID
                       where c.ACTIVO == false
                       select new ListCitasViewModel
                       {
                           id = c.ID,
                           medicoId = c.MEDICOID,
                           nombreMedico = m.NOMBRES,
                           apellidoMedico = m.APELLIDOS,
                           pacienteId = c.PACIENTEID,
                           apellidoPaciente = p.APELLIDOS,
                           nombrePaciente = p.NOMBRES,
                           estado = c.ESTADO
                       }).ToList();
            }
            return View(lst); //Retornamos la vista con la lista
        }

        public ActionResult Nuevo()
        {

            using (CLINICAEntities1 db = new CLINICAEntities1())
            {
                var medicos = db.MEDICOS.Where(c => c.ACTIVO == true).ToList();
                var medicosItems = new List<SelectListItem>();
                foreach (var item in medicos)
                {
                    medicosItems.Add(new SelectListItem
                    {
                        Text = item.NOMBRES + " " + item.APELLIDOS,
                        Value = item.ID.ToString()
                    });
                }

                var pacientes = db.PACIENTES.Where(c => c.ACTIVO == true).ToList();
                var pacientesItems = new List<SelectListItem>();
                foreach (var item in pacientes)
                {
                    pacientesItems.Add(new SelectListItem
                    {
                        Text = item.NOMBRES + " " + item.APELLIDOS,
                        Value = item.ID.ToString()
                    });
                }

                ViewBag.medicosItems = medicosItems;
                ViewBag.pacientesItems = pacientesItems;
            }
            return View();
        }

        public JsonResult getEspecialidadesList(int medicoId)
        {
            using (var db = new CLINICAEntities1())
            {
                var oM_E = db.MEDICOS_ESPECIALIDADES.Where(c => c.MEDICOID == medicoId).ToList();
                var especialidades = new List<ESPECIALIDADES>();
                foreach (var item in oM_E)
                {
                    var oEsp = db.ESPECIALIDADES.Find(item.ESPECIALIDADID);
                    especialidades.Add(new ESPECIALIDADES
                    {
                        ID = oEsp.ID,
                        NOMBRE = oEsp.NOMBRE
                    });
                }

                return Json(especialidades, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Nuevo(CitaViewModel citaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new CLINICAEntities1())
                    {
                        var model = new CITAS();
                        model.MEDICOID = citaModel.medicoId;
                        model.PACIENTEID = citaModel.pacienteId;
                        model.FECHAATENCION = citaModel.fechaAtencion;
                        model.INICIOATENCION = citaModel.inicioAtencion;
                        model.FINATENCION = citaModel.finAtencion;
                        model.ESTADO = "Pendiente";
                        model.OBSERVACIONES = citaModel.observaciones;
                        model.ACTIVO = true;
                        model.FECHAREGISTRO = DateTime.Now;
                        model.USUARIOREGISTRO = "";
                        model.FECHAMODIFICACION = DateTime.Now;
                        model.USUARIOMODIFICACION = "";

                        int idEspecialidad = int.Parse(citaModel.especialidad);
                        var oEspecialidad = db.ESPECIALIDADES.SingleOrDefault(d => d.ID == idEspecialidad);
                        model.ESPECIALIDAD = oEspecialidad.NOMBRE;

                        db.CITAS.Add(model);
                        db.SaveChanges();

                        return Redirect("~/Citas/Index");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(citaModel);
        }

        public ActionResult verCita(int id)
        {
            CitaViewModel model = new CitaViewModel();
            using (CLINICAEntities1 db = new CLINICAEntities1())
            {
                var oCita = db.CITAS.Find(id);
                var oMedico = db.MEDICOS.Find(oCita.MEDICOID);
                var oPaciente = db.PACIENTES.Find(oCita.PACIENTEID);

                model.id = oCita.ID;
                model.nombreMedico = oMedico.NOMBRES;
                model.especialidad = oCita.ESPECIALIDAD;
                model.apellidoMedico = oMedico.APELLIDOS;
                model.nombrePaciente = oPaciente.NOMBRES;
                model.apellidoPaciente = oPaciente.APELLIDOS;
                model.fechaAtencion = oCita.FECHAATENCION;
                model.inicioAtencion = oCita.INICIOATENCION;
                model.finAtencion = oCita.FINATENCION;
                model.estado = oCita.ESTADO;
                model.observaciones = oCita.OBSERVACIONES;
                model.activo = oCita.ACTIVO;
                model.fechaRegistro = DateTime.Now;

                if (model.usuarioRegistro != null)
                {
                    model.usuarioRegistro = oCita.USUARIOREGISTRO;
                }
                else
                {
                    model.usuarioRegistro = "";
                }

                model.fechaModificacion = DateTime.Now;

                if (model.usuarioModificacion != null)
                {
                    model.usuarioModificacion = oCita.USUARIOMODIFICACION;
                }
                else
                {
                    model.usuarioModificacion = "";
                }

            }

            return View(model);
        }

        public ActionResult delCita(int id)
        {
            using (CLINICAEntities1 db = new CLINICAEntities1())
            {
                var oCita = db.CITAS.Find(id);
                oCita.ACTIVO = false;
                oCita.ESTADO = "Cancelada";
                db.Entry(oCita).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Content("1");
        }

        public ActionResult confCita(int id)
        {
            using (CLINICAEntities1 db = new CLINICAEntities1())
            {
                var oCita = db.CITAS.Find(id);
                oCita.ACTIVO = false;
                oCita.ESTADO = "Atentida";
                db.Entry(oCita).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Content("1");
        }
    }
}