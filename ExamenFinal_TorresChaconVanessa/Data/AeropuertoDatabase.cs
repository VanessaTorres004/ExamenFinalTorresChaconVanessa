using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ExamenFinal_TorresChaconVanessa.Models;


namespace ExamenFinal_TorresChaconVanessa.Data
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Aeropuerto>().Wait();
        }

        public Task<List<Aeropuerto>> GetAeropuertosAsync()
        {
            return _database.Table<Aeropuerto>().ToListAsync();
        }

        public Task<int> SaveAeropuertoAsync(Aeropuerto aeropuerto)
        {
            return _database.InsertAsync(aeropuerto);
        }

        public Task<int> DeleteAeropuertoAsync(Aeropuerto aeropuerto)
        {
            return _database.DeleteAsync(aeropuerto);
        }
    }
}

