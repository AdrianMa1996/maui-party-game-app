using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Services;

namespace KnockKnockApp.ViewModels
{
    public partial class PurchasePrimeViewModel : ObservableObject
    {
        private readonly ISubscriptionManagementService _subscriptionManagementService;

        public PurchasePrimeViewModel(ILocalizationService localizationService, ISubscriptionManagementService subscriptionManagementService)
        {
            LocalizationService = localizationService;
            _subscriptionManagementService = subscriptionManagementService;
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [RelayCommand]
        public void NavigateToSelectGameMode()
        {
            Shell.Current.GoToAsync("..", false);
        }

        [RelayCommand]
        public async Task BuyPrimeSubscription()
        {
            await _subscriptionManagementService.PurchaseSubscription();
            _ = _subscriptionManagementService.UpdateAccountInformation();
            await Shell.Current.GoToAsync("..", false);
        }

        [RelayCommand]
        public void OpenTermsOfUse()
        {
            AppShell.Current.GoToAsync("TermsOfUseView", false);
        }

        [RelayCommand]
        public void OpenPrivacyPolicy()
        {
            AppShell.Current.GoToAsync("PrivacyPolicyView", false);
        }
    }
}
