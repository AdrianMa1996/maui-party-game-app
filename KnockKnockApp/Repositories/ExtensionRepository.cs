using KnockKnockApp.Models.Database;
using KnockKnockApp.Services;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class ExtensionRepository : IExtensionRepository
    {
        private SQLiteAsyncConnection _dbConnection;
        private ILocalizationService _localizationService;

        public ExtensionRepository(ILocalizationService localizationService)
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }

            _localizationService = localizationService;
        }

        public async Task<List<Extension>> GetExtensionsAsync()
        {
            var cultureCode = _localizationService.GetCurrentLocalization().Culture.Name;
            var extensionList = await _dbConnection.Table<Extension>().Where(extension => extension.Language == cultureCode).ToListAsync();
            if (extensionList.Count == 0)
            {
                extensionList = await _dbConnection.Table<Extension>().Where(extension => extension.Language == "en-GB").ToListAsync();
            }

            return extensionList;
        }
    }
}
