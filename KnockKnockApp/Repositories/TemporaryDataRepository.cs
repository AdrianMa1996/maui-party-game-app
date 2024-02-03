using KnockKnockApp.Models;
using KnockKnockApp.TemporaryData;
using System.Collections.ObjectModel;

namespace KnockKnockApp.Repositories
{
    public class TemporaryDataRepository : ITemporaryDataRepository
    {
        // Player
        public ObservableCollection<Player> GetPlayers()
        {
            return GeneralData.Instance.Players;
        }

        public void SetPlayers(ObservableCollection<Player> players)
        {
            GeneralData.Instance.Players = players;
        }
    }
}
