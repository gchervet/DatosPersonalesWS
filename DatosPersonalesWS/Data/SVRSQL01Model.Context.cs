﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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
    
        public virtual ObjectResult<sp_uni_update_datos_alumno_username_Result> sp_uni_update_datos_alumno_username(Nullable<int> idEntidad, string mail, string telFijoArea, string telFijoNumero, string telMovilArea, string telMovilNumero)
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
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_uni_update_datos_alumno_username_Result>("sp_uni_update_datos_alumno_username", idEntidadParameter, mailParameter, telFijoAreaParameter, telFijoNumeroParameter, telMovilAreaParameter, telMovilNumeroParameter);
        }
    }
}
