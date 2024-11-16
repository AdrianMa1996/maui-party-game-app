using KnockKnockApp.Models;
using Plugin.InAppBilling;

namespace KnockKnockApp.Services
{
    public partial class SubscriptionManagementService
    {
        private static string productId = "knockknock_premium_weekly";

        public partial AccountInformation GetAccountInformation()
        {
            return AccountInformation;
        }

        public partial async Task<bool> PurchaseSubscription()
        {
            var returnValue = false;

            if (CrossInAppBilling.IsSupported == false)
            {
                return returnValue;
            }

            var billing = CrossInAppBilling.Current;
            try
            {
                var connected = await billing.ConnectAsync();
                if (!connected)
                {
                    return returnValue;
                }

                //purchases
                var purchase = await billing.PurchaseAsync(productId, ItemType.Subscription);

                //possibility that a null came through.
                if (purchase != null && purchase.State == PurchaseState.Purchased)
                {
                    //only needed on android unless you turn off auto finalize
                    var ack = await CrossInAppBilling.Current.FinalizePurchaseAsync([purchase.TransactionIdentifier]);

                    // Handle if acknowledge was successful or not
                    if (ack.FirstOrDefault().Success)
                    {
                        returnValue = true;
                    }
                }
            }
            catch (InAppBillingPurchaseException purchaseEx)
            {
                //Something has gone wrong, log it
            }
            catch (Exception ex)
            {
                //Something has gone wrong, log it
            }
            finally
            {
                await billing.DisconnectAsync();
            }

            return returnValue;
        }

        public partial async Task UpdateAccountInformation()
        {
            // AccountInformation.IsPrimeSubscriptionActive = true;

            if (CrossInAppBilling.IsSupported == false)
            {
                return;
            }

            var billing = CrossInAppBilling.Current;
            try
            {
                var connected = await billing.ConnectAsync();
                if (!connected)
                {
                    //Couldn't connect
                    return;
                }

                //get purchase
                var purchaseList = await billing.GetPurchasesAsync(ItemType.Subscription);
                var purchase = purchaseList.FirstOrDefault(p => p.ProductId == productId);

                if (purchase != null && purchase.State == PurchaseState.Purchased)
                {
                    AccountInformation.IsPrimeSubscriptionActive = true;
                }
            }
            catch (Exception ex)
            {
                //Something has gone wrong, log it
            }
            finally
            {
                await billing.DisconnectAsync();
            }
        }
    }
}
