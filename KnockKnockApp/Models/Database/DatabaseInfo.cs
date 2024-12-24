using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class DatabaseInfo
    {
        [PrimaryKey]
        public int DatabaseInfoID { get; set; }
        public string ConnectedAppBuild { get; set; }
    }
}
