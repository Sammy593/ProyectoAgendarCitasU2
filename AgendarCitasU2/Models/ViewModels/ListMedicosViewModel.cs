using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendarCitasU2.Models.ViewModels
{
    public class ListMedicosViewModel
    {
        public int ID { get; set; }
     
        public string NOMBRES { get; set; }

        public string APELLIDOS { get; set; }
     
        public string DNI { get; set; }
    
        public string DIRECCION { get; set; }
       
        public string CORREO { get; set; }
       
        public string TELEFONO { get; set; }
  
        public string SEXO { get; set; }
      
        public string NUMCOLEGIATURA { get; set; }
        

        public DateTime FECHANACIMIENTO { get; set; }
      
        public DateTime FECHAREGISTRO { get; set; }

        public string USUARIOREGISTRO { get; set; }
     
        public string USUARIOMODIFICACION { get; set; }

        public bool ACTIVO { get; set; }

        public string USERNAME { get; set; }

        public string PASSWORD { get; set; }


    }
}