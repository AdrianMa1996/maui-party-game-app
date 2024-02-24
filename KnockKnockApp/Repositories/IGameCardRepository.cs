using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface IGameCardRepository
    {
        public Task<GameCard> GetGameCardByIdAsync(int gameCardId);

        public Task<List<GameCard>> GetGameCardListByCardSetIdAsync(int cardSetId);
    }
}
