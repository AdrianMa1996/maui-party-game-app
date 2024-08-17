using KnockKnockApp.Models;

namespace KnockKnockApp.Services
{
    public interface ISubscriptionManagementService
    {
        void PurchaseSubscription(); // sollte true bzw. false zurückgeben, um dann entsprechend das Popup zu schließen
        AccountInformation GetAccountInformation();
    }
}
