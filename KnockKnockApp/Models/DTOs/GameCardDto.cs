using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Models.DTOs
{
    public class GameCardDto
    {
        public GameCard GameCardDetails { get; set; }
        public CardSet CardSetDetails { get; set; }
    }
}
