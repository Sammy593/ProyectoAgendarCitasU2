using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendarCitasU2.Models.ViewModels
{
    public class ListEspecialidadViewModel
    {
        //se trae los requisitos de la tabla de especialidades 

        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FECHAREGISTRO { get; set; }

    }
}