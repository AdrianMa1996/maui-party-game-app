using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface IExtensionRepository
    {
        public Task<List<Extension>> GetExtensionsAsync();
    }
}
