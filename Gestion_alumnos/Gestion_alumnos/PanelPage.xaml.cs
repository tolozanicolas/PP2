using Gestion_alumnos.ViewModels;

namespace Gestion_alumnos
{
    public partial class PanelPage : ContentPage
    {
        public PanelPage(PanelViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}