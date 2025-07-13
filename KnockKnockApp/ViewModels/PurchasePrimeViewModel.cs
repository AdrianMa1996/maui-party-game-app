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

        [ObservableProperty]
        public bool isLoading = false;

        [RelayCommand]
        public void NavigateToSelectGameMode()
        {
            Shell.Current.GoToAsync("..", false);
        }

        [RelayCommand]
        public async Task BuyPrimeSubscription()
        {
            IsLoading = true;
            await _subscriptionManagementService.PurchaseSubscription();
            await _subscriptionManagementService.UpdateAccountInformation();
            await Shell.Current.GoToAsync("..", false);
            IsLoading = false;
        }

        [RelayCommand]
        public async Task RestorePurchases()
        {
            IsLoading = true;
            await _subscriptionManagementService.UpdateAccountInformation();
            await Shell.Current.GoToAsync("..", false);
            IsLoading = false;
        }

        [RelayCommand]
        public void OpenTermsOfUse()
        {
            Launcher.OpenAsync("https://knockknock-partygame.com/knockknock-app/nutzungsbedingungen");
        }

        [RelayCommand]
        public void OpenPrivacyPolicy()
        {
            Launcher.OpenAsync("https://knockknock-partygame.com/knockknock-app/datenschutzbestimmungen");
        }
    }
}
