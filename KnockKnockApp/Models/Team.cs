using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.Models
{
    public partial class Team : ObservableObject
    {
        public Team(string name, int gamePoints)
        {
            Name = name;
            GamePoints = gamePoints;
        }
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public int gamePoints;
        public ObservableCollection<Player> TeamMembers = [];
    }
}
