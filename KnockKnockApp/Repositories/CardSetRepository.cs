using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class CardSetRepository : ICardSetRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public CardSetRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public Task<CardSet> GetCardSetByIdAsync(int cardSetId) => _dbConnection.GetAsync<CardSet>(cardSetId);
    }
}
