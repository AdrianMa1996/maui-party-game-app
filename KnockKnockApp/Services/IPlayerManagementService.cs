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
        public void AddPlayerToTeamOne(Guid playerId);
        public ObservableCollection<Player> GetTeamTwoPlayers();
        public void AddPlayerToTeamTwo(Guid playerId);
    }
}
