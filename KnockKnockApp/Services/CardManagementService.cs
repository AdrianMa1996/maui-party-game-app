using KnockKnockApp.Mapper;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Repositories;

namespace KnockKnockApp.Services
{
    public class CardManagementService : ICardManagementService
    {
        private readonly IGameModeMapper _gameModeMapper;
        private readonly ICardSetMapper _cardSetMapper;
        private readonly IGameCardMapper _gameCardMapper;
        private readonly IGameCardRepository _gameCardRepository;
        private readonly ICardSetRepository _cardSetRepository;
        private readonly IPlayerManagementService _playerManagementService;
        private readonly ITeamManagementService _teamManagementService;
        private readonly ICardTextPlaceholderService _cardTextPlaceholderService;
        private readonly IPlayedCardRepository _playedCardRepository;
        private readonly IPlayedGameRepository _playedGameRepository;

        private Random _random = new Random();

        private GameModeDto? _gameModeDto;
        private Stack<GameCard?> _cardDeck = new();
        private bool isGameOver = false;

        public int templateSize = 0;
        public int numberOfPlayedTemplateCards = 0;

        public CardManagementService(IGameModeMapper gameModeMapper, ICardSetMapper cardSetMapper, IGameCardMapper gameCardMapper, IGameCardRepository gameCardRepository, ICardSetRepository cardSetRepository, IPlayerManagementService playerManagementService, ICardTextPlaceholderService cardTextPlaceholderService, ITeamManagementService teamManagementService, IPlayedCardRepository playedCardRepository, IPlayedGameRepository playedGameRepository)
        {
            _gameModeMapper = gameModeMapper;
            _cardSetMapper = cardSetMapper;
            _gameCardMapper = gameCardMapper;
            _gameCardRepository = gameCardRepository;
            _cardSetRepository = cardSetRepository;
            _playerManagementService = playerManagementService;
            _cardTextPlaceholderService = cardTextPlaceholderService;
            _teamManagementService = teamManagementService;
            _playedCardRepository = playedCardRepository;
            _playedGameRepository = playedGameRepository;
        }

        public async Task SetupAsync(GameMode gameMode)
        {
            _gameModeDto = await _gameModeMapper.ConvertToDtoAsync(gameMode);
            _cardDeck = new Stack<GameCard?>();

            InitializeCardDeckWithTemplateCards();

            _cardTextPlaceholderService.SetupAndShuffleLists();

            await PlaceFollowUpCardsAsync(_gameModeDto.GameModeDetails.StartingCardID);
            await PlaceFollowUpCardsAsync(_gameModeDto.GameModeDetails.FinisherCardID, _cardDeck.Count, true);
        }

        public async Task<GameCardDto?> DrawNextCardAsync()
        {
            _cardTextPlaceholderService.SetupAndShuffleLists();

            if (_cardDeck.Count == 0 || isGameOver)
            {
                await _playedGameRepository.AddPlayedGameAsync(new PlayedGame()
                {
                    GameModeID = _gameModeDto.GameModeDetails.GameModeID,
                    TemplateID = _gameModeDto.TemplateDetails.TemplateID,
                });
                return null;
            }

            var gameCard = _cardDeck.Pop();
            if (gameCard.GameCardID == 0)
            {
                gameCard = await GetRandomTemplateCardAsync(gameCard);
                numberOfPlayedTemplateCards = numberOfPlayedTemplateCards + 1;
                PlaceCardInCardDeck(gameCard);
                await PlaceFollowUpCardsAsync(gameCard.FollowUpCardID, gameCard.IntervalToFollowUp);
                gameCard = _cardDeck.Pop();
                await _playedCardRepository.AddPlayedCardAsync(new PlayedCard()
                {
                    GameCardID = gameCard.GameCardID,
                });
            }

            gameCard = _cardTextPlaceholderService.ResolveWinningTeamPlaceholders(gameCard);
            gameCard = _cardTextPlaceholderService.ResolveLosingTeamPlaceholders(gameCard);

            var gameCardDto = await _gameCardMapper.ConvertToDtoAsync(gameCard);

            if (gameCardDto.CardSetDetails.Category == CardSetCategory.GameOver)
            {
                isGameOver = true;
            }

            return gameCardDto;
        }

        private void InitializeCardDeckWithTemplateCards()
        {
            var reversedTemplateSlots = _gameModeDto.TemplateSlots;
            reversedTemplateSlots.Reverse();
            foreach (var templateSlot in reversedTemplateSlots)
            {
                _cardDeck.Push(new GameCard()
                {
                    GameCardID = 0, // Template: ID = 0
                    CardSetID = templateSlot.CardSetID,
                    CardText = "TemplateCard",
                    RequiredPlayers = 0,
                    FollowUpCardID = 0,
                    IntervalToFollowUp = 0,
                });
            }
            templateSize = _gameModeDto.TemplateSlots.Count;
        }

        private async Task PlaceFollowUpCardsAsync(int followUpCardID, int followUpInterval = 0, bool belongsToFinisherCard = false)
        {
            while (followUpCardID != 0)
            {
                var gameCard = await _gameCardRepository.GetGameCardByIdAsync(followUpCardID);
                PlaceCardInCardDeck(gameCard, followUpInterval, belongsToFinisherCard);
                followUpCardID = gameCard.FollowUpCardID;
                followUpInterval = followUpInterval + gameCard.IntervalToFollowUp;
            }
        }

        private void PlaceCardInCardDeck(GameCard gameCard, int cardDepth = 0, bool belongsToFinisherCard = false)
        {
            if (cardDepth >= 0)
            {
                Stack<GameCard?> tempStack = new Stack<GameCard?>();

                while (cardDepth != 0 && _cardDeck.Count > 0)
                {
                    var drawnCard = _cardDeck.Pop();
                    if (drawnCard.GameCardID == _gameModeDto.GameModeDetails.FinisherCardID && !belongsToFinisherCard)
                    {
                        _cardDeck.Push(drawnCard);
                        break;
                    }
                    tempStack.Push(drawnCard);
                    cardDepth = cardDepth - 1;
                }

                gameCard = _cardTextPlaceholderService.ResolvePlayerPlaceholders(gameCard);
                gameCard = _cardTextPlaceholderService.ResolvePointValuePlaceholders(gameCard);
                gameCard = _cardTextPlaceholderService.ResolveTeamPlaceholders(gameCard);
                gameCard = _cardTextPlaceholderService.ResolvePlayerTeam1Placeholders(gameCard);
                gameCard = _cardTextPlaceholderService.ResolvePlayerTeam2Placeholders(gameCard);

                _cardDeck.Push(gameCard);

                while (tempStack.Count > 0)
                {
                    _cardDeck.Push(tempStack.Pop());
                }
            }
        }

        private async Task<GameCard> GetRandomTemplateCardAsync(GameCard gameCard)
        {
            var isValidForPlay = false;
            var numberOfAttempts = 0;
            while (isValidForPlay == false)
            {
                numberOfAttempts = numberOfAttempts + 1;
                if(numberOfAttempts <= 20)
                {
                    var cardSet = await _cardSetRepository.GetCardSetByIdAsync(gameCard.CardSetID);
                    var cardSetDto = await _cardSetMapper.ConvertToDtoAsync(cardSet);
                    int randomNumber = _random.Next(cardSetDto.GameCards.Count);
                    gameCard = cardSetDto.GameCards[randomNumber];
                    isValidForPlay = await CheckIfGameCardIsValidCardAsync(gameCard);
                }
                else
                {
                    var cardSet = await _cardSetRepository.GetCardSetByIdAsync(_gameModeDto.GameModeDetails.FallbackCardSet);
                    var cardSetDto = await _cardSetMapper.ConvertToDtoAsync(cardSet);
                    int randomNumber = _random.Next(cardSetDto.GameCards.Count);
                    gameCard = cardSetDto.GameCards[randomNumber];
                    isValidForPlay = true;
                }
            }

            return gameCard;
        }

        private async Task<bool> CheckIfGameCardIsValidCardAsync(GameCard gameCard)
        {
            if (gameCard.RequiredPlayers > _playerManagementService.GetAllPlayers().Count)
            {
                return false;
            }

            if (_gameModeDto.GameModeDetails.IsTeamGameMode && (gameCard.RequiredPlayers > _teamManagementService.GetTeamOne().TeamMembers.Count || gameCard.RequiredPlayers > _teamManagementService.GetTeamTwo().TeamMembers.Count))
            {
                return false;
            }

            var last100PlayedCards = await _playedCardRepository.GetLast80PlayedCardsAsync();
            if (last100PlayedCards.Any(pc => pc.GameCardID== gameCard.GameCardID))
            {
                return false;
            }

            return true;
        }

        public int GetTemplateSize()
        {
            return templateSize;
        }

        public int GetNumberOfPlayedTemplateCards()
        {
            return numberOfPlayedTemplateCards;
        }
    }
}
