﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatosPersonalesWS.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dev_Uni_Entities : DbContext
    {
        public dev_Uni_Entities()
            : base("name=dev_Uni_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<uniAlumnosDatosPersonale> uniAlumnosDatosPersonales { get; set; }
        public virtual DbSet<uniAlumno> uniAlumnos { get; set; }
        public virtual DbSet<UniAlumnosDetalleTitulo> UniAlumnosDetalleTituloes { get; set; }
    
        public virtual ObjectResult<sp_uni_get_datos_alumno_username_Result> sp_uni_get_datos_alumno_username(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_uni_get_datos_alumno_username_Result>("sp_uni_get_datos_alumno_username", usernameParameter);
        }
    
        public virtual ObjectResult<sp_uni_get_alumno_carrera_idEntidad_Result> sp_uni_get_alumno_carrera_idEntidad(Nullable<int> idEntidad)
        {
            var idEntidadParameter = idEntidad.HasValue ?
                new ObjectParameter("idEntidad", idEntidad) :
                new ObjectParameter("idEntidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_uni_get_alumno_carrera_idEntidad_Result>("sp_uni_get_alumno_carrera_idEntidad", idEntidadParameter);
        }
    
        public virtual ObjectResult<sp_uni_update_datos_alumno_username_Result> sp_uni_update_datos_alumno_username(Nullable<int> idEntidad, string mail, string telFijoArea, string telFijoNumero, string telMovilArea, string telMovilNumero, string telFijoCodPais, string telMovilCodPais)
        {
            var idEntidadParameter = idEntidad.HasValue ?
                new ObjectParameter("idEntidad", idEntidad) :
                new ObjectParameter("idEntidad", typeof(int));
    
            var mailParameter = mail != null ?
                new ObjectParameter("mail", mail) :
                new ObjectParameter("mail", typeof(string));
    
            var telFijoAreaParameter = telFijoArea != null ?
                new ObjectParameter("telFijoArea", telFijoArea) :
                new ObjectParameter("telFijoArea", typeof(string));
    
            var telFijoNumeroParameter = telFijoNumero != null ?
                new ObjectParameter("telFijoNumero", telFijoNumero) :
                new ObjectParameter("telFijoNumero", typeof(string));
    
            var telMovilAreaParameter = telMovilArea != null ?
                new ObjectParameter("telMovilArea", telMovilArea) :
                new ObjectParameter("telMovilArea", typeof(string));
    
            var telMovilNumeroParameter = telMovilNumero != null ?
                new ObjectParameter("telMovilNumero", telMovilNumero) :
                new ObjectParameter("telMovilNumero", typeof(string));
    
            var telFijoCodPaisParameter = telFijoCodPais != null ?
                new ObjectParameter("telFijoCodPais", telFijoCodPais) :
                new ObjectParameter("telFijoCodPais", typeof(string));
    
            var telMovilCodPaisParameter = telMovilCodPais != null ?
                new ObjectParameter("telMovilCodPais", telMovilCodPais) :
                new ObjectParameter("telMovilCodPais", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_uni_update_datos_alumno_username_Result>("sp_uni_update_datos_alumno_username", idEntidadParameter, mailParameter, telFijoAreaParameter, telFijoNumeroParameter, telMovilAreaParameter, telMovilNumeroParameter, telFijoCodPaisParameter, telMovilCodPaisParameter);
        }
    }
}
