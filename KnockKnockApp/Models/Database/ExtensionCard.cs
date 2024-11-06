using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class ExtensionCard
    {
        [PrimaryKey]
        public int ExtensionCardID { get; set; }
        public int ExtensionCardSetID { get; set; }
        public string CardText { get; set; }
        public int FollowUpCardID { get; set; } // is 0 if there is no FollowUpCard
    }
}
