using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class GameCard
    {
        [PrimaryKey]
        public int GameCardID { get; set; }
        public int CardSetID { get; set; }
        public string CardText { get; set; }
        public int PointValue { get; set; }
        public int RequiredTotalPlayersCount { get; set; }
        public int RequiredTeamOnePlayersCount { get; set; }
        public int RequiredTeamTwoPlayersCount { get; set; }
        public int RequiredPlayedCardCount { get; set; }
        public int FollowUpCardID { get; set; } // is 0 if there is no FollowUpCard
        public int IntervalToFollowUp { get; set; }
    }
}
