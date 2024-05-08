using CommunityToolkit.Mvvm.ComponentModel;

namespace KnockKnockApp.Models
{
    public partial class Player : ObservableObject
    {
        public Player(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        [ObservableProperty]
        public bool isTeamlessPlayer = true;
        [ObservableProperty]
        public bool isTeamOnePlayer = false;
        [ObservableProperty]
        public bool isTeamTwoPlayer = false;
    }
}
