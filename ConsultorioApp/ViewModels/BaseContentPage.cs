using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.Views;

public abstract class BaseContentPage<TViewModel> : ContentPage where TViewModel : ObservableObject
{
    protected BaseContentPage(TViewModel viewModel)
    {
        base.BindingContext = viewModel;
    }

    protected new TViewModel BindingContext => (TViewModel)base.BindingContext;
}