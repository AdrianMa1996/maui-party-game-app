namespace KnockKnockApp.Models.Database
{
    public class GameMode
    {
        public int GameModeID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string DescriptionText { get; set; }
        public bool IsPrime { get; set; }
    }
}
