using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class TemplateSlot
    {
        [PrimaryKey]
        public int TemplateSlotID { get; set; }
        public int TemplateID { get; set; }
        public int CardSetID { get; set; }
        public int SlotNumber { get; set; }
    }
}
