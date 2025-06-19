using ConsultorioApp.ViewModels;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views
{
    public partial class PacientesPage : ContentPage
    {
        public PacientesPage(PacienteDetalleViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}