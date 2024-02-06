using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Repositories;
using KnockKnockApp.Services;
using KnockKnockApp.TemporaryData;
using System.Collections.ObjectModel;

namespace KnockKnockApp.ViewModels
{
    public partial class SelectGameModeViewModel : ObservableObject
    {
        private readonly IDeviceOrientationService _deviceOrientationService;
        private readonly IGameModeRepository _gameModeRepository;

        public SelectGameModeViewModel(IDeviceOrientationService deviceOrientationService, IGameModeRepository gameModeRepository)
        {
            _deviceOrientationService = deviceOrientationService;
            _gameModeRepository = gameModeRepository;

            RefreshGameModeCollection();
        }

        [ObservableProperty]
        public ObservableCollection<GameMode> gameModeCollection = new ObservableCollection<GameMode>();

        [ObservableProperty]
        public GeneralData generalDataInstance = GeneralData.Instance;

        [RelayCommand]
        public async void RefreshGameModeCollection()
        {
            GameModeCollection = new ObservableCollection<GameMode>(await _gameModeRepository.GetGameModesAsync());
        }

        [RelayCommand]
        public void NavigateToManagePlayers()
        {
            Shell.Current.GoToAsync("..", true);
        }

        [RelayCommand]
        public void NavigateToGameplay(GameMode gameMode)
        {
            var navParam = new Dictionary<string, object>
            {
                { "GameMode", gameMode }
            };
            AppShell.Current.GoToAsync("BasicGameplayView", false, navParam);
            _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Landscape);
        }
    }
}
