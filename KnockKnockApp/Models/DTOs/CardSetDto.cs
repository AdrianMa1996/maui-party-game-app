using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Models.DTOs
{
    public class CardSetDto
    {
        public CardSet CardSetDetails { get; set; }
        public List<GameCard> GameCards { get; set; }
    }
}
