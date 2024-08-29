using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Services;

namespace KnockKnockApp.ViewModels
{
    public partial class PrivacyPolicyViewModel : ObservableObject
    {
        public PrivacyPolicyViewModel(ILocalizationService localizationService)
        {
            LocalizationService = localizationService;
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [RelayCommand]
        public void ClosePrivacyPolicy()
        {
            Shell.Current.GoToAsync("..", false);
        }
    }
}
