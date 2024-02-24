using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Models.DTOs
{
    public class CardSetDto
    {
        public CardSet CardSetDetails { get; set; }
        public GameModeAndCardSetBinding GameModeBindingDetails { get; set; }
        public GameMode GameModeDetails { get; set; }
        public List<GameCard> GameCards { get; set; }
    }
}
