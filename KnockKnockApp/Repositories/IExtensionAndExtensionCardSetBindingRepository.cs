using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface IExtensionAndExtensionCardSetBindingRepository
    {
        public Task<List<ExtensionAndExtensionCardSetBinding>> GetExtensionAndExtensionCardSetBindingsByExtensionIdAsync(int extensionId);
    }
}
