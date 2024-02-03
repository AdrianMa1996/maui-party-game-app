namespace KnockKnockApp.Models.Database
{
    public class GameModeAndCardSetBinding
    {
        public int GameModeAndCardSetBindingID { get; set; }
        public int GameModeID { get; set; }
        public int CardSetID { get; set; }
        public string Title { get; set; }
        public bool IsDisableable { get; set; }
        public bool IsActivated { get; set; }
        public OccurrenceFrequency CardSetOccurrence { get; set; }
    }

    public enum OccurrenceFrequency
    {
        VeryLow,
        Low,
        Minor,
        ModeratelyLow,
        Medium,
        ModeratelyHigh,
        High,
        VeryHigh,
        ExtremelyHigh,
        Maximum
    }
}
