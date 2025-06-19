using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultorioApp.ViewModels;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views;

public partial class RolesPage : ContentPage
{
    public RolesPage(RolesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}