using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Views.GameplayViews;

public partial class BasicGamecardView : ContentView
{
    public static readonly BindableProperty GamecardTapGestureRecognizerCommandProperty = BindableProperty.Create(nameof(GamecardTapGestureRecognizerCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand GamecardTapGestureRecognizerCommand
    {
        get => (RelayCommand)GetValue(GamecardTapGestureRecognizerCommandProperty);
        set => SetValue(GamecardTapGestureRecognizerCommandProperty, value);
    }

    public static readonly BindableProperty NavigateToManagePlayersCommandProperty = BindableProperty.Create(nameof(NavigateToManagePlayersCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand NavigateToManagePlayersCommand
    {
        get { return (RelayCommand)GetValue(NavigateToManagePlayersCommandProperty); }
        set { SetValue(NavigateToManagePlayersCommandProperty, value); }
    }

    public static readonly BindableProperty LeaveGameModeCommandProperty = BindableProperty.Create(nameof(LeaveGameModeCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand LeaveGameModeCommand
    {
        get { return (RelayCommand)GetValue(LeaveGameModeCommandProperty); }
        set { SetValue(LeaveGameModeCommandProperty, value); }
    }

    public static readonly BindableProperty PointsTeamAProperty = BindableProperty.Create(nameof(PointsTeamA), typeof(string), typeof(BasicGamecardView), string.Empty);

    public string PointsTeamA
    {
        get => (string)GetValue(PointsTeamAProperty);
        set => SetValue(PointsTeamAProperty, value);
    }

    public static readonly BindableProperty PointsTeamBProperty = BindableProperty.Create(nameof(PointsTeamB), typeof(string), typeof(BasicGamecardView), string.Empty);

    public string PointsTeamB
    {
        get => (string)GetValue(PointsTeamBProperty);
        set => SetValue(PointsTeamBProperty, value);
    }

    public static readonly BindableProperty GamecardProperty = BindableProperty.Create(nameof(Gamecard), typeof(GameCardDto), typeof(BasicGamecardView), propertyChanged: OnGamecardChanged);

    static void OnGamecardChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BasicGamecardView gamecardView = (BasicGamecardView)bindable;
        gamecardView.AnimateCardText();
    }

    public GameCardDto Gamecard
    {
        get => (GameCardDto)GetValue(GamecardProperty);
        set => SetValue(GamecardProperty, value);
    }

    public static readonly BindableProperty GameModeProperty = BindableProperty.Create(nameof(GameMode), typeof(GameMode), typeof(BasicGamecardView));

    public GameMode GameMode
    {
        get => (GameMode)GetValue(GameModeProperty);
        set => SetValue(GameModeProperty, value);
    }

    public BasicGamecardView()
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