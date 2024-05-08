using KnockKnockApp.Models.Database;

namespace KnockKnockApp.Views;

[QueryProperty(nameof(GameMode), "GameMode")]
public partial class LoadingBasicGameplayView : ContentPage
{
    public LoadingBasicGameplayView()
    {
        InitializeComponent();
    }

    private GameMode gameMode;

    public GameMode GameMode
    {
        get => gameMode;
        set
        {
            if (gameMode == value) return;
            gameMode = value;
            OnPropertyChanged();
        }
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        await Task.Run(() =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var navParam = new Dictionary<string, object>
                {
                    { "GameMode", gameMode }
                };

                AppShell.Current.GoToAsync("../BasicGameplayView", false, navParam);
            });
        });
    }
}