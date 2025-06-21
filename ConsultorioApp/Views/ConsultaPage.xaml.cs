using ConsultorioApp.ViewModels;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views
{
    public partial class ConsultaPage : ContentPage
    {
        public ConsultaPage(ConsultaViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}