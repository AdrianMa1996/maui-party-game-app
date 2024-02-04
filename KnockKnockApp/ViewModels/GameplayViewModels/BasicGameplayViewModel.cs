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
            _ = Application.Current.MainPage.Navigation.PopAsync(false);
            _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
        }
    }
}
