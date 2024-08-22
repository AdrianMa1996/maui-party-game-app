using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class PurchasePrimeView : ContentPage
{
    private readonly PurchasePrimeViewModel _viewModel;

    public PurchasePrimeView(PurchasePrimeViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}
}