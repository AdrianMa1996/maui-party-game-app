using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface IExtensionCardSetRepository
    {
        public Task<ExtensionCardSet> GetExtensionCardSetByIdAsync(int extensionCardSetId);
    }
}
