using KnockKnockApp.ViewModels;
using KnockKnockApp.Services;
using Microsoft.Maui.Controls;

namespace KnockKnockApp.Views;

public partial class SelectGameModeView : ContentPage
{
    private readonly SelectGameModeViewModel _viewModel;
    private readonly IDeviceOrientationService _deviceOrientationService;

    public SelectGameModeView(SelectGameModeViewModel viewModel, IDeviceOrientationService deviceOrientationService)
	{
        BindingContext = _viewModel = viewModel;
        _deviceOrientationService = deviceOrientationService;
        InitializeComponent();
	}

    private async void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        await Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (Resources.TryGetValue("GameModeCollectionView", out var template2))
                {
                    GameModeContentView.Content = (template2 as DataTemplate)?.CreateContent() as View;
                }
            });
        });
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait);
    }

    private async void ButtonClickedShowTeamGameModeCollection(object sender, EventArgs e)
    {
        if (Resources.TryGetValue("GameModeCollectionActivityIndicator", out var template1))
        {
            GameModeContentView.Content = (template1 as DataTemplate)?.CreateContent() as View;
            await Task.Delay(50);
        }

        _viewModel.ShowTeamGameModeCollection();

        if (Resources.TryGetValue("GameModeCollectionView", out var template2))
        {
            await Task.Delay(50);
            GameModeContentView.Content = (template2 as DataTemplate)?.CreateContent() as View;
        }
    }

    private async void ButtonClickedShowSoloGameModeCollection(object sender, EventArgs e)
    {
        if (Resources.TryGetValue("GameModeCollectionActivityIndicator", out var template1))
        {
            GameModeContentView.Content = (template1 as DataTemplate)?.CreateContent() as View;
            await Task.Delay(50);
        }

        _viewModel.ShowSoloGameModeCollection();

        if (Resources.TryGetValue("GameModeCollectionView", out var template2))
        {
            await Task.Delay(50);
            GameModeContentView.Content = (template2 as DataTemplate)?.CreateContent() as View;
        }
    }
}