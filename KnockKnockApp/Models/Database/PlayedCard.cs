using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class PlayedCard
    {
        [PrimaryKey, AutoIncrement]
        public int PlayedCardID { get; set; }
        public int GameCardID { get; set; }
    }
}
