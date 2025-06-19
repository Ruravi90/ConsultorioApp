using ConsultorioApp.ViewModels;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views
{
    public partial class CitaDetallePage : ContentPage
    {
        public CitaDetallePage(CitaDetalleViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}