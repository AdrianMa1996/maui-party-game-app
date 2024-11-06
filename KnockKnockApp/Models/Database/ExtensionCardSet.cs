using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class ExtensionCardSet
    {
        [PrimaryKey]
        public int ExtensionCardSetID { get; set; }
        public string Title { get; set; }
        public ExtensionCardSetCategory Category { get; set; }
    }

    public enum ExtensionCardSetCategory
    {
        ThemedGamePreparation,
        ThemedGame,
        ThemedGameCompletion,
        RhymingGamePreparation,
        RhymingGame,
        RhymingGameCompletion,
        MimePreparation,
        Mime,
        MimeCompletion,
        GameRule
    }
}
