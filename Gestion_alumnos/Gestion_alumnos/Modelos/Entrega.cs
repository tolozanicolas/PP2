using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_alumnos.Modelos
{
    public class Entrega
    {
        public int LegajoEstudiante { get; set; }

        public string NombreTrabajo { get; set; } = string.Empty;

        public string Comision { get; set; } = string.Empty;

        public bool Entregado { get; set; }
    }
}
