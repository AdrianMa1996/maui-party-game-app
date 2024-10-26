using KnockKnockApp.Models;
using System.Collections.ObjectModel;

namespace KnockKnockApp.Services
{
    class PlayerManagementService : IPlayerManagementService
    {
        private ObservableCollection<Player> allPlayers = [/*new Player("Adrian"), new Player("Tim"), new Player("Kevin"), new Player("Laurenz")*/];

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
    }
}
