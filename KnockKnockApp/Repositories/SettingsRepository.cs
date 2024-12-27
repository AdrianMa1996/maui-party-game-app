using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public SettingsRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public Task<Settings> GetSettingsAsync() => _dbConnection.GetAsync<Settings>(1);

        public async Task UpdateSettingsAsync(Settings settings)
        {
            await _dbConnection.UpdateAsync(settings);
        }
    }
}
