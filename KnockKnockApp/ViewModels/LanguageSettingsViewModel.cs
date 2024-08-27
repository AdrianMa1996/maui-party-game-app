using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Services;
using System.Collections.ObjectModel;

namespace KnockKnockApp.ViewModels
{
    public partial class LanguageSettingsViewModel : ObservableObject
    {
        public LanguageSettingsViewModel(ILocalizationService localizationService)
        {
            LocalizationService = localizationService;
            Localizations = LocalizationService.GetLocalizations();
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [ObservableProperty]
        public ObservableCollection<Localization> localizations;

        [RelayCommand]
        public void ChangeLocalization(Localization localization)
        {
            LocalizationService.SetCurrentLocalization(localization);
            Shell.Current.GoToAsync("..", false);
        }

        [RelayCommand]
        public void NavigateToManagePlayers()
        {
            Shell.Current.GoToAsync("..", false);
        }
    }
}
