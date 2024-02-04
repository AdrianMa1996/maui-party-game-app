using KnockKnockApp.Models;
using KnockKnockApp.Repositories;

namespace KnockKnockApp.Services
{
    public class ManagePlayersService : IManagePlayersService
    {
        private readonly ITemporaryDataRepository _temporaryDataRepository;

        public ManagePlayersService(ITemporaryDataRepository temporaryDataRepository)
        {
            _temporaryDataRepository = temporaryDataRepository;
        }

        public void AddPlayer(string playerName)
        {
            if (!string.IsNullOrEmpty(playerName))
            {
                var players = _temporaryDataRepository.GetPlayers();
                players.Add(new Player(playerName));
                _temporaryDataRepository.SetPlayers(players);
            }
        }

        public void RemovePlayer(Guid playerId)
        {
            var players = _temporaryDataRepository.GetPlayers();
            var playerToRemove = players.FirstOrDefault(p => p.Id == playerId);
            players.Remove(playerToRemove);
            _temporaryDataRepository.SetPlayers(players);
        }
    }
}
