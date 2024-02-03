using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class GameCardView : ContentView
{
    private readonly GameplayViewModel _viewModel;

    public GameCardView(GameplayViewModel viewModel)
    {
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
    }
}