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
        private readonly ITeamManagementService _teamManagementService;
        private readonly ICardTextPlaceholderService _cardTextPlaceholderService;

        private Random _random = new Random();

        private GameModeDto? _gameModeDto;
        private Stack<GameCard?> _cardDeck = new();
        private List<GameCard> _usedCards = [];
        private bool isGameOver = false;

        public CardManagementService(IGameModeMapper gameModeMapper, IGameCardMapper gameCardMapper, IGameCardRepository gameCardRepository, IPlayerManagementService playerManagementService, ICardTextPlaceholderService cardTextPlaceholderService, ITeamManagementService teamManagementService)
        {
            _gameModeMapper = gameModeMapper;
            _gameCardMapper = gameCardMapper;
            _gameCardRepository = gameCardRepository;
            _playerManagementService = playerManagementService;
            _cardTextPlaceholderService = cardTextPlaceholderService;
            _teamManagementService = teamManagementService;
        }

        public async Task SetupAsync(GameMode gameMode)
        {
            _gameModeDto = await _gameModeMapper.ConvertToDtoAsync(gameMode);
            _cardDeck = new Stack<GameCard?>();
            _usedCards = new List<GameCard>();

            InitializeCardDeckWithNullCards();

            _cardTextPlaceholderService.SetupAndShuffleLists();

            await PlaceFollowUpCardsAsync(_gameModeDto.GameModeDetails.StartingCardID);
            await PlaceFollowUpCardsAsync(_gameModeDto.GameModeDetails.FinisherCardID, _cardDeck.Count);
        }

        public async Task<GameCardDto?> DrawNextCardAsync()
        {
            _cardTextPlaceholderService.SetupAndShuffleLists();

            if (_cardDeck.Count == 0 || isGameOver) // wenn _cardDeck ist empty: Spielende (return null)
            {
                return null;
            }

            var gameCard = _cardDeck.Pop();
            if (gameCard == null)
            {
                gameCard = GetRandomCard();
                PlaceCardInCardDeck(gameCard);
                await PlaceFollowUpCardsAsync(gameCard.FollowUpCardID, gameCard.IntervalToFollowUp);
                gameCard = _cardDeck.Pop();
            }

            gameCard = _cardTextPlaceholderService.ResolveWinningTeamPlaceholders(gameCard);
            gameCard = _cardTextPlaceholderService.ResolveLosingTeamPlaceholders(gameCard);

            _usedCards.Add(gameCard);

            var gameCardDto = await _gameCardMapper.ConvertToDtoAsync(gameCard);

            if (gameCardDto.CardSetDetails.Category == CardSetCategory.GameOver || gameCardDto.CardSetDetails.Category == CardSetCategory.GameOverTeams)
            {
                isGameOver = true;
            }

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
                followUpInterval = followUpInterval + gameCard.IntervalToFollowUp;
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

                gameCard = _cardTextPlaceholderService.ResolvePlayerPlaceholders(gameCard);
                gameCard = _cardTextPlaceholderService.ResolvePointValuePlaceholders(gameCard);
                gameCard = _cardTextPlaceholderService.ResolveTeamPlaceholders(gameCard);
                gameCard = _cardTextPlaceholderService.ResolvePlayerTeam1Placeholders(gameCard);
                gameCard = _cardTextPlaceholderService.ResolvePlayerTeam2Placeholders(gameCard);

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
                isValidForPlay = CheckIfGameCardIsValidCard(gameCard);
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

        private bool CheckIfGameCardIsValidCard(GameCard gameCard)
        {
            if (gameCard.RequiredPlayedCardCount <= _usedCards.Count)
            {
                if (!_usedCards.Contains(gameCard))
                {
                    if (gameCard.RequiredTotalPlayersCount <= _playerManagementService.GetAllPlayers().Count)
                    {
                        if (gameCard.RequiredTeamOnePlayersCount > _teamManagementService.GetTeamOne().TeamMembers.Count || gameCard.RequiredTeamTwoPlayersCount > _teamManagementService.GetTeamTwo().TeamMembers.Count)
                        {
                            return false;
                        }

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
