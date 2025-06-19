using ConsultorioApp.ViewModels;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views
{
    public partial class CitasPage : ContentPage
    {
        public CitasPage(CitasViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}