
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Gestion_alumnos.Modelos;
using Gestion_alumnos.Servicios;

namespace Gestion_alumnos.ViewModels
{
    public class PanelViewModel : INotifyPropertyChanged
    {
        private readonly RiesgoService riesgoService;

        public ObservableCollection<RiesgoEstudiante> EstudiantesRiesgo
        { get; } = new();

        private string? comisionSeleccionada;

        public string? ComisionSeleccionada
        {
            get => comisionSeleccionada;
            set
            {
                if (comisionSeleccionada == value)
                    return;

                comisionSeleccionada = value;
                OnPropertyChanged();
                ActualizarPanel();
            }
        }

        private string mensajeEstado = "Seleccioná una comisión.";

        public string MensajeEstado
        {
            get => mensajeEstado;
            set
            {
                mensajeEstado = value;
                OnPropertyChanged();
            }
        }

        public ICommand ActualizarPanelCommand { get; }

        public PanelViewModel(RiesgoService riesgoService)
        {
            this.riesgoService = riesgoService;

            ActualizarPanelCommand = new Command(ActualizarPanel);
        }

        private void ActualizarPanel()
        {
            EstudiantesRiesgo.Clear();

            if (string.IsNullOrWhiteSpace(ComisionSeleccionada))
            {
                MensajeEstado = "Seleccioná una comisión.";
                return;
            }

            var resultados = riesgoService.CalcularRiesgos()
                .Where(r => r.Comision == ComisionSeleccionada)
                .OrderByDescending(r => r.PorcentajeRiesgo);

            foreach (var resultado in resultados)
            {
                EstudiantesRiesgo.Add(resultado);
            }

            MensajeEstado = EstudiantesRiesgo.Count == 0
                ? "No hay estudiantes cargados en esta comisión."
                : $"Estudiantes encontrados: {EstudiantesRiesgo.Count}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(
            [CallerMemberName] string? nombre = null)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(nombre));
        }
    }
}
