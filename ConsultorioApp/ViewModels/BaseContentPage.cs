using CommunityToolkit.Mvvm.ComponentModel;
namespace ConsultorioApp.Views;

public abstract class BaseContentPage<TViewModel> : ContentPage where TViewModel : ObservableObject
{
    protected BaseContentPage(TViewModel viewModel)
    {
        base.BindingContext = viewModel;
    }

    protected new TViewModel BindingContext => (TViewModel)base.BindingContext;
}