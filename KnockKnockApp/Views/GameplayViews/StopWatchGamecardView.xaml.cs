using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Views.GameplayViews;

public partial class StopWatchGamecardView : ContentView
{
    public static readonly BindableProperty CurrentCardProperty = BindableProperty.Create(nameof(CurrentCard), typeof(GameCardDto), typeof(StopWatchGamecardView));

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
            StopWatchLabel.Text = stopWatchTime.ToString();
        });
        currentStopWatchTime = stopWatchTime;
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(1000);
        timer.Tick += (s, e) =>
        {
            Vibration.Default.Vibrate(tickVibrationLength);
            currentStopWatchTime--;
            MainThread.BeginInvokeOnMainThread(() =>
            {
                StopWatchLabel.Text = currentStopWatchTime.ToString();
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
        if (timer.IsRunning)
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
                StopWatchLabel.Text = "0";
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
}