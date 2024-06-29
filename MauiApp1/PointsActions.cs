using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp1
{
    public class PointsActions
    {
        SQLiteAsyncConnection Database;

        public PointsActions()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<User>();
        }

        public async Task<List<User>> GetPointsAsync()
        {
            await Init();
            return await Database.Table<User>().ToListAsync();
        }
        public async Task<int> DeleteItemAsync(User user)
        {
            await Init();
            return await Database.DeleteAsync(user);
        }

        public async Task<User> GetPointsAsync(int id)
        {
            await Init();
            return await Database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(User user)
        {
            await Init();
            if (user.Id != 0)
                return await Database.UpdateAsync(user);
            else
                return await Database.InsertAsync(user);
        }
    }
}
