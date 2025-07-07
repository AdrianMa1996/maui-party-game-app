using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class Template
    {
        [PrimaryKey]
        public int TemplateID { get; set; }
        public int GameModeID { get; set; }
        public bool ContainsAdvertising { get; set; }
    }
}
