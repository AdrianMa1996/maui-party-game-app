using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Services;
using KnockKnockApp.TemporaryData;
using KnockKnockApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnockKnockApp.ViewModels
{
    public partial class GameplayViewModel : ObservableObject
    {
        private readonly IDeviceOrientationService _deviceOrientationService;

        public GameplayViewModel(IDeviceOrientationService deviceOrientationService)
        {
            _deviceOrientationService = deviceOrientationService;
            currentView = new SelectGameModeView(this);
        }

        [ObservableProperty]
        public GeneralData generalDataInstance = GeneralData.Instance;

        [RelayCommand]
        public void NavigateToManagePlayers()
        {
            _ = Application.Current.MainPage.Navigation.PopAsync();
        }

        [ObservableProperty]
        public object currentView;

        [RelayCommand]
        public void ChangeCurrentView1()
        {
            CurrentView = new GameCardView(this);
            _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Landscape);
        }

        [RelayCommand]
        public void ChangeCurrentView2()
        {
            CurrentView = new SelectGameModeView(this);
            _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
        }
    }
}
