using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsultorioApp.Models;

namespace ConsultorioApp.Database
{
    public interface IUsuarioStore
    {
        Task<Usuario> GetPorNombreUsuario(string nombreUsuario);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task<int> AddAsync(Usuario item);
        Task<int> UpdateAsync(Usuario item);
        Task<int> DeleteAsync(Usuario item);
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(Func<Usuario, bool> predicate);
    }
}