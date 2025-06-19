using ConsultorioApp.ViewModels;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views
{
    public partial class PerfilPage : ContentPage
    {
        public PerfilPage(PerfilViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}