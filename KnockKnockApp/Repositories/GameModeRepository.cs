using KnockKnockApp.Models.Database;
using KnockKnockApp.Services;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class GameModeRepository : IGameModeRepository
    {
        private SQLiteAsyncConnection _dbConnection;
        private ILocalizationService _localizationService;

        public GameModeRepository(ILocalizationService localizationService)
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }

            _localizationService = localizationService;
        }

        public async Task<List<GameMode>> GetGameModesAsync(bool getTeamModes = true, bool getSoloModes = true)
        {
            var cultureCode = _localizationService.GetCurrentLocalization().Culture.Name;
            var gameModeList = await _dbConnection.Table<GameMode>().Where(gameMode => gameMode.Language == cultureCode).ToListAsync();
            if (gameModeList.Count == 0)
            {
                gameModeList = await _dbConnection.Table<GameMode>().Where(gameMode => gameMode.Language == "en-GB").ToListAsync();
            }

            if (getTeamModes == true && getSoloModes == false)
            {
                gameModeList = gameModeList.Where(gameMode => gameMode.IsTeamGameMode == true).ToList();
            }

            if (getTeamModes == false && getSoloModes == true)
            {
                gameModeList = gameModeList.Where(gameMode => gameMode.IsTeamGameMode == false).ToList();
            }

            return gameModeList;
        }
    }
}
