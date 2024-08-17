using CommunityToolkit.Mvvm.ComponentModel;
using KnockKnockApp.Models;

namespace KnockKnockApp.Services
{
    [ObservableObject]
    public partial class SubscriptionManagementService : ISubscriptionManagementService
    {
        [ObservableProperty]
        public AccountInformation accountInformation = new AccountInformation();

        public partial void PurchaseSubscription();
        public partial AccountInformation GetAccountInformation();
    }
}
