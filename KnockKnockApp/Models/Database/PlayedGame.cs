using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class PlayedGame
    {
        [PrimaryKey, AutoIncrement]
        public int PlayedGameID { get; set; }
        public int GameModeID { get; set; }
        public int TemplateID { get; set; }
    }
}
