using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendarCitasU2.Models.ViewModels
{
    public class ListCitasViewModel
    {
        public int id { get; set; }
        public int medicoId { get; set; }
        public string nombreMedico { get; set; }
        public string apellidoMedico { get; set; }
        public int pacienteId { get; set; }
        public string nombrePaciente { get; set; }
        public string apellidoPaciente { get; set; }
        //public DateTime fechaAtencion { get; set; }
        //public DateTime inicioAtencion { get; set; }
        //public DateTime finAtencion { get; set; }
        public string estado { get; set; }
        //public string observaciones { get; set; }
        //public Boolean activo { get; set; }
        //public DateTime fechaRegistro { get; set; }
        //public string usuarioRegistro { get; set; }
        //public DateTime fechaModificacion { get; set; }
        //public string usuarioMod { get; set; }
    }
}