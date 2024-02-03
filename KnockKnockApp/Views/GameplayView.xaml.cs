using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class GameplayView : ContentPage
{
    private readonly GameplayViewModel _viewModel;

    public GameplayView(GameplayViewModel viewModel)
    {
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
    }
}