using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class PrivacyPolicyView : ContentPage
{
    private readonly PrivacyPolicyViewModel _viewModel;

    public PrivacyPolicyView(PrivacyPolicyViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}
}