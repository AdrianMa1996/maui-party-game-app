using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Repositories;
using KnockKnockApp.Services;
using System.Collections.ObjectModel;

namespace KnockKnockApp.ViewModels
{
    public partial class WelcomePageViewModel : ObservableObject
    {
        private readonly ISettingsRepository _settingsRepository;

        public WelcomePageViewModel(ILocalizationService localizationService, ISettingsRepository settingsRepository)
        {
            LocalizationService = localizationService;
            _settingsRepository = settingsRepository;
            IsWarningMessageVisible = true;
            IsInformationPopupVisible = false;

            Task.Run(async () =>
            {
                Settings = await _settingsRepository.GetSettingsAsync();
            });
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [ObservableProperty]
        public Settings settings;

        [ObservableProperty]
        public bool isWarningMessageVisible;

        [ObservableProperty]
        public bool isInformationPopupVisible;

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

        [RelayCommand]
        public void CloseWarningMessage()
        {
            IsWarningMessageVisible = false;
        }

        [RelayCommand]
        public void OpenInformationPopup()
        {
            IsInformationPopupVisible = true;
        }

        [RelayCommand]
        public void CloseInformationPopup()
        {
            IsInformationPopupVisible = false;
            _settingsRepository.UpdateSettingsAsync(Settings);
        }

        [RelayCommand]
        public async Task OpenAmazonKnockKnockCardGame()
        {
            await Launcher.OpenAsync("https://www.amazon.de/dp/B0F9LGCDMJ");
        }
    }
}
