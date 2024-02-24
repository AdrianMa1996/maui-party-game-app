using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class GameCardRepository : IGameCardRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public GameCardRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public Task<GameCard> GetGameCardByIdAsync(int gameCardId) => _dbConnection.GetAsync<GameCard>(gameCardId);

        public async Task<List<GameCard>> GetGameCardListByCardSetIdAsync(int cardSetId)
        {
            var gameModeAndCardSetBindingList = await _dbConnection.Table<GameCard>().Where(gameCard => gameCard.CardSetID == cardSetId).ToListAsync();
            return gameModeAndCardSetBindingList;
        }
    }
}
