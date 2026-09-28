using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MauiApp2
{
    public class DatabaseService
    {
        private const string databaseName = "";
        private readonly SQLiteAsyncConnection _connection;

        public DatabaseService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, databaseName));
            _connection.CreateTableAsync<Character>();
        }

        public async Task<List<Character>> GetCharacters()
        {
            return await _connection.Table<Character>().ToListAsync();
        }

        public async Task<Character> GetById(int id)
        {
            return await _connection.Table<Character>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Character character)
        {
            await _connection.InsertAsync(character);
        }

        public async Task Update(Character character)
        {
            await _connection.UpdateAsync(character);
        }

        public async Task Delete(Character character)
        {
            await _connection.DeleteAsync(character);
        }


    }
}
