using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class CardSet
    {
        [PrimaryKey]
        public int CardSetID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public CardSetCategory Category { get; set; }
    }

    public enum CardSetCategory
    {
        // Information
        Information,
        GameOver,
        ManageTeams,
        PunishmentGame,
        // CardColors
        PurpleCard, // Basic
        PurpleCardScoring,
        YellowCard, // Mehr oder weniger
        YellowCardScoring,
        GreenCard, // Minigame, Abstimmen
        GreenCardScoring,
        BlueCard, // Fallback, Werbung, Pflicht, Wahrheit, Wer etwas zuletzt macht
        BlueCardScoring,
        RedCard, // Richtig oder Falsch (Fake News)
        RedCardScoring,
        PinkCard, // Schätzspiel
        PinkCardScoring,
        OrangeCard, // Allgemeinwissen
        OrangeCardScoring,
        GrayCard, // Gewinnerbekanntgabe
        GrayCardScoring,
        // TimeBomb
        TimeBombPreparation,
        TimeBomb,
        TimeBombScoring, // nur bei Teammode
        // StopWatch
        StopWatchPreparation,
        StopWatch,
        StopWatchScoring, // nur bei TeamMode
    }
}
