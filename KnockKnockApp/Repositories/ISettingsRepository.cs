using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface ISettingsRepository
    {
        public Task<Settings> GetSettingsAsync();

        public Task UpdateSettingsAsync(Settings settings);
    }
}
