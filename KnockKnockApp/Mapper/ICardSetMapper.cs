using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Mapper
{
    public interface ICardSetMapper
    {
        public Task<CardSetDto> ConvertToDtoAsync(CardSet cardSet);
    }
}
