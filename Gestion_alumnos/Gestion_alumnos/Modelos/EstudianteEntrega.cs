using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_alumnos.Modelos
{
    public class EstudianteEntrega
    {
        public int Legajo { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public bool Entregado { get; set; }
    }
}
