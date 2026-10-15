using System;
using System.Collections.Generic;
using System.Text;
using Gestion_alumnos.Modelos;

namespace Gestion_alumnos.Servicios
{
    public class RiesgoService
    {
        private readonly DatosService datosService;

        // Valores iniciales definidos por el equipo.
        // Más adelante H7 permitirá configurarlos.
        private const double UmbralMedio = 20;
        private const double UmbralAlto = 40;

        public RiesgoService(DatosService datosService)
        {
            this.datosService = datosService;
        }

        public List<RiesgoEstudiante> CalcularRiesgos()
        {
            List<RiesgoEstudiante> resultados = new();

            foreach (var estudiante in datosService.Estudiantes)
            {
                // Clases registradas de su comisión
                var clases = datosService.Clases
                    .Where(c => c.Comision == estudiante.Comision)
                    .ToList();

                int totalClases = clases.Count;

                // Cantidad de clases en las que figura ausente
                int inasistencias = clases.Count(clase =>
                    datosService.Asistencias.Any(a =>
                        a.LegajoEstudiante == estudiante.Legajo &&
                        a.Comision == estudiante.Comision &&
                        a.FechaClase.Date == clase.Fecha.Date &&
                        !a.Presente));

                double porcentajeInasistencias = totalClases > 0
                    ? (double)inasistencias / totalClases * 100
                    : 0;

                // Trabajos prácticos de su comisión
                var trabajos = datosService.Trabajos
                    .Where(t => t.Comision == estudiante.Comision)
                    .ToList();

                int totalTrabajos = trabajos.Count;

                // Cantidad de trabajos que figuran como no entregados
                int noEntregas = trabajos.Count(trabajo =>
                    datosService.Entregas.Any(e =>
                        e.LegajoEstudiante == estudiante.Legajo &&
                        e.Comision == estudiante.Comision &&
                        e.NombreTrabajo == trabajo.Nombre &&
                        !e.Entregado));

                double porcentajeNoEntregas = totalTrabajos > 0
                    ? (double)noEntregas / totalTrabajos * 100
                    : 0;

                // Combinar las señales disponibles.
                // Si solo hay una, usamos esa señal al 100 %.
                bool hayAsistencias = totalClases > 0;
                bool hayEntregas = totalTrabajos > 0;

                double riesgo = 0;
                string nivel = "Sin datos";

                if (hayAsistencias && hayEntregas)
                {
                    riesgo = porcentajeInasistencias * 0.5
                           + porcentajeNoEntregas * 0.5;
                }
                else if (hayAsistencias)
                {
                    riesgo = porcentajeInasistencias;
                }
                else if (hayEntregas)
                {
                    riesgo = porcentajeNoEntregas;
                }

                if (hayAsistencias || hayEntregas)
                {
                    if (riesgo >= UmbralAlto)
                        nivel = "Alto";
                    else if (riesgo >= UmbralMedio)
                        nivel = "Medio";
                    else
                        nivel = "Bajo";
                }

                resultados.Add(new RiesgoEstudiante
                {
                    Legajo = estudiante.Legajo,
                    NombreCompleto =
                        $"{estudiante.Apellido}, {estudiante.Nombre}",
                    Comision = estudiante.Comision,
                    PorcentajeInasistencias =
                        porcentajeInasistencias,
                    PorcentajeNoEntregas =
                        porcentajeNoEntregas,
                    PorcentajeRiesgo = riesgo,
                    NivelRiesgo = nivel
                });
            }

            return resultados
                .OrderByDescending(r => r.PorcentajeRiesgo)
                .ToList();
        }
    }
}
