using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Services;
using System.Collections.ObjectModel;

namespace KnockKnockApp.ViewModels
{
    public partial class WelcomePageViewModel : ObservableObject
    {
        public WelcomePageViewModel(ILocalizationService localizationService)
        {
            LocalizationService = localizationService;
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [RelayCommand]
        public void NavigateToManagePlayers()
        {
            AppShell.Current.GoToAsync("ManagePlayers", true);
        }

        [RelayCommand]
        public void NavigateToSelectCardGameExtension()
        {
            AppShell.Current.GoToAsync("SelectCardGameExtensionView", true);
        }

        [RelayCommand]
        public async Task OpenTermsOfUseUrl()
        {
            await Launcher.OpenAsync("https://knockknock-partygame.com/knockknock-app/nutzungsbedingungen");
        }

        [RelayCommand]
        public async Task OpenPrivacyPolicyUrl()
        {
            await Launcher.OpenAsync("https://knockknock-partygame.com/knockknock-app/datenschutzbestimmungen");
        }
    }
}
