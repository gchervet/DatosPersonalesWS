using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DatosPersonalesWS.Common.DTO;

namespace DatosPersonalesWS.Data.DAL
{
    public class AlumnoDAL
    {
        /// <summary>
        /// Obtiene los datos personales del alumno mediante su nombre de usuario
        /// </summary>
        /// <param name="username">Nombre de usuario del alumno</param>
        /// <returns>Listado de los datos personales del alumno</returns>
        internal UniAlumnosDatosPersonalesDto GetDatosPersonalesByUsername(string username)
        {
            using (var context = new dev_Uni_Entities())
            {
                // context posee todas mis entidades de modelo de base de datos
                sp_uni_get_datos_alumno_username_Result alumnosDatosPersonales = context.sp_uni_get_datos_alumno_username(username).FirstOrDefault();

                // FirstOrDefault() me devuelve el primer registro encontrado, o null en su defecto
                if (alumnosDatosPersonales != null)
                {
                    List<sp_uni_get_alumno_carrera_idEntidad_Result> carrerasPorAlumnoLista = context.sp_uni_get_alumno_carrera_idEntidad(alumnosDatosPersonales.IdEntidad).ToList();
                    return new UniAlumnosDatosPersonalesDto(alumnosDatosPersonales, carrerasPorAlumnoLista);
                }
                return null;
            }
        }

        /// <summary>
        /// Actualiza los datos personales del alumno, cargan una nueva fecha de actualización
        /// </summary>
        /// <param name="datosPersonalesDto">*DTO* Tipo que representa los datos personales del alumno</param>
        /// <returns>El objeto de la base actualizado, con la nueva fecha de última modificación</returns>
        internal UniAlumnosDatosPersonalesDto UpdateDatosPersonales(UniAlumnosDatosPersonalesDto datosPersonalesDto)
        {
            using (var context = new dev_Uni_Entities())
            {
                // Stored que actualiza los datos
                sp_uni_update_datos_alumno_username_Result datosParaActualizar = 
                    context.sp_uni_update_datos_alumno_username(
                        datosPersonalesDto.IdEntidad, 
                        datosPersonalesDto.Email, 
                        datosPersonalesDto.TelFijoCodArea, 
                        datosPersonalesDto.TelFijoNumero, 
                        datosPersonalesDto.TelMovilCodArea, 
                        datosPersonalesDto.TelMovilNumero).FirstOrDefault();

                if (datosParaActualizar != null)
                {
                    datosPersonalesDto.UltimaModificacion = datosParaActualizar.UltimaActualizacion;
                }
                return datosPersonalesDto;
            }
        }

        internal List<UniCarreraDTO> GetAlumnoCarreras(string username)
        {
            using (var context = new dev_Uni_Entities())
            {
                List<UniCarreraDTO> rtn = new List<Common.DTO.UniCarreraDTO>();
                // context posee todas mis entidades de modelo de base de datos
                sp_uni_get_datos_alumno_username_Result alumnosDatosPersonales = context.sp_uni_get_datos_alumno_username(username).FirstOrDefault();

                // FirstOrDefault() me devuelve el primer registro encontrado, o null en su defecto
                if (alumnosDatosPersonales != null)
                {
                    List<sp_uni_get_alumno_carrera_idEntidad_Result> carrerasPorAlumnoLista = context.sp_uni_get_alumno_carrera_idEntidad(alumnosDatosPersonales.IdEntidad).ToList();
                    foreach (sp_uni_get_alumno_carrera_idEntidad_Result carrera in carrerasPorAlumnoLista)
                    {
                        rtn.Add(new UniCarreraDTO(carrera));
                    }
                    return rtn;
                }
                return null;
            }
        }

        internal int GetIdEntidadByUsername(string username)
        {
            using (var context = new dev_Uni_Entities())
            {
                // context posee todas mis entidades de modelo de base de datos
                uniAlumno uniAlumno = context.uniAlumnos.Where(x => x.username == username).FirstOrDefault();

                // FirstOrDefault() me devuelve el primer registro encontrado, o null en su defecto
                if (uniAlumno != null)
                {
                    return uniAlumno.IdEntidad.HasValue ? uniAlumno.IdEntidad.Value : 0;
                }
                return 0;
            }
        }
    }
}