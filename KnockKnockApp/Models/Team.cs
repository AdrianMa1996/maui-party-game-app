using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.Models
{
    public class Team
    {
        public Team(string name, int gamePoints)
        {
            Name = name;
            GamePoints = gamePoints;
        }
        public string Name { get; set; }
        public int GamePoints { get; set; }
        public ObservableCollection<Player> TeamMembers = [];
    }
}
