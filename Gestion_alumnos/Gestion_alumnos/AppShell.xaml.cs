
namespace Gestion_alumnos
{
    public partial class AppShell : Shell
    {
        public AppShell(
            MainPage estudiantesPage,
            CalendarioPage calendarioPage,
            AsistenciaPage asistenciaPage,
            EntregaPage entregaPage,
            PanelPage panelPage)
        {
            InitializeComponent();

            EstudiantesTab.Content = estudiantesPage;
            CalendarioTab.Content = calendarioPage;
            AsistenciaTab.Content = asistenciaPage;
            EntregasTab.Content = entregaPage;
            PanelTab.Content = panelPage;
        }
    }
}