using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Repositories;

namespace KnockKnockApp.Mapper
{
    public class GameModeMapper : IGameModeMapper
    {
        private readonly IGameModeAndCardSetBindingRepository _gameModeAndCardSetBindingRepository;
        private readonly ICardSetRepository _cardSetRepository;
        private readonly IGameCardRepository _gameCardRepository;

        public GameModeMapper(IGameModeAndCardSetBindingRepository gameModeAndCardSetBindingRepository, ICardSetRepository cardSetRepository, IGameCardRepository gameCardRepository)
        {
            _gameModeAndCardSetBindingRepository = gameModeAndCardSetBindingRepository;
            _cardSetRepository = cardSetRepository;
            _gameCardRepository = gameCardRepository;
        }

        public async Task<GameModeDto> ConvertToDtoAsync(GameMode gameMode)
        {
            var gameModeDto = new GameModeDto()
            {
                GameModeDetails = gameMode,
                CardSets = await GetCardSetDtoListAsync(gameMode)
            };
            return gameModeDto;
        }

        private async Task<List<CardSetDto>> GetCardSetDtoListAsync(GameMode gameMode)
        {
            var cardSetDtoList = new List<CardSetDto>();

            var gameModeAndCardSetBindingList = await _gameModeAndCardSetBindingRepository.GetGameModeAndCardSetBindingsByGameModeIdAsync(gameMode.GameModeID);

            foreach (var gameModeAndCardSetBinding in gameModeAndCardSetBindingList)
            {
                var cardSet = await _cardSetRepository.GetCardSetByIdAsync(gameModeAndCardSetBinding.CardSetID);
                var gameCardList = await _gameCardRepository.GetGameCardListByCardSetIdAsync(cardSet.CardSetID);
                var cardSetDto = new CardSetDto()
                {
                    CardSetDetails = cardSet,
                    GameModeBindingDetails = gameModeAndCardSetBinding,
                    GameModeDetails = gameMode,
                    GameCards = gameCardList
                };

                cardSetDtoList.Add(cardSetDto);
            }

            return cardSetDtoList;
        }
    }
}
