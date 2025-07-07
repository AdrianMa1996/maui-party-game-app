using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface IPlayedCardRepository
    {
        public Task AddPlayedCardAsync(PlayedCard playedCard);
        public Task<List<PlayedCard>> GetLast80PlayedCardsAsync();
    }
}
