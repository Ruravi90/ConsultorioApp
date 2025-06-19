using ConsultorioApp.ViewModels;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views
{
    public partial class PacienteDetallePage : ContentPage
    {
        public PacienteDetallePage(PacienteDetalleViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}