using KnockKnockApp.Models;
using System.Collections.ObjectModel;

namespace KnockKnockApp.Repositories
{
    public interface ITemporaryDataRepository
    {
        public ObservableCollection<Player> GetPlayers();
        public void SetPlayers(ObservableCollection<Player> players);
    }
}
