using System.IO;
using CommunityToolkit.Maui;
using ConsultorioApp.Database;
using ConsultorioApp.Helpers;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Services;
using ConsultorioApp.ViewModels;
using ConsultorioApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Storage;

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

        var database = new AppDatabase();
        builder.Services.AddSingleton(database);
        // Inicializa la base de datos
        DatabaseHelper.InicializarAsync(database);
        
        builder.Services.AddSingleton<IUsuarioStore>(database.Usuarios);
        builder.Services.AddSingleton<IRolStore>(database.Roles);
        builder.Services.AddSingleton<ICitaStore>(database.Citas);
        builder.Services.AddSingleton<IPacienteStore>(database.Pacientes);
        
        // Registra el SessionManager como singleton
        builder.Services.AddSingleton<ISessionManager, SessionManager>();
        
        builder.Services.AddScoped<IUsuarioService, UsuarioService>();
        builder.Services.AddScoped<IRolService, RolService>();
        builder.Services.AddScoped<ICitaService, CitaService>();
        builder.Services.AddScoped<IPacienteService, PacienteService>();
        
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegistroViewModel>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<RolesViewModel>();
        builder.Services.AddTransient<PerfilViewModel>();
        builder.Services.AddTransient<CambiarContraseñaViewModel>();
        builder.Services.AddTransient<UsuariosViewModel>();
        
        Routing.RegisterRoute("main",typeof(MainPage));
        Routing.RegisterRoute("login",typeof(LoginPage));
        Routing.RegisterRoute("registro",typeof(RegistroPage));
        Routing.RegisterRoute("citas",typeof(CitasPage));
        Routing.RegisterRoute("citas/detalle",typeof(CitaDetallePage));
        Routing.RegisterRoute("pacientes",typeof(PacientesPage));
        Routing.RegisterRoute("pacientes/detalle",typeof(PacienteDetallePage));
        Routing.RegisterRoute("perfil",typeof(PerfilPage));
        Routing.RegisterRoute("CambiarContraseñaPage",typeof(CambiarContraseñaPage));
        Routing.RegisterRoute("roles",typeof(RolesPage));
        Routing.RegisterRoute("usuarios",typeof(UsuariosPage));

#if DEBUG
        builder.Logging.AddDebug();
#endif
        
        return builder.Build();
    }
}