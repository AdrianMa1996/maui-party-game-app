using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Repositories;

namespace KnockKnockApp.Mapper
{
    public class CardSetMapper : ICardSetMapper
    {
        private readonly IGameCardRepository _gameCardRepository;

        public CardSetMapper(IGameCardRepository gameCardRepository)
        {
            _gameCardRepository = gameCardRepository;

        }

        public async Task<CardSetDto> ConvertToDtoAsync(CardSet cardSet)
        {
            var gameCardList = await _gameCardRepository.GetGameCardListByCardSetIdAsync(cardSet.CardSetID);
            return new CardSetDto()
            {
                CardSetDetails = cardSet,
                GameCards = gameCardList
            };
        }
    }
}
