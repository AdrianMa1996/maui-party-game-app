using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Models.DTOs
{
    public class GameModeDto
    {
        public GameMode GameModeDetails { get; set; }
        public Template TemplateDetails { get; set; }
        public List<TemplateSlot> TemplateSlots { get; set; }
    }
}
