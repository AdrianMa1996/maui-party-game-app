using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class GameMode
    {
        [PrimaryKey]
        public int GameModeID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string DescriptionText { get; set; }
        public bool IsTeamGameMode { get; set; }
        public bool IsPrime { get; set; }
        public string Language { get; set; }
        public int StartingCardID { get; set; }
        public int FinisherCardID { get; set; }
        public int FallbackCardSet { get; set; }
    }
}
