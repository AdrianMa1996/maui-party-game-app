using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface ICardSetRepository
    {
        public Task<CardSet> GetCardSetByIdAsync(int cardSetId);
    }
}
