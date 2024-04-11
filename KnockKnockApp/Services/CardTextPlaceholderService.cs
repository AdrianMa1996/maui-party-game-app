using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KnockKnockApp.Services
{
    class CardTextPlaceholderService : ICardTextPlaceholderService
    {
        private readonly IPlayerManagementService _playerManagementService;
        private readonly ITeamManagementService _teamManagementService;

        private Random _random = new Random();

        private List<Player> shuffledAllPlayersList = new List<Player>();

        private List<Team> shuffledTeamsList = new List<Team>();
        private List<Player> shuffledTeamOnePlayersList = new List<Player>();
        private List<Player> shuffledTeamTwoPlayersList = new List<Player>();

        public CardTextPlaceholderService(IPlayerManagementService playerManagementService, ITeamManagementService teamManagementService)
        {
            _playerManagementService = playerManagementService;
            _teamManagementService = teamManagementService;
        }

        public void SetupAndShuffleLists()
        {
            shuffledAllPlayersList = _playerManagementService.GetAllPlayers().ToList().OrderBy(x => _random.Next()).ToList();
            shuffledTeamsList = new List<Team>() { _teamManagementService.GetTeamOne(), _teamManagementService.GetTeamTwo() }.OrderBy(x => _random.Next()).ToList();
            shuffledTeamOnePlayersList = _teamManagementService.GetTeamOne().TeamMembers.ToList().OrderBy(x => _random.Next()).ToList();
            shuffledTeamTwoPlayersList = _teamManagementService.GetTeamTwo().TeamMembers.ToList().OrderBy(x => _random.Next()).ToList();
            return;
        }

        public GameCard ResolveTextPlaceholders(GameCard gameCard)
        {
            // Regex, um die Platzhalter zu finden
            var placeholderRegex = new Regex(@"\{Player(\d+)\}");
            var matches = placeholderRegex.Matches(gameCard.CardText);

            foreach (Match match in matches)
            {
                // Extrahieren der Nummer aus dem Platzhalter
                int playerNumber = int.Parse(match.Groups[1].Value) - 1; // -1, weil die List-Indizierung bei 0 beginnt

                if (playerNumber < shuffledAllPlayersList.Count)
                {
                    // Ersetzen des Platzhalters durch den Spielername, wenn vorhanden
                    string playerName = shuffledAllPlayersList[playerNumber].Name;
                    gameCard.CardText = gameCard.CardText.Replace(match.Value, playerName);
                }
            }

            return gameCard;
        }
    }
}
