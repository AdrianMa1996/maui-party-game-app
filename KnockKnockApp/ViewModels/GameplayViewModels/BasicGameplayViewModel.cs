using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Services;

namespace KnockKnockApp.ViewModels.GameplayViewModels
{
    public partial class BasicGameplayViewModel : ObservableObject
    {
        private readonly IDeviceOrientationService _deviceOrientationService;

        public BasicGameplayViewModel(IDeviceOrientationService deviceOrientationService)
        {
            _deviceOrientationService = deviceOrientationService;
        }

        [RelayCommand]
        public void NavigateToSelectGameMode()
        {
            Shell.Current.GoToAsync("..", false);
            _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
        }
    }
}
