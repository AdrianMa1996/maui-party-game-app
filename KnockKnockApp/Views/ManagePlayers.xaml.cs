using KnockKnockApp.Services;
using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class ManagePlayers : ContentPage
{
    private readonly ManagePlayersViewModel _viewModel;
    private readonly IDeviceOrientationService _deviceOrientationService;

    public ManagePlayers(ManagePlayersViewModel viewModel, IDeviceOrientationService deviceOrientationService)
    {
        BindingContext = _viewModel = viewModel;
        _deviceOrientationService = deviceOrientationService;
        InitializeComponent();
        Loaded += OnPageLoaded;
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
        SpielerNameEntry.Focus();
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        SpielerNameEntry.IsEnabled = false;
    }
}