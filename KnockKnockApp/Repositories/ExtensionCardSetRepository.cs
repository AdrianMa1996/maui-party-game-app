using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class ExtensionCardSetRepository : IExtensionCardSetRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public ExtensionCardSetRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public Task<ExtensionCardSet> GetExtensionCardSetByIdAsync(int extensionCardSetId) => _dbConnection.GetAsync<ExtensionCardSet>(extensionCardSetId);
    }
}
