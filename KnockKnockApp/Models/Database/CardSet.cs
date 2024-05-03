using SQLite;

namespace KnockKnockApp.Models.Database
{
    public class CardSet
    {
        [PrimaryKey]
        public int CardSetID { get; set; }
        public string Name { get; set; } // Wird im Code nicht benötigt, brauche ich aber zur Differenzierung zu anderen CardSets
        public string Title { get; set; }
        public CardSetCategory Category { get; set; }
    }

    public enum CardSetCategory
    {
        Information,
        Basic,
        Game,
        Dare,
        Duel,
        Rule,
        Curse,
        Powerup,
        ManageTeams,
        PunishmentGame,
        TeamGame,
        TeamDare,
        TeamDuel,
        TeamComparison,
        TeamTuneYourViolins,
        TeamChampionPreparation,
        TeamChampion,
        GameOver
    }
}
