using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using XamarinMOTG.Model;

namespace XamarinMOTG.Connections
{
    public static class LoginService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<User>();
            
        }

        public static async Task AddUser(string uname, string pw, string email)
        {
            await Init();
            var usr = new User
            {
                Name = uname,
                Password = pw,
                Email = email
            };
            var id = await db.InsertAsync(usr);
        }

        public static async Task RemoveUser(int id)
        {
            await Init();
            
            await db.DeleteAsync<User>(id);
        }

        public static async Task UpdateUser(int id, string email, string pw)
        {
            await Init();
        }

        public static async Task<IEnumerable<User>> GetUser(string uname, string pw)
        {
            await Init();

            var res = await db.QueryAsync<User>("SELECT * FROM User WHERE Name = ? AND Passowrd = ?", uname, pw);
            foreach (var usr in res)
                Console.WriteLine("Id: " + usr.Id);
            return res;
        }

    }
}
