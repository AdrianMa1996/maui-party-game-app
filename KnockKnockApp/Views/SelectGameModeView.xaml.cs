using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class SelectGameModeView : ContentPage
{
    private readonly SelectGameModeViewModel _viewModel;

    public SelectGameModeView(SelectGameModeViewModel viewModel)
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
                if (Resources.TryGetValue("GameModeCollectionView", out var grid))
                {
                    GameModeContentView.Content = grid as View;
                }
            });
        });
    }
}