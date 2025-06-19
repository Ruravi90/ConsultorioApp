using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace ConsultorioApp.Database
{
    public abstract class BaseStore<T> where T : class, new()
    {
        protected readonly SQLiteAsyncConnection Connection;

        protected BaseStore(SQLiteAsyncConnection connection)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
            Initialize();
        }

        private async void Initialize()
        {
            await Connection.CreateTableAsync<T>();
        }

        #region Métodos reutilizables

        public async Task<List<T>> GetAllAsync()
        {
            return await Connection.Table<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Connection.FindAsync<T>(id);
        }

        public async Task<int> AddAsync(T item)
        {
            return await Connection.InsertAsync(item);
        }

        public async Task<int> UpdateAsync(T item)
        {
            return await Connection.UpdateAsync(item);
        }

        public async Task<int> DeleteAsync(T item)
        {
            return await Connection.DeleteAsync(item);
        }

        public async Task<bool> AnyAsync() => await Connection.Table<T>().CountAsync() > 0;

        public async Task<bool> AnyAsync(Func<T, bool> predicate)
        {
            var list = await Connection.Table<T>().ToListAsync();
            return list.Any(predicate);
        }

        #endregion
    }
}