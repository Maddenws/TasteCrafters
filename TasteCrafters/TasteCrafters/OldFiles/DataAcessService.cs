using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TasteCrafters.Models;
using Xamarin.Essentials;

namespace TasteCrafters.Services
{
    public static class DataAcessService
    {
        static SQLiteAsyncConnection _db;
        public static async Task Init()
        {
            if (_db != null)
                return;

            var database = Path.Combine(FileSystem.AppDataDirectory, "TasteCrafters.db");

             _db = new SQLiteAsyncConnection(database);

            if (await IsTableEmpty<MeatModel>())
                await _db.CreateTableAsync<MeatModel>();

            if (await IsTableEmpty<BeansAndLegumesModel>())
                await _db.CreateTableAsync<BeansAndLegumesModel>();

            if (await IsTableEmpty<SeafoodModel>())
                await _db.CreateTableAsync<SeafoodModel>();

            if (await IsTableEmpty<ProduceModel>())
                await _db.CreateTableAsync<ProduceModel>();

            if (await IsTableEmpty<PoultryModel>())
                await _db.CreateTableAsync<PoultryModel>();

            if (await IsTableEmpty<RiceAndGrainsModel>())
                await _db.CreateTableAsync<RiceAndGrainsModel>();

        }

        public static async Task InsertItemsAsync<T>(List<T> items)
        {
            await _db.InsertAllAsync(items);
        }

        public static async Task<bool> IsTableEmpty<T>()where T : new()
        {
            int count = await _db.Table<T>().CountAsync();
            return count == 0;
        }

        public static async Task DropAllTablesTest()
        {
            await _db.DropTableAsync<MeatModel>();
            await _db.DropTableAsync<BeansAndLegumesModel>();
            await _db.DropTableAsync<SeafoodModel>();
            await _db.DropTableAsync<ProduceModel>();
            await _db.DropTableAsync<PoultryModel>();
            await _db.DropTableAsync<RiceAndGrainsModel>();
        }
    }
}
