using CommunityToolkit.Mvvm.Input;
using KnockKnockApp.Models.Database;
using KnockKnockApp.Models.DTOs;

namespace KnockKnockApp.Views.CardGameExtension;

public partial class ExtensionTimeBombView : ContentView
{
    public static readonly BindableProperty CurrentCardProperty = BindableProperty.Create(nameof(CurrentCard), typeof(ExtensionCardDto), typeof(ExtensionTimeBombView), propertyChanged: OnGamecardChanged);

    static void OnGamecardChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ExtensionTimeBombView gamecardView = (ExtensionTimeBombView)bindable;
        gamecardView.AnimateCardText();
    }

    public ExtensionCardDto CurrentCard
    {
        get => (ExtensionCardDto)GetValue(CurrentCardProperty);
        set => SetValue(CurrentCardProperty, value);
    }

    public static readonly BindableProperty CurrentExtensionProperty = BindableProperty.Create(nameof(CurrentExtension), typeof(Extension), typeof(ExtensionTimeBombView));

    public Extension CurrentExtension
    {
        get => (Extension)GetValue(CurrentExtensionProperty);
        set => SetValue(CurrentExtensionProperty, value);
    }

    public static readonly BindableProperty NavigateToSelectCardGameExtensionCommandProperty = BindableProperty.Create(nameof(NavigateToSelectCardGameExtensionCommand), typeof(RelayCommand), typeof(ExtensionTimeBombView));

    public RelayCommand NavigateToSelectCardGameExtensionCommand
    {
        get { return (RelayCommand)GetValue(NavigateToSelectCardGameExtensionCommandProperty); }
        set { SetValue(NavigateToSelectCardGameExtensionCommandProperty, value); }
    }

    public static readonly BindableProperty DisplayNextCardCommandProperty = BindableProperty.Create(nameof(DisplayNextCardCommand), typeof(RelayCommand), typeof(ExtensionTimeBombView));

    public RelayCommand DisplayNextCardCommand
    {
        get => (RelayCommand)GetValue(DisplayNextCardCommandProperty);
        set => SetValue(DisplayNextCardCommandProperty, value);
    }

    public ExtensionTimeBombView()
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