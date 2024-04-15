using CommunityToolkit.Maui.Views;
using KnockKnockApp.ViewModels;
using KnockKnockApp.ViewModels.PopupViewModels;

namespace KnockKnockApp.Views.PopupViews;

public partial class LanguageSettingsView : Popup
{
    private readonly LanguageSettingsViewModel _viewModel;

    public LanguageSettingsView(LanguageSettingsViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}

    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}