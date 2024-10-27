using KnockKnockApp.Models;

namespace KnockKnockApp.Services
{
    public interface ISubscriptionManagementService
    {
        AccountInformation GetAccountInformation();
        Task<bool> PurchaseSubscription();
        Task UpdateAccountInformation();
    }
}
