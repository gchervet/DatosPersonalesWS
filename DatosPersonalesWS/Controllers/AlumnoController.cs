using DatosPersonalesWS.Common.DTO;
using DatosPersonalesWS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;

namespace DatosPersonalesWS.Controllers
{
    [RoutePrefix("api/alumno")]
    public class AlumnoController : ApiController
    {
        private AlumnoService alumnoService = new AlumnoService();

        /// <summary>
        /// Verifica si el alumno tiene los datos actualizados en función a la cantidad de meses enviada
        /// </summary>
        /// <param name="username">Nombre de usuario del alumno</param>
        /// <param name="cantMeses">Cantidad de meses para verificar, 6 por defecto</param>
        /// <returns>True si la información está actualizada. False en caso contrario</returns>
        [Route("ValidarInformacionActualizada")]
        [HttpGet]
        public bool ValidarInformacionActualizada(string username, int cantMeses = 6)
        {
            return alumnoService.ValidarInformacionActualizada(username, cantMeses);
        }

        /// <summary>
        /// Obtiene una lista de UniAlumnosDatosPersonalesDto
        /// </summary>
        /// <param name="username">Nombre de usuario del alumno</param>
        [Route("GetDatosPersonalesByUsername")]
        [HttpGet]
        public UniAlumnosDatosPersonalesDto GetDatosPersonalesByUsername(string username)
        {
            return alumnoService.GetDatosPersonalesByUsername(username);
        }

        /// <summary>
        /// Actualiza los datos personales del alumno, cargan una nueva fecha de actualización
        /// </summary>
        /// <param name="datosPersonalesDto">*DTO* Tipo que representa los datos personales del alumno</param>
        /// <returns>El objeto de la base actualizado, con la nueva fecha de última modificación</returns>
        [Route("UpdateDatosPersonales")]
        [HttpPost]
        public UniAlumnosDatosPersonalesDto UpdateDatosPersonales([FromBody]UniAlumnosDatosPersonalesDto alumnosDatosPersonalesDto)
        {
            return alumnoService.UpdateDatosPersonales(alumnosDatosPersonalesDto);
        }

        /// <summary>
        /// Actualiza los datos personales del alumno, cargan una nueva fecha de actualización
        /// </summary>
        /// <param name="datosPersonalesDto">*DTO* Tipo que representa los datos personales del alumno</param>
        /// <returns>El objeto de la base actualizado, con la nueva fecha de última modificación</returns>
        [Route("GetAlumnoCarreras")]
        [HttpGet]
        public List<UniCarreraDTO> GetAlumnoCarreras(string username)
        {
            return alumnoService.GetAlumnoCarreras(username);
        }

        /// <summary>
        /// Actualiza los datos personales del alumno, cargan una nueva fecha de actualización
        /// </summary>
        /// <param name="datosPersonalesDto">*DTO* Tipo que representa los datos personales del alumno</param>
        /// <returns>El objeto de la base actualizado, con la nueva fecha de última modificación</returns>
        [Route("GetIdEntidadByUsername")]
        [HttpGet]
        public int GetIdEntidadByUsername(string username)
        {
            return alumnoService.GetIdEntidadByUsername(username);
        }
    }
}