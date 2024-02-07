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
}