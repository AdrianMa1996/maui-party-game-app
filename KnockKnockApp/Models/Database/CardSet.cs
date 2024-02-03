namespace KnockKnockApp.Models.Database
{
    public class CardSet
    {
        public int CardSetID { get; set; }
        public string Name { get; set; } // Wird im Code nicht benötigt, brauche ich aber zur Differenzierung zu anderen CardSets
        public string Title { get; set; }
        public CardSetCategory Category { get; set; }
    }

    public enum CardSetCategory
    {
        BeispielCategory1,
        BeispielCategory2,
        BeispielCategory3,
        BeispielCategory4
    }
}
