//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgendarCitasU2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PACIENTES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PACIENTES()
        {
            this.CITAS = new HashSet<CITAS>();
        }
    
        public int ID { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public string DNI { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string SEXO { get; set; }
        public System.DateTime FECHANACIMIENTO { get; set; }
        public Nullable<System.DateTime> FECHAREGISTRO { get; set; }
        public Nullable<System.DateTime> FECHAMODIFICACION { get; set; }
        public string USUARIOREGISTRO { get; set; }
        public string USUARIOMODIFICACION { get; set; }
        public bool ACTIVO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CITAS> CITAS { get; set; }
    }
}
