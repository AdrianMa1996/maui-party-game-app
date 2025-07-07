using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using System.Text.RegularExpressions;

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
            shuffledTeamOnePlayersList = shuffledTeamsList[0].TeamMembers.ToList().OrderBy(x => _random.Next()).ToList();
            shuffledTeamTwoPlayersList = shuffledTeamsList[1].TeamMembers.ToList().OrderBy(x => _random.Next()).ToList();
            return;
        }

        public GameCard ResolvePlayerPlaceholders(GameCard gameCard)
        {
            var playerPlaceholderRegex = new Regex(@"\{Player(\d+)\}");
            var matches = playerPlaceholderRegex.Matches(gameCard.CardText);

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

        public GameCard ResolveWinningTeamPlaceholders(GameCard gameCard)
        {
            var winningTeamPlaceholderRegex = new Regex(@"\{WinningTeam\}");
            var matches = winningTeamPlaceholderRegex.Matches(gameCard.CardText);

            foreach (Match match in matches)
            {
                gameCard.CardText = gameCard.CardText.Replace(match.Value, _teamManagementService.GetWinningTeam().Name); // winning Team ist hier null...
            }

            return gameCard;
        }

        public GameCard ResolveLosingTeamPlaceholders(GameCard gameCard)
        {
            var losingTeamPlaceholderRegex = new Regex(@"\{LosingTeam\}");
            var matches = losingTeamPlaceholderRegex.Matches(gameCard.CardText);

            foreach (Match match in matches)
            {
                gameCard.CardText = gameCard.CardText.Replace(match.Value, _teamManagementService.GetLosingTeam().Name);
            }

            return gameCard;
        }

        public GameCard ResolvePointValuePlaceholders(GameCard gameCard)
        {

            return gameCard;
        }

        public GameCard ResolveTeamPlaceholders(GameCard gameCard)
        {
            var teamPlaceholderRegex = new Regex(@"\{Team(\d+)\}");
            var matches = teamPlaceholderRegex.Matches(gameCard.CardText);

            foreach (Match match in matches)
            {
                // Extrahieren der Nummer aus dem Platzhalter
                int teamNumber = int.Parse(match.Groups[1].Value) - 1; // -1, weil die List-Indizierung bei 0 beginnt

                if (teamNumber < shuffledTeamsList.Count)
                {
                    // Ersetzen des Platzhalters durch den Spielername, wenn vorhanden
                    string teamName = shuffledTeamsList[teamNumber].Name;
                    gameCard.CardText = gameCard.CardText.Replace(match.Value, teamName);
                }
            }

            return gameCard;
        }

        public GameCard ResolvePlayerTeam1Placeholders(GameCard gameCard)
        {
            var playerTeam1PlaceholderRegex = new Regex(@"\{Player(\d+)Team1\}");
            var matches = playerTeam1PlaceholderRegex.Matches(gameCard.CardText);

            foreach (Match match in matches)
            {
                // Extrahieren der Nummer aus dem Platzhalter
                int playerTeam1Number = int.Parse(match.Groups[1].Value) - 1; // -1, weil die List-Indizierung bei 0 beginnt

                if (playerTeam1Number < shuffledTeamOnePlayersList.Count)
                {
                    // Ersetzen des Platzhalters durch den Spielername, wenn vorhanden
                    string playerName = shuffledTeamOnePlayersList[playerTeam1Number].Name;
                    gameCard.CardText = gameCard.CardText.Replace(match.Value, playerName);
                }
            }

            return gameCard;
        }

        public GameCard ResolvePlayerTeam2Placeholders(GameCard gameCard)
        {
            var playerTeam2PlaceholderRegex = new Regex(@"\{Player(\d+)Team2\}");
            var matches = playerTeam2PlaceholderRegex.Matches(gameCard.CardText);

            foreach (Match match in matches)
            {
                // Extrahieren der Nummer aus dem Platzhalter
                int playerTeam2Number = int.Parse(match.Groups[1].Value) - 1; // -1, weil die List-Indizierung bei 0 beginnt

                if (playerTeam2Number < shuffledTeamTwoPlayersList.Count)
                {
                    // Ersetzen des Platzhalters durch den Spielername, wenn vorhanden
                    string playerName = shuffledTeamTwoPlayersList[playerTeam2Number].Name;
                    gameCard.CardText = gameCard.CardText.Replace(match.Value, playerName);
                }
            }

            return gameCard;
        }
    }
}
