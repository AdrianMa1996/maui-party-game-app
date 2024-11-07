using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Models.DTOs
{
    public class ExtensionCardSetDto
    {
        public ExtensionCardSet ExtensionCardSetDetails { get; set; }
        public ExtensionAndExtensionCardSetBinding ExtensionBindingDetails { get; set; }
        public Extension ExtensionDetails { get; set; }
        public List<ExtensionCard> ExtensionCards { get; set; }
    }
}
