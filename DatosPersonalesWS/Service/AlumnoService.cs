using DatosPersonalesWS.Common.DTO;
using DatosPersonalesWS.Data.DAL;
using System;
using System.Collections.Generic;
namespace DatosPersonalesWS.Service
{
	public class AlumnoService
	{
		private AlumnoDAL alumnoDAL = new AlumnoDAL();
		internal bool ValidarInformacionActualizada(string username, int cantMeses)
		{
			UniAlumnosDatosPersonalesDto datosPersonalesByUsername = this.alumnoDAL.GetDatosPersonalesByUsername(username);
			bool flag = datosPersonalesByUsername == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = !datosPersonalesByUsername.UltimaModificacion.HasValue;
				if (flag2)
				{
					result = false;
				}
				else
				{
					DateTime t = DateTime.Now.AddMonths(-cantMeses);
					result = (datosPersonalesByUsername.UltimaModificacion >= t && datosPersonalesByUsername.UltimaModificacion <= DateTime.Now);
				}
			}
			return result;
		}
		internal UniAlumnosDatosPersonalesDto GetDatosPersonalesByUsername(string username)
		{
			return this.alumnoDAL.GetDatosPersonalesByUsername(username);
		}
		internal UniAlumnosDatosPersonalesDto UpdateDatosPersonales(UniAlumnosDatosPersonalesDto alumnosDatosPersonalesDto)
		{
			return this.alumnoDAL.UpdateDatosPersonales(alumnosDatosPersonalesDto);
		}
		internal List<UniCarreraDTO> GetAlumnoCarreras(string username)
		{
			return this.alumnoDAL.GetAlumnoCarreras(username);
		}
		internal void InsertDetalleTitulo(UniAlumnoDetalleTituloDto alumnoDetalleTituloDto)
		{
			this.alumnoDAL.InsertDetalleTitulo(alumnoDetalleTituloDto);
		}
		internal bool ValidarDetalleDeTituloActualizado(string username)
		{
			return this.alumnoDAL.ValidarDetalleDeTituloActualizado(username);
		}
		internal int GetIdEntidadByUsername(string username)
		{
			return this.alumnoDAL.GetIdEntidadByUsername(username);
		}

        internal bool ValidarAlumnoNotificado(string username)
        {
            return this.alumnoDAL.ValidarAlumnoNotificado(username);
        }

        internal void UpdateAlumnoNotificado(string username)
        {
            this.alumnoDAL.UpdateAlumnoNotificado(username);
        }
    }
}
