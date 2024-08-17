using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Repositories;
using KnockKnockApp.Services;
using KnockKnockApp.ViewModels.PopupViewModels;
using System.Collections.ObjectModel;

namespace KnockKnockApp.ViewModels
{
    public partial class SelectGameModeViewModel : ObservableObject
    {
        private readonly IDeviceOrientationService _deviceOrientationService;
        private readonly IGameModeRepository _gameModeRepository;
        private readonly IPlayerManagementService _playerManagementService;
        private readonly ISubscriptionManagementService _subscriptionManagementService;

        private readonly IPopupService _popupService;
        private readonly PurchasePrimePopupViewModel _purchasePrimePopupViewModel;

        public SelectGameModeViewModel(ILocalizationService localizationService, IDeviceOrientationService deviceOrientationService, IGameModeRepository gameModeRepository, IPlayerManagementService playerManagementService, ISubscriptionManagementService subscriptionManagementService, IPopupService popupService, PurchasePrimePopupViewModel purchasePrimePopupViewModel)
        {
            LocalizationService = localizationService;
            _deviceOrientationService = deviceOrientationService;
            _gameModeRepository = gameModeRepository;
            _playerManagementService = playerManagementService;
            _subscriptionManagementService = subscriptionManagementService;

            _popupService = popupService;
            _purchasePrimePopupViewModel = purchasePrimePopupViewModel;

            AccountInformation = _subscriptionManagementService.GetAccountInformation();

            AllPlayers = _playerManagementService.GetAllPlayers();

            RefreshGameModeCollection();
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [ObservableProperty]
        public AccountInformation accountInformation;

        [ObservableProperty]
        public ObservableCollection<GameMode> gameModeCollection = new ObservableCollection<GameMode>();

        [ObservableProperty]
        public ObservableCollection<Player> allPlayers;

        [RelayCommand]
        public async void RefreshGameModeCollection()
        {
            GameModeCollection = new ObservableCollection<GameMode>(await _gameModeRepository.GetGameModesAsync());
        }

        [RelayCommand]
        public void NavigateToGameplay(GameMode gameMode)
        {
            var navParam = new Dictionary<string, object>
            {
                { "GameMode", gameMode }
            };
            AppShell.Current.GoToAsync("LoadingBasicGameplayView", false, navParam);
            _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Landscape);
        }

        [RelayCommand]
        public void NavigateToGameModeSettings(GameMode gameMode)
        {
            var navParam = new Dictionary<string, object>
            {
                { "GameMode", gameMode }
            };
            AppShell.Current.GoToAsync("GameModeSettingsView", true, navParam);
        }

        [RelayCommand]
        public void OpenSubscriptionPopup()
        {
            _popupService.ShowPopup(_purchasePrimePopupViewModel);
        }

        [RelayCommand]
        public void NavigateToManagePlayers()
        {
            Shell.Current.GoToAsync("..", true);
        }
    }
}
