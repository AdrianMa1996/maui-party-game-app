using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface IPlayedGameRepository
    {
        public Task AddPlayedGameAsync(PlayedGame playedGame);
        public Task<List<PlayedGame>> GetLast3PlayedGamesAsync();
    }
}
