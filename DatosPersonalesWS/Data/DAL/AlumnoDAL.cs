using DatosPersonalesWS.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DatosPersonalesWS.Data.DAL
{
	public class AlumnoDAL
	{
		internal UniAlumnosDatosPersonalesDto GetDatosPersonalesByUsername(string username)
		{
			UniAlumnosDatosPersonalesDto result;
			using (dev_Uni_Entities dev_Uni_Entities = new dev_Uni_Entities())
			{
				sp_uni_get_datos_alumno_username_Result sp_uni_get_datos_alumno_username_Result = dev_Uni_Entities.sp_uni_get_datos_alumno_username(username).FirstOrDefault<sp_uni_get_datos_alumno_username_Result>();
				bool flag = sp_uni_get_datos_alumno_username_Result != null;
				if (flag)
				{
					List<sp_uni_get_alumno_carrera_idEntidad_Result> carrerasLista = dev_Uni_Entities.sp_uni_get_alumno_carrera_idEntidad(sp_uni_get_datos_alumno_username_Result.IdEntidad).ToList<sp_uni_get_alumno_carrera_idEntidad_Result>();
					result = new UniAlumnosDatosPersonalesDto(sp_uni_get_datos_alumno_username_Result, carrerasLista);
				}
				else
				{
					result = null;
				}
			}
			return result;
		}
		internal UniAlumnosDatosPersonalesDto UpdateDatosPersonales(UniAlumnosDatosPersonalesDto datosPersonalesDto)
		{
			using (dev_Uni_Entities dev_Uni_Entities = new dev_Uni_Entities())
			{
				sp_uni_update_datos_alumno_username_Result sp_uni_update_datos_alumno_username_Result = dev_Uni_Entities.sp_uni_update_datos_alumno_username(datosPersonalesDto.IdEntidad, datosPersonalesDto.Email, datosPersonalesDto.TelFijoCodArea, datosPersonalesDto.TelFijoNumero, datosPersonalesDto.TelMovilCodArea, datosPersonalesDto.TelMovilNumero).FirstOrDefault<sp_uni_update_datos_alumno_username_Result>();
				bool flag = sp_uni_update_datos_alumno_username_Result != null;
				if (flag)
				{
					datosPersonalesDto.UltimaModificacion = sp_uni_update_datos_alumno_username_Result.UltimaActualizacion;
				}
			}
			return datosPersonalesDto;
		}
		internal List<UniCarreraDTO> GetAlumnoCarreras(string username)
		{
			List<UniCarreraDTO> result;
			using (dev_Uni_Entities dev_Uni_Entities = new dev_Uni_Entities())
			{
				List<UniCarreraDTO> list = new List<UniCarreraDTO>();
				sp_uni_get_datos_alumno_username_Result sp_uni_get_datos_alumno_username_Result = dev_Uni_Entities.sp_uni_get_datos_alumno_username(username).FirstOrDefault<sp_uni_get_datos_alumno_username_Result>();
				bool flag = sp_uni_get_datos_alumno_username_Result != null;
				if (flag)
				{
					List<sp_uni_get_alumno_carrera_idEntidad_Result> list2 = dev_Uni_Entities.sp_uni_get_alumno_carrera_idEntidad(sp_uni_get_datos_alumno_username_Result.IdEntidad).ToList<sp_uni_get_alumno_carrera_idEntidad_Result>();
					foreach (sp_uni_get_alumno_carrera_idEntidad_Result current in list2)
					{
						list.Add(new UniCarreraDTO(current));
					}
					result = list;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}
		internal void InsertDetalleTitulo(UniAlumnoDetalleTituloDto alumnoDetalleTituloDto)
		{
			using (dev_Uni_Entities dev_Uni_Entities = new dev_Uni_Entities())
			{
				bool flag = alumnoDetalleTituloDto != null;
				if (flag)
				{
					UniAlumnosDetalleTitulo uniAlumnosDetalleTitulo = new UniAlumnosDetalleTitulo();
					uniAlumnosDetalleTitulo.IdEntidad = alumnoDetalleTituloDto.IdEntidad;
					uniAlumnosDetalleTitulo.TipoTituloNivelMedio = new int?(int.Parse(alumnoDetalleTituloDto.TipoTituloNivelMedio));
					uniAlumnosDetalleTitulo.FechaActualizacion = new DateTime?(alumnoDetalleTituloDto.FechaActualizacion);
					uniAlumnosDetalleTitulo.Convalidado = alumnoDetalleTituloDto.Convalidado;
					uniAlumnosDetalleTitulo.ComentarioTipoTituloNivelMedio = alumnoDetalleTituloDto.ComentarioTipoTituloNivelMedio;
					dev_Uni_Entities.UniAlumnosDetalleTituloes.Add(uniAlumnosDetalleTitulo);
					try
					{
						dev_Uni_Entities.SaveChanges();
					}
					catch (Exception ex)
					{
                        throw ex;
					}
				}
			}
		}
		internal bool ValidarDetalleDeTituloActualizado(string username)
		{
			bool result;
			using (dev_Uni_Entities dev_Uni_Entities = new dev_Uni_Entities())
			{
				sp_uni_get_datos_alumno_username_Result alumnosDatosPersonales = dev_Uni_Entities.sp_uni_get_datos_alumno_username(username).FirstOrDefault<sp_uni_get_datos_alumno_username_Result>();
				bool flag = alumnosDatosPersonales != null;
				if (flag)
				{
					result = dev_Uni_Entities.UniAlumnosDetalleTituloes.Any((UniAlumnosDetalleTitulo x) => (int?)x.IdEntidad == alumnosDatosPersonales.IdEntidad);
				}
				else
				{
					result = true;
				}
			}
			return result;
		}
		internal int GetIdEntidadByUsername(string username)
		{
			int result;
			using (dev_Uni_Entities dev_Uni_Entities = new dev_Uni_Entities())
			{
				sp_uni_get_datos_alumno_username_Result sp_uni_get_datos_alumno_username_Result = dev_Uni_Entities.sp_uni_get_datos_alumno_username(username).FirstOrDefault<sp_uni_get_datos_alumno_username_Result>();
				bool flag = sp_uni_get_datos_alumno_username_Result != null;
				if (flag)
				{
					result = (sp_uni_get_datos_alumno_username_Result.IdEntidad.HasValue ? sp_uni_get_datos_alumno_username_Result.IdEntidad.Value : 0);
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}
	}
}
