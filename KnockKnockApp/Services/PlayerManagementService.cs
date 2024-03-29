using KnockKnockApp.Models;
using System.Collections.ObjectModel;

namespace KnockKnockApp.Services
{
    class PlayerManagementService : IPlayerManagementService
    {
        private ObservableCollection<Player> allPlayers = [new Player("Max"), new Player("Max Mustermann"), new Player("Mustermann"), new Player("Mustermann Max")];
        private ObservableCollection<Player> teamOnePlayers = [];
        private ObservableCollection<Player> teamTwoPlayers = [];

        public ObservableCollection<Player> GetAllPlayers()
        {
            return allPlayers;
        }

        public void AddPlayer(string playerName)
        {
            if (!string.IsNullOrEmpty(playerName))
            {
                allPlayers.Add(new Player(playerName));
            }
        }

        public void RemovePlayer(Guid playerId)
        {
            var playerToRemove = allPlayers.FirstOrDefault(p => p.Id == playerId);
            _ = allPlayers.Remove(playerToRemove);
        }

        public ObservableCollection<Player> GetTeamOnePlayers()
        {
            return teamOnePlayers;
        }

        public void AddPlayerToTeamOne(Guid playerId)
        {
            return;
        }

        public ObservableCollection<Player> GetTeamTwoPlayers()
        {
            return teamTwoPlayers;
        }

        public void AddPlayerToTeamTwo(Guid playerId)
        {
            return;
        }
    }
}
