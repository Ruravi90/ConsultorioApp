using System;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace ConsultorioApp.Helpers
{
    public static class SQLiteExtensions
    {
        public static async Task<bool> AnyAsync<T>(this SQLiteAsyncConnection connection) where T : class, new()
        {
            var count = await connection.Table<T>().CountAsync();
            return count > 0;
        }

        public static async Task<bool> AnyAsync<T>(this SQLiteAsyncConnection connection, Func<T, bool> predicate) where T : class, new()
        {
            var items = await connection.Table<T>().ToListAsync();
            return items.Any(predicate);
        }
    }
}