using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_alumnos.Modelos
{
    public class Asistencia
    {
        public int LegajoEstudiante { get; set; }

        public DateTime FechaClase { get; set; }

        public string Comision { get; set; } = string.Empty;

        public bool Presente { get; set; }
    }
}
