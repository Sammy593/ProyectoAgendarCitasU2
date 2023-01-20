using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AgendarCitasU2.Models.ViewModels
{
    public class CitaViewModel
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Medico")]
        public int medicoId { get; set; }
        public string nombreMedico { get; set; }
        public string apellidoMedico { get; set; }

        public string especialidad { get; set; }
       
        [Required]
        [Display(Name = "Paciente")]
        public int pacienteId { get; set; }
        public string nombrePaciente { get; set; }
        public string apellidoPaciente { get; set; }

        [Required]
        [Display(Name = "Fecha de atencion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaAtencion { get; set; }

        [Required]
        [Display(Name = "Inicio de atencion")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{hh-mm-ss}", ApplyFormatInEditMode = true)]
        public TimeSpan inicioAtencion { get; set; }

        [Required]
        [Display(Name = "Fin de atencion")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{hh-mm-ss}", ApplyFormatInEditMode = true)]
        public TimeSpan finAtencion { get; set; }

        [Display(Name = "Estado")]
        [StringLength(25)]
        public string estado { get; set; }

        [Display(Name = "Observaciones")]
        [StringLength(500)]
        public string observaciones { get; set; }

        [Required]
        [Display(Name = "Activo")]
        public Boolean activo { get; set; }

        [Display(Name = "Fecha de registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaRegistro { get; set; }

        [Display(Name = "Registro de usuario")]
        [StringLength(25)]
        public string usuarioRegistro { get; set; }

        [Display(Name = "Fecha de modificacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaModificacion { get; set; }

        [Display(Name = "Modificacion de usuario")]
        [StringLength(25)]
        public string usuarioModificacion { get; set; }

       // public IEnumerable<System.Web.Mvc.SelectListItem> medico { get; set; }
    }
}