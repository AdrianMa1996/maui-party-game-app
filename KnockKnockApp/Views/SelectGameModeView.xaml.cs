using KnockKnockApp.ViewModels;
using KnockKnockApp.Services;

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
                if (Resources.TryGetValue("GameModeCollectionView", out var grid))
                {
                    GameModeContentView.Content = grid as View;
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
        await Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (Resources.TryGetValue("GameModeCollectionActivityIndicator", out var grid))
                {
                    GameModeContentView.Content = grid as View;
                }
            });
        });

        await Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _viewModel.ShowTeamGameModeCollection();
            });
        });

        await Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (Resources.TryGetValue("GameModeCollectionView", out var grid))
                {
                    GameModeContentView.Content = grid as View;
                }
            });
        });
    }

    private async void ButtonClickedShowSoloGameModeCollection(object sender, EventArgs e)
    {
        await Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (Resources.TryGetValue("GameModeCollectionActivityIndicator", out var grid))
                {
                    GameModeContentView.Content = grid as View;
                }
            });
        });

        await Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _viewModel.ShowSoloGameModeCollection();
            });
        });

        await Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (Resources.TryGetValue("GameModeCollectionView", out var grid))
                {
                    GameModeContentView.Content = grid as View;
                }
            });
        });
    }
}