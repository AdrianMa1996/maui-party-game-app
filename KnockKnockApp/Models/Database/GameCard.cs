using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class GameCard
    {
        [PrimaryKey]
        public int GameCardID { get; set; }
        public int CardSetID { get; set; }
        public string CardText { get; set; }
        public int RequiredPlayers { get; set; }
        public int FollowUpCardID { get; set; }
        public int IntervalToFollowUp { get; set; }
    }
}
