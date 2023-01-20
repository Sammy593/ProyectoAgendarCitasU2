using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Llamar a DataAnotations
using System.ComponentModel.DataAnnotations;

namespace AgendarCitasU2.Models.ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }

        // Campos de la tabla
        [Required]
        [Display(Name = "Usuario")]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [StringLength(16)]
        public string PASSWORD { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("PASSWORD", ErrorMessage = "La contraseña no coincide")]
        public string CONFIRMPASSWORD { get; set; }

        [Required]
        [Display(Name = "Seleccione la función")]
        public bool ISADMIN { get; set; }

        [Required]
        [Display(Name = "Seleccione el estado")]
        public bool ISACTIVE { get; set; }
    }
}