using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Repositories;

namespace KnockKnockApp.Mapper
{
    public class GameModeMapper : IGameModeMapper
    {
        private readonly ITemplateRepository _templateRepository;
        private readonly ITemplateSlotRepository _templateSlotRepository;
        private readonly IPlayedGameRepository _playedGameRepository;

        private Random _random = new Random();

        public GameModeMapper(ITemplateRepository templateRepository, ITemplateSlotRepository templateSlotRepository, IPlayedGameRepository playedGameRepository)
        {
            _templateRepository = templateRepository;
            _templateSlotRepository = templateSlotRepository;
            _playedGameRepository = playedGameRepository;
        }

        public async Task<GameModeDto> ConvertToDtoAsync(GameMode gameMode)
        {
            var templates = await _templateRepository.GetTemplatesByGameModeIdAsync(gameMode.GameModeID);

            var template = new Template();
            var validTemplateFound = false;
            while (validTemplateFound == false)
            {
                int randomNumber = _random.Next(templates.Count);
                template = templates[randomNumber];

                var last3PlayedGames = await _playedGameRepository.GetLast3PlayedGamesAsync();
                if (last3PlayedGames.Count > 0 && last3PlayedGames[0].TemplateID == template.TemplateID)
                {
                    continue;
                }

                if (template.ContainsAdvertising && last3PlayedGames.Count < 3)
                {
                    continue;
                }

                validTemplateFound = true;
            }

            var templateSlots = await _templateSlotRepository.GetTemplateSlotsByTemplateIdAsync(template.TemplateID);

            var gameModeDto = new GameModeDto()
            {
                GameModeDetails = gameMode,
                TemplateDetails = template,
                TemplateSlots = templateSlots
            };
            return gameModeDto;
        }
    }
}
