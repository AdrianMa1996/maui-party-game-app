using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface IGameModeAndCardSetBindingRepository
    {
        public Task<List<GameModeAndCardSetBinding>> GetGameModeAndCardSetBindingsByGameModeIdAsync(int gameModeId);

        public Task UpdateGameModeAndCardSetBindingsAsync(List<GameModeAndCardSetBinding> gameModeAndCardSetBindingList);
    }
}
