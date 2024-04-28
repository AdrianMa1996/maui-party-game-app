using CommunityToolkit.Maui.Views;
using KnockKnockApp.ViewModels.PopupViewModels;

namespace KnockKnockApp.Views.PopupViews;

public partial class ManagePlayersPopupView : Popup
{
    private readonly ManagePlayersPopupViewModel _viewModel;

    public ManagePlayersPopupView(ManagePlayersPopupViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}

    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}