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
        // Normal
        Basic,
        Duel,
        Game,
        Dare,
        Rule,
        Powerdown,
        Powerup,
        // Team-Information
        InformationTeams,
        GameOverTeams,
        ManageTeams,
        PunishmentGame,
        // Team
        TeamBasic,
        TimeBombPreparation,
        TimeBomb,
        TimeBombScoring,
        TeamDare,
        TeamTuneYourViolins,
        StopWatchPreparation,
        StopWatch,
        StopWatchScoring,
        GuessingGame,
        GuessingGameScoring,
        // KnockKnockGlas
        KnockKnockGlasTrinken,
        KnockKnockGlasBefüllen,
        KnockKnockGlasWeitergeben
    }
}
