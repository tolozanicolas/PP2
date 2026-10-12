using System;
using System.Collections.Generic;
using System.Text;

namespace Gestion_alumnos.Modelos
{
    public class TrabajoPractico
    {
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaEntrega { get; set; }
        public string Comision { get; set; } = string.Empty;
    }
}
