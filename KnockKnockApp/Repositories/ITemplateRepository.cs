using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface ITemplateRepository
    {
        public Task<List<Template>> GetTemplatesByGameModeIdAsync(int gameModeId);
    }
}
