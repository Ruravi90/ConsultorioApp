using System.IO;
using System.Threading.Tasks;
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
using SQLite;
using Syncfusion.Maui.Toolkit.Hosting;

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
        
        
        // BD
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "consultorio.db");
        builder.Services.AddSingleton<SQLiteAsyncConnection>(sp => 
            new SQLiteAsyncConnection(dbPath));

        // Stores
        builder.Services.AddSingleton<IUsuarioStore, UsuarioStore>();
        builder.Services.AddSingleton<ICitaStore, CitaStore>();
        builder.Services.AddSingleton<IPacienteStore, PacienteStore>();
        builder.Services.AddSingleton<IRolStore, RolStore>();
        builder.Services.AddSingleton<IConsultaStore, ConsultaStore>();
        
        // Registra AppDatabase primero ↑↑↑
        builder.Services.AddSingleton<AppDatabase>(sp =>
        {
            var connection = sp.GetRequiredService<SQLiteAsyncConnection>();
            return new AppDatabase(connection);
        });
        
        // Services
        builder.Services.AddSingleton<IUsuarioService,UsuarioService>();
        builder.Services.AddSingleton<IRolService,RolService>();
        builder.Services.AddSingleton<IPacienteService,PacienteService>();
        builder.Services.AddSingleton<ICitaService,CitaService>();
        builder.Services.AddSingleton<IConsultaService,ConsultaService>();
        
        // Inserta datos iniciales
        Task.Run(async () => await DatabaseHelper.InicializarAsync(dbPath)).Wait();
        
        // Registra el SessionManager como singleton
        builder.Services.AddSingleton<ISessionManager, SessionManager>();

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegistroViewModel>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<RolesViewModel>();
        builder.Services.AddTransient<PerfilViewModel>();
        builder.Services.AddTransient<CambiarContraseñaViewModel>();
        builder.Services.AddTransient<UsuariosViewModel>();
        builder.Services.AddTransient<ConsultaViewModel>();
        
        Routing.RegisterRoute("main",typeof(MainPage));
        Routing.RegisterRoute("login",typeof(LoginPage));
        Routing.RegisterRoute("registro",typeof(RegistroPage));
        Routing.RegisterRoute("consulta",typeof(ConsultaPage));
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