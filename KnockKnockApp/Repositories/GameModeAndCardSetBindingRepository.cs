using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class GameModeAndCardSetBindingRepository : IGameModeAndCardSetBindingRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public GameModeAndCardSetBindingRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public async Task<List<GameModeAndCardSetBinding>> GetGameModeAndCardSetBindingsByGameModeIdAsync(int gameModeId)
        {
            var gameModeAndCardSetBindingList = await _dbConnection.Table<GameModeAndCardSetBinding>().Where(binding => binding.GameModeID == gameModeId).ToListAsync();
            return gameModeAndCardSetBindingList;
        }

        public async Task UpdateGameModeAndCardSetBindingsAsync(List<GameModeAndCardSetBinding> gameModeAndCardSetBindingList)
        {
            await _dbConnection.UpdateAllAsync(gameModeAndCardSetBindingList);
        }
    }
}
