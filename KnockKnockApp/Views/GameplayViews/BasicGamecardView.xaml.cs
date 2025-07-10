using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Views.GameplayViews;

public partial class BasicGamecardView : ContentView
{
    public static readonly BindableProperty CurrentCardProperty = BindableProperty.Create(nameof(CurrentCard), typeof(GameCardDto), typeof(BasicGamecardView), propertyChanged: OnGamecardChanged);

    static void OnGamecardChanged(BindableObject bindable, object oldValue, object newValue)
    {
        BasicGamecardView gamecardView = (BasicGamecardView)bindable;
        gamecardView.AnimateCardText();
    }

    public GameCardDto CurrentCard
    {
        get => (GameCardDto)GetValue(CurrentCardProperty);
        set => SetValue(CurrentCardProperty, value);
    }

    public static readonly BindableProperty CurrentGameModeProperty = BindableProperty.Create(nameof(CurrentGameMode), typeof(GameMode), typeof(BasicGamecardView));

    public GameMode CurrentGameMode
    {
        get => (GameMode)GetValue(CurrentGameModeProperty);
        set => SetValue(CurrentGameModeProperty, value);
    }

    public static readonly BindableProperty TemplateSizeProperty = BindableProperty.Create(nameof(TemplateSize), typeof(int), typeof(BasicGamecardView));

    public int TemplateSize
    {
        get => (int)GetValue(TemplateSizeProperty);
        set => SetValue(TemplateSizeProperty, value);
    }

    public static readonly BindableProperty NumberOfPlayedTemplateCardsProperty = BindableProperty.Create(nameof(NumberOfPlayedTemplateCards), typeof(int), typeof(BasicGamecardView));

    public int NumberOfPlayedTemplateCards
    {
        get => (int)GetValue(NumberOfPlayedTemplateCardsProperty);
        set => SetValue(NumberOfPlayedTemplateCardsProperty, value);
    }

    public static readonly BindableProperty TeamOneProperty = BindableProperty.Create(nameof(TeamOne), typeof(Team), typeof(BasicGamecardView));

    public Team TeamOne
    {
        get => (Team)GetValue(TeamOneProperty);
        set => SetValue(TeamOneProperty, value);
    }

    public static readonly BindableProperty TeamTwoProperty = BindableProperty.Create(nameof(TeamTwo), typeof(Team), typeof(BasicGamecardView));

    public Team TeamTwo
    {
        get => (Team)GetValue(TeamTwoProperty);
        set => SetValue(TeamTwoProperty, value);
    }

    public static readonly BindableProperty PointsToTeamOneCommandProperty = BindableProperty.Create(nameof(PointsToTeamOneCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand PointsToTeamOneCommand
    {
        get => (RelayCommand)GetValue(PointsToTeamOneCommandProperty);
        set => SetValue(PointsToTeamOneCommandProperty, value);
    }

    public static readonly BindableProperty PointsToTeamTwoCommandProperty = BindableProperty.Create(nameof(PointsToTeamTwoCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand PointsToTeamTwoCommand
    {
        get => (RelayCommand)GetValue(PointsToTeamTwoCommandProperty);
        set => SetValue(PointsToTeamTwoCommandProperty, value);
    }

    public static readonly BindableProperty NavigateToManagePlayersCommandProperty = BindableProperty.Create(nameof(NavigateToManagePlayersCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand NavigateToManagePlayersCommand
    {
        get { return (RelayCommand)GetValue(NavigateToManagePlayersCommandProperty); }
        set { SetValue(NavigateToManagePlayersCommandProperty, value); }
    }

    public static readonly BindableProperty NavigateToSelectGameModeCommandProperty = BindableProperty.Create(nameof(NavigateToSelectGameModeCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand NavigateToSelectGameModeCommand
    {
        get { return (RelayCommand)GetValue(NavigateToSelectGameModeCommandProperty); }
        set { SetValue(NavigateToSelectGameModeCommandProperty, value); }
    }

    public static readonly BindableProperty DisplayNextCardCommandProperty = BindableProperty.Create(nameof(DisplayNextCardCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand DisplayNextCardCommand
    {
        get => (RelayCommand)GetValue(DisplayNextCardCommandProperty);
        set => SetValue(DisplayNextCardCommandProperty, value);
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