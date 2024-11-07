using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Models.DTOs
{
    public class ExtensionDto
    {
        public Extension ExtensionDetails { get; set; }
        public List<ExtensionCardSetDto> ExtensionCardSets { get; set; }
    }
}
