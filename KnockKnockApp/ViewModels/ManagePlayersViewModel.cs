using CommunityToolkit.Maui.Core;
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
        private readonly IPopupService _popupService;
        private readonly LanguageSettingsViewModel _languageSettingsViewModel;

        public ManagePlayersViewModel(ILocalizationService localizationService, IPlayerManagementService playerManagementService, IPopupService popupService, LanguageSettingsViewModel languageSettingsViewModel)
        {
            LocalizationService = localizationService;
            _playerManagementService = playerManagementService;
            _popupService = popupService;
            _languageSettingsViewModel = languageSettingsViewModel;

            AllPlayers = _playerManagementService.GetAllPlayers();
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

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

        [RelayCommand]
        public void DisplayLanguageSettings(Localization localization)
        {
            AppShell.Current.GoToAsync("LanguageSettingsView", false);
        }
    }
}
