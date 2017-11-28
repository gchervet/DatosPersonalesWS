using DatosPersonalesWS.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace DatosPersonalesWS.Common.DTO
{
	public class UniAlumnosDatosPersonalesDto
	{
		public int LegajoProvisorio
		{
			get;
			set;
		}
		public int? LegajoDefinitivo
		{
			get;
			set;
		}
		public string Apellido
		{
			get;
			set;
		}
		public string Nombre
		{
			get;
			set;
		}
		public DateTime? FecNac
		{
			get;
			set;
		}
		public string username
		{
			get;
			set;
		}
		public int? IdEntidad
		{
			get;
			set;
		}
		public string NumeroDocumento
		{
			get;
			set;
		}
		public int? TipoDocumento
		{
			get;
			set;
		}
		public string Email
		{
			get;
			set;
		}
		public DateTime? UltimaModificacion
		{
			get;
			set;
		}
		public string TelFijoCodArea
		{
			get;
			set;
		}
		public string TelFijoCodPais
		{
			get;
			set;
		}
		public string TelFijoNumero
		{
			get;
			set;
		}
		public string TelMovilCodArea
		{
			get;
			set;
		}
		public string TelMovilCodPais
		{
			get;
			set;
		}
		public string TelMovilNumero
		{
			get;
			set;
		}
		public List<UniCarreraDTO> CarreraLista
		{
			get;
			set;
		}
		[JsonConstructor]
		public UniAlumnosDatosPersonalesDto()
		{
		}
		public UniAlumnosDatosPersonalesDto(sp_uni_get_datos_alumno_username_Result alumnosDatosPersonales, List<sp_uni_get_alumno_carrera_idEntidad_Result> carrerasLista)
		{
			this.LegajoProvisorio = alumnosDatosPersonales.legprovi;
			this.LegajoDefinitivo = alumnosDatosPersonales.legdef;
			this.Apellido = alumnosDatosPersonales.apellido;
			this.Nombre = alumnosDatosPersonales.nombre;
			this.Email = alumnosDatosPersonales.EMail;
			this.IdEntidad = alumnosDatosPersonales.IdEntidad;
			this.FecNac = alumnosDatosPersonales.fecnac;
			this.NumeroDocumento = alumnosDatosPersonales.NumeroDocumento;
			this.TelFijoCodArea = alumnosDatosPersonales.TelFijoCodArea;
			this.TelFijoNumero = alumnosDatosPersonales.TelFijoNumero;
			this.TelMovilCodArea = alumnosDatosPersonales.TelMovilCodArea;
			this.TelMovilNumero = alumnosDatosPersonales.TelMovilNumero;
			this.UltimaModificacion = alumnosDatosPersonales.UltimaActualizacion;
			this.CarreraLista = new List<UniCarreraDTO>();
			foreach (sp_uni_get_alumno_carrera_idEntidad_Result current in carrerasLista)
			{
				this.CarreraLista.Add(new UniCarreraDTO(current));
			}
		}
	}
}
