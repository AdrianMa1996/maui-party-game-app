using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Mapper
{
    public interface IGameCardMapper
    {
        public Task<GameCardDto> ConvertToDtoAsync(GameCard gameCard);
    }
}
