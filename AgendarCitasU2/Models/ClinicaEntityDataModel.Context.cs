﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CLINICAEntities1 : DbContext
    {
        public CLINICAEntities1()
            : base("name=CLINICAEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CITAS> CITAS { get; set; }
        public virtual DbSet<ESPECIALIDADES> ESPECIALIDADES { get; set; }
        public virtual DbSet<HORARIOS> HORARIOS { get; set; }
        public virtual DbSet<MEDICOS> MEDICOS { get; set; }
        public virtual DbSet<MEDICOS_ESPECIALIDADES> MEDICOS_ESPECIALIDADES { get; set; }
        public virtual DbSet<PACIENTES> PACIENTES { get; set; }
        public virtual DbSet<USUARIOS> USUARIOS { get; set; }
    }
}
