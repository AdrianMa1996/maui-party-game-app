using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Services;
using System.Collections.ObjectModel;

namespace KnockKnockApp.ViewModels.GameplayViewModels
{
    [QueryProperty(nameof(CurrentGameMode), "GameMode")]
    public partial class BasicGameplayViewModel : ObservableObject
    {
        private readonly IDeviceOrientationService _deviceOrientationService;
        private readonly ICardManagementService _cardManagementService;
        private readonly IPlayerManagementService _playerManagementService;
        private readonly ITeamManagementService _teamManagementService;

        public BasicGameplayViewModel(ILocalizationService localizationService, IDeviceOrientationService deviceOrientationService, ICardManagementService cardManagementService, IPlayerManagementService playerManagementService, ITeamManagementService teamManagementService)
        {
            LocalizationService = localizationService;
            _deviceOrientationService = deviceOrientationService;
            _cardManagementService = cardManagementService;
            _playerManagementService = playerManagementService;
            _teamManagementService = teamManagementService;
#if IOS
            keyboardHeight = new GridLength(0.58, GridUnitType.Star);
#endif
            _teamManagementService.SetupTeamManagementService();

            TeamOne = _teamManagementService.GetTeamOne();
            TeamTwo = _teamManagementService.GetTeamTwo();

            AllPlayers = _playerManagementService.GetAllPlayers();

            foreach (var player in AllPlayers)
            {
                player.IsTeamlessPlayer = true;
                player.IsTeamOnePlayer = false;
                player.IsTeamTwoPlayer = false;
            }

            TeamlessPlayers = new ObservableCollection<Player>(_playerManagementService.GetAllPlayers());
            TeamOnePlayers = _teamManagementService.GetTeamOne().TeamMembers;
            TeamTwoPlayers = _teamManagementService.GetTeamTwo().TeamMembers;
            _teamManagementService = teamManagementService;

            isGameRunning = true;
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [ObservableProperty]
        private bool isGameRunning;

        [ObservableProperty]
        public GridLength keyboardHeight = new GridLength(0);

        [ObservableProperty]
        public ObservableCollection<Player> allPlayers;

        [ObservableProperty]
        public ObservableCollection<Player> teamlessPlayers;

        [ObservableProperty]
        public ObservableCollection<Player> teamOnePlayers;

        [ObservableProperty]
        public ObservableCollection<Player> teamTwoPlayers;

        [ObservableProperty]
        private GameMode? currentGameMode;

        [ObservableProperty]
        public Team teamOne;

        [ObservableProperty]
        public Team teamTwo;

        partial void OnCurrentGameModeChanged(GameMode? value)
        {
            SetupGameAndDrawCard();
        }

        [ObservableProperty]
        private GameCardDto? currentCard;

        [RelayCommand]
        public async void DisplayNextCard()
        {
            var nextCard = await _cardManagementService.DrawNextCardAsync();
            if (nextCard == null)
            {
                Shell.Current.GoToAsync("..", false);
                _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
            }
            CurrentCard = nextCard;
        }

        [RelayCommand]
        public async void PointsToTeamOne()
        {
            _teamManagementService.AddGamePointsToTeamOne(CurrentCard.GameCardDetails.PointValue);
            TeamOne = new Team("TeamOne", 0);
            TeamOne = _teamManagementService.GetTeamOne();
            DisplayNextCard();
        }

        [RelayCommand]
        public async void PointsToTeamTwo()
        {
            _teamManagementService.AddGamePointsToTeamTwo(CurrentCard.GameCardDetails.PointValue);
            TeamTwo = new Team("TeamTwo", 0);
            TeamTwo = _teamManagementService.GetTeamTwo();
            DisplayNextCard();
        }

        [RelayCommand]
        public void NavigateToManagePlayers()
        {
            ShowManagePlayersPopup = true;
        }

        [RelayCommand]
        public async void NavigateToSelectGameMode()
        {
            var answer = await Application.Current.MainPage.DisplayAlert("Partie verlassen?", "Seid ihr sicher, dass ihr die Partie verlassen wollt?", "Ja", "Nein");
            if (answer)
            {
                IsGameRunning = false;
                Shell.Current.GoToAsync("..", false);
                _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
            }
        }

        public async void SetupGameAndDrawCard()
        {
            await _cardManagementService.SetupAsync(CurrentGameMode);
            CurrentCard = await _cardManagementService.DrawNextCardAsync();
        }

        [RelayCommand]
        public void AddPlayerToTeamOne(object commandParameter)
        {
            var player = (Player)commandParameter;

            AllPlayers.First(x => x.Id == player.Id).IsTeamlessPlayer = false;
            AllPlayers.First(x => x.Id == player.Id).IsTeamOnePlayer = true;
            AllPlayers.First(x => x.Id == player.Id).IsTeamTwoPlayer = false;

            TeamOne.TeamMembers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamOnePlayer == true));
            TeamTwo.TeamMembers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamTwoPlayer == true));
            TeamlessPlayers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamlessPlayer == true));
        }

        [RelayCommand]
        public void AddPlayerToTeamTwo(object commandParameter)
        {
            var player = (Player)commandParameter;

            AllPlayers.First(x => x.Id == player.Id).IsTeamlessPlayer = false;
            AllPlayers.First(x => x.Id == player.Id).IsTeamOnePlayer = false;
            AllPlayers.First(x => x.Id == player.Id).IsTeamTwoPlayer = true;

            TeamOne.TeamMembers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamOnePlayer == true));
            TeamTwo.TeamMembers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamTwoPlayer == true));
            TeamlessPlayers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamlessPlayer == true));
        }

        [RelayCommand]
        public void RemovePlayerOfTeamOne(object commandParameter)
        {
            var player = (Player)commandParameter;

            AllPlayers.First(x => x.Id == player.Id).IsTeamlessPlayer = true;
            AllPlayers.First(x => x.Id == player.Id).IsTeamOnePlayer = false;
            AllPlayers.First(x => x.Id == player.Id).IsTeamTwoPlayer = false;

            TeamOne.TeamMembers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamOnePlayer == true));
            TeamTwo.TeamMembers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamTwoPlayer == true));
            TeamlessPlayers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamlessPlayer == true));
        }

        [RelayCommand]
        public void RemovePlayerOfTeamTwo(object commandParameter)
        {
            var player = (Player)commandParameter;

            AllPlayers.First(x => x.Id == player.Id).IsTeamlessPlayer = true;
            AllPlayers.First(x => x.Id == player.Id).IsTeamOnePlayer = false;
            AllPlayers.First(x => x.Id == player.Id).IsTeamTwoPlayer = false;

            TeamOne.TeamMembers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamOnePlayer == true));
            TeamTwo.TeamMembers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamTwoPlayer == true));
            TeamlessPlayers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamlessPlayer == true));
        }

        [RelayCommand]
        public void DistributePlayersRandomlyAmongTeams()
        {
            Random random = new Random();
            var allPlayersShuffled = new ObservableCollection<Player>(AllPlayers).OrderBy(x => random.Next()).ToList();
            TeamOnePlayers.Clear();
            TeamTwoPlayers.Clear();

            for (int i = 0; i < allPlayersShuffled.Count; i++)
            {
                if (i % 2 == 0)
                {
                    AllPlayers.First(x => x.Id == allPlayersShuffled[i].Id).IsTeamlessPlayer = false;
                    AllPlayers.First(x => x.Id == allPlayersShuffled[i].Id).IsTeamOnePlayer = true;
                    AllPlayers.First(x => x.Id == allPlayersShuffled[i].Id).IsTeamTwoPlayer = false;
                }
                else
                {
                    AllPlayers.First(x => x.Id == allPlayersShuffled[i].Id).IsTeamlessPlayer = false;
                    AllPlayers.First(x => x.Id == allPlayersShuffled[i].Id).IsTeamOnePlayer = false;
                    AllPlayers.First(x => x.Id == allPlayersShuffled[i].Id).IsTeamTwoPlayer = true;
                }
            }

            TeamOne.TeamMembers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamOnePlayer == true));
            TeamTwo.TeamMembers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamTwoPlayer == true));
            TeamlessPlayers = new ObservableCollection<Player>(AllPlayers.Where(x => x.IsTeamlessPlayer == true));
        }

        [ObservableProperty]
        public bool showManagePlayersPopup = false;

        public event EventHandler ShowManagePlayersRequested;
        public event EventHandler HideManagePlayersRequested;

        partial void OnShowManagePlayersPopupChanged(bool value)
        {
            if (value)
            {
                ShowManagePlayersRequested?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                HideManagePlayersRequested?.Invoke(this, EventArgs.Empty);
            }
        }

        [ObservableProperty]
        public string spielerNameEntryText = string.Empty;

        [RelayCommand]
        public void RemovePlayer(object commandParameter)
        {
            var player = (Player)commandParameter;
            var playerId = player.Id;
            _playerManagementService.RemovePlayer(playerId);
        }

        [RelayCommand]
        public void AddPlayer()
        {
            var playerName = SpielerNameEntryText;
            _playerManagementService.AddPlayer(playerName);
            SpielerNameEntryText = string.Empty;
        }

        [RelayCommand]
        public void HideManagePlayers()
        {
            ShowManagePlayersPopup = false;
        }
    }
}
