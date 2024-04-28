using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using KnockKnockApp.Services;
using KnockKnockApp.ViewModels.PopupViewModels;

namespace KnockKnockApp.Views.PopupViews;

public partial class ManagePlayersPopupView : Popup
{
    private readonly ManagePlayersPopupViewModel _viewModel;
    private readonly IDeviceOrientationService _deviceOrientationService;

    public ManagePlayersPopupView(ManagePlayersPopupViewModel viewModel, IDeviceOrientationService deviceOrientationService)
	{
        BindingContext = _viewModel = viewModel;
        _deviceOrientationService = deviceOrientationService;
        InitializeComponent();
        Opened += OnPopupOpened;
        Closed += OnPopupClosed;
    }

    private void OnPopupOpened(object? sender, PopupOpenedEventArgs e)
    {
        _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
        SpielerNameEntry.IsEnabled = true;
        SpielerNameEntry.Focus();
    }

    private void OnPopupClosed(object? sender, PopupClosedEventArgs e)
    {
        _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Landscape);
        SpielerNameEntry.IsEnabled = false;
    }

    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}