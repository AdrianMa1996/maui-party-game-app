using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Views.GameplayViews;

public partial class TeamBasicGamecardView : ContentView
{
    public static readonly BindableProperty CurrentCardProperty = BindableProperty.Create(nameof(CurrentCard), typeof(GameCardDto), typeof(TeamBasicGamecardView), propertyChanged: OnGamecardChanged);

    static void OnGamecardChanged(BindableObject bindable, object oldValue, object newValue)
    {
        TeamBasicGamecardView gamecardView = (TeamBasicGamecardView)bindable;
        gamecardView.AnimateCardText();
    }

    public GameCardDto CurrentCard
    {
        get => (GameCardDto)GetValue(CurrentCardProperty);
        set => SetValue(CurrentCardProperty, value);
    }

    public static readonly BindableProperty CurrentGameModeProperty = BindableProperty.Create(nameof(CurrentGameMode), typeof(GameMode), typeof(TeamBasicGamecardView));

    public GameMode CurrentGameMode
    {
        get => (GameMode)GetValue(CurrentGameModeProperty);
        set => SetValue(CurrentGameModeProperty, value);
    }

    public static readonly BindableProperty TeamOneProperty = BindableProperty.Create(nameof(TeamOne), typeof(Team), typeof(TeamBasicGamecardView));

    public Team TeamOne
    {
        get => (Team)GetValue(TeamOneProperty);
        set => SetValue(TeamOneProperty, value);
    }

    public static readonly BindableProperty TeamTwoProperty = BindableProperty.Create(nameof(TeamTwo), typeof(Team), typeof(TeamBasicGamecardView));

    public Team TeamTwo
    {
        get => (Team)GetValue(TeamTwoProperty);
        set => SetValue(TeamTwoProperty, value);
    }

    public static readonly BindableProperty PointsToTeamOneCommandProperty = BindableProperty.Create(nameof(PointsToTeamOneCommand), typeof(RelayCommand), typeof(TeamBasicGamecardView));

    public RelayCommand PointsToTeamOneCommand
    {
        get => (RelayCommand)GetValue(PointsToTeamOneCommandProperty);
        set => SetValue(PointsToTeamOneCommandProperty, value);
    }

    public static readonly BindableProperty PointsToTeamTwoCommandProperty = BindableProperty.Create(nameof(PointsToTeamTwoCommand), typeof(RelayCommand), typeof(TeamBasicGamecardView));

    public RelayCommand PointsToTeamTwoCommand
    {
        get => (RelayCommand)GetValue(PointsToTeamTwoCommandProperty);
        set => SetValue(PointsToTeamTwoCommandProperty, value);
    }

    public static readonly BindableProperty NavigateToManagePlayersCommandProperty = BindableProperty.Create(nameof(NavigateToManagePlayersCommand), typeof(RelayCommand), typeof(TeamBasicGamecardView));

    public RelayCommand NavigateToManagePlayersCommand
    {
        get { return (RelayCommand)GetValue(NavigateToManagePlayersCommandProperty); }
        set { SetValue(NavigateToManagePlayersCommandProperty, value); }
    }

    public static readonly BindableProperty NavigateToSelectGameModeCommandProperty = BindableProperty.Create(nameof(NavigateToSelectGameModeCommand), typeof(RelayCommand), typeof(TeamBasicGamecardView));

    public RelayCommand NavigateToSelectGameModeCommand
    {
        get { return (RelayCommand)GetValue(NavigateToSelectGameModeCommandProperty); }
        set { SetValue(NavigateToSelectGameModeCommandProperty, value); }
    }

    public static readonly BindableProperty DisplayNextCardCommandProperty = BindableProperty.Create(nameof(DisplayNextCardCommand), typeof(RelayCommand), typeof(TeamBasicGamecardView));

    public RelayCommand DisplayNextCardCommand
    {
        get => (RelayCommand)GetValue(DisplayNextCardCommandProperty);
        set => SetValue(DisplayNextCardCommandProperty, value);
    }

    public TeamBasicGamecardView()
	{
		InitializeComponent();
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