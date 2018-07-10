using DatosPersonalesWS.Common;
using DatosPersonalesWS.Common.DTO;
using DatosPersonalesWS.Service;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
namespace DatosPersonalesWS.Controllers
{
	[RoutePrefix("api/alumno")]
	public class AlumnoController : ApiController
	{
		private AlumnoService alumnoService = new AlumnoService();
		private SecurityService securityService = new SecurityService();

		[HttpGet, Route("ValidarInformacionActualizada")]
		public bool ValidarInformacionActualizada(string username, int cantMeses = 6)
		{
			return this.alumnoService.ValidarInformacionActualizada(username, cantMeses);
		}

        [AllowAnonymous, HttpGet, Route("GetDatosPersonalesByUsername")]
		public UniAlumnosDatosPersonalesDto GetDatosPersonalesByUsername(string username)
		{
			UniAlumnosDatosPersonalesDto result;
			try
			{
                username = username.Replace(' ', '+');
                string text = this.securityService.DesencriptarUsername(username);
				bool flag = !string.IsNullOrEmpty(text);
				if (flag)
				{
					result = this.alumnoService.GetDatosPersonalesByUsername(text);
					return result;
				}
			}
			catch (Exception ex)
			{
				result = null;
				return result;
			}
			result = null;
			return result;
		}
        [AllowAnonymous, HttpPost, Route("UpdateDatosPersonales")]
        public UniAlumnosDatosPersonalesDto UpdateDatosPersonales([FromBody] UniAlumnosDatosPersonalesDto alumnosDatosPersonalesDto)
        {
            return this.alumnoService.UpdateDatosPersonales(alumnosDatosPersonalesDto);
        }
		[AllowAnonymous, HttpGet, Route("GetAlumnoCarreras")]
		public List<UniCarreraDTO> GetAlumnoCarreras(string username)
		{
			return this.alumnoService.GetAlumnoCarreras(username);
		}
		[HttpPost, Route("InsertDetalleTitulo")]
		public void InsertDetalleTitulo(UniAlumnoDetalleTituloDto alumnoDetalleTituloDto)
		{
			try
			{
				string text = this.securityService.DesencriptarUsername(HttpContext.Current.Request.Headers["Authorization"]);
				bool flag = alumnoDetalleTituloDto != null;
				if (flag)
				{
					bool flag2 = alumnoDetalleTituloDto.TipoTituloNivelMedio != TipoTituloNivelMedioEnum.OBTENIDO_EN_EXTERIOR.GetHashCode().ToString();
					if (flag2)
					{
						alumnoDetalleTituloDto.Convalidado = null;
					}
					bool flag3 = alumnoDetalleTituloDto.TipoTituloNivelMedio != TipoTituloNivelMedioEnum.OTRO.GetHashCode().ToString();
					if (flag3)
					{
						alumnoDetalleTituloDto.ComentarioTipoTituloNivelMedio = null;
					}
					bool flag4 = string.IsNullOrEmpty(alumnoDetalleTituloDto.ComentarioTipoTituloNivelMedio);
					if (flag4)
					{
						alumnoDetalleTituloDto.ComentarioTipoTituloNivelMedio = null;
					}
				}
				alumnoDetalleTituloDto.FechaActualizacion = DateTime.Now;
				this.alumnoService.InsertDetalleTitulo(alumnoDetalleTituloDto);
			}
            catch (Exception ex)
			{
			}
		}
		[HttpGet, Route("ValidarDetalleDeTituloActualizado")]
		public bool ValidarDetalleDeTituloActualizado(string username)
		{
			bool result;
			try
			{
				string text = this.securityService.DesencriptarUsername(HttpContext.Current.Request.Headers["Authorization"]);
				result = this.alumnoService.ValidarDetalleDeTituloActualizado(username);
			}
            catch (Exception ex)
			{
				result = false;
			}
			return result;
		}
		[HttpGet, Route("GetIdEntidadByUsername")]
		public int GetIdEntidadByUsername(string username)
		{
			return this.alumnoService.GetIdEntidadByUsername(username);
		}


        [HttpGet, Route("ValidarAlumnoNotificado")]
        public bool ValidarAlumnoNotificado(string username)
        {
            return this.alumnoService.ValidarAlumnoNotificado(username);
        }

        [HttpPost, Route("UpdateAlumnoNotificado")]
        public void UpdateAlumnoNotificado(string username)
        {
            this.alumnoService.UpdateAlumnoNotificado(username);
        }
	}
}
