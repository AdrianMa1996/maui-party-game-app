using KnockKnockApp.Mapper;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Repositories;

namespace KnockKnockApp.Services
{
    public class ExtensionCardManagementService : IExtensionCardManagementService
    {
        private readonly IExtensionMapper _extensionMapper;
        private readonly IExtensionCardMapper _extensionCardMapper;
        private readonly IExtensionCardRepository _extensionCardRepository;

        private Random _random = new Random();

        private ExtensionDto? _extensionDto;
        private Stack<ExtensionCard?> _cardDeck = new();
        private bool isGameOver = false;

        public ExtensionCardManagementService(IExtensionMapper extensionMapper, IExtensionCardMapper extensionCardMapper, IExtensionCardRepository extensionCardRepository)
        {
            _extensionMapper = extensionMapper;
            _extensionCardMapper = extensionCardMapper;
            _extensionCardRepository = extensionCardRepository;
        }

        public async Task SetupAsync(Extension extension)
        {
            _extensionDto = await _extensionMapper.ConvertToDtoAsync(extension);
            _cardDeck = new Stack<ExtensionCard?>();

            InitializeCardDeckWithNullCards();
        }

        public async Task<ExtensionCardDto?> DrawNextExtensionCardAsync()
        {
            if (_cardDeck.Count == 0 || isGameOver) // wenn _cardDeck ist empty: Spielende (return null)
            {
                return null;
            }

            var extensionCard = _cardDeck.Pop();
            if (extensionCard == null)
            {
                extensionCard = GetRandomCard();
                PlaceCardInCardDeck(extensionCard);
                await PlaceFollowUpCardsAsync(extensionCard.FollowUpCardID, 1);
                extensionCard = _cardDeck.Pop();
            }

            var extensionCardDto = await _extensionCardMapper.ConvertToDtoAsync(extensionCard);

            if (extensionCardDto.ExtensionCardSetDetails.Category == ExtensionCardSetCategory.GameRule || extensionCardDto.ExtensionCardSetDetails.Category == ExtensionCardSetCategory.ThemedGameCompletion || extensionCardDto.ExtensionCardSetDetails.Category == ExtensionCardSetCategory.RhymingGameCompletion || extensionCardDto.ExtensionCardSetDetails.Category == ExtensionCardSetCategory.MimeCompletion)
            {
                isGameOver = true;
            }

            return await _extensionCardMapper.ConvertToDtoAsync(extensionCard);
        }

        private void InitializeCardDeckWithNullCards()
        {
            for (int i = 0; i < 20; i++)
            {
                _cardDeck.Push(null);
            }
        }

        private async Task PlaceFollowUpCardsAsync(int followUpCardID, int followUpInterval = 0)
        {
            while (followUpCardID != 0)
            {
                var extensionCard = await _extensionCardRepository.GetExtensionCardByIdAsync(followUpCardID);
                PlaceCardInCardDeck(extensionCard, followUpInterval);
                followUpCardID = extensionCard.FollowUpCardID;
                followUpInterval = followUpInterval + 1;
            }
        }

        private void PlaceCardInCardDeck(ExtensionCard extensionCard, int cardDepth = 0)
        {
            if (cardDepth >= 0)
            {
                Stack<ExtensionCard?> tempStack = new Stack<ExtensionCard?>();

                while (cardDepth != 0 && _cardDeck.Count > 0)
                {
                    var drawnCard = _cardDeck.Pop();
                    tempStack.Push(drawnCard);
                    cardDepth = cardDepth - 1;
                }

                _cardDeck.Push(extensionCard); // Problem: Karte wird eventuell hinter der Spiel-Ende karte gepushed

                while (tempStack.Count > 0)
                {
                    _cardDeck.Push(tempStack.Pop());
                }
            }
        }

        private ExtensionCard GetRandomCard()
        {
            var extensionCardSet = _extensionDto.ExtensionCardSets.FirstOrDefault();
            int randomNumber = _random.Next(extensionCardSet.ExtensionCards.Count);
            var extensionCard = extensionCardSet.ExtensionCards[randomNumber];

            return extensionCard;
        }
    }
}
