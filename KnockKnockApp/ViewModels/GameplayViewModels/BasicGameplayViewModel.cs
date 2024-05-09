using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;
using KnockKnockApp.Services;
using KnockKnockApp.ViewModels.PopupViewModels;
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
        private readonly IPopupService _popupService;
        private readonly ManagePlayersPopupViewModel _managePlayersPopupViewModel;

        public BasicGameplayViewModel(IDeviceOrientationService deviceOrientationService, ICardManagementService cardManagementService, IPlayerManagementService playerManagementService, ITeamManagementService teamManagementService, IPopupService popupService, ManagePlayersPopupViewModel managePlayersPopupViewModel)
        {
            _deviceOrientationService = deviceOrientationService;
            _cardManagementService = cardManagementService;
            _playerManagementService = playerManagementService;
            _teamManagementService = teamManagementService;
            _popupService = popupService;
            _managePlayersPopupViewModel = managePlayersPopupViewModel;

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
            _popupService.ShowPopup(_managePlayersPopupViewModel);
        }

        [RelayCommand]
        public async void NavigateToSelectGameMode()
        {
            var answer = await Application.Current.MainPage.DisplayAlert("Partie verlassen?", "Seid ihr sicher, dass ihr die Partie verlassen wollt?", "Yes", "No");
            if (answer)
            {
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
    }
}
