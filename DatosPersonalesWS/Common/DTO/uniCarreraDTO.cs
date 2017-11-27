using DatosPersonalesWS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatosPersonalesWS.Common.DTO
{
    public class UniCarreraDTO
    {
        public UniCarreraDTO(sp_uni_get_alumno_carrera_idEntidad_Result carrera)
        {
            Plan = carrera.Plan;
            Modalidad = carrera.Modalidad;
            Carrera = carrera.Carrera;
            Canvas = carrera.Canvas;
        }
        public string Plan { get; set; }
        public string Modalidad { get; set; }
        public string Carrera { get; set; }
        public Nullable<bool> Canvas { get; set; }
    }
}