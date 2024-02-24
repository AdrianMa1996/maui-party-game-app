using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Models.DTOs
{
    public class GameModeDto
    {
        public GameMode GameModeDetails { get; set; }
        public List<CardSetDto> CardSets { get; set; }
    }
}
