using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Services;

namespace KnockKnockApp.ViewModels.CardGameExtension
{
    [QueryProperty(nameof(CurrentExtension), "Extension")]
    public partial class ExtensionGameplayViewModel : ObservableObject
    {
        public ExtensionGameplayViewModel(ILocalizationService localizationService)
        {
            LocalizationService = localizationService;
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [ObservableProperty]
        private Extension? currentExtension;

        [RelayCommand]
        public async void NavigateToSelectCardGameExtension()
        {
            var answer = await Application.Current.MainPage.DisplayAlert("Partie verlassen?", "Seid ihr sicher, dass ihr die Partie verlassen wollt?", "Ja", "Nein");
            if (answer)
            {
                Shell.Current.GoToAsync("..", false);
            }
        }
    }
}
