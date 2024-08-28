using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Views.GameplayViews;

public partial class StopWatchGamecardView : ContentView
{
    public static readonly BindableProperty CurrentCardProperty = BindableProperty.Create(nameof(CurrentCard), typeof(GameCardDto), typeof(StopWatchGamecardView), propertyChanged: OnGamecardChanged);

    static void OnGamecardChanged(BindableObject bindable, object oldValue, object newValue)
    {
        StopWatchGamecardView gamecardView = (StopWatchGamecardView)bindable;
        gamecardView.AnimateCardText();
    }

    public GameCardDto CurrentCard
    {
        get => (GameCardDto)GetValue(CurrentCardProperty);
        set => SetValue(CurrentCardProperty, value);
    }

    public static readonly BindableProperty CurrentGameModeProperty = BindableProperty.Create(nameof(CurrentGameMode), typeof(GameMode), typeof(StopWatchGamecardView));

    public GameMode CurrentGameMode
    {
        get => (GameMode)GetValue(CurrentGameModeProperty);
        set => SetValue(CurrentGameModeProperty, value);
    }

    public static readonly BindableProperty TeamOneProperty = BindableProperty.Create(nameof(TeamOne), typeof(Team), typeof(StopWatchGamecardView));

    public Team TeamOne
    {
        get => (Team)GetValue(TeamOneProperty);
        set => SetValue(TeamOneProperty, value);
    }

    public static readonly BindableProperty TeamTwoProperty = BindableProperty.Create(nameof(TeamTwo), typeof(Team), typeof(StopWatchGamecardView));

    public Team TeamTwo
    {
        get => (Team)GetValue(TeamTwoProperty);
        set => SetValue(TeamTwoProperty, value);
    }

    public static readonly BindableProperty PointsToTeamOneCommandProperty = BindableProperty.Create(nameof(PointsToTeamOneCommand), typeof(RelayCommand), typeof(StopWatchGamecardView));

    public RelayCommand PointsToTeamOneCommand
    {
        get => (RelayCommand)GetValue(PointsToTeamOneCommandProperty);
        set => SetValue(PointsToTeamOneCommandProperty, value);
    }

    public static readonly BindableProperty PointsToTeamTwoCommandProperty = BindableProperty.Create(nameof(PointsToTeamTwoCommand), typeof(RelayCommand), typeof(StopWatchGamecardView));

    public RelayCommand PointsToTeamTwoCommand
    {
        get => (RelayCommand)GetValue(PointsToTeamTwoCommandProperty);
        set => SetValue(PointsToTeamTwoCommandProperty, value);
    }

    public static readonly BindableProperty NavigateToManagePlayersCommandProperty = BindableProperty.Create(nameof(NavigateToManagePlayersCommand), typeof(RelayCommand), typeof(StopWatchGamecardView));

    public RelayCommand NavigateToManagePlayersCommand
    {
        get { return (RelayCommand)GetValue(NavigateToManagePlayersCommandProperty); }
        set { SetValue(NavigateToManagePlayersCommandProperty, value); }
    }

    public static readonly BindableProperty NavigateToSelectGameModeCommandProperty = BindableProperty.Create(nameof(NavigateToSelectGameModeCommand), typeof(RelayCommand), typeof(StopWatchGamecardView));

    public RelayCommand NavigateToSelectGameModeCommand
    {
        get { return (RelayCommand)GetValue(NavigateToSelectGameModeCommandProperty); }
        set { SetValue(NavigateToSelectGameModeCommandProperty, value); }
    }

    public static readonly BindableProperty DisplayNextCardCommandProperty = BindableProperty.Create(nameof(DisplayNextCardCommand), typeof(RelayCommand), typeof(StopWatchGamecardView));

    public RelayCommand DisplayNextCardCommand
    {
        get => (RelayCommand)GetValue(DisplayNextCardCommandProperty);
        set => SetValue(DisplayNextCardCommandProperty, value);
    }

    public StopWatchGamecardView()
	{
		InitializeComponent();
	}

    IDispatcherTimer timer;
    private int stopWatchTime = 30;
    private int currentStopWatchTime;
    TimeSpan tickVibrationLength = TimeSpan.FromMilliseconds(50);

    private async void this_Loaded(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            StopWatchLabel.Text = stopWatchTime.ToString("D2") + " Sekunden";
        });
        EndStopWatchButton.IsVisible = true;
        currentStopWatchTime = stopWatchTime;
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(1000);
        timer.Tick += (s, e) =>
        {
            Vibration.Default.Vibrate(tickVibrationLength);
            currentStopWatchTime--;
            MainThread.BeginInvokeOnMainThread(() =>
            {
                StopWatchLabel.Text = currentStopWatchTime.ToString("D2") + " Sekunden";
            });
            if (currentStopWatchTime <= 0)
            {
                timer.Stop();
                _ = LetStopWatchStop();
            }
        };

        timer.Start();
    }

    private async void EndStopWatchButton_Clicked(object sender, EventArgs e)
    {
        var answer = await Application.Current.MainPage.DisplayAlert("Timer vorzeitig anhalten?", "Seid ihr sicher, dass ihr den Timer vorzeitig anhalten wollt?", "Ja", "Nein");
        if (timer.IsRunning && answer)
        {
            await LetStopWatchStop();
        }
    }

    private async Task LetStopWatchStop()
    {
        TimeSpan vibrationLength = TimeSpan.FromMilliseconds(1500);

        await Task.Run(async () =>
        {
            timer.Stop();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                StopWatchLabel.Text = "00" + " Sekunden";
                EndStopWatchButton.IsVisible = false;
            });
            await Task.Delay(50);
            Vibration.Default.Vibrate(vibrationLength);
            await Task.Delay(3000);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                DisplayNextCardCommand.Execute(null);
            });
        });
    }

    private Color GetColorFromResources(string key)
    {
        var color = Colors.White;
        if (App.Current.Resources.TryGetValue(key, out var colorvalue))
        {
            color = (Color)colorvalue;
        }

        return color;
    }

    public async void AnimateCardText()
    {
        await Task.Run(async () =>
        {
            var animation = new Animation();
            var singleAnimationDuration = 1.0 / 2.0;

            for (int i = 0; i < 1; i++)
            {
                // pan right
                animation.Add(i * 2 * singleAnimationDuration, (i * 2 + 1) * singleAnimationDuration, new Animation(v => CardTextStackLayout.TranslationX = v, 0, 15, Easing.CubicOut));
                // pan left
                animation.Add((i * 2 + 1) * singleAnimationDuration, (i * 2 + 2) * singleAnimationDuration, new Animation(v => CardTextStackLayout.TranslationX = v, 15, -15, Easing.CubicOut));
            }
            // return to starting position
            animation.Add(1 - singleAnimationDuration, 1, new Animation(v => CardTextStackLayout.TranslationX = v, -15, 0, Easing.CubicOut));
            animation.Commit(this, "CardTextSwingAnimation", length: 250, easing: Easing.CubicOut);
        });
    }
}