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
    
    public partial class MEDICOS_ESPECIALIDADES
    {
        public int ID { get; set; }
        public int MEDICOID { get; set; }
        public int ESPECIALIDADID { get; set; }
        public Nullable<System.DateTime> FECHAREGISTRO { get; set; }
        public Nullable<System.DateTime> FECHAMODIFICACION { get; set; }
        public string USUARIOREGISTRO { get; set; }
        public string USUARIOMODIFICACION { get; set; }
        public bool ACTIVO { get; set; }
    
        public virtual ESPECIALIDADES ESPECIALIDADES { get; set; }
        public virtual MEDICOS MEDICOS { get; set; }
    }
}
