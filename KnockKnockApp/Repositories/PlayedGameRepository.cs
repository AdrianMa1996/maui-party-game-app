using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class PlayedGameRepository : IPlayedGameRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public PlayedGameRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public async Task AddPlayedGameAsync(PlayedGame playedGame)
        {
            await _dbConnection.InsertAsync(playedGame);
        }

        public async Task<List<PlayedGame>> GetLast3PlayedGamesAsync()
        {
            var playedGameList = await _dbConnection.Table<PlayedGame>().OrderByDescending(game => game.PlayedGameID).Take(3).ToListAsync();
            return playedGameList;
        }
    }
}
