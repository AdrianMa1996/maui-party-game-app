using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Services;
using System.Collections.ObjectModel;

namespace KnockKnockApp.ViewModels
{
    public partial class ManagePlayersViewModel : ObservableObject
    {
        private readonly IPlayerManagementService _playerManagementService;

        public ManagePlayersViewModel(IPlayerManagementService playerManagementService)
        {
            _playerManagementService = playerManagementService;

            AllPlayers = _playerManagementService.GetAllPlayers();
        }

        [ObservableProperty]
        public ObservableCollection<Player> allPlayers;

        [ObservableProperty]
        public string spielerNameEntryText = string.Empty;

        [RelayCommand]
        public void AddPlayer()
        {
            var playerName = SpielerNameEntryText;
            _playerManagementService.AddPlayer(playerName);
            SpielerNameEntryText = string.Empty;
        }

        [RelayCommand]
        public void RemovePlayer(object commandParameter)
        {
            var player = (Player)commandParameter;
            var playerId = player.Id;
            _playerManagementService.RemovePlayer(playerId);
        }

        [RelayCommand]
        public void NavigateToSelectGameMode()
        {
            AppShell.Current.GoToAsync("SelectGameModeView", true);
        }
    }
}
