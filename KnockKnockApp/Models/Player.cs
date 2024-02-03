namespace KnockKnockApp.Models
{
    public class Player
    {
        public Player(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
