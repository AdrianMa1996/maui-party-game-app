using CommunityToolkit.Mvvm.ComponentModel;
using KnockKnockApp.Models;
//using Plugin.InAppBilling;
//using System.Diagnostics;

namespace KnockKnockApp.Services
{
    [ObservableObject]
    public partial class SubscriptionManagementService : ISubscriptionManagementService
    {
        [ObservableProperty]
        public AccountInformation accountInformation = new AccountInformation();

        public partial void PurchaseSubscription();
        public partial AccountInformation GetAccountInformation();

        //private async Task<bool> CheckItem(string productId, string payload)
        //{
        //    var billing = CrossInAppBilling.Current;
        //    var returnValue = false;
        //    try
        //    {
        //        var connected = await billing.ConnectAsync();
        //        if (!connected)
        //        {
        //            //we are offline or can't connect, don't try to purchase
        //            return false;
        //        }

        //        //get purchases
        //        var purchaseList = await billing.GetPurchasesAsync(ItemType.Subscription);
        //        var purchase = purchaseList.FirstOrDefault(p => p.ProductId == productId);

        //        if (purchase.State == PurchaseState.Purchased)
        //        {
        //            returnValue = true;
        //        }

        //        return returnValue;
        //    }
        //    catch (Exception ex)
        //    {
        //        //Something has gone wrong, log it
        //        Debug.WriteLine("Issue connecting: " + ex);
        //    }
        //    finally
        //    {
        //        await billing.DisconnectAsync();
        //    }

        //    return returnValue;
        //}

        //private async Task<bool> PurchaseItem(string productId, string payload)
        //{
        //    var billing = CrossInAppBilling.Current;
        //    var returnValue = false;
        //    try
        //    {
        //        var connected = await billing.ConnectAsync();
        //        if (!connected)
        //        {
        //            //we are offline or can't connect, don't try to purchase
        //            return false;
        //        }

        //        //get purchases
        //        var purchaseList = await billing.GetPurchasesAsync(ItemType.Subscription);
        //        var purchase = purchaseList.FirstOrDefault(p => p.ProductId == productId);

        //        //Wenn noch nicht aktiv
        //        if (purchase.State == PurchaseState.Purchased)
        //        {
        //            //purchases durchführen
        //            purchase = await billing.PurchaseAsync(purchase.ProductId, ItemType.Subscription);
        //        }

        //        //possibility that a null came through.
        //        if (purchase == null)
        //        {
        //            //did not purchase
        //        }
        //        else if (purchase.State == PurchaseState.Purchased)
        //        {
        //            //only needed on android unless you turn off auto finalize
        //            var ack = await CrossInAppBilling.Current.FinalizePurchaseAsync(purchase.TransactionIdentifier);

        //            // Handle if acknowledge was successful or not
        //            returnValue = true;
        //        }
        //    }
        //    catch (InAppBillingPurchaseException purchaseEx)
        //    {
        //        //Billing Exception handle this based on the type
        //        Debug.WriteLine("Error: " + purchaseEx);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Something else has gone wrong, log it
        //        Debug.WriteLine("Issue connecting: " + ex);
        //    }
        //    finally
        //    {
        //        await billing.DisconnectAsync();
        //    }

        //    return returnValue;
        //}
    }
}
