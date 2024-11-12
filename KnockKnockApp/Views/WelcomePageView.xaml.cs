using KnockKnockApp.Services;
using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class WelcomePageView : ContentPage
{
    private readonly WelcomePageViewModel _viewModel;
    private readonly IDeviceOrientationService _deviceOrientationService;

    public WelcomePageView(WelcomePageViewModel viewModel, IDeviceOrientationService deviceOrientationService)
	{
        BindingContext = _viewModel = viewModel;
        _deviceOrientationService = deviceOrientationService;
        InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
    }
}