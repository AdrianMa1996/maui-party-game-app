using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class LanguageSettingsView : ContentPage
{
    private readonly LanguageSettingsViewModel _viewModel;

    public LanguageSettingsView(LanguageSettingsViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}
}