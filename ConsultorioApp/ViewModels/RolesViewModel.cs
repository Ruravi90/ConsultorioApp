using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ConsultorioApp.Interfaces;
using ConsultorioApp.Models;
using Microsoft.Maui.Controls;

namespace ConsultorioApp.ViewModels
{
    public partial class RolesViewModel : ObservableObject
    {
        private readonly IRolService _rolService;

        public ObservableCollection<Rol> Roles { get; set; } = new();

        public RolesViewModel(IRolService rolService)
        {
            _rolService = rolService;
            CargarRoles();
        }

        private async Task CargarRoles()
        {
            var lista = await _rolService.GetAllAsync();
            foreach (var r in lista)
            {
                Roles.Add(r);
            }
        }

        [RelayCommand]
        private async Task NuevoRol()
        {
            string nombre = await Shell.Current.DisplayPromptAsync("Nuevo Rol", "Nombre del rol:");
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                var nuevo = new Rol { Nombre = nombre };
                await _rolService.AddAsync(nuevo);
                Roles.Add(nuevo);
            }
        }

        [RelayCommand]
        private async Task EditarRol(Rol rol)
        {
            string nuevoNombre = await Shell.Current.DisplayPromptAsync("Editar Rol", "Nuevo nombre:", initialValue: rol.Nombre);
            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                rol.Nombre = nuevoNombre;
                await _rolService.UpdateAsync(rol);
            }
        }
        [RelayCommand]
        private async Task EliminarRol(Rol rol)
        {
            bool confirmado = await Shell.Current.DisplayAlert("Confirmar", $"¿Eliminar el rol '{rol.Nombre}'?", "Sí", "No");
            if (confirmado)
            {
                await _rolService.DeleteAsync(rol.Id);
                Roles.Remove(rol);
            }
        }
    }
}