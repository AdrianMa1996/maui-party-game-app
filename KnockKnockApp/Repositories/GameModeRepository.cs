using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class GameModeRepository : IGameModeRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public GameModeRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public async Task<List<GameMode>> GetGameModesAsync()
        {
            var gameModeList = await _dbConnection.Table<GameMode>().ToListAsync();
            return gameModeList;
        }
    }
}
