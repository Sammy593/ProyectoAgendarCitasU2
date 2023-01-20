using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AgendarCitasU2.Models.ViewModels
{
    public class PacienteFullViewModel
    {
        public int idP { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        [StringLength(25)]
        public string nombresP { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [StringLength(25)]
        public string apellidosP { get; set; }

        [Required]
        [Display(Name = "DNI")]
        [StringLength(8)]
        public string dniP { get; set; }

        [Required]
        [Display(Name = "Direccion")]
        [StringLength(100)]
        public string direccionP { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        [StringLength(25)]
        public string telefonoP { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        [StringLength(1)]
        public string sexoP { get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fNacP { get; set; }


        [Display(Name = "Fecha de registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fRegP { get; set; }


        [Display(Name = "Fecha de modificacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fModP { get; set; }


        [Display(Name = "Registro de usuario")]
        [StringLength(25)]
        public string userRegP { get; set; }


        [Display(Name = "Modificacion de usuario")]
        [StringLength(25)]
        public string userModP { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public Boolean activoP { get; set; }

    }
}