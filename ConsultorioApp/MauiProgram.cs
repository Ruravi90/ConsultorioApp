using CommunityToolkit.Maui;
using ConsultorioApp.Data;
using ConsultorioApp.Helpers;
using ConsultorioApp.ViewModels;
using ConsultorioApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace ConsultorioApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        // Inicializa la base de datos
        DatabaseHelper.InicializarAsync();
        builder.Services.AddDbContext<AppDbContext>();
        
        Routing.RegisterRoute("main",typeof(MainPage));
        Routing.RegisterRoute("login",typeof(LoginPage));
        Routing.RegisterRoute("registro",typeof(RegistroPage));

#if DEBUG
        builder.Logging.AddDebug();
#endif
        
        return builder.Build();
    }
}