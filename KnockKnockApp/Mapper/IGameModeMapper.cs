using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Mapper
{
    public interface IGameModeMapper
    {
        public Task<GameModeDto> ConvertToDtoAsync(GameMode gameMode);
    }
}
