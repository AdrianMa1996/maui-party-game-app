using KnockKnockApp.Models.Database;
using SQLite;

namespace KnockKnockApp.Repositories
{
    public class TemplateSlotRepository : ITemplateSlotRepository
    {
        private SQLiteAsyncConnection _dbConnection;

        public TemplateSlotRepository()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.sqlite");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
            }
        }

        public async Task<List<TemplateSlot>> GetTemplateSlotsByTemplateIdAsync(int templateId)
        {
            var templateSlotList = await _dbConnection.Table<TemplateSlot>().Where(templateSlot => templateSlot.TemplateID == templateId).OrderBy(templateSlot => templateSlot.SlotNumber).ToListAsync();
            return templateSlotList;
        }
    }
}
