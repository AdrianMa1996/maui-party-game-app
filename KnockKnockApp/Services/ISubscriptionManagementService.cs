using KnockKnockApp.Models;

namespace KnockKnockApp.Services
{
    public interface ISubscriptionManagementService
    {
        void PurchaseSubscription();
        AccountInformation GetAccountInformation();
    }
}
