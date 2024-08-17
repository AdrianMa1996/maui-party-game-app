using CommunityToolkit.Maui.Views;
using KnockKnockApp.ViewModels.PopupViewModels;

namespace KnockKnockApp.Views.PopupViews;

public partial class PurchasePrimePopupView : Popup
{
    private readonly PurchasePrimePopupViewModel _viewModel;

    public PurchasePrimePopupView(PurchasePrimePopupViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}

    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}