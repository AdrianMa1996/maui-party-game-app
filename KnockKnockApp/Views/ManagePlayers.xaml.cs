using KnockKnockApp.ViewModels;

namespace KnockKnockApp.Views;

public partial class ManagePlayers : ContentPage
{
    private readonly ManagePlayersViewModel _viewModel;

    public ManagePlayers(ManagePlayersViewModel viewModel)
    {
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
        Loaded += OnPageLoaded;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SpielerNameEntry.IsEnabled = true;
        SpielerNameEntry.Focus();
    }

    private void OnPageLoaded(object sender, EventArgs e)
    {
        SpielerNameEntry.IsEnabled = true;
        SpielerNameEntry.Focus();
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        SpielerNameEntry.IsEnabled = false;
    }
}