using NuGet.Common;
using PlanTechShenApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanTechShenApp.Data
{
    public class PlantItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<PlantItemDatabase> Instance = new AsyncLazy<PlantItemDatabase>(async () =>
        {
            var instance = new PlantItemDatabase();
            CreateTableResult result = await Database.CreateTableAsync<PlantItems>();
            return instance;
        });

        public PlantItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<PlantItems>> GetItemsAsync()
        {
            return Database.Table<PlantItems>().ToListAsync();
        }

        public Task<List<PlantItems>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<PlantItems>("SELECT * FROM [PlantItems] WHERE [Done] = 0");
        }

        public Task<PlantItems> GetItemAsync(int id)
        {
            return Database.Table<PlantItems>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(PlantItems item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(PlantItems item)
        {
            return Database.DeleteAsync(item);
        }
    }
}

 
