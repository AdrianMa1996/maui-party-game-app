using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class GameModeSettingsView : ContentPage
{
    private readonly GameModeSettingsViewModel _viewModel;

    public GameModeSettingsView(GameModeSettingsViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
    }

    private async void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        await Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (Resources.TryGetValue("GameModeAndCardSetBindingCollectionView", out var grid))
                {
                    GameModeAndCardSetBindingContentView.Content = grid as View;
                }
            });
        });
    }
}