using KnockKnockApp.Models;
using System.Collections.ObjectModel;

namespace KnockKnockApp.Services
{
    public interface IPlayerManagementService
    {
        public ObservableCollection<Player> GetAllPlayers();
        public void AddPlayer(string playerName);
        public void RemovePlayer(Guid playerId);
        public ObservableCollection<Player> GetTeamOnePlayers();
        public void AddPlayerToTeamOne(Player player);
        public void RemovePlayerFromTeamOne(Player player);
        public ObservableCollection<Player> GetTeamTwoPlayers();
        public void AddPlayerToTeamTwo(Player player);
        public void RemovePlayerFromTeamTwo(Player player);
    }
}
