using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Services;
using System.Collections.ObjectModel;
using System.Globalization;

namespace KnockKnockApp.ViewModels.PopupViewModels
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

        [ObservableProperty]
        public string textBeispiel = "Das ist das Textbeispiel";

        [RelayCommand]
        public void ChangeLocalization(Localization localization)
        {
            var switchToCulture = new CultureInfo("nl-NL");

            LocalizationService.SetCulture(switchToCulture);
        }
    }
}
