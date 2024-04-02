using CommunityToolkit.Mvvm.Input;

namespace KnockKnockApp.Views.GameplayViews;

public partial class ScoreGamecardView : ContentView
{
    public static readonly BindableProperty GamecardTitleProperty = BindableProperty.Create(nameof(GamecardTitle), typeof(string), typeof(ScoreGamecardView), string.Empty);

    public string GamecardTitle
    {
        get => (string)GetValue(GamecardTitleProperty);
        set => SetValue(GamecardTitleProperty, value);
    }

    public static readonly BindableProperty GamecardTextProperty = BindableProperty.Create(nameof(GamecardText), typeof(string), typeof(ScoreGamecardView));

    public string GamecardText
    {
        get => (string)GetValue(GamecardTextProperty);
        set => SetValue(GamecardTextProperty, value);
    }

    public static readonly BindableProperty GamecardBackgroundColorProperty = BindableProperty.Create(nameof(GamecardBackgroundColor), typeof(Color), typeof(ScoreGamecardView));

    public Color GamecardBackgroundColor
    {
        get => (Color)GetValue(GamecardBackgroundColorProperty);
        set => SetValue(GamecardBackgroundColorProperty, value);
    }

    public static readonly BindableProperty PointsToTeamACommandProperty = BindableProperty.Create(nameof(PointsToTeamACommand), typeof(RelayCommand), typeof(ScoreGamecardView));

    public RelayCommand PointsToTeamACommand
    {
        get => (RelayCommand)GetValue(PointsToTeamACommandProperty);
        set => SetValue(PointsToTeamACommandProperty, value);
    }

    public static readonly BindableProperty PointsToTeamBCommandProperty = BindableProperty.Create(nameof(PointsToTeamBCommand), typeof(RelayCommand), typeof(ScoreGamecardView));

    public RelayCommand PointsToTeamBCommand
    {
        get => (RelayCommand)GetValue(PointsToTeamBCommandProperty);
        set => SetValue(PointsToTeamBCommandProperty, value);
    }

    public static readonly BindableProperty NavigateToManagePlayersCommandProperty = BindableProperty.Create(nameof(NavigateToManagePlayersCommand), typeof(RelayCommand), typeof(ScoreGamecardView));

    public RelayCommand NavigateToManagePlayersCommand
    {
        get { return (RelayCommand)GetValue(NavigateToManagePlayersCommandProperty); }
        set { SetValue(NavigateToManagePlayersCommandProperty, value); }
    }

    public static readonly BindableProperty LeaveGameModeCommandProperty = BindableProperty.Create(nameof(LeaveGameModeCommand), typeof(RelayCommand), typeof(ScoreGamecardView));

    public RelayCommand LeaveGameModeCommand
    {
        get { return (RelayCommand)GetValue(LeaveGameModeCommandProperty); }
        set { SetValue(LeaveGameModeCommandProperty, value); }
    }

    public static readonly BindableProperty GamecardPointValueProperty = BindableProperty.Create(nameof(GamecardPointValue), typeof(string), typeof(ScoreGamecardView), string.Empty);

    public string GamecardPointValue
    {
        get => (string)GetValue(GamecardPointValueProperty);
        set => SetValue(GamecardPointValueProperty, value);
    }

    public static readonly BindableProperty PointsTeamAProperty = BindableProperty.Create(nameof(PointsTeamA), typeof(string), typeof(ScoreGamecardView), string.Empty);

    public string PointsTeamA
    {
        get => (string)GetValue(PointsTeamAProperty);
        set => SetValue(PointsTeamAProperty, value);
    }

    public static readonly BindableProperty PointsTeamBProperty = BindableProperty.Create(nameof(PointsTeamB), typeof(string), typeof(ScoreGamecardView), string.Empty);

    public string PointsTeamB
    {
        get => (string)GetValue(PointsTeamBProperty);
        set => SetValue(PointsTeamBProperty, value);
    }

    public static readonly BindableProperty SkipCardCommandProperty = BindableProperty.Create(nameof(SkipCardCommand), typeof(RelayCommand), typeof(ScoreGamecardView));

    public RelayCommand SkipCardCommand
    {
        get => (RelayCommand)GetValue(SkipCardCommandProperty);
        set => SetValue(SkipCardCommandProperty, value);
    }

    public ScoreGamecardView()
	{
		InitializeComponent();
	}
}