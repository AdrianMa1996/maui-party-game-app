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

        public BasicGameplayViewModel(IDeviceOrientationService deviceOrientationService, ICardManagementService cardManagementService, IPlayerManagementService playerManagementService)
        {
            _deviceOrientationService = deviceOrientationService;
            _cardManagementService = cardManagementService;
            _playerManagementService = playerManagementService;

            AllPlayers = _playerManagementService.GetAllPlayers();
            TeamlessPlayers = new ObservableCollection<Player>(_playerManagementService.GetAllPlayers());
            TeamOnePlayers = _playerManagementService.GetTeamOnePlayers();
            TeamTwoPlayers = _playerManagementService.GetTeamTwoPlayers();
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
        public int pointsTeamA = 0;

        [ObservableProperty]
        public int pointsTeamB = 0;

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
        public async void PointsToTeamA()
        {
            PointsTeamA = PointsTeamA + CurrentCard.GameCardDetails.PointValue;
            DisplayNextCardAsync();
        }

        [RelayCommand]
        public async void PointsToTeamB()
        {
            PointsTeamB = PointsTeamB + CurrentCard.GameCardDetails.PointValue;
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
            var teamOnePlayerCopy = new ObservableCollection<Player>(TeamOnePlayers);
            teamOnePlayerCopy.Add(player);
            TeamOnePlayers = teamOnePlayerCopy;
            var teamlessPlayersCopy = new ObservableCollection<Player>(TeamlessPlayers);
            teamlessPlayersCopy.Remove(player);
            TeamlessPlayers = teamlessPlayersCopy;
        }

        [RelayCommand]
        public void AddPlayerToTeamTwo(object commandParameter)
        {
            var player = (Player)commandParameter;
            var teamTwoPlayerCopy = new ObservableCollection<Player>(TeamTwoPlayers);
            teamTwoPlayerCopy.Add(player);
            TeamTwoPlayers = teamTwoPlayerCopy;
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
            var teamOnePlayerCopy = new ObservableCollection<Player>(TeamOnePlayers);
            teamOnePlayerCopy.Remove(player);
            TeamOnePlayers = teamOnePlayerCopy;
        }

        [RelayCommand]
        public void RemovePlayerOfTeamTwo(object commandParameter)
        {
            var player = (Player)commandParameter;
            var teamlessPlayersCopy = new ObservableCollection<Player>(TeamlessPlayers);
            teamlessPlayersCopy.Add(player);
            TeamlessPlayers = teamlessPlayersCopy;
            var teamTwoPlayerCopy = new ObservableCollection<Player>(TeamTwoPlayers);
            teamTwoPlayerCopy.Remove(player);
            TeamTwoPlayers = teamTwoPlayerCopy;
        }
    }
}
