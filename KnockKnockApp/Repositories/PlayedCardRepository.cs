using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class PlayedCardRepository : IPlayedCardRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public PlayedCardRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public async Task AddPlayedCardAsync(PlayedCard playedCard)
        {
            await _dbConnection.InsertAsync(playedCard);
        }


        public async Task<List<PlayedCard>> GetLast80PlayedCardsAsync()
        {
            var playedCardList = await _dbConnection.Table<PlayedCard>().OrderByDescending(card => card.PlayedCardID).Take(80).ToListAsync();
            return playedCardList;
        }
    }
}
