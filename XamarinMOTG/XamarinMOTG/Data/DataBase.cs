using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinMOTG.Model;

namespace XamarinMOTG.Data
{
    public class DataBase
    {
        private readonly SQLiteAsyncConnection _dataBase;
        public DataBase(string dbpath)
        {
            _dataBase = new SQLiteAsyncConnection(dbpath);
            _dataBase.CreateTableAsync<User>();
            _dataBase.CreateTableAsync<Set>();
            _dataBase.CreateTableAsync<Language>();
            _dataBase.CreateTableAsync<Card>();
            _dataBase.CreateTableAsync<Bid>();
            _dataBase.CreateTableAsync<Advertisement>();
        }
        
        
    }
}