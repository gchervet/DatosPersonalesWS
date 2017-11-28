using System;
namespace DatosPersonalesWS.Common.DTO
{
	public class UniAlumnoDetalleTituloDto
	{
		public int IdEntidad
		{
			get;
			set;
		}
		public string TipoTituloNivelMedio
		{
			get;
			set;
		}
		public bool? Convalidado
		{
			get;
			set;
		}
		public string ComentarioTipoTituloNivelMedio
		{
			get;
			set;
		}
		public DateTime FechaActualizacion
		{
			get;
			set;
		}
	}
}
