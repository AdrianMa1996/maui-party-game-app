using KnockKnockApp.ViewModels;
using KnockKnockApp.ViewModels.CardGameExtension;

namespace KnockKnockApp.Views.CardGameExtension;

public partial class SelectCardGameExtensionView : ContentPage
{
    private readonly SelectCardGameExtensionViewModel _viewModel;

    public SelectCardGameExtensionView(SelectCardGameExtensionViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}

    private async void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        await Task.Run(() =>
        {
            Task.Delay(200).Wait();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                if (Resources.TryGetValue("ExtensionCollectionView", out var grid))
                {
                    CardGameExtensionContentView.Content = grid as CollectionView;
                }
            });
        });
    }
}