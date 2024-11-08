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

    private bool isTicking;
    private int minGameLength = 15000;
    private int maxGameLength = 30000;

    private async void this_Loaded(object sender, EventArgs e)
    {
        TimeBombImage.IsVisible = true;
        TimeBombExplosionImage.IsVisible = false;
        // TimeBombImage.Source = "image_time_bomb.png";
        MainGrid.BackgroundColor = GetColorFromResources("GreenCardColor");
        ExplodeButton.IsVisible = true;

        int timeUntilExplosion = Random.Shared.Next(minGameLength, maxGameLength);

        var timeBombAnimation = new Animation(v => TimeBombImage.Scale = v, 1, 1.3);
        timeBombAnimation.Commit(this, "TimeBombAnimation", 16, 2000, Easing.Linear, (v, c) => TimeBombImage.Scale = 1, () => true);
        isTicking = true;

        await Task.Run(async () =>
        {
            VibratePhone();
            await Task.Delay(timeUntilExplosion);
            if (isTicking)
            {
                await LetTimeBombExplode();
            }
        });
    }

    private async void TimeBombExplodeButton_Clicked(object sender, EventArgs e)
    {
        var answer = await Application.Current.MainPage.DisplayAlert("Zeitbombe vorzeitig anhalten?", "Seid ihr sicher, dass ihr die Zeitbombe vorzeitig anhalten wollt?", "Ja", "Nein");
        if (isTicking && answer)
        {
            await LetTimeBombExplode();
        }
    }

    private async Task LetTimeBombExplode()
    {
        TimeSpan vibrationLength = TimeSpan.FromMilliseconds(2000);

        await Task.Run(async () =>
        {
            isTicking = false;
            this.AbortAnimation("TimeBombAnimation");
            MainThread.BeginInvokeOnMainThread(() =>
            {
                // TimeBombImage.Source = "image_bomb_explosion.png";
                TimeBombImage.IsVisible = false;
                TimeBombExplosionImage.IsVisible = true;
                MainGrid.BackgroundColor = GetColorFromResources("RedCardColor");
                ExplodeButton.IsVisible = false;
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

    private async void VibratePhone()
    {
        TimeSpan tickVibrationLength = TimeSpan.FromMilliseconds(50);

        await Task.Run(async () =>
        {
            while (isTicking)
            {
                Vibration.Default.Vibrate(tickVibrationLength);
                await Task.Delay(333);
                if (!isTicking)
                {
                    break;
                }
                Vibration.Default.Vibrate(tickVibrationLength);
                await Task.Delay(666);
            }
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
                animation.Add(i * 2 * singleAnimationDuration, (i * 2 + 1) * singleAnimationDuration, new Animation(v => CardTextLabel.TranslationX = v, 0, 15, Easing.CubicOut));
                // pan left
                animation.Add((i * 2 + 1) * singleAnimationDuration, (i * 2 + 2) * singleAnimationDuration, new Animation(v => CardTextLabel.TranslationX = v, 15, -15, Easing.CubicOut));
            }
            // return to starting position
            animation.Add(1 - singleAnimationDuration, 1, new Animation(v => CardTextLabel.TranslationX = v, -15, 0, Easing.CubicOut));
            animation.Commit(this, "CardTextSwingAnimation", length: 250, easing: Easing.CubicOut);
        });
    }
}