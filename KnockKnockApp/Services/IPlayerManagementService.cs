using KnockKnockApp.Models;
using System.Collections.ObjectModel;

namespace KnockKnockApp.Services
{
    public interface IPlayerManagementService
    {
        public ObservableCollection<Player> GetAllPlayers();
        public void AddPlayer(string playerName);
        public void RemovePlayer(Guid playerId);
    }
}
