using KnockKnockApp.Services;
using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class ManagePlayers : ContentPage
{
    private readonly ManagePlayersViewModel _viewModel;
    private readonly IDeviceOrientationService _deviceOrientationService;
    private readonly ISubscriptionManagementService _subscriptionManagementService;

    public ManagePlayers(ManagePlayersViewModel viewModel, IDeviceOrientationService deviceOrientationService, ISubscriptionManagementService subscriptionManagementService)
    {
        BindingContext = _viewModel = viewModel;
        _deviceOrientationService = deviceOrientationService;
        _subscriptionManagementService = subscriptionManagementService;
        InitializeComponent();
        Loaded += OnPageLoaded;

        Task.Run(() =>
        {
            _ = _subscriptionManagementService.UpdateAccountInformation();
        });
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
        SpielerNameEntry.IsEnabled = true;
        SpielerNameEntry.Focus();
    }

    private void OnPageLoaded(object sender, EventArgs e)
    {
        SpielerNameEntry.IsEnabled = true;
        Task.Run(() =>
        {
            Task.Delay(200).Wait();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                SpielerNameEntry.Focus();
            });
        });
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
#if ANDROID
        SpielerNameEntry.IsEnabled = false;
#endif
    }
}