using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Services;

namespace KnockKnockApp.ViewModels
{
    public partial class TermsOfUseViewModel : ObservableObject
    {
        public TermsOfUseViewModel(ILocalizationService localizationService)
        {
            LocalizationService = localizationService;
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [RelayCommand]
        public void CloseTermsOfUse()
        {
            Shell.Current.GoToAsync("..", false);
        }
    }
}
