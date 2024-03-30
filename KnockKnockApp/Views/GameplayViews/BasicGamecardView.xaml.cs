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

    public static readonly BindableProperty GamecardProperty = BindableProperty.Create(nameof(Gamecard), typeof(GameCardDto), typeof(BasicGamecardView));

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
}