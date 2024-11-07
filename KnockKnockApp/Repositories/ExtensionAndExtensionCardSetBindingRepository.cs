using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class ExtensionAndExtensionCardSetBindingRepository : IExtensionAndExtensionCardSetBindingRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public ExtensionAndExtensionCardSetBindingRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public async Task<List<ExtensionAndExtensionCardSetBinding>> GetExtensionAndExtensionCardSetBindingsByExtensionIdAsync(int extensionId)
        {
            var extensionAndExtensionCardSetBindingList = await _dbConnection.Table<ExtensionAndExtensionCardSetBinding>().Where(binding => binding.ExtensionID == extensionId).ToListAsync();
            return extensionAndExtensionCardSetBindingList;
        }
    }
}
