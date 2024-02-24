using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Repositories;

namespace KnockKnockApp.Mapper
{
    public class GameCardMapper : IGameCardMapper
    {
        private readonly ICardSetRepository _cardSetRepository;

        public GameCardMapper(ICardSetRepository cardSetRepository)
        {
            _cardSetRepository = cardSetRepository;
        }

        public async Task<GameCardDto> ConvertToDtoAsync(GameCard gameCard)
        {
            var cardSet = await _cardSetRepository.GetCardSetByIdAsync(gameCard.CardSetID);
            return new GameCardDto()
            {
                GameCardDetails = gameCard,
                CardSetDetails = cardSet
            };
        }
    }
}
