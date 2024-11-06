using KnockKnockApp.ViewModels.CardGameExtension;

namespace KnockKnockApp.Views.CardGameExtension;

public partial class ExtensionGameplayView : ContentPage
{
    private readonly ExtensionGameplayViewModel _viewModel;

    public ExtensionGameplayView(ExtensionGameplayViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}
}