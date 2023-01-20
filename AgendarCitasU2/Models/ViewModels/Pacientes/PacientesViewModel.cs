using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendarCitasU2.Models.ViewModels
{
    public class PacientesViewModel
    {
        public int idPaciente { get; set; }
        public string nombresPaciente { set; get; }

        public string apellidosPaciente { set; get; }

        public string dniPaciente { set; get; }
    }
}