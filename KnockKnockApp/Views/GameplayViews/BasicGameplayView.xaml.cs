using KnockKnockApp.ViewModels.GameplayViewModels;

namespace KnockKnockApp.Views.GameplayViews;

public partial class BasicGameplayView : ContentPage
{
    private readonly BasicGameplayViewModel _viewModel;

    public BasicGameplayView(BasicGameplayViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}
}