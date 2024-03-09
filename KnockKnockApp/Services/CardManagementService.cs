using KnockKnockApp.Mapper;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Repositories;

namespace KnockKnockApp.Services
{
    public class CardManagementService : ICardManagementService
    {
        private readonly IGameModeMapper _gameModeMapper;
        private readonly IGameCardMapper _gameCardMapper;
        private readonly IGameCardRepository _gameCardRepository;
        private readonly IPlayerManagementService _playerManagementService;

        private Random _random = new Random();

        private GameModeDto? _gameModeDto;
        private Stack<GameCard?> _cardDeck = new();
        private List<GameCard> _usedCards = [];

        public CardManagementService(IGameModeMapper gameModeMapper, IGameCardMapper gameCardMapper, IGameCardRepository gameCardRepository, IPlayerManagementService playerManagementService)
        {
            _gameModeMapper = gameModeMapper;
            _gameCardMapper = gameCardMapper;
            _gameCardRepository = gameCardRepository;
            _playerManagementService = playerManagementService;
        }

        public async Task SetupAsync(GameMode gameMode)
        {
            _gameModeDto = await _gameModeMapper.ConvertToDtoAsync(gameMode);
            _cardDeck = new Stack<GameCard?>();
            _usedCards = new List<GameCard>();

            InitializeCardDeckWithNullCards();

            await PlaceFollowUpCardsAsync(_gameModeDto.GameModeDetails.StartingCardID);
            await PlaceFollowUpCardsAsync(_gameModeDto.GameModeDetails.FinisherCardID, _cardDeck.Count);
        }

        public async Task<GameCardDto?> DrawNextCardAsync()
        {
            if (_cardDeck.Count == 0) // wenn _cardDeck ist empty: Spielende (return null)
            {
                return null;
            }

            var gameCard = _cardDeck.Pop();
            if (gameCard == null)
            {
                gameCard = GetRandomCard();
                await PlaceFollowUpCardsAsync(gameCard.FollowUpCardID, gameCard.IntervalToFollowUp);
            }

            _usedCards.Add(gameCard);

            return await _gameCardMapper.ConvertToDtoAsync(gameCard);
        }

        private void InitializeCardDeckWithNullCards()
        {
            for (int i = 0; i < _gameModeDto.GameModeDetails.NumberOfGameCards; i++)
            {
                _cardDeck.Push(null);
            }
        }

        private async Task PlaceFollowUpCardsAsync(int followUpCardID, int followUpInterval = 0)
        {
            while (followUpCardID != 0)
            {
                var gameCard = await _gameCardRepository.GetGameCardByIdAsync(followUpCardID);
                PlaceCardInCardDeck(gameCard, followUpInterval);
                followUpCardID = gameCard.FollowUpCardID;
                followUpInterval = gameCard.IntervalToFollowUp;
            }
        }

        private void PlaceCardInCardDeck(GameCard gameCard, int cardDepth = 0)
        {
            if (cardDepth >= 0)
            {
                Stack<GameCard?> tempStack = new Stack<GameCard?>();

                while (cardDepth != 0 && _cardDeck.Count > 0)
                {
                    var drawnCard = _cardDeck.Pop();
                    tempStack.Push(drawnCard);
                    cardDepth = cardDepth - 1;
                }

                _cardDeck.Push(gameCard); // Problem: Karte wird eventuell hinter der Spiel-Ende karte gepushed

                while (tempStack.Count > 0)
                {
                    _cardDeck.Push(tempStack.Pop());
                }
            }
        }

        private GameCard GetRandomCard()
        {
            var gameCard = new GameCard();
            var isValidForPlay = false;
            while (isValidForPlay == false)
            {
                var cardSet = GetRandomActivatedCardSet();
                int randomNumber = _random.Next(cardSet.GameCards.Count);
                gameCard = cardSet.GameCards[randomNumber];
                if (gameCard.RequiredPlayedCardCount <= _usedCards.Count && gameCard.RequiredPlayerCount <= _playerManagementService.GetAllPlayers().Count && !_usedCards.Contains(gameCard))
                {
                    isValidForPlay = true;
                }
            }

            return gameCard;
        }

        private CardSetDto? GetRandomActivatedCardSet()
        {
            int totalProbability = 0;
            foreach (var cardSet in _gameModeDto.CardSets)
            {
                if (cardSet.GameModeBindingDetails.IsActivated)
                {
                    totalProbability += cardSet.GameModeBindingDetails.CardSetOccurrence;
                }
            }

            int randomNumber = _random.Next(totalProbability);

            foreach (var cardSet in _gameModeDto.CardSets)
            {
                if (cardSet.GameModeBindingDetails.IsActivated)
                {
                    if (randomNumber < cardSet.GameModeBindingDetails.CardSetOccurrence)
                    {
                        return cardSet;
                    }
                    randomNumber -= cardSet.GameModeBindingDetails.CardSetOccurrence;
                }
            }

            return null; // dürfte eigentlich nie passieren
        }
    }
}
