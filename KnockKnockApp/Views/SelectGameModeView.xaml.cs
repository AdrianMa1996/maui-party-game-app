using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class SelectGameModeView : ContentView
{
    private readonly GameplayViewModel _viewModel;

    public SelectGameModeView(GameplayViewModel viewModel)
    {
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
    }
}