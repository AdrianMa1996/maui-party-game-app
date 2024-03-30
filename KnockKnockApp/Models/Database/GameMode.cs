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
        public int Language { get; set; } // 0 is default => EN
        public int Category { get; set; }
        public int NumberOfGameCards { get; set; }
        public int StartingCardID { get; set; }
        public int FinisherCardID { get; set; }
    }
}
