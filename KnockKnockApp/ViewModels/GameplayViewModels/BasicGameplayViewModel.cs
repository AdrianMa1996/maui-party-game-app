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
            TeamOnePlayers = new ObservableCollection<Player>();
            TeamTwoPlayers = new ObservableCollection<Player>();
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
