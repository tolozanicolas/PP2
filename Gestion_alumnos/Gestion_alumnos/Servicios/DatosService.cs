using Gestion_alumnos.Modelos;
using System.Collections.ObjectModel;

namespace Gestion_alumnos.Servicios
{
    public class DatosService
    {
        public ObservableCollection<Estudiante> Estudiantes { get; }
            = new ObservableCollection<Estudiante>();

        public ObservableCollection<Clase> Clases { get; }
            = new ObservableCollection<Clase>();

        public ObservableCollection<TrabajoPractico> Trabajos { get; }
            = new ObservableCollection<TrabajoPractico>();

        public ObservableCollection<Asistencia> Asistencias { get; }
            = new ObservableCollection<Asistencia>();

        public ObservableCollection<Entrega> Entregas { get; set; } = new();
    }
}
