using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace KnockKnockApp.Views.GameplayViews;

public partial class BasicGamecardView : ContentView
{
    public static readonly BindableProperty GamecardTitleProperty = BindableProperty.Create(nameof(GamecardTitle), typeof(string), typeof(BasicGamecardView), string.Empty);

    public string GamecardTitle
    {
        get => (string)GetValue(GamecardTitleProperty);
        set => SetValue(GamecardTitleProperty, value);
    }

    public static readonly BindableProperty GamecardTextProperty = BindableProperty.Create(nameof(GamecardText), typeof(string), typeof(BasicGamecardView));

    public string GamecardText
    {
        get => (string)GetValue(GamecardTextProperty);
        set => SetValue(GamecardTextProperty, value);
    }

    public static readonly BindableProperty GamecardBackgroundColorProperty = BindableProperty.Create(nameof(GamecardBackgroundColor), typeof(Color), typeof(BasicGamecardView));

    public Color GamecardBackgroundColor
    {
        get => (Color)GetValue(GamecardBackgroundColorProperty);
        set => SetValue(GamecardBackgroundColorProperty, value);
    }

    public static readonly BindableProperty GamecardTapGestureRecognizerCommandProperty = BindableProperty.Create(nameof(GamecardTapGestureRecognizerCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand GamecardTapGestureRecognizerCommand
    {
        get => (RelayCommand)GetValue(GamecardTapGestureRecognizerCommandProperty);
        set => SetValue(GamecardTapGestureRecognizerCommandProperty, value);
    }

    public static readonly BindableProperty LeaveGameModeCommandProperty = BindableProperty.Create(nameof(LeaveGameModeCommand), typeof(RelayCommand), typeof(BasicGamecardView));

    public RelayCommand LeaveGameModeCommand
    {
        get { return (RelayCommand)GetValue(LeaveGameModeCommandProperty); }
        set { SetValue(LeaveGameModeCommandProperty, value); }
    }

    public BasicGamecardView()
	{
		InitializeComponent();
	}
}