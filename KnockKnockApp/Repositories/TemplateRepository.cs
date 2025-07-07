using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public TemplateRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public async Task<List<Template>> GetTemplatesByGameModeIdAsync(int gameModeId)
        {
            var templateList = await _dbConnection.Table<Template>().Where(template => template.GameModeID == gameModeId).ToListAsync();
            return templateList;
        }
    }
}
