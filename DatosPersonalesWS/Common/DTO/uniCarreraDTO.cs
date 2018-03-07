using DatosPersonalesWS.Data;
using System;
namespace DatosPersonalesWS.Common.DTO
{
	public class UniCarreraDTO
	{
		public string Plan
		{
			get;
			set;
		}
		public string Modalidad
		{
			get;
			set;
		}
		public string Carrera
		{
			get;
			set;
		}
        public string Nivel
        {
            get;
            set;
        }
		public bool? Canvas
		{
			get;
			set;
		}
        public bool? Notificado
        {
            get;
            set;
        }
		public UniCarreraDTO(sp_uni_get_alumno_carrera_idEntidad_Result carrera)
		{
			this.Plan = carrera.Plan;
			this.Modalidad = carrera.Modalidad;
			this.Carrera = carrera.Carrera;
			this.Canvas = carrera.Canvas;
            this.Nivel = carrera.Nivel;
            this.Notificado = carrera.Notificado;
		}
	}
}
