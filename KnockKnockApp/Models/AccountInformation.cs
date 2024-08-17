using CommunityToolkit.Mvvm.ComponentModel;

namespace KnockKnockApp.Models
{
    public partial class AccountInformation : ObservableObject
    {
        [ObservableProperty]
        public bool isPrimeSubscriptionActive = false;
    }
}
