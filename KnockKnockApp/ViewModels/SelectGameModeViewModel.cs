using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Services;
using KnockKnockApp.TemporaryData;
using KnockKnockApp.Views.GameplayViews;

namespace KnockKnockApp.ViewModels
{
    public partial class SelectGameModeViewModel : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDeviceOrientationService _deviceOrientationService;

        public SelectGameModeViewModel(IServiceProvider serviceProvider, IDeviceOrientationService deviceOrientationService)
        {
            _serviceProvider = serviceProvider;
            _deviceOrientationService = deviceOrientationService;
        }

        [ObservableProperty]
        public GeneralData generalDataInstance = GeneralData.Instance;

        [RelayCommand]
        public void NavigateToManagePlayers()
        {
            _ = Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        public void NavigateToGameplay()
        {
            var basicGameplayView = _serviceProvider.GetService<BasicGameplayView>();
            _ = Application.Current.MainPage.Navigation.PushAsync(basicGameplayView, false);
            _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Landscape);
        }
    }
}
