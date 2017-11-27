using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatosPersonalesWS.Data;
using Newtonsoft.Json;

namespace DatosPersonalesWS.Common.DTO
{
    public class UniAlumnosDatosPersonalesDto
    {
        [JsonConstructor]
        public UniAlumnosDatosPersonalesDto() { }

        public UniAlumnosDatosPersonalesDto(sp_uni_get_datos_alumno_username_Result alumnosDatosPersonales, List<sp_uni_get_alumno_carrera_idEntidad_Result> carrerasLista)
        {
            LegajoProvisorio = alumnosDatosPersonales.legprovi;
            LegajoDefinitivo = alumnosDatosPersonales.legdef;
            Apellido = alumnosDatosPersonales.apellido;
            Nombre = alumnosDatosPersonales.nombre;
            Email = alumnosDatosPersonales.EMail;
            IdEntidad = alumnosDatosPersonales.IdEntidad;
            FecNac = alumnosDatosPersonales.fecnac;
            NumeroDocumento = alumnosDatosPersonales.NumeroDocumento;
            TelFijoCodArea = alumnosDatosPersonales.TelFijoCodArea;
            TelFijoNumero = alumnosDatosPersonales.TelFijoNumero;
            TelMovilCodArea = alumnosDatosPersonales.TelMovilCodArea;
            TelMovilNumero = alumnosDatosPersonales.TelMovilNumero;
            UltimaModificacion = alumnosDatosPersonales.UltimaActualizacion;
            CarreraLista = new List<UniCarreraDTO>();

            foreach (sp_uni_get_alumno_carrera_idEntidad_Result carrera in carrerasLista)
            {
                CarreraLista.Add(new UniCarreraDTO(carrera));
            }
        }

        public int LegajoProvisorio { get; set; }
        public Nullable<int> LegajoDefinitivo { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FecNac { get; set; }
        public string username { get; set; }
        public Nullable<int> IdEntidad { get; set; }
        public string NumeroDocumento { get; set; }
        public Nullable<int> TipoDocumento { get; set; }
        public string Email { get; set; }
        public Nullable<DateTime> UltimaModificacion { get; set; }
        public string TelFijoCodArea { get; set; }
        public string TelFijoCodPais { get; set; }
        public string TelFijoNumero { get; set; }
        public string TelMovilCodArea { get; set; }
        public string TelMovilCodPais { get; set; }
        public string TelMovilNumero { get; set; }
        public List<UniCarreraDTO> CarreraLista { get; set; }
    }
}