using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_alumnos.Modelos
{
    public class EstudianteAsistencia
    {
        public int Legajo { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public bool Presente { get; set; }
    }
}