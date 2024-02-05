using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Services;
using KnockKnockApp.TemporaryData;
using KnockKnockApp.Views.GameplayViews;

namespace KnockKnockApp.ViewModels
{
    public partial class SelectGameModeViewModel : ObservableObject
    {
        private readonly IDeviceOrientationService _deviceOrientationService;

        public SelectGameModeViewModel(IDeviceOrientationService deviceOrientationService)
        {
            _deviceOrientationService = deviceOrientationService;
        }

        [ObservableProperty]
        public GeneralData generalDataInstance = GeneralData.Instance;

        [RelayCommand]
        public void NavigateToManagePlayers()
        {
            Shell.Current.GoToAsync("..", true);
        }

        [RelayCommand]
        public void NavigateToGameplay()
        {
            AppShell.Current.GoToAsync("BasicGameplayView", false);
            _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Landscape);
        }
    }
}
