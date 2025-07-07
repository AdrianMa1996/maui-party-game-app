using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Repositories
{
    public interface IGameModeRepository
    {
        public Task<List<GameMode>> GetGameModesAsync(bool getTeamModes = true, bool getSoloModes = true);
    }
}
