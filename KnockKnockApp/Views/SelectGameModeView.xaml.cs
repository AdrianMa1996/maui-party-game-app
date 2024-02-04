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
}