using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AgendarCitasU2.Models.ViewModels
{
    public class MedicosViewModel
    {


        public int ID { get; set; }
        [Required]
        [Display(Name ="Nombres")]
        [StringLength(25)]
        public string NOMBRES { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        [StringLength(25)]
        public string APELLIDOS { get; set; }
        [Required]
        [Display(Name = "DNI")]
        public string DNI { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        [StringLength(100)]
        public string DIRECCION { get; set; }
        [Required]
        [Display(Name = "Correo")]
        [StringLength(50)]
        public string CORREO { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        [StringLength(25)]
        public string TELEFONO { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        [StringLength(1)]
        public string SEXO { get; set; }
        [Required]
        [Display(Name = "Numero de colegiatura")]
        [StringLength(10)]
        public string NUMCOLEGIATURA { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FECHANACIMIENTO { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de registro")]
        public DateTime FECHAREGISTRO { get; set; }
        [Display(Name = "Usuario registro")]
        [StringLength(25)]
        public string USUARIOREGISTRO { get; set;}
        [Display(Name = "Usuario modificacion")]
        [StringLength(25)]
        public string USUARIOMODIFICACION { get; set; }
        [Required]
        [Display(Name = "Username")]
        [StringLength(10)]
        public string USERNAME { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(10)]
        public string PASSWORD{ get; set; }


        [Required]
        [Display(Name =" ¿El usuario está activo? ")]
        public bool ACTIVO { get; set; }







    }
}