using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultorioApp.ViewModels;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views;

public partial class CambiarContraseñaPage : ContentPage
{
    public CambiarContraseñaPage(CambiarContraseñaViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}