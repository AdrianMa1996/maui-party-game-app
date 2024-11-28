using KnockKnockApp.Models;

namespace KnockKnockApp.Services
{
    public partial class SubscriptionManagementService
    {
        private static string productId = "";
        private static bool testBool = false;

        public partial AccountInformation GetAccountInformation()
        {
            return AccountInformation;
        }

        public partial async Task<bool> PurchaseSubscription()
        {
            //await Task.Delay(3000);
            // testBool = true;
            return true;
        }

        public partial async Task UpdateAccountInformation()
        {
            //await Task.Delay(3000);
            //if (testBool)
            //{
            //    AccountInformation.IsPrimeSubscriptionActive = true;
            //}

            AccountInformation.IsPrimeSubscriptionActive = true;
        }
    }
}
