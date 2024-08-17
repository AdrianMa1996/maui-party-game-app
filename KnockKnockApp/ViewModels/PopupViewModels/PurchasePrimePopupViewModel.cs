using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Services;

namespace KnockKnockApp.ViewModels.PopupViewModels
{
    public partial class PurchasePrimePopupViewModel : ObservableObject
    {
        private readonly ISubscriptionManagementService _subscriptionManagementService;

        public PurchasePrimePopupViewModel(ILocalizationService localizationService, ISubscriptionManagementService subscriptionManagementService)
        {
            LocalizationService = localizationService;
            _subscriptionManagementService = subscriptionManagementService;
        }

        [ObservableProperty]
        public ILocalizationService localizationService;

        [RelayCommand]
        public void BuyPrimeSubscription()
        {
            _subscriptionManagementService.PurchaseSubscription();
        }
    }
}
