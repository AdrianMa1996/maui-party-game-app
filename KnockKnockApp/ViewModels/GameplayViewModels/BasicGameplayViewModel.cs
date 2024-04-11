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

        public BasicGameplayViewModel(IDeviceOrientationService deviceOrientationService, ICardManagementService cardManagementService, IPlayerManagementService playerManagementService, ITeamManagementService teamManagementService)
        {
            _deviceOrientationService = deviceOrientationService;
            _cardManagementService = cardManagementService;
            _playerManagementService = playerManagementService;
            _teamManagementService = teamManagementService;

            // setup TeamManagementService (und evtl die Team-Spieler vom PlayerManagementservice in den TeamManagementServiceverscheibenn)

            TeamOne = _teamManagementService.GetTeamOne();
            TeamTwo = _teamManagementService.GetTeamTwo();

            AllPlayers = _playerManagementService.GetAllPlayers();
            TeamlessPlayers = new ObservableCollection<Player>(_playerManagementService.GetAllPlayers());
            TeamOnePlayers = _teamManagementService.GetTeamOne().TeamMembers;
            TeamOnePlayers.Clear();
            TeamTwoPlayers = _teamManagementService.GetTeamTwo().TeamMembers;
            TeamTwoPlayers.Clear();
            _teamManagementService = teamManagementService;
        }

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
        public async void DisplayNextCardAsync()
        {
            var nextCard = await _cardManagementService.DrawNextCardAsync();
            if (nextCard == null)
            {
                NavigateToSelectGameMode();
            }
            CurrentCard = nextCard;
        }

        [RelayCommand]
        public async void PointsToTeamOne()
        {
            _teamManagementService.AddGamePointsToTeamOne(CurrentCard.GameCardDetails.PointValue);
            TeamOne = new Team("TeamOne", 0);
            TeamOne = _teamManagementService.GetTeamOne();
            DisplayNextCardAsync();
        }

        [RelayCommand]
        public async void PointsToTeamTwo()
        {
            _teamManagementService.AddGamePointsToTeamTwo(CurrentCard.GameCardDetails.PointValue);
            TeamTwo = new Team("TeamTwo", 0);
            TeamTwo = _teamManagementService.GetTeamTwo();
            DisplayNextCardAsync();
        }

        [RelayCommand]
        public void NavigateToManagePlayers()
        {
            var xxx = 10;
        }

        [RelayCommand]
        public void NavigateToSelectGameMode()
        {
            Shell.Current.GoToAsync("..", false);
            _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
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
            TeamOnePlayers.Add(player);
            TeamOnePlayers = new ObservableCollection<Player>();
            TeamOnePlayers = _teamManagementService.GetTeamOne().TeamMembers;
            var teamlessPlayersCopy = new ObservableCollection<Player>(TeamlessPlayers);
            teamlessPlayersCopy.Remove(player);
            TeamlessPlayers = teamlessPlayersCopy;
        }

        [RelayCommand]
        public void AddPlayerToTeamTwo(object commandParameter)
        {
            var player = (Player)commandParameter;
            TeamTwoPlayers.Add(player);
            TeamTwoPlayers = new ObservableCollection<Player>();
            TeamTwoPlayers = _teamManagementService.GetTeamTwo().TeamMembers;
            var teamlessPlayersCopy = new ObservableCollection<Player>(TeamlessPlayers);
            teamlessPlayersCopy.Remove(player);
            TeamlessPlayers = teamlessPlayersCopy;
        }

        [RelayCommand]
        public void RemovePlayerOfTeamOne(object commandParameter)
        {
            var player = (Player)commandParameter;
            var teamlessPlayersCopy = new ObservableCollection<Player>(TeamlessPlayers);
            teamlessPlayersCopy.Add(player);
            TeamlessPlayers = teamlessPlayersCopy;
            TeamOnePlayers.Remove(player);
            TeamOnePlayers = new ObservableCollection<Player>();
            TeamOnePlayers = _teamManagementService.GetTeamOne().TeamMembers;
        }

        [RelayCommand]
        public void RemovePlayerOfTeamTwo(object commandParameter)
        {
            var player = (Player)commandParameter;
            var teamlessPlayersCopy = new ObservableCollection<Player>(TeamlessPlayers);
            teamlessPlayersCopy.Add(player);
            TeamlessPlayers = teamlessPlayersCopy;
            TeamTwoPlayers.Remove(player);
            TeamTwoPlayers = new ObservableCollection<Player>();
            TeamTwoPlayers = _teamManagementService.GetTeamTwo().TeamMembers;
        }
    }
}
