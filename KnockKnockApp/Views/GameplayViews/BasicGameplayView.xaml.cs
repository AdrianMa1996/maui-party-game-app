using KnockKnockApp.ViewModels.GameplayViewModels;
using KnockKnockApp.Services;

namespace KnockKnockApp.Views.GameplayViews;

public partial class BasicGameplayView : ContentPage
{
    private readonly BasicGameplayViewModel _viewModel;
    private readonly IDeviceOrientationService _deviceOrientationService;

    public BasicGameplayView(BasicGameplayViewModel viewModel, IDeviceOrientationService deviceOrientationService)
	{
        BindingContext = _viewModel = viewModel;
        _deviceOrientationService = deviceOrientationService;
        InitializeComponent();
        viewModel.ShowManagePlayersRequested += OnShowManagePlayersPopup;
        viewModel.HideManagePlayersRequested += OnHideManagePlayersPopup;
    }

    private async void OnShowManagePlayersPopup(object sender, EventArgs e)
    {
        _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
        SpielerNameEntry.IsEnabled = true;
        await Task.Delay(100);
        SpielerNameEntry.Focus();
    }

    private async void OnHideManagePlayersPopup(object sender, EventArgs e)
    {
        _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Landscape);
        SpielerNameEntry.IsEnabled = false;
    }

    protected override bool OnBackButtonPressed()
    {
        _viewModel.NavigateToSelectGameMode();
        return true;
    }
}