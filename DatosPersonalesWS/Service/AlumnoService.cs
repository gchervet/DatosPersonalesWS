using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatosPersonalesWS.Common.DTO;
using DatosPersonalesWS.Data.DAL;

namespace DatosPersonalesWS.Service
{
    public class AlumnoService
    {
        private AlumnoDAL alumnoDAL = new AlumnoDAL();
        
        /// <summary>
        /// Verifica si el alumno tiene los datos actualizados en función a la cantidad de meses enviada
        /// </summary>
        /// <param name="username">Nombre de usuario del alumno</param>
        /// <param name="cantMeses">Cantidad de meses para verificar, 6 por defecto</param>
        /// <returns>True si la información está actualizada. False en caso contrario</returns>
        internal bool ValidarInformacionActualizada(string username, int cantMeses)
        {
            // Reutilizo el método de obtención de datos
            UniAlumnosDatosPersonalesDto datosPersonales = alumnoDAL.GetDatosPersonalesByUsername(username);
            
            // Chequeos generales 
            if(datosPersonales == null) 
                return false;
            
            if(datosPersonales.UltimaModificacion == null)
                return false;
            
            // Obtengo la fechaDesde mediante la cantidad de meses ingresada
            DateTime fechaDesde = DateTime.Now.AddMonths(-cantMeses);

            // Retorno true/false si la fecha se encuentra en el rango
            return datosPersonales.UltimaModificacion >= fechaDesde && datosPersonales.UltimaModificacion <= DateTime.Now;
        }

        /// <summary>
        /// Obtiene los datos personales del alumno mediante su nombre de usuario
        /// </summary>
        /// <param name="username">Nombre de usuario del alumno</param>
        /// <returns>Listado de los datos personales del alumno</returns>
        internal UniAlumnosDatosPersonalesDto GetDatosPersonalesByUsername(string username)
        {
            return alumnoDAL.GetDatosPersonalesByUsername(username);
        }

        /// <summary>
        /// Actualiza los datos personales del alumno, cargan una nueva fecha de actualización
        /// </summary>
        /// <param name="datosPersonalesDto">*DTO* Tipo que representa los datos personales del alumno</param>
        /// <returns>El objeto de la base actualizado, con la nueva fecha de última modificación</returns>
        internal UniAlumnosDatosPersonalesDto UpdateDatosPersonales(UniAlumnosDatosPersonalesDto alumnosDatosPersonalesDto)
        {
            return alumnoDAL.UpdateDatosPersonales(alumnosDatosPersonalesDto);
        }

        internal List<UniCarreraDTO> GetAlumnoCarreras(string username)
        {
            return alumnoDAL.GetAlumnoCarreras(username);
        }

        internal int GetIdEntidadByUsername(string username)
        {
            return alumnoDAL.GetIdEntidadByUsername(username);
        }
    }
}