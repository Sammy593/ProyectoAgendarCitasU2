using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace AgendarCitasU2.Models.ViewModels
{
    public class EspecialidadesViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(100)]
        public string NOMBRE { get; set; }

        [Required]
        [Display(Name = "DESCRIPCION")]
        [StringLength(500)]
        public string DESCRIPCION { get; set; }
       
        [Required]
        [Display(Name = "FECHA REGISTRO")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FECHAREGISTRO { get; set; }

        [Required]
        [Display(Name = "FECHA MODIFICACIÓN")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FECHAMODIFICACION { get; set; }

        [Required]
        [Display(Name = "USUARIO REGISTRO")]
        [StringLength(25)]
        public string USUARIOREGISTRO { get; set; }

        [Required]
        [Display(Name = "USUARIO MODIFICACION")]
        [StringLength(25)]
        public string USUARIOMODIFICACION { get; set; }

        [Required]
        [Display(Name = "¿EL USUARIO ESTA ACTIVO O INACTIVO?")]
        public bool ACTIVO { get; set; }
    }
}