using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Services;
using KnockKnockApp.TemporaryData;

namespace KnockKnockApp.ViewModels
{
    public partial class ManagePlayersViewModel : ObservableObject
    {
        private readonly IManagePlayersService _managePlayersService;

        public ManagePlayersViewModel(IManagePlayersService managePlayersService)
        {
            _managePlayersService = managePlayersService;
        }

        [ObservableProperty]
        public GeneralData generalDataInstance = GeneralData.Instance;

        [ObservableProperty]
        public string spielerNameEntryText = string.Empty;

        [RelayCommand]
        public void AddPlayer()
        {
            var playerName = SpielerNameEntryText;
            _managePlayersService.AddPlayer(playerName);
            SpielerNameEntryText = string.Empty;
        }

        [RelayCommand]
        public void RemovePlayer(object commandParameter)
        {
            var player = (Player)commandParameter;
            var playerId = player.Id;
            _managePlayersService.RemovePlayer(playerId);

        }

        [RelayCommand]
        public void NavigateToSelectGameMode()
        {
            AppShell.Current.GoToAsync("SelectGameModeView", true);
        }
    }
}
