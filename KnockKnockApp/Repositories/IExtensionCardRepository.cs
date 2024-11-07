using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface IExtensionCardRepository
    {
        public Task<ExtensionCard> GetExtensionCardByIdAsync(int extensionCardId);
        public Task<List<ExtensionCard>> GetExtensionCardListByExtensionCardSetIdAsync(int extensionCardSetId);
    }
}
