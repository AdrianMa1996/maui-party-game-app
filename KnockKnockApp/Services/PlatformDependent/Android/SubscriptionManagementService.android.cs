using KnockKnockApp.Models;

namespace KnockKnockApp.Services
{
    public partial class SubscriptionManagementService
    {
        private static string productId = "";
        private bool testBool = false;

        public partial AccountInformation GetAccountInformation() // hole das AccountInformation-Objekt
        {
            return AccountInformation;
        }

        public partial async Task<bool> PurchaseSubscription() // kaufe prime
        {
            await Task.Delay(3000); // simuliert die Zeit des Kaufs
            testBool = true; // testbool simuliert einen erfolgreichen kauf
            return true;
        }

        public partial async Task UpdateAccountInformation() // checke, ob prime aktiv ist (AccountInformation-Objekt aktuallisieren)
        {
            await Task.Delay(3000); // simuliert die zeit des abfragens
            if (testBool)
            {
                AccountInformation.IsPrimeSubscriptionActive = true;
            }
        }
    }
}
