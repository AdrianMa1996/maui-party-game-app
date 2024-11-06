using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class ExtensionAndExtensionCardSetBinding
    {
        [PrimaryKey]
        public int ExtensionAndExtensionCardSetBindingID { get; set; }
        public int ExtensionID { get; set; }
        public int ExtensionCardSetID { get; set; }
    }
}
