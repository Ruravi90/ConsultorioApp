using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultorioApp.Database
{
    public interface IStoreBase<T>
    {
        Task<bool> AnyAsync();
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(T item);
        Task<int> UpdateAsync(T item);
        Task<int> DeleteAsync(int id);
    }
}