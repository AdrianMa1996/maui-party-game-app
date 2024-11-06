using SQLite;

namespace KnockKnockApp.Models.Database
{
    class Extension
    {
        [PrimaryKey]
        public int ExtensionID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Language { get; set; }
    }
}
