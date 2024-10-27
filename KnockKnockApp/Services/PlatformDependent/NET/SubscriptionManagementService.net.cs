using KnockKnockApp.Models;

namespace KnockKnockApp.Services
{
    public partial class SubscriptionManagementService
    {
        public partial async Task<bool> PurchaseSubscription()
        {
            return true;
        }

        public partial AccountInformation GetAccountInformation()
        {
            return AccountInformation;
        }

        public partial async Task UpdateAccountInformation()
        {
            return;
        }
    }
}
