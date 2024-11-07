using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class ExtensionCardRepository : IExtensionCardRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public ExtensionCardRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public Task<ExtensionCard> GetExtensionCardByIdAsync(int extensionCardId) => _dbConnection.GetAsync<ExtensionCard>(extensionCardId);

        public async Task<List<ExtensionCard>> GetExtensionCardListByExtensionCardSetIdAsync(int extensionCardSetId)
        {
            var extensionAndExtensionCardSetBindingList = await _dbConnection.Table<ExtensionCard>().Where(extensionCard => extensionCard.ExtensionCardSetID == extensionCardSetId).ToListAsync();
            return extensionAndExtensionCardSetBindingList;
        }
    }
}
