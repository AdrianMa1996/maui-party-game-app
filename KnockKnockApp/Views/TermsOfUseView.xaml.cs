using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class TermsOfUseView : ContentPage
{
    private readonly TermsOfUseViewModel _viewModel;

    public TermsOfUseView(TermsOfUseViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}
}