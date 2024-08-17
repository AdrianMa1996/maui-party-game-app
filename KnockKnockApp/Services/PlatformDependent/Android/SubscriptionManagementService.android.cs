using KnockKnockApp.Models;

namespace KnockKnockApp.Services
{
    public partial class SubscriptionManagementService
    {
        public partial void PurchaseSubscription()
        {
            AccountInformation.IsPrimeSubscriptionActive = true;
        }

        public partial AccountInformation GetAccountInformation()
        {
            return AccountInformation;
        }
    }
}
