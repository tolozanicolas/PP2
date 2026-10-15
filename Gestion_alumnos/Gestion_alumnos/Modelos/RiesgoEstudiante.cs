using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_alumnos.Modelos
{
    public class RiesgoEstudiante
    {
        public int Legajo { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public string Comision { get; set; } = string.Empty;

        public double PorcentajeInasistencias { get; set; }

        public double PorcentajeNoEntregas { get; set; }

        public double PorcentajeRiesgo { get; set; }

        public string NivelRiesgo { get; set; } = string.Empty;
    }
}
